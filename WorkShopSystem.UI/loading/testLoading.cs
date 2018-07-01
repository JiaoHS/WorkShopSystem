using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkShopSystem.UI.loading
{
    public partial class testLoading : Form
    {
        public testLoading()
        {
            InitializeComponent();
        }
        OpaqueCommand cmd = new OpaqueCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            cmd.ShowOpaqueLayer(panel1, 125, true);
        }
        private void Waiting()
        {
            System.Threading.Thread.Sleep(2000);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmd.HideOpaqueLayer();
        }
    }
}
