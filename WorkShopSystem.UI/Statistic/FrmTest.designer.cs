using WorkShopSystem.UI;

namespace MultiColHeaderDgvTest
{
    partial class FrmTest
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("年月");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("压铸产能");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("压铸计数器数");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("压铸");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("打砂1");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("打砂2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("挫披锋");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("H面全检");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("压铸车间内部报废数", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("压铸车间内部报废率");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("CNC产能");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("CNC");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("清洗");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("测漏");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("全检");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("机加缺陷报废数", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("机加车间最终报废率");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("测漏");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("CNC2");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("全检线");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("压铸缺陷报废总数", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("压铸车间最终报废率");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("车间数据统计", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode17,
            treeNode18,
            treeNode22,
            treeNode23});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.multiColHeaderDgv2 = new WorkShopSystem.UI.MultiColHeaderDgv();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "加载数据列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(844, 1);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "xiangmu";
            treeNode1.Text = "项目";
            treeNode2.Name = "nianyue";
            treeNode2.Text = "年月";
            treeNode3.Name = "yazhuchanneng";
            treeNode3.Text = "压铸产能";
            treeNode4.Name = "yazhujishuqishu";
            treeNode4.Text = "压铸计数器数";
            treeNode5.Name = "yazhu";
            treeNode5.Text = "压铸";
            treeNode6.Name = "dasha1";
            treeNode6.Text = "打砂1";
            treeNode7.Name = "dasha2";
            treeNode7.Text = "打砂2";
            treeNode8.Name = "cuopifeng";
            treeNode8.Text = "挫披锋";
            treeNode9.Name = "hmianquanjian";
            treeNode9.Text = "H面全检";
            treeNode10.Name = "节点11";
            treeNode10.Text = "压铸车间内部报废数";
            treeNode11.Name = "yazhuchejianneibubaofeilv";
            treeNode11.Text = "压铸车间内部报废率";
            treeNode12.Name = "cncchanneng";
            treeNode12.Text = "CNC产能";
            treeNode13.Name = "cnc";
            treeNode13.Text = "CNC";
            treeNode14.Name = "qingxi";
            treeNode14.Text = "清洗";
            treeNode15.Name = "celou";
            treeNode15.Text = "测漏";
            treeNode16.Name = "quanjian";
            treeNode16.Text = "全检";
            treeNode17.Name = "jijiabaofeishu";
            treeNode17.Text = "机加缺陷报废数";
            treeNode18.Name = "jijiachejianzuizhongbaofeilv";
            treeNode18.Text = "机加车间最终报废率";
            treeNode19.Name = "yazhuchejian";
            treeNode19.Text = "测漏";
            treeNode20.Name = "cnc2";
            treeNode20.Text = "CNC2";
            treeNode21.Name = "quanjianxian";
            treeNode21.Text = "全检线";
            treeNode22.Name = "yazhubaofeishu";
            treeNode22.Text = "压铸缺陷报废总数";
            treeNode23.Name = "yazhuchejianzuizhongbaofeilv";
            treeNode23.Text = "压铸车间最终报废率";
            treeNode24.Name = "tongji";
            treeNode24.Text = "车间数据统计";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24});
            this.treeView2.Size = new System.Drawing.Size(201, 84);
            this.treeView2.TabIndex = 3;
            this.treeView2.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(520, 27);
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
            this.multiColHeaderDgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiColHeaderDgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.multiColHeaderDgv2.ColumnHeadersHeight = 18;
            this.multiColHeaderDgv2.Location = new System.Drawing.Point(0, 102);
            this.multiColHeaderDgv2.myColHeaderTreeView = this.treeView2;
            this.multiColHeaderDgv2.Name = "multiColHeaderDgv2";
            this.multiColHeaderDgv2.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgv2.Size = new System.Drawing.Size(1033, 453);
            this.multiColHeaderDgv2.TabIndex = 4;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.multiColHeaderDgv2);
            this.Controls.Add(this.button1);
            this.Name = "FrmTest";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private MultiColHeaderDgv multiColHeaderDgv2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnExcel;
    }
}

