using BLLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public class BillPrintingHotel
    {
       
        public string bill_no;
        public string cashier;
        public string table_no;
        public string sub_total;
        public string discount;
        public string grand_total;
        public string cash_amount;
        public string card_amount;
        public string remaning_amount;
        public string service_charge;
        public string tax_amount;
        public string change_amount;
        public string customer_pan_no;
        public string customer_name;
        public string mobile_no;
        string count_print;
        public bool print_save;
        public bool billing_print_only = false;
        public bool print_again=false;
        public bool duplicate_bill_print = false;
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        BLLUser blu = new BLLUser();
        BLLBill_printing blps = new BLLBill_printing();
        public void print()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("A4", 826, 1169);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Hotel";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 1169;
            pdoc.DefaultPageSettings.PaperSize.Width = 826;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();

            }
            else
            {
                MessageBox.Show("Invalid Printer", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {
                    pdoc.Print();
                    print_save = true;
                }
                else
                {
                    print_again = false;
                    billing_print_only = false;
                    duplicate_bill_print = false;
                   // billing_print_again = false;
                    datagridview_item_name.Clear();
                    datagridview_item_price.Clear();
                    datagridview_quantity.Clear();
                    datagridview_total.Clear();
                    //datagridview_complementary.Clear();
                }
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 20;
            int y_inc = 0;
            float widths = 750.0F; // max width I found through trial and error
            float heights = 0F;
            string price;
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            string name; string quantity; string totala;
            Pen drawingPen = new Pen(Color.Black, 3);
            Pen drawingPen_1 = new Pen(Color.Black, 1);

            Font drawFontArial12Bold = new Font("Arial", 20, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 14, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 10, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
          
            DataTable dtm = blu.checkbusiness();
            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();
            string phone_no = dtm.Rows[0]["phone_no"].ToString();
            string pan_no = dtm.Rows[0]["pan_no"].ToString();
            Graphics gra = e.Graphics;
            //title head
            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            y_inc = 115;

            if (print_again == true)
            {
                DataTable dt = blps.getall_bill_no(bill_no);
                if (dt.Rows.Count > 0)
                {
                    count_print = (dt.Rows.Count).ToString();
                }
                gra.DrawString("INVOICE", new System.Drawing.Font("Times New Roamn", 13, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 325, y_inc); y_inc = y_inc + 15;
                if (duplicate_bill_print == true)
                {
                    gra.DrawString("Copy Of Orginal # " + count_print, new System.Drawing.Font("Times New Roman ", 15, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 290, y_inc);
                }
            }
            else
            {
                gra.DrawString("TAX INVOICE", new System.Drawing.Font("Times New Roamn", 13, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 325, y_inc); y_inc = y_inc + 5;

            }
            gra.DrawString("BILL NO :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 511, y_inc);
            gra.DrawString(bill_no, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 570, y_inc);
            gra.DrawString("NAME   :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y_inc); 
            gra.DrawString(customer_name, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y_inc); y_inc = y_inc + 23;
            gra.DrawString("DATE :  "+ strDate, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 511, y_inc);
            gra.DrawString("Customer Pan No :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y_inc);       
            gra.DrawString(mobile_no, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y_inc); y_inc = y_inc + 23;
            gra.DrawString("CASHIER :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 511, y_inc);
            gra.DrawString(cashier, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 570, y_inc);
            gra.DrawString("ROOM NO :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y_inc); 
            gra.DrawString(table_no, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y_inc); y_inc = y_inc + 23;
            gra.DrawString("PAN NO :", new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 511, y_inc); 
            gra.DrawString(pan_no, new System.Drawing.Font("Times New Roamn", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 570, y_inc); y_inc = y_inc + 23;

            y_inc = y_inc + 20;
            // down title
            gra.DrawLine(drawingPen, 0, y_inc, 826, y_inc); y_inc = y_inc + 2;
            // gra.DrawLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 1, 245);
            gra.DrawString("S.NO", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y_inc);
            gra.DrawString("DESCRIPTION", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 50, y_inc);
            gra.DrawString("QTY", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc);
            gra.DrawString("AMOUNT", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 600, y_inc);
            gra.DrawString("TOTAL", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 700, y_inc); y_inc = y_inc + 18;
            //  gra.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new System.Drawing.Font("Times New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 1, 265);
            gra.DrawLine(drawingPen, 0, y_inc, 826, y_inc); y_inc = y_inc + 4;

            for (int i = 0; i < datagridview_item_name.Count; i++)
            {
                name = datagridview_item_name[i];
                quantity = datagridview_quantity[i];
                price = datagridview_item_price[i];
                totala = datagridview_total[i];
                gra.DrawString((i+1).ToString(), new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, y_inc);
                gra.DrawString(name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 50, y_inc);
                gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 500, y_inc);
                gra.DrawString(price, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 600, y_inc);
                gra.DrawString(totala, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 700, y_inc);
                y_inc = y_inc + 20;
            }
            gra.DrawLine(drawingPen, 0, y_inc, 826, y_inc);y_inc = y_inc + 5;
            gra.DrawString("Total", new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc);
            gra.DrawString(sub_total, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 600, y_inc); y_inc = y_inc + 20;
            gra.DrawLine(drawingPen, 490, y_inc, 826, y_inc); y_inc = y_inc + 5;
            gra.DrawString("Discount", new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc);
            gra.DrawString(discount, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 650, y_inc); y_inc = y_inc + 20;
            gra.DrawString("Service Charge", new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc);
            gra.DrawString(service_charge, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 650, y_inc); y_inc = y_inc + 20;
            gra.DrawString("VAT Amount", new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc); 
            gra.DrawString(tax_amount, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 650, y_inc); y_inc = y_inc + 20;
            gra.DrawLine(drawingPen, 490, y_inc, 826, y_inc); y_inc = y_inc + 5;
            gra.DrawString("Grand Total", new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 500, y_inc); 
            gra.DrawString(grand_total, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 650, y_inc); y_inc = y_inc + 20;
            gra.DrawLine(drawingPen_1, 0, 969, 826, 969);
            gra.DrawLine(drawingPen_1, 0, 971, 826, 971);
            gra.DrawString("All bill payable on presentation. I agree that I am responsible for full payment of this bill in the event of it not being", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, 973);
            gra.DrawString("paid by the company/organisation or person indicated", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, 985);
            //signature line 
            gra.DrawLine(drawingPen_1, 50, 1030, 150, 1030);
            gra.DrawString("Checkout By:"+ cashier, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 1033);


            //signature line2 
            gra.DrawLine(drawingPen_1, 650, 1030, 800, 1030);
            gra.DrawString("GUEST SIGNATURE", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 650, 1033);

            e.Graphics.DrawString(business_name, drawFontArial10Regular, drawBrush, new RectangleF(xs, 1060, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial10Regular).Height;
            e.Graphics.DrawString(address +"  "+"Tel: "+phone_no, drawFontArial10Regularsmall, drawBrush, new RectangleF(xs, 1080, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address + "  " + "Tel: " + phone_no, drawFontArial10Regularsmall).Height;
            datagridview_item_name.Clear();
            datagridview_item_price.Clear();
            datagridview_quantity.Clear();
            datagridview_total.Clear();
        }
    }

  }

