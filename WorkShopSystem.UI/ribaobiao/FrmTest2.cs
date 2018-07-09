using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WorkShopSystem.BLL;
using WorkShopSystem.UI.loading;
using WorkShopSystem.Utility;

namespace MultiColHeaderDgvTest
{
    public partial class FrmTest2 : Form
    {
        string time = string.Empty;
        int workshoptype = 0;
        public FrmTest2()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;


            time = CommonHelper.TimeStatic;
            workshoptype = CommonHelper.WorkShopType;
            LoadData();
        }
        string headTitle = "��������#�����豸�� �ͺ�,���#������#����/��#�����׼����#������Ϣ��#";
        public delegate void AuthenticationDelegate(bool value);
        OpaqueCommand cmd = new OpaqueCommand();
        int totalColNum = 0;


        CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();

        Microsoft.Office.Interop.Excel.Application xlApp;
        DataTable dtable = new DataTable();
        public void initLeaf(List<string> dic, TreeNode tn)
        {
            for (int i = 0; i < dic.Count; i++)
            {

                TreeNode ctn = new TreeNode();
                ctn.Text = dic[i];
                ctn.Tag = dic[i];
                tn.Nodes.Add(ctn);
                //�ݹ���ã�����ѭ����Ҷ�ڵ�
                if (IsDateTime(dic[i]))
                {
                    initLeaf3(ctn);
                }
            }
        }
        public void initLeaf3(TreeNode tn)
        {
            List<string> list = new List<string>() { "�װ�", "ҹ��" };
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode ctn = new TreeNode();
                ctn.Text = list[i];
                ctn.Tag = list[i];
                tn.Nodes.Add(ctn);
            }
        }
        public Dictionary<string, Dictionary<string, List<string>>> GetDayByWeek(string time)
        {
            DateTime dtBeginDate = new DateTime();
            DateTime dtEndDate = new DateTime();
            Dictionary<string, Dictionary<string, List<string>>> dic = new Dictionary<string, Dictionary<string, List<string>>>();
            Dictionary<string, List<string>> dicList = new Dictionary<string, List<string>>();
            int year = DateTime.Now.Year;
            DataTable dt = commonWorkShopRecordBLL.GetTimeDayList(time);
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime.TryParse(dt.Rows[0]["time"].ToString(), out dtBeginDate);
                DateTime.TryParse(dt.Rows[dt.Rows.Count - 1]["time"].ToString(), out dtEndDate);
            }
            int beginIndex = new System.Globalization.GregorianCalendar().GetWeekOfYear(dtBeginDate, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int endIndex = new System.Globalization.GregorianCalendar().GetWeekOfYear(dtEndDate, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            for (int i = beginIndex; i <= endIndex; i++)
            {
                dicList.Add(year.ToString() + "���" + i.ToString() + "��", GetWeekSpan(i, dtBeginDate));
            }
            //ȥ�����Ǳ��µ� �����Ǳ��ܵ�����
            foreach (var item in dicList)
            {
                foreach (var item2 in item.Value)
                {
                    if (IsDateTime(item2))
                    {
                        totalColNum += 2;
                    }
                    else
                    {
                        totalColNum += 1;
                    }
                }
            }
            //totalColNum = dicList.Count * 7 * 2 + dicList.Count;//����ʱ���ܵ�����
            dic.Add("", dicList);
            return dic;
        }
        public bool IsDateTime(string str)
        {
            try
            {
                DateTime dt = new DateTime();
                return DateTime.TryParse(str, out dt);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��ȡ��ǰ�ܵļ���
        /// </summary>
        /// <param name="iWeeks"></param>
        /// <returns></returns>
        private List<string> GetWeekSpan(int iWeeks, DateTime dt)
        {
            List<string> listDay = new List<string>();
            int iCurrentYear = DateTime.Now.Year;
            DateTime dtFirstDate = new DateTime(iCurrentYear, 1, 1);

            int iDays = (iWeeks - 1) * 7;
            dtFirstDate = dtFirstDate.AddDays(iDays);

            int iDaysOfWeek = (int)dtFirstDate.DayOfWeek;
            int month = dt.Month;
            for (int i = 7; i >= 1; i--)
            {
                dt = dtFirstDate.AddDays(7 - i);
                if (dt.Month != month)
                {
                    continue;
                }
                listDay.Add(dt.ToString("yyyy-MM-dd"));
            }
            listDay.Add("����/��");
            //DateTime dtBeginDate = dtFirstDate.AddDays(-(iDaysOfWeek - 1));

            //DateTime dtEndDate = dtFirstDate.AddDays(7 - iDaysOfWeek);
            return listDay;
        }

        /**//// <summary>
            /// ��ĳ���ж�����
            /// ���� int
            /// </summary>
            /// <param name="strYear"></param>
            /// <returns>int</returns>
        public int GetYearWeekCount(int strYear)
        {
            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//�õ�����ĵ�һ�����ܼ� 
            if (k == 1)
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 1;
                return countWeek;

            }
            else
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 2;
                return countWeek;
            }

        }

        //��ʼ�����ڵ�
        public void initParent(Dictionary<string, Dictionary<string, List<string>>> dic)
        {
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> kv in dic)
            {
                initLeaf2(kv.Value, this.treeView2.Nodes[0]);
            }
        }
        public void initLeaf2(Dictionary<string, List<string>> dic, TreeNode tn)
        {
            foreach (var item in dic)
            {
                TreeNode ctn = new TreeNode();
                ctn.Text = item.Key;
                ctn.Tag = item.Key;
                tn.Nodes.Add(ctn);
                //�ݹ���ã�����ѭ����Ҷ�ڵ�
                initLeaf(item.Value, ctn);
            }
        }
        private Thread loginThread = null;
        private void button1_Click(object sender, EventArgs e)
        {
            //btnLoadD.Enabled = false;
            //time = this.cbMonthLIst.SelectedItem.ToString();
            //workshoptype = this.cbWorkShopList.SelectedIndex;

        }
        private void PassAuthentication(bool value)
        {
            if (this.InvokeRequired == false)
            {
                if (value == true)
                {
                    cmd.ShowOpaqueLayer(panel1, 125, true);
                }
                else
                {

                }
            }
            else
            {
                AuthenticationDelegate myDelegate = new AuthenticationDelegate(PassAuthentication);
                this.Invoke(myDelegate, new object[] { value });
            }

        }
        public void LoadData()
        {
            if (loginThread != null)
            {
                loginThread.Join();
            }
            if (workshoptype == 0)
            {
                loginThread = new Thread(new ParameterizedThreadStart(ClearData));
            }
            if (workshoptype == 1)
            {
                loginThread = new Thread(new ParameterizedThreadStart(ClearDataJiJia));
            }
            loginThread.Start(5);
        }
        public void ClearData(object _delay)
        {
            int delay = (int)_delay;
            Thread.Sleep(delay);
            PassAuthentication(true);
            Dictionary<string, Dictionary<string, List<string>>> dicModel = new Dictionary<string, Dictionary<string, List<string>>>();
            dicModel = GetDayByWeek(time);
            //GetDayByWeek(time);
            initParent(dicModel);
            //button1.Enabled = false;
            //�ȸ��±�����
            //set columns names
            dtable.Columns.Add("gongyiliucheng", typeof(System.String));
            dtable.Columns.Add("xinghao", typeof(System.String));
            dtable.Columns.Add("bianhao", typeof(System.String));
            dtable.Columns.Add("lingjianbianhao", typeof(System.String));
            dtable.Columns.Add("dingeban", typeof(System.String));
            dtable.Columns.Add("xuqiubiaozhunchanneng", typeof(System.String));
            dtable.Columns.Add("shenchanxinxilan", typeof(System.String));

            //DataRow drow3 = dtable.NewRow();
            //drow3["gongyiliucheng"] = "a";
            //drow3["xinghao"] = "a";
            //drow3["bianhao"] = "a";
            //drow3["lingjianbianhao"] = "a";
            //drow3["dingeban"] = "a";
            //drow3["xuqiubiaozhunchanneng"] = "a";
            //drow3["shenchanxinxilan"] = "a";
            //���ڵ�����
            for (int i = 0; i <= totalColNum - 1; i++)
            {
                dtable.Columns.Add("column" + i.ToString(), typeof(System.String));
                //string temp = "column" + i.ToString();
                //drow3[temp] = "1";//��Ӧ��ÿһ��İװ����ҹ��
            }
            //dtable.Rows.Add(drow3);
            string fileName = "biaotou.xlsx";
            Dictionary<string, DataTable> dicTables = ExcelToDataTable(fileName, null, false);//��ȡ��excel������sheet   
            //dicTables = ExcelToDataTable(fileName, null, false);//��ȡ��excel������sheet   
            string gongyiliuchengmingchen = string.Empty;
            string xinghao = string.Empty;
            string bianhao = string.Empty;
            string xuqiubiaozhunchanneng = string.Empty;
            string lingjianbianhao = string.Empty;
            if (dicTables != null && dicTables.Count > 0)
            #region MyRegion
            {
                foreach (var item in dicTables)
                {
                    DataTable dt = dicTables[item.Key];
                    //������е�������� ��������
                    string shenchanbianhaolist = string.Empty;
                    string lingjianbianhaoList = string.Empty;
                    string shenchanbianhaolist31 = string.Empty;
                    string lingjianbianhaoList31 = string.Empty;
                    string shenchanbianhaolist49 = string.Empty;
                    string shenchanbianhaolist68 = string.Empty;
                    string lingjianbianhao68 = string.Empty;
                    //���� ��ѯ ÿ�����������
                    Dictionary<string, List<string>> dicList = dicModel[""];
                    List<string> listDay = new List<string>();
                    if (dicList != null && dicList.Count > 0)
                    {
                        foreach (var item2 in dicList)
                        {
                            for (int k = 0; k < item2.Value.Count; k++)
                            {
                                if (item2.Value[k].ToString() == "����/��")
                                {
                                    headTitle += item2.Key + item2.Value[k] + "#";
                                }
                                else
                                {
                                    headTitle += item2.Value[k] + " " + "�װ�,���#";
                                }

                                listDay.Add(item2.Value[k]);
                            }
                        }
                    }
                    #region ���е�����
                    for (int i = 0; i < dt.Rows.Count; i++)//���е�����
                    {
                        DataRow drow2 = dtable.NewRow();
                        if (dt.Columns.Contains("gongyiliuchengmingchen"))
                        {
                            if (!Convert.IsDBNull(dt.Rows[i]["gongyiliuchengmingchen"]) && dt.Rows[i]["gongyiliuchengmingchen"].ToString().Trim() != "")
                            {
                                gongyiliuchengmingchen = Convert.ToString(dt.Rows[i]["gongyiliuchengmingchen"]);
                            }
                        }
                        drow2["gongyiliucheng"] = gongyiliuchengmingchen;
                        if (dt.Columns.Contains("shengchanshebeilan_xinghao"))
                        {
                            if (!Convert.IsDBNull(dt.Rows[i]["shengchanshebeilan_xinghao"]) && dt.Rows[i]["shengchanshebeilan_xinghao"].ToString().Trim() != "")
                            {
                                xinghao = Convert.ToString(dt.Rows[i]["shengchanshebeilan_xinghao"]);
                            }
                        }
                        drow2["xinghao"] = xinghao;
                        if (dt.Columns.Contains("dingeban"))
                        {
                            drow2["dingeban"] = dt.Rows[i]["dingeban"].ToString();
                        }

                        if (dt.Columns.Contains("lingjianbianhao"))
                        {
                            if (!Convert.IsDBNull(dt.Rows[i]["lingjianbianhao"]) && dt.Rows[i]["lingjianbianhao"].ToString().Trim() != "")
                            {
                                lingjianbianhao = Convert.ToString(dt.Rows[i]["lingjianbianhao"]);
                            }
                        }
                        drow2["lingjianbianhao"] = lingjianbianhao;
                        if (dt.Columns.Contains("xuqiubiaozhunchanneng"))
                        {
                            if (!Convert.IsDBNull(dt.Rows[i]["xuqiubiaozhunchanneng"]) && dt.Rows[i]["xuqiubiaozhunchanneng"].ToString().Trim() != "")
                            {
                                xuqiubiaozhunchanneng = Convert.ToString(dt.Rows[i]["xuqiubiaozhunchanneng"]);
                            }
                        }
                        drow2["xuqiubiaozhunchanneng"] = xuqiubiaozhunchanneng;
                        if (dt.Columns.Contains("shengchanxinxilan"))
                        {
                            drow2["shenchanxinxilan"] = dt.Rows[i]["shengchanxinxilan"].ToString();
                        }
                        if (dt.Columns.Contains("shengchanshebeilan_bianhao"))
                        {
                            if (!Convert.IsDBNull(dt.Rows[i]["shengchanshebeilan_bianhao"]) && dt.Rows[i]["shengchanshebeilan_bianhao"].ToString().Trim() != "")
                            {
                                bianhao = Convert.ToString(dt.Rows[i]["shengchanshebeilan_bianhao"]);
                            }
                        }
                        drow2["bianhao"] = bianhao;
                        if (i >= 19 && i <= 22)
                        {
                            drow2["gongyiliucheng"] = "";
                            drow2["xinghao"] = "";
                            drow2["dingeban"] = "";
                            drow2["lingjianbianhao"] = "";
                            drow2["xuqiubiaozhunchanneng"] = "";
                            drow2["shenchanxinxilan"] = "";
                        }
                        else if (i >= 23 && i <= 24)
                        {
                            drow2["xinghao"] = "";
                            drow2["lingjianbianhao"] = "";
                        }
                        else if (i >= 27 && i <= 30)
                        {
                            drow2["xinghao"] = "";
                            drow2["lingjianbianhao"] = "";
                            drow2["dingeban"] = "";
                            drow2["xuqiubiaozhunchanneng"] = "";
                            drow2["shenchanxinxilan"] = "";
                        }
                        else if (i >= 45 && i <= 48)
                        {
                            drow2["lingjianbianhao"] = "";
                            drow2["dingeban"] = "";
                            drow2["xuqiubiaozhunchanneng"] = "";
                            drow2["shenchanxinxilan"] = "";
                        }
                        else if (i >= 64 && i <= 67)
                        {
                            drow2["lingjianbianhao"] = "";
                            drow2["dingeban"] = "";
                            drow2["xuqiubiaozhunchanneng"] = "";
                            drow2["shenchanxinxilan"] = "";
                        }
                        else if (i >= 68 && i <= 74)//ȫ��
                        {
                            drow2["xinghao"] = "";
                        }
                        else if (i >= 75 && i <= 78)
                        {
                            drow2["xinghao"] = "";
                            drow2["lingjianbianhao"] = "";
                            drow2["dingeban"] = "";
                            drow2["xuqiubiaozhunchanneng"] = "";
                            drow2["shenchanxinxilan"] = "";
                        }
                        #endregion

                        //ѭ��ʱ���ѯ
                        decimal meitianshuliang = 0;
                        string temp = string.Empty;
                        decimal tempCount = 0;//ÿ��Ĳ���
                        decimal totalCount = 0;//7������ܺ�


                        int index = 0;
                        if (i <= 18)//ѹ��
                        {
                            #region MyRegion
                            shenchanbianhaolist += "'" + bianhao.Split('-')[1] + "#" + "'" + "," + "'" + bianhao.Split('-')[1] + "'" + ",";
                            lingjianbianhaoList += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetNum(bianhao.Split('-')[1] + "#", lingjianbianhao.TrimEnd('/'), listDay[j], m == 2 ? "ҹ��" : "�װ�");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//��Ӧ��ÿһ��İװ����ҹ��
                                            index++;//��Ӧ���е���ѭ��
                                            totalCount += tempCount;//��Ӧһ�ܵ��ܺ�ͬһ��������� ������
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //���
                                        temp = "column" + index.ToString();
                                        drow2[temp] = totalCount;
                                        totalCount = 0;
                                        index++;
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        #region MyRegion
                        else if (i >= 19 && i <= 22)//ѹ��4��ͳ������
                        {
                            #region MyRegion
                            DataTable tableDay = new DataTable();
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            decimal jishuqishuSum = 0;//��Ӧ��������
                            //ͨ�����е�������� �������Ų�ѯ ĳһ��Ĳ���
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//��Ӧ���е���ѭ��
                                    decimal tempquexian = 0;//��Ӧȱ������
                                    decimal jishuqishu = 0;//��Ӧ��������

                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int h = 0; h < 2; h++)
                                        {
                                            if (h == 0)
                                            {
                                                tableDay = commonWorkShopRecordBLL.GetNumByDay(listDay[j], shenchanbianhaolist.TrimEnd(','), lingjianbianhaoList.TrimEnd(','));
                                                if (tableDay != null && tableDay.Rows.Count > 0)
                                                {
                                                    if (i == 19)
                                                    {
                                                        if (tableDay.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = dayCount;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 20)
                                                    {
                                                        if (tableDay.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 20700).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ��Ч��
                                                    }
                                                    else if (i == 21)
                                                    {

                                                        if (tableDay.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (tableDay.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (tableDay.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        drow2[temp] = tempquexian;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 22)
                                                    {
                                                        if (tableDay.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (tableDay.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (tableDay.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        if (tableDay.Columns.Contains("jishuqishu"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["jishuqishu"].ToString(), out jishuqishu);
                                                        }
                                                        jishuqishuSum += jishuqishu;
                                                        if (jishuqishu > 0)
                                                        {
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishu).ToString()) * 100, 2).ToString() + "%";//��Ӧ��ÿһ���ܺ�
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//��Ӧ��ÿһ���ܺ�
                                                        }
                                                    }
                                                }

                                            }
                                            else if (h == 1)
                                            {
                                                temp = "column" + index.ToString();
                                                index++;
                                                if (i == 19)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 20)
                                                {
                                                    drow2[temp] = "";  //������;//��Ӧ��ÿһ��Ч��
                                                }
                                                else if (i == 21)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 22)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        //��� ������
                                        if (i == 19)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 20)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 144900).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;
                                        }
                                        else if (i == 21)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 22)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        #endregion
                        else if (i >= 23 && i <= 24)//2̨��ɰ
                        {
                            #region MyRegion
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetDaShaDayCount(i == 23 ? 1 : 2, listDay[j], m == 2 ? "ҹ��" : "�װ�");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//��Ӧ��ÿһ��İװ����ҹ��
                                            index++;//��Ӧ���е���ѭ��
                                            totalCount += tempCount;//��Ӧһ�ܵ��ܺ�ͬһ��������� ������
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //���
                                        temp = "column" + index.ToString();
                                        drow2[temp] = totalCount;
                                        totalCount = 0;
                                        index++;
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 27 && i <= 30)//��ɰͳ��
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//��Ӧ��������
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//��Ӧ���е���ѭ��
                                    decimal tempquexian = 0;//��Ӧȱ������
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)//�װ��ҹ��
                                        {
                                            if (m == 1)
                                            {
                                                dtDaSha = commonWorkShopRecordBLL.GetDaShaNum("1," + "2", listDay[j]);
                                                if (dtDaSha != null && dtDaSha.Rows.Count > 0)
                                                {
                                                    if (i == 27)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = dayCount;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 28)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 44000).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ��Ч��
                                                    }
                                                    else if (i == 29)
                                                    {

                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        drow2[temp] = tempquexian;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 30)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        jishuqishuSum += dayCount;
                                                        if (dayCount > 0)
                                                        {
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//��Ӧ��ÿһ���ܺ�
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//��Ӧ��ÿһ���ܺ�
                                                        }
                                                    }
                                                }
                                            }
                                            else if (m == 2)
                                            {
                                                temp = "column" + index.ToString();
                                                index++;
                                                if (i == 27)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 28)
                                                {
                                                    drow2[temp] = "";  //������;//��Ӧ��ÿһ��Ч��
                                                }
                                                else if (i == 29)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 30)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��� ������
                                        if (i == 27)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 28)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 308000).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;
                                        }
                                        else if (i == 29)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 30)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 31 && i <= 44)//P04�������
                        {
                            #region MyRegion
                            shenchanbianhaolist31 += "'" + (i - 30).ToString() + "#" + "'" + ",";
                            lingjianbianhaoList31 += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetCuoPiFengDayCount(i - 30, lingjianbianhao.TrimEnd('/'), listDay[j], m == 2 ? "ҹ��" : "�װ�");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//��Ӧ��ÿһ��İװ����ҹ��
                                            index++;//��Ӧ���е���ѭ��
                                            totalCount += tempCount;//��Ӧһ�ܵ��ܺ�ͬһ��������� ������
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //���
                                        temp = "column" + index.ToString();
                                        drow2[temp] = totalCount;
                                        totalCount = 0;
                                        index++;
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 45 && i <= 48)//P04�������  ���ͳ��
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//��Ӧ��������
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//��Ӧ���е���ѭ��
                                    decimal tempquexian = 0;//��Ӧȱ������
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)//�װ��ҹ��
                                        {
                                            if (m == 1)
                                            {
                                                //����todo ��Ҫ�ٴ�һ�������� �ļ���
                                                dtDaSha = commonWorkShopRecordBLL.GetCuoPiFengNum(shenchanbianhaolist31.TrimEnd(','), listDay[j], lingjianbianhaoList31.TrimEnd(','));
                                                if (dtDaSha != null && dtDaSha.Rows.Count > 0)
                                                {
                                                    if (i == 45)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = dayCount;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 46)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 8300).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ��Ч��
                                                    }
                                                    else if (i == 47)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        drow2[temp] = tempquexian;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 48)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        jishuqishuSum += dayCount;
                                                        if (dayCount > 0)
                                                        {
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//��Ӧ��ÿһ���ܺ�
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//��Ӧ��ÿһ���ܺ�
                                                        }
                                                    }
                                                }
                                            }
                                            else if (m == 2)
                                            {
                                                temp = "column" + index.ToString();
                                                index++;
                                                if (i == 45)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 46)
                                                {
                                                    drow2[temp] = "";  //������;//��Ӧ��ÿһ��Ч��
                                                }
                                                else if (i == 47)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 48)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��� ������
                                        if (i == 45)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 46)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 58100).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;
                                        }
                                        else if (i == 47)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 48)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 49 && i <= 63)//�ֶ������� 
                        {
                            #region MyRegion
                            shenchanbianhaolist49 += "'" + bianhao + "'" + ",";
                            //lingjianbianhao = "";
                            //lingjianbianhao += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetShouDongCuoPiFengDayCount(bianhao, listDay[j], m == 2 ? "ҹ��" : "�װ�");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//��Ӧ��ÿһ��İװ����ҹ��
                                            index++;//��Ӧ���е���ѭ��
                                            totalCount += tempCount;//��Ӧһ�ܵ��ܺ�ͬһ��������� ������
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //���
                                        temp = "column" + index.ToString();
                                        drow2[temp] = totalCount;
                                        totalCount = 0;
                                        index++;
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 64 && i <= 67)
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//��Ӧ��������
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//��Ӧ���е���ѭ��
                                    decimal tempquexian = 0;//��Ӧȱ������
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)//�װ��ҹ��
                                        {
                                            if (m == 1)
                                            {
                                                //����todo ��Ҫ�ٴ�һ�������� �ļ���
                                                dtDaSha = commonWorkShopRecordBLL.GetShouDongCuoPiFengNum(shenchanbianhaolist49.TrimEnd(','), listDay[j]);
                                                if (dtDaSha != null && dtDaSha.Rows.Count > 0)
                                                {
                                                    if (i == 64)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = dayCount;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 65)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 9240).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ��Ч��
                                                    }
                                                    else if (i == 66)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        drow2[temp] = tempquexian;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 67)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        jishuqishuSum += dayCount;
                                                        if (dayCount > 0)
                                                        {
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//��Ӧ��ÿһ���ܺ�
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//��Ӧ��ÿһ���ܺ�
                                                        }
                                                    }
                                                }
                                            }
                                            else if (m == 2)
                                            {
                                                temp = "column" + index.ToString();
                                                index++;
                                                if (i == 64)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 65)
                                                {
                                                    drow2[temp] = "";  //������;//��Ӧ��ÿһ��Ч��
                                                }
                                                else if (i == 66)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 67)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��� ������
                                        if (i == 64)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 65)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 64680).ToString()) * 100, 2) + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;
                                        }
                                        else if (i == 66)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 67)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 68 && i <= 74)//ȫ��
                        {
                            #region MyRegion
                            shenchanbianhaolist68 += "'" + (i - 67).ToString() + "#" + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetQuanJianDayCount(i - 67, listDay[j], m == 2 ? "ҹ��" : "�װ�");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//��Ӧ��ÿһ��İװ����ҹ��
                                            index++;//��Ӧ���е���ѭ��
                                            totalCount += tempCount;//��Ӧһ�ܵ��ܺ�ͬһ��������� ������
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //���
                                        temp = "column" + index.ToString();
                                        drow2[temp] = totalCount;
                                        totalCount = 0;
                                        index++;
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 75 && i <= 78)//ȫ�����
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//��Ӧ��������
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//��Ӧ���е���ѭ��
                                    decimal tempquexian = 0;//��Ӧȱ������
                                    if (IsDateTime(listDay[j]))//��ʱ��
                                    {
                                        for (int m = 1; m <= 2; m++)//�װ��ҹ��
                                        {
                                            if (m == 1)
                                            {
                                                //����todo ��Ҫ�ٴ�һ�������� �ļ���
                                                dtDaSha = commonWorkShopRecordBLL.GetQuanJianNum(shenchanbianhaolist68.TrimEnd(','), listDay[j]);
                                                if (dtDaSha != null && dtDaSha.Rows.Count > 0)
                                                {
                                                    if (i == 75)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = dayCount;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 76)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 195000).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ��Ч��
                                                    }
                                                    else if (i == 77)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        drow2[temp] = tempquexian;//��Ӧ��ÿһ���ܺ�
                                                    }
                                                    else if (i == 78)
                                                    {
                                                        if (dtDaSha.Columns.Contains("yazhuquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["yazhuquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("cuopifengquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["cuopifengquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        if (dtDaSha.Columns.Contains("pinjianquexian"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["pinjianquexian"].ToString(), out dayCount);
                                                        }
                                                        tempquexian += dayCount;
                                                        zhouCount += tempquexian;
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        jishuqishuSum += dayCount;
                                                        if (dayCount > 0)
                                                        {
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//��Ӧ��ÿһ���ܺ�
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//��Ӧ��ÿһ���ܺ�
                                                        }
                                                    }
                                                }
                                            }
                                            else if (m == 2)
                                            {
                                                temp = "column" + index.ToString();
                                                index++;
                                                if (i == 75)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 76)
                                                {
                                                    drow2[temp] = "";  //������;//��Ӧ��ÿһ��Ч��
                                                }
                                                else if (i == 77)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                                else if (i == 78)
                                                {
                                                    drow2[temp] = "";//��Ӧ��ÿһ���ܺ�
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //��� ������
                                        if (i == 75)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 76)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 1365000).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;
                                        }
                                        else if (i == 77)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 78)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //������;//��Ӧ��ÿһ�ܵ�Ч��;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                    }
                }
            }
            #endregion
            //multiColHeaderDgvRiBaoBiao.DataSource = dtable;
            cmd.HideOpaqueLayer();
            MessageBox.Show("����ͳ�����,��������б�!����", "ϵͳ��ʾ",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning,
                 MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            //������������MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly������ʹ������MessageBox��ʾ����ǰ��;

        }
        public void ClearDataJiJia(object _delay)
        {
            int delay = (int)_delay;
            Thread.Sleep(delay);
            PassAuthentication(true);
        }

        private decimal GetQuanJianDayCount(int xianhao, string time, string banci)
        {
            DataTable dt = commonWorkShopRecordBLL.GetQuanJianDayCount(xianhao, time, banci);
            decimal num = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //��������
                if (dt.Columns.Contains("shengchanzongshu"))
                {
                    decimal.TryParse(dt.Rows[0]["shengchanzongshu"].ToString(), out num);
                }
            }
            return num;
        }

        private decimal GetShouDongCuoPiFengDayCount(string bianhao, string time, string banci)
        {
            DataTable dt = commonWorkShopRecordBLL.GetShouDongCuoPiFengDayCount(bianhao, time, banci);
            decimal num = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //��������
                if (dt.Columns.Contains("shengchanzongshu"))
                {
                    decimal.TryParse(dt.Rows[0]["shengchanzongshu"].ToString(), out num);
                }
            }
            return num;
        }

        private decimal GetCuoPiFengDayCount(int xianhao, string lingjianbianhao, string time, string banci)
        {
            DataTable dt = commonWorkShopRecordBLL.GetCuoPiFengDayCount(xianhao, lingjianbianhao, time, banci);
            decimal num = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //��������
                if (dt.Columns.Contains("shengchanzongshu"))
                {
                    decimal.TryParse(dt.Rows[0]["shengchanzongshu"].ToString(), out num);
                }
            }
            return num;
        }

        private decimal GetDaShaDayCount(int dashaindex, string time, string banci)
        {
            DataTable dt = commonWorkShopRecordBLL.GetDaShaDayCount(dashaindex, time, banci);
            decimal num = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //��������
                if (dt.Columns.Contains("shengchanzongshu"))
                {
                    decimal.TryParse(dt.Rows[0]["shengchanzongshu"].ToString(), out num);
                }
            }
            return num;
        }

        public decimal GetNum(string shebeibianhao, string lingjianbianhao, string time, string daynight)
        {
            DataTable dt = commonWorkShopRecordBLL.GetNum(shebeibianhao, lingjianbianhao, time, daynight);
            decimal num = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //��������
                if (dt.Columns.Contains("shengchanzongshu"))
                {
                    decimal.TryParse(dt.Rows[0]["shengchanzongshu"].ToString(), out num);
                }
            }
            return num;
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

                string header = headTitle.TrimEnd('#');
                //"��Ŀ#����#ѹ������#ѹ��������#ѹ�����䱨���� ѹ��,��ɰ1,��ɰ2,������,���ȫ��#ѹ�������ڲ�������#CNC����#����ȱ�ݱ����� CNC,��ϴ,��©,ȫ��#���ӳ������ձ�����#ѹ�����䱨������ ѹ������,CNC,ȫ����#ѹ���������ձ�����";
                DataSet ds = new DataSet();
                ds.Tables.Add(dtable.Copy());
                NPOIHelper helper = new WorkShopSystem.Utility.NPOIHelper("", "sheet", header, "��������ͳ��", ds, "", path, 2);
                string flag = helper.Export();
                if (flag == "ok")
                {
                    MessageBox.Show("�������ݳɹ���");
                    cmd.HideOpaqueLayer();
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            ////�ж��û��Ƿ���ȷ��ѡ�����ļ�
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    //��ȡ�û�ѡ���ļ��ĺ�׺��
            //    string extension = Path.GetExtension(fileDialog.FileName);
            //    //��������ĺ�׺��
            //    string[] str = new string[] { ".xls", ".xlsx" };
            //    if (!((IList<string>)str).Contains(extension))
            //    {
            //        MessageBox.Show("�����ϴ�xls,xlsx��ʽ��ͼƬ��");
            //    }
            //    else
            //    {
            //        //��ȡ�û�ѡ����ļ������ж��ļ���С���ܳ���20K��fileInfo.Length�����ֽ�Ϊ��λ��
            //        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
            //        txtFile.Text = fileInfo.FullName;
            //    }
            //}
        }

        private Dictionary<string, DataTable> ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            Dictionary<string, DataTable> dicDataTable = new Dictionary<string, DataTable>();//���巵��excel���е�sheet

            IWorkbook workbook = null;
            int index = 0;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                int sheetCount = 0;
                if (fileName.IndexOf(".xlsx") > 0) // 2007�汾
                {
                    workbook = new XSSFWorkbook(fs);
                    sheetCount = ((NPOI.XSSF.UserModel.XSSFWorkbook)workbook).Count;//�õ�sheet������
                }
                else if (fileName.IndexOf(".xls") > 0) // 2003�汾
                {
                    workbook = new HSSFWorkbook(fs);
                    sheetCount = ((NPOI.HSSF.UserModel.HSSFWorkbook)workbook).Count;//�õ�sheet������
                }
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //���û���ҵ�ָ����sheetName��Ӧ��sheet�����Ի�ȡ��һ��sheet
                    {
                        sheet = workbook.GetSheetAt(0);

                        data = GetDataBySheet(sheet, false);
                        dicDataTable.Add(sheet.SheetName, data);
                    }

                }
                else
                {
                    if (sheetCount > 0)
                    {
                        //int type = 0;
                        for (int i = 0; i < sheetCount; i++)//ѭ�����е�sheet
                        {
                            sheet = workbook.GetSheetAt(i);
                            if (workbook.IsSheetHidden(i))
                            {
                                continue;
                            }
                            //��sheet����
                            data = GetDataBySheet(sheet, false);
                            dicDataTable.Add(sheet.SheetName, data);
                        }
                    }
                }
                return dicDataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(index);
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        //����sheetIdȡ����
        /// <summary>
        /// ����sheetIdȡ����
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataTable GetDataBySheet(ISheet sheet, bool isFirstRowColumn)
        {
            Dictionary<int, string> dicTitle = new Dictionary<int, string>();
            DataTable data = new DataTable();
            int startRow = 0;
            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum; //һ�����һ��cell�ı�� ���ܵ�����
                                                      //ǰ�����Ƿ��Ǳ���
                if (isFirstRowColumn)
                {
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        ICell cell = firstRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = CommonHelper.GetPyFromName(cell.StringCellValue);
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }
                    startRow = firstRow.FirstCellNum + 1;
                }
                else
                {
                    startRow = sheet.FirstRowNum;
                }
                //���һ�еı��
                int rowCount = sheet.LastRowNum;
                int titleCount = 4;
                //bool flag = true;
                //for (int i = startRow; i <= rowCount; ++i)
                //{
                //    IRow row = sheet.GetRow(i);
                //    if (row == null) continue; //û�����ݵ���Ĭ����null��
                //    DataRow dataRow = data.NewRow();
                //    if (flag)
                //    {
                //        if (IsDateTime(Convert.ToString(GetCellValue(row.GetCell(0)))))
                //        {
                //            titleCount = i;
                //            flag = false;
                //            break;//����ѭ�� �ҵ����еı�����
                //        }
                //    }
                //}

                for (int i = 0; i < rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //û�����ݵ���Ĭ����null��
                    DataRow dataRow = data.NewRow();
                    //ǰtitleCount�д������
                    #region MyRegion
                    if (i < titleCount)
                    {
                        string temp = string.Empty;
                        string quexianType = string.Empty;
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null)
                            {
                                //dataRow[j] = GetCellValue(row.GetCell(j));
                                //listTitle.Add(row.GetCell(j).StringCellValue)
                                temp = CommonHelper.GetPyFromName(row.GetCell(j).StringCellValue);
                                if (temp == "" || temp == null)
                                {
                                    //��ǰ����ͷΪ�� ��֮ǰ���������� ��������ռ��
                                    if (dicTitle.ContainsKey(j))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        dicTitle.Add(j, "");
                                    }
                                }
                                if (dicTitle.ContainsKey(j))
                                {
                                    if (i == titleCount - 1)
                                    {
                                        //���һ�е���ϸ
                                        if (dicTitle[j] != null && dicTitle[j].ToString() != "")
                                        {
                                            quexianType = dicTitle[j].ToString();
                                            dicTitle[j] = quexianType + "_" + temp;
                                        }
                                        else
                                        {
                                            dicTitle[j] = quexianType + "_" + temp;
                                        }
                                    }
                                    else
                                    {
                                        dicTitle[j] = temp;
                                    }
                                }
                                else
                                {
                                    dicTitle.Add(j, temp);
                                }

                            }
                        }
                        if (i == titleCount - 1)
                        {
                            //ѭ������ӽ�ȥdata
                            if (dicTitle != null && dicTitle.Count > 0)
                            {
                                foreach (var item in dicTitle)
                                {
                                    DataColumn column = new DataColumn(item.Value);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        //int cellCount = row.LastCellNum; //һ�����һ��cell�ı�� ���ܵ�����
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null)
                            {
                                dataRow[j] = GetCellValue(row.GetCell(j));
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
            }
            return data;
        }
        public object GetCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell.CellType != CellType.Blank)//�����ڿ�ֵ
                {
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            //hssfCell.getCellStyle().getDataFormat()==28||hssfCell.getCellStyle().getDataFormat()==31
                            //cell.CellType.
                            //NPOI.SS.UserModel.DateUtil.IsCellDateFormatted(cell)
                            // Date comes here  HSSFDateUtil.IsCellDateFormatted(row.GetCell(j))
                            if (HSSFDateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;
                            }
                            else
                            {
                                // Numeric type
                                if (cell.ColumnIndex == 0)
                                {
                                    value = cell.DateCellValue;
                                }
                                else
                                {
                                    value = cell.NumericCellValue;
                                }

                            }
                            break;
                        case CellType.Boolean:
                            // Boolean type
                            value = cell.BooleanCellValue;
                            break;
                        case CellType.Formula:
                            //��������
                            if (HSSFDateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;
                            }
                            //����������
                            else
                            {
                                value = cell.NumericCellValue.ToString();
                            }
                            //value = cell.CellFormula;
                            break;
                        default:
                            // String type
                            value = cell.StringCellValue.Trim() == "" ? "0" : cell.StringCellValue.Trim();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                value = "";
            }

            return value;
        }

        private void btnFullList_Click(object sender, EventArgs e)
        {
            multiColHeaderDgvRiBaoBiao.DataSource = dtable;
        }
    }
}