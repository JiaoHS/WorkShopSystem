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
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("�������̣����ƣ�");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("�ͺ�");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("���");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("�����豸��", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("����/��");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("�����׼����");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("������Ϣ��");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("ѹ������ �����ձ���", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multiColHeaderDgvRiBaoBiao = new WorkShopSystem.UI.MultiColHeaderDgv();
            this.btnFullList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgvRiBaoBiao)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(844, 1);
            this.treeView2.Name = "treeView2";
            treeNode28.Name = "gongyiliucheng";
            treeNode28.Text = "�������̣����ƣ�";
            treeNode29.Name = "xinghao";
            treeNode29.Text = "�ͺ�";
            treeNode30.Name = "bianhao";
            treeNode30.Text = "���";
            treeNode31.Name = "shenchanshebeilan";
            treeNode31.Text = "�����豸��";
            treeNode32.Name = "lingjianbianhao";
            treeNode32.Text = "������";
            treeNode33.Name = "dingeban";
            treeNode33.Text = "����/��";
            treeNode34.Name = "xuqiubiaozhunchanneng";
            treeNode34.Text = "�����׼����";
            treeNode35.Name = "shenchanxinxilan";
            treeNode35.Text = "������Ϣ��";
            treeNode36.Name = "tongji";
            treeNode36.Text = "ѹ������ �����ձ���";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36});
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
            this.btnExcel.Text = "����excel";
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgvRiBaoBiao.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.multiColHeaderDgvRiBaoBiao.Size = new System.Drawing.Size(1039, 453);
            this.multiColHeaderDgvRiBaoBiao.TabIndex = 4;
            // 
            // btnFullList
            // 
            this.btnFullList.Location = new System.Drawing.Point(424, 29);
            this.btnFullList.Name = "btnFullList";
            this.btnFullList.Size = new System.Drawing.Size(75, 23);
            this.btnFullList.TabIndex = 14;
            this.btnFullList.Text = "����б�";
            this.btnFullList.UseVisualStyleBackColor = true;
            this.btnFullList.Click += new System.EventHandler(this.btnFullList_Click);
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
            this.Text = "Form1";
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

