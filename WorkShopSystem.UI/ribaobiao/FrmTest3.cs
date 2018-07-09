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
    public partial class FrmTest3 : Form
    {
        public FrmTest3()
        {
            InitializeComponent();
            btnLoadD.Enabled = true;
            GetMonthList();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        OpaqueCommand cmd = new OpaqueCommand();
        CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
        public delegate void AuthenticationDelegate(bool value);
        Microsoft.Office.Interop.Excel.Application xlApp;
        int totalColNum = 0;
        string time = "";
        int workshoptype = 0;
        string flagTemp = "first";
        public void GetMonthList()
        {
            DataTable dt = commonWorkShopRecordBLL.GetMonthList();
            DateTime dtime = new DateTime();
            List<string> listTime = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime.TryParse(dt.Rows[i]["time"].ToString(), out dtime);
                    this.cbMonthLIst.Items.Add(dtime.ToString("yyyy-MM"));
                    this.cbMonthLIst.SelectedIndex = 0;
                }
            }
        }
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
                initLeaf2(kv.Value, this.treeView1.Nodes[0]);
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
        DataTable dtable = new DataTable("Rock");
        private Thread loginThread = null;
        public void LoadData(object _delay)
        {
            if (flagTemp == "first")
            {
                flagTemp = "notfirst";
                //�״�
                ClearData(_delay);
            }
            else
            {
                //���ǵ�һ��
                dtable = new DataTable();
                totalColNum = 0;
                ClearData(_delay);
            }
        }
        public void ClearData(object _delay)
        {
            int delay = (int)_delay;
            Thread.Sleep(delay);
            //PassAuthentication(true);
            //btnLoadD.Enabled = false;
            //cmd.ShowOpaqueLayer(panel1, 125, true);
            //time = this.cbMonthLIst.SelectedItem.ToString();

            Dictionary<string, Dictionary<string, List<string>>> dicModel = GetDayByWeek(time);
            //GetDayByWeek(time);
            initParent(dicModel);

            //�ȸ��±�����
            //set columns names
            dtable.Columns.Add("gongyiliucheng", typeof(System.String));
            dtable.Columns.Add("xinghao", typeof(System.String));
            dtable.Columns.Add("bianhao", typeof(System.String));
            dtable.Columns.Add("lingjianbianhao", typeof(System.String));
            dtable.Columns.Add("dingeban", typeof(System.String));
            dtable.Columns.Add("xuqiubiaozhunchanneng", typeof(System.String));

            dtable.Columns.Add("shenchanxinxilan", typeof(System.String));
            //����һ��
            DataRow drow4 = dtable.NewRow();
            drow4["gongyiliucheng"] = "a";
            drow4["xinghao"] = "a";
            drow4["bianhao"] = "a";
            drow4["lingjianbianhao"] = "a";
            drow4["dingeban"] = "a";
            drow4["xuqiubiaozhunchanneng"] = "a";
            drow4["shenchanxinxilan"] = "a";
            //drow4["cuopifeng"] = "a";
            //drow4["hmianquanjian"] = "a";
            //drow4["yazhuchejianneibubaofeilv"] = "a";
            //drow4["cncchanneng"] = "a";
            //drow4["cnc"] = "a";
            //drow4["qingxi"] = "a";
            //drow4["celou"] = "a";
            //drow4["quanjian"] = "a";
            //drow4["jijiachejianzuizhongbaofeilv"] = "a";
            //drow4["yazhuchejian"] = "a";
            //drow4["cnc2"] = "a";
            //drow4["quanjianxian"] = "a";
            //drow4["yazhuchejianzuizhongbaofeilv"] = "a";

            for (int i = 0; i <= totalColNum - 1; i++)
            {
                dtable.Columns.Add("column" + i.ToString(), typeof(System.String));
                string temp = "column" + i.ToString();
                drow4[temp] = "1";//��Ӧ��ÿһ��İװ����ҹ��
            }
            dtable.Rows.Add(drow4);

            //��ȡ���е�����
            multiColHeaderDgv2.DataSource = dtable;
            cmd.HideOpaqueLayer();
            //MessageBox.Show("����ͳ�����,��������excel!");

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //btnLoadD.Enabled = false;
            //time = this.cbMonthLIst.SelectedItem.ToString();
            // workshoptype = this.cbWorkShopList.SelectedIndex;
            if (btnLoadD.Text == "���������б�")
            {
                btnLoadD.Text = "������...";
                if (loginThread != null)
                {
                    loginThread.Join();
                }
                loginThread = new Thread(new ParameterizedThreadStart(LoadData));
                loginThread.Start(5);

            }
            else
            {
                btnLoadD.Text = "�����������";
                cmd.HideOpaqueLayer();
                if (loginThread != null)
                    loginThread.Abort();
            }

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