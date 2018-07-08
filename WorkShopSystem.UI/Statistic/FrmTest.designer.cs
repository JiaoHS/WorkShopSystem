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
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("年月");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("压铸产能");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("压铸计数器数");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("压铸");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("打砂1");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("打砂2");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("挫披锋");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("H面全检");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("压铸车间内部报废数", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("压铸车间内部报废率");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("CNC产能");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("CNC");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("清洗");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("测漏");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("全检");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("机加缺陷报废数", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("机加车间最终报废率");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("测漏");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("CNC2");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("全检线");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("压铸缺陷报废总数", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("压铸车间最终报废率");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("车间数据统计", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode41,
            treeNode42,
            treeNode46,
            treeNode47});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.multiColHeaderDgv2 = new WorkShopSystem.UI.MultiColHeaderDgv();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 25);
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
            treeNode25.Name = "xiangmu";
            treeNode25.Text = "项目";
            treeNode26.Name = "nianyue";
            treeNode26.Text = "年月";
            treeNode27.Name = "yazhuchanneng";
            treeNode27.Text = "压铸产能";
            treeNode28.Name = "yazhujishuqishu";
            treeNode28.Text = "压铸计数器数";
            treeNode29.Name = "yazhu";
            treeNode29.Text = "压铸";
            treeNode30.Name = "dasha1";
            treeNode30.Text = "打砂1";
            treeNode31.Name = "dasha2";
            treeNode31.Text = "打砂2";
            treeNode32.Name = "cuopifeng";
            treeNode32.Text = "挫披锋";
            treeNode33.Name = "hmianquanjian";
            treeNode33.Text = "H面全检";
            treeNode34.Name = "节点11";
            treeNode34.Text = "压铸车间内部报废数";
            treeNode35.Name = "yazhuchejianneibubaofeilv";
            treeNode35.Text = "压铸车间内部报废率";
            treeNode36.Name = "cncchanneng";
            treeNode36.Text = "CNC产能";
            treeNode37.Name = "cnc";
            treeNode37.Text = "CNC";
            treeNode38.Name = "qingxi";
            treeNode38.Text = "清洗";
            treeNode39.Name = "celou";
            treeNode39.Text = "测漏";
            treeNode40.Name = "quanjian";
            treeNode40.Text = "全检";
            treeNode41.Name = "jijiabaofeishu";
            treeNode41.Text = "机加缺陷报废数";
            treeNode42.Name = "jijiachejianzuizhongbaofeilv";
            treeNode42.Text = "机加车间最终报废率";
            treeNode43.Name = "yazhuchejian";
            treeNode43.Text = "测漏";
            treeNode44.Name = "cnc2";
            treeNode44.Text = "CNC2";
            treeNode45.Name = "quanjianxian";
            treeNode45.Text = "全检线";
            treeNode46.Name = "yazhubaofeishu";
            treeNode46.Text = "压铸缺陷报废总数";
            treeNode47.Name = "yazhuchejianzuizhongbaofeilv";
            treeNode47.Text = "压铸车间最终报废率";
            treeNode48.Name = "tongji";
            treeNode48.Text = "车间数据统计";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode48});
            this.treeView2.Size = new System.Drawing.Size(201, 84);
            this.treeView2.TabIndex = 3;
            this.treeView2.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(585, 25);
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.RowsDefaultCellStyle = dataGridViewCellStyle2;
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

