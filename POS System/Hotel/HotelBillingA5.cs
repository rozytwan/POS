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

namespace POS_System.Hotel
{
   public class HotelBillingA5
    {
        public bool save_after_print;
        public string bill_no;
        public string cashier;
        public string table_no;
        public string sub_total;
        public string discount;
        public string grand_total;
        public string cash_amount;
        public string card_amount;
        public string service_charge;
        public string delivery_charge;
        public string tax_amount;
        public string change_amount;
        public string customer_PAN_no;
        public string customer_address;
        public string customer_phone_no;
        public string customer_name;
        public string discount_sub_total;
        public string discount_percent;
        public string area_name;
        public DateTime billing_date;
        public string taxable_amount;
        public string printer_name;
        public string sales_type;
        public List<string> kot_no = new List<string>();
        public string fiscal_year;
        public bool duplicate_bill_print = false;
        public bool print_again = false;
        public bool billing_print_again = false;
        public bool billing_print_only = false;
        public string customer_card_balance;
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        public List<string> datagridview_complementary = new List<string>();
        string count_print;
        string tax_percent;
        string table_name;
        string service_charge_percent;
        public string payment_mode;


        int total_noOfPage = 0;
        BLLUser blu = new BLLUser();
        BLLBill_printing blps = new BLLBill_printing();
        BLL_Tax bltx = new BLL_Tax();
        BLLTable blt = new BLLTable();
        public void printtobill()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("A5 (148 x 210 mm)", 584, 827);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "BillingA5";
            pd.Document.DefaultPageSettings.PaperSize = psize;

            
pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);


            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
                save_after_print = true;
            }
            else
            {
                MessageBox.Show("Invalid Printer", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                    save_after_print = true;
                }
                else
                {
                    print_again = false;
                    billing_print_only = false;
                    duplicate_bill_print = false;
                    billing_print_again = false;
                    datagridview_item_name.Clear();
                    datagridview_item_price.Clear();
                    datagridview_quantity.Clear();
                    datagridview_total.Clear();
                    datagridview_complementary.Clear();
                }
            }
        }
        PictureBox pb1 = new PictureBox();
        string panvat;
        CheckDynamic cd = new CheckDynamic();
        BLLDynamic bldd = new BLLDynamic();
        public bool Headerstatus;
        public bool FooterStatus;
        public bool Grandtotal;
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            total_noOfPage++;
            panvat = cd.DynamicPan();
            float xs = 5;
            float ys = 5;
            int yinc = 0;
            int ybinc = 0;
            float widths = 550.0F; // max width I found through trial and error
            float heights = 0F;
            string price;
            string name; string quantity; string totala; int y = 83;
            Pen drawingPen = new Pen(Color.Black, 1);
            Pen draw_watermark = new Pen(Color.FromArgb(64, Color.Black));
            Font drawFontArial12Bold = new Font("Arial", 16, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 12, FontStyle.Regular);
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
            DataTable getalltable = blps.getall_Printing_data();
            //DataTable get_table_name = blt.chheck_table_info(table_no);
            //if (get_table_name.Rows.Count > 0)
            //{
            //    table_name = get_table_name.Rows[0]["rest_table_name"].ToString();
            //}
            if (getalltable.Rows.Count > 0)
            {
                //
                DataTable dtm = blu.checkbusiness();
                string business_name = dtm.Rows[0]["business_name"].ToString();
                string address = dtm.Rows[0]["address"].ToString();
                string phone_no = dtm.Rows[0]["phone_no"].ToString();
                string note_1 = dtm.Rows[0]["note_1"].ToString();
                string note_2 = dtm.Rows[0]["note_2"].ToString();
                string pan_no = dtm.Rows[0]["pan_no"].ToString();
                DataTable dt_tax = bltx.get_all_tax_data();
                //if (dtm.Rows[0]["blogo"] == DBNull.Value)
                //{
                //    Byte[] imge_byte = (byte[])dtm.Rows[0]["blogo"];
                //    var stream = new MemoryStream(imge_byte);
                //    pb1.Size = new System.Drawing.Size(150, 100);
                //    pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                //    pb1.Image = System.Drawing.Image.FromStream(stream);
                //    Bitmap myBitmap1 = new Bitmap(pb1.Width, pb1.Height);
                //    pb1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pb1.Width, pb1.Height));
                //    e.Graphics.DrawImage(myBitmap1, 0, 0);
                //    ybinc = 100;
                //}
                if (dt_tax.Rows.Count > 0)
                {
                    string a = dt_tax.Rows[0]["tax_amount"].ToString();
                    string b = dt_tax.Rows[0]["service_charge_amount"].ToString();
                    tax_percent = a.TrimEnd('0').TrimEnd('.');
                    service_charge_percent = b.TrimEnd('0').TrimEnd('.');
                }
                Graphics gra = e.Graphics;
                //titel       
                DateTime strDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

                if (Headerstatus == true)
                {
                    if (getalltable.Rows[0]["store_name"].ToString() == "True")
                    {
                        e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
                        if (business_name.Length >= 30)
                        {
                            ybinc = 20;
                        }
                    }
                    if (getalltable.Rows[0]["address"].ToString() == "True")
                    {
                        e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
                        if (address.Length >= 40)
                        {
                            yinc = 18;
                        }

                        e.Graphics.DrawString(phone_no, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(phone_no, drawFontArial10Regular).Height;
                    }


                    if (print_again == true || billing_print_only == true)
                    {

                        DataTable dt = blps.getall_bill_no(bill_no);
                        if (dt.Rows.Count > 0)
                        {
                            count_print = (dt.Rows.Count).ToString();
                        }
                        if (billing_print_only == true)
                        {
                            e.Graphics.DrawString("Quotation Print", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
                            ys += e.Graphics.MeasureString("Quotation Print", drawFontArial10Regular).Height;

                        }
                        else
                        {
                            e.Graphics.DrawString("Invoice", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
                            ys += e.Graphics.MeasureString("Invoice", drawFontArial10Regular).Height;

                        }
                        if (duplicate_bill_print == true)
                        {
                            gra.DrawString("Copy Of Orginal #" + count_print, new System.Drawing.Font("Times New Roman ", 15, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 80, 80 + ybinc + yinc);
                        }

                    }
                    else
                    {
                        e.Graphics.DrawString("Tax Invoice", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString("Tax Invoice", drawFontArial10Regular).Height;
                    }
                }

                if (billing_print_only != true)
                {
                    y = y + 80;
                    gra.DrawString(panvat + ":", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(pan_no, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);
                    y = y + 15;
                    gra.DrawString("Bill No :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(bill_no, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);

                }
                if (customer_name != "Choose One" && customer_name != "")
                {
                    gra.DrawString("Customer Name #", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    if (customer_name.Length > 30)
                    {
                        gra.DrawString(customer_name.Substring(0, 29), new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                        y = y + 16;
                        gra.DrawString(customer_name.Substring(29), new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                        y = y + 16;

                    }
                    else
                    {
                        gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                        y = y + 16;
                    }
                }
                else
                {
                    y = y + 16;
                }

                if (getalltable.Rows[0]["table_name"].ToString() == "True")
                {
                    gra.DrawString("Area :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(area_name, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);
                    y = y + 16;
                    if (sales_type == "HD")
                    {
                        gra.DrawString("HD No :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    }
                    else
                    {
                        gra.DrawString("Table No :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    }
                    gra.DrawString(table_no, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);
                    y = y + 16;
                    if (table_name != null && table_name != "")
                    {
                        gra.DrawString("Table Name :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                        gra.DrawString(table_name, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);

                    }
                }
                if (customer_PAN_no != "")
                {
                    gra.DrawString("Customer PAN No #", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 340, y);
                    gra.DrawString(customer_PAN_no, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                    y = y + 16;
                }
                else
                {
                    y = y + 16;
                }
                if (getalltable.Rows[0]["date_and_time"].ToString() == "True")
                {

                    gra.DrawString("Bill Date :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(String.Format("{0:f}", billing_date), new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);
                    y = y + 16;
                    gra.DrawString("Fiscal Year :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(fiscal_year, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);

                }
                if (customer_address != "" && customer_address != null)
                {
                    gra.DrawString("Customer Address #", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(customer_address, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                    y = y + 16;

                }
                else
                {
                    y = y + 16;
                }
                if (getalltable.Rows[0]["cashier"].ToString() == "True")
                {
                    gra.DrawString("Cashier :", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    gra.DrawString(cashier, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y);

                }
                if (customer_phone_no != "" && customer_phone_no != "Choose One")
                {
                    gra.DrawString("Customer Phone No #", new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(customer_phone_no, new System.Drawing.Font("Times New Roman ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                    y = y + 19;

                }
                else
                {
                    y = y + 19;
                }

                if (getalltable.Rows[0]["header"].ToString() == "True")
                {
                    gra.DrawLine(drawingPen, 0, y, 690, y);
                    y = y + 7;
                    gra.DrawString("S.N", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y);
                    gra.DrawString("Item", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 35, y);
                    gra.DrawString("QTY", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 250, y);
                    gra.DrawString("Price", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 350, y);
                    gra.DrawString("Total", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 450, y);
                    y = y + 16;
                    gra.DrawLine(drawingPen, 0, y, 690, y);
                    y = y + 7;
                }
                if (getalltable.Rows[0]["items"].ToString() == "True")
                {
                    int totalItem = datagridview_item_name.Count;
                    for (int i = 0; i < totalItem; i++)
                    {
                        name = datagridview_item_name[i];
                        quantity = datagridview_quantity[i];
                        price = datagridview_item_price[i];
                        totala = datagridview_total[i];
                        gra.DrawString((i + 1).ToString(), new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                        if (name.Length <= 150)
                        {
                            gra.DrawString(name, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, y);
                        }
                        else
                        {
                            string sub = name.Substring(0, 150);
                            gra.DrawString(sub + "...", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, y);
                        }
                        if (print_again != true)
                        {
                            gra.DrawString(datagridview_complementary[i], new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 490, y);
                        }
                        if (name == "Room Charge")
                        {
                            gra.DrawString(quantity + " days", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 240, y);
                            gra.DrawString(price, new System.Drawing.Font("minisystem", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 340, y);
                            gra.DrawString(totala, new System.Drawing.Font("minisystem", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                            y = y + 20;
                            gra.DrawLine(drawingPen, 220, y, 690, y);
                            y = y + 2;
                            gra.DrawString("Total :", new System.Drawing.Font("minisystem", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 340, y);
                            gra.DrawString(totala, new System.Drawing.Font("minisystem", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y); y = y + 16;
                            gra.DrawLine(drawingPen, 220, y, 690, y); y = y + 2;
                        }
                        else
                        {
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 240, y);
                            gra.DrawString(price, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 340, y);
                            gra.DrawString(totala, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 440, y);
                            y = y + 23;
                        }
                        //gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 540, y);
                        //gra.DrawString(price, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 640, y);
                        //gra.DrawString(totala, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 740, y);
                        //y = y + 23;



                    }


                }

                //mode of payment
                if (getalltable.Rows[0]["payment_mode"].ToString() == "True")
                {
                    gra.DrawString("Mode Of Payment", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 20);
                    gra.DrawRectangle(drawingPen, 10, y + 35, 100, 40);
                    gra.DrawString(payment_mode, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 40);

                    if (payment_mode == "Cash")
                    {
                        gra.DrawString(cash_amount, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 55);

                    }
                    else
                    {
                        gra.DrawString(card_amount, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 55);
                    }

                }

                y = y - 5;
                gra.DrawLine(drawingPen, 0, y, 690, y);
                y = y + 21;
                if (getalltable.Rows[0]["sub_total"].ToString() == "True")
                {
                    gra.DrawString("Sub-Total :", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(sub_total, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;
                    gra.DrawLine(drawingPen, 290, y, 690, y); y = y + 2;
                }

                if (getalltable.Rows[0]["discount"].ToString() == "True")
                {
                    gra.DrawString("Discount(" + discount_percent + ")", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(discount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;
                    gra.DrawLine(drawingPen, 390, y, 390, y + 72); //xline stright
                    gra.DrawLine(drawingPen, 290, y, 690, y); y = y + 2;

                    gra.DrawString("Total", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(discount_sub_total, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;

                    gra.DrawLine(drawingPen, 290, y, 690, y); y = y + 2;
                    if (sales_type != "HD")
                    {
                        gra.DrawString("Service (" + service_charge_percent + "%)", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                        gra.DrawString(service_charge, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;
                    }
                    gra.DrawLine(drawingPen, 290, y, 690, y); y = y + 2;

                }
                if (getalltable.Rows[0]["total"].ToString() == "True")
                {
                    gra.DrawString("Taxable AMT", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(taxable_amount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;

                    gra.DrawLine(drawingPen, 290, y, 690, y); y = y + 2;
                    gra.DrawString("VAT (" + String.Format("{0:0.##}", tax_percent) + "%)", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(tax_amount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 19;

                }
                if (sales_type == "HD")
                {
                    gra.DrawString("Delivery Charge", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 300, y);
                    gra.DrawString(delivery_charge, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 600, y); y = y + 19;

                }
                gra.DrawLine(drawingPen, 0, y, 690, y); y = y + 2;
                gra.DrawString("Grand Total:", new System.Drawing.Font("Courier New ", 25, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y);
                gra.DrawString(grand_total, new System.Drawing.Font("Courier New ", 19, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 60;

                gra.DrawLine(drawingPen, 0, y, 690, y); y = y + 2;
                if (Grandtotal == false)
                {
                    string inwordtext = Spell.SpellAmount.InWrods(Convert.ToDecimal(Convert.ToDecimal(grand_total).ToString("F")));
                    e.Graphics.DrawString("In Words:" + inwordtext.Substring(4, inwordtext.Length - 4), drawFontArial10Regular, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString("In Words:" + inwordtext.Substring(4, inwordtext.Length - 4), drawFontArial10Regular).Height; y = y + 40;
                    gra.DrawLine(drawingPen, 0, y + yinc + ybinc, 690, y + yinc + ybinc); y = y + 2;
                }
                if (getalltable.Rows[0]["received_amt"].ToString() == "True")
                {

                    if (billing_print_only == true)
                    {
                        if (cash_amount != "0.00" || cash_amount != "0" || cash_amount != "")
                        {
                            gra.DrawString("Advance AMT ::", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 400, y);
                            gra.DrawString(cash_amount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 600, y); y = y + 19;

                        }

                    }
                    else
                    {
                        gra.DrawString("Received AMT ::", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 200, y);
                        gra.DrawString(cash_amount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 16;

                    }
                }
                if (getalltable.Rows[0]["change_amt"].ToString() == "True")
                {
                    gra.DrawString("Change AMT :", new System.Drawing.Font("Courier New ", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 200, y);
                    gra.DrawString(change_amount, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 400, y); y = y + 30;

                }

                if (FooterStatus == true)
                {
                    e.Graphics.DrawString(note_1, drawFontArial12Bold, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString(note_1, drawFontArial12Bold).Height; y = y + 16;
                    if (note_1.Length > 40)
                    {
                        y = y + 16;

                    }

                    gra.DrawString(note_2, new System.Drawing.Font("Courier New ", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);
                    if (note_2.Length > 40)
                    {
                        y = y + 16;
                    }

                    y = y + 35;



                    //    if (billing_print_again == true)
                    //    {
                    //        gra.DrawString("Re-Print Date #", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                    //        gra.DrawString(String.Format("{0:f}", strDate), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y + ybinc + yinc);
                    //        y = y + 15;
                    //    }
                    //    y = y + 50;
                    //    gra.DrawLine(drawingPen, 0, y, 80, y); y = y + 3;
                    //    gra.DrawString("Cashier", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);


                    //    //signature line2 
                    //    gra.DrawLine(drawingPen, 200, y, 300, y); y = y + 3;
                    //    gra.DrawString("Customer", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 210, y); y = y + 15;
                    //    if (billing_print_only == true)
                    //    {
                    //        e.Graphics.DrawString("This Quotation is not for official use.", drawFontArial10Regular, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    //        ys += e.Graphics.MeasureString("This Quotation is not for official use.", drawFontArial10Regular).Height; y = y + 15;

                    //    }

                    //    gra.DrawLine(drawingPen, 0, y + yinc + 10 + ybinc, 314, y + yinc + 10 + ybinc);
                    //}

                    print_again = false;
                    billing_print_only = false;
                    duplicate_bill_print = false;
                    billing_print_again = false;

                    datagridview_item_name.Clear();
                    datagridview_item_price.Clear();
                    datagridview_quantity.Clear();
                    datagridview_total.Clear();
                    datagridview_complementary.Clear();

                }


            }

        }
    }
}
