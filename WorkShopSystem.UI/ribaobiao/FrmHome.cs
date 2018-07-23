using MultiColHeaderDgvTest;
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
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI.ribaobiao
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            //this.cbWorkShopList.Items.Add("压铸车间");
            //this.cbWorkShopList.Items.Add("机加车间");
            //this.cbWorkShopList.SelectedIndex = 0;

            GetMonthList(0);
        }
        CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
        private void btnLoadD_Click(object sender, EventArgs e)
        {
            //CommonHelper.TimeStatic = this.cbMonthLIst.SelectedItem.ToString();
            //CommonHelper.WorkShopType = this.cbWorkShopList.SelectedIndex;
            //FrmTest2 frm = new MultiColHeaderDgvTest.FrmTest2();                
            //frm.ShowDialog();
        }

        public void GetMonthList(int type)
        {
            //DataTable dt = new DataTable();
            //if (type==0)
            //{
            //    dt = commonWorkShopRecordBLL.GetMonthList(0);
            //}
            //if(type==1)
            //{
            //    dt = commonWorkShopRecordBLL.GetMonthList(1);
            //}
            //DateTime dtime = new DateTime();
            //List<string> listTime = new List<string>();
            //this.cbMonthLIst.Items.Clear();
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DateTime.TryParse(dt.Rows[i]["time"].ToString(), out dtime);
                
            //        this.cbMonthLIst.Items.Add(dtime.ToString("yyyy-MM"));                   
            //    }
            //    this.cbMonthLIst.SelectedIndex = 0;
            //}
        }

        private void cbWorkShopList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMonthList(1);
        }
    }
}
