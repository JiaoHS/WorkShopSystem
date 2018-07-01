namespace WorkShopSystem.UI.Statistic
{
    partial class QueryHome
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLIuChengPIaoHao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbJiTaiHao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaoPiHao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMuHao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.dgList);
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 361);
            this.panel1.TabIndex = 0;
            // 
            // dgList
            // 
            this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Location = new System.Drawing.Point(0, 3);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(1024, 355);
            this.dgList.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(936, 23);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "流程票编号：";
            // 
            // tbLIuChengPIaoHao
            // 
            this.tbLIuChengPIaoHao.Location = new System.Drawing.Point(82, 11);
            this.tbLIuChengPIaoHao.Name = "tbLIuChengPIaoHao";
            this.tbLIuChengPIaoHao.Size = new System.Drawing.Size(107, 21);
            this.tbLIuChengPIaoHao.TabIndex = 4;
            this.tbLIuChengPIaoHao.TextChanged += new System.EventHandler(this.tbLIuChengPIaoHao_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "压铸机台号：";
            // 
            // tbJiTaiHao
            // 
            this.tbJiTaiHao.Location = new System.Drawing.Point(298, 11);
            this.tbJiTaiHao.Name = "tbJiTaiHao";
            this.tbJiTaiHao.Size = new System.Drawing.Size(107, 21);
            this.tbJiTaiHao.TabIndex = 6;
            this.tbJiTaiHao.TextChanged += new System.EventHandler(this.tbJiTaiHao_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "毛坯号：";
            // 
            // tbMaoPiHao
            // 
            this.tbMaoPiHao.Location = new System.Drawing.Point(492, 12);
            this.tbMaoPiHao.Name = "tbMaoPiHao";
            this.tbMaoPiHao.Size = new System.Drawing.Size(107, 21);
            this.tbMaoPiHao.TabIndex = 6;
            this.tbMaoPiHao.TextChanged += new System.EventHandler(this.tbMaoPiHao_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "模号：";
            // 
            // tbMuHao
            // 
            this.tbMuHao.Location = new System.Drawing.Point(674, 13);
            this.tbMuHao.Name = "tbMuHao";
            this.tbMuHao.Size = new System.Drawing.Size(107, 21);
            this.tbMuHao.TabIndex = 6;
            this.tbMuHao.TextChanged += new System.EventHandler(this.tbMuHao_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMaoPiHao);
            this.groupBox1.Controls.Add(this.tbMuHao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbLIuChengPIaoHao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbJiTaiHao);
            this.groupBox1.Location = new System.Drawing.Point(31, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 39);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.Location = new System.Drawing.Point(843, 23);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 8;
            this.btnClean.Text = "一键清空";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // QueryHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 467);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.panel1);
            this.Name = "QueryHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单个条件查询";
            this.Load += new System.EventHandler(this.StatisticHome_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLIuChengPIaoHao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJiTaiHao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaoPiHao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMuHao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.DataGridView dgList;
    }
}