namespace Windowsapp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblKeyPressCount;
        private System.Windows.Forms.Label lblMouseClickCount;
        private System.Windows.Forms.Label lblCpuTemp;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblStorageInfo;
        private System.Windows.Forms.Label lblGpuUsage;
        private System.Windows.Forms.Label lblNetworkUsage;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Timer systemInfoTimer;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Label lblHDivider1;
        private System.Windows.Forms.Label lblHDivider2;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblKeyPressCount = new System.Windows.Forms.Label();
            this.lblMouseClickCount = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblCpuTemp = new System.Windows.Forms.Label();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblStorageInfo = new System.Windows.Forms.Label();
            this.lblGpuUsage = new System.Windows.Forms.Label();
            this.lblNetworkUsage = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.systemInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.lblHDivider1 = new System.Windows.Forms.Label();
            this.lblHDivider2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKeyPressCount
            // 
            this.lblKeyPressCount.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKeyPressCount.Location = new System.Drawing.Point(10, 10);
            this.lblKeyPressCount.Name = "lblKeyPressCount";
            this.lblKeyPressCount.Size = new System.Drawing.Size(160, 50);
            this.lblKeyPressCount.TabIndex = 0;
            this.lblKeyPressCount.Text = "⌨️Key: 0　      (´・ω・`) ";
            this.lblKeyPressCount.Click += new System.EventHandler(this.lblKeyPressCount_Click);
            // 
            // lblMouseClickCount
            // 
            this.lblMouseClickCount.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMouseClickCount.Location = new System.Drawing.Point(10, 65);
            this.lblMouseClickCount.Name = "lblMouseClickCount";
            this.lblMouseClickCount.Size = new System.Drawing.Size(160, 50);
            this.lblMouseClickCount.TabIndex = 1;
            this.lblMouseClickCount.Text = "クリック回数:   (´・ω・`) ";
            // 
            // lblDistance
            // 
            this.lblDistance.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDistance.Location = new System.Drawing.Point(10, 120);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(160, 50);
            this.lblDistance.TabIndex = 2;
            this.lblDistance.Text = "📏 移動距離: 0.00 cm";
            this.lblDistance.Click += new System.EventHandler(this.lblDistance_Click);
            // 
            // lblCpuTemp
            // 
            this.lblCpuTemp.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpuTemp.Location = new System.Drawing.Point(175, 10);
            this.lblCpuTemp.Name = "lblCpuTemp";
            this.lblCpuTemp.Size = new System.Drawing.Size(160, 50);
            this.lblCpuTemp.TabIndex = 3;
            this.lblCpuTemp.Text = "🌡️CPU :       (´・ω・`) ";
            this.lblCpuTemp.Click += new System.EventHandler(this.lblCpuTemp_Click);
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoryUsage.Location = new System.Drawing.Point(175, 65);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(160, 50);
            this.lblMemoryUsage.TabIndex = 4;
            this.lblMemoryUsage.Text = "💾 メモリ使用率: (´・ω・`) ";
            // 
            // lblStorageInfo
            // 
            this.lblStorageInfo.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorageInfo.Location = new System.Drawing.Point(175, 120);
            this.lblStorageInfo.Name = "lblStorageInfo";
            this.lblStorageInfo.Size = new System.Drawing.Size(160, 50);
            this.lblStorageInfo.TabIndex = 5;
            this.lblStorageInfo.Text = "💿 ストレージ: (´・ω・`) ";
            // 
            // lblGpuUsage
            // 
            this.lblGpuUsage.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpuUsage.Location = new System.Drawing.Point(340, 10);
            this.lblGpuUsage.Name = "lblGpuUsage";
            this.lblGpuUsage.Size = new System.Drawing.Size(140, 50);
            this.lblGpuUsage.TabIndex = 6;
            this.lblGpuUsage.Text = "🎮 GPU使用率: (´・ω・`) ";
            // 
            // lblNetworkUsage
            // 
            this.lblNetworkUsage.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkUsage.Location = new System.Drawing.Point(340, 65);
            this.lblNetworkUsage.Name = "lblNetworkUsage";
            this.lblNetworkUsage.Size = new System.Drawing.Size(140, 50);
            this.lblNetworkUsage.TabIndex = 7;
            this.lblNetworkUsage.Text = "📡 NET使用率: (´・ω・`) ";
            // 
            // lblUptime
            // 
            this.lblUptime.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUptime.Location = new System.Drawing.Point(340, 120);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(140, 50);
            this.lblUptime.TabIndex = 8;
            this.lblUptime.Text = "⏰ 起動時間: (´・ω・`) ";
            // 
            // systemInfoTimer
            // 
            this.systemInfoTimer.Interval = 2000;
            this.systemInfoTimer.Tick += new System.EventHandler(this.systemInfoTimer_Tick);
            // 
            // lblDivider1
            // 
            this.lblDivider1.BackColor = System.Drawing.Color.Gray;
            this.lblDivider1.Location = new System.Drawing.Point(170, 10);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(2, 160);
            this.lblDivider1.TabIndex = 9;
            // 
            // lblDivider2
            // 
            this.lblDivider2.BackColor = System.Drawing.Color.Gray;
            this.lblDivider2.Location = new System.Drawing.Point(335, 10);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(2, 160);
            this.lblDivider2.TabIndex = 10;
            // 
            // lblHDivider1
            // 
            this.lblHDivider1.BackColor = System.Drawing.Color.Gray;
            this.lblHDivider1.Location = new System.Drawing.Point(10, 62);
            this.lblHDivider1.Name = "lblHDivider1";
            this.lblHDivider1.Size = new System.Drawing.Size(470, 2);
            this.lblHDivider1.TabIndex = 11;
            // 
            // lblHDivider2
            // 
            this.lblHDivider2.BackColor = System.Drawing.Color.Gray;
            this.lblHDivider2.Location = new System.Drawing.Point(10, 117);
            this.lblHDivider2.Name = "lblHDivider2";
            this.lblHDivider2.Size = new System.Drawing.Size(470, 2);
            this.lblHDivider2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(490, 180);
            this.Controls.Add(this.lblHDivider2);
            this.Controls.Add(this.lblHDivider1);
            this.Controls.Add(this.lblDivider2);
            this.Controls.Add(this.lblDivider1);
            this.Controls.Add(this.lblUptime);
            this.Controls.Add(this.lblNetworkUsage);
            this.Controls.Add(this.lblGpuUsage);
            this.Controls.Add(this.lblStorageInfo);
            this.Controls.Add(this.lblMemoryUsage);
            this.Controls.Add(this.lblCpuTemp);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblKeyPressCount);
            this.Controls.Add(this.lblMouseClickCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.Text = "✨ くもぱわー ✨";
            this.TopMost = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDistance;
    }
}

