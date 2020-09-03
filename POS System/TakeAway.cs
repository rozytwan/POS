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
    public partial class TakeAway : Form
    {
        public TakeAway()
        {
            InitializeComponent();
        }
        public bool save_value_toprint = false;
        string customername = "";
        string customermobile = "";
        string cardno = "";
        private bool button1WasClicked = false;    
        BLLCategory bllcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blord = new BLLOrder();
        BLLUser blu = new BLLUser();
        BLLTable blta = new BLLTable();
        BLLRestSell blresll = new BLLRestSell();
        Button newPanelcategory = new Button();
        BLLKotDisplay bllkot = new BLLKotDisplay();
        Bll_allJournal_Lists allaclists = new Bll_allJournal_Lists();
        DateTime datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        private void TakeAway_Load(object sender, EventArgs e)
        {
            txtcashier.Text = Login.sendtext;
            txtcardamount.Text = "0.00";
            txtcashamount.Text = "0.00";
            txtdiscount.Text = "0.00";
            txtgrandtotal.Text = "0.00";
            txtsubtotal.Text = "0.00";          
            bill();
            lbltable.Text = "104";
            datagridviewload();
            txtcashamount.Text = txtgrandtotal.Text;
            save_and_print();
            this.Close();
          
        }
        public void bill()
        {
            DataTable dt = blresll.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    txtnewbillno.Text = "100";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    txtnewbillno.Text = getinvoiceno.ToString();
                }
            }
        }
        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blord.getalldata(Convert.ToDecimal(lbltable.Text));
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();

                }
                calculate_total();
                this.Refresh();
                //clear();
            }
        }
        public void calculate_total()
        {
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
            }
            txtsubtotal.Text = sum.ToString();
            txtgrandtotal.Text = sum.ToString();
          

        }
        public void save_and_print()
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {

                if (!decimal.TryParse(lbltable.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No");

                }
                else if (txtcardamount.Text == "0.00" & txtcashamount.Text == "0.00" || txtcardamount.Text == "0" & txtcashamount.Text == "0")
                {
                    MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount");
                }
                else if (txtcardamount.Text != "0.00" || txtcashamount.Text != "0.00")
                {
                    printtobill();
                    if(save_value_toprint==true)
                    {
                        string payment_mode;
                        for (int a = 0; a < dataGridView1.Rows.Count; a++)
                        {

                            string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                            int quantity = Convert.ToInt32(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                            decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                            decimal total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                            string category_name1 = dataGridView1.Rows[a].Cells["cal_category_name"].Value.ToString();
                            //string date = DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString();
                            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                            if (chkcash.Checked)
                            {
                                payment_mode = "Cash";
                            }

                            else if (chkcard.Checked)
                            {

                                payment_mode = "Card";

                            }
                            else if (chkcredit.Checked)
                            {
                                payment_mode = "Credit";

                            }
                            else
                            {
                                payment_mode = "Cash/Card";

                            }
                            // int b = blresll.insertintosalesbook(Convert.ToInt32(txtnewbillno.Text), date, txtcashier.Text, lbltable.Text, customername, customermobile, item, quantity, cost, total, payment_mode, cardno, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(txtdiscount.Text), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), category_name1, "TA", "X");

                                button1WasClicked = true;

                            MessageBox.Show("Data has been save to database with new");

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                int order_id = Convert.ToInt32(row.Cells["cal_order_id"].Value);
                                int i = blord.deletefromorder_id(order_id);
                            }
                         
                            dataGridView1.Rows.Clear();
                        }
                    }
                }


              
            }
        }
          public void printtobill()
             {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 583);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "B1";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 583;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);


            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
                save_value_toprint = true;
                MessageBox.Show("Invalid Printer");
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {
                    pdoc.Print();
                    save_value_toprint = true;
                }
            }

            //DialogResult result = pd.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    PrintPreviewDialog ppd = new PrintPreviewDialog();
            //    ppd.Document = pdoc;
            //    result = ppd.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        pdoc.Print();

            //    }
            //}

        }
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 5;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            string price;
            string name; string quantity; string totala; int y = 0;
            Pen drawingPen = new Pen(Color.Black, 1);
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 7, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();

            //
            DataTable dtm = blu.checkbusiness();
            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();
            string phone_no = dtm.Rows[0]["phone_no"].ToString();
            string note_1 = dtm.Rows[0]["note_1"].ToString();
            string note_2 = dtm.Rows[0]["note_2"].ToString();
            Graphics gra = e.Graphics;
            string strDate = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            //titel       
            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            e.Graphics.DrawString(phone_no, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(phone_no, drawFontArial10Regular).Height;
            //dateandtime
            gra.DrawString("Date", new System.Drawing.Font("Arial", 6, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 60);
            gra.DrawString(strDate, new System.Drawing.Font("Arial", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 40, 60);
            gra.DrawString("Times", new System.Drawing.Font("Arial", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 180, 60);
            gra.DrawString(time, new System.Drawing.Font("Arial", 6, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, 60);
            gra.DrawLine(drawingPen, 0, 70, 314, 70);
            //bill and sale no

            gra.DrawString("Bill No::", new System.Drawing.Font("Times New Roman ", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, 75);
            gra.DrawString(txtnewbillno.Text, new System.Drawing.Font("Times New Roman ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 40, 75);
            gra.DrawString("Cashier::", new System.Drawing.Font("Times New Roman ", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 180, 75);
            gra.DrawString(txtcashier.Text, new System.Drawing.Font("Times New Roman ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, 75);

            gra.DrawLine(drawingPen, 0, 87, 314, 87);
            gra.DrawString("Item", new System.Drawing.Font("Arial", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, 89);
            gra.DrawString("QTY", new System.Drawing.Font("Arial", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130, 89);
            gra.DrawString("Price", new System.Drawing.Font("Arial", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 170, 89);
            gra.DrawString("Total", new System.Drawing.Font("Arial", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 230, 89);
            gra.DrawLine(drawingPen, 0, 102, 314, 102);
            y = 107;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                name = dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString();
                quantity = dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString();
                price = dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString();
                totala = dataGridView1.Rows[i].Cells["cal_total"].Value.ToString();
                if (name.Length <= 15)
                {
                    gra.DrawString(name, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, y);
                }
                else
                {
                    string sub = name.Substring(0, 15);
                    gra.DrawString(sub + ".....", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, y);

                }
                gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y);
                gra.DrawString(price, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, y);
                gra.DrawString(totala, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 230, y);
                y = y + 20;
            }

            //mode of payment
            gra.DrawString("Mode Of Payment", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 20, y);
            gra.DrawRectangle(drawingPen, 10, y + 10, 100, 40);
            gra.DrawString("Cash", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 15);
            gra.DrawString(txtcashamount.Text, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, y + 15);
            if (txtcardamount.Text != "0.00")
            {
                gra.DrawString("Card", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, y + 30);
                gra.DrawString(txtcardamount.Text, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, y + 30);
            }

            y = y - 5;
            gra.DrawLine(drawingPen, 0, y, 314, y);
            y = y + 10;
            gra.DrawString("Total ::", new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y);
            gra.DrawString(txtsubtotal.Text, new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y);
            Button btn = sender as Button;
            if (button1WasClicked == true)
            {
                gra.DrawString("Discount ::", new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y + 10);
                gra.DrawString(txtdiscount.Text, new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y + 10);
                gra.DrawString("Grand Total ::", new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y + 20);
                gra.DrawString(txtsubtotal.Text, new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y + 20);
                gra.DrawString("Received Amount ::", new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y + 30);
                gra.DrawString(txtcashamount.Text, new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y + 30);
                gra.DrawString("Change Amount ::", new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, y + 40);
                gra.DrawString(txtremainingamount.Text, new System.Drawing.Font("Courier New ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, y + 40);
                y = y + 53;
            }
            gra.DrawLine(drawingPen, 0, y, 314, y);
            e.Graphics.DrawString(note_1, drawFontArial10Regular, drawBrush, new RectangleF(xs, y + 5, widths, heights), drawFormatLeft);
            ys += e.Graphics.MeasureString(note_1, drawFontArial10Regular).Height;
            e.Graphics.DrawString(note_2, drawFontArial10Regular, drawBrush, new RectangleF(xs, y + 15, widths, heights), drawFormatLeft);
            ys += e.Graphics.MeasureString(note_2, drawFontArial10Regular).Height;

        }
        public void addSalestoJournals()
        {
            Bll_allJournal_Lists BllAlljounals = new Bll_allJournal_Lists();

            BLLAccounts_Journal_entry acs = new BLLAccounts_Journal_entry();
            BllLedger_entry ledgers = new BllLedger_entry();

            DateTime DateNow = DateTime.Now;
            int invoiceno = Convert.ToInt32(txtnewbillno.Text);
            decimal subtotal = Convert.ToDecimal(txtsubtotal.Text);

            string main_ac_type = "Expenses/Losses";

            decimal discounOnly = (Convert.ToDecimal(txtsubtotal.Text) * (Convert.ToDecimal(txtdiscount.Text) / 100));
            decimal _subTotal_withoutDiscount = Convert.ToDecimal(txtsubtotal.Text) - discounOnly;


            if (chkcash.Checked)
            {
                int insertintoallJournals = BllAlljounals.insertintoals_alljournals("Sales", "Being Sales", subtotal, invoiceno, DateNow);


                int insertintoDebitjournal = acs.InsertIntoTable(DateNow, "Cash", "Beind Sales Done", subtotal, 0, "Sales", invoiceno);

                int insertintoledgersdebit = ledgers.insertledgerdebit(DateNow, "Cash", subtotal, 0, "Sales", "Cash", "Assets", invoiceno, "Being Sales Done");



                if (Convert.ToDecimal(txtdiscount.Text) > 0)
                {
                    int insertintoDiscountintojournal = acs.InsertIntoTable(DateNow, "Discount allowed", "Being discount on sales", 0, discounOnly, "Cash", invoiceno);
                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Sales", "Being Sales Done", 0, _subTotal_withoutDiscount, "Cash", invoiceno);

                    int insertintoDiscountcredit = ledgers.insertledgercredit(DateNow, "Discount allowed", 0, discounOnly, "Cash", "Discount allowed", main_ac_type, invoiceno, "Being discount on sales");
                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Sales", 0, _subTotal_withoutDiscount, "Cash", "Sales", main_ac_type, invoiceno, "Being Sales Done");



                }
                else
                {

                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Sales", "Being Sales Done", 0, subtotal, "Cash", invoiceno);

                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Sales", 0, subtotal, "Cash", "Sales", main_ac_type, invoiceno, "Being Sales Done");
                }

                MessageBox.Show("cash only Checked");

            }
            else if (chkcredit.Checked)
            {
                int insertintoallJournals = BllAlljounals.insertintoals_alljournals("Debtors", "Being Debtors", subtotal, invoiceno, DateNow);


                int insertintoDebitjournal = acs.InsertIntoTable(DateNow, "Cash", "Being Debtors", subtotal, 0, "Debtors", invoiceno);

                int insertintoledgersdebit = ledgers.insertledgerdebit(DateNow, "Cash", subtotal, 0, "Debtors", "Cash", "Assets", invoiceno, "Being Debtors");


                if (Convert.ToDecimal(txtdiscount.Text) > 0)
                {

                    int insertintoDiscountintojournal = acs.InsertIntoTable(DateNow, "Discount allowed", "Being discount on sales", 0, discounOnly, "Cash", invoiceno);
                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Debtors", "Being Sales Done in credit", 0, _subTotal_withoutDiscount, "Cash", invoiceno);

                    int insertintoDiscountcredit = ledgers.insertledgercredit(DateNow, "Discount allowed", 0, discounOnly, "Cash", "Discount allowed", main_ac_type, invoiceno, "Being discount on sales");
                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Debtors", 0, _subTotal_withoutDiscount, "Cash", "Debtors", "Assets", invoiceno, "Being Sales done in credit");

                }
                else
                {

                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Debtors", "Being Sales Done", 0, subtotal, "Cash", invoiceno);

                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Debtors", 0, subtotal, "Cash", "Debtors", "Assets", invoiceno, "Being Sales done in credit");
                }

                MessageBox.Show("Credit only Checked");

            }
            else if (chkcard.Checked)
            {
                int insertintoallJournals = BllAlljounals.insertintoals_alljournals("Cash at Bank", "Being Payment made by Card", subtotal, invoiceno, DateNow);

                int insertintoDebitjournal = acs.InsertIntoTable(DateNow, "Cash", "Being Payment made by Card", subtotal, 0, "Cash at Bank", invoiceno);

                int insertintoledgersdebit = ledgers.insertledgerdebit(DateNow, "Cash", subtotal, 0, "Cash at Bank", "Cash", "Assets", invoiceno, "Being Payment made by Card");


                if (Convert.ToDecimal(txtdiscount.Text) > 0)
                {

                    int insertintoDiscountintojournal = acs.InsertIntoTable(DateNow, "Discount allowed", "Being discount on sales", 0, discounOnly, "Cash", invoiceno);
                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Cash at Bank", "Being payement by card on sales", 0, _subTotal_withoutDiscount, "Cash", invoiceno);

                    int insertintoDiscountcredit = ledgers.insertledgercredit(DateNow, "Discount allowed", 0, discounOnly, "Cash", "Discount allowed", main_ac_type, invoiceno, "Being discount on sales");
                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Cash at Bank", 0, _subTotal_withoutDiscount, "Cash", "Cash at Bank", "Assets", invoiceno, "Being payement by card on sales");

                }
                else
                {

                    int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Debtors", "Being Sales Done", 0, subtotal, "Cash", invoiceno);

                    int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, "Cash at Bank", 0, subtotal, "Cash", "Cash at Bank", "Assets", invoiceno, "Being payement by card on sales");
                }
                MessageBox.Show("Card only Checked");

            }
            else if (chkcash_card.Checked)
            {
                int insertintoallJournals = BllAlljounals.insertintoals_alljournals("Sales", "Being sales done by card and cash", subtotal, invoiceno, DateNow);

                int insertintoDebitjournal = acs.InsertIntoTable(DateNow, "Cash", "Being sales done by card and cash", subtotal, 0, "Sales", invoiceno);

                int insertintoledgersdebit = ledgers.insertledgerdebit(DateNow, "Cash", subtotal, 0, "Sales", "Cash", "Assets", invoiceno, "Being sales done by card and cash");

                decimal cardamount = Convert.ToDecimal(txtcardamount.Text);
                decimal cashamount = Convert.ToDecimal(txtcashamount.Text);


                if (Convert.ToDecimal(txtdiscount.Text) > 0)
                {

                    int insertintoDiscountintojournal = acs.InsertIntoTable(DateNow, "Discount allowed", "Being discount on sales", 0, discounOnly, "Cash", invoiceno);
                    int insertintocreditcardjournal = acs.InsertIntoTable(DateNow, "Cash at Bank", "Being sales done by card and cash", 0, cardamount, "Cash", invoiceno);
                    int insertintocreditCashjournal = acs.InsertIntoTable(DateNow, "Sales", "Being sales done by card and cash", 0, cashamount, "Cash", invoiceno);


                    int insertintoDiscountcredit = ledgers.insertledgercredit(DateNow, "Discount allowed", 0, discounOnly, "Cash", "Discount allowed", main_ac_type, invoiceno, "Being discount on sales");
                    int insertintoledgerCardscredit = ledgers.insertledgercredit(DateNow, "Cash at Bank", 0, cardamount, "Cash", "Cash at Bank", "Assets", invoiceno, "Being sales done by card and cash");
                    int insertintoledgersCashcredit = ledgers.insertledgercredit(DateNow, "Sales", 0, cashamount, "Cash", "Sales", "Revenue/Income/Gain", invoiceno, "Being sales done by card and cash");

                }
                else
                {
                    int insertintocreditcardjournal = acs.InsertIntoTable(DateNow, "Cash at Bank", "Being sales done by card and cash", 0, cardamount, "Cash", invoiceno);
                    int insertintocreditCashjournal = acs.InsertIntoTable(DateNow, "Sales", "Being sales done by card and cash", 0, cashamount, "Cash", invoiceno);

                    int insertintoledgerCardscredit = ledgers.insertledgercredit(DateNow, "Cash at Bank", 0, cardamount, "Cash", "Cash at Bank", "Assets", invoiceno, "Being sales done by card and cash");
                    int insertintoledgersCashcredit = ledgers.insertledgercredit(DateNow, "Sales", 0, cashamount, "Cash", "Sales", "Revenue/Income/Gain", invoiceno, "Being sales done by card and cash");

                }              
            }


            //inserting into blljournal for showing

            //inserting into journal accounts
            //int insertintoDebitjournal = acs.InsertIntoTable(DateNow, advouvhertype, narration, allpurchasetotal, 0, "Cash", invoiceno);
            //int insertintocreditjournal = acs.InsertIntoTable(DateNow, "Cash", narration, 0, credittotal, advouvhertype, invoiceno);

            ////inserting into ledgers 
            //int insertintoledgersdebit = ledgers.insertledgerdebit(DateNow, adddebit, allpurchasetotal, 0, "Cash", actype1, expense, invoiceno, narration);
            //int insertintoledgerscredit = ledgers.insertledgercredit(DateNow, addcredit, 0, credittotal, advouvhertype, actype2, assets, invoiceno, narration);



        }

    }
}

  