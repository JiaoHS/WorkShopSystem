namespace WorkShopSystem.UI.cleardata
{
    partial class ClearDataForm
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
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(420, 24);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 23);
            this.btnClearData.TabIndex = 5;
            this.btnClearData.Text = "数据入库";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(268, 24);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(33, 26);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(201, 21);
            this.txtFile.TabIndex = 3;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 377);
            this.panel1.TabIndex = 6;
            // 
            // ClearDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Name = "ClearDataForm";
            this.Text = "数据处理入库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Panel panel1;
    }
}