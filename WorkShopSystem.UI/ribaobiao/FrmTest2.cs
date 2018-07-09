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
        string headTitle = "工艺流程#生产设备栏 型号,编号#零件编号#定额/班#需求标准产能#生产信息栏#";
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
                //递归调用，不断循环至叶节点
                if (IsDateTime(dic[i]))
                {
                    initLeaf3(ctn);
                }
            }
        }
        public void initLeaf3(TreeNode tn)
        {
            List<string> list = new List<string>() { "白班", "夜班" };
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
                dicList.Add(year.ToString() + "年第" + i.ToString() + "周", GetWeekSpan(i, dtBeginDate));
            }
            //去掉不是本月的 但是是本周的天数
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
            //totalColNum = dicList.Count * 7 * 2 + dicList.Count;//报表时间总的列数
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
        /// 获取当前周的几天
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
            listDay.Add("产能/周");
            //DateTime dtBeginDate = dtFirstDate.AddDays(-(iDaysOfWeek - 1));

            //DateTime dtEndDate = dtFirstDate.AddDays(7 - iDaysOfWeek);
            return listDay;
        }

        /**//// <summary>
            /// 求某年有多少周
            /// 返回 int
            /// </summary>
            /// <param name="strYear"></param>
            /// <returns>int</returns>
        public int GetYearWeekCount(int strYear)
        {
            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
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

        //初始化根节点
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
                //递归调用，不断循环至叶节点
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
            //先更新表数据
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
            //日期的列数
            for (int i = 0; i <= totalColNum - 1; i++)
            {
                dtable.Columns.Add("column" + i.ToString(), typeof(System.String));
                //string temp = "column" + i.ToString();
                //drow3[temp] = "1";//对应的每一天的白班或者夜班
            }
            //dtable.Rows.Add(drow3);
            string fileName = "biaotou.xlsx";
            Dictionary<string, DataTable> dicTables = ExcelToDataTable(fileName, null, false);//获取到excel的所有sheet   
            //dicTables = ExcelToDataTable(fileName, null, false);//获取到excel的所有sheet   
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
                    //求出所有的生产编号 和零件编号
                    string shenchanbianhaolist = string.Empty;
                    string lingjianbianhaoList = string.Empty;
                    string shenchanbianhaolist31 = string.Empty;
                    string lingjianbianhaoList31 = string.Empty;
                    string shenchanbianhaolist49 = string.Empty;
                    string shenchanbianhaolist68 = string.Empty;
                    string lingjianbianhao68 = string.Empty;
                    //计算 查询 每天的生产数量
                    Dictionary<string, List<string>> dicList = dicModel[""];
                    List<string> listDay = new List<string>();
                    if (dicList != null && dicList.Count > 0)
                    {
                        foreach (var item2 in dicList)
                        {
                            for (int k = 0; k < item2.Value.Count; k++)
                            {
                                if (item2.Value[k].ToString() == "产能/周")
                                {
                                    headTitle += item2.Key + item2.Value[k] + "#";
                                }
                                else
                                {
                                    headTitle += item2.Value[k] + " " + "白班,晚班#";
                                }

                                listDay.Add(item2.Value[k]);
                            }
                        }
                    }
                    #region 所有的行数
                    for (int i = 0; i < dt.Rows.Count; i++)//所有的行数
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
                        else if (i >= 68 && i <= 74)//全检
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

                        //循环时间查询
                        decimal meitianshuliang = 0;
                        string temp = string.Empty;
                        decimal tempCount = 0;//每天的产能
                        decimal totalCount = 0;//7天产能总和


                        int index = 0;
                        if (i <= 18)//压铸
                        {
                            #region MyRegion
                            shenchanbianhaolist += "'" + bianhao.Split('-')[1] + "#" + "'" + "," + "'" + bianhao.Split('-')[1] + "'" + ",";
                            lingjianbianhaoList += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetNum(bianhao.Split('-')[1] + "#", lingjianbianhao.TrimEnd('/'), listDay[j], m == 2 ? "夜班" : "白班");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//对应的每一天的白班或者夜班
                                            index++;//对应所有的列循环
                                            totalCount += tempCount;//对应一周的总和同一个生产编号 零件编号
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //求和
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
                        else if (i >= 19 && i <= 22)//压铸4行统计数据
                        {
                            #region MyRegion
                            DataTable tableDay = new DataTable();
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            decimal jishuqishuSum = 0;//对应计数器数
                            //通过所有的生产编号 和零件编号查询 某一天的产能
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//对应所有的列循环
                                    decimal tempquexian = 0;//对应缺陷总数
                                    decimal jishuqishu = 0;//对应计数器数

                                    if (IsDateTime(listDay[j]))//是时间
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
                                                        drow2[temp] = dayCount;//对应的每一天总和
                                                    }
                                                    else if (i == 20)
                                                    {
                                                        if (tableDay.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(tableDay.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 20700).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一天效率
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
                                                        drow2[temp] = tempquexian;//对应的每一天总和
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
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishu).ToString()) * 100, 2).ToString() + "%";//对应的每一天总和
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//对应的每一天总和
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
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 20)
                                                {
                                                    drow2[temp] = "";  //报废率;//对应的每一天效率
                                                }
                                                else if (i == 21)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 22)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        //求和 产能列
                                        if (i == 19)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 20)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 144900).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;
                                        }
                                        else if (i == 21)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 22)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //报废率;//对应的每一周的效率;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        #endregion
                        else if (i >= 23 && i <= 24)//2台打砂
                        {
                            #region MyRegion
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetDaShaDayCount(i == 23 ? 1 : 2, listDay[j], m == 2 ? "夜班" : "白班");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//对应的每一天的白班或者夜班
                                            index++;//对应所有的列循环
                                            totalCount += tempCount;//对应一周的总和同一个生产编号 零件编号
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //求和
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
                        else if (i >= 27 && i <= 30)//打砂统计
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//对应计数器数
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//对应所有的列循环
                                    decimal tempquexian = 0;//对应缺陷总数
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)//白班和夜班
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
                                                        drow2[temp] = dayCount;//对应的每一天总和
                                                    }
                                                    else if (i == 28)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 44000).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一天效率
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
                                                        drow2[temp] = tempquexian;//对应的每一天总和
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
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//对应的每一天总和
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//对应的每一天总和
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
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 28)
                                                {
                                                    drow2[temp] = "";  //报废率;//对应的每一天效率
                                                }
                                                else if (i == 29)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 30)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //求和 产能列
                                        if (i == 27)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 28)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 308000).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;
                                        }
                                        else if (i == 29)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 30)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //报废率;//对应的每一周的效率;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 31 && i <= 44)//P04、锉批锋
                        {
                            #region MyRegion
                            shenchanbianhaolist31 += "'" + (i - 30).ToString() + "#" + "'" + ",";
                            lingjianbianhaoList31 += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetCuoPiFengDayCount(i - 30, lingjianbianhao.TrimEnd('/'), listDay[j], m == 2 ? "夜班" : "白班");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//对应的每一天的白班或者夜班
                                            index++;//对应所有的列循环
                                            totalCount += tempCount;//对应一周的总和同一个生产编号 零件编号
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //求和
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
                        else if (i >= 45 && i <= 48)//P04、锉批锋  求和统计
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//对应计数器数
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//对应所有的列循环
                                    decimal tempquexian = 0;//对应缺陷总数
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)//白班和夜班
                                        {
                                            if (m == 1)
                                            {
                                                //明天todo 需要再传一个零件编号 的集合
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
                                                        drow2[temp] = dayCount;//对应的每一天总和
                                                    }
                                                    else if (i == 46)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 8300).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一天效率
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
                                                        drow2[temp] = tempquexian;//对应的每一天总和
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
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//对应的每一天总和
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//对应的每一天总和
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
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 46)
                                                {
                                                    drow2[temp] = "";  //报废率;//对应的每一天效率
                                                }
                                                else if (i == 47)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 48)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //求和 产能列
                                        if (i == 45)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 46)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 58100).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;
                                        }
                                        else if (i == 47)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 48)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //报废率;//对应的每一周的效率;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 49 && i <= 63)//手动挫披锋 
                        {
                            #region MyRegion
                            shenchanbianhaolist49 += "'" + bianhao + "'" + ",";
                            //lingjianbianhao = "";
                            //lingjianbianhao += "'" + lingjianbianhao.TrimEnd('/') + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetShouDongCuoPiFengDayCount(bianhao, listDay[j], m == 2 ? "夜班" : "白班");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//对应的每一天的白班或者夜班
                                            index++;//对应所有的列循环
                                            totalCount += tempCount;//对应一周的总和同一个生产编号 零件编号
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //求和
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
                            decimal jishuqishuSum = 0;//对应计数器数
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//对应所有的列循环
                                    decimal tempquexian = 0;//对应缺陷总数
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)//白班和夜班
                                        {
                                            if (m == 1)
                                            {
                                                //明天todo 需要再传一个零件编号 的集合
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
                                                        drow2[temp] = dayCount;//对应的每一天总和
                                                    }
                                                    else if (i == 65)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 9240).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一天效率
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
                                                        drow2[temp] = tempquexian;//对应的每一天总和
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
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//对应的每一天总和
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//对应的每一天总和
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
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 65)
                                                {
                                                    drow2[temp] = "";  //报废率;//对应的每一天效率
                                                }
                                                else if (i == 66)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 67)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //求和 产能列
                                        if (i == 64)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 65)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 64680).ToString()) * 100, 2) + "%";  //报废率;//对应的每一周的效率;
                                        }
                                        else if (i == 66)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 67)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //报废率;//对应的每一周的效率;;
                                            }
                                        }
                                    }
                                }
                            }
                            dtable.Rows.Add(drow2);
                            #endregion
                        }
                        else if (i >= 68 && i <= 74)//全检
                        {
                            #region MyRegion
                            shenchanbianhaolist68 += "'" + (i - 67).ToString() + "#" + "'" + ",";
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)
                                        {
                                            tempCount = GetQuanJianDayCount(i - 67, listDay[j], m == 2 ? "夜班" : "白班");
                                            temp = "column" + index.ToString();
                                            drow2[temp] = tempCount;//对应的每一天的白班或者夜班
                                            index++;//对应所有的列循环
                                            totalCount += tempCount;//对应一周的总和同一个生产编号 零件编号
                                            meitianshuliang += tempCount;
                                        }
                                    }
                                    else
                                    {
                                        //求和
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
                        else if (i >= 75 && i <= 78)//全检求和
                        {
                            #region MyRegion
                            decimal jishuqishuSum = 0;//对应计数器数
                            decimal dayCount = 0;
                            decimal zhouCount = 0;
                            DataTable dtDaSha = new DataTable();
                            if (listDay != null && listDay.Count > 0)
                            {
                                for (int j = 0; j < listDay.Count; j++)
                                {
                                    temp = "column" + index.ToString();
                                    index++;//对应所有的列循环
                                    decimal tempquexian = 0;//对应缺陷总数
                                    if (IsDateTime(listDay[j]))//是时间
                                    {
                                        for (int m = 1; m <= 2; m++)//白班和夜班
                                        {
                                            if (m == 1)
                                            {
                                                //明天todo 需要再传一个零件编号 的集合
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
                                                        drow2[temp] = dayCount;//对应的每一天总和
                                                    }
                                                    else if (i == 76)
                                                    {
                                                        if (dtDaSha.Columns.Contains("shengchanzongshu"))
                                                        {
                                                            decimal.TryParse(dtDaSha.Rows[0]["shengchanzongshu"].ToString(), out dayCount);
                                                        }
                                                        zhouCount += dayCount;
                                                        drow2[temp] = decimal.Round(decimal.Parse((dayCount / 195000).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一天效率
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
                                                        drow2[temp] = tempquexian;//对应的每一天总和
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
                                                            drow2[temp] = decimal.Round(decimal.Parse((tempquexian / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";//对应的每一天总和
                                                        }
                                                        else
                                                        {
                                                            drow2[temp] = 0;//对应的每一天总和
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
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 76)
                                                {
                                                    drow2[temp] = "";  //报废率;//对应的每一天效率
                                                }
                                                else if (i == 77)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                                else if (i == 78)
                                                {
                                                    drow2[temp] = "";//对应的每一天总和
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //求和 产能列
                                        if (i == 75)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 76)
                                        {
                                            drow2[temp] = decimal.Round(decimal.Parse((zhouCount / 1365000).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;
                                        }
                                        else if (i == 77)
                                        {
                                            drow2[temp] = zhouCount;
                                        }
                                        else if (i == 78)
                                        {
                                            if (jishuqishuSum > 0)
                                            {
                                                drow2[temp] = decimal.Round(decimal.Parse((zhouCount / jishuqishuSum).ToString()) * 100, 2).ToString() + "%";  //报废率;//对应的每一周的效率;;
                                            }
                                            else
                                            {
                                                drow2[temp] = 0;  //报废率;//对应的每一周的效率;;
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
            MessageBox.Show("数据统计完成,请点击填充列表!！！", "系统提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning,
                 MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            //增加两个属性MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly，可以使弹出的MessageBox显示到最前方;

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
                //计算总数
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
                //计算总数
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
                //计算总数
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
                //计算总数
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
                //计算总数
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

                string header = headTitle.TrimEnd('#');
                //"项目#年月#压铸产能#压铸计数器#压铸车间报废数 压铸,打砂1,打砂2,挫披锋,外观全检#压铸车间内部报废率#CNC产能#机加缺陷报废数 CNC,清洗,测漏,全检#机加车间最终报废率#压铸车间报废总数 压铸车间,CNC,全检线#压铸车间最终报废率";
                DataSet ds = new DataSet();
                ds.Tables.Add(dtable.Copy());
                NPOIHelper helper = new WorkShopSystem.Utility.NPOIHelper("", "sheet", header, "车间数据统计", ds, "", path, 2);
                string flag = helper.Export();
                if (flag == "ok")
                {
                    MessageBox.Show("导出数据成功！");
                    cmd.HideOpaqueLayer();
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            ////判断用户是否正确的选择了文件
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    //获取用户选择文件的后缀名
            //    string extension = Path.GetExtension(fileDialog.FileName);
            //    //声明允许的后缀名
            //    string[] str = new string[] { ".xls", ".xlsx" };
            //    if (!((IList<string>)str).Contains(extension))
            //    {
            //        MessageBox.Show("仅能上传xls,xlsx格式的图片！");
            //    }
            //    else
            //    {
            //        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
            //        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
            //        txtFile.Text = fileInfo.FullName;
            //    }
            //}
        }

        private Dictionary<string, DataTable> ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            Dictionary<string, DataTable> dicDataTable = new Dictionary<string, DataTable>();//定义返回excel所有的sheet

            IWorkbook workbook = null;
            int index = 0;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                int sheetCount = 0;
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook(fs);
                    sheetCount = ((NPOI.XSSF.UserModel.XSSFWorkbook)workbook).Count;//得到sheet的总数
                }
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                {
                    workbook = new HSSFWorkbook(fs);
                    sheetCount = ((NPOI.HSSF.UserModel.HSSFWorkbook)workbook).Count;//得到sheet的总数
                }
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
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
                        for (int i = 0; i < sheetCount; i++)//循环所有的sheet
                        {
                            sheet = workbook.GetSheetAt(i);
                            if (workbook.IsSheetHidden(i))
                            {
                                continue;
                            }
                            //传sheet名字
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
        //根据sheetId取数据
        /// <summary>
        /// 根据sheetId取数据
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
                int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                                                      //前几行是否是标题
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
                //最后一列的标号
                int rowCount = sheet.LastRowNum;
                int titleCount = 4;
                //bool flag = true;
                //for (int i = startRow; i <= rowCount; ++i)
                //{
                //    IRow row = sheet.GetRow(i);
                //    if (row == null) continue; //没有数据的行默认是null　
                //    DataRow dataRow = data.NewRow();
                //    if (flag)
                //    {
                //        if (IsDateTime(Convert.ToString(GetCellValue(row.GetCell(0)))))
                //        {
                //            titleCount = i;
                //            flag = false;
                //            break;//跳出循环 找到所有的标题行
                //        }
                //    }
                //}

                for (int i = 0; i < rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　
                    DataRow dataRow = data.NewRow();
                    //前titleCount行处理标题
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
                                    //当前格里头为空 若之前存在则跳过 不存在则占坑
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
                                        //最后一行的详细
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
                            //循环标题加进去data
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
                        //int cellCount = row.LastCellNum; //一行最后一个cell的编号 即总的列数
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
                if (cell.CellType != CellType.Blank)//不等于空值
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
                            //是日期型
                            if (HSSFDateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;
                            }
                            //不是日期型
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