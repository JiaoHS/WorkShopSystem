using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Visifire.Charts;
using WorkShopSystem.Model;

namespace WorkShopSystem.UI.Statistic
{
    /// <summary>
    /// ChartControl.xaml 的交互逻辑
    /// </summary>
    public partial class ChartControl : UserControl
    {
        public ChartControl()
        {
            InitializeComponent();
        }
        public void BindChartExpense(List<WealthyInfo> WealthyList, string type)
        {
            this.WealthyList1 = WealthyList;
            #region 设置控件基础属性
            Chart chart = new Chart();
            chart.Width = 470;
            chart.Height = 350;
            chart.Name = "Chart";
            chart.SetValue(Canvas.LeftProperty, 5.0);
            chart.SetValue(Canvas.TopProperty, 5.0);
            chart.Theme = "Theme1";//设置皮肤
            chart.BorderBrush = new SolidColorBrush(Colors.Gray);
            chart.AnimatedUpdate = true;
            chart.CornerRadius = new CornerRadius(7);
            chart.ShadowEnabled = true;
            chart.Padding = new Thickness(2, 2, 2, 5);
            #endregion

            DataSeries dataSeries = new DataSeries();
            dataSeries.RenderAs = RenderAs.Pie;
            dataSeries.LegendText = "机加车间产能统计";
            DataPoint point;
            Title title = new Title();
            title.Text = "机加车间产能统计";
            chart.Titles.Add(title);

            foreach (WealthyInfo cominfo in WealthyList)
            {
                point = new DataPoint();
                point.YValue = cominfo.AmountExpensesMoney;
                point.Tag = cominfo.ProductName;

                point.MouseLeftButtonDown += Dpoint1_MouseLeftButtonDown;
                dataSeries.DataPoints.Add(point);
            }
            chart.Series.Add(dataSeries);
            this.LayoutRoot.Children.Add(chart);
        }
        private List<WealthyInfo> WealthyList1;

        public void BindChart(List<WealthyInfo> WealthyList, string type)
        {
            this.WealthyList1 = WealthyList;
            #region 设置控件基础属性
            Chart chart = new Chart();
            chart.Width = 400;
            chart.Height = 350;
            chart.Name = "Chart";
            chart.SetValue(Canvas.LeftProperty, 30.0);
            chart.SetValue(Canvas.TopProperty, 30.0);
            chart.Theme = "Theme1";//设置皮肤
            chart.BorderBrush = new SolidColorBrush(Colors.Gray);
            chart.AnimatedUpdate = true;
            chart.CornerRadius = new CornerRadius(7);
            chart.ShadowEnabled = true;
            chart.Padding = new Thickness(4, 4, 4, 10);
            #endregion

            #region 设置Title
            Title title = new Title();
            title.Text = type=="a"? "压铸车间产能统计": "机加车间月份产能";
            chart.Titles.Add(title);
            #endregion

            #region 设置AxesX
            Axis xAxis = new Axis();
            xAxis.Title = "所有月份";
            chart.AxesX.Add(xAxis);
            #endregion

            #region 设置AxesY
            Axis yAxis = new Axis();
            yAxis.Title = type == "a" ? "压铸车间" : "机加车间";
            yAxis.Prefix = "数量：";
            yAxis.Suffix = "个";
            chart.AxesY.Add(yAxis);
            #endregion

            #region 设置PlotArea
            PlotArea plot = new PlotArea();
            plot.ShadowEnabled = false;
            chart.PlotArea = plot;
            #endregion

            #region 设置Legends
            Legend legend = new Legend();
            legend.MouseLeftButtonDown += Legend_MouseLeftButtonDown;
            chart.Legends.Add(legend);
            #endregion
            #region
            Visifire.Charts.ToolTip tip = new Visifire.Charts.ToolTip();
            tip.VerticalAlignment = VerticalAlignment.Bottom;
            chart.ToolTips.Add(tip);
            #endregion
            #region 创建数据序列和数据点

            foreach (WealthyInfo cominfo in WealthyList)
            {
                DataSeries dseries = new DataSeries();
                dseries.RenderAs = RenderAs.StackedColumn;
                dseries.LegendText = cominfo.ProductName;

                DataPoint dpointUpload = new DataPoint();
                dpointUpload.YValue = cominfo.AmountIncomeMoney;
                dpointUpload.Tag = cominfo.ProductName;
                dpointUpload.MouseLeftButtonDown += Dpoint_MouseLeftButtonDown;
                dseries.DataPoints.Add(dpointUpload);
                chart.Series.Add(dseries);
            }
            #endregion
            LayoutRoot.Children.Add(chart);
            //LayoutRoot.Children.Add(chart2);
        }

        /// <summary>
        /// DataPoint被点击执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Dpoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //接收到当前被点击的LengendText的值
            DataPoint dpoint = sender as DataPoint;
            string str = dpoint.Tag.ToString();
            foreach (WealthyInfo cominfo in WealthyList1)
            {
                if (str == cominfo.ProductName)
                {
                    MessageBox.Show(cominfo.ProductName + "数量：" + cominfo.AmountIncomeMoney + "个");
                }
            }
        }

        /// <summary>
        /// DataPoint被点击执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Dpoint1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //接收到当前被点击的LengendText的值
            DataPoint dpoint = sender as DataPoint;
            string str = dpoint.Tag.ToString();
            foreach (WealthyInfo cominfo in WealthyList1)
            {
                if (str == cominfo.ProductName)
                {
                    MessageBox.Show(cominfo.ProductName + "数量：" + cominfo.AmountExpensesMoney + "个");
                }
            }
        }
        /// <summary>
        /// Legend文字被点击执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Legend_MouseLeftButtonDown(object sender, LegendMouseButtonEventArgs e)
        {
            //接收到当前被点击的LengendText的值
            string str = e.DataSeries.LegendText;
            foreach (WealthyInfo cominfo in WealthyList1)
            {
                if (str == cominfo.ProductName)
                {
                    MessageBox.Show(cominfo.ProductName + "数量：" + cominfo.AmountIncomeMoney + "个");
                }
            }
        }
    }
}
