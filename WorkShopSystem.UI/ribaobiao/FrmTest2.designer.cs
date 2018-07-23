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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiColHeaderDgvRiBaoBiao = new WorkShopSystem.UI.MultiColHeaderDgv();
            this.btnFullList = new System.Windows.Forms.Button();
            this.btnLoadD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonthLIst = new System.Windows.Forms.ComboBox();
            this.cbCheJianList = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgvRiBaoBiao)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(844, 1);
            this.treeView2.Name = "treeView2";
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
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView2.Size = new System.Drawing.Size(201, 84);
            this.treeView2.TabIndex = 3;
            this.treeView2.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(746, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "生成excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.multiColHeaderDgvRiBaoBiao);
            this.panel1.Location = new System.Drawing.Point(6, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 453);
            this.panel1.TabIndex = 9;
            // 
            // multiColHeaderDgvRiBaoBiao
            // 
            this.multiColHeaderDgvRiBaoBiao.AllowUserToAddRows = false;
            this.multiColHeaderDgvRiBaoBiao.AllowUserToDeleteRows = false;
            this.multiColHeaderDgvRiBaoBiao.AllowUserToResizeRows = false;
            this.multiColHeaderDgvRiBaoBiao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.multiColHeaderDgvRiBaoBiao.ColumnHeadersHeight = 18;
            this.multiColHeaderDgvRiBaoBiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiColHeaderDgvRiBaoBiao.Location = new System.Drawing.Point(0, 0);
            this.multiColHeaderDgvRiBaoBiao.myColHeaderTreeView = this.treeView2;
            this.multiColHeaderDgvRiBaoBiao.Name = "multiColHeaderDgvRiBaoBiao";
            this.multiColHeaderDgvRiBaoBiao.ReadOnly = true;
            this.multiColHeaderDgvRiBaoBiao.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgvRiBaoBiao.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgvRiBaoBiao.Size = new System.Drawing.Size(1039, 453);
            this.multiColHeaderDgvRiBaoBiao.TabIndex = 4;
            // 
            // btnFullList
            // 
            this.btnFullList.Location = new System.Drawing.Point(622, 28);
            this.btnFullList.Name = "btnFullList";
            this.btnFullList.Size = new System.Drawing.Size(75, 23);
            this.btnFullList.TabIndex = 14;
            this.btnFullList.Text = "填充列表";
            this.btnFullList.UseVisualStyleBackColor = true;
            this.btnFullList.Click += new System.EventHandler(this.btnFullList_Click);
            // 
            // btnLoadD
            // 
            this.btnLoadD.Location = new System.Drawing.Point(465, 28);
            this.btnLoadD.Name = "btnLoadD";
            this.btnLoadD.Size = new System.Drawing.Size(85, 25);
            this.btnLoadD.TabIndex = 23;
            this.btnLoadD.Text = "加载数据列表";
            this.btnLoadD.UseVisualStyleBackColor = true;
            this.btnLoadD.Click += new System.EventHandler(this.btnLoadD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "车间：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "月份：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbMonthLIst
            // 
            this.cbMonthLIst.FormattingEnabled = true;
            this.cbMonthLIst.Location = new System.Drawing.Point(280, 33);
            this.cbMonthLIst.Name = "cbMonthLIst";
            this.cbMonthLIst.Size = new System.Drawing.Size(121, 20);
            this.cbMonthLIst.TabIndex = 20;
            this.cbMonthLIst.SelectedIndexChanged += new System.EventHandler(this.cbMonthLIst_SelectedIndexChanged);
            // 
            // cbCheJianList
            // 
            this.cbCheJianList.FormattingEnabled = true;
            this.cbCheJianList.Location = new System.Drawing.Point(80, 34);
            this.cbCheJianList.Name = "cbCheJianList";
            this.cbCheJianList.Size = new System.Drawing.Size(121, 20);
            this.cbCheJianList.TabIndex = 24;
            this.cbCheJianList.SelectedIndexChanged += new System.EventHandler(this.cbCheJianList_SelectedIndexChanged);
            // 
            // FrmTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.cbCheJianList);
            this.Controls.Add(this.btnLoadD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMonthLIst);
            this.Controls.Add(this.btnFullList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.treeView2);
            this.Name = "FrmTest2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车间日报表统计首页";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgvRiBaoBiao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MultiColHeaderDgv multiColHeaderDgvRiBaoBiao;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFullList;
        private System.Windows.Forms.Button btnLoadD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonthLIst;
        private System.Windows.Forms.ComboBox cbCheJianList;
    }
}

