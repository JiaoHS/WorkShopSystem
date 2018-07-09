namespace WorkShopSystem.UI.ribaobiao
{
    partial class FrmHome
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWorkShopList = new System.Windows.Forms.ComboBox();
            this.cbMonthLIst = new System.Windows.Forms.ComboBox();
            this.btnLoadD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "车间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "月份：";
            // 
            // cbWorkShopList
            // 
            this.cbWorkShopList.FormattingEnabled = true;
            this.cbWorkShopList.Location = new System.Drawing.Point(292, 57);
            this.cbWorkShopList.Name = "cbWorkShopList";
            this.cbWorkShopList.Size = new System.Drawing.Size(121, 20);
            this.cbWorkShopList.TabIndex = 14;
            // 
            // cbMonthLIst
            // 
            this.cbMonthLIst.FormattingEnabled = true;
            this.cbMonthLIst.Location = new System.Drawing.Point(100, 58);
            this.cbMonthLIst.Name = "cbMonthLIst";
            this.cbMonthLIst.Size = new System.Drawing.Size(121, 20);
            this.cbMonthLIst.TabIndex = 15;
            // 
            // btnLoadD
            // 
            this.btnLoadD.Location = new System.Drawing.Point(484, 55);
            this.btnLoadD.Name = "btnLoadD";
            this.btnLoadD.Size = new System.Drawing.Size(85, 25);
            this.btnLoadD.TabIndex = 18;
            this.btnLoadD.Text = "加载数据列表";
            this.btnLoadD.UseVisualStyleBackColor = true;
            this.btnLoadD.Click += new System.EventHandler(this.btnLoadD_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 259);
            this.Controls.Add(this.btnLoadD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbWorkShopList);
            this.Controls.Add(this.cbMonthLIst);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWorkShopList;
        private System.Windows.Forms.ComboBox cbMonthLIst;
        private System.Windows.Forms.Button btnLoadD;
    }
}