using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorkShopSystem.Model;
using WorkShopSystem.Utility;
using WorkShopSystem.BLL;
using System.Threading;
using WorkShopSystem.UI.loading;
using WorkShopSystem.UI.cleardata;
using MultiColHeaderDgvTest;
using WorkShopSystem.UI.yazhu;
using WorkShopSystem.UI.Statistic;

namespace WorkShopSystem.UI
{
    public partial class MainForm : Form
    {
        CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
        public delegate void AuthenticationDelegate(bool value);
        int num = 0;
        DataTable dt = new DataTable();
        //MachineShopProductionRecordBLL bll = new MachineShopProductionRecordBLL();
        Dictionary<int, string> dicTitle = new Dictionary<int, string>();
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            LoadDataIncome();
        }


        private void LoadDataIncome()
        {
            List<WealthyInfo> WealthyList1 = new List<WealthyInfo>();
            List<WealthyInfo> WealthyList2 = new List<WealthyInfo>();
            DataTable dtAllCol = commonWorkShopRecordBLL.GetAllGroupByTime();
            DateTime dt;
            double numTemp = 0;
            if (dtAllCol != null && dtAllCol.Rows.Count > 0)
            {
                for (int k = 0; k < dtAllCol.Rows.Count; k++)//获取所有的日期集合
                {
                    DataTable dtDetail = new DataTable();
                    dtDetail = commonWorkShopRecordBLL.GetNumByTime("a", dtAllCol.Rows[k]["time"].ToString());
                    DateTime.TryParse(dtAllCol.Rows[k]["time"].ToString(), out dt);
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        double.TryParse(dtDetail.Rows[0]["shengchanshu"].ToString(), out numTemp);
                        WealthyList1.Add(new WealthyInfo()
                        {
                            AmountExpensesMoney = numTemp,
                            AmountIncomeMoney = numTemp,
                            DeposiTime = dt,
                            ProductName = dt.ToString("yyyy-MM-dd")
                        });
                    }
                    dtDetail = commonWorkShopRecordBLL.GetNumByTime("b", dtAllCol.Rows[k]["time"].ToString());
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        double.TryParse(dtDetail.Rows[0]["shengchanshu"].ToString(), out numTemp);
                        WealthyList2.Add(new WealthyInfo()
                        {
                            AmountExpensesMoney = numTemp,
                            AmountIncomeMoney = numTemp,
                            DeposiTime = dt,
                            ProductName = dt.ToString("yyyy-MM-dd")
                        });
                    }
                }
            }
            //    WealthyList = new WealthyBLL().GetWealthyIncomeInfoModels();
            ChartControl chart1 = new ChartControl();
            chart1.BindChart(WealthyList1,"a");
            elementHost1.Child = chart1;

            ChartControl chart2 = new ChartControl();
            chart2.BindChartExpense(WealthyList2,"b");
            elementHost2.Child = chart2;
        }



        OpaqueCommand cmd = new OpaqueCommand();
        public DataTable ImportExcelFile(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();
                IWorkbook wk = null;
                string extension = System.IO.Path.GetExtension(filePath);
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    if (extension.Equals(".xls"))
                    {
                        //把xls文件中的数据写入wk中
                        wk = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        //把xlsx文件中的数据写入wk中
                        wk = new XSSFWorkbook(fs);
                    }

                    fs.Close();
                    //读取当前表数据
                    ISheet sheet = wk.GetSheetAt(0);

                    IRow row = sheet.GetRow(0);  //读取当前行数据
                    //LastRowNum 是当前表的总行数-1（注意）
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    {
                        row = sheet.GetRow(i);  //读取当前行数据
                        if (row != null)
                        {
                            //LastCellNum 是当前行的总列数
                            for (int j = 0; j < row.LastCellNum; j++)
                            {
                                //读取该行的第j列数据
                                string value = row.GetCell(j).ToString();
                                Console.Write(value.ToString() + " ");
                            }
                            Console.WriteLine("\n");
                        }
                    }
                }
                return dt;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Excel格式错误或者Excel正由另一进程在访问");
                return null;
            }
        }

        public DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();

            int startRow = 0;
            IWorkbook workbook = null;
            int index = 0;
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
                        if (i > 10000)
                        {
                            break;
                        }
                        index++;
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
                                    dataRow[j] = GetCellValue(row.GetCell(j));
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
                Console.WriteLine(index);
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
            finally
            {
                Dispose();
            }
        }


        public void WriteToDb(DataTable dt)
        {

        }
        //获取cell的数据，并设置为对应的数据类型
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
                                //CommonHelper.DateTimeToUnix(cell.DateCellValue).ToString();
                            }
                            else
                            {
                                // Numeric type
                                if (cell.ColumnIndex == 0)
                                {
                                    value = cell.DateCellValue;
                                    //value = CommonHelper.DateTimeToUnix(cell.DateCellValue).ToString();
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
                                value = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
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
                            value = cell.StringCellValue;
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
        private Thread loginThread = null;
        private void btnClearData_Click(object sender, EventArgs e)
        {
        }

        public void ClearData(object _delay)
        {
        }
        private void PassAuthentication(bool value)
        {
            //if (this.InvokeRequired == false)
            //{
            //    if (value == true)
            //    {
            //        cmd.ShowOpaqueLayer(panel1, 125, true);
            //        //resultLabel.Text = "执行中...";
            //    }
            //    else
            //    {
            //        btnClearData.Text = "清理over!";
            //    }
            //}
            //else
            //{
            //    AuthenticationDelegate myDelegate = new AuthenticationDelegate(PassAuthentication);
            //    this.Invoke(myDelegate, new object[] { value });
            //}

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            ////判断用户是否正确的选择了文件
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = string.Empty;
            //    //获取用户选择文件的后缀名
            //    string extension = Path.GetExtension(fileDialog.FileName);
            //    //声明允许的后缀名
            //    string[] str = new string[] { ".xls", ".xlsx" };
            //    if (!((IList)str).Contains(extension))
            //    {
            //        MessageBox.Show("仅能上传xls,xlsx格式的图片！");
            //    }
            //    else
            //    {
            //        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
            //        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
            //        txtUrl.Text = fileInfo.FullName;
            //    }
            //}
        }

        private void LoadCmbboxYaZhuJi()
        {
            //获取所有的压铸机
            //DataTable dtYaZhu = bll.GetList("");
        }

        private void tsb_jijia_Click(object sender, EventArgs e)
        {
            JiJiaHome jijia = new yazhu.JiJiaHome();
            jijia.ShowDialog();
        }

        private void tsbClearData_Click(object sender, EventArgs e)
        {
            ClearDataForm clearDataForm = new ClearDataForm();
            clearDataForm.ShowDialog();
        }

        private void tsbYaZhu_Click(object sender, EventArgs e)
        {
            yazhu.YaZhuHome yaZhuHome = new yazhu.YaZhuHome();
            yaZhuHome.ShowDialog();
        }

        private void tsbStatic_Click(object sender, EventArgs e)
        {
            FrmTest test = new MultiColHeaderDgvTest.FrmTest();
            test.ShowDialog();
            //Statistic.StatisticHome statisticHome = new Statistic.StatisticHome();
            //statisticHome.ShowDialog();
        }

        private void tsbChaXun_Click(object sender, EventArgs e)
        {
            QueryHome qHome = new Statistic.QueryHome();
            qHome.ShowDialog();
        }

        private void tsbRiBaoBiao_Click(object sender, EventArgs e)
        {

        }
    }
}
