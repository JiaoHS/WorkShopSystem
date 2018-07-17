using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkShopSystem.UI.WaitingBox;
using System.Threading;
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Caluculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        class DataPram
        {
            public int process;
            public int delay;
        }
        private DataPram _inputPra;

        private void AsynchronousDelegate(string message)
        {
            Thread.Sleep(5000);
            MessageBox.Show(message);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string res;
            DataTable dtable = null;
            frmWaitingBox f = new frmWaitingBox((obj, args) =>
            {
                Thread.Sleep(5000);
                string sql = "SELECT * FROM [test].[dbo].[studentInfo]";
                dtable = SqlHelper.ExecuteDataTable(sql);
            }, 10, "Plase Wait...", false, false);
            f.ShowDialog(this);
            res = f.Message;
            //dataGridView1.DataSource = dt;
            if (!string.IsNullOrEmpty(res))
                MessageBox.Show(res);


            //progressBar1.Maximum = 100000;
            //progressBar1.Step = 1;

            //for (int j = 0; j < 100000; j++)
            //{
            //    Caluculate(j);
            //    progressBar1.PerformStep();
            //}
            //timer1.Start();
            //progressBar1.Maximum = 100;
            //if (progressBar1.Value == 100)
            //{
            //    timer1.Stop();
            //    MessageBox.Show("over");
            //    progressBar1.Value = 0;
            //}
            //progressBar1.Maximum = 100;
            //progressBar1.Step = 1;
            //progressBar1.Value = 0;
            //backgroundWorker.RunWorkerAsync();
            //if (!backgroundWorker.IsBusy)
            //{
            //    _inputPra.process = 100;
            //    _inputPra.delay = 1200;
            //    backgroundWorker.RunWorkerAsync(_inputPra);
            //}

        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //var backgroundWorker = sender as BackgroundWorker;
            //for (int j = 0; j < 100000; j++)
            //{
            //    Caluculate(j);
            //    backgroundWorker.ReportProgress((j * 100) / 100000);
            //}

            int process = ((DataPram)e.Argument).process;
            int delay = ((DataPram)e.Argument).delay;
            int index = 1;
            try
            {
                for (int i = 0; i < process; i++)
                {
                    backgroundWorker.ReportProgress(index++ / process, string.Format("data{0}", i));
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("ok");
            // TODO: do something with final calculation.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
        }
    }
}
