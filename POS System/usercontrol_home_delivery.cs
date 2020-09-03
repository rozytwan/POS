using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.Drawing.Printing;
using POS_System.Void;
using POS_System.Customer_Management;


namespace POS_System
{
    public partial class home : Form
    {
        public home(string hd_id)
        {
            InitializeComponent();
            home_delivery_id = hd_id;
        }
        
        BLLhome_delivery BLLhome = new BLLhome_delivery();
        BLLUser blu = new BLLUser();
        BLLRestSell blres = new BLLRestSell();
        Bll_cashcounter blcas = new Bll_cashcounter();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLOrder blord = new BLLOrder();
        bll_orderCancel boc = new bll_orderCancel();
        BLLKotDisplay blkot = new BLLKotDisplay();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLL_Fiscal blfsc = new BLL_Fiscal();
       public static string home_delivery_id="0";
        bool kot_cancel_1 = false;
        bool kot_cancel_2 = false;
        private bool button_cancelAll = false;    
        bool user_access_check;
        bool save_after_print;
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        PictureBox userpicbox = new PictureBox();
        string fiscal_year;
        int customer_id = AllCusomterList.customer_id;
        public void clearAllTextbox(Control Con)
        {
            foreach (Control c in Con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    clearAllTextbox(c);
            }
        }
        public void clearAllCombobox(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is ComboBox)
                    ((ComboBox)c).ResetText();
                else
                    clearAllCombobox(c);
            }

        }
        public void CUstomer_name()
        {
            DataTable dt = blcd.getallcustomers();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_customer.DataSource = dt;
                txt_customer.DisplayMember = "name";
                txt_customer.ValueMember = "id";
            }
        }
        public void CUstomer_number()
        {
            DataTable dt = blcd.getallcustomers();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["phone"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_phone.DataSource = dt;
                txt_phone.DisplayMember = "phone";
                txt_phone.ValueMember = "id";
            }
        }
        public void Cashier()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txtcashier.DataSource = dt;
                txtcashier.DisplayMember = "user_name";
                txtcashier.ValueMember = "user_name";
            }
        }
        public void GetCustomer()
        {
            DataTable dt = blcd.getallBykotid(home_delivery_id);
            if (dt.Rows.Count > 0)
            {
                txt_customer.SelectedValue = dt.Rows[0]["id"].ToString();
                txt_customer.Text = dt.Rows[0]["name"].ToString();
                //txt_phone.Text = dt.Rows[0]["phone"].ToString();
            }
        }
        private void usercontrol_home_delivery_Load(object sender, EventArgs e)
        {
          
            userpicbox.Image = global::POS_System.Properties.Resources.url;
            cbo_delivery.Focus();
            CUstomer_name();
            CUstomer_number();
            cbo_home_id.DropDownStyle = ComboBoxStyle.DropDown;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;     
            HomedeliveryTableNo();
            Cashier();
            txtcashier.Text = Login.sendtext;
            cbo_home_id.Text = home_delivery_id;
          
            if (cbo_home_id.Text.Length > 0 & cbo_home_id.Text != "Choose One"&cbo_home_id.Text!="103")
            {
            
                showall();
                GetCustomer();
            }
            //fiscal year
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            //if (home_delivery_id.Length > 0)
            //{
            //    if (home_delivery_id != "103")
            //    {
            //        showall();
            //        int inserthomedelivery = BLLhome.inserttheDeleverystats(home_delivery_id, "Null", "Null", "Null", Convert.ToDecimal(txt_total.Text), "Null", "Pending", Convert.ToDecimal(txt_grand_total.Text), Convert.ToDecimal(txt_delivery_charge.Text));
            //        int delete = BLLhome.deleteHomedeliveryStatus(home_delivery_id);                   
            //        printtobill();
            //        this.Close();
            //    }
            //}


        }
      
        public void showall()
        {
            DataTable fetchfromHomeId = BLLhome.getDataFromKot(home_delivery_id);
            dataGridView1.Rows.Clear();
            if (fetchfromHomeId.Rows.Count > 0)
            {
               
                dataGridView1.Rows.Clear();
                for (int fecrw = 0; fecrw < fetchfromHomeId.Rows.Count; fecrw++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[fecrw].Cells["cal_item_name"].Value = fetchfromHomeId.Rows[fecrw]["item"].ToString();
                    dataGridView1.Rows[fecrw].Cells["cal_qty"].Value = fetchfromHomeId.Rows[fecrw]["quantity"].ToString();
                    dataGridView1.Rows[fecrw].Cells["cal_cost"].Value = fetchfromHomeId.Rows[fecrw]["cost"].ToString();
                    dataGridView1.Rows[fecrw].Cells["cal_total"].Value = fetchfromHomeId.Rows[fecrw]["total"].ToString();
                    dataGridView1.Rows[fecrw].Cells["cal_item_category"].Value = fetchfromHomeId.Rows[fecrw]["category_name"].ToString();
                    dataGridView1.Rows[fecrw].Cells["cal_order_id"].Value = fetchfromHomeId.Rows[fecrw]["order_id"].ToString();
                    dataGridView1.Rows[fecrw].Cells["calkot_print"].Value = fetchfromHomeId.Rows[fecrw]["kot_print"].ToString();
                  //  grand_total += Convert.ToDecimal(dataGridView1.Rows[fecrw].Cells["cal_total"].Value);
                }
                //sub_total = grand_total;
                //txt_total.Text = sub_total.ToString();
                calculate_total();
                tax_calcu();
               
            }
        }
        decimal tax_amount;
        decimal sub_total;
        decimal service_charge=0;
        decimal static_grand_total;
        decimal taxable_amount;
        //decimal grand_total;
        public void calculate_total()
        {
            decimal sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1.Rows[i].Cells["cal_total"].Value.ToString() != "")
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                }
            }
            txt_total.Text = sum.ToString("F");
            sub_total = sum;
            tax_calcu();


        }
        public void tax_calcu()
       {
            TaxCalculation tax = new TaxCalculation();           
           
            taxable_amount = Convert.ToDecimal(sub_total);
            tax_amount = tax.tax_calculation(taxable_amount);
            txt_tax_amount.Text = tax_amount.ToString();
            static_grand_total = Convert.ToDecimal(txt_total.Text) + tax_amount + (Convert.ToDecimal(txt_delivery_charge.Text));
            txt_grand_total.Text = static_grand_total.ToString();         
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            if (txt_total.Text.Length > 0 && txt_total.Text != "")
            {
                if (txt_discount.Text.Length > 0 && txt_delivery_charge.Text.Length > 0 && txt_discount.Text.Length>0)
                {
                    txt_grand_total.Text = (Convert.ToDecimal(txt_total.Text) + Convert.ToDecimal(txt_delivery_charge.Text) - Convert.ToDecimal(txt_discount.Text)).ToString();
                }
            }
        }
        public void HomedeliveryTableNo()
        {
            DataTable dt = BLLhome.getallHomedeliveryTables();
            cbo_home_id.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["hd_no"] = "Choose Id";
                dt.Rows.InsertAt(dr, 0);
                cbo_home_id.DataSource = dt;
                cbo_home_id.DisplayMember = "hd_no";
                cbo_home_id.ValueMember = "hd_no";


            }
        }



        private void btn_save_Click(object sender, EventArgs e)
        {
            decimal total;
           
           
            if (!decimal.TryParse(txt_total.Text, out total)  || !decimal.TryParse(txt_grand_total.Text, out total) || !decimal.TryParse(txt_delivery_charge.Text, out total))
            {
                MessageBox.Show("Wrong Text Formats. Check again");
            }
            else {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataTable dt = BLLhome.getalldatabykotId(Convert.ToDecimal(Convert.ToDecimal(cbo_home_id.Text)));
                    if (dt.Rows.Count > 0)
                    {
                        printer_checker();
                        dataGridView1.Rows.Clear();
                        clearAllTextbox(this);
                        clearAllCombobox(this);
                        this.Close();
                    }
                    else
                    {
                        if (rbtn_cash.Checked)
                        {
                            int inserthomedelivery = BLLhome.inserttheDeleverystats(Convert.ToDecimal(cbo_home_id.Text), txt_customer.Text, txt_adress.Text, txt_phone.Text, Convert.ToDecimal(txt_grand_total.Text), cbo_delivery.Text, "Pending",  Convert.ToDecimal(txt_delivery_charge.Text), Convert.ToDecimal(txt_total.Text), 0, "Cash", Convert.ToDecimal(service_charge), taxable_amount, Convert.ToDecimal(tax_amount),fiscal_year,txt_discount.Text);
                            if (inserthomedelivery > 0)
                            {
                              //  int ibiza = blres.insert_into_bill_invoice(Convert.ToInt32(txtnewbillno.Text));
                                int delete_hdcustomer = BLLhome.DeleteHomedeliveryCustomer(cbo_home_id.Text);
                               // printer_checker();
                                blp_80.billing_print_only = true;
                                blp_76.billing_print_only = true;
                                printer_checker();

                                dataGridView1.Rows.Clear();
                                clearAllTextbox(this);
                                clearAllCombobox(this);
                                this.Close();
                               

                            }
                        }
                        else if (rbtn_card.Checked)
                        {
                            int inserthomedelivery = BLLhome.inserttheDeleverystats(Convert.ToDecimal(cbo_home_id.Text), txt_customer.Text, txt_adress.Text, txt_phone.Text, Convert.ToDecimal(txt_grand_total.Text), cbo_delivery.Text, "Pending", Convert.ToDecimal(txt_delivery_charge.Text), Convert.ToDecimal(txt_total.Text), 0, "Card", Convert.ToDecimal(service_charge), taxable_amount, Convert.ToDecimal(tax_amount), fiscal_year,txt_discount.Text);
                            if (inserthomedelivery > 0)
                            {
                               // int ibiza = blres.insert_into_bill_invoice(Convert.ToInt32(txtnewbillno.Text));
                                int delete_hdcustomer = BLLhome.DeleteHomedeliveryCustomer(cbo_home_id.Text);
                              //  printer_checker();
                                blp_80.billing_print_only = true;
                                blp_76.billing_print_only = true;
                                printer_checker();
                                dataGridView1.Rows.Clear();
                                clearAllTextbox(this);
                                clearAllCombobox(this);
                                this.Close();
                               
                            }
                        }
                        //else if (rbtn_zomato_pre_paid.Checked)
                        //{
                        //    if (dataGridView1.Rows.Count > 0)
                        //    {
                        //        for (int a = 0; a < dataGridView1.Rows.Count; a++)
                        //        {
                        //            string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                        //            decimal quantity = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                        //            decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                        //            decimal sub_total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                        //            string category_name1 = dataGridView1.Rows[a].Cells["cal_item_category"].Value.ToString();
                        //            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());

                        //            int b = blres.insertintosalesbook(0, date, txtcashier.Text, category_name1, cbo_home_id.Text, txt_customer.Text,txt_phone.Text, item, quantity, cost, total,"Card", "", sub_total, Convert.ToDecimal(0.00), grand_total, Convert.ToDecimal(0.00), grand_total, "HD", "", "X", service_charge, taxable_amount, tax_amount, fiscal_year, "", date, 0, a, DateTime.Now.ToString("HH:mm tt"), "False", 0, "", "", 0, "", 0);

                        //        }
                        //       // int ibiza = blres.insert_into_bill_invoice(Convert.ToInt32(txtnewbillno.Text));
                        //       // printer_checker();
                        //        blp_80.billing_print_only = true;
                        //        blp_76.billing_print_only = true;
                        //        printer_checker();
                        //        int delete_hdcustomer = BLLhome.DeleteHomedeliveryCustomer(cbo_home_id.Text);
                        //        int delete_home_no = BLLhome.deletehomedeleveryid(cbo_home_id.Text);
                        //        int delete = BLLhome.deleteHomedeliveryStatus(cbo_home_id.Text);
                        //        dataGridView1.Rows.Clear();
                        //        clearAllTextbox(this);
                        //        clearAllCombobox(this);
                        //        this.Close();
                               
                        //    }

                       // }
                    }

                }


            }
        }
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting76 blp_76 = new BillPrinting76();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        bool multi_billing_check = false;
        CheckDynamic cd = new CheckDynamic();
        public void printer_checker()
        {
            bool headerstatus = cd.QuotationHeaderPrint();
            bool Footerstatus = cd.QuotationFooterPrint();
            string Qprintername = cd.CheckPrinterName();
            DataTable dt_prt = blpst.getalldata();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80") 
                {
                    blp_80.Headerstatus = headerstatus;
                    blp_80.FooterStatus = Footerstatus;
                    blp_80.billing_print_only = true;
                    blp_80.printer_name = Qprintername;
                    bill_printing_for_80();

                }
               
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                {
                    blp_76.Headerstatus = headerstatus;
                    blp_76.FooterStatus = Footerstatus;
                    blp_76.billing_print_only = true;
                    blp_76.printer_name = Qprintername;
                    bill_printing_for_76();

                }
               
                else
                {
                    blp.Headerstatus = headerstatus;
                    blp.FooterStatus = Footerstatus;
                    blp.billing_print_only = true;
                    blp.printer_name = Qprintername;
                    blp.billing_print_only = true;
                    bill_printing_for_58();

                }
            }
        }
        public void bill_printing_for_58()
        {
         
            blp.cashier = txtcashier.Text;
            blp.cash_amount = txt_grand_total.Text;
            blp.discount = txt_discount.Text;
            blp.grand_total = txt_grand_total.Text;
            blp.sub_total = txt_total.Text;
            blp.table_no = cbo_home_id.Text;
            blp.tax_amount = tax_amount.ToString();
            blp.service_charge = service_charge.ToString();
            blp.sales_type = "HD";
            blp.billing_date = date;
            blp.fiscal_year = fiscal_year;
            blp.delivery_charge = txt_delivery_charge.Text;         
            blp.change_amount = "0.00";
            blp.customer_phone_no = txt_phone.Text;
            blp.customer_address = txt_adress.Text;        
            blp.customer_name = txt_customer.Text;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                blp.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                blp.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                blp.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                blp.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
               
            }
            blp.printtobill();
            save_after_print = blp.save_after_print;

        }
        public void bill_printing_for_76()
        {
            
            blp_76.cashier = txtcashier.Text;
            blp_76.cash_amount = Convert.ToDecimal(txt_grand_total.Text).ToString("#.##");
            blp_76.discount = Convert.ToDecimal(txt_discount.Text).ToString("#.##");
            blp_76.grand_total = Convert.ToDecimal(txt_grand_total.Text).ToString("#.##");
            blp_76.sub_total = Convert.ToDecimal(txt_total.Text).ToString("#.##");
            blp_76.table_no = cbo_home_id.Text;
            blp_76.customer_phone_no = txt_phone.Text;
            blp_76.customer_address = txt_adress.Text;
            //blp_76.customer_PAN_no = txtpan_no.Text;
            blp_76.customer_name = txt_customer.Text;
           // blp_76.discount_percent = discount_percent;
            blp_76.tax_amount = tax_amount.ToString("#.##");
            blp_76.service_charge = service_charge.ToString("#.##");
            //blp_76.area_name = area_name;
            //if (txtremainingamount.Text != "")
            //{
            //    blp_76.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            //}
            blp_76.billing_date = date;
            blp_76.taxable_amount = taxable_amount.ToString("#.##");
            blp_76.discount_sub_total = Convert.ToDecimal(sub_total).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_76.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp_76.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp_76.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp_76.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                }
                blp_76.printtobill();
                save_after_print = blp_76.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        blp_76.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        blp_76.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        blp_76.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        blp_76.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                    }
                    blp_76.printtobill();
                    save_after_print = blp_76.save_after_print;
                }
                else
                {
                    MessageBox.Show("Data Row Select", "Please Select Data Row!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error 404", "Transaction Failed! Please Do It Again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void bill_printing_for_80()
        {
          
            blp_80.cashier = txtcashier.Text;
            blp_80.cash_amount = Convert.ToDecimal(txt_grand_total.Text).ToString("#.##");
            blp_80.discount = Convert.ToDecimal(txt_discount.Text).ToString("#.##");
            blp_80.grand_total = Convert.ToDecimal(txt_grand_total.Text).ToString("#.##");
            blp_80.sub_total = Convert.ToDecimal(txt_total.Text).ToString("#.##");
            blp_80.table_no = cbo_home_id.Text;
            blp_80.customer_phone_no = txt_phone.Text;
            blp_80.customer_address = txt_adress.Text;
            blp_80.sales_type ="HD";
            blp_80.customer_name = txt_customer.Text;
            blp_80.delivery_charge = txt_delivery_charge.Text;
            blp_80.tax_amount = tax_amount.ToString("#.##");
            blp_80.service_charge = service_charge.ToString("#.##");         
            blp_80.billing_date = date;
            blp_80.taxable_amount = taxable_amount.ToString("#.##");
            blp_80.discount_sub_total = Convert.ToDecimal(sub_total).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp_80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp_80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp_80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    blp_80.datagridview_complementary.Add("");
                }
                blp_80.printtobill();
                save_after_print = blp_80.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        blp_80.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        blp_80.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        blp_80.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        blp_80.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        blp_80.datagridview_complementary.Add("");
                    }
                    blp_80.printtobill();
                    save_after_print = blp_80.save_after_print;
                }
                else
                {
                    MessageBox.Show("Data Row Select", "Please Select Data Row!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error 404", "Transaction Failed! Please Do It Again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo_home_id.Text != "Choose Id"&&cbo_home_id.Text!= "System.Data.DataRowView")
            {
                if (cbo_home_id.Text.Length > 0)
                {
                    home_delivery_id = cbo_home_id.Text;
                   
                    showall();
                    GetCustomer();
                }
            }
        }

        private void cbo_home_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal grand = 0;
                dataGridView1.Rows.Clear();
                //fetching tables name and set data to datagridview
                DataTable fetchfromHomeId = BLLhome.getDataFromKot(cbo_home_id.Text);
                if (fetchfromHomeId.Rows.Count > 0)
                {
                    for (int fecrw = 0; fecrw < fetchfromHomeId.Rows.Count; fecrw++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[fecrw].Cells["cal_item_name"].Value = fetchfromHomeId.Rows[fecrw]["item"].ToString();
                        dataGridView1.Rows[fecrw].Cells["cal_qty"].Value = fetchfromHomeId.Rows[fecrw]["quantity"].ToString();
                        dataGridView1.Rows[fecrw].Cells["cal_cost"].Value = fetchfromHomeId.Rows[fecrw]["cost"].ToString();
                        dataGridView1.Rows[fecrw].Cells["cal_total"].Value = fetchfromHomeId.Rows[fecrw]["total"].ToString();

                        grand += Convert.ToDecimal(dataGridView1.Rows[fecrw].Cells["cal_total"].Value);
                        txt_total.Text = grand.ToString();
                        
                    }
                }
                else
                {
                    MessageBox.Show("There no any Orders for " + cbo_home_id.Text + " Id.");
                }
            


            }
        }

      

        private void txt_adress_KeyDown(object sender, KeyEventArgs e)
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

        private void txt_phone_KeyDown(object sender, KeyEventArgs e)
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

        private void txt_total_KeyDown(object sender, KeyEventArgs e)
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
        private void txt_delivery_charge_KeyDown(object sender, KeyEventArgs e)
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
        private void txt_grand_total_KeyDown(object sender, KeyEventArgs e)
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
        //bool printing2nd=true;
      
        private void txt_delivery_charge_TextChanged(object sender, EventArgs e)
        {
            if (txt_delivery_charge.Text.Length > 0&&txt_delivery_charge.Text!="0"&& txt_discount.Text.Length>0)
            {
                txt_grand_total.Text =( Convert.ToDecimal(txt_total.Text) +Convert.ToDecimal(txt_tax_amount.Text) + Convert.ToDecimal(txt_delivery_charge.Text)-Convert.ToDecimal(txt_discount.Text)).ToString();
            }
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_delivery_charge_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_grand_total_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbo_customer_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_customer.Text != "Choose One" && txt_customer.Text != "System.Data.DataRowView")
            {
                DataTable dt = blcd.GetallcustomerbyId(txt_customer.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    txt_customer.Text = dt.Rows[0]["name"].ToString();
                    txt_phone.Text = dt.Rows[0]["phone"].ToString();
                    txt_adress.Text = dt.Rows[0]["address"].ToString();
                }
            }
            else
            {
                txt_customer.Text = "Choose One";
            }
        }

        private void cbo_customer_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_phone.Text != "" && txt_phone.Text != "Choose One"&& txt_customer.Text != "System.Data.DataRowView")
            {
                DataTable dt = blcd.getDataByitsPhonenumbers(txt_phone.Text);
                if (dt.Rows.Count > 0)
                {
                    txt_customer.Text = dt.Rows[0]["name"].ToString();
                    txt_phone.Text = dt.Rows[0]["phone"].ToString();
                    txt_adress.Text = dt.Rows[0]["address"].ToString();
                }
            }
            else 
            {
                txt_phone.Text = "Choose One";
            }
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        if (Convert.ToDecimal(dr.Cells["cal_qty"].Value) == 1)
                        {
                            int i = blord.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
                            decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                            //txt_grand_total.Text = (Convert.ToDecimal(txt_grand_total.Text) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value)).ToString();
                          
                            dataGridView1.Rows.Remove(dr);
                        }
                        else
                        {
                            dr.Cells["cal_qty"].Value = Convert.ToString(Convert.ToDecimal(dr.Cells["cal_qty"].Value) - 1);
                            decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value);
                            decimal quantitys = Convert.ToDecimal(dr.Cells["cal_qty"].Value);
                            decimal total = quantitys * cost;
                            dataGridView1.CurrentRow.Cells["cal_total"].Value = total;
                            int i = blord.updateorderstable(quantitys, Convert.ToInt32(dr.Cells["cal_order_id"].Value), total);
                           // txt_grand_total.Text = (Convert.ToDecimal(txt_grand_total.Text) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value)).ToString();
                          // txt_grand_total.Text = (Convert.ToDecimal(txt_grand_total.Text) - (cost)).ToString();

                           
                        }
                    }
                    calculate_total();
                }
                else
                {
                    MessageBox.Show("Please Select Row First");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                  
                    if (dt.Rows.Count > 0)
                    {

                        //Cancel_emo canemo = new Cancel_emo();
                        //canemo.ShowDialog();
                        //emo_desc = Cancel_emo.emo_text;
                        foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                        {
                            if (dr.Cells["calkot_print"].Value.ToString() == "K1")
                            {
                                kot_cancel_1 = true;
                            }
                            else if (dr.Cells["calkot_print"].Value.ToString() == "K2")
                            {
                                kot_cancel_2 = true;
                            }
                        }

                        if (kot_cancel_1 == true)
                        {
                            printcalcel();
                        }
                        if (kot_cancel_2 == true)
                        {
                            printcalcel2();
                        }
                        foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                        {
                            string item_name = dr.Cells["cal_item_name"].Value.ToString();
                            decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                            decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                            decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                            string category_name = dr.Cells["cal_item_category"].Value.ToString();
                            string kot_print = dr.Cells["calkot_print"].Value.ToString();
                            DateTime todaydate = DateTime.Now;
                            string time = DateTime.Now.ToShortTimeString();
                            decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                           txt_grand_total.Text = (Convert.ToDecimal(txt_grand_total.Text) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();                      
                            int i = blord.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
                            int j = blkot.cancel_update(Convert.ToInt32(dr.Cells["cal_order_id"].Value), "cancel");
                            int bocs = boc.insertordercancellation(txt_customer.Text, Convert.ToDecimal(cbo_home_id.Text), item_name, quantity, total, cost, "No", category_name, kot_print, txt_phone.Text, DateTime.Now, "emo_desc", "TS");
                            dataGridView1.Rows.Remove(dr);
                            calculate_total();
                        }

                    }
                    else
                    {
                        foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                        {
                            dataGridView1.Rows.Remove(dr);
                            calculate_total();
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void printcalcel()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "K1";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1calcel_PrintPage);
            

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

        private void printDocument1calcel_PrintPage(object sender, PrintPageEventArgs e)
        {

            string table_no;
            table_no = home_delivery_id;
            float xs = 10;
            float ys = 5;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F;
            float heights = 0F;
            DataTable dtm = blu.checkbusiness();
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, FontStyle.Regular);
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


            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();

            Graphics gra = e.Graphics;
            String strDate = DateTime.Now.ToLongTimeString();
            gra.DrawString(strDate, new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 60);
            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            if (business_name.Length >= 30)
            {
                ybinc = 13;
            }
            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            if (address.Length >= 40)
            {
                yinc = 10;
            }
          
                    gra.DrawString("Home Delivery ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, 60 + ybinc + yinc);
                    gra.DrawString(home_delivery_id, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 60 + ybinc + yinc);
               
              

            gra.DrawLine(drawingPen, 10, 75 + ybinc + yinc, 309, 75 + ybinc + yinc);
            gra.DrawString("Item", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 75 + ybinc + yinc);
            gra.DrawString("Qty", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 75 + ybinc + yinc);
            gra.DrawLine(drawingPen, 10, 90 + ybinc + yinc, 309, 90 + ybinc + yinc);
            int y;
            y = 100 + ybinc + yinc;

          
                if (button_cancelAll == true)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["calkot_print"].Value.ToString() == "K1")
                        {
                            string item_name = row.Cells["cal_item_name"].Value.ToString();
                            string quantity = row.Cells["cal_qty"].Value.ToString();

                            DataTable dt = blu.checkbusiness();
                            if (dt.Rows[0]["language"].ToString() == "Arabic")
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                            }
                            else
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                            }
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);

                            y = y + 15;
                        }
                    else if (row.Cells["calkot_print"].Value.ToString() == "K2")
                    {
                        string item_name = row.Cells["cal_item_name"].Value.ToString();
                        string quantity = row.Cells["cal_qty"].Value.ToString();
                        DataTable dt = blu.checkbusiness();
                        if (dt.Rows[0]["language"].ToString() == "Arabic")
                        {
                            gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                        }
                        else
                        {
                            gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                        }
                        gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);
                        y = y + 15;
                    }
                }
                }

                else
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                    if (row.Cells["calkot_print"].Value.ToString() == "K1")
                    {
                        string item_name = row.Cells["cal_item_name"].Value.ToString();
                        string quantity = row.Cells["cal_qty"].Value.ToString();

                        DataTable dt = blu.checkbusiness();
                        if (dt.Rows[0]["language"].ToString() == "Arabic")
                        {
                            gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                        }
                        else
                        {
                            gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                        }
                        gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);

                        y = y + 15;
                    }

                    else if (row.Cells["calkot_print"].Value.ToString() == "K2")
                        {
                            string item_name = row.Cells["cal_item_name"].Value.ToString();
                            string quantity = row.Cells["cal_qty"].Value.ToString();
                            DataTable dt = blu.checkbusiness();
                            if (dt.Rows[0]["language"].ToString() == "Arabic")
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                            }
                            else
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                            }
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);
                            y = y + 15;
                        }
                    }
                }
            


            int z = y + 20;
            gra.DrawLine(drawingPen, 10, z, 309, z);
            gra.DrawString("Description", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, z + 5);
            gra.DrawString("Cancel", new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, z + 20);
            z = y + 20;
            kot_cancel_1 = false;
        }
        public void printcalcel2()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "K2";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1calcel_PrintPage2);

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
        private void printDocument1calcel_PrintPage2(object sender, PrintPageEventArgs e)
        {

            string table_no;
            table_no = home_delivery_id;
            float xs = 10;
            float ys = 5;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F;
            float heights = 0F;
            DataTable dtm = blu.checkbusiness();
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, FontStyle.Regular);
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


            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();

            Graphics gra = e.Graphics;
            String strDate = DateTime.Now.ToLongTimeString();
            gra.DrawString(strDate, new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 60);
            gra.DrawString(strDate, new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 60);
            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            if (business_name.Length >= 30)
            {
                ybinc = 13;
            }
            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            if (address.Length >= 40)
            {
                yinc = 10;
            }
           
                    gra.DrawString("Home Delivery ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, 60 + ybinc + yinc);
                    gra.DrawString(home_delivery_id, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 60 + ybinc + yinc);
               
            gra.DrawLine(drawingPen, 10, 75 + ybinc + yinc, 309, 75 + ybinc + yinc);
            gra.DrawString("Item", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, 75 + ybinc + yinc);
            gra.DrawString("Qty", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, 75 + ybinc + yinc);
            gra.DrawLine(drawingPen, 10, 90 + ybinc + yinc, 309, 90 + ybinc + yinc);
            int y;
            y = 95 + ybinc + yinc;

           
                if (button_cancelAll == true)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["calkot_print"].Value.ToString() == "K2")
                        {
                            string item_name = row.Cells["cal_item_name"].Value.ToString();
                            string quantity = row.Cells["cal_qty"].Value.ToString();
                            DataTable dt = blu.checkbusiness();
                            if (dt.Rows[0]["language"].ToString() == "Arabic")
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                            }
                            else
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                            }
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);

                            y = y + 15;
                        }
                    }
                }

                else
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (row.Cells["calkot_print"].Value.ToString() == "K1")
                        {
                            string item_name = row.Cells["cal_item_name"].Value.ToString();
                            string quantity = row.Cells["cal_qty"].Value.ToString();
                            DataTable dt = blu.checkbusiness();
                            if (dt.Rows[0]["language"].ToString() == "Arabic")
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("ArabicNaskhSSK", 8, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 200, y - 5, format);
                            }
                            else
                            {
                                gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 10, y);

                            }
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 250, y);
                            y = y + 15;
                        }
                    }
                }
            


            int z = y + 20;
            gra.DrawLine(drawingPen, 10, z, 309, z);
            gra.DrawString("Description", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, z + 5);
            gra.DrawString("Cancel", new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, z + 20);
            z = y + 20;
            kot_cancel_2 = false;
        }
      

        private void btnaadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DialogResult dig = MessageBox.Show("Are You Sure To Delete All Items?", "Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dig == DialogResult.Yes)
                    {
                        DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));

                        if (home_delivery_id.Length > 0)
                        {
                            //Cancel_emo canemo = new Cancel_emo();
                            //canemo.ShowDialog();
                            //emo_desc = Cancel_emo.emo_text;
                            button_cancelAll = true;
                            foreach (DataGridViewRow dr in dataGridView1.Rows)
                            {
                                if (dr.Cells["calkot_print"].Value.ToString() == "K1")
                                {
                                    kot_cancel_1 = true;
                                }
                                else if (dr.Cells["calkot_print"].Value.ToString() == "K2")
                                {
                                    kot_cancel_2 = true;
                                }
                            }
                            if (kot_cancel_1 == true)
                            {
                                printcalcel();
                            }
                            if (kot_cancel_2 == true)
                            {
                                printcalcel2();
                            }
                            int i = blord.deletefromtable(Convert.ToDecimal(home_delivery_id));
                            if (i > 0)
                            {
                                int delete_home_no = BLLhome.deletehomedeleveryid(home_delivery_id);
                                int deletehomedelevery = BLLhome.deletehomedeleveryvalue(Convert.ToDecimal(cbo_home_id.Text));
                                foreach (DataGridViewRow dr in dataGridView1.Rows)
                                {
                                    string item_name = dr.Cells["cal_item_name"].Value.ToString();
                                    decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                                    decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                                    decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                                    string category_name = dr.Cells["cal_item_category"].Value.ToString();
                                    string kot_print = dr.Cells["calkot_print"].Value.ToString();
                                    DateTime todaydate = DateTime.Now;
                                    string time = DateTime.Now.ToShortTimeString();
                                    decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                                    txt_grand_total.Text = (Convert.ToDecimal(txt_grand_total.Text) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();
                                    int bocs = boc.insertordercancellation(txt_customer.Text, Convert.ToDecimal(home_delivery_id), item_name, quantity, total, cost, "No", category_name, kot_print, txt_phone.Text, DateTime.Now, "emo_desc", "TS");

                                }

                            }
                            HomedeliveryTableNo();
                            dataGridView1.Rows.Clear();

                        }

                    }
                }
                    txt_grand_total.Text = "0.00";
                    txt_total.Text = "0.00";
                txt_discount.Text = "0.00";
                txt_delivery_charge.Text = "0.00";                           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
      
        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
      {
            user_access_check = AdminAccess.discount_access_value;
            if (user_access_check != true)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
            }
            if (user_access_check == true)
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
            else
            {

                e.Handled = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt_delivery_charge_Enter(object sender, EventArgs e)
        {
            if (txt_delivery_charge.Text == "0.00")
            {
                txt_delivery_charge.Text = "";
            }
        }

        private void txt_delivery_charge_Leave(object sender, EventArgs e)
        {
            if (txt_delivery_charge.Text == "")
            {
                txt_delivery_charge.Text = "0.00";
            }
        }
        VoidModel vm = new VoidModel();
        public static string orderstatus="";
        //bool void_status = Billing.void_status;
        private void btn_add_Click(object sender, EventArgs e)
        {
           // orderstatus = "HD";
            //if (Application.OpenForms.OfType<AddItemForVoid>().Count() == 1)
            //    Application.OpenForms.OfType<AddItemForVoid>().First().Close();
            AddItemForVoid siv = new AddItemForVoid("HD");
                siv.ShowDialog();
                if (VoidModel.item_name.Count > 0)
                {
                    for (int i = 0; i < VoidModel.item_name.Count; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        dataGridView1.Rows[abc].Cells["cal_item_name"].Value = VoidModel.item_name[i];
                        dataGridView1.Rows[abc].Cells["cal_qty"].Value = VoidModel.qty[i];
                        dataGridView1.Rows[abc].Cells["cal_total"].Value = VoidModel.total[i];
                        dataGridView1.Rows[abc].Cells["cal_cost"].Value = VoidModel.cost[i];
                        dataGridView1.Rows[abc].Cells["cal_item_category"].Value = VoidModel.category_name[i];
                        dataGridView1.Rows[abc].Cells["calkot_print"].Value = VoidModel.kot_type[i];
                     
                }
                calculate_total();

                }

            }

        private void btntable_transfer_Enter(object sender, EventArgs e)
        {

        }
    }
    }
   
  
    

