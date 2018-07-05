using MultiColHeaderDgvTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorkShopSystem.UI.cleardata;
using WorkShopSystem.UI.loading;
using WorkShopSystem.UI.Statistic;
using WorkShopSystem.UI.yazhu;

namespace WorkShopSystem.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
