using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkShopSystem.BLL;

namespace WorkShopSystem.UI.Statistic
{
    public partial class QueryHome : Form
    {
        public QueryHome()
        {
            InitializeComponent();
        }
        CommonWorkShopRecordBLL BLL = new CommonWorkShopRecordBLL();
        private void StatisticHome_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            StringBuilder strWhere = new StringBuilder();
            //根据条件查询          
            //模号
            string muHaoList = tbMuHao.Text.Trim();
            //毛坯号 
            string maoPiHaoList = tbMaoPiHao.Text.Trim();
            //流程票 
            string liuChengPiaoList = tbLIuChengPIaoHao.Text.Trim();
            //机台号
            string yaZhuJiTaiHao = tbJiTaiHao.Text.Trim();
            strWhere.Append(string.Format(@"isdel=0 ", muHaoList));
            if (!string.IsNullOrEmpty(muHaoList.Trim()))
            {
                strWhere.Append(string.Format(@" and muhao='{0}'", muHaoList));
            }
            if (!string.IsNullOrEmpty(maoPiHaoList))
            {
                strWhere.Append(string.Format(@" and maopeihao='{0}'", maoPiHaoList));
            }
            if (!string.IsNullOrEmpty(liuChengPiaoList))
            {
                strWhere.Append(string.Format(@" and liuchengpiaobianhao='{0}'", liuChengPiaoList));
            }
            if (!string.IsNullOrEmpty(yaZhuJiTaiHao))
            {
                strWhere.Append(string.Format(@" and yazhujihao='{0}'", yaZhuJiTaiHao));
            }

            DataTable dt = BLL.GetInfoByOne(strWhere.ToString());


            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridViewQueryHome.DataSource = dt;
                dataGridViewQueryHome.Rows[0].Frozen = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
        private void tbLIuChengPIaoHao_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbJiTaiHao_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbMaoPiHao_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMuHao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            foreach (Control cl in groupBox1.Controls)//，与上面的区别在这里哦——循环groupBox1上的控件
            {
                if (cl is TextBox)//看看是不是checkbox
                {
                    TextBox ck = cl as TextBox;//将找到的control转化成checkbox
                    ck.Text = "";
                }
            }
        }
    }
}
