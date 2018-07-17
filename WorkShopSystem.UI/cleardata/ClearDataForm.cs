using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            btnOpen.Enabled = true;
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
                            data = new DataTable();
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
            btnClearData.Enabled = true;
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
            btnOpen.Enabled = false;
            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.IsBackground = false;
            //fThread.Start();
            //cmd.ShowOpaqueLayer(panel1, 125, true);
            if (btnClearData.Text == "数据入库")
            {
                btnClearData.Enabled = false;
                btnClearData.Text = "入库中，请勿停止或者关闭！";
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

                //创建数据库
                using (SqlConnection connection = new SqlConnection(SqlHelper.connstr))
                {
                    string command0 = "select count(*) from sysobjects where xtype='U' and name='CommonWorkShopRecord'";

                    SqlCommand sqlCommand = new SqlCommand(command0, connection);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    int count = (int)sqlCommand.ExecuteScalar();
                    if (count != 1)
                    {
                        string command1 = "CREATE TABLE CommonWorkShopRecord([time] [datetime] NULL,[yazhujihao] [nvarchar](50) NULL,[maopeihao] [nvarchar](50)  NULL,[muhao] [nvarchar](50) NULL,[liuchengpiaobianhao] [nvarchar](50) NULL,[banci] [nvarchar](50) NULL,[jihuashengchanshu] [DECIMAL](30) NULL,[shengchanzongshu] [DECIMAL](30) NULL,[jishuqishu] [DECIMAL](30) NULL,[baofeizongshu] [DECIMAL](30) NULL,[baofeilv] [DECIMAL](30) NULL,[fanxiuzongshu] [DECIMAL](30) NULL,[fanxiulv] [DECIMAL](30) NULL,[xianhao] [nvarchar](50) NULL,[gongxu] [nvarchar](50) NULL,[workshoptype] [DECIMAL](30) NULL,[gonghao] [nvarchar](50) NULL,[isdel] [DECIMAL](30) NULL,[yazhuquexian] [DECIMAL](30) NULL,[cuopifengquexian] [DECIMAL](30) NULL,[pinjianquexian] [DECIMAL](30) NULL,[jijiaquexian] [DECIMAL](30) NULL) ON [PRIMARY]";
                        string command4 = "CREATE NONCLUSTERED INDEX [time_index] ON CommonWorkShopRecord([Time] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
                        string command2 = "CREATE TABLE JiJiaQueXianDetail([time] [datetime] NULL,[cnctiaojipin] [DECIMAL] (30) NULL,[falanmianyashang] [DECIMAL](30) NULL,[falanmianhuahenpengshang] [DECIMAL](30) NULL,[hmianyashang] [DECIMAL](30) NULL,[jinqikoukepeng] [DECIMAL](30) NULL,[shangzhouchengkongkepeng] [DECIMAL](30) NULL,[daowen] [DECIMAL](30) NULL,[kongjingchaocha] [DECIMAL](30) NULL,[shuiyin] [DECIMAL](30) NULL,[zangwu] [DECIMAL](30) NULL,[jiagongbuliang] [DECIMAL](30) NULL,[shakong] [DECIMAL](30) NULL,[liewen] [DECIMAL](30) NULL,[bengque] [DECIMAL](30) NULL,[feihua] [DECIMAL](30) NULL,[feipeng] [DECIMAL](30) NULL,[qipi] [DECIMAL](30) NULL,[zazhi] [DECIMAL](30) NULL,[nianmo] [DECIMAL](30) NULL,[maopeifamei] [DECIMAL](30) NULL,[yanghuafahei] [DECIMAL](30) NULL,[luodi] [DECIMAL](30) NULL,[qita] [DECIMAL](30) NULL,[lamo] [DECIMAL](30) NULL,[xiankawai] [DECIMAL](30) NULL,[chouyangshu] [DECIMAL](30) NULL,[gonghao] [nvarchar](30) NULL,[feijiagongmianaokeng] [DECIMAL](30) NULL,[lvxue] [DECIMAL](30) NULL,[type] [DECIMAL](30) NULL,[liuchengpiaobianhao] [nvarchar](30) NULL) ON [PRIMARY]";
                        string command5 = "CREATE NONCLUSTERED INDEX [liuchengpiaobianhao_index] ON JiJiaQueXianDetail([liuchengpiaobianhao] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
                        string command3 = "CREATE TABLE FanXiuDetail([time] [datetime] NULL,[bengliao] [DECIMAL] (30) NULL,[fanpen] [DECIMAL](30) NULL,[zhengxing] [DECIMAL](30) NULL,[beizhu] [nvarchar](50) NULL,[jinqikoukepeng] [DECIMAL](30) NULL,[falanmianhuashang] [DECIMAL](30) NULL,[pensha] [DECIMAL](30) NULL,[kefanxipin] [DECIMAL](30) NULL,[kefanfamei] [DECIMAL](30) NULL,[xiaoshakongkefanxiu] [DECIMAL](30) NULL,[louqi] [DECIMAL](30) NULL,[liuchengpiaobianhao] [nvarchar](30) NULL) ON [PRIMARY]";
                        string command6 = "CREATE NONCLUSTERED INDEX [liuchengpiaobianhao_index] ON FanXiuDetail([liuchengpiaobianhao] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
                        string command7 = "CREATE TABLE YaZhuQueXianDetail([time] [datetime] NULL,[gaodiya] [DECIMAL] (30) NULL,[lamo] [DECIMAL](30) NULL,[nianmo] [DECIMAL](30) NULL,[kaweichaocha] [DECIMAL](30) NULL,[liewen] [DECIMAL](30) NULL,[guilie] [DECIMAL](30) NULL,[lengliao] [DECIMAL](30) NULL,[youwufahei] [DECIMAL](30) NULL,[duanzhen] [DECIMAL](30) NULL,[qipi] [DECIMAL](30) NULL,[jushang] [DECIMAL](30) NULL,[yadianshang] [DECIMAL](30) NULL,[chongshang] [DECIMAL](30) NULL,[bengqueliao] [DECIMAL](30) NULL,[penghuashang] [DECIMAL](30) NULL,[Hmianhuashang] [DECIMAL](30) NULL,[xiankawai] [DECIMAL](30) NULL,[luodipin] [DECIMAL](30) NULL,[gubao] [DECIMAL](30) NULL,[jitan] [DECIMAL](30) NULL,[shuikouduan] [DECIMAL](30) NULL,[aokeng] [DECIMAL](30) NULL,[qita] [DECIMAL](30) NULL,[cuoshang] [DECIMAL](30) NULL,[cuodaohen] [DECIMAL](30) NULL,[abbdashang] [DECIMAL](30) NULL,[assqiexue] [nvarchar](30) NULL,[qupifengqita] [DECIMAL](30) NULL,[type] [DECIMAL](30) NULL,[liuchengpiaobianhao] [nvarchar](30) NULL,[chouyangshu] [DECIMAL](30) NULL,[gonghao] [nvarchar](30) NULL) ON [PRIMARY]";
                        string command8 = "CREATE NONCLUSTERED INDEX [liuchengpiaobianhao_index] ON YaZhuQueXianDetail([liuchengpiaobianhao] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
                        SqlTransaction trans = null;
                        try
                        {
                            if (connection.State != ConnectionState.Open)
                                connection.Open();
                            trans = connection.BeginTransaction();
                            SqlCommand sqlCommand1 = new SqlCommand(command1, connection);
                            sqlCommand1.Transaction = trans;
                            SqlCommand sqlCommand2 = new SqlCommand(command2, connection);
                            sqlCommand2.Transaction = trans;
                            SqlCommand sqlCommand3 = new SqlCommand(command3, connection);
                            sqlCommand3.Transaction = trans;
                            SqlCommand sqlCommand4 = new SqlCommand(command4, connection);
                            sqlCommand4.Transaction = trans;
                            SqlCommand sqlCommand5 = new SqlCommand(command5, connection);
                            sqlCommand5.Transaction = trans;
                            SqlCommand sqlCommand6 = new SqlCommand(command6, connection);
                            sqlCommand6.Transaction = trans;
                            SqlCommand sqlCommand7 = new SqlCommand(command7, connection);
                            sqlCommand7.Transaction = trans;
                            SqlCommand sqlCommand8 = new SqlCommand(command8, connection);
                            sqlCommand8.Transaction = trans;
                            sqlCommand1.ExecuteNonQuery();
                            sqlCommand2.ExecuteNonQuery();
                            sqlCommand3.ExecuteNonQuery();
                            sqlCommand4.ExecuteNonQuery();
                            sqlCommand5.ExecuteNonQuery();
                            sqlCommand6.ExecuteNonQuery();
                            sqlCommand7.ExecuteNonQuery();
                            sqlCommand8.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (SqlException sqe)
                        {
                            Console.WriteLine(sqe.Message);
                            if (trans != null)
                                trans.Rollback();
                        }
                    }
                }
                //查询数据
                PassAuthentication(true);
                //根据文件的路径的名字判断数据类型
                dicTables = ExcelToDataTable(fileName, null, false);//获取到excel的所有sheet 
                #region 机加
                if (fileName.Contains("机加"))
                {
                    //循环dt入库

                    CommonWorkShopRecordBLL commonWorkShopRecordBLL = new CommonWorkShopRecordBLL();
                    DateTime tiemTemp = new DateTime();
                    if (dicTables != null && dicTables.Count > 0)
                    {
                        int type = -1;
                        string sheetName = string.Empty;
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
                                string yazhujitaihao = string.Empty;
                                string jihuashu = string.Empty;
                                string jishuqishuzhi = string.Empty;
                                string gonghao = string.Empty;
                                decimal tempNum = 0;
                                #region MyRegion
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    decimal? shenChanShu = 0;
                                    if (dt.Columns.Contains("shideshengchanshu"))
                                    {
                                        decimal.TryParse(dt.Rows[i]["shideshengchanshu"].ToString(), out tempNum);
                                        model.shengchanzongshu = tempNum;
                                    }
                                    shenChanShu = model.shengchanzongshu;
                                    BLL.JiJiaQueXianDetailBLL quanJianBll = new BLL.JiJiaQueXianDetailBLL();
                                    Model.JiJiaQueXianDetail quanJianModel = new Model.JiJiaQueXianDetail();
                                    switch (item.Key)
                                    {
                                        case "拉线统计":
                                            #region 机加车间拉线统计
                                            model.workshoptype = 8;
                                            quanJianModel = new Model.JiJiaQueXianDetail();
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
                                            if (dt.Columns.Contains("jiagongqingxiquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            if (dt.Columns.Contains("jiagongqingxiquexian_feijiagongmiankepengshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_feijiagongmiankepengshang"].ToString(), out tempNum);
                                                quanJianModel.feijiagongmianaokeng = tempNum;
                                            }
                                            model.jijiaquexian = quanJianModel.cnctiaojipin + quanJianModel.falanmianyashang + quanJianModel.falanmianhuahenpengshang + quanJianModel.hmianyashang + quanJianModel.jinqikoukepeng + quanJianModel.shangzhouchengkongkepeng + quanJianModel.daowen + quanJianModel.kongjingchaocha + quanJianModel.shuiyin + quanJianModel.luodi + quanJianModel.feijiagongmianaokeng;
                                            //以上是jijiaquexian对应的是加工清洗缺陷
                                            if (dt.Columns.Contains("maopiquexian_zangwu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_zangwu"].ToString(), out tempNum);
                                                quanJianModel.zangwu = tempNum;
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
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                quanJianModel.qita = tempNum;
                                            }

                                            model.yazhuquexian = quanJianModel.zangwu + quanJianModel.lamo + quanJianModel.xiankawai + quanJianModel.jiagongbuliang + quanJianModel.shakong + quanJianModel.liewen + quanJianModel.bengque + quanJianModel.qipi + quanJianModel.zazhi + quanJianModel.nianmo + quanJianModel.maopeifamei + quanJianModel.yanghuafahei + quanJianModel.qita;
                                            //yazhuquexian对应的是毛坯缺陷
                                            if (dt.Columns.Contains("jitalei_louqi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_louqi"].ToString(), out tempNum);
                                                quanJianModel.qipi = tempNum;
                                            }
                                            if (dt.Columns.Contains("jitalei_lvxie"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_lvxie"].ToString(), out tempNum);
                                                quanJianModel.lvxue = tempNum;
                                            }
                                            model.cuopifengquexian = quanJianModel.qipi + quanJianModel.lvxue;
                                            //cuopifengquexian以上对应的是其他类
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                quanJianModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            if (dt.Columns.Contains("pinjian_gonghao"))
                                            {
                                                quanJianModel.gonghao = dt.Rows[i]["pinjian_gonghao"].ToString();
                                            }
                                            if (dt.Columns.Contains("liuchengpiaobianhao"))
                                            {
                                                quanJianModel.liuchengpiaobianhao = dt.Rows[i]["liuchengpiaobianhao"].ToString();
                                            }
                                            quanJianModel.type = 4;
                                            //以上是品检缺陷=抽样数
                                            quanJianModel.time = DateTime.Now;
                                            quanJianBll.Add(quanJianModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            //model.baofeizongshu = model.jijiaquexian + model.yazhuquexian + model.pinjianquexian; //报废总数
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
                                        case "清洗线统计"://车间清洗
                                            #region 清洗统计
                                            model.workshoptype = 6;
                                            quanJianModel = new Model.JiJiaQueXianDetail();
                                            quanJianModel.time = DateTime.Now;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_lade"].ToString(), out tempNum);
                                                quanJianModel.luodi = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_queliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_queliao"].ToString(), out tempNum);
                                            //    quanJianModel.qita = tempNum;
                                            //}
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                quanJianModel.chouyangshu = tempNum;
                                            }
                                            if (dt.Columns.Contains("pinjian_gonghao"))
                                            {
                                                quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            }
                                            model.jijiaquexian = quanJianModel.luodi;
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            if (dt.Columns.Contains("liuchengpiaobianhao"))
                                            {
                                                quanJianModel.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);
                                            }
                                            quanJianModel.type = 2;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            //model.baofeizongshu = model.jijiaquexian + model.pinjianquexian; //报废总数
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
                                        case "CNC统计":
                                            #region CNC统计
                                            model.workshoptype = 5;
                                            quanJianModel = new Model.JiJiaQueXianDetail();
                                            quanJianModel.time = DateTime.Now;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_diaojipin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_diaojipin"].ToString(), out tempNum);
                                            }
                                            quanJianModel.cnctiaojipin = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianyashang"].ToString(), out tempNum);
                                            }
                                            quanJianModel.falanmianyashang = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_falanmianhuahenpengshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_falanmianhuahenpengshang"].ToString(), out tempNum);
                                            }
                                            quanJianModel.falanmianhuahenpengshang = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_mianyashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_mianyashang"].ToString(), out tempNum);
                                            }
                                            quanJianModel.hmianyashang = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_jinqikoukepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_jinqikoukepeng"].ToString(), out tempNum);
                                            }
                                            quanJianModel.jinqikoukepeng = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shangzhouchengkongkepeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shangzhouchengkongkepeng"].ToString(), out tempNum);
                                            }
                                            quanJianModel.shangzhouchengkongkepeng = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_daowen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_daowen"].ToString(), out tempNum);
                                            }
                                            quanJianModel.daowen = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_kongjingchaocha"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_kongjingchaocha"].ToString(), out tempNum);
                                            }
                                            quanJianModel.kongjingchaocha = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_shuiyin"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_shuiyin"].ToString(), out tempNum);
                                            }
                                            quanJianModel.shuiyin = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_lade"].ToString(), out tempNum);
                                            }
                                            quanJianModel.luodi = tempNum;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_feijiagongmianaokeng"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            }
                                            quanJianModel.feijiagongmianaokeng = tempNum;
                                            model.jijiaquexian = quanJianModel.cnctiaojipin + quanJianModel.falanmianyashang + quanJianModel.falanmianhuahenpengshang + quanJianModel.hmianyashang + quanJianModel.jinqikoukepeng + quanJianModel.shangzhouchengkongkepeng + quanJianModel.daowen + quanJianModel.kongjingchaocha + quanJianModel.shuiyin + quanJianModel.luodi + quanJianModel.feijiagongmianaokeng;
                                            //以上是jijiaquexian对应的是加工清洗缺陷
                                            if (dt.Columns.Contains("maopiquexian_zangwu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_zangwu"].ToString(), out tempNum);
                                            }
                                            quanJianModel.zangwu = tempNum;
                                            if (dt.Columns.Contains("waiguanquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_lamo"].ToString(), out tempNum);
                                            }
                                            quanJianModel.lamo = tempNum;
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                            }
                                            quanJianModel.xiankawai = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_jiagongbuliang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_jiagongbuliang"].ToString(), out tempNum);
                                            }
                                            quanJianModel.jiagongbuliang = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_shakong"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_shakong"].ToString(), out tempNum);
                                            }
                                            quanJianModel.shakong = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_liewen"].ToString(), out tempNum);
                                            }
                                            quanJianModel.liewen = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_bengque"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_bengque"].ToString(), out tempNum);
                                            }
                                            quanJianModel.bengque = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_qipi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_qipi"].ToString(), out tempNum);
                                            }
                                            quanJianModel.qipi = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_zazhi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_zazhi"].ToString(), out tempNum);
                                            }
                                            quanJianModel.zazhi = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_nianmo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_nianmo"].ToString(), out tempNum);
                                            }
                                            quanJianModel.nianmo = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_maopifamei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_maopifamei"].ToString(), out tempNum);
                                            }
                                            quanJianModel.maopeifamei = tempNum;
                                            if (dt.Columns.Contains("maopiquexian_yanghuafahei"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["maopiquexian_yanghuafahei"].ToString(), out tempNum);
                                            }
                                            quanJianModel.yanghuafahei = tempNum;
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                            }
                                            quanJianModel.qita = tempNum;
                                            model.yazhuquexian = quanJianModel.zangwu + quanJianModel.lamo + quanJianModel.xiankawai + quanJianModel.jiagongbuliang + quanJianModel.shakong + quanJianModel.liewen + quanJianModel.bengque + quanJianModel.qipi + quanJianModel.zazhi + quanJianModel.nianmo + quanJianModel.maopeifamei + quanJianModel.yanghuafahei + quanJianModel.qita;
                                            //yazhuquexian对应的是毛坯缺陷
                                            if (dt.Columns.Contains("jitalei_louqi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_louqi"].ToString(), out tempNum);
                                            }
                                            quanJianModel.qipi = tempNum;
                                            if (dt.Columns.Contains("jitalei_lvxie"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_lvxie"].ToString(), out tempNum);
                                            }
                                            quanJianModel.lvxue = tempNum;
                                            model.cuopifengquexian = quanJianModel.qipi + quanJianModel.lvxue;
                                            //cuopifengquexian以上对应的是其他类
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                            }
                                            quanJianModel.chouyangshu = tempNum;
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            if (dt.Columns.Contains("pinjian_gonghao"))
                                            {
                                                quanJianModel.gonghao = dt.Rows[i]["pinjian_gonghao"].ToString();
                                            }
                                            if (dt.Columns.Contains("liuchengpiaobianhao"))
                                            {
                                                quanJianModel.liuchengpiaobianhao = Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            }
                                            quanJianModel.type = 1;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                            }
                                            model.baofeizongshu = tempNum;
                                            //model.baofeizongshu = model.jijiaquexian + model.yazhuquexian + model.pinjianquexian; //报废总数
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
                                        case "测漏统计":
                                            #region 测漏统计
                                            model.workshoptype = 7;
                                            quanJianModel = new Model.JiJiaQueXianDetail();
                                            quanJianModel.time = DateTime.Now;
                                            if (dt.Columns.Contains("jiagongqingxiquexian_lade"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongqingxiquexian_lade"].ToString(), out tempNum);
                                            }
                                            quanJianModel.luodi = tempNum;
                                            if (dt.Columns.Contains("jitalei_louqi"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_louqi"].ToString(), out tempNum);
                                            }
                                            quanJianModel.qipi = tempNum;
                                            if (dt.Columns.Contains("jitalei_lvxie"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jitalei_lvxie"].ToString(), out tempNum);
                                            }
                                            quanJianModel.lvxue = tempNum;
                                            model.cuopifengquexian = quanJianModel.qipi + quanJianModel.lvxue;
                                            //if (dt.Columns.Contains("waiguanquexian_queliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_queliao"].ToString(), out tempNum);
                                            //    quanJianModel.qita = tempNum;
                                            //}
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                            }
                                            quanJianModel.chouyangshu = tempNum;
                                            if (dt.Columns.Contains("pinjian_gonghao"))
                                            {
                                                quanJianModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            }
                                            model.jijiaquexian = quanJianModel.luodi;
                                            model.pinjianquexian = quanJianModel.chouyangshu;
                                            if (dt.Columns.Contains("liuchengpiaobianhao"))
                                            {
                                                quanJianModel.liuchengpiaobianhao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);
                                            }
                                            quanJianModel.type = 3;
                                            //以上是品检缺陷=抽样数
                                            quanJianBll.Add(quanJianModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                            }
                                            model.baofeizongshu = tempNum;
                                            //model.baofeizongshu = model.jijiaquexian + model.pinjianquexian; //报废总数
                                            if (shenChanShu != 0)
                                            {
                                                model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / shenChanShu).ToString()), 4);  //报废率
                                            }
                                            else
                                            {
                                                model.baofeilv = 0;  //报废率
                                            }
                                            #region 注释
                                            //quanJianModel = new Model.JiJiaQueXianDetail();
                                            //model.workshoptype = 7;
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_shengchanshu"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_shengchanshu"].ToString(), out tempNum);
                                            //    model.shengchanzongshu = tempNum;
                                            //}

                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_riji") && dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"].ToString().Trim() != "")
                                            //{
                                            //    if (!Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"]))
                                            //    {
                                            //        DateTime.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_riji"].ToString(), out tiemTemp);
                                            //    }
                                            //}
                                            //model.time = tiemTemp;
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_jitaixianhao") && dt.Rows[i]["nianjijiachejianshengchanjilubiao_jitaixianhao"].ToString().Trim() != "")
                                            //{
                                            //    if (!Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jitaixianhao"]))
                                            //    {
                                            //        yazhujitaihao = Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jitaixianhao"]);
                                            //    }
                                            //}
                                            //model.yazhujihao = yazhujitaihao;
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_gonghao") && dt.Rows[i]["nianjijiachejianshengchanjilubiao_gonghao"].ToString().Trim() != "")
                                            //{
                                            //    if (!Convert.IsDBNull(dt.Rows[i]["nianjijiachejianshengchanjilubiao_gonghao"]))
                                            //    {
                                            //        gonghao = Convert.ToString(dt.Rows[i]["nianjijiachejianshengchanjilubiao_gonghao"]);
                                            //    }
                                            //}
                                            //model.gonghao = gonghao;

                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_maopihao"))
                                            //{
                                            //    model.maopeihao = dt.Rows[i]["nianjijiachejianshengchanjilubiao_maopihao"].ToString();
                                            //    if (model.maopeihao.Contains("-"))//包含"-"的时候去掉
                                            //    {
                                            //        string[] strs = model.maopeihao.Split('-');
                                            //        model.maopeihao = strs[0] + strs[1];
                                            //    }
                                            //    else if (model.maopeihao.Length >= 4)//长度大于等于4
                                            //    {
                                            //        model.maopeihao = model.maopeihao.Substring(0, 1) + model.maopeihao.Substring(model.maopeihao.Length - 3);
                                            //    }
                                            //}
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_mohao"))
                                            //{
                                            //    model.muhao = dt.Rows[i]["nianjijiachejianshengchanjilubiao_mohao"].ToString();
                                            //}
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_liuchengpiaobianhao"))
                                            //{
                                            //    model.liuchengpiaobianhao = dt.Rows[i]["nianjijiachejianshengchanjilubiao_liuchengpiaobianhao"].ToString();
                                            //}
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_banci"))
                                            //{
                                            //    model.banci = dt.Rows[i]["nianjijiachejianshengchanjilubiao_banci"].ToString();
                                            //}

                                            ////if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_falanmianhuahenpengshang"))
                                            ////{
                                            ////    decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_falanmianhuahenpengshang"].ToString(), out tempNum);
                                            ////    quanJianModel.falanmianhuahenpengshang = tempNum;
                                            ////}
                                            ////if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_shangzhouchengkongkepeng"))
                                            ////{
                                            ////    decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_shangzhouchengkongkepeng"].ToString(), out tempNum);
                                            ////    quanJianModel.shangzhouchengkongkepeng = tempNum;
                                            ////}
                                            ////if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_jiagongbuliang"))
                                            ////{
                                            ////    decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_jiagongbuliang"].ToString(), out tempNum);
                                            ////    quanJianModel.jiagongbuliang = tempNum;
                                            ////}
                                            //if (dt.Columns.Contains("jiagongqixingquexian_lade"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongqixingquexian_lade"].ToString(), out tempNum);
                                            //    quanJianModel.luodi = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("jitalei_louqi"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jitalei_louqi"].ToString(), out tempNum);
                                            //    quanJianModel.qipi = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("jitalei_lvxie"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jitalei_lvxie"].ToString(), out tempNum);
                                            //    quanJianModel.lvxue = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                            //    quanJianModel.chouyangshu = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("pinjian_gonghao"))
                                            //{
                                            //    model.gonghao = dt.Rows[i]["pinjian_gonghao"].ToString();
                                            //}
                                            //quanJianModel.type = 3;
                                            //quanJianModel.liuchengpiaobianhao = model.liuchengpiaobianhao;
                                            //model.jijiaquexian = quanJianModel.luodi;
                                            //model.cuopifengquexian = quanJianModel.qipi + quanJianModel.lvxue;
                                            //quanJianBll.Add(quanJianModel);
                                            //if (dt.Columns.Contains("nianjijiachejianshengchanjilubiao_baofeizongshu"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["nianjijiachejianshengchanjilubiao_baofeizongshu"].ToString(), out tempNum);
                                            //    model.baofeizongshu = tempNum;
                                            //}
                                            ////model.baofeizongshu = model.jijiaquexian; //报废总数
                                            //if (model.shengchanzongshu != 0)
                                            //{
                                            //    model.baofeilv = decimal.Round(decimal.Parse((model.baofeizongshu / model.shengchanzongshu).ToString()), 4);  //报废率
                                            //}
                                            //else
                                            //{
                                            //    model.baofeilv = 0;  //报废率
                                            //}
                                            //model.isdel = 0;
                                            //commonWorkShopRecordBLL.Add(model); 
                                            #endregion
                                            #endregion
                                            break;
                                    }
                                    if (type != 5)
                                    #region MyRegion
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["riji"]) && dt.Rows[i]["riji"].ToString().Trim() != "")
                                        {
                                            DateTime.TryParse(dt.Rows[i]["riji"].ToString(), out tiemTemp);
                                        }
                                        model.time = tiemTemp;   //日期
                                        if (dt.Columns.Contains("jitaixianhao") && dt.Rows[i]["jitaixianhao"].ToString().Trim() != "")
                                        {
                                            yazhujitaihao = Convert.ToString(dt.Rows[i]["jitaixianhao"]);
                                        }
                                        model.yazhujihao = yazhujitaihao; //机台线号
                                        model.xianhao = yazhujitaihao;
                                        if (dt.Columns.Contains("xianhao"))
                                        {
                                            model.xianhao = Convert.ToString(dt.Rows[i]["xianhao"]);
                                        }
                                        model.maopeihao = Convert.ToString(dt.Rows[i]["chanpinxinghao"]); //产品型号
                                        if (model.maopeihao.Contains("-"))//包含"-"的时候去掉
                                        {
                                            string[] strs = model.maopeihao.Split('-');
                                            model.maopeihao = strs[0] + strs[1];
                                        }
                                        else if (model.maopeihao.Length >= 4)//长度大于5并且f开头
                                        {
                                            model.maopeihao = model.maopeihao.Substring(0, 1) + model.maopeihao.Substring(model.maopeihao.Length - 3);
                                        }
                                        if (dt.Columns.Contains("mohao"))
                                        {
                                            model.muhao = Convert.ToString(dt.Rows[i]["mohao"]);
                                        }
                                        // model.muhao = Convert.ToString(dt.Rows[i]["mohao"]);   //模号
                                        if (dt.Columns.Contains("liuchengpiaobianhao"))
                                        {
                                            model.liuchengpiaobianhao = Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);
                                        }
                                        if (dt.Columns.Contains("banci"))
                                        {
                                            model.banci = Convert.ToString(dt.Rows[i]["banci"]);
                                        }
                                        if (dt.Columns.Contains("jihuashengchanshu"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["jihuashengchanshu"].ToString(), out tempNum);
                                        }
                                        model.jihuashengchanshu = tempNum;
                                        if (dt.Columns.Contains("jishuqishuzhi"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["jishuqishuzhi"].ToString(), out tempNum);
                                        }
                                        model.jishuqishu = tempNum;
                                        if (dt.Columns.Contains("shideshengchanshu"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["shideshengchanshu"].ToString(), out tempNum);
                                        }
                                        model.shengchanzongshu = tempNum;
                                        if (dt.Columns.Contains("gonghao"))
                                        {
                                            if (!Convert.IsDBNull(dt.Rows[i]["gonghao"]) && dt.Rows[i]["gonghao"].ToString().Trim() != "")
                                            {
                                                gonghao = Convert.ToString(dt.Rows[i]["gonghao"]);
                                            }
                                        }
                                        model.gonghao = gonghao;
                                        //返修明细
                                        FanXiuDetail fanxiuModel = new FanXiuDetail();
                                        FanXiuDetailBLL fanxiuBll = new FanXiuDetailBLL();
                                        if (dt.Columns.Contains("bengliao"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["bengliao"].ToString(), out tempNum);
                                        }
                                        fanxiuModel.bengliao = tempNum;
                                        if (dt.Columns.Contains("fanpen"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["fanpen"].ToString(), out tempNum);
                                            fanxiuModel.fanpen = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.fanpen = 0;
                                        }

                                        if (dt.Columns.Contains("zhengxing"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["zhengxing"].ToString(), out tempNum);
                                            fanxiuModel.zhengxing = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.zhengxing = 0;
                                        }
                                        if (dt.Columns.Contains("jinqikoukepeng"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["jinqikoukepeng"].ToString(), out tempNum);
                                            fanxiuModel.jinqikoukepeng = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.jinqikoukepeng = 0;
                                        }
                                        if (dt.Columns.Contains("falanmianhuashang"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["falanmianhuashang"].ToString(), out tempNum);
                                            fanxiuModel.falanmianhuashang = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.falanmianhuashang = 0;
                                        }
                                        if (dt.Columns.Contains("pensha"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["pensha"].ToString(), out tempNum);
                                            fanxiuModel.pensha = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.pensha = 0;
                                        }
                                        if (dt.Columns.Contains("kefanxipin"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["kefanxipin"].ToString(), out tempNum);
                                            fanxiuModel.kefanxipin = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.kefanxipin = 0;
                                        }
                                        if (dt.Columns.Contains("kefanfamei"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["kefanfamei"].ToString(), out tempNum);
                                            fanxiuModel.kefanfamei = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.kefanfamei = 0;
                                        }
                                        if (dt.Columns.Contains("xiaoshakongkefanxiu"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["xiaoshakongkefanxiu"].ToString(), out tempNum);
                                            fanxiuModel.xiaoshakongkefanxiu = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.xiaoshakongkefanxiu = 0;
                                        }
                                        if (dt.Columns.Contains("louqi"))
                                        {
                                            decimal.TryParse(dt.Rows[i]["louqi"].ToString(), out tempNum);
                                            fanxiuModel.louqi = tempNum;
                                        }
                                        else
                                        {
                                            fanxiuModel.louqi = 0;
                                        }
                                        fanxiuModel.beizhu = dt.Columns.Contains("beizhu") ? (Convert.IsDBNull(dt.Rows[i]["beizhu"]) ? "" : Convert.ToString(dt.Rows[i]["beizhu"])) : "";  //备注
                                        model.fanxiuzongshu = fanxiuModel.jinqikoukepeng + fanxiuModel.falanmianhuashang;
                                        fanxiuModel.time = DateTime.Now;
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
                                    #endregion
                                }
                                #endregion
                            }
                        }
                    }
                }
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
                                    switch (item.Key)
                                    {
                                        case "压铸统计"://压铸缺陷
                                            #region 压铸缺陷
                                            YaZhuQueXianDetailBLL yaZhuBll = new BLL.YaZhuQueXianDetailBLL();
                                            YaZhuQueXianDetail yaZhuModel = new Model.YaZhuQueXianDetail();
                                            //if (dt.Columns.Contains("yazhuquexian_diaojipin"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_diaojipin"].ToString(), out tempNum);
                                            //    yaZhuModel.tiaojipin = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            //    yaZhuModel.feijiagongaokeng = tempNum;
                                            //}
                                            if (dt.Columns.Contains("yazhuquexian_liewen"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_liewen"].ToString(), out tempNum);
                                                yaZhuModel.liewen = tempNum;
                                            }
                                            //if (dt.Columns.Contains("yazhuquexian_nianmo"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_nianmo"].ToString(), out tempNum);
                                            //    yaZhuModel.nainmo = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                            //    yaZhuModel.shangzhouchengjushang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                yaZhuModel.chongshang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                            //    yaZhuModel.bengliao = tempNum;
                                            //}
                                            //model.yazhuquexian = yaZhuModel.tiaojipin + yaZhuModel.feijiagongaokeng + yaZhuModel.liewen + yaZhuModel.nainmo + yaZhuModel.lamo + yaZhuModel.qipi + yaZhuModel.youwufahei + yaZhuModel.cuoshang + yaZhuModel.shangzhouchengjushang + yaZhuModel.chongshang + yaZhuModel.bengliao;
                                            //以上是压铸缺陷
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                yaZhuModel.penghuashang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                            //    yaZhuModel.hmianhuashang = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("waiguanquexian_shangzhouchengkongduanlie"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_shangzhouchengkongduanlie"].ToString(), out tempNum);
                                            //    yaZhuModel.shangzhouchengkongduanlie = tempNum;
                                            //}
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
                                            //model.cuopifengquexian = yaZhuModel.penghuashang + yaZhuModel.hmianhuashang + yaZhuModel.xiankawai + yaZhuModel.luodipin + yaZhuModel.shangzhouchengkongduanlie + yaZhuModel.jitan + yaZhuModel.lengliao + yaZhuModel.qita;
                                            //以上是挫披锋缺陷
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                yaZhuModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = yaZhuModel.chouyangshu;
                                            yaZhuModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            //yaZhuModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            //以上是品检缺陷=抽样数
                                            yaZhuBll.Add(yaZhuModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            // model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
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
                                        case "打砂（1）统计"://打砂缺陷
                                            #region DaShaBaoFeiDetail
                                            YaZhuQueXianDetailBLL daShaBll = new BLL.YaZhuQueXianDetailBLL();
                                            YaZhuQueXianDetail daShaMpdel = new Model.YaZhuQueXianDetail();
                                            //if (dt.Columns.Contains("yazhuquexian_gaodiyadiaoji"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_gaodiyadiaoji"].ToString(), out tempNum);
                                            //    daShaMpdel.gaodiyatiaoji = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            //    daShaMpdel.feijiagongaokeng = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                            //    daShaMpdel.shangzhouchengjushang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                daShaMpdel.chongshang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                            //    daShaMpdel.bengliao = tempNum;
                                            //}
                                            //model.yazhuquexian = daShaMpdel.gaodiyatiaoji + daShaMpdel.feijiagongaokeng + daShaMpdel.liewen + daShaMpdel.nianmo + daShaMpdel.qipi + daShaMpdel.youwufahei + daShaMpdel.cuoshang + daShaMpdel.shangzhouchengjushang + daShaMpdel.chongshang + daShaMpdel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                daShaMpdel.penghuashang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                            //    daShaMpdel.hmianhuashang = tempNum;
                                            //}
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
                                            //model.cuopifengquexian = daShaMpdel.penghuashang + daShaMpdel.hmianhuashang + daShaMpdel.xiankawai + daShaMpdel.luodipin + daShaMpdel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                daShaMpdel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = daShaMpdel.chouyangshu;
                                            daShaMpdel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["waiguanquexian_gonghao"]);
                                            //daShaMpdel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            //daShaMpdel.dashaType = 1;
                                            daShaBll.Add(daShaMpdel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            // model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
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
                                        case "打砂（2）统计":
                                            #region DaShaBaoFeiDetail
                                            YaZhuQueXianDetailBLL daShaBll2 = new BLL.YaZhuQueXianDetailBLL();
                                            YaZhuQueXianDetail daShaModel = new Model.YaZhuQueXianDetail();
                                            //if (dt.Columns.Contains("yazhuquexian_gaodiyadiaoji"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_gaodiyadiaoji"].ToString(), out tempNum);
                                            //    daShaModel.gaodiyatiaoji = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            //    daShaModel.feijiagongaokeng = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                            //    daShaModel.shangzhouchengjushang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                daShaModel.chongshang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                            //    daShaModel.bengliao = tempNum;
                                            //}
                                            //model.yazhuquexian = daShaModel.gaodiyatiaoji + daShaModel.feijiagongaokeng + daShaModel.liewen + daShaModel.nianmo + daShaModel.qipi + daShaModel.youwufahei + daShaModel.cuoshang + daShaModel.shangzhouchengjushang + daShaModel.chongshang + daShaModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                daShaModel.penghuashang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                            //    daShaModel.hmianhuashang = tempNum;
                                            //}
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
                                            //model.cuopifengquexian = daShaModel.penghuashang + daShaModel.hmianhuashang + daShaModel.xiankawai + daShaModel.luodipin;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                daShaModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = daShaModel.chouyangshu;
                                            daShaModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["waiguanquexian_gonghao"]);
                                            //daShaModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            //daShaModel.dashaType = 2;
                                            daShaBll2.Add(daShaModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            //model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
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
                                        case "披锋组统计":
                                            #region piFengBaoFeiDetail
                                            YaZhuQueXianDetailBLL piFengBll = new BLL.YaZhuQueXianDetailBLL();
                                            YaZhuQueXianDetail piFengModel = new Model.YaZhuQueXianDetail();
                                            if (dt.Columns.Contains("yazhuquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lamo"].ToString(), out tempNum);
                                                piFengModel.lamo = tempNum;
                                            }
                                            //if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            //    piFengModel.feijiagongaokeng = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                            //    piFengModel.shangzhouchengjushang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                piFengModel.chongshang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                            //    piFengModel.bengliao = tempNum;
                                            //}
                                            //model.yazhuquexian = piFengModel.lamo + piFengModel.feijiagongaokeng + piFengModel.liewen + piFengModel.nianmo + piFengModel.qipi + piFengModel.youwufahei + piFengModel.lengliao + piFengModel.cuoshang + piFengModel.shangzhouchengjushang + piFengModel.chongshang + piFengModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                piFengModel.penghuashang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                            //    piFengModel.hmianhuashang = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("waiguanquexian_mianbianxing"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianbianxing"].ToString(), out tempNum);
                                            //    piFengModel.hmianbianxing = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("waiguanquexian_yashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_yashang"].ToString(), out tempNum);
                                            //    piFengModel.yashang = tempNum;
                                            //}
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
                                            //model.cuopifengquexian = piFengModel.penghuashang + piFengModel.hmianhuashang + piFengModel.hmianbianxing + piFengModel.yashang + piFengModel.xiankawai + piFengModel.abbdashang + piFengModel.luodipin + piFengModel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                piFengModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = piFengModel.chouyangshu;
                                            piFengModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            //piFengModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            piFengBll.Add(piFengModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            //model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
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
                                        case "披锋组（H面）":
                                            #region H面全检
                                            YaZhuQueXianDetailBLL piFengHBll = new BLL.YaZhuQueXianDetailBLL();
                                            YaZhuQueXianDetail piFengHModel = new Model.YaZhuQueXianDetail();
                                            //if (dt.Columns.Contains("yazhuquexian_shayan"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_shayan"].ToString(), out tempNum);
                                            //    piFengHModel.shayan = tempNum;
                                            //}
                                            if (dt.Columns.Contains("yazhuquexian_lamo"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["yazhuquexian_lamo"].ToString(), out tempNum);
                                                piFengHModel.lamo = tempNum;
                                            }
                                            //if (dt.Columns.Contains("yazhuquexian_feijiagongmianaokeng"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["yazhuquexian_feijiagongmianaokeng"].ToString(), out tempNum);
                                            //    piFengHModel.feijiagongmianaokeng = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("jiagongquexian_shangzhouchengkongduanmianjushang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_shangzhouchengkongduanmianjushang"].ToString(), out tempNum);
                                            //    piFengHModel.shangzhouchengjushang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("jiagongquexian_chongshang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["jiagongquexian_chongshang"].ToString(), out tempNum);
                                                piFengHModel.chongshang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("jiagongquexian_bengliao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["jiagongquexian_bengliao"].ToString(), out tempNum);
                                            //    piFengHModel.bengliao = tempNum;
                                            //}
                                            //model.yazhuquexian = piFengHModel.shayan + piFengHModel.lamo + piFengHModel.feijiagongmianaokeng + piFengHModel.liewen + piFengHModel.nianmo + piFengHModel.qipi + piFengHModel.youwufahei + piFengHModel.lengliao + piFengHModel.cuoshang + piFengHModel.shangzhouchengjushang + piFengHModel.chongshang + piFengHModel.bengliao;
                                            if (dt.Columns.Contains("waiguanquexian_penghuashang"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_penghuashang"].ToString(), out tempNum);
                                                piFengHModel.penghuashang = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_mianhuashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianhuashang"].ToString(), out tempNum);
                                            //    piFengHModel.hmianhuashang = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("waiguanquexian_mianbianxing"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_mianbianxing"].ToString(), out tempNum);
                                            //    piFengHModel.hmianbianxing = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("waiguanquexian_jiaobianxing"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_jiaobianxing"].ToString(), out tempNum);
                                            //    piFengHModel.rjiaobianxing = tempNum;
                                            //}
                                            //if (dt.Columns.Contains("waiguanquexian_yashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_yashang"].ToString(), out tempNum);
                                            //    piFengHModel.yashang = tempNum;
                                            //}
                                            if (dt.Columns.Contains("waiguanquexian_xiankawai"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_xiankawai"].ToString(), out tempNum);
                                                piFengHModel.xiankawai = tempNum;
                                            }
                                            //if (dt.Columns.Contains("waiguanquexian_dashang"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_dashang"].ToString(), out tempNum);
                                            //    piFengHModel.assdashang = tempNum;
                                            //}
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
                                            //if (dt.Columns.Contains("waiguanquexian_cucaodugao"))
                                            //{
                                            //    decimal.TryParse(dt.Rows[i]["waiguanquexian_cucaodugao"].ToString(), out tempNum);
                                            //    piFengHModel.cuzaodugao = tempNum;
                                            //}
                                            if (dt.Columns.Contains("waiguanquexian_jita"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["waiguanquexian_jita"].ToString(), out tempNum);
                                                piFengHModel.qita = tempNum;
                                            }
                                            //model.cuopifengquexian = piFengHModel.penghuashang + piFengHModel.hmianhuashang + piFengHModel.hmianbianxing + piFengHModel.rjiaobianxing + piFengHModel.yashang + piFengHModel.xiankawai + piFengHModel.assdashang + piFengHModel.luodipin + piFengHModel.gubao + piFengHModel.aokeng + piFengHModel.cuzaodugao + piFengHModel.qita;
                                            if (dt.Columns.Contains("pinjian_chouyangshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["pinjian_chouyangshu"].ToString(), out tempNum);
                                                piFengHModel.chouyangshu = tempNum;
                                            }
                                            model.pinjianquexian = piFengHModel.chouyangshu;
                                            piFengHModel.gonghao = Convert.IsDBNull(dt.Rows[i]["pinjian_gonghao"]) ? "" : Convert.ToString(dt.Rows[i]["pinjian_gonghao"]);
                                            //piFengHModel.liuchengpiaohao = Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]) ? "" : Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);//流程票编号
                                            piFengHBll.Add(piFengHModel);
                                            if (dt.Columns.Contains("baofeizongshu"))
                                            {
                                                decimal.TryParse(dt.Rows[i]["baofeizongshu"].ToString(), out tempNum);
                                                model.baofeizongshu = tempNum;
                                            }
                                            //model.baofeizongshu = model.yazhuquexian + model.cuopifengquexian + model.pinjianquexian; //报废总数
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
                                        DateTime.TryParse(dt.Rows[i]["riji"].ToString(), out tiemTemp);
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
                                    if (dt.Columns.Contains("maopihao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["maopihao"]))
                                        {
                                            model.maopeihao = Convert.ToString(dt.Rows[i]["maopihao"]);
                                        }
                                    }
                                    if (model.maopeihao.Contains("-"))//包含"-"的时候去掉
                                    {
                                        string[] strs = model.maopeihao.Split('-');
                                        model.maopeihao = strs[0] + strs[1];
                                    }
                                    else if (model.maopeihao.Length >= 4)//长度大于5并且f开头
                                    {
                                        model.maopeihao = model.maopeihao.Substring(0, 1) + model.maopeihao.Substring(model.maopeihao.Length - 3);
                                    }
                                    if (dt.Columns.Contains("mohao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["mohao"]))
                                        {
                                            model.muhao = Convert.ToString(dt.Rows[i]["mohao"]);
                                        }
                                    }
                                    if (dt.Columns.Contains("liuchengpiaobianhao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["liuchengpiaobianhao"]))
                                        {
                                            model.liuchengpiaobianhao = Convert.ToString(dt.Rows[i]["liuchengpiaobianhao"]);
                                        }
                                    }
                                    if (dt.Columns.Contains("banci"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["banci"]))
                                        {
                                            model.banci = Convert.ToString(dt.Rows[i]["banci"]);
                                        }
                                    }
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
                                    FanXiuDetail fanxiuModel = new FanXiuDetail();
                                    FanXiuDetailBLL fanxiuBll = new FanXiuDetailBLL();
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
                                    fanxiuModel.beizhu = Convert.IsDBNull(dt.Rows[i]["beizhu"]) ? "" : Convert.ToString(dt.Rows[i]["beizhu"]);  //备注
                                    fanxiuModel.liuchengpiaobianhao = model.liuchengpiaobianhao;
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
                                    if (dt.Columns.Contains("xianhao"))
                                    {
                                        if (!Convert.IsDBNull(dt.Rows[i]["xianhao"]) && dt.Rows[i]["xianhao"].ToString().Trim() != "")
                                        {
                                            model.xianhao = Convert.ToString(dt.Rows[i]["xianhao"]);
                                        }
                                    }

                                    commonWorkShopRecordBLL.Add(model);
                                }
                                #endregion
                            }
                        }
                    }
                }
                #endregion

                MessageBox.Show("数据成功入库完毕，请关闭当前页面！");
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
