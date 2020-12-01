using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class TableTransfer : Form
    {
        public TableTransfer()
        {
            InitializeComponent();
        }
        BLLTable blta = new BLLTable();
        BLLOrder blo = new BLLOrder();

        private void TableTransfer_Load(object sender, EventArgs e)
        {
            from();
            TO();

        }

        public void from()
        {
            DataTable dt = blta.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                txtfrom.DataSource = dt;
                txtfrom.DisplayMember = "rest_table_name";
                txtfrom.ValueMember = "rest_table_no";
            }
        }
        public void TO()
        {
            DataTable dt = blta.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                txtto.DataSource = dt;
                txtto.DisplayMember = "rest_table_name";
                txtto.ValueMember = "rest_table_no";
            }
        }


        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataTable dt = blta.checktransfer(Convert.ToDecimal(txtfrom.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do You Like To Transfer From " + txtfrom.Text + " To " + txtto.Text, "Table Tarnsfer", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dtm = blo.getallfromtblorder(Convert.ToDecimal(txtto.SelectedValue));
                    if (dtm.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int updateTableTransfer = blta.updateTableTransfer(Convert.ToDecimal(txtfrom.SelectedValue).ToString(), Convert.ToDecimal(txtto.SelectedValue).ToString(),dt.Rows[i]["item"].ToString(),Convert.ToDecimal(dt.Rows[i]["quantity"]),Convert.ToInt32(dt.Rows[i]["order_id"]));
                        }
                        int tableTranser = blta.tabletransfer(Convert.ToDecimal(txtfrom.SelectedValue), Convert.ToDecimal(txtto.SelectedValue));
                    }
                    else
                    {
                        int updateTableTransfer = blta.updateTableTransfer(Convert.ToDecimal(txtfrom.SelectedValue).ToString(), Convert.ToDecimal(txtto.SelectedValue).ToString(),"0",0,0);

                    }
                    int deleteAdvanceDiscount = blta.Updatetransfer(Convert.ToString(txtfrom.SelectedValue), Convert.ToString(txtto.SelectedValue));
                    DialogResult dialogResult2 = MessageBox.Show("Do You Like To Print Data In Kitchen", "Printing", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        printkot1();
                        printkot2();
                        printkot3();
                      
                        this.Close();
                    }
                }
            }
            else
            {
                int i = blta.tabletransfer(Convert.ToDecimal(txtfrom.SelectedValue), Convert.ToDecimal(txtto.SelectedValue));
                
                MessageBox.Show("Table Transfer");
                this.Hide();


            }
        }
        public void printkot1()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "K1";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                }
            }
        }
        public void printkot2()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "K2";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                }
            }
        }

        public void printkot3()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "B1";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                }
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 5;

            float widths = 120.0F; // max width I found through trial and error
            float heights = 0F;
          
            Font drawFontArial12Bold = new Font("Arial", 8, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 8, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 6, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen drawingPen = new Pen(Color.Black, 1);
            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
          

              
                String strDate = DateTime.Now.ToLongTimeString();

              
                    e.Graphics.DrawString("Table Has Been Transfer From"+txtfrom.Text+" To " +txtto.Text, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString("Table Has Been Transfer From" + txtfrom.Text + " To " + txtto.Text, drawFontArial12Bold).Height; ys = ys + 13;
                 
               


            
        }
    }
}
