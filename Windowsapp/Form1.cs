using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windowsapp
{
    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public int KeyPressCount { get; set; } = 0;
        public int MouseClickCount { get; set; } = 0;

        // 前回のマウス位置
        private Point previousPoint = Point.Empty;
        // 総移動距離（ピクセル）
        private double totalDistance = 0;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        public void UpdateKeyPressCount()
        {
            lblKeyPressCount.Text = $"キーボード入力回数: {KeyPressCount}";
        }

        public void UpdateMouseClickCount()
        {
            lblMouseClickCount.Text = $"マウスクリック回数: {MouseClickCount}";
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
            using (Graphics graphics = this.CreateGraphics())
            {
                float dpiX = graphics.DpiX;
                float inches = pixels / dpiX;
                float cm = inches * 2.54f;
                lblDistance.Text = $"総移動距離: {cm:F2} cm";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblDistance_Click(object sender, EventArgs e)
        {

        }

        private void lblKeyPressCount_Click(object sender, EventArgs e)
        {

        }
    }

}
