using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WorkShopSystem.BLL;
using WorkShopSystem.Model;
using WorkShopSystem.UI.loading;
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI.yazhu
{
    public partial class YaZhuHome : Form
    {
        public YaZhuHome()
        {
            InitializeComponent();
            //InitDemo();
        }
        DataTable dtable = new DataTable();
        string header = string.Empty;
        public delegate void AuthenticationDelegate(bool value);
        private int redrawCounter = -1;
        OpaqueCommand cmd = new OpaqueCommand();
        CommonWorkShopRecordBLL BLL = new CommonWorkShopRecordBLL();
        Microsoft.Office.Interop.Excel.Application xlApp;
        private void YaZhuHome_Load(object sender, EventArgs e)
        {
            //listView.GridLines = true;//表格是否显示网格线
            //listView.FullRowSelect = true;//是否选中整行
            //listView.View = View.Details;//设置显示方式
            //listView.Scrollable = true;//是否自动显示滚动条
            //listView.MultiSelect = false;//是否可以选择多行
            this.cbLiuCheng.SelectedIndex = 0;
            this.cbPiaoType.SelectedIndex = 0;
            this.cbBanCi.SelectedIndex = 0;
            dtpStart.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now;
        }

        private void LoadCheckedListBox3Content(int type)
        {
            string timeStart = dtpStart.Value.ToString("yyyy-MM-dd");
            string timeEnd = dtpEnd.Value.ToString("yyyy-MM-dd");
            string strTemp = string.Empty;
            double temp = 0;

            if (checkedListBox3.InvokeRequired == false)
            {
                checkedListBox3.Items.Clear();
                DataTable dt = new DataTable();
                dt = BLL.GetLiuChengPiaoList(timeStart, timeEnd, "a");
                switch (type)
                {
                    case 0:
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                strTemp = dt.Rows[i]["liuchengpiaobianhao"].ToString();
                                if (double.TryParse(strTemp.Trim(), out temp))
                                {
                                    checkedListBox3.Items.Add(strTemp);
                                }
                            }
                        }
                        break;
                    case 1:
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                strTemp = dt.Rows[i]["liuchengpiaobianhao"].ToString();
                                if (strTemp.ToLower().IndexOf("p") >= 0 || strTemp.ToLower().IndexOf("f") >= 0)
                                {
                                    checkedListBox3.Items.Add(strTemp);
                                }
                            }
                        }
                        break;
                    default:
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                strTemp = dt.Rows[i]["liuchengpiaobianhao"].ToString();
                                if ((strTemp.ToLower().IndexOf("p") < 0 && strTemp.ToLower().IndexOf("f") < 0) && !double.TryParse(strTemp.Trim(), out temp))
                                {
                                    checkedListBox3.Items.Add(strTemp);
                                }
                            }
                        }
                        break;
                }
                //默认全选
                if (checkedListBox3.Items.Count > 0)
                {
                    for (int i = 0; i < checkedListBox3.Items.Count; i++)
                    {
                        checkedListBox3.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                NPDelegate myDelegate = new NPDelegate(LoadCheckedListBox1Content);
                this.Invoke(myDelegate);
            }
        }

        private void LoadCheckedListBox2Content()
        {
            if (checkedListBox2.InvokeRequired == false)
            {
                checkedListBox2.Items.Clear();
                DataTable dt = new DataTable();
                dt = BLL.GetMaoPiList("a");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        checkedListBox2.Items.Add(dt.Rows[i]["maopeihao"].ToString());
                    }
                }
                //默认全选
                if (checkedListBox2.Items.Count > 0)
                {
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                NPDelegate myDelegate = new NPDelegate(LoadCheckedListBox1Content);
                this.Invoke(myDelegate);
            }
        }

        private void LoadCheckedListBox1Content()
        {
            if (checkedListBox1.InvokeRequired == false)
            {
                checkedListBox1.Items.Clear();
                DataTable dt = new DataTable();
                dt = BLL.GetMuHaoList("a");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        checkedListBox1.Items.Add(dt.Rows[i]["muhao"].ToString());
                    }
                }
                //默认全选
                if (checkedListBox1.Items.Count > 0)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                NPDelegate myDelegate = new NPDelegate(LoadCheckedListBox1Content);
                this.Invoke(myDelegate);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dtable = new DataTable();
            header = "";
            btnExcel.Enabled = true;
            cmd.ShowOpaqueLayer(panel1, 125, true);
            //listView.Items.Clear();
            //listView.Clear();
            List<string> titleList = new List<string>();
            Dictionary<string, string> dicTitle = new Dictionary<string, string>();
            foreach (Control cl in groupBox1.Controls)//，与上面的区别在这里哦——循环groupBox1上的控件
            {
                if (cl is CheckBox)//看看是不是checkbox
                {
                    CheckBox ck = cl as CheckBox;//将找到的control转化成checkbox
                    if (ck.Checked)//判断是否选中
                    {
                        dicTitle.Add(ck.Name, ck.Text);
                        dtable.Columns.Add(ck.Text, typeof(System.String));
                        header += ck.Text + "#";
                        //sb += ck.Text + ",";
                    }
                }
            }
            if (dicTitle.Count <= 0)
            {
                MessageBox.Show("请勾选表头！");
                return;
            }
            //if (dicTitle != null && dicTitle.Count > 0)
            //{
            //    foreach (var item2 in dicTitle)
            //    {
            //        listView.Columns.Add(item2.Value, 160, HorizontalAlignment.Center);
            //    }
            //}
            //根据条件查询          
            //模号
            string muHaoList = GetCheckedListBoxState1();
            //毛坯号 
            string maoPiHaoList = GetCheckedListBoxState2();
            //流程票 
            string liuChengPiaoList = GetCheckedListBoxState3();
            //查询表数据
            string dtStart = dtpStart.Value.ToString("yyyy-MM-dd");
            string drEnd = dtpEnd.Value.ToString("yyyy-MM-dd");
            StringBuilder strWhere = new StringBuilder();
            if (dtStart.Trim() != "" && drEnd.Trim() != "")
            {
                strWhere.Append(string.Format(@" convert(char(10) ,time , 120)<='{0}' and convert(char(10) ,time , 120) >='{1}'", drEnd, dtStart));
            }

            if (muHaoList != null && muHaoList != "")
            {
                strWhere.Append(string.Format(@" and muhao in ({0})", muHaoList));
            }

            if (maoPiHaoList != null && maoPiHaoList != "")
            {
                strWhere.Append(string.Format(@" and maopeihao in ({0})", maoPiHaoList));
            }

            if (liuChengPiaoList == "")
            {
                //strWhere.Append(string.Format(@" and liuchengpiaobianhao =''", liuChengPiaoList));
            }
            else
            {
                strWhere.Append(string.Format(@" and liuchengpiaobianhao in ({0})", liuChengPiaoList));
            }

            int liuCheng = cbLiuCheng.SelectedIndex;
            if (liuCheng > 0)
            {
                strWhere.Append(string.Format(@" and workshoptype = {0}", liuCheng));
            }
            else
            {
                strWhere.Append(string.Format(@" and workshoptype in(0,1,2,3,4)"));
                //strWhere.Append(string.Format(@" and workshoptype in(5,6,7,8)"));
            }

            int banCi = cbBanCi.SelectedIndex;
            if (banCi > 0)
            {
                string banCiText = cbBanCi.SelectedItem.ToString();
                strWhere.Append(string.Format(@" and banci = '{0}'", banCiText));
            }

            //System.Threading.Thread test = new System.Threading.Thread(new System.Threading.ThreadStart(Loading(strWhere)));
            //test.Start();
            DataTable dt = BLL.GetList(strWhere.ToString());
            //ListViewItem item;
            DataTable dtSum = BLL.GetListSum(strWhere.ToString());
            if (dtSum != null && dtSum.Rows.Count > 0)
            {
                string colTemp = string.Empty;
                double tempDou = 0;
                for (int i = 0; i < dtSum.Rows.Count; i++)
                {
                    //titleList所有选择的复选框的Name
                    int index = 0;
                    //item = new ListViewItem();
                    DataRow drow = dtable.NewRow();
                    //加总数到第一行

                    foreach (var itemDic in dicTitle)
                    {
                        if (itemDic.Key == "liuchengpiaobianhao")
                        {
                            tempDou = 0;
                        }
                        else
                        {
                            index = dtSum.Rows[i].Table.Columns.IndexOf(itemDic.Key);
                            //item.SubItems.Add(dt.Rows[i][dt.Rows[i].Table.Columns[index]].ToString());
                            if (index == -1)
                            {
                                tempDou = 0;
                            }
                            else
                            {
                                double.TryParse(dtSum.Rows[i][dtSum.Rows[i].Table.Columns[index]].ToString(), out tempDou);
                            }
                        }
                        drow[itemDic.Value] = tempDou;
                    }
                    //item.SubItems.RemoveAt(0);
                    //listViewJiJia.Items.Add(item);
                    dtable.Rows.Add(drow);
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                string colTemp = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //titleList所有选择的复选框的Name
                    int index = 0;
                    //item = new ListViewItem();
                    DataRow drow = dtable.NewRow();
                    foreach (var itemDic in dicTitle)
                    {
                        index = dt.Rows[i].Table.Columns.IndexOf(itemDic.Key);
                        //item.SubItems.Add(dt.Rows[i][dt.Rows[i].Table.Columns[index]].ToString());
                        drow[itemDic.Value] = dt.Rows[i][dt.Rows[i].Table.Columns[index]].ToString();
                    }
                    //item.SubItems.RemoveAt(0);
                    //listView.Items.Add(item);
                    dtable.Rows.Add(drow);
                }
                dataGridViewYaZhu.DataSource = dtable;
                dataGridViewYaZhu.Rows[0].Frozen = true;
                this.dataGridViewYaZhu.Rows[0].Selected = false;
                this.dataGridViewYaZhu.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                cmd.HideOpaqueLayer();
            }

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string colTemp = string.Empty;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        //titleList所有选择的复选框的Name
            //        int index = 0;
            //        //item = new ListViewItem();
            //        DataRow drow = dtable.NewRow();
            //        //加总数到第一行

            //        foreach (var itemDic in dicTitle)
            //        {
            //            index = dt.Rows[i].Table.Columns.IndexOf(itemDic.Key);
            //            //item.SubItems.Add(dt.Rows[i][dt.Rows[i].Table.Columns[index]].ToString());
            //            drow[itemDic.Value] = dt.Rows[i][dt.Rows[i].Table.Columns[index]].ToString();
            //        }
            //        //item.SubItems.RemoveAt(0);
            //        //listViewJiJia.Items.Add(item);
            //        dtable.Rows.Add(drow);
            //    }
            //    dataGridViewYaZhu.DataSource = dtable;
            //    dataGridViewYaZhu.Rows[0].Frozen = true;
            //    this.dataGridViewYaZhu.Rows[0].Selected = false;
            //    this.dataGridViewYaZhu.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            //    cmd.HideOpaqueLayer();
            //}
        }

        private string GetCheckedListBoxState2()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (checkedListBox2.InvokeRequired == false)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i) == true)
                    {
                        stringBuilder.Append(string.Format("'{0}'" + ",", checkedListBox2.Items[i].ToString()));
                    }
                }
            }
            else
            {
                StateDelegate stateDelegate = new StateDelegate(GetCheckedListBoxState2);
                this.Invoke(stateDelegate);
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
        private string GetCheckedListBoxState3()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (checkedListBox3.InvokeRequired == false)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    if (checkedListBox3.GetItemChecked(i) == true)
                    {
                        stringBuilder.Append(string.Format("'{0}'" + ",", checkedListBox3.Items[i].ToString()));
                    }
                }
            }
            else
            {
                StateDelegate stateDelegate = new StateDelegate(GetCheckedListBoxState3);
                this.Invoke(stateDelegate);
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        private string GetCheckedListBoxState1()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (checkedListBox1.InvokeRequired == false)
            {

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        stringBuilder.Append(string.Format("'{0}'" + ",", checkedListBox1.Items[i].ToString()));
                    }
                }
            }
            else
            {
                StateDelegate stateDelegate = new StateDelegate(GetCheckedListBoxState1);
                this.Invoke(stateDelegate);
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        DateTimePicker dateTimePicker1 = new DateTimePicker();
        DateTimePicker dateTimePicker2 = new DateTimePicker();

        //void InitDemo()
        //{
        //    this.dtpEnd.ValueChanged += new System.EventHandler(dateTimePicker2_ValueChanged);
        //    this.dtpStart.Value = new DateTime(2000, 1, 2);
        //    this.dtpEnd.Value = new DateTime(2000, 1, 1);
        //}
        //bool changing = false;
        //List<int> list = new List<int>();
        //void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        //{
        //    if (changing) return;

        //    var ret = dateTimePicker2.Value.Date.CompareTo(dateTimePicker1.Value.Date);
        //    list.Add(ret); // 记录比较结果
        //    if (ret == -1)
        //    {
        //        MessageBox.Show("结束时间应晚于或等于起始时间");
        //        changing = true;
        //        dateTimePicker2.Value = dateTimePicker1.Value.Date;
        //        changing = false;
        //    }
        //}

        private void DtpEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd"));
            DateTime drEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd"));
            //MessageBox.Show(dtStart.ToString("yyyy-MM-dd HH:mm:ss"));
            //MessageBox.Show(drEnd.ToString("yyyy-MM-dd HH:mm:ss"));
            if (dtStart > drEnd)
            {
                MessageBox.Show("开始时间应小于结束时间");
                dtpStart.Value = dtpStart.Value.AddDays(-1);
            }
            //WaitForDraw();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtStart = dtpStart.Value;
            DateTime drEnd = dtpEnd.Value;
            if (dtStart > drEnd)
            {
                MessageBox.Show("开始时间应小于结束时间");
                dtpEnd.Value = dtpEnd.Value.AddDays(1);
            }
            //WaitForDraw();
        }
        private void WaitForDraw()
        {
            redrawCounter = 10;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (redrawCounter == 0)
            {
                //bool showDetail = Properties.Settings.Default.showDetail;
                //if (showDetail == true)
                //    DrawLink();
                //else
                //    DrawLinkWithAS();
                //ResetAutoUpdate();

                //更新与时间关联的其他条件的列表

            }
            redrawCounter--;
            if (redrawCounter < -1)
                redrawCounter = -1;
        }
        private Thread YaZhuThread = null;
        string fileName = string.Empty;
        private void btnExcel_Click(object sender, EventArgs e)
        {
            btnExcel.Enabled = false;
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
            //try
            //{
            //    //ExportToExecl();
            //    if (YaZhuThread != null)
            //    {
            //        YaZhuThread.Join();
            //    }
            //    System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.DefaultExt = "xls";
            //    sfd.Filter = "Excel文件(*.xls)|*.xls";
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        YaZhuThread = new Thread(new ParameterizedThreadStart(LoadExcel));
            //        YaZhuThread.Start(0);
            //        fileName = sfd.FileName;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //finally
            //{
            //    EndReport();
            //}
        }
        private void ExportToExecl()
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件 (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;

                //string heade = header.TrimEnd('#');
                DataSet ds = new DataSet();
                ds.Tables.Add(dtable.Copy());
                NPOIHelper helper = new WorkShopSystem.Utility.NPOIHelper("", "压铸车间", header.TrimEnd('#'), "压铸车间数据查询", ds, "", path, 2);
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
        //public void LoadExcel(object _delay)
        //{
        //    int delay = (int)_delay;
        //    Thread.Sleep(delay);
        //    PassAuthentication(true);
        //    //ExportToExecl();
        //    DoExport(listView, fileName);
        //}

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
        //private void ExportToExecl()
        //{
        //    System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.DefaultExt = "xls";
        //    sfd.Filter = "Excel文件(*.xls)|*.xls";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        DoExport(listView, sfd.FileName);
        //    }
        //}
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, true);
            }
        }

        private void 全不选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadCheckedListBox1Content();//加载模号
            LoadCheckedListBox2Content();//加载毛坯号
            LoadCheckedListBox3Content(cbPiaoType.SelectedIndex);//加载流程票号
        }
        public void LoadData(object _delay)
        {
            try
            {
                int delay = (int)_delay;
                Thread.Sleep(delay);
                PassAuthentication(true);
                LoadCheckedListBox1Content();//加载模号
                LoadCheckedListBox2Content();//加载毛坯号
                LoadCheckedListBox3Content(0);//加载流程票号
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            cmd.HideOpaqueLayer();
        }
        private void PassAuthentication(bool value)
        {
            if (this.InvokeRequired == false)
            {
                if (value == true)
                {
                    cmd.ShowOpaqueLayer(panel1, 125, true);
                    //resultLabel.Text = "执行中...";
                }
                else
                {
                    btnLoadData.Text = "加载完成!";
                }
            }
            else
            {
                AuthenticationDelegate myDelegate = new AuthenticationDelegate(PassAuthentication);
                this.Invoke(myDelegate, new object[] { value });
            }

        }
        private Thread loginThread = null;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据票的类型加载该类型对应的数据
            //数字开头的是生产类型 P开头的是返修类型 F开头的是品检 剩余的是其他类型
            //根据时间筛选出的数据
            int type = cbPiaoType.SelectedIndex;
            LoadCheckedListBox3Content(type);
            //默认全选
            if (checkedListBox3.Items.Count > 0)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, true);
                }
            }
        }
    }
    public delegate void NPDelegate();
    public delegate string StateDelegate();

}
