using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
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
using WorkShopSystem.Utility;

namespace WorkShopSystem.UI.jijia
{
    public partial class jijiawork : Form
    {
        //MachineShopProductionRecordBLL bll = new MachineShopProductionRecordBLL();
        List<CommonModel> machineList = new List<CommonModel>();
        public jijiawork()
        {
            InitializeComponent();
        }      

        private void jijiawork_Load(object sender, EventArgs e)
        {
            try
            {

                //1.加载机器的列表
                LoadMachineList();

                //2.生成流水号
                //CreateFlowNumber();

                //3.初始化消费数据
                //AlleExpenseInfos = new List<ExpenseInfo>();

                //List<Cus_Room> roomInfos = new Cus_RoomBLL().IsPayingGetModels(0);
                //占用CR_Money来显示用户的姓名
                //foreach (var roomInfo in roomInfos)
                //{
                //    roomInfo.CR_Money = roomInfo.CR_RoomID.Room_ID;
                //}
                //Expense_AutoID.Items.Add(roomInfo.CR_AutoID);
                //cmbMachine.DataSource = machineList;
                //cmbMachine.DisplayMember = "CR_Money";
                //cmbMachine.ValueMember = "CR_AutoID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadMachineList()
        {
            //machineList = bll.GetMachineList("");
        }
    }
}
