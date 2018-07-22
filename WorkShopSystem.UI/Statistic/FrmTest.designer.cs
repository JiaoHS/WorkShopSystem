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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode(" 压铸车间合格品数");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("压铸计数器数");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("压铸");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("打砂1");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("打砂2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("挫披锋");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("H面全检");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("压铸内部报废", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("压铸内部报废数");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("压铸车间内部报废率");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("压铸");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("打砂1");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("打砂2");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("挫披锋");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("H面全检+外观全检");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("搓披风内部报废", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("搓披风内部报废数");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("搓披风内部报废率");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("压铸车间内部总的报废数");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("压铸车间内部总的报废率");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("CNC产能");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("CNC");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("清洗");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("测漏");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("全检");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("机加缺陷报废数", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("机加车间最终报废率");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("机加车间最终报废率");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("CNC2");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("全检线");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("压铸缺陷报废数", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("压铸车间最终报废数");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("压铸车间最终报废率");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("车间数据统计", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode33,
            treeNode34,
            treeNode35});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiColHeaderDgv2 = new WorkShopSystem.UI.MultiColHeaderDgv();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 25);
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
            treeNode3.Text = " 压铸车间合格品数";
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
            treeNode10.Text = "压铸内部报废";
            treeNode11.Name = "yazhuneibubaofeishu";
            treeNode11.Text = "压铸内部报废数";
            treeNode12.Name = "yazhuchejianneibubaofeilv";
            treeNode12.Text = "压铸车间内部报废率";
            treeNode13.Name = "cuopifengyazhu";
            treeNode13.Text = "压铸";
            treeNode14.Name = "cuopifengdasha1";
            treeNode14.Text = "打砂1";
            treeNode15.Name = "cuopifengdasha2";
            treeNode15.Text = "打砂2";
            treeNode16.Name = "cuopifeng2";
            treeNode16.Text = "挫披锋";
            treeNode17.Name = "cuopifengHmian";
            treeNode17.Text = "H面全检+外观全检";
            treeNode18.Name = "cuopifengneibubaofeishu";
            treeNode18.Text = "搓披风内部报废";
            treeNode19.Name = "cuopifengbeibubaofeishu";
            treeNode19.Text = "搓披风内部报废数";
            treeNode20.Name = "cuopifengneibubaofeilv";
            treeNode20.Text = "搓披风内部报废率";
            treeNode21.Name = "yazhuzongbeofeishu";
            treeNode21.Text = "压铸车间内部总的报废数";
            treeNode22.Name = "yazhuzongbaofeilv";
            treeNode22.Text = "压铸车间内部总的报废率";
            treeNode23.Name = "cncchanneng";
            treeNode23.Text = "CNC产能";
            treeNode24.Name = "jijiacnc";
            treeNode24.Text = "CNC";
            treeNode25.Name = "jijiaqingxi";
            treeNode25.Text = "清洗";
            treeNode26.Name = "jijiacelou";
            treeNode26.Text = "测漏";
            treeNode27.Name = "jijiaquanjian";
            treeNode27.Text = "全检";
            treeNode28.Name = "jijiabaofeishu";
            treeNode28.Text = "机加缺陷报废数";
            treeNode29.Name = "jijiazuizhongbaofeishu";
            treeNode29.Text = "机加车间最终报废率";
            treeNode30.Name = "jijiachejianzuizhongbaofeilv";
            treeNode30.Text = "机加车间最终报废率";
            treeNode31.Name = "yazhuquexiancnc2";
            treeNode31.Text = "CNC2";
            treeNode32.Name = "yazhuquexianquanjianxian";
            treeNode32.Text = "全检线";
            treeNode33.Name = "yazhubaofeishu";
            treeNode33.Text = "压铸缺陷报废数";
            treeNode34.Name = "yazhuzuizhongbaofeishu";
            treeNode34.Text = "压铸车间最终报废数";
            treeNode35.Name = "yazhuchejianzuizhongbaofeilv";
            treeNode35.Text = "压铸车间最终报废率";
            treeNode36.Name = "tongji";
            treeNode36.Text = "车间数据统计";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36});
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.multiColHeaderDgv2);
            this.panel1.Location = new System.Drawing.Point(0, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 430);
            this.panel1.TabIndex = 6;
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
            this.multiColHeaderDgv2.myColHeaderTreeView = this.treeView2;
            this.multiColHeaderDgv2.Name = "multiColHeaderDgv2";
            this.multiColHeaderDgv2.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgv2.Size = new System.Drawing.Size(1045, 430);
            this.multiColHeaderDgv2.TabIndex = 4;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.button1);
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private MultiColHeaderDgv multiColHeaderDgv2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel1;
    }
}

