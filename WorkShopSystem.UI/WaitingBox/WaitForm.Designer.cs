﻿namespace WorkShopSystem.UI.WaitingBox
{
    partial class frmWaitingBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTimer = new System.Windows.Forms.Label();
            this.labMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.labTimer);
            this.panel1.Controls.Add(this.labMessage);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 144);
            this.panel1.TabIndex = 0;
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labTimer.ForeColor = System.Drawing.Color.Red;
            this.labTimer.Location = new System.Drawing.Point(155, 77);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(30, 16);
            this.labTimer.TabIndex = 2;
            this.labTimer.Text = "0秒";
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labMessage.Location = new System.Drawing.Point(152, 54);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(170, 16);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "正在处理数据，请稍后...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkShopSystem.UI.Properties.Resources.waiting;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 141);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmWaitingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(365, 152);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWaitingBox";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "frmWaitingBox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.Timer timer1;
    }
}