using WorkShopSystem.UI;

namespace MultiColHeaderDgvTest
{
    partial class FrmTest2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("工艺流程（名称）");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("型号");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("编号");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("生产设备栏", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("零件编号");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("定额/班");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("需求标准产能");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("生产信息栏");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("压铸车间 产能日报表", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLoadD = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cbMonthLIst = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiColHeaderDgv2 = new WorkShopSystem.UI.MultiColHeaderDgv();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadD
            // 
            this.btnLoadD.Location = new System.Drawing.Point(496, 25);
            this.btnLoadD.Name = "btnLoadD";
            this.btnLoadD.Size = new System.Drawing.Size(85, 25);
            this.btnLoadD.TabIndex = 1;
            this.btnLoadD.Text = "加载数据列表";
            this.btnLoadD.UseVisualStyleBackColor = true;
            this.btnLoadD.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(844, 1);
            this.treeView2.Name = "treeView2";
            treeNode10.Name = "gongyiliucheng";
            treeNode10.Text = "工艺流程（名称）";
            treeNode11.Name = "xinghao";
            treeNode11.Text = "型号";
            treeNode12.Name = "bianhao";
            treeNode12.Text = "编号";
            treeNode13.Name = "shenchanshebeilan";
            treeNode13.Text = "生产设备栏";
            treeNode14.Name = "lingjianbianhao";
            treeNode14.Text = "零件编号";
            treeNode15.Name = "dingeban";
            treeNode15.Text = "定额/班";
            treeNode16.Name = "xuqiubiaozhunchanneng";
            treeNode16.Text = "需求标准产能";
            treeNode17.Name = "shenchanxinxilan";
            treeNode17.Text = "生产信息栏";
            treeNode18.Name = "tongji";
            treeNode18.Text = "压铸车间 产能日报表";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18});
            this.treeView2.Size = new System.Drawing.Size(201, 84);
            this.treeView2.TabIndex = 3;
            this.treeView2.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(701, 25);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "生成excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbMonthLIst
            // 
            this.cbMonthLIst.FormattingEnabled = true;
            this.cbMonthLIst.Location = new System.Drawing.Point(268, 30);
            this.cbMonthLIst.Name = "cbMonthLIst";
            this.cbMonthLIst.Size = new System.Drawing.Size(121, 20);
            this.cbMonthLIst.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.multiColHeaderDgv2);
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 466);
            this.panel1.TabIndex = 9;
            // 
            // multiColHeaderDgv2
            // 
            this.multiColHeaderDgv2.AllowUserToAddRows = false;
            this.multiColHeaderDgv2.AllowUserToDeleteRows = false;
            this.multiColHeaderDgv2.AllowUserToResizeRows = false;
            this.multiColHeaderDgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiColHeaderDgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.multiColHeaderDgv2.ColumnHeadersHeight = 18;
            this.multiColHeaderDgv2.Location = new System.Drawing.Point(0, 0);
            this.multiColHeaderDgv2.myColHeaderTreeView = this.treeView2;
            this.multiColHeaderDgv2.Name = "multiColHeaderDgv2";
            this.multiColHeaderDgv2.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.multiColHeaderDgv2.Size = new System.Drawing.Size(1042, 463);
            this.multiColHeaderDgv2.TabIndex = 4;
            // 
            // FrmTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbMonthLIst);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.btnLoadD);
            this.Name = "FrmTest2";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadD;
        private MultiColHeaderDgv multiColHeaderDgv2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cbMonthLIst;
        private System.Windows.Forms.Panel panel1;
    }
}

