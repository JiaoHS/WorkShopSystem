using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.International.Converters.PinYinConverter;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace WorkShopSystem.Utility
{
    public class CommonHelper
    {
        public static int WorkShopType;
        public static string TimeStatic;
        //将字符串转化为MD5
        public static string ComputeStringMD5(string str)
        {
            //创建一个StringBuilder存放转化后的字符串
            StringBuilder sb = new StringBuilder();
            //创建一个MD5对象
            using (MD5 md5 = MD5.Create())
            {
                //将字符串转化为字节数组，因为MD5只能对一个字节进行转化
                byte[] buff = System.Text.Encoding.Default.GetBytes(str);
                //计算MD5值,并释放MD5
                byte[] mdbyte = md5.ComputeHash(buff);
                md5.Clear();

                //然后循环将转化后的mdbuff加到StringBuilder里
                //以16进制数组的形式进行拼接
                for (int i = 0; i < mdbyte.Length; i++)
                {
                    sb.Append(mdbyte[i].ToString("x2"));
                }

                //然后返回拼接完的字符串
                return sb.ToString();
            }
        }


        public static string GetPyFromName(string userName)
        {
            StringBuilder sbPy = new StringBuilder();
            //1.获取用户输入的文字
            string user_input = userName.Trim();

            //1.1循环遍历字符串中的每个字符
            for (int i = 0; i < user_input.Length; i++)
            {
                if (ChineseChar.IsValidChar(user_input[i]))
                {
                    //2.创建一个拼音计算类的对象
                    ChineseChar cnChar = new ChineseChar(user_input[i]);
                    if (cnChar.PinyinCount > 0)
                    {
                        sbPy.Append(cnChar.Pinyins[0].Substring(0, cnChar.Pinyins[0].Length - 1).ToLower());
                        //sbPy.Append(cnChar.Pinyins[0].Substring(0, 1)); //拼音首字母
                    }
                }
                else
                {
                    //sbPy.Append(user_input[i]);
                }
            }
            return sbPy.ToString();
        }
        public static long DateTimeToUnix(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            // 当地时区

            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
            return timeStamp;
        }
        public static DateTime UnixToDateTime(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            // 当地时区

            DateTime dt = startTime.AddSeconds(timeStamp);

            return dt;
        }

        public static void Save(System.Data.DataTable dt)
        {
            string fileName = "";
            //以下DataSet根据自己实际定义，本人的u_ListBase1是继承自DevExpress.XtraGrid.GridControl  
            //DataSet ds2 = u_ListBase1.GetCurrentDataSet();//选中要保存的数据  

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls"; //设置对话框保存的文件类型    
            saveFileDialog1.Title = "保存导出数据......";                       //设置对话框标题    
            saveFileDialog1.InitialDirectory = @"c:\";                          //设置初始保存路径    
            saveFileDialog1.RestoreDirectory = true;                            //设置保存对话框是否记忆上次打开的目录    
            saveFileDialog1.ShowHelp = true;                                    //设置是否显示帮助按钮    
            //u_ListBase1.ShowFooter = false;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                fileName = saveFileDialog1.FileName;   //文件名  
                SuperToExcel(dt, fileName);
                //u_ListBase1.ShowFooter = true;
            }
        }
        //高效导出Excel  
        public static bool SuperToExcel(System.Data.DataTable excelTable, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application app =
                new Microsoft.Office.Interop.Excel.Application();
            try
            {
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
                Microsoft.Office.Interop.Excel.Range range;
                int colIndex = 0;
                int rowIndex = 0;
                int colCount = excelTable.Columns.Count;
                int rowCount = excelTable.Rows.Count;

                //创建缓存数据  
                object[,] objData = new object[rowCount + 1, colCount];

                //写标题  
                int size = excelTable.Columns.Count;
                for (int i = 0; i < size; i++)
                {
                    wSheet.Cells[1, 1 + i] = excelTable.Columns[i].Caption;
                }
                //range = (Range)wSheet.get_Range(app.Cells[1, 1], app.Cells[1, colCount]);

                range = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[rowCount + 1, colCount]];
                //range.Value = data;

                range.Interior.ColorIndex = 15;//背景色 灰色  
                range.Font.Bold = true;//粗字体  
                                       //获取实际数据  

                for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (colIndex = 0; colIndex < colCount; colIndex++)
                    {
                        objData[rowIndex, colIndex] = excelTable.Rows[rowIndex][colIndex].ToString();
                    }
                }


                //写入Excel   
                range = (Range)wSheet.get_Range(app.Cells[2, 1], app.Cells[rowCount + 1, colCount]);
                range.NumberFormatLocal = "@";//设置数字文本格式  
                range.Value2 = objData;
                //Application.DoEvents();  

                wSheet.Columns.AutoFit();

                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;

                wBook.Saved = true;
                wBook.SaveCopyAs(filePath);

                app.Quit();
                app = null;
                GC.Collect();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
            }
        }
    }
}
