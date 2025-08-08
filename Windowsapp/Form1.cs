using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace Windowsapp
{
    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public int KeyPressCount { get; set; }
        public int MouseClickCount { get; set; }

        // 前回のマウス位置
        private Point previousPoint = Point.Empty;
        // 総移動距離（ピクセル）
        private double totalDistance = 0;
        
        // システム情報用
        private ComputerInfo computerInfo;
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private DateTime startTime;
        
        // DPI情報をキャッシュ
        private float cachedDpiX = 96f; // デフォルト値
        
        // 表示モードを通常モードで固定

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            KeyPressCount = 0;
            MouseClickCount = 0;
            computerInfo = new ComputerInfo();
            startTime = DateTime.Now;
            InitializeDpi();
            InitializeSystemMonitoring();
        }
        
        private void InitializeDpi()
        {
            try
            {
                using (Graphics graphics = this.CreateGraphics())
                {
                    cachedDpiX = graphics.DpiX;
                }
            }
            catch
            {
                cachedDpiX = 96f; // フォールバック値
            }
        }
        
        private void InitializeSystemMonitoring()
        {
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                cpuCounter.NextValue(); // 初回呼び出し
                systemInfoTimer.Start();
            }
            catch (Exception ex)
            {
                // パフォーマンスカウンタが利用できない場合のフォールバック
                lblCpuTemp.Text = "🌡️ CPU温度: (´･ω･`) 取得できません";
                lblMemoryUsage.Text = "💾 メモリ使用率: (´･ω･`) 取得できません";
            }
        }

        public void UpdateKeyPressCount()
        {
            string keyboardEmoji = GetKeyboardEmoji(KeyPressCount);
            lblKeyPressCount.Text = string.Format("KEY: {0}\n{1}", 
                KeyPressCount, keyboardEmoji);
        }

        public void UpdateMouseClickCount()
        {
            string mouseEmoji = GetMouseEmoji(MouseClickCount);
            lblMouseClickCount.Text = string.Format("CLICK: {0}\n{1}", 
                MouseClickCount, mouseEmoji);
        }


        public void HandleMouseMove(Point currentMousePosition)
        {
            // マウスの現在位置と前回位置との距離を計算
            if (!previousPoint.IsEmpty)
            {
                double distance = Math.Sqrt(Math.Pow(currentMousePosition.X - previousPoint.X, 2) + Math.Pow(currentMousePosition.Y - previousPoint.Y, 2));
                totalDistance += distance;
                ConvertPixelsToCentimeters((float)totalDistance);
            }
            previousPoint = currentMousePosition; // 現在位置を更新
        }

        private void ConvertPixelsToCentimeters(float pixels)
        {
            float inches = pixels / cachedDpiX;
            float cm = inches * 2.54f;
            string distanceEmoji = GetDistanceEmoji(cm);
            lblDistance.Text = string.Format("MOVE: {0:F1}cm\n{1}", 
                cm, distanceEmoji);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初期表示の更新
            UpdateSystemInfo();
        }
        
        
        

        private void lblDistance_Click(object sender, EventArgs e)
        {

        }

        private void lblKeyPressCount_Click(object sender, EventArgs e)
        {

        }
        
        private void systemInfoTimer_Tick(object sender, EventArgs e)
        {
            UpdateSystemInfo();
        }
        
        private void UpdateSystemInfo()
        {
            try
            {
                // CPU使用率
                if (cpuCounter != null)
                {
                    float cpuUsage = cpuCounter.NextValue();
                    string cpuEmoji = GetCpuEmoji(cpuUsage);
                    string cpuBar = GetProgressBar(cpuUsage);
                    lblCpuTemp.Text = string.Format("CPU: {0:F1}%\n{1}", 
                        cpuUsage, cpuEmoji);
                }
                
                // メモリ使用率
                if (ramCounter != null)
                {
                    float availableRAM = ramCounter.NextValue();
                    ulong totalRAM = computerInfo.TotalPhysicalMemory / (1024 * 1024); // MB変換
                    float usedRAM = totalRAM - availableRAM;
                    float memoryUsage = (usedRAM / totalRAM) * 100;
                    string memoryEmoji = GetMemoryEmoji(memoryUsage);
                    string memoryBar = GetProgressBar(memoryUsage);
                    lblMemoryUsage.Text = string.Format("RAM: {0:F1}%\n{1}", 
                        memoryUsage, memoryEmoji);
                }
                
                // ストレージ情報
                DriveInfo cDrive = new DriveInfo("C");
                if (cDrive.IsReady)
                {
                    long totalSpace = cDrive.TotalSize / (1024 * 1024 * 1024); // GB変換
                    long freeSpace = cDrive.AvailableFreeSpace / (1024 * 1024 * 1024);
                    long usedSpace = totalSpace - freeSpace;
                    float storageUsage = ((float)usedSpace / totalSpace) * 100;
                    string storageEmoji = GetStorageEmoji(storageUsage);
                    string storageBar = GetProgressBar(storageUsage);
                    lblStorageInfo.Text = string.Format("SSD: {0:F1}%\n{1}", 
                        storageUsage, storageEmoji);
                }
                
                // GPU使用率（簡易版）
                Random rand = new Random();
                float gpuUsage = 15 + rand.Next(0, 70); // 仮想的なGPU使用率
                string gpuEmoji = GetRandomGpuEmoji();
                string gpuBar = GetProgressBar(gpuUsage);
                lblGpuUsage.Text = string.Format("GPU: {0:F1}%\n{1}", 
                    gpuUsage, gpuEmoji);
                
                // ネットワーク使用率（簡易版）
                float networkUsage = 5 + rand.Next(0, 40); // 仮想的なネットワーク使用率
                string networkEmoji = GetRandomNetworkEmoji();
                string networkBar = GetProgressBar(networkUsage);
                lblNetworkUsage.Text = string.Format("NET: {0:F1}%\n{1}", 
                    networkUsage, networkEmoji);
                
                // 起動時間
                TimeSpan uptime = DateTime.Now - startTime;
                string uptimeEmoji = GetUptimeEmoji(uptime);
                int totalMinutes = (int)uptime.TotalMinutes;
                lblUptime.Text = string.Format("UP: {0}h{1}m\n{2}", 
                    uptime.Hours, uptime.Minutes, uptimeEmoji);
            }
            catch (Exception ex)
            {
                // エラーハンドリング
            }
        }
        
        private string GetCpuEmoji(float usage)
        {
            if (usage < 30) return "(´∀｀)♡";
            else if (usage < 60) return "(＾▽＾)";
            else if (usage < 80) return "(；´Д｀)";
            else return "(>_<)";
        }
        
        private string GetMemoryEmoji(float usage)
        {
            if (usage < 50) return "ヽ(´▽`)/";
            else if (usage < 70) return "(・∀・)";
            else if (usage < 85) return "(´･ω･`)";
            else return "(｡•́︿•̀｡)";
        }
        
        private string GetStorageEmoji(float usage)
        {
            if (usage < 70) return "٩(◕‿◕)۶";
            else if (usage < 85) return "(￣▽￣)";
            else if (usage < 95) return "(´・ω・`)";
            else return "(╥﹏╥)";
        }
        
        private string GetRandomGpuEmoji()
        {
            string[] emojis = { "(｡◕‿◕｡)", "ヾ(≧▽≦*)o", "(＾◡＾)", "(*´▽`*)", "(◍•ᴗ•◍)" };
            Random rand = new Random();
            return emojis[rand.Next(emojis.Length)];
        }
        
        private string GetRandomNetworkEmoji()
        {
            string[] emojis = { "ヽ(°◇° )ノ", "(≧∇≦)ﾉ", "(๑˃̵ᴗ˂̵)و", "٩(｡•́‿•̀｡)۶", "(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧" };
            Random rand = new Random();
            return emojis[rand.Next(emojis.Length)];
        }
        
        private string GetUptimeEmoji(TimeSpan uptime)
        {
            int totalMinutes = (int)uptime.TotalMinutes;
            if (totalMinutes < 30) return "(ﾉ´ヮ`)ﾉ*: ･ﾟ";
            else if (totalMinutes < 120) return "(◕‿◕)♡";
            else if (totalMinutes < 360) return "(￣▽￣)";
            else if (totalMinutes < 720) return "(´･ω･`)";
            else return "(｡•̀ᴗ-)✧";
        }
        
        // プログレスバー風の表示を生成
        private string GetProgressBar(float percentage)
        {
            int filled = (int)(percentage / 20);
            int empty = 5 - filled;
            string bar = "";
            for (int i = 0; i < filled; i++) bar += "█";
            for (int i = 0; i < empty; i++) bar += "░";
            return bar;
        }
        
        // CPU状態テキスト
        private string GetCpuStatusText(float usage)
        {
            if (usage < 20) return "のんびり中～ (/・ω・)/";
            else if (usage < 50) return "順調に稼働中♪";
            else if (usage < 75) return "がんばってる！ (´∀｀)";
            else if (usage < 90) return "フル稼働中！！ (>_<)";
            else return "限界突破！！ (╯°□°）╯";
        }
        
        // メモリ状態テキスト
        private string GetMemoryStatusText(float usage)
        {
            if (usage < 40) return "余裕だね～ ヽ(´▽`)/";
            else if (usage < 60) return "まだまだいけるよ！";
            else if (usage < 80) return "ちょっと重いかも (´･ω･`)";
            else if (usage < 95) return "メモリが苦しそう (｡•́︿•̀｡)";
            else return "メモリパンク寸前！ (゜□゜)";
        }
        
        // GPU状態テキスト
        private string GetGpuStatusText(float usage)
        {
            if (usage < 30) return "グラフィック軽々～♪";
            else if (usage < 60) return "描画がんばってる！";
            else if (usage < 80) return "フル描画モード！ (｡◕‿◕｡)";
            else return "グラフィック爆発中！ ✧*｡٩(ˊωˋ*)و✧*｡";
        }
        
        // ネットワーク状態テキスト
        private string GetNetworkStatusText(float usage)
        {
            if (usage < 20) return "通信のんびり～";
            else if (usage < 50) return "データ流れてる♪";
            else if (usage < 75) return "高速通信中！ (๑˃̵ᴗ˂̵)و";
            else return "ネット爆速！！ ٩(｡•́‿•̀｡)۶";
        }
        
        // 稼働時間バー
        private string GetUptimeBar(int minutes)
        {
            if (minutes < 60) return "🟩🟩🟩░░░░░░░ 新人さん♪";
            else if (minutes < 240) return "🟩🟩🟩🟩🟩░░░░░ がんばり中！";
            else if (minutes < 480) return "🟩🟩🟩🟩🟩🟩🟩░░░ ベテラン級！";
            else if (minutes < 720) return "🟩🟩🟩🟩🟩🟩🟩🟩🟩░ マスター級！";
            else return "🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩 レジェンド！";
        }
        
        // キーボード用絵文字
        private string GetKeyboardEmoji(int count)
        {
            if (count < 10) return "⌨️(´∀｀)";
            else if (count < 50) return "⌨️( ◠‿◠ )";
            else if (count < 150) return "⌨️ヽ(´▽`)/";
            else if (count < 300) return "⌨️٩(◕‿◕)۶";
            else if (count < 500) return "⌨️ლ(╹◡╹ლ)";
            else if (count < 800) return "⌨️ᕕ( ᐛ )ᕗ";
            else if (count < 1200) return "⌨️(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧";
            else return "⌨️⚡(°o°)⚡";
        }
        
        // キーボード進捗バー
        private string GetKeyboardProgressBar(int count)
        {
            int level = Math.Min(count / 50, 5);
            string bar = "";
            for (int i = 0; i < level; i++) bar += "🟦";
            for (int i = level; i < 5; i++) bar += "⬜";
            return bar;
        }
        
        // キーボード状態テキスト
        private string GetKeyboardStatusText(int count)
        {
            if (count < 50) return "ゆっくりタイピング中～";
            else if (count < 200) return "文字入力がんばってる♪";
            else if (count < 500) return "タイピング絶好調！";
            else if (count < 1000) return "キーボード戦士レベル！";
            else return "タイピング神の領域！ (ﾉ◕ヮ◕)ﾉ*:･ﾟ✧";
        }
        
        // マウス用絵文字
        private string GetMouseEmoji(int count)
        {
            if (count < 20) return "(´･ω･`)";
            else if (count < 50) return "(・∀・)";
            else if (count < 100) return "ヽ(°◇° )ノ";
            else if (count < 200) return "٩(｡•́‿•̀｡)۶";
            else return "(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧";
        }
        
        // マウス進捗バー
        private string GetMouseProgressBar(int count)
        {
            int level = Math.Min(count / 20, 5);
            string bar = "";
            for (int i = 0; i < level; i++) bar += "🟨";
            for (int i = level; i < 5; i++) bar += "⬜";
            return bar;
        }
        
        // マウス状態テキスト
        private string GetMouseStatusText(int count)
        {
            if (count < 20) return "のんびりクリック中～";
            else if (count < 50) return "クリックしてるね♪";
            else if (count < 100) return "マウス使いこなしてる！";
            else if (count < 200) return "クリックマスター級！";
            else return "マウス操作の達人！ ✧*｡٩(ˊωˋ*)و✧*｡";
        }
        
        // 距離用絵文字
        private string GetDistanceEmoji(float cm)
        {
            if (cm < 100) return "(´∀｀)";
            else if (cm < 500) return "ヽ(´▽`)/";
            else if (cm < 1000) return "٩(◕‿◕)۶";
            else if (cm < 5000) return "ᕕ( ᐛ )ᕗ";
            else return "(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧";
        }
        
        // 距離進捗バー
        private string GetDistanceProgressBar(float cm)
        {
            int level = Math.Min((int)(cm / 200), 5);
            string bar = "";
            for (int i = 0; i < level; i++) bar += "🟩";
            for (int i = level; i < 5; i++) bar += "⬜";
            return bar;
        }
        
        // 距離状態テキスト
        private string GetDistanceStatusText(float cm)
        {
            if (cm < 100) return "まだまだ移動開始♪";
            else if (cm < 500) return "マウスでお散歩中～";
            else if (cm < 1000) return "結構移動してるね！";
            else if (cm < 5000) return "マウス旅行者レベル！";
            else return "地球一周しちゃいそう！ ✧*｡٩(ˊωˋ*)و✧*｡";
        }

        private void lblCpuTemp_Click(object sender, EventArgs e)
        {

        }
        
        
    }

}
