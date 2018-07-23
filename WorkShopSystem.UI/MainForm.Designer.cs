namespace WorkShopSystem.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClearData = new System.Windows.Forms.ToolStripButton();
            this.tsbYaZhu = new System.Windows.Forms.ToolStripButton();
            this.tsb_jijia = new System.Windows.Forms.ToolStripButton();
            this.tsbStatic = new System.Windows.Forms.ToolStripButton();
            this.tsbChaXun = new System.Windows.Forms.ToolStripButton();
            this.tsbRiBaoBiao = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.elementHost2);
            this.panel1.Controls.Add(this.elementHost1);
            this.panel1.Location = new System.Drawing.Point(5, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 520);
            this.panel1.TabIndex = 6;
            // 
            // elementHost2
            // 
            this.elementHost2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.elementHost2.Location = new System.Drawing.Point(520, 3);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(581, 514);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = null;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.elementHost1.Location = new System.Drawing.Point(0, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(514, 514);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClearData,
            this.tsbYaZhu,
            this.tsb_jijia,
            this.tsbStatic,
            this.tsbChaXun,
            this.tsbRiBaoBiao});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1107, 74);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbClearData
            // 
            this.tsbClearData.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearData.Image")));
            this.tsbClearData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearData.Name = "tsbClearData";
            this.tsbClearData.Size = new System.Drawing.Size(60, 71);
            this.tsbClearData.Text = "数据处理";
            this.tsbClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClearData.Click += new System.EventHandler(this.tsbClearData_Click);
            // 
            // tsbYaZhu
            // 
            this.tsbYaZhu.Image = ((System.Drawing.Image)(resources.GetObject("tsbYaZhu.Image")));
            this.tsbYaZhu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbYaZhu.Name = "tsbYaZhu";
            this.tsbYaZhu.Size = new System.Drawing.Size(60, 71);
            this.tsbYaZhu.Text = "压铸车间";
            this.tsbYaZhu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbYaZhu.Click += new System.EventHandler(this.tsbYaZhu_Click);
            // 
            // tsb_jijia
            // 
            this.tsb_jijia.Image = ((System.Drawing.Image)(resources.GetObject("tsb_jijia.Image")));
            this.tsb_jijia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_jijia.Name = "tsb_jijia";
            this.tsb_jijia.Size = new System.Drawing.Size(60, 71);
            this.tsb_jijia.Text = "机加车间";
            this.tsb_jijia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_jijia.Click += new System.EventHandler(this.tsb_jijia_Click);
            // 
            // tsbStatic
            // 
            this.tsbStatic.Image = ((System.Drawing.Image)(resources.GetObject("tsbStatic.Image")));
            this.tsbStatic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStatic.Name = "tsbStatic";
            this.tsbStatic.Size = new System.Drawing.Size(60, 71);
            this.tsbStatic.Text = "数据统计";
            this.tsbStatic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbStatic.Click += new System.EventHandler(this.tsbStatic_Click);
            // 
            // tsbChaXun
            // 
            this.tsbChaXun.Image = ((System.Drawing.Image)(resources.GetObject("tsbChaXun.Image")));
            this.tsbChaXun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChaXun.Name = "tsbChaXun";
            this.tsbChaXun.Size = new System.Drawing.Size(72, 71);
            this.tsbChaXun.Text = "单条件查询";
            this.tsbChaXun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbChaXun.Click += new System.EventHandler(this.tsbChaXun_Click);
            // 
            // tsbRiBaoBiao
            // 
            this.tsbRiBaoBiao.Image = ((System.Drawing.Image)(resources.GetObject("tsbRiBaoBiao.Image")));
            this.tsbRiBaoBiao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRiBaoBiao.Name = "tsbRiBaoBiao";
            this.tsbRiBaoBiao.Size = new System.Drawing.Size(72, 71);
            this.tsbRiBaoBiao.Text = "产能日报表";
            this.tsbRiBaoBiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRiBaoBiao.Click += new System.EventHandler(this.tsbRiBaoBiao_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 616);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车间管理系统";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_jijia;
        private System.Windows.Forms.ToolStripButton tsbYaZhu;
        private System.Windows.Forms.ToolStripButton tsbClearData;
        private System.Windows.Forms.ToolStripButton tsbStatic;
        private System.Windows.Forms.ToolStripButton tsbChaXun;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.ToolStripButton tsbRiBaoBiao;
    }
}

