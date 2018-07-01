﻿using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WorkShopSystem.BLL;
using WorkShopSystem.Model;
using WorkShopSystem.UI.loading;
using WorkShopSystem.UI.WaitingBox;
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI.cleardata
{
    public partial class ClearDataForm : Form
    {
        public delegate void AuthenticationDelegate(bool value);
        DataTable dt = new DataTable();

        List<CommonModel> machineList = new List<CommonModel>();
        public ClearDataForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        OpaqueCommand cmd = new OpaqueCommand();
        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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
        /// <summary>
        /// ExcelToDataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public Dictionary<string, DataTable> ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
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
                    //sheet = workbook.GetSheetAt(0);
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
            finally
            {
                Dispose();
            }
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
                int titleCount = 0;
                bool flag = true;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　
                    DataRow dataRow = data.NewRow();
                    if (flag)
                    {
                        if (IsDateTime(Convert.ToString(GetCellValue(row.GetCell(0)))))
                        {
                            titleCount = i;
                            flag = false;
                            break;//跳出循环 找到所有的标题行
                        }
                    }
                }

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
        /// <summary>
        /// 获取有格式单元格的数据
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
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
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = string.Empty;
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名
                string[] str = new string[] { ".xls", ".xlsx" };
                if (!((IList<string>)str).Contains(extension))
                {
                    MessageBox.Show("仅能上传xls,xlsx格式的图片！");
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    txtFile.Text = fileInfo.FullName;
                }
            }
        }

        private Thread loginThread = null;



        //int times;
        //private void btnClearData_Click(object sender, EventArgs e)
        //{
        //    string fileName = txtFile.Text;
        //    if (fileName == null || fileName == "")
        //    {
        //        MessageBox.Show("请先打开文件！");
        //        return;
        //    }

        //    times = 0;
        //    Thread th = new Thread(new ThreadStart(this.ExecWaitForm));
        //    th.Start();
        //    btnClearData.Enabled = false;
        //}
        //private void ExecWaitForm()
        //{
        //    try
        //    {
        //        WaitFormService.Show();

        //        WaitFormService.SetText("正在执行 ，请耐心等待....");

        //        //times++;

        //        //for (int i = 0; i < 10000; i++)
        //        //{
        //        //    WaitFormService.SetText(times.ToString() + "正在执行 ，请耐心等待...." + i.ToString());

        //        //}
        //        ClearData();

        //        WaitFormService.Close();
        //        if (times == 3)
        //        {
        //            btnClearData.Enabled = true;
        //            return;
        //        }
        //        ExecWaitForm();


        //    }
        //    catch (Exception ex)
        //    {
        //        WaitFormService.Close();
        //    }
        //}



        private void btnClearData_Click(object sender, EventArgs e)
        {
            string fileName = txtFile.Text;
            if (fileName == null || fileName == "")
            {
                MessageBox.Show("请先打开文件！");
                return;
            }
            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.IsBackground = false;
            //fThread.Start();
            //cmd.ShowOpaqueLayer(panel1, 125, true);
            if (btnClearData.Text == "数据入库")
            {
                btnClearData.Text = "入库中...";
                if (loginThread != null)
                {
                    loginThread.Join();
                }
                loginThread = new Thread(new ParameterizedThreadStart(ClearData));
                loginThread.Start(0);
            }
            else
            {
                btnClearData.Text = "数据入库";
                if (loginThread != null)
                    loginThread.Abort();
            }
        }

        public void ClearData(object _delay)
        {
            try
            {
                int delay = (int)_delay;
                Thread.Sleep(delay);
                //cmd.ShowOpaqueLayer(panel1, 125, true);
                string fileName = txtFile.Text;
                Dictionary<string, DataTable> dicTables = new Dictionary<string, DataTable>();
                DataTable dt = new DataTable();
                #region 根据文件的路径的名字判断数据类型
                #region 机加
                if (fileName.Contains("机加"))
                {
                    //循环dt入库
                    PassAuthentication(true);
                    CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
                    dicTables = ExcelToDataTable(fileName, null, false);//获取到excel的所有sheet                               
                    if (dicTables != null && dicTables.Count > 0)
                    {
                        string sheetName = string.Empty;
                        int type = -1;
                        foreach (var item in dicTables)
                        {
                            type++;
                            //if (type == 0 || type == 1 || type == 2)
                            //{
                            //    continue;
                            //}
                            //枚举 0 1 2 3 4 
                            dt = dicTables[item.Key];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                CommonWorkShopRecord model = new CommonWorkShopRecord();
                                DateTime tiemTemp = new DateTime();
                                string yazhujitaihao = string.Empty;
                                string jihuashu = string.Empty;
                                string jishuqishuzhi = string.Empty;
                                string gonghao = string.Empty;
                                decimal tempNum = 0;
                                #region MyRegion
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //if(Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]) != "0318010103")
                                    //{
                                    //    continue;
                                    //}else
                                    //{
                                    //    bool flag = true;
                                    //}
                                    //if (i <= 1589)
                                    //{
                                    //    continue;
                                    //}
                                    //else
                                    //{
                                    //    bool flag = true;
                                    //}
                                    decimal? shenChanShu = 0;
                                    if (dt.Columns.Contains("shideshengchanshu"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["shideshengchanshu"].ToString(), out tempNum);
                                        model.shengchanzongshu = tempNum;
                                    }
                                    shenChanShu = model.shengchanzongshu;
                                    QuanJianDetailBLL quanJianBll = new BLL.QuanJianDetailBLL();
                                    QuanJianDetail quanJianModel = new Model.QuanJianDetail();
                                    switch (type)
                                    {
                                        case 0:
                                            #region 机加车间拉线统计
                                            model.workshoptype = 5;
                                            quanJianModel = new QuanJianDetail();
                                            if (dt.Columns.Contains("jiagongqingxiquexian_diaojipin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_diaojipin"].ToString(), out tempNum);
                                                quanJianModel.cnctiaojipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianyashang"].ToString(), out tempNum);
                                                quanJianModel.falanmianyashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianhuahenpengshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianhuahenpengshang"].ToString(), out tempNum);
                                                quanJianModel.falanmianhuahenpengshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_mianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_mianyashang"].ToString(), out tempNum);
                                                quanJianModel.hmianyashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_jinqikoukepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_jinqikoukepeng"].ToString(), out tempNum);
                                                quanJianModel.jinqikoukepeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shangzhouchengkongkepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shangzhouchengkongkepeng"].ToString(), out tempNum);
                                                quanJianModel.shangzhouchengkongkepeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_daowen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_daowen"].ToString(), out tempNum);
                                                quanJianModel.daowen = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_kongjingchaocha"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_kongjingchaocha"].ToString(), out tempNum);
                                                quanJianModel.kongjingchaocha = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shuiyin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shuiyin"].ToString(), out tempNum);
                                                quanJianModel.shuiyin = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_zangwu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_zangwu"].ToString(), out tempNum);
                                                quanJianModel.zangwu = tempNum;
                                            }
                                            model.jijiaquexian = quanJianModel.cnctiaojipin + quanJianModel.falanmianyashang + quanJianModel.falanmianhuahenpengshang + quanJianModel.hmianyashang + quanJianModel.jinqikoukepeng + quanJianModel.shangzhouchengkongkepeng + quanJianModel.daowen + quanJianModel.kongjingchaocha + quanJianModel.shuiyin + quanJianModel.zangwu;
                                            //以上是压铸缺陷
                                            if (dt.Columns.Contains("maopiquexian_jiagongbuliang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_jiagongbuliang"].ToString(), out tempNum);
                                                quanJianModel.jiagongbuliang = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_shakong"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_shakong"].ToString(), out tempNum);
                                                quanJianModel.shakong = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_liewen"].ToString(), out tempNum);
                                                quanJianModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_bengque"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_bengque"].ToString(), out tempNum);
                                                quanJianModel.bengque = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_feihua"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_feihua"].ToString(), out tempNum);
                                                quanJianModel.feihua = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_feipeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_feipeng"].ToString(), out tempNum);
                                                quanJianModel.feipeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_feijiagongaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_feijiagongaokeng"].ToString(), out tempNum);
                                                quanJianModel.feijiagongmianaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_qipi"].ToString(), out tempNum);
                                                quanJianModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_zazhi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_zazhi"].ToString(), out tempNum);
                                                quanJianModel.zazhi = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_nianmo"].ToString(), out tempNum);
                                                quanJianModel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_maopifamei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_maopifamei"].ToString(), out tempNum);
                                                quanJianModel.maopeifamei = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_yanghuafahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_yanghuafahei"].ToString(), out tempNum);
                                                quanJianModel.yanghuafahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                quanJianModel.qita = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lamo"].ToString(), out tempNum);
                                                quanJianModel.lamo = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                quanJianModel.xiankawai = tempNum;
                                            }
                                            model.yazhuquexian = quanJianModel.jiagongbuliang + quanJianModel.shakong + quanJianModel.liewen + quanJianModel.bengque + quanJianModel.feihua + quanJianModel.feipeng + quanJianModel.qipi + quanJianModel.zazhi + quanJianModel.nianmo + quanJianModel.maopeifamei + quanJianModel.yanghuafahei + quanJianModel.luodi + quanJianModel.qita + quanJianModel.lamo + quanJianModel.xiankawai;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                quanJianModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            quanJianModel.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            quanJianModel.type = 1;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            model.baofeizongshu = model.jijiaquexian + model.yazhuquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 1://车间清洗
                                            #region 清洗统计
                                            model.workshoptype = 6;
                                            quanJianModel = new QuanJianDetail();
                                            if (dt.Columns.Contains("waiguanquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_queliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_queliao"].ToString(), out tempNum);
                                                quanJianModel.qita = tempNum;
                                            }
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                quanJianModel.chouyangshu = tempNum;
                                            }
                                            if (dt.Columns.Contains("pinjian_gonghao"))
                                            {
                                                quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            }
                                            model.jijiaquexian = quanJianModel.luodi + quanJianModel.qita;
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            quanJianModel.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            quanJianModel.type = 2;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            model.baofeizongshu = model.jijiaquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 2:
                                            #region CNC统计
                                            model.workshoptype = 7;
                                            quanJianModel = new QuanJianDetail();
                                            if (dt.Columns.Contains("jiagongqingxiquexian_diaojipin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_diaojipin"].ToString(), out tempNum);
                                                quanJianModel.cnctiaojipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianyashang"].ToString(), out tempNum);
                                                quanJianModel.falanmianyashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianhuahenpengshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianhuahenpengshang"].ToString(), out tempNum);
                                                quanJianModel.falanmianhuahenpengshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_mianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_mianyashang"].ToString(), out tempNum);
                                                quanJianModel.hmianyashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_jinqikoukepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_jinqikoukepeng"].ToString(), out tempNum);
                                                quanJianModel.jinqikoukepeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shangzhouchengkongkepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shangzhouchengkongkepeng"].ToString(), out tempNum);
                                                quanJianModel.shangzhouchengkongkepeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_daowen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_daowen"].ToString(), out tempNum);
                                                quanJianModel.daowen = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_kongjingchaocha"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_kongjingchaocha"].ToString(), out tempNum);
                                                quanJianModel.kongjingchaocha = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shuiyin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shuiyin"].ToString(), out tempNum);
                                                quanJianModel.shuiyin = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_zangwu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_zangwu"].ToString(), out tempNum);
                                                quanJianModel.zangwu = tempNum;
                                            }
                                            model.jijiaquexian = quanJianModel.cnctiaojipin + quanJianModel.falanmianyashang + quanJianModel.falanmianhuahenpengshang + quanJianModel.hmianyashang + quanJianModel.jinqikoukepeng + quanJianModel.shangzhouchengkongkepeng + quanJianModel.daowen + quanJianModel.kongjingchaocha + quanJianModel.shuiyin + quanJianModel.zangwu;
                                            //以上是压铸缺陷
                                            if (dt.Columns.Contains("maopiquexian_jiagongbuliang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_jiagongbuliang"].ToString(), out tempNum);
                                                quanJianModel.jiagongbuliang = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_shakong"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_shakong"].ToString(), out tempNum);
                                                quanJianModel.shakong = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_liewen"].ToString(), out tempNum);
                                                quanJianModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_bengque"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_bengque"].ToString(), out tempNum);
                                                quanJianModel.bengque = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_feijiagongaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_feijiagongaokeng"].ToString(), out tempNum);
                                                quanJianModel.feijiagongmianaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_qipi"].ToString(), out tempNum);
                                                quanJianModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_zazhi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_zazhi"].ToString(), out tempNum);
                                                quanJianModel.zazhi = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_nianmo"].ToString(), out tempNum);
                                                quanJianModel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_maopifamei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_maopifamei"].ToString(), out tempNum);
                                                quanJianModel.maopeifamei = tempNum;
                                            }
                                            if (dt.Columns.Contains("maopiquexian_yanghuafahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_yanghuafahei"].ToString(), out tempNum);
                                                quanJianModel.yanghuafahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                quanJianModel.qita = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lamo"].ToString(), out tempNum);
                                                quanJianModel.lamo = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                quanJianModel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lvxue"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lvxue"].ToString(), out tempNum);
                                                quanJianModel.lvxue = tempNum;
                                            }
                                            model.yazhuquexian = quanJianModel.jiagongbuliang + quanJianModel.shakong + quanJianModel.liewen + quanJianModel.bengque + quanJianModel.qipi + quanJianModel.zazhi + quanJianModel.nianmo + quanJianModel.maopeifamei + quanJianModel.yanghuafahei + quanJianModel.luodi + quanJianModel.qita + quanJianModel.lamo + quanJianModel.xiankawai + quanJianModel.feijiagongmianaokeng + quanJianModel.lvxue;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                quanJianModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            quanJianModel.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            quanJianModel.type = 3;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            model.baofeizongshu = model.jijiaquexian + model.yazhuquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 3:
                                            #region 测漏统计
                                            quanJianModel = new QuanJianDetail();
                                            model.workshoptype = 8;
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_shideshengchanshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_shideshengchanshu"].ToString(), out tempNum);
                                                model.shengchanzongshu = tempNum;
                                            }
                                            if (!Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"]) && dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"].ToString().Trim() != "")
                                            {
                                                tiemTemp = Convert.ToDateTime(dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"]);
                                            }
                                            model.time = tiemTemp;
                                            model.yazhujihao = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jitaixianhao"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jitaixianhao"]);
                                            model.maopeihao = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_maopihao"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_maopihao"]);
                                            model.muhao = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_mohao"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_mohao"]);
                                            model.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_liuchengpiaobianhao"]);
                                            model.banci = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_banci"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_banci"]);

                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_falanmianhuahenpengshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_falanmianhuahenpengshang"].ToString(), out tempNum);
                                                quanJianModel.falanmianhuahenpengshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_shangzhouchengkongkepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_shangzhouchengkongkepeng"].ToString(), out tempNum);
                                                quanJianModel.shangzhouchengkongkepeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_jiagongbuliang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jiagongbuliang"].ToString(), out tempNum);
                                                quanJianModel.jiagongbuliang = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_louqi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_louqi"].ToString(), out tempNum);
                                                quanJianModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_lvxie"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_lvxie"].ToString(), out tempNum);
                                                quanJianModel.lvxue = tempNum;
                                            }
                                            if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jita"].ToString(), out tempNum);
                                                quanJianModel.qita = tempNum;
                                            }
                                            quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_caozuoyuangonghao"]) ? "" : Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_caozuoyuangonghao"]);
                                            quanJianModel.type = 4;
                                            quanJianModel.liuchengpiaobianhao = model.liuchengpiaobianhao;
                                            model.jijiaquexian = quanJianModel.falanmianhuahenpengshang + quanJianModel.shangzhouchengkongkepeng + quanJianModel.jiagongbuliang + quanJianModel.luodi + quanJianModel.qipi + quanJianModel.lvxue + quanJianModel.qita;
                                            quanJianBll.Add(quanJianModel);
                                            model.baofeizongshu = model.jijiaquexian; //报废总数
                                            if (model.shengchanzongshu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / model.shengchanzongshu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            if (dt.Columns.Contains("gonghao"))
                                            {
                                                if (!Convert.IsDBNull(dt.Rows[i]["gonghao"]) && dt.Rows[i]["gonghao"].ToString().Trim() != "")
                                                {
                                                    gonghao = Convert.ToString(dt.Rows[i]["gonghao"]);
                                                }
                                            }
                                            model.gonghao = gonghao;
                                            model.isdel = 0;
                                            commonWorkShopRecordBLL.Add(model);
                                            #endregion
                                            break;
                                    }
                                    if (type != 3)
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["riji"]) && dt.Rows[i]["riji"].ToString().Trim() != "")
                                        {
                                            DateTime.TryParse(dt.Rows[i]["riji"].ToString(), out tiemTemp);
                                        }
                                        model.time = tiemTemp;   //日期
                                        if (dt.Columns.Contains("jitaixianhao"))
                                        {
                                            if (!Convert.IsDBNull(dt.Rows[i]["jitaixianhao"]) && dt.Rows[i]["jitaixianhao"].ToString().Trim() != "")
                                            {
                                                yazhujitaihao = Convert.ToString(dt.Rows[i]["jitaixianhao"]);
                                            }
                                        }
                                        model.yazhujihao = yazhujitaihao; //机台线号
                                        if (dt.Columns.Contains("xianhao"))
                                        {
                                            if (!Convert.IsDBNull(dt.Rows[i]["xianhao"]) && dt.Rows[i]["xianhao"].ToString().Trim() != "")
                                            {
                                                model.xianhao = Convert.ToString(dt.Rows[i]["xianhao"]);
                                            }
                                        }
                                        model.maopeihao = Convert.ToString(dt.Rows[i]["chanpinxinghao"]); //产品型号
                                        model.muhao = Convert.ToString(dt.Rows[i]["mohao"]);   //模号
                                        model.liuchengpiaobianhao = Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                        model.banci = Convert.ToString(dt.Rows[i]["banci"]);   //班次
                                        if (dt.Columns.Contains("jihuashengchanshu"))
                                        {
                                            model.jihuashengchanshu = Convert.IsDBNull(dt.Rows[i]["jihuashengchanshu"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["jihuashengchanshu"]);
                                        }

                                        if (dt.Columns.Contains("jishuqishuzhi"))
                                        {
                                            model.jishuqishu = Convert.IsDBNull(dt.Rows[i]["jishuqishuzhi"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["jishuqishuzhi"]);
                                        }
                                        if (dt.Columns.Contains("shideshengchanshu"))
                                        {
                                            model.shengchanzongshu = Convert.IsDBNull(dt.Rows[i]["shideshengchanshu"]) ? 0 : Convert.ToDecimal(dt.Rows[i]["shideshengchanshu"]);
                                        }
                                        if (dt.Columns.Contains("gonghao"))
                                        {
                                            if (!Convert.IsDBNull(dt.Rows[i]["gonghao"]) && dt.Rows[i]["gonghao"].ToString().Trim() != "")
                                            {
                                                gonghao = Convert.ToString(dt.Rows[i]["gonghao"]);
                                            }
                                        }
                                        model.gonghao = gonghao;
                                        //返修明细
                                        JiJiaFanXiuDetail fanxiuModel = new JiJiaFanXiuDetail();
                                        JiJiaFanXiuDetailBLL fanxiuBll = new JiJiaFanXiuDetailBLL();
                                        if (dt.Columns.Contains("jinqikoukepeng"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["jinqikoukepeng"].ToString(), out tempNum);
                                            fanxiuModel.jinqikoukepeng = tempNum;
                                        }
                                        if (dt.Columns.Contains("falanmianhuashang"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["falanmianhuashang"].ToString(), out tempNum);
                                            fanxiuModel.falanmianhuashang = tempNum;
                                        }
                                        if (dt.Columns.Contains("pensha"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["pensha"].ToString(), out tempNum);
                                            fanxiuModel.falanmianhuashang = tempNum;
                                        }
                                        if (dt.Columns.Contains("kefanxipin"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["kefanxipin"].ToString(), out tempNum);
                                            fanxiuModel.kefanxipin = tempNum;
                                        }
                                        if (dt.Columns.Contains("kefanfamei"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["kefanfamei"].ToString(), out tempNum);
                                            fanxiuModel.kefanfamei = tempNum;
                                        }
                                        if (dt.Columns.Contains("xiaoshakongkefanxiu"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["xiaoshakongkefanxiu"].ToString(), out tempNum);
                                            fanxiuModel.kefanfamei = tempNum;
                                        }
                                        if (dt.Columns.Contains("louqi"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["louqi"].ToString(), out tempNum);
                                            fanxiuModel.louqi = tempNum;
                                        }
                                        fanxiuModel.beizhu = dt.Columns.Contains("beizhu") ? (Convert.IsDBNull(dt.Rows[i]["beizhu"]) ? "" : Convert.ToString(dt.Rows[i]["beizhu"])) : "";  //备注
                                        model.fanxiuzongshu = fanxiuModel.jinqikoukepeng + fanxiuModel.falanmianhuashang;
                                        fanxiuModel.liuchengpiaobianhao = model.liuchengpiaobianhao;
                                        fanxiuBll.Add(fanxiuModel);
                                        if (shenChanShu != 0)
                                        {
                                            model.fanxiulv = decimal.Round(decimal.Parse((model.fanxiuzongshu / shenChanShu).ToString()), 4);  //报废率
                                        }
                                        else
                                        {
                                            model.fanxiulv = 0;  //返修率
                                        }
                                        model.shengchanzongshu = shenChanShu;
                                        model.isdel = 0;
                                        model.gongxu = dt.Columns.Contains("gongxu") ? (Convert.IsDBNull(dt.Rows[i]["gongxu"]) ? "" : Convert.ToString(dt.Rows[i]["gongxu"])) : "";  //工序  不是共同有的字段

                                        commonWorkShopRecordBLL.Add(model);
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
                #endregion
                #endregion
                #region 压铸
                if (fileName.Contains("压铸"))
                {
                    //循环dt入库
                    PassAuthentication(true);
                    CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
                    dicTables = ExcelToDataTable(fileName, null, false);//获取到excel的所有sheet                               
                    if (dicTables != null && dicTables.Count > 0)
                    {
                        string sheetName = string.Empty;
                        int type = -1;
                        foreach (var item in dicTables)
                        {
                            type++;
                            //if (type == 0 || type == 1 || type == 2 || type == 3)
                            //{
                            //    continue;
                            //}
                            //枚举 0 1 2 3 4 
                            dt = dicTables[item.Key];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                CommonWorkShopRecord model = new CommonWorkShopRecord();
                                DateTime tiemTemp = new DateTime();
                                string yazhujitaihao = string.Empty;
                                string jihuashu = string.Empty;
                                string jishuqishuzhi = string.Empty;
                                string gonghao = string.Empty;
                                decimal tempNum = 0;
                                #region MyRegion
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]) != "0118030108"
                                    //if (i <= 4259)  0118040096
                                    //{
                                    //    continue;
                                    //}
                                    //else if (i >= 4261 && i < 4303)
                                    //{
                                    //    continue;
                                    //}
                                    //else
                                    //{
                                    //    bool flag = true;
                                    //}
                                    decimal? fanxiuShu = 0;
                                    decimal? shenChanShu = 0;
                                    if (dt.Columns.Contains("shengchanzongshu"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["shengchanzongshu"].ToString(), out tempNum);
                                        shenChanShu = tempNum;
                                    }
                                    switch (type)
                                    {
                                        case 0://压铸缺陷
                                            #region 压铸缺陷
                                            YaZhuBaoFeiDetailBLL yaZhuBll = new BLL.YaZhuBaoFeiDetailBLL();
                                            YaZhuBaoFeiDetail yaZhuModel = new Model.YaZhuBaoFeiDetail();
                                            if (dt.Columns.Contains("yazhuquexian_diaojipin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_diaojipin"].ToString(), out tempNum);
                                                yaZhuModel.tiaojipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                                yaZhuModel.feijiagongaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                yaZhuModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                                yaZhuModel.nainmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lamo"].ToString(), out tempNum);
                                                yaZhuModel.lamo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_qipi"].ToString(), out tempNum);
                                                yaZhuModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_youwufahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_youwufahei"].ToString(), out tempNum);
                                                yaZhuModel.youwufahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_cuoshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_cuoshang"].ToString(), out tempNum);
                                                yaZhuModel.cuoshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                                yaZhuModel.shangzhouchengjushang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                yaZhuModel.chongshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                                yaZhuModel.bengliao = tempNum;
                                            }
                                            model.yazhuquexian = yaZhuModel.tiaojipin + yaZhuModel.feijiagongaokeng + yaZhuModel.liewen + yaZhuModel.nainmo + yaZhuModel.lamo + yaZhuModel.qipi + yaZhuModel.youwufahei + yaZhuModel.cuoshang + yaZhuModel.shangzhouchengjushang + yaZhuModel.chongshang + yaZhuModel.bengliao;
                                            //以上是压铸缺陷
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                yaZhuModel.penghuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                                yaZhuModel.hmianhuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                yaZhuModel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_ladepin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_ladepin"].ToString(), out tempNum);
                                                yaZhuModel.luodipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_shangzhouchengkongduanlie"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_shangzhouchengkongduanlie"].ToString(), out tempNum);
                                                yaZhuModel.shangzhouchengkongduanlie = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jitan"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jitan"].ToString(), out tempNum);
                                                yaZhuModel.jitan = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_lengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lengliao"].ToString(), out tempNum);
                                                yaZhuModel.lengliao = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                yaZhuModel.qita = tempNum;
                                            }
                                            model.cuopifengquexian = yaZhuModel.penghuashang + yaZhuModel.hmianhuashang + yaZhuModel.xiankawai + yaZhuModel.luodipin + yaZhuModel.shangzhouchengkongduanlie + yaZhuModel.jitan + yaZhuModel.lengliao + yaZhuModel.qita;
                                            //以上是挫披锋缺陷
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                yaZhuModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = yaZhuModel.chouyangshu;
                                            yaZhuModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            yaZhuModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            //以上是品检缺陷=抽样数
                                            yaZhuBll.Add(yaZhuModel);
                                            model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 1://打砂缺陷
                                            #region DaShaBaoFeiDetail
                                            DaShaBaoFeiDetailBLL daShaBll = new BLL.DaShaBaoFeiDetailBLL();
                                            DaShaBaoFeiDetail daShaMpdel = new Model.DaShaBaoFeiDetail();
                                            if (dt.Columns.Contains("yazhuquexian_gaodiyadiaoji"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_gaodiyadiaoji"].ToString(), out tempNum);
                                                daShaMpdel.gaodiyatiaoji = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                                daShaMpdel.feijiagongaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                daShaMpdel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                                daShaMpdel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_qipi"].ToString(), out tempNum);
                                                daShaMpdel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_youwufahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_youwufahei"].ToString(), out tempNum);
                                                daShaMpdel.youwufahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_cuoshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_cuoshang"].ToString(), out tempNum);
                                                daShaMpdel.cuoshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                                daShaMpdel.shangzhouchengjushang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                daShaMpdel.chongshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                                daShaMpdel.bengliao = tempNum;
                                            }
                                            model.yazhuquexian = daShaMpdel.gaodiyatiaoji + daShaMpdel.feijiagongaokeng + daShaMpdel.liewen + daShaMpdel.nianmo + daShaMpdel.qipi + daShaMpdel.youwufahei + daShaMpdel.cuoshang + daShaMpdel.shangzhouchengjushang + daShaMpdel.chongshang + daShaMpdel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                daShaMpdel.penghuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                                daShaMpdel.hmianhuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                daShaMpdel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_ladepin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_ladepin"].ToString(), out tempNum);
                                                daShaMpdel.luodipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                daShaMpdel.qita = tempNum;
                                            }
                                            model.cuopifengquexian = daShaMpdel.penghuashang + daShaMpdel.hmianhuashang + daShaMpdel.xiankawai + daShaMpdel.luodipin + daShaMpdel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                daShaMpdel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = daShaMpdel.chouyangshu;
                                            daShaMpdel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["waiguanquexian_gonghao"]);
                                            daShaMpdel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            daShaMpdel.dashaType = 1;
                                            daShaBll.Add(daShaMpdel);
                                            model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 2:
                                            #region DaShaBaoFeiDetail
                                            DaShaBaoFeiDetailBLL daShaBll2 = new BLL.DaShaBaoFeiDetailBLL();
                                            DaShaBaoFeiDetail daShaModel = new Model.DaShaBaoFeiDetail();
                                            if (dt.Columns.Contains("yazhuquexian_gaodiyadiaoji"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_gaodiyadiaoji"].ToString(), out tempNum);
                                                daShaModel.gaodiyatiaoji = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                                daShaModel.feijiagongaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                daShaModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                                daShaModel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_qipi"].ToString(), out tempNum);
                                                daShaModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_youwufahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_youwufahei"].ToString(), out tempNum);
                                                daShaModel.youwufahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_cuoshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_cuoshang"].ToString(), out tempNum);
                                                daShaModel.cuoshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                                daShaModel.shangzhouchengjushang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                daShaModel.chongshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                                daShaModel.bengliao = tempNum;
                                            }
                                            model.yazhuquexian = daShaModel.gaodiyatiaoji + daShaModel.feijiagongaokeng + daShaModel.liewen + daShaModel.nianmo + daShaModel.qipi + daShaModel.youwufahei + daShaModel.cuoshang + daShaModel.shangzhouchengjushang + daShaModel.chongshang + daShaModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                daShaModel.penghuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                                daShaModel.hmianhuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                daShaModel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_ladepin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_ladepin"].ToString(), out tempNum);
                                                daShaModel.luodipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                daShaModel.qita = tempNum;
                                            }
                                            model.cuopifengquexian = daShaModel.penghuashang + daShaModel.hmianhuashang + daShaModel.xiankawai + daShaModel.luodipin;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                daShaModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = daShaModel.chouyangshu;
                                            daShaModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["waiguanquexian_gonghao"]);
                                            daShaModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            daShaModel.dashaType = 2;
                                            daShaBll2.Add(daShaModel);
                                            model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 3:
                                            #region piFengBaoFeiDetail
                                            piFengBaoFeiDetailBLL piFengBll = new BLL.piFengBaoFeiDetailBLL();
                                            piFengBaoFeiDetail piFengModel = new Model.piFengBaoFeiDetail();
                                            if (dt.Columns.Contains("yazhuquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lamo"].ToString(), out tempNum);
                                                piFengModel.lamo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                                piFengModel.feijiagongaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                piFengModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                                piFengModel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_qipi"].ToString(), out tempNum);
                                                piFengModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_youwufahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_youwufahei"].ToString(), out tempNum);
                                                piFengModel.youwufahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_lengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lengliao"].ToString(), out tempNum);
                                                piFengModel.lengliao = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_cuoshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_cuoshang"].ToString(), out tempNum);
                                                piFengModel.cuoshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                                piFengModel.shangzhouchengjushang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                piFengModel.chongshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                                piFengModel.bengliao = tempNum;
                                            }
                                            model.yazhuquexian = piFengModel.lamo + piFengModel.feijiagongaokeng + piFengModel.liewen + piFengModel.nianmo + piFengModel.qipi + piFengModel.youwufahei + piFengModel.lengliao + piFengModel.cuoshang + piFengModel.shangzhouchengjushang + piFengModel.chongshang + piFengModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                piFengModel.penghuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                                piFengModel.hmianhuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianbianxing"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianbianxing"].ToString(), out tempNum);
                                                piFengModel.hmianbianxing = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_yashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_yashang"].ToString(), out tempNum);
                                                piFengModel.yashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                piFengModel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_dashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_dashang"].ToString(), out tempNum);
                                                piFengModel.abbdashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_ladepin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_ladepin"].ToString(), out tempNum);
                                                piFengModel.luodipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                piFengModel.qita = tempNum;
                                            }
                                            model.cuopifengquexian = piFengModel.penghuashang + piFengModel.hmianhuashang + piFengModel.hmianbianxing + piFengModel.yashang + piFengModel.xiankawai + piFengModel.abbdashang + piFengModel.luodipin + piFengModel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                piFengModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = piFengModel.chouyangshu;
                                            piFengModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            piFengModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            piFengBll.Add(piFengModel);
                                            model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                        case 4:
                                            #region MyRegion
                                            PiFengHBaiFeiDetailBLL piFengHBll = new BLL.PiFengHBaiFeiDetailBLL();
                                            PiFengHBaiFeiDetail piFengHModel = new Model.PiFengHBaiFeiDetail();
                                            if (dt.Columns.Contains("yazhuquexian_shayan"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_shayan"].ToString(), out tempNum);
                                                piFengHModel.shayan = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lamo"].ToString(), out tempNum);
                                                piFengHModel.lamo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                                piFengHModel.feijiagongmianaokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                piFengHModel.liewen = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                                piFengHModel.nianmo = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_qipi"].ToString(), out tempNum);
                                                piFengHModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_youwufahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_youwufahei"].ToString(), out tempNum);
                                                piFengHModel.youwufahei = tempNum;
                                            }
                                            if (dt.Columns.Contains("yazhuquexian_lengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lengliao"].ToString(), out tempNum);
                                                piFengHModel.lengliao = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_cuoshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_cuoshang"].ToString(), out tempNum);
                                                piFengHModel.cuoshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                                piFengHModel.shangzhouchengjushang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                piFengHModel.chongshang = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                                piFengHModel.bengliao = tempNum;
                                            }
                                            model.yazhuquexian = piFengHModel.shayan + piFengHModel.lamo + piFengHModel.feijiagongmianaokeng + piFengHModel.liewen + piFengHModel.nianmo + piFengHModel.qipi + piFengHModel.youwufahei + piFengHModel.lengliao + piFengHModel.cuoshang + piFengHModel.shangzhouchengjushang + piFengHModel.chongshang + piFengHModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                piFengHModel.penghuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                                piFengHModel.hmianhuashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_mianbianxing"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_mianbianxing"].ToString(), out tempNum);
                                                piFengHModel.hmianbianxing = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jiaobianxing"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jiaobianxing"].ToString(), out tempNum);
                                                piFengHModel.rjiaobianxing = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_yashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_yashang"].ToString(), out tempNum);
                                                piFengHModel.yashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                piFengHModel.xiankawai = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_dashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_dashang"].ToString(), out tempNum);
                                                piFengHModel.assdashang = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_ladepin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_ladepin"].ToString(), out tempNum);
                                                piFengHModel.luodipin = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_gubao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_gubao"].ToString(), out tempNum);
                                                piFengHModel.gubao = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_aokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_aokeng"].ToString(), out tempNum);
                                                piFengHModel.aokeng = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_cucaodugao"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_cucaodugao"].ToString(), out tempNum);
                                                piFengHModel.cuzaodugao = tempNum;
                                            }
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                piFengHModel.qita = tempNum;
                                            }
                                            model.cuopifengquexian = piFengHModel.penghuashang + piFengHModel.hmianhuashang + piFengHModel.hmianbianxing + piFengHModel.rjiaobianxing + piFengHModel.yashang + piFengHModel.xiankawai + piFengHModel.assdashang + piFengHModel.luodipin + piFengHModel.gubao + piFengHModel.aokeng + piFengHModel.cuzaodugao + piFengHModel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                piFengHModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = piFengHModel.chouyangshu;
                                            piFengHModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            piFengHModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            piFengHBll.Add(piFengHModel);
                                            model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #endregion
                                            break;
                                    }
                                    if (!Convert.IsDBNull(dt.Rows[i]["riji"]) && dt.Rows[i]["riji"].ToString().Trim() != "")
                                    {
                                        tiemTemp = Convert.ToDateTime(dt.Rows[i]["riji"]);
                                    }
                                    model.time = tiemTemp;   //日期
                                    if (dt.Columns.Contains("yazhujitaihao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["yazhujitaihao"]) && dt.Rows[i]["yazhujitaihao"].ToString().Trim() != "")
                                        {
                                            yazhujitaihao = Convert.ToString(dt.Rows[i]["yazhujitaihao"]);
                                        }
                                    }

                                    model.yazhujihao = yazhujitaihao; //机台线号
                                    model.maopeihao = Convert.ToString(dt.Rows[i]["maopihao"]); //产品型号
                                    model.muhao = Convert.ToString(dt.Rows[i]["mohao"]);   //模号
                                    model.liuchengpiaobianhao = Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                    model.banci = Convert.ToString(dt.Rows[i]["banci"]);   //班次
                                    if (dt.Columns.Contains("jihuashengchanshu"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["jihuashengchanshu"].ToString(), out tempNum);
                                        model.jihuashengchanshu = tempNum;
                                    }
                                    if (dt.Columns.Contains("jishuqishuzhi"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["jishuqishuzhi"].ToString(), out tempNum);
                                        model.jishuqishu = tempNum;
                                    }
                                    if (dt.Columns.Contains("gonghao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["gonghao"]) && dt.Rows[i]["gonghao"].ToString().Trim() != "")
                                        {
                                            gonghao = Convert.ToString(dt.Rows[i]["gonghao"]);
                                        }
                                    }
                                    model.gonghao = gonghao;
                                    model.workshoptype = type;

                                    //返修明细
                                    fanxiuDetail fanxiuModel = new fanxiuDetail();
                                    fanxiuDetailBLL fanxiuBll = new fanxiuDetailBLL();
                                    if (dt.Columns.Contains("bengliao"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["bengliao"].ToString(), out tempNum);
                                        fanxiuModel.bengliao = tempNum;
                                    }
                                    if (dt.Columns.Contains("fanpen"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["fanpen"].ToString(), out tempNum);
                                        fanxiuModel.fanpen = tempNum;
                                    }
                                    if (dt.Columns.Contains("zhengxing"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["zhengxing"].ToString(), out tempNum);
                                        fanxiuModel.zhengxing = tempNum;
                                    }
                                    fanxiuShu = fanxiuModel.bengliao + fanxiuModel.fanpen + fanxiuModel.zhengxing;
                                    fanxiuModel.benzhu = Convert.IsDBNull(dt.Rows[i]["beizhu"]) ? "" : Convert.ToString(dt.Rows[i]["beizhu"]);  //备注
                                    fanxiuModel.liuchengpiaohao = model.liuchengpiaobianhao;
                                    fanxiuBll.Add(fanxiuModel);
                                    if (shenChanShu != 0)
                                    {
                                        model.fanxiulv = decimal.Round(decimal.Parse((fanxiuShu / shenChanShu).ToString()), 2);  //报废率
                                    }
                                    else
                                    {
                                        model.fanxiulv = 0;  //返修率
                                    }
                                    model.shengchanzongshu = shenChanShu;
                                    model.isdel = 0;
                                    model.gongxu = dt.Columns.Contains("gongxu") ? (Convert.IsDBNull(dt.Rows[i]["gongxu"]) ? "" : Convert.ToString(dt.Rows[i]["gongxu"])) : "";  //工序  不是共同有的字段

                                    commonWorkShopRecordBLL.Add(model);
                                }
                                #endregion
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
                    btnClearData.Text = "清理over!";
                }
            }
            else
            {
                AuthenticationDelegate myDelegate = new AuthenticationDelegate(PassAuthentication);
                this.Invoke(myDelegate, new object[] { value });
            }

        }
        private void txtFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}