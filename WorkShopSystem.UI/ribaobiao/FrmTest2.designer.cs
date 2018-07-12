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
            this.btnFullList = new System.Windows.Forms.Button();
            this.multiColHeaderDgvRiBaoBiao = new WorkShopSystem.UI.MultiColHeaderDgv();
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
            this.btnExcel.Location = new System.Drawing.Point(614, 29);
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
            // btnFullList
            // 
            this.btnFullList.Location = new System.Drawing.Point(424, 29);
            this.btnFullList.Name = "btnFullList";
            this.btnFullList.Size = new System.Drawing.Size(75, 23);
            this.btnFullList.TabIndex = 14;
            this.btnFullList.Text = "填充列表";
            this.btnFullList.UseVisualStyleBackColor = true;
            this.btnFullList.Click += new System.EventHandler(this.btnFullList_Click);
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
            // FrmTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
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

        }

        #endregion
        private MultiColHeaderDgv multiColHeaderDgvRiBaoBiao;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFullList;
    }
}

