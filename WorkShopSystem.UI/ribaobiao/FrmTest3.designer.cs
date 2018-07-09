using WorkShopSystem.UI;

namespace MultiColHeaderDgvTest
{
    partial class FrmTest3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("工艺流程（名称）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("型号");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("编号");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("生产设备栏", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("零件编号");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("定额/班");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("需求标准产能");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("生产信息栏");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("压铸车间 产能日报表", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.btnLoadD = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.multiColHeaderDgv2 = new WorkShopSystem.UI.MultiColHeaderDgv();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonthLIst = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadD
            // 
            this.btnLoadD.Location = new System.Drawing.Point(208, 24);
            this.btnLoadD.Name = "btnLoadD";
            this.btnLoadD.Size = new System.Drawing.Size(85, 25);
            this.btnLoadD.TabIndex = 1;
            this.btnLoadD.Text = "加载数据列表";
            this.btnLoadD.UseVisualStyleBackColor = true;
            this.btnLoadD.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(366, 26);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "生成excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // multiColHeaderDgv2
            // 
            this.multiColHeaderDgv2.AllowUserToAddRows = false;
            this.multiColHeaderDgv2.AllowUserToDeleteRows = false;
            this.multiColHeaderDgv2.AllowUserToResizeRows = false;
            this.multiColHeaderDgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.multiColHeaderDgv2.ColumnHeadersHeight = 18;
            this.multiColHeaderDgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiColHeaderDgv2.Location = new System.Drawing.Point(0, 0);
            this.multiColHeaderDgv2.myColHeaderTreeView = this.treeView1;
            this.multiColHeaderDgv2.Name = "multiColHeaderDgv2";
            this.multiColHeaderDgv2.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgv2.Size = new System.Drawing.Size(1029, 441);
            this.multiColHeaderDgv2.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(562, 1);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "gongyiliucheng";
            treeNode1.Text = "工艺流程（名称）";
            treeNode2.Name = "xinghao";
            treeNode2.Text = "型号";
            treeNode3.Name = "bianhao";
            treeNode3.Text = "编号";
            treeNode4.Name = "shenchanshebeilan";
            treeNode4.Text = "生产设备栏";
            treeNode5.Name = "lingjianbianhao";
            treeNode5.Text = "零件编号";
            treeNode6.Name = "dingeban";
            treeNode6.Text = "定额/班";
            treeNode7.Name = "xuqiubiaozhunchanneng";
            treeNode7.Text = "需求标准产能";
            treeNode8.Name = "shenchanxinxilan";
            treeNode8.Text = "生产信息栏";
            treeNode9.Name = "tongji";
            treeNode9.Text = "压铸车间 产能日报表";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(201, 84);
            this.treeView1.TabIndex = 6;
            this.treeView1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "月份：";
            // 
            // cbMonthLIst
            // 
            this.cbMonthLIst.FormattingEnabled = true;
            this.cbMonthLIst.Location = new System.Drawing.Point(61, 29);
            this.cbMonthLIst.Name = "cbMonthLIst";
            this.cbMonthLIst.Size = new System.Drawing.Size(121, 20);
            this.cbMonthLIst.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.multiColHeaderDgv2);
            this.panel1.Location = new System.Drawing.Point(4, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 441);
            this.panel1.TabIndex = 16;
            // 
            // FrmTest3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMonthLIst);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnLoadD);
            this.Name = "FrmTest3";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadD;
        private MultiColHeaderDgv multiColHeaderDgv2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonthLIst;
        private System.Windows.Forms.Panel panel1;
    }
}

