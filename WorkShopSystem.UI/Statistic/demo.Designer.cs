namespace WorkShopSystem.UI.Statistic
{
    partial class demo
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项目");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("年月");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("压铸车间生产数");
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(849, 44);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "xiangmu";
            treeNode1.Text = "项目";
            treeNode2.Name = "nianyue";
            treeNode2.Text = "年月";
            treeNode3.Name = "yazhushu";
            treeNode3.Text = "压铸车间生产数";
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
            treeNode10.Name = "yazhubaofeishu";
            treeNode10.Text = "压铸车间内部报废数";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(121, 424);
            this.treeView1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(29, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(814, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 503);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "demo";
            this.Text = "demo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}