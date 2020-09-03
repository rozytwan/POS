using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using DevExpress.XtraCharts;

namespace POS_System.Sales_Chart
{
    public partial class SalesChart : UserControl
    {
        public SalesChart()
        {
            InitializeComponent();
        }
        BLLChart blc = new BLLChart();
        private void SalesChart_Load_1(object sender, EventArgs e)
        {
            DateTime dateonly = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime datetimeNow = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            DataTable dtm = blc.getallDataByPastweekQty(dateonly, datetimeNow);
            if (dtm.Rows.Count > 0)
            {
                ChartTitle charttitkeweek = new ChartTitle();
                charttitkeweek.Text = "QTY per hour";
                chartControlQtySum.Titles.Add(charttitkeweek);
                DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series("QTY", ViewType.ScatterLine);
                series2.DataSource = dtm;
                series2.ArgumentScaleType = ScaleType.Auto;
                series2.ArgumentDataMember = "Hours";
                series2.ValueScaleType = ScaleType.Numerical;
                series2.ValueDataMembers.AddRange(new string[] { "QTY" });
                chartControlQtySum.Series.Add(series2);

            }
            DataTable dt = blc.getallDataByPastweek(dateonly, datetimeNow);
            if (dt.Rows.Count > 0)
            {
                ChartTitle charttitkeweek = new ChartTitle();
                charttitkeweek.Text = "Sales per hour";
                chartControlSalesSum.Titles.Add(charttitkeweek);
                DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series("Sales",ViewType.ScatterLine);
                series3.DataSource = dt;             
                series3.ArgumentScaleType = ScaleType.Auto;
                series3.ArgumentDataMember = "Hours";
                series3.ValueScaleType = ScaleType.Numerical;
                series3.ValueDataMembers.AddRange(new string[] { "Amt" });
                chartControlSalesSum.Series.Add(series3);

            }
            int total_no_of_table = 0;
            int total_no_of_bgtable = 0;
            DataTable dtc = blc.getAllTable();
            if (dtc.Rows.Count > 0)
            {
                total_no_of_table = Convert.ToInt32(dtc.Rows[0][0]);
            }
          
            DataTable dtb = blc.getAllbusytableTable();
            if (dtb.Rows.Count > 0)
            {
                total_no_of_bgtable = Convert.ToInt32(dtb.Rows[0][0]);
            }
          
            decimal totalbgpercent = (((total_no_of_bgtable) * 100 / (total_no_of_table)));
            decimal totalfreetable = 100 - totalbgpercent;

            Series series1 = new Series("A Pie Series", ViewType.Pie);

            // Populate the series with points. 
            series1.Points.Add(new SeriesPoint("Busy Table", totalbgpercent));
            series1.Points.Add(new SeriesPoint("Free Table", totalfreetable));

            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "3D Pie Chart";
            chartControlPie.Titles.Add(chartTitle1);
            chartControlPie.Series.Add(series1);
            chartControlPie.Legend.Visible = true;




        }

        private void chartControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
