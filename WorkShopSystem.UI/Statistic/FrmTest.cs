using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WorkShopSystem.BLL;
using WorkShopSystem.Utility;

namespace MultiColHeaderDgvTest
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
            button1.Enabled = true;
        }
        CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
        Microsoft.Office.Interop.Excel.Application xlApp;
        DataTable dtable = new DataTable("Rock");
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //先更新表数据
            //set columns names
            dtable.Columns.Add("xiangmu", typeof(System.String));
            dtable.Columns.Add("nianyue", typeof(System.String));
            dtable.Columns.Add("yazhuchanneng", typeof(System.String));
            dtable.Columns.Add("yazhujishuqishu", typeof(System.String));
            dtable.Columns.Add("yazhu", typeof(System.String));
            dtable.Columns.Add("dasha1", typeof(System.String));

            dtable.Columns.Add("dasha2", typeof(System.String));
            dtable.Columns.Add("cuopifeng", typeof(System.String));
            dtable.Columns.Add("hmianquanjian", typeof(System.String));

            dtable.Columns.Add("yazhuchejianneibubaofeilv", typeof(System.String));
            dtable.Columns.Add("cncchanneng", typeof(System.String));
            dtable.Columns.Add("cnc", typeof(System.String));
            dtable.Columns.Add("qingxi", typeof(System.String));
            dtable.Columns.Add("celou", typeof(System.String));
            dtable.Columns.Add("quanjian", typeof(System.String));
            dtable.Columns.Add("jijiachejianzuizhongbaofeilv", typeof(System.String));
            dtable.Columns.Add("yazhuchejian", typeof(System.String));
            dtable.Columns.Add("cnc2", typeof(System.String));
            dtable.Columns.Add("quanjianxian", typeof(System.String));
            dtable.Columns.Add("yazhuchejianzuizhongbaofeilv", typeof(System.String));


            //获取所有的行数
            //压铸车间
            DataTable dtAllCol = commonWorkShopRecordBLL.GetAllGroupByTime();
            if (dtAllCol != null && dtAllCol.Rows.Count > 0)
            {

                for (int k = 0; k < dtAllCol.Rows.Count; k++)//获取所有的日期集合
                {
                    int dtDetailSum = 0;
                    int totalNum = 0;
                    decimal tempNum = 0;
                    decimal yazhuchanneng = 0;
                    decimal yazhujishuqishu = 0;
                    decimal cncchanneng = 0;

                    //int fanxiuzongshu = 0;
                    decimal yazhuquexian = 0;
                    //int pinjianquexian = 0;
                    //int jijiaquexianorcuopifeng = 0;
                    DataTable dtDetail = new DataTable();
                    DataRow drow = dtable.NewRow();
                    drow["xiangmu"] = "";
                    drow["nianyue"] = dtAllCol.Rows[k]["time"].ToString();
                    //drow["yazhuchanneng"] = dtAllCol.Rows[k]["shengchanshu"].ToString();
                    //drow["yazhujishuqishu"] = dtAllCol.Rows[k]["jishuqishu"].ToString();
                    //根据日期计算生产总数
                    #region 压铸车间报废
                    dtDetail = commonWorkShopRecordBLL.GetNumByTime("a", dtAllCol.Rows[k]["time"].ToString());
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["shengchanshu"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["shengchanshu"].ToString(), out yazhuchanneng);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["jishuqishu"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["jishuqishu"].ToString(), out yazhujishuqishu);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["yazhuquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["yazhuquexian"].ToString(), out yazhuquexian);
                        }
                        //if (!Convert.IsDBNull(dtDetail.Rows[0]["cuopifengquexian"]))
                        //{
                        //    int.TryParse(dtDetail.Rows[0]["cuopifengquexian"].ToString(), out jijiaquexianorcuopifeng);
                        //}
                        //if (!Convert.IsDBNull(dtDetail.Rows[0]["pinjianquexian"]))
                        //{
                        //    int.TryParse(dtDetail.Rows[0]["pinjianquexian"].ToString(), out pinjianquexian);
                        //}
                        //if (!Convert.IsDBNull(dtDetail.Rows[0]["fanxiuzongshu"]))
                        //{
                        //    int.TryParse(dtDetail.Rows[0]["fanxiuzongshu"].ToString(), out fanxiuzongshu);
                        //}
                        drow["yazhuchanneng"] = yazhuchanneng;
                        drow["yazhujishuqishu"] = yazhujishuqishu;
                    }
                    //通过日期查询报废车间的具体总数
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "0");//压铸
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["tiaojipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["tiaojipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["feijiagongaokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["feijiagongaokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["liewen"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["liewen"])) + (Convert.IsDBNull(dtDetail.Rows[i]["nainmo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["nainmo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qipi"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qipi"])) + (Convert.IsDBNull(dtDetail.Rows[i]["youwufahei"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["youwufahei"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuoshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuoshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengjushang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengjushang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["chongshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["chongshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["bengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["bengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["penghuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["penghuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianhuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianhuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["xiankawai"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["xiankawai"])) + (Convert.IsDBNull(dtDetail.Rows[i]["luodipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["luodipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qita"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qita"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lamo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lamo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengkongduanlie"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengkongduanlie"])) + (Convert.IsDBNull(dtDetail.Rows[i]["jitan"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["jitan"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lengliao"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["yazhu"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "1");
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["gaodiyatiaoji"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["gaodiyatiaoji"])) + (Convert.IsDBNull(dtDetail.Rows[i]["feijiagongaokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["feijiagongaokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["liewen"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["liewen"])) + (Convert.IsDBNull(dtDetail.Rows[i]["nianmo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["nianmo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qipi"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qipi"])) + (Convert.IsDBNull(dtDetail.Rows[i]["youwufahei"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["youwufahei"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuoshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuoshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengjushang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengjushang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["chongshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["chongshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["bengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["bengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["penghuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["penghuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianhuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianhuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["xiankawai"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["xiankawai"])) + (Convert.IsDBNull(dtDetail.Rows[i]["luodipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["luodipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qita"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qita"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["dasha1"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "2");
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["gaodiyatiaoji"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["gaodiyatiaoji"])) + (Convert.IsDBNull(dtDetail.Rows[i]["feijiagongaokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["feijiagongaokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["liewen"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["liewen"])) + (Convert.IsDBNull(dtDetail.Rows[i]["nianmo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["nianmo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qipi"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qipi"])) + (Convert.IsDBNull(dtDetail.Rows[i]["youwufahei"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["youwufahei"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuoshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuoshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengjushang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengjushang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["chongshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["chongshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["bengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["bengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["penghuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["penghuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianhuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianhuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["xiankawai"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["xiankawai"])) + (Convert.IsDBNull(dtDetail.Rows[i]["luodipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["luodipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qita"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qita"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["dasha2"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "3");
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["feijiagongaokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["feijiagongaokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["liewen"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["liewen"])) + (Convert.IsDBNull(dtDetail.Rows[i]["nianmo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["nianmo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lamo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lamo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qipi"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qipi"])) + (Convert.IsDBNull(dtDetail.Rows[i]["youwufahei"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["youwufahei"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuoshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuoshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengjushang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengjushang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["chongshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["chongshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["bengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["bengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["penghuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["penghuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianhuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianhuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianbianxing"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianbianxing"])) + (Convert.IsDBNull(dtDetail.Rows[i]["yashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["yashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["xiankawai"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["xiankawai"])) + (Convert.IsDBNull(dtDetail.Rows[i]["luodipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["luodipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["abbdashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["abbdashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qita"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qita"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["cuopifeng"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "4");
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["shayan"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shayan"])) + (Convert.IsDBNull(dtDetail.Rows[i]["feijiagongmianaokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["feijiagongmianaokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["liewen"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["liewen"])) + (Convert.IsDBNull(dtDetail.Rows[i]["nianmo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["nianmo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lamo"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lamo"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qipi"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qipi"])) + (Convert.IsDBNull(dtDetail.Rows[i]["youwufahei"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["youwufahei"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuoshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuoshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["shangzhouchengjushang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["shangzhouchengjushang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["chongshang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["chongshang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["bengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["bengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["penghuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["penghuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianhuashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianhuashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["rjiaobianxing"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["rjiaobianxing"])) + (Convert.IsDBNull(dtDetail.Rows[i]["hmianbianxing"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["hmianbianxing"])) + (Convert.IsDBNull(dtDetail.Rows[i]["xiankawai"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["xiankawai"])) + (Convert.IsDBNull(dtDetail.Rows[i]["luodipin"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["luodipin"])) + (Convert.IsDBNull(dtDetail.Rows[i]["yashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["yashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["assdashang"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["assdashang"])) + (Convert.IsDBNull(dtDetail.Rows[i]["lengliao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["lengliao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["gubao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["gubao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["aokeng"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["aokeng"])) + (Convert.IsDBNull(dtDetail.Rows[i]["cuzaodugao"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["cuzaodugao"])) + (Convert.IsDBNull(dtDetail.Rows[i]["qita"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["qita"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["hmianquanjian"] = dtDetailSum.ToString();
                    if (yazhuchanneng > 0)
                    {
                        // 压铸内部报废率（ΣC压铸不合格品数+ H不合格品数totalNum）/ΣM压铸车间生产数
                        drow["yazhuchejianneibubaofeilv"] = decimal.Round((decimal)(Math.Abs(totalNum + (yazhujishuqishu - yazhuchanneng)) / yazhuchanneng), 4);
                    }
                    else
                    {
                        drow["yazhuchejianneibubaofeilv"] = "0";
                    }
                    drow["yazhuchejian"] = totalNum.ToString();
                    #endregion
                    #region 机加车间报废
                    totalNum = 0;
                    decimal yazhuquexianjijia = 0;
                    decimal pinjianquexianjijia = 0;
                    decimal jijiaquexianorcuopifengjijia = 0;
                    decimal fanxiuzongshujijia = 0;
                    dtDetail = commonWorkShopRecordBLL.GetNumByTime("b", dtAllCol.Rows[k]["time"].ToString());
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["yazhuquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["yazhuquexian"].ToString(), out yazhuquexianjijia);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["pinjianquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["pinjianquexian"].ToString(), out pinjianquexianjijia);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["jijiaquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["jijiaquexian"].ToString(), out jijiaquexianorcuopifengjijia);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["fanxiuzongshu"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["fanxiuzongshu"].ToString(), out fanxiuzongshujijia);
                        }
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["shengchanshu"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["shengchanshu"].ToString(), out cncchanneng);
                        }
                        drow["cncchanneng"] = cncchanneng;
                    }
                    //通过日期查询报废车间的具体总数  机加车间
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "5");//机加拉线
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type4"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type4"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type5"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type5"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type6"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type6"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type7"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type7"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type8"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type8"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type9"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type9"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type10"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type10"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type11"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type11"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type12"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type12"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type13"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type13"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type14"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type14"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type15"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type15"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type16"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type16"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type17"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type17"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type18"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type18"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type19"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type19"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type20"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type20"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type21"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type21"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type22"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type22"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type23"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type23"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type24"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type24"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type25"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type25"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["quanjian"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "6");//机加清洗
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["qingxi"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "7");//机加CNC
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type4"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type4"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type5"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type5"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type6"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type6"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type7"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type7"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type8"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type8"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type9"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type9"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type10"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type10"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type11"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type11"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type12"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type12"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type13"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type13"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type14"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type14"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type15"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type15"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type16"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type16"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type17"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type17"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type18"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type18"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type19"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type19"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type20"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type20"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type21"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type21"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type22"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type22"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type23"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type23"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["cnc"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "8");//测漏
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type4"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type4"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type5"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type5"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type6"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type6"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type7"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type7"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["celou"] = dtDetailSum.ToString();
                    if (cncchanneng > 0)
                    {
                        drow["jijiachejianzuizhongbaofeilv"] = decimal.Round((decimal)(jijiaquexianorcuopifengjijia / cncchanneng), 4);  //机加车间报废率;
                    }
                    else
                    {
                        drow["jijiachejianzuizhongbaofeilv"] = "0";
                    }
                    #endregion
                    #region 压铸缺陷报废总数
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("7", dtAllCol.Rows[k]["time"].ToString());//cnc
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["yazhuquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["yazhuquexian"].ToString(), out yazhuquexianjijia);
                        }
                    }
                    drow["cnc2"] = yazhuquexianjijia;
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("8", dtAllCol.Rows[k]["time"].ToString());//测漏 压铸缺陷
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["jijiaquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["jijiaquexian"].ToString(), out yazhuquexianjijia);
                        }
                    }
                    drow["yazhuchejian"] = yazhuquexianjijia;
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("5", dtAllCol.Rows[k]["time"].ToString());//全检 压铸缺陷
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["yazhuquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["yazhuquexian"].ToString(), out yazhuquexianjijia);
                        }
                    }
                    drow["quanjianxian"] = yazhuquexianjijia;
                    #endregion
                    if (cncchanneng > 0)
                    {
                        drow["yazhuchejianzuizhongbaofeilv"] = decimal.Round((decimal)((yazhuquexian + yazhuquexianjijia) / (cncchanneng)), 4);//压铸最终报废率
                    }
                    else
                    {
                        drow["yazhuchejianzuizhongbaofeilv"] = "0";
                    }

                    dtable.Rows.Add(drow);
                }
            }
            multiColHeaderDgv2.DataSource = dtable;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            try
            {
                ExportToExecl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                EndReport();
            }

            #region MyRegion
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = true;
            //saveFileDialog.Title = "Export Excel File";
            //saveFileDialog.ShowDialog();
            //if (saveFileDialog.FileName == "")
            //    return;
            //Stream myStream;
            //myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            //string str = "";
            //try
            //{
            //    for (int i = 0; i < multiColHeaderDgv2.ColumnCount; i++)
            //    {
            //        if (i > 0)
            //        {
            //            str += "\t";
            //        }
            //        str += multiColHeaderDgv2.Columns[i].HeaderText;
            //    }
            //    sw.WriteLine(str);
            //    for (int j = 0; j < multiColHeaderDgv2.Rows.Count; j++)
            //    {
            //        string tempStr = "";
            //        for (int k = 0; k < multiColHeaderDgv2.Columns.Count; k++)
            //        {
            //            if (k > 0)
            //            {
            //                tempStr += "\t";
            //            }
            //            tempStr += multiColHeaderDgv2.Rows[j].Cells[k].Value.ToString();
            //        }
            //        sw.WriteLine(tempStr);
            //    }
            //    sw.Close();
            //    myStream.Close();
            //}

            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.ToString());  
            //}
            //finally
            //{
            //    sw.Close();
            //    myStream.Close();
            //}
            #endregion
        }
        private void ExportToExecl()
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件 (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;

                string header = "项目#年月#压铸产能#压铸计数器#压铸车间报废数 压铸,打砂1,打砂2,挫披锋,外观全检#压铸车间内部报废率#CNC产能#机加缺陷报废数 CNC,清洗,测漏,全检#机加车间最终报废率#压铸车间报废总数 压铸车间,CNC,全检线#压铸车间最终报废率";
                DataSet ds = new DataSet();
                ds.Tables.Add(dtable.Copy());
                NPOIHelper helper = new WorkShopSystem.Utility.NPOIHelper("", "sheet", header, "车间数据统计", ds, "", path, 2);
                string flag = helper.Export();
                if (flag == "ok")
                {
                    MessageBox.Show("导出数据成功！");
                }
                else
                {
                    MessageBox.Show(flag);
                }
            }
        }
        /// <summary>
        /// 具体导出的方法
        /// </summary>
        /// <param name="listView">ListView</param>
        /// <param name="strFileName">导出到的文件名</param>
        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("OK");
            }
        }
        private void EndReport()
        {
            object missing = System.Reflection.Missing.Value;
            try
            { }
            catch { }
            finally
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Workbooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Application);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    xlApp = null;
                }
                catch { }
                try
                {
                    //清理垃圾进程    
                    this.killProcessThread();
                }
                catch { }
                GC.Collect();
            }
        }
        private void killProcessThread()
        {
            ArrayList myProcess = new ArrayList();
            for (int i = 0; i < myProcess.Count; i++)
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                }
                catch { }
            }
        }
    }
}