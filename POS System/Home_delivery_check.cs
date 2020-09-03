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

namespace POS_System
{
    public partial class Home_delivery_check : Form
    {
        public Home_delivery_check()
        {
            InitializeComponent();
        }
        BLLhome_delivery BLLhome = new BLLhome_delivery();
        Bll_allJournal_Lists BllAlljounals = new Bll_allJournal_Lists();
        BLLRestSell blres = new BLLRestSell();
        BLLAccounts_Journal_entry acs = new BLLAccounts_Journal_entry();
        BllLedger_entry ledgers = new BllLedger_entry();
        BLLOrder blord = new BLLOrder();
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int order_id = 0;
        decimal grand_total;
        int bill_no;
        decimal total;
        string customer_name;
        string customer_address;
        string customer_phone;
        decimal tax_amount;
        decimal service_charge;
        decimal taxable_amount;
        string fiscal_year;
        decimal sub_total;
        public DateTime today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
        public void bill()
        {
            DataTable dt = blres.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                 bill_no=1;
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    bill_no=  getinvoiceno;
                }
            }
           
        }
        DataTable dtItem = new DataTable();
        string discount;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtchk = BLLhome.getalldatabykotId(Convert.ToDecimal(lblkotid.Text));
            if (dtchk.Rows.Count > 0)
            {
                service_charge = Convert.ToDecimal(dtchk.Rows[0]["service_charge"].ToString());
                taxable_amount = Convert.ToDecimal(dtchk.Rows[0]["taxable_amount"].ToString());
                tax_amount = Convert.ToDecimal(dtchk.Rows[0]["tax_amount"].ToString());
                fiscal_year = dtchk.Rows[0]["fiscal_year"].ToString();
                customer_name = dtchk.Rows[0]["customer_name"].ToString();
                customer_address = dtchk.Rows[0]["customer_adress"].ToString();
                customer_phone = dtchk.Rows[0]["customer_name"].ToString();
                grand_total = Convert.ToDecimal(dtchk.Rows[0]["grandtotal"].ToString());
                sub_total = Convert.ToDecimal(dtchk.Rows[0]["total"].ToString());
               
                discount =dtchk.Rows[0]["discount"].ToString();
                dtItem = blord.getalldata(Convert.ToDecimal(lblkotid.Text));

                for (int z = 0; z < dtItem.Rows.Count; z++)
                {
                    order_id = Convert.ToInt32(dtItem.Rows[z]["order_id"].ToString());
                    string item_name = dtItem.Rows[z]["item"].ToString();
                    decimal quantity = Convert.ToDecimal(dtItem.Rows[z]["quantity"].ToString());
                    total = Convert.ToDecimal(dtItem.Rows[z]["total"].ToString());
                    decimal cost = Convert.ToDecimal(dtItem.Rows[z]["cost"].ToString());
                    string category_name = dtItem.Rows[z]["category_name"].ToString();
                    string service_provider = "";
                    int b = blres.insertintosalesbook(bill_no, date, txtcashier.Text, category_name ,homeId.Text,customer_name, "", item_name, quantity, cost, total, lbl_payment_type.Text, "", sub_total, Convert.ToDecimal(0.00), grand_total, Convert.ToDecimal(0.00), grand_total, "HD", "", "X", service_charge, taxable_amount, tax_amount, fiscal_year, service_provider, date, 0, z ,DateTime.Now.ToString("HH:mm tt"), "False", 0, "", "", 0, "", order_id);
                }

                int ibiza = blres.insert_into_bill_invoice(bill_no);
                int delete_home_no = BLLhome.deletehomedeleveryid(lblkotid.Text);
                int deletehomedelevery = BLLhome.deletehomedeleveryvalue(Convert.ToDecimal(lblkotid.Text));
                int delete = BLLhome.deleteHomedeliveryStatus(lblkotid.Text);
                printer_checker();
                MessageBox.Show("Checked");
                this.Hide();
            }
            else
            {
                MessageBox.Show("The Payment was already Received. Check it.");
            }
        }
        public void materialized_view()
        {
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                string fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
                int fiscal = blfsc.insert_Materialized_View(fiscal_year,bill_no, customer_name, "", date, sub_total,0, grand_total, tax_amount, "True", "True", date.ToString("HH:mm tt"), txtcashier.Text, txtcashier.Text,"true","true");
            }
            else
            {
                int fiscal = blfsc.insert_Materialized_View("", bill_no, customer_name, "", date, sub_total, 0, grand_total, tax_amount, "True", "True", date.ToString("HH:mm tt"), txtcashier.Text, txtcashier.Text, "true", "true");
                MessageBox.Show("Information", "Please Set The Fiscal Year", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting76 blp_76 = new BillPrinting76();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        public void printer_checker()
        {
            DataTable dt_prt = blpst.getalldata();
            DataTable dt_p = blpst.getallPrintingTimes();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            blp_80.Headerstatus = true;
                            blp_80.FooterStatus = true;
                            blp_80.print_again = true;
                            blp_80.printer_name = "Billing";
                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp_80.print_again = false;
                            }
                            bill_printing_for_80();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
              
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            blp_76.Headerstatus = true;
                            blp_76.FooterStatus = true;
                            blp_76.print_again = true;

                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp_76.printer_name = "Billing";
                                blp_76.print_again = false;
                            }
                            bill_printing_for_76();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
                else
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {

                            
                            blp.Headerstatus = true;
                            blp.FooterStatus = true;
                            blp.print_again = true;

                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp.print_again = false;
                            }
                            bill_printing_for_58();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void bill_printing_for_58()
        {
            blp.bill_no = bill_no.ToString() ;
            blp.cashier = txtcashier.Text;
            blp.cash_amount = grand_total.ToString("#.##");
            blp.discount =discount;
            blp.grand_total = grand_total.ToString();
            blp.sub_total = sub_total.ToString();
            blp.table_no = lblkotid.Text;
          //  blp.customer_PAN_no = customer_phone;
            blp.customer_name = customer_name;
            blp.customer_address = customer_address;
            blp.customer_phone_no = customer_phone;
           // blp.discount_percent = discount_percent;
            blp.tax_amount = tax_amount.ToString("#.##");
            blp.service_charge = service_charge.ToString("#.##");
            blp.fiscal_year = fiscal_year;
            // blp.area_name = area_name;
            // blp.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            // blp.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            //if (txtremainingamount.Text != "")
            //{
            //    blp.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            //}
            blp.payment_mode = lbl_payment_type.Text;
            blp.billing_date = date;
            blp.taxable_amount = taxable_amount.ToString();
            blp.discount_sub_total =sub_total.ToString();
          
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    blp.datagridview_item_name.Add(dtItem.Rows[i]["item"].ToString());
                    blp.datagridview_item_price.Add(dtItem.Rows[i]["cost"].ToString());
                    blp.datagridview_total.Add(dtItem.Rows[i]["total"].ToString());
                    blp.datagridview_quantity.Add(dtItem.Rows[i]["quantity"].ToString());
                    //blp.datagridview_complementary.Add(dtItem.Rows[i]["com"].ToString());
                    //blp.kot_no.Add(dtItem.Rows[i]["cal_kot_id"].ToString());
                }
                blp.printtobill();
               // save_after_print = blp.save_after_print;
            
           
        }
        public void bill_printing_for_76()
        {
            blp_76.bill_no =bill_no.ToString();
            blp_76.cashier = txtcashier.Text;
            blp_76.cash_amount = grand_total.ToString();
            blp_76.discount = discount;
            blp_76.grand_total =grand_total.ToString();
            blp_76.sub_total = sub_total.ToString();
            blp_76.table_no = lblkotid.Text;
          //  blp_76.customer_PAN_no = customer_phone;
            blp_76.customer_name =customer_name;
            blp_76.customer_address = customer_address;
            blp_76.customer_phone_no = customer_phone;
            //blp_76.discount_percent = discount_percent;
            blp_76.tax_amount = tax_amount.ToString("#.##");
            blp_76.service_charge = service_charge.ToString("#.##");
          //  blp_76.area_name = area_name;
            blp_76.fiscal_year = fiscal_year;
            blp_76.payment_mode = lbl_payment_type.Text;
          
            blp_76.billing_date = date;
            blp_76.taxable_amount = taxable_amount.ToString("#.##");
            blp_76.discount_sub_total = sub_total.ToString();
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                blp_76.datagridview_item_name.Add(dtItem.Rows[i]["item"].ToString());
                blp_76.datagridview_item_price.Add(dtItem.Rows[i]["cost"].ToString());
                blp_76.datagridview_total.Add(dtItem.Rows[i]["total"].ToString());
                blp_76.datagridview_quantity.Add(dtItem.Rows[i]["quantity"].ToString());
                //blp.datagridview_complementary.Add(dtItem.Rows[i]["com"].ToString());
                //blp.kot_no.Add(dtItem.Rows[i]["cal_kot_id"].ToString());
            }
            blp_76.printtobill();
              //  save_after_print = blp_76.save_after_print;
           
        }
        public void bill_printing_for_80()
        {
            blp_80.bill_no = bill_no.ToString();
            blp_80.cashier = txtcashier.Text;
            blp_80.cash_amount = grand_total.ToString();
            blp_80.discount = discount;
            blp_80.grand_total = grand_total.ToString();
            blp_80.sub_total = sub_total.ToString();
            blp_80.table_no = lblkotid.Text;
           // blp_80.customer_PAN_no = customer_phone;
            blp_80.customer_name = customer_name;
            blp_80.customer_address = customer_address;
            blp_80.customer_phone_no = customer_phone;
            //blp_76.discount_percent = discount_percent;
            blp_80.tax_amount = tax_amount.ToString("#.##");
            blp_80.service_charge = service_charge.ToString("#.##");
            //  blp_76.area_name = area_name;
            blp_80.fiscal_year = fiscal_year;
            blp_80.payment_mode = lbl_payment_type.Text;

            blp_80.billing_date = date;
            blp_80.taxable_amount = taxable_amount.ToString("#.##");
            blp_80.discount_sub_total = sub_total.ToString();
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                blp_80.datagridview_item_name.Add(dtItem.Rows[i]["item"].ToString());
                blp_80.datagridview_item_price.Add(dtItem.Rows[i]["cost"].ToString());
                blp_80.datagridview_total.Add(dtItem.Rows[i]["total"].ToString());
                blp_80.datagridview_quantity.Add(dtItem.Rows[i]["quantity"].ToString());
                //blp.datagridview_complementary.Add(dtItem.Rows[i]["com"].ToString());
                //blp.kot_no.Add(dtItem.Rows[i]["cal_kot_id"].ToString());
            }
            blp_80.printtobill();
          //  save_after_print = blp_76.save_after_print;


        }
        private void Home_delivery_check_Load(object sender, EventArgs e)
        {
            bill();
            txtcashier.Text = Login.sendtext;
            lblkotid.Hide();
            lbl_payment_type.Hide();
            
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txt_deliverby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
