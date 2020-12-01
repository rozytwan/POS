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
    class HotelBilling76
    {

        public bool save_after_print;
        public string nepaliDate;
        public string bill_no;
        public string brfiscal_year;
        public string cashier;
        public string table_no;
        public string sub_total;
        public string discount;
        public string grand_total;
        public string cash_amount;
        public string card_amount;
        public string customer_address;
        public string customer_phone_no;
        public string service_charge;
        public string tax_amount;
        public string change_amount;
        public string customer_PAN_no;
        public string customer_name;
        public string discount_sub_total;
        public string discount_percent;
        public string printer_name;
        public string area_name;
        public string fiscal_year;
        public DateTime billing_date;
        public string taxable_amount;
        public bool duplicate_bill_print = false;
        public bool print_again = false;
        public bool billing_print_again = false;
        public bool billing_print_only = false;
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        public List<string> datagridview_complementary = new List<string>();
        string count_print;
        string tax_percent;
        string table_name;
        public string payment_mode;
        string service_charge_percent;
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
            PaperSize psize = new PaperSize("Custome", 288, 6000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = printer_name;
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
        BLLDynamic bldd = new BLLS.BLLDynamic();
        public bool Headerstatus;
        public bool FooterStatus;
        public bool Grandtotal;
        public bool BillFooter;
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            panvat = cd.DynamicPan();
            float xs = 10;
            float ys = 7;
            int yinc = 0;
            int ybinc = 0;
            float widths = 225.0F; // max width I found through trial and error
            float heights = 0F;

            int y = 93;
            Pen drawingPen = new Pen(Color.Black, 1);
            Pen draw_watermark = new Pen(Color.FromArgb(64, Color.Black));
            Font drawFontArial12Bold = new Font("minisystem", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("minisystem", 9, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("minisystem", 7, FontStyle.Regular);
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
                //if (dtm.Rows[0]["blogo"] == DBNull.Value)
                //{

                //}
                //else
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
                DataTable dt_tax = bltx.get_all_tax_data();

                if (dt_tax.Rows.Count > 0)
                {
                    string a = dt_tax.Rows[0]["tax_amount"].ToString();
                    string b = dt_tax.Rows[0]["service_charge_amount"].ToString();
                    tax_percent = a.TrimEnd('0').TrimEnd('.');
                    service_charge_percent = b.TrimEnd('0').TrimEnd('.');
                }
                Graphics gra = e.Graphics;
                //titel       
                DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
                //DataTable dtheader = bldd.GetDynamic("QPH");
                //if (dtheader.Rows.Count > 0)
                //{
                //    string status = dtheader.Rows[0]["status"].ToString();
                //    if (status == "True")
                //    {

                if (Headerstatus == true)
                {
                    if (getalltable.Rows[0]["store_name"].ToString() == "True")
                    {
                        e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
                        if (business_name.Length >= 30)
                        {
                            ybinc = 13;
                        }
                    }
                    if (getalltable.Rows[0]["address"].ToString() == "True")
                    {
                        e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
                        if (address.Length >= 40)
                        {
                            yinc = 10;
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
                            gra.DrawString("Copy Of Orginal #" + count_print, new System.Drawing.Font("minisystem", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 80, 80 + ybinc + yinc);
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
                    gra.DrawString(panvat + ":", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 80 + ybinc + yinc);
                    gra.DrawString(pan_no, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, 80 + ybinc + yinc);
                    gra.DrawString("Bill No :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);

                    gra.DrawString(bill_no, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);

                    y = y + 13;
                }

                if (getalltable.Rows[0]["table_name"].ToString() == "True")
                {
                    gra.DrawString("Room Area :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(area_name, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
                    y = y + 13;
                    gra.DrawString("Room No :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(table_no, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
                    y = y + 13;
                    //if (table_name != null && table_name != "")
                    //{
                    //    gra.DrawString("Table Name :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    //    gra.DrawString(table_name, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
                    //    y = y + 13;
                    //}
                }
                if (getalltable.Rows[0]["date_and_time"].ToString() == "True")
                {

                    gra.DrawString("Bill Date :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(String.Format("{0:f}", billing_date), new System.Drawing.Font("minisystem", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                    y = y + 13;
                    gra.DrawString("Nepali Date :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(nepaliDate, new System.Drawing.Font("minisystem", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                    y = y + 13;
                    gra.DrawString("Fiscal Year :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(fiscal_year, new System.Drawing.Font("minisystem", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                    y = y + 13;
                }
                if (getalltable.Rows[0]["cashier"].ToString() == "True")
                {

                    gra.DrawString("Cashier :", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
                    gra.DrawString(cashier, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, y + ybinc + yinc);
                    y = y + 13;
                }

                if (getalltable.Rows[0]["header"].ToString() == "True")
                {
                    gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
                    y = y + 5;
                    gra.DrawString("Description", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                    gra.DrawString("QTY", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                    gra.DrawString("Price", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 145, y + ybinc + yinc);
                    gra.DrawString("Total", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 195, y + ybinc + yinc);
                    y = y + 13;
                    gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
                    y = y + 5;
                }
                if (getalltable.Rows[0]["items"].ToString() == "True")
                {
                    for (int i = 0; i < datagridview_item_name.Count; i++)
                    {
                        string name = datagridview_item_name[i];
                        string quantity = datagridview_quantity[i];
                        string price = datagridview_item_price[i];
                        string totala = datagridview_total[i];
                        if (name.Length <= 20)
                        {

                            gra.DrawString(name, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                            
                        }
                        else
                        {
                            string sub = name.Substring(0, 20);
                            gra.DrawString(sub + "...", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        }
                        if (print_again != true)
                        {
                            gra.DrawString(datagridview_complementary[i] ?? string.Empty, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, y + yinc + ybinc);
                        }
                        if (name == "Room Charge")
                        {
                            gra.DrawString(quantity + " days", new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + yinc + ybinc);
                            gra.DrawString(price, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 145, y + yinc + ybinc);
                            gra.DrawString(totala, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 195, y + yinc + ybinc);
                            y = y + 13;
                            gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
                            y = y + 2;
                            gra.DrawString("Total :", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, y + yinc + ybinc);
                            gra.DrawString(totala, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                            gra.DrawLine(drawingPen, 150, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                        }
                       else
                        {
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + yinc + ybinc);
                            gra.DrawString(price, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 145, y + yinc + ybinc);
                            gra.DrawString(totala, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 195, y + yinc + ybinc);
                            y = y + 20;
                        }
                        //gra.DrawString(quantity, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + yinc + ybinc);
                        //gra.DrawString(price, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 145, y + yinc + ybinc);
                        //gra.DrawString(totala, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 195, y + yinc + ybinc);
                        //y = y + 20;
                    }
                }
                //mode of payment
                if (getalltable.Rows[0]["payment_mode"].ToString() == "True")
                {
                    gra.DrawString("Mode Of Payment", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, y + yinc + ybinc);
                    gra.DrawString("Total :", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);

                    gra.DrawRectangle(drawingPen, 0, y + 15 + yinc + ybinc, 100, 40);
                    gra.DrawString(payment_mode, new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 20 + yinc + ybinc);
                    // gra.DrawString(cash_amount, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, y + 20 + yinc + ybinc);
                    //if (card_amount != "0.00")
                    //{
                    if (payment_mode == "Cash")
                    {
                        gra.DrawString(cash_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 35 + yinc + ybinc);

                    }
                    else
                    {
                        gra.DrawString(card_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 35 + yinc + ybinc);
                    }
                }

                y = y - 5;
                gra.DrawLine(drawingPen, 0, y + yinc + ybinc, 314, y + yinc + ybinc);
                y = y + 18;
                if (getalltable.Rows[0]["sub_total"].ToString() == "True")
                {
                    gra.DrawString("Sub-Total :", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(sub_total, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                    gra.DrawLine(drawingPen, 100, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                }
                if (getalltable.Rows[0]["discount"].ToString() == "True")
                {
                    int linefordiscount = 54;
                    if (discount != "")
                    {
                        gra.DrawString("Discount(" + discount_percent + ")", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                        gra.DrawString(discount, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                        gra.DrawLine(drawingPen, 100, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                        linefordiscount += 10;

                    }


                    gra.DrawString("Total", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(discount_sub_total, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                    gra.DrawLine(drawingPen, 100, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                    if (service_charge != "")
                    {
                        gra.DrawString("Service (" + service_charge_percent + "%)", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                        gra.DrawString(service_charge, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                        gra.DrawLine(drawingPen, 100, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                        linefordiscount += 8;
                    }
                    gra.DrawLine(drawingPen, 195, y + yinc + ybinc - 35, 195, y + yinc + ybinc + 72 - 35); //xline stright
                }
                if (getalltable.Rows[0]["total"].ToString() == "True")
                {
                    gra.DrawString("Taxable AMT", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(taxable_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                    gra.DrawLine(drawingPen, 120, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                    gra.DrawString("VAT (" + String.Format("{0:0.##}", tax_percent) + "%)", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(tax_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 16;
                }

                gra.DrawLine(drawingPen, 0, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                gra.DrawString("Grand Total:", new System.Drawing.Font("minisystem", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + yinc + ybinc);
                gra.DrawString(grand_total, new System.Drawing.Font("minisystem", 12, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, y + yinc + ybinc); y = y + 30;
                gra.DrawLine(drawingPen, 0, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                if (Grandtotal == false)
                {
                    string inwordtext = Spell.SpellAmount.InWrods(Convert.ToDecimal(Convert.ToDecimal(grand_total).ToString("F")));
                    e.Graphics.DrawString("In Words:" + inwordtext.Substring(4, inwordtext.Length - 4), drawFontArial10Regular, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString("In Words:" + inwordtext.Substring(4, inwordtext.Length - 4), drawFontArial10Regular).Height; y = y + 50;
                    gra.DrawLine(drawingPen, 0, y + yinc + ybinc, 314, y + yinc + ybinc); y = y + 2;
                }
                if (getalltable.Rows[0]["received_amt"].ToString() == "True")
                {

                    gra.DrawString("Received AMT ::", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(cash_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 190, y + yinc + ybinc); y = y + 16;

                }
                if (getalltable.Rows[0]["change_amt"].ToString() == "True")
                {
                    gra.DrawString("Change AMT :", new System.Drawing.Font("minisystem", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 100, y + yinc + ybinc);
                    gra.DrawString(change_amount, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y + yinc + ybinc); y = y + 30;
                }
                if (BillFooter == false || BillFooter == true && printer_name == "Billing")
                {
                    e.Graphics.DrawString(note_1, drawFontArial12Bold, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString(note_1, drawFontArial12Bold).Height; y = y + 13; y = y + 13;
                    if (note_1.Length > 40)
                    {
                        y = y + 13;
                    }
                }
                if (FooterStatus == true && printer_name != "Billing")
                {
                    //e.Graphics.DrawString(note_2, drawFontArial12Bold, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                    //ys += e.Graphics.MeasureString(note_2, drawFontArial12Bold).Height; y = y + 13; y = y + 13;
                    //if (note_1.Length > 40)
                    //{
                    //    y = y + 13;
                    //}
                    gra.DrawString(note_2, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + yinc + ybinc);
                    if (note_2.Length > 40)
                    {
                        y = y + 13;
                    }
                    y = y + 30;

                    if (customer_name != "Choose One" && customer_name != "")
                    {
                        gra.DrawString("Customer Name #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        if (customer_name.Length > 30)
                        {
                            gra.DrawString(customer_name.Substring(0, 29), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                            y = y + 15;
                            if (customer_name.Length > 29)
                            {
                                int cs_length;
                                if (customer_name.Length > 58)
                                {
                                    cs_length = 29;
                                }
                                else
                                {
                                    cs_length = customer_name.Length - 29;
                                }
                                gra.DrawString(customer_name.Substring(29, cs_length), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                                y = y + 15;
                            }
                            if (customer_name.Length > 58)
                            {
                                gra.DrawString(customer_name.Substring(58), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                                y = y + 15;
                            }

                        }

                        else
                        {
                            gra.DrawString(customer_name, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                            y = y + 15;
                        }
                        gra.DrawString("Customer PAN No #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        gra.DrawString(customer_PAN_no, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                        y = y + 15;
                        if (customer_address != "")
                        {
                            gra.DrawString("Customer Address #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                            gra.DrawString(customer_address, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                            y = y + 15;
                        }
                        if (customer_phone_no != "")
                        {
                            gra.DrawString("Customer Phone No #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                            gra.DrawString(customer_phone_no, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                            y = y + 15;
                        }
                    }
                    if (billing_print_again == true)
                    {
                        gra.DrawString("Re-Print Date #", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        gra.DrawString(String.Format("{0:f}", strDate), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y + ybinc + yinc);
                        y = y + 15;
                    }
                    y = y + 50;
                    gra.DrawLine(drawingPen, 0, y, 80, y); y = y + 3;
                    gra.DrawString("Cashier", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);


                    //signature line2 
                    gra.DrawLine(drawingPen, 200, y, 300, y); y = y + 3;
                    gra.DrawString("Customer", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 210, y); y = y + 15;
                    if (billing_print_only == true)
                    {
                        e.Graphics.DrawString("This Quotation is not for official use.", drawFontArial10Regular, drawBrush, new RectangleF(xs, y, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString("This Quotation is not for official use.", drawFontArial10Regular).Height; y = y + 15;

                    }

                    gra.DrawLine(drawingPen, 0, y + yinc + 10 + ybinc, 314, y + yinc + 10 + ybinc);
                }
                if (BillFooter == false && printer_name == "Billing")
                {
                    gra.DrawString(note_2, new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + yinc + ybinc);
                    if (note_2.Length > 40)
                    {
                        y = y + 13;
                    }
                    y = y + 30;

                    if (customer_name != "Choose One" && customer_name != "")
                    {
                        gra.DrawString("Customer Name #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        if (customer_name.Length > 30)
                        {
                            gra.DrawString(customer_name.Substring(0, 29), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                            y = y + 15;
                            if (customer_name.Length > 29)
                            {
                                int cs_length;
                                if (customer_name.Length > 58)
                                {
                                    cs_length = 29;
                                }
                                else
                                {
                                    cs_length = customer_name.Length - 29;
                                }
                                gra.DrawString(customer_name.Substring(29, cs_length), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                                y = y + 15;
                            }
                            if (customer_name.Length > 58)
                            {
                                gra.DrawString(customer_name.Substring(58), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                                y = y + 15;
                            }

                        }

                        else
                        {
                            gra.DrawString(customer_name, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, y + ybinc + yinc);
                            y = y + 15;
                        }
                        gra.DrawString("Customer PAN No #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                        gra.DrawString(customer_PAN_no, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                        y = y + 15;
                        if (customer_address != "")
                        {
                            gra.DrawString("Customer Address #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                            gra.DrawString(customer_address, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                            y = y + 15;
                        }
                        if (customer_phone_no != "")
                        {
                            gra.DrawString("Customer Phone No #", new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                            gra.DrawString(customer_phone_no, new System.Drawing.Font("minisystem", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 110, y + ybinc + yinc);
                            y = y + 15;
                        }
                    }

                    if (print_again == true)
                    {
                        gra.DrawString("Re-Print Date #", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc); y = y + 15;
                        gra.DrawString(String.Format("{0:f}", strDate), new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, y + ybinc + yinc);
                        y = y + 15;
                    }
                    y = y + 50;
                    gra.DrawLine(drawingPen, 0, y, 80, y); y = y + 3;
                    gra.DrawString("Cashier", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y);


                    //signature line2 
                    gra.DrawLine(drawingPen, 200, y, 300, y); y = y + 3;
                    gra.DrawString("Customer", new System.Drawing.Font("minisystem", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y); y = y + 15;

                    gra.DrawLine(drawingPen, 0, y + yinc + 10 + ybinc, 314, y + yinc + 10 + ybinc);
                }
                print_again = false;
                billing_print_only = false;
                duplicate_bill_print = false;
                billing_print_again = false;
                datagridview_item_name.Clear();
                datagridview_item_price.Clear();
                datagridview_quantity.Clear();
                datagridview_total.Clear();
            }
            

        }
    }
}
