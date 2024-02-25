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
            this.lblKeyPressCount = new System.Windows.Forms.Label();
            this.lblMouseClickCount = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKeyPressCount
            // 
            this.lblKeyPressCount.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKeyPressCount.Location = new System.Drawing.Point(12, 67);
            this.lblKeyPressCount.Name = "lblKeyPressCount";
            this.lblKeyPressCount.Size = new System.Drawing.Size(620, 32);
            this.lblKeyPressCount.TabIndex = 0;
            this.lblKeyPressCount.Text = "キーボード入力回数: 0";
            this.lblKeyPressCount.Click += new System.EventHandler(this.lblKeyPressCount_Click);
            // 
            // lblMouseClickCount
            // 
            this.lblMouseClickCount.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMouseClickCount.Location = new System.Drawing.Point(12, 30);
            this.lblMouseClickCount.Name = "lblMouseClickCount";
            this.lblMouseClickCount.Size = new System.Drawing.Size(494, 37);
            this.lblMouseClickCount.TabIndex = 1;
            this.lblMouseClickCount.Text = "マウスクリック回数: 0";
            // 
            // lblDistance
            // 
            this.lblDistance.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDistance.Location = new System.Drawing.Point(12, 127);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(282, 49);
            this.lblDistance.TabIndex = 2;
            this.lblDistance.Text = "null";
            this.lblDistance.Click += new System.EventHandler(this.lblDistance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 199);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblKeyPressCount);
            this.Controls.Add(this.lblMouseClickCount);
            this.Name = "Form1";
            this.Text = "くもぱわー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDistance;
    }
}

