namespace POS_System.Sales_Chart
{
    partial class SalesChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartControlPie = new DevExpress.XtraCharts.ChartControl();
            this.chartControlSalesSum = new DevExpress.XtraCharts.ChartControl();
            this.chartControlQtySum = new DevExpress.XtraCharts.ChartControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlSalesSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlQtySum)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartControlPie);
            this.panel1.Controls.Add(this.chartControlSalesSum);
            this.panel1.Controls.Add(this.chartControlQtySum);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 601);
            this.panel1.TabIndex = 1;
            // 
            // chartControlPie
            // 
            this.chartControlPie.Location = new System.Drawing.Point(655, 12);
            this.chartControlPie.Name = "chartControlPie";
            this.chartControlPie.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlPie.Size = new System.Drawing.Size(341, 276);
            this.chartControlPie.TabIndex = 4;
            // 
            // chartControlSalesSum
            // 
            this.chartControlSalesSum.Location = new System.Drawing.Point(8, 12);
            this.chartControlSalesSum.Name = "chartControlSalesSum";
            this.chartControlSalesSum.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlSalesSum.Size = new System.Drawing.Size(641, 276);
            this.chartControlSalesSum.TabIndex = 6;
            // 
            // chartControlQtySum
            // 
            this.chartControlQtySum.Location = new System.Drawing.Point(8, 310);
            this.chartControlQtySum.Name = "chartControlQtySum";
            this.chartControlQtySum.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlQtySum.Size = new System.Drawing.Size(641, 276);
            this.chartControlQtySum.TabIndex = 5;
            // 
            // SalesChart
            // 
            this.ClientSize = new System.Drawing.Size(1005, 601);
            this.Controls.Add(this.panel1);
            this.Name = "SalesChart";
            this.Load += new System.EventHandler(this.SalesChart_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlSalesSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlQtySum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraCharts.ChartControl chartControlSalesSum;
        private DevExpress.XtraCharts.ChartControl chartControlQtySum;
        private DevExpress.XtraCharts.ChartControl chartControlPie;
    }
}