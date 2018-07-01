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
            //�ȸ��±�����
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


            //��ȡ���е�����
            //ѹ������
            DataTable dtAllCol = commonWorkShopRecordBLL.GetAllGroupByTime();
            if (dtAllCol != null && dtAllCol.Rows.Count > 0)
            {

                for (int k = 0; k < dtAllCol.Rows.Count; k++)//��ȡ���е����ڼ���
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
                    //�������ڼ�����������
                    #region ѹ�����䱨��
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
                    //ͨ�����ڲ�ѯ���ϳ���ľ�������
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "0");//ѹ��
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
                        // ѹ���ڲ������ʣ���Cѹ�����ϸ�Ʒ��+ H���ϸ�Ʒ��totalNum��/��Mѹ������������
                        drow["yazhuchejianneibubaofeilv"] = decimal.Round((decimal)(Math.Abs(totalNum + (yazhujishuqishu - yazhuchanneng)) / yazhuchanneng), 4);
                    }
                    else
                    {
                        drow["yazhuchejianneibubaofeilv"] = "0";
                    }
                    drow["yazhuchejian"] = totalNum.ToString();
                    #endregion
                    #region ���ӳ��䱨��
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
                    //ͨ�����ڲ�ѯ���ϳ���ľ�������  ���ӳ���
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "5");//��������
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type4"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type4"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type5"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type5"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type6"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type6"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type7"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type7"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type8"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type8"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type9"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type9"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type10"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type10"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type11"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type11"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type12"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type12"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type13"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type13"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type14"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type14"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type15"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type15"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type16"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type16"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type17"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type17"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type18"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type18"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type19"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type19"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type20"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type20"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type21"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type21"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type22"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type22"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type23"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type23"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type24"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type24"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type25"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type25"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["quanjian"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "6");//������ϴ
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["qingxi"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "7");//����CNC
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            dtDetailSum = (Convert.IsDBNull(dtDetail.Rows[i]["type1"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type1"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type2"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type2"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type3"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type3"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type4"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type4"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type5"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type5"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type6"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type6"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type7"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type7"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type8"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type8"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type9"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type9"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type10"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type10"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type11"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type11"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type12"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type12"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type13"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type13"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type14"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type14"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type15"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type15"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type16"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type16"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type17"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type17"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type18"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type18"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type19"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type19"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type20"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type20"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type21"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type21"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type22"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type22"])) + (Convert.IsDBNull(dtDetail.Rows[i]["type23"]) ? 0 : Convert.ToInt32(dtDetail.Rows[i]["type23"]));
                        }
                    }
                    totalNum += dtDetailSum;
                    drow["cnc"] = dtDetailSum.ToString();
                    dtDetail = commonWorkShopRecordBLL.GetDetailBaoFeiList(dtAllCol.Rows[k]["time"].ToString(), "8");//��©
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
                        drow["jijiachejianzuizhongbaofeilv"] = decimal.Round((decimal)(jijiaquexianorcuopifengjijia / cncchanneng), 4);  //���ӳ��䱨����;
                    }
                    else
                    {
                        drow["jijiachejianzuizhongbaofeilv"] = "0";
                    }
                    #endregion
                    #region ѹ��ȱ�ݱ�������
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("7", dtAllCol.Rows[k]["time"].ToString());//cnc
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["yazhuquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["yazhuquexian"].ToString(), out yazhuquexianjijia);
                        }
                    }
                    drow["cnc2"] = yazhuquexianjijia;
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("8", dtAllCol.Rows[k]["time"].ToString());//��© ѹ��ȱ��
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        if (!Convert.IsDBNull(dtDetail.Rows[0]["jijiaquexian"]))
                        {
                            decimal.TryParse(dtDetail.Rows[0]["jijiaquexian"].ToString(), out yazhuquexianjijia);
                        }
                    }
                    drow["yazhuchejian"] = yazhuquexianjijia;
                    dtDetail = commonWorkShopRecordBLL.GetNumByTimeWorkshoptype("5", dtAllCol.Rows[k]["time"].ToString());//ȫ�� ѹ��ȱ��
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
                        drow["yazhuchejianzuizhongbaofeilv"] = decimal.Round((decimal)((yazhuquexian + yazhuquexianjijia) / (cncchanneng)), 4);//ѹ�����ձ�����
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
                MessageBox.Show("�����쳣��" + ex.Message, "�����쳣", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            sfd.Filter = "Excel�ļ� (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;

                string header = "��Ŀ#����#ѹ������#ѹ��������#ѹ�����䱨���� ѹ��,��ɰ1,��ɰ2,������,���ȫ��#ѹ�������ڲ�������#CNC����#����ȱ�ݱ����� CNC,��ϴ,��©,ȫ��#���ӳ������ձ�����#ѹ�����䱨������ ѹ������,CNC,ȫ����#ѹ���������ձ�����";
                DataSet ds = new DataSet();
                ds.Tables.Add(dtable.Copy());
                NPOIHelper helper = new WorkShopSystem.Utility.NPOIHelper("", "sheet", header, "��������ͳ��", ds, "", path, 2);
                string flag = helper.Export();
                if (flag == "ok")
                {
                    MessageBox.Show("�������ݳɹ���");
                }
                else
                {
                    MessageBox.Show(flag);
                }
            }
        }
        /// <summary>
        /// ���嵼���ķ���
        /// </summary>
        /// <param name="listView">ListView</param>
        /// <param name="strFileName">���������ļ���</param>
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
                    MessageBox.Show("�޷�����excel���󣬿�������ϵͳû�а�װexcel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //��ListView����������Excel���һ��
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //��ListView�е����ݵ���Excel��
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //ע������ڵ�����ʱ����ˡ�\t�� ��Ŀ�ľ��Ǳ��⵼����������ʾΪ��ѧ�����������Է���ÿ�е���β��
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //������Ҫ˵��������strFileName,Excel.XlFileFormat.xlExcel9795���淽ʽʱ �����Excel�汾����95��97 ����2003��2007 ʱ������ʱ��ᱨһ�������쳣���� HRESULT:0x800A03EC�� ����취���ǻ���strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal��
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
                    //������������    
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