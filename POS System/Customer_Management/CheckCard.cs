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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace POS_System
{
    public partial class CheckCard : UserControl
    {
        public CheckCard()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        BLLUser blu = new BLLUser();
        public int id;
        public static int customer_no;
      
        private void CheckCard_Load(object sender, EventArgs e)
        {

            searchPanel.Show();
            backpanel.Hide();
            dtp_from.Text = Convert.ToString((date));
            dtp_to.Text = Convert.ToString((date));
          

            
        }


        public void SearchSales()
        {
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);

            DataTable dt = blcd.SearchSales(txt_card.Text, datefrom, dateto);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                    dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date2"].ToString();

                    transaction_date.Add(Convert.ToDateTime(dataGridView1.Rows[i].Cells["col_date"].Value).ToString("dd/MM/yyyy"));
                }
            }

        }
        public void SearchAddBalance()
        {
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DataTable dt1 = blcd.GetCustomerid(txt_card.Text);
            if (dt1.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt1.Rows[0]["id"].ToString());
            }
            DataTable dt = blcd.SearchAddBalance(id, datefrom, dateto);
            if (dt.Rows.Count > 0)
            {
                dataGridView2.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells["col_add_amount"].Value = dt.Rows[i]["balance_add"].ToString();
                    dataGridView2.Rows[i].Cells["col_date2"].Value = dt.Rows[i]["date"].ToString();

                    transaction_date.Add(Convert.ToDateTime(dataGridView2.Rows[i].Cells["col_date2"].Value).ToString("dd/MM/yyyy"));


                }
            }

        }

        public void SearchCashBack()
        {
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DataTable dt1 = blcd.GetCustomerid(txt_card.Text);
            if (dt1.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt1.Rows[0]["id"].ToString());
            }
            DataTable dt = blcd.SearchCashBack((id), datefrom, dateto);
            if (dt.Rows.Count > 0)
            {
                dataGridView3.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells["col_cash_back"].Value = dt.Rows[i]["cash_back"].ToString();
                    dataGridView3.Rows[i].Cells["col_date3"].Value = dt.Rows[i]["date"].ToString();

                    transaction_date.Add(Convert.ToDateTime(dataGridView3.Rows[i].Cells["col_date3"].Value).ToString("dd/MM/yyyy"));
                }
            }

        }

        public void grandtotal()
        {
            double grandtotal = 0;
            double add_balance = 0;
            double cash_back = 0;
         

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                grandtotal += Convert.ToDouble(dataGridView1.Rows[x].Cells["col_grand_total"].Value.ToString());
           }
 for (int x = 0; x < dataGridView2.Rows.Count; x++)
            {
                
                add_balance += Convert.ToDouble(dataGridView2.Rows[x].Cells["col_add_amount"].Value.ToString());
               
            }
            for (int x = 0; x < dataGridView3.Rows.Count; x++)
            {
                cash_back += Convert.ToDouble(dataGridView3.Rows[x].Cells["col_cash_back"].Value.ToString());
            }
            lbl_grand_total.Text = grandtotal.ToString();
            lbl_add_balance.Text = add_balance.ToString();
            lbl_cash_back.Text = cash_back.ToString();
        }
        List<string> tranDate = new List<string>();
        private void btn_show_all_Click(object sender, EventArgs e)
        {

            SearchSales();
            SearchAddBalance();
            SearchCashBack();
            // txt_searchbox.Text = txt_card.Text;
            tranDate = transaction_date.Distinct().ToList();
            tranDate.Sort();
            grandtotal();
            DataTable dt1 = blcd.GetCustomerid(txt_card.Text);
            if (dt1.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt1.Rows[0]["name"].ToString() + "  " + dt1.Rows[0]["lastname"].ToString();
            }
            lbl_customer_no.Text = txt_card.Text;
            customer_no = Convert.ToInt32(lbl_customer_no.Text);
            lbl_from.Text = dtp_from.Text;
            lbl_to.Text = dtp_to.Text;
            searchPanel.Hide();
            backpanel.Show();

        }
        
        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            printing_name = "Microsoft Print To PDF";
            printscript();
           
        }
        string printing_name;
        List<string> transaction_date = new List<string>();

        public void printscript()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 6000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = printing_name;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 6000;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);


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

                }
            }
        }
        PictureBox pb1 = new PictureBox();
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 7;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            int y = 83;
            Pen drawingPen = new Pen(System.Drawing.Color.Black, 1);
            Pen draw_watermark = new Pen(System.Drawing.Color.FromArgb(64, System.Drawing.Color.Black));
            System.Drawing.Font drawFontArial12Bold = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font drawFontArial10Regular = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            System.Drawing.Font drawFontArial10Regularsmall = new System.Drawing.Font("Arial", 7, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            Graphics gra = e.Graphics;
            //
            DataTable dtm = blu.checkbusiness();
            if (dtm.Rows.Count > 0)
            {
                string business_name = dtm.Rows[0]["business_name"].ToString();
                string address = dtm.Rows[0]["address"].ToString();
                string phone_no = dtm.Rows[0]["phone_no"].ToString();



                //titel       
                DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());

                e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
                if (business_name.Length >= 30)
                {
                    ybinc = 17;
                }

                e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
                ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
                if (address.Length >= 40)
                {
                    yinc = 15;
                }

                e.Graphics.DrawString(phone_no, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
                ys += e.Graphics.MeasureString(phone_no, drawFontArial10Regular).Height;
            }

            e.Graphics.DrawString("Topup Invoice", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Topup Invoice", drawFontArial10Regular).Height;

            //gra.DrawString("Customer Name :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            //gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            //gra.DrawString("Card Type :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            //gra.DrawString(Card_type, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            //gra.DrawString("Card No :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            //gra.DrawString(card_no, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("ID", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, yinc + 73 + ybinc);
            gra.DrawString("Transaction Details :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 73 + ybinc + yinc);

            gra.DrawString("Amount :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 73 + ybinc + yinc);
            y = y + 13;
            gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
            y = y + 5;
            yinc = yinc + 25;
            for (int i = 0; i < tranDate.Count; i++)
            {

                gra.DrawString(tranDate[i], new System.Drawing.Font("Times New Roman ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, yinc + 73 + ybinc); yinc = yinc + 25;

                for (int a = 0; a < dataGridView1.Rows.Count; a++)
                {
                    if (Convert.ToDateTime(dataGridView1.Rows[a].Cells["col_date"].Value).ToString("dd/MM/yyyy") == tranDate[i])
                    {

                        gra.DrawString(dataGridView1.Rows[a].Cells["col_bill_no"].Value.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, yinc + 73 + ybinc);
                        gra.DrawString("Sales:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 73 + ybinc + yinc);
                        gra.DrawString(dataGridView1.Rows[a].Cells["col_grand_total"].Value.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 73 + ybinc + yinc); yinc = yinc + 15;
                    }
                }
                for (int b = 0; b < dataGridView2.Rows.Count; b++)
                {
                    if (Convert.ToDateTime(dataGridView2.Rows[b].Cells["col_date2"].Value).ToString("dd/MM/yyyy") == tranDate[i])
                    {

                        gra.DrawString("Add Balance:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 73 + ybinc + yinc);
                        gra.DrawString(dataGridView2.Rows[b].Cells["col_add_amount"].Value.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 73 + ybinc + yinc); yinc = yinc + 15;
                    }
                }
                for (int c = 0; c < dataGridView3.Rows.Count; c++)
                {
                    if (Convert.ToDateTime(dataGridView3.Rows[c].Cells["col_date3"].Value).ToString("dd/MM/yyyy") == tranDate[i])
                    {
                        gra.DrawString("Cash Back", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 73 + ybinc + yinc);
                        gra.DrawString(dataGridView3.Rows[c].Cells["col_cash_back"].Value.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 73 + ybinc + yinc); yinc = yinc + 15;
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            backpanel.Hide();
        }
        
        private void btn_print_Click(object sender, EventArgs e)
        {
            printing_name = "B1";
            printscript();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_bill_no"].Index)
            {
                BillDetails detail = new BillDetails();
                detail.lbl_bill_no.Text = dataGridView1.Rows[e.RowIndex].Cells["col_bill_no"].Value.ToString();
                detail.Show();
            }
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            CreditDetail detail = new CreditDetail();
            detail.lbl_from.Text = dtp_from.Text;
            detail.lbl_to.Text = lbl_to.Text;
            detail.Show();
        }
    }
}
