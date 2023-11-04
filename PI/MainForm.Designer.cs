namespace PI
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExponentBox = new System.Windows.Forms.TextBox();
            this.ProgressStatusBar = new System.Windows.Forms.ProgressBar();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 45);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Ticker
            // 
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(93, 45);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "2";
            // 
            // ExponentBox
            // 
            this.ExponentBox.BackColor = System.Drawing.SystemColors.Control;
            this.ExponentBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExponentBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExponentBox.Location = new System.Drawing.Point(35, 9);
            this.ExponentBox.Name = "ExponentBox";
            this.ExponentBox.Size = new System.Drawing.Size(133, 16);
            this.ExponentBox.TabIndex = 3;
            this.ExponentBox.Text = "1";
            this.ExponentBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExponentBox_KeyPress);
            // 
            // ProgressStatusBar
            // 
            this.ProgressStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressStatusBar.Location = new System.Drawing.Point(12, 74);
            this.ProgressStatusBar.Name = "ProgressStatusBar";
            this.ProgressStatusBar.Size = new System.Drawing.Size(535, 23);
            this.ProgressStatusBar.TabIndex = 4;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TimeLabel.Location = new System.Drawing.Point(185, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(362, 48);
            this.TimeLabel.TabIndex = 5;
            this.TimeLabel.Text = "00:00:00.0000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "桁";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 109);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ProgressStatusBar);
            this.Controls.Add(this.ExponentBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "PI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExponentBox;
        private System.Windows.Forms.ProgressBar ProgressStatusBar;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label label3;
    }
}

