using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI
{
    public partial class testBar : Form
    {
        public testBar()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private delegate void SetPos(int ipos);
        private void button1_Click(object sender, EventArgs e)
        {
            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.Start();

            //progressBar1.Maximum = 10000;
            //progressBar1.Step = 1;
            //progressBar1.Value = 0;
            //backgroundWorker1.RunWorkerAsync();

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                //backgroundWorker1.RunWorkerAsync();

                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerAsync("Tank");
                }
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 这里是后台线程， 是在另一个线程上完成的
            // 这里是真正做事的工作线程
            // 可以在这里做一些费时的，复杂的操作



            BackgroundWorker worker = sender as BackgroundWorker;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            string str = @"E:\520\xjtuSystem\机加车间统计表2018.xlsx";
            DataTable dt = ExcelToDataTable(str, "", false);
            int num = dt.Rows.Count;
            progressBar1.Maximum = Convert.ToInt32(num);
            for (int j = 0; j < 7926; j++)
            {
                // Perform a time consuming operation and report progress.
                //ChangeList(dt);
                //System.Threading.Thread.Sleep(500);

                progressBar1.Value = j;
                Application.DoEvents();
                worker.ReportProgress(j * 10);


                //backgroundWorker.ReportProgress((j * 100) / 1000);
            }

            Thread.Sleep(5000);
            e.Result = e.Argument + "工作线程完成";
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            this.label1.Text = e.Result.ToString();
        }

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //var backgroundWorker = sender as BackgroundWorker;
            BackgroundWorker worker = sender as BackgroundWorker;
            string str = @"E:\520\xjtuSystem\机加车间统计表2018.xlsx";
            DataTable dt = ExcelToDataTable(str, "", false);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                // Perform a time consuming operation and report progress.
                ChangeList(dt);
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress(j * 10);


                //backgroundWorker.ReportProgress((j * 100) / 1000);
            }



            //for (int i = 1; i <= 10; i++)
            //{
            //    if (worker.CancellationPending == true)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        System.Threading.Thread.Sleep(500);
            //        worker.ReportProgress(i * 10);
            //    }
            //}
        }

        public void ChangeList(DataTable dt)
        {
            int index = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                index++;
            }
        }


        public DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            Dictionary<int, string> dicTitle = new Dictionary<int, string>();
            int startRow = 0;
            IWorkbook workbook = null;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
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
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　
                        DataRow dataRow = data.NewRow();
                        //前4行处理标题
                        #region MyRegion
                        if (i < 4)
                        {
                            string temp = string.Empty;
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    //dataRow[j] = GetCellValue(row.GetCell(j));
                                    //listTitle.Add(row.GetCell(j).StringCellValue)
                                    temp = CommonHelper.GetPyFromName(row.GetCell(j).StringCellValue);
                                    if (temp == "" || temp == null)
                                    {
                                        continue;
                                    }
                                    if (dicTitle.ContainsKey(j))
                                    {
                                        dicTitle[j] = i.ToString() + "_" + temp;
                                    }
                                    else
                                    {
                                        dicTitle.Add(j, i.ToString() + "_" + temp);
                                    }

                                }
                            }
                            if (i == 3)
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
                                    dataRow[j] = row.GetCell(j);
                                    //row.GetCell(j).ToString();
                                } //同理，没有数据的单元格都默认是null                               
                            }
                            data.Rows.Add(dataRow);
                        }
                        #region 1
                        //if (titleCout == 4)
                        //{
                        //    if (dicTitle != null && dicTitle.Count >"0")
                        //    {
                        //        foreach (var item in dicTitle)
                        //        {
                        //            dataTitle.Rows.Add(item.Value);
                        //        }
                        //    }
                        //} 
                        #endregion
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
            finally
            {
                Dispose();
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            label1.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

    }
}
