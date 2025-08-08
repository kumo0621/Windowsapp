using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace Windowsapp
{
    internal static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static LowLevelKeyboardProc _keyboardProc = KeyboardProc;
        private static LowLevelMouseProc _mouseProc = MouseProc;
        private static IntPtr _keyboardHookID = IntPtr.Zero;
        private static IntPtr _mouseHookID = IntPtr.Zero;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_RBUTTONDOWN = 0x0204;
        private static DateTime _lastMouseMoveTime = DateTime.MinValue;
        private const int MOUSE_MOVE_THROTTLE_MS = 16; // ~60fps

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            _keyboardHookID = SetHook(_keyboardProc);
            _mouseHookID = SetHook(_mouseProc);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            UnhookWindowsHookEx(_keyboardHookID);
            UnhookWindowsHookEx(_mouseHookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Form1.Instance.KeyPressCount++;
                Form1.Instance.Invoke((MethodInvoker)Form1.Instance.UpdateKeyPressCount);
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }

        private static IntPtr MouseProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                try
                {
                    MSLLHOOKSTRUCT mouseStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    Point mousePosition = new Point(mouseStruct.pt.x, mouseStruct.pt.y);

                    if (Form1.Instance != null && !Form1.Instance.IsDisposed)
                    {
                        // Form1のインスタンスがnullでない場合に処理を実行
                        switch ((int)wParam)
                        {
                            case WM_MOUSEMOVE:
                                // マウス移動のスロットリング（パフォーマンス向上）
                                DateTime now = DateTime.Now;
                                if ((now - _lastMouseMoveTime).TotalMilliseconds >= MOUSE_MOVE_THROTTLE_MS)
                                {
                                    _lastMouseMoveTime = now;
                                    // スレッド間での操作を安全に行うためにInvokeを使用
                                    if (Form1.Instance.InvokeRequired)
                                    {
                                        Form1.Instance.BeginInvoke(new Action(() => {
                                            if (Form1.Instance != null && !Form1.Instance.IsDisposed)
                                            {
                                                Form1.Instance.HandleMouseMove(mousePosition);
                                            }
                                        }));
                                    }
                                    else
                                    {
                                        Form1.Instance.HandleMouseMove(mousePosition);
                                    }
                                }
                                break;
                            case WM_LBUTTONDOWN:
                                // マウスの左ボタンが押されたときの処理
                                Form1.Instance.MouseClickCount++;
                                if (Form1.Instance.InvokeRequired)
                                {
                                    Form1.Instance.BeginInvoke((MethodInvoker)Form1.Instance.UpdateMouseClickCount);
                                }
                                else
                                {
                                    Form1.Instance.UpdateMouseClickCount();
                                }
                                break;
                            case WM_RBUTTONDOWN:
                                Form1.Instance.MouseClickCount++;
                                if (Form1.Instance.InvokeRequired)
                                {
                                    Form1.Instance.BeginInvoke((MethodInvoker)Form1.Instance.UpdateMouseClickCount);
                                }
                                else
                                {
                                    Form1.Instance.UpdateMouseClickCount();
                                }
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    // 例外を無視して処理を継続
                }
            }
            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }



        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, Delegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
    }
}