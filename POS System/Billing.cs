using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLLS;
using System.Runtime.InteropServices;
using POS_System.IRT;
using POS_System.Void;
using POS_System.Printing_Billing;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using POS_System.FonePayApi;
using BLLS.bakery;
using POS_System.CustomerLoyalty;

namespace POS_System
{
    public partial class Billing : UserControl
    {
        public Billing(string table_no, string tablename)
        {
            table_no2 = table_no;
            Gettablename = tablename;
            InitializeComponent();
            txtcardamount.Text = "0.00";
            this.txtcardamount.Leave += new System.EventHandler(this.txtcardamount_Leave);
            this.txtcardamount.Enter += new System.EventHandler(this.txtcardamount_Enter);
            txtcashamount.Text = "0.00";
            this.txtcashamount.Leave += new System.EventHandler(this.txtcashamount_Leave_1);
            this.txtcashamount.Enter += new System.EventHandler(this.txtcashamount_Enter);
            //KeyDown += new KeyEventHandler(Billing_KeyDown);
            foreach (TextBox tb in containpanel.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }
        int customer_id = 0;
        string table_no2;
        string Gettablename;
        bool save_after_print;
        decimal subtotal_with_services;
        string discount_amount = "0.00";
        BLLBill_printing blps = new BLLBill_printing();
        BLLCategory bllcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blord = new BLLOrder();
        BLLUser blu = new BLLUser();
        BLLRestSell blresll = new BLLRestSell();
        Button newPanelcategory = new Button();
        BLLKotDisplay bllkot = new BLLKotDisplay();
        Bll_allJournal_Lists allaclists = new Bll_allJournal_Lists();
        BLLTakeAway bltak = new BLLTakeAway();
        Bll_cashcounter blcas = new Bll_cashcounter();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLcustomer_credit blc_credit = new BLLcustomer_credit();
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting76 blp_76 = new BillPrinting76();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        DateTime datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLdiscount bld = new BLLdiscount();
        Button btn_area = new Button();
        Button btn_customer = new Button();
        BLLTable_Area blarea = new BLLTable_Area();
        BLLTable bltab = new BLLTable();
        BLLDynamic bldd = new BLLDynamic();
        BLL_Login_logout bllgin = new BLL_Login_logout();
        IRT.IRTAPI apir = new IRT.IRTAPI();
        BllBakeryOrder blbo = new BllBakeryOrder();
        BLLLoyalty blloy = new BLLLoyalty();
        string fiscal_year;
        string fiscal_year_status;
        bool club_card_balance = false;
        bool multi_billing_check = false;
        PictureBox userpicbox = new PictureBox();
        string payment_mode = "Cash";
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
        decimal service_charge = 0;
        bool save_data = false;
        public string area_name = "";
        public static int area_id = 0;
        Label[] lbl_table_name = new Label[99];
        string QuotationName;
        bool QuotationAccess;
        decimal Abbreviatedtax;
        bool AbbreviatedtaxEnable;
        bool customer_settlement;
        string ird_username;
        string ird_password;
        string loyalty_type;
        int customer_details;
        private void Billing_Load(object sender, EventArgs e)
        {

            //chk_fone_pay.Hide();
            groupBox2.Show();
            label15.Show();
            txtcardamount.Show();
            QuotationAccess = second_user_interface.QuotationAccess;
            QuotationName = second_user_interface.QuotationName;
            Abbreviatedtax = cd.CheckabbreviatedTaxAmount();
            AbbreviatedtaxEnable = cd.CheckabbreviatedTax();
            customer_settlement = cd.CheckCustomerSettlement();
            loyalty_type = cd.LoyaltyPoint();
            if (QuotationAccess == true)
            {
                btn_order_quotation.Visible = true;
                btn_order_quotation.Text = QuotationName;
            }
            else
            {
                btn_order_quotation.Visible = false;
            }
            if (customer_settlement==false)
            {
                btn_settlement.Visible = false;
               
            }
          
            DataTable dt1 = bllgin.GetIrdInfo();
            if (dt1.Rows.Count > 0)
            {
                ird_password = Encryption.StringEncryption.Decrypt(dt1.Rows[0]["password"].ToString(), "sblw-3hn8-sqoy19");
                ird_username = dt1.Rows[0]["username"].ToString();
            }
            dateConvertToNepali();
           
            lbltable.Text = table_no2;
           
            ComplementryInvoiceNo();
            userpicbox.Image = global::POS_System.Properties.Resources.url;
           
            DataTable dt_table = bltab.chheck_table_info(lbltable.Text);
            if (dt_table.Rows.Count > 0)
            {
                area_id = Convert.ToInt32(dt_table.Rows[0]["area_id"]);
                if (area_id > 0)
                {
                    DataTable dt_area = bltab.Get_Data_ByAreaId(area_id);
                    if (dt_area.Rows.Count > 0)
                    {
                        area_name = dt_area.Rows[0]["area_name"].ToString();
                    }
                }
            }

            //fiscal year
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
                fiscal_year_status = dt.Rows[0]["is_active"].ToString();
            }
            // area_button();
            tabletuch();
            user_access_check = false;
         
            txtcashier.Text = Login.sendtext;
            if (cd.BusinessType() == "Bakery")
            {
                DataTable dtb = blbo.get_all_rest_table_info(Gettablename);
                customertouch(dtb);
                DataTable dtm = blbo.getallKOTdata(table_no2, Gettablename);
                datagridviewload(dtm);
                if (dtm.Rows.Count > 0)
                {
                    cbo_customer_name.Text = (dtm.Rows[0]["name"] + " " + dtm.Rows[0]["lastname"]);
                }
                DataTable dtc = blbo.GetAllDataFromOrderDetails(table_no2, Gettablename);
                if (dtc.Rows.Count > 0)
                {
                    lbl_advance_amount.Text = dtc.Rows[0]["advance_amount"].ToString();
                  
                }
                else
                {
                    lbl_advance_amount.Text = "0.00";
                }
            }
            else
            {
                if (Convert.ToDecimal(lbltable.Text) >= 1000)
                {
                    lbl_table_no_2.Text = "TA " + Gettablename;
                    lbltable.Hide();
                    take_away();
                  
                }
                else if ((Convert.ToDecimal(lbltable.Text) <= 99))
                {
                    area_button();
                   
                }
                DataTable dtm = blord.getalldata(Convert.ToDecimal(lbltable.Text));
                datagridviewload(dtm);
            }
            bill();
            panel3.Show();
            customer_details = Customer_Management.AllCusomterList.customer_details;
            if (customer_details > 0)
            {
                cbo_customer_name.SelectedValue = customer_details;
            }
            else
            {
                CUstomer_name();
                CUstomer_number();
            }
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
            txtcashamount.Focus();
            AdvanceDiscount();
            BillingbuttonAccess();
        }
        public void BillingbuttonAccess()
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["billing"].ToString() == "True")
                    {
                        btn_x_save_only.Visible = true;
                        btn_x_billing.Visible = true;
                        buttonX2.Visible = true;
                    }
                    else
                    {
                        btn_x_save_only.Visible = false;
                        btn_x_billing.Visible = false;
                        buttonX2.Visible = false;
                    }
                }
            }
        }
        string nepaliDateConvert;
        public void dateConvertToNepali()
        {
            NepaliDateConverter.DateConverter dp = new NepaliDateConverter.DateConverter();
            var nepalidate = dp.EngToNep(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")));
            string nyear = nepalidate.ConvertedDate.Year.ToString();
            string nday = nepalidate.ConvertedDate.Day.ToString();
            string nmonths = nepalidate.ConvertedDate.Month.ToString();
            nepaliDateConvert = nyear + ".0" + nmonths + "." + nday;
        }
        public void AdvanceDiscount()
        {
            DataTable dt = bld.ad_tableNoCheck(lbltable.Text);
            if (dt.Rows.Count > 0)
            {

                discount_percent = dt.Rows[0]["discount_percent"].ToString();
                decimal discountInAmount = ((Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(discount_percent)) / 100);
                lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - discountInAmount).ToString();
                discount_amount = discountInAmount.ToString();
                lbldiscount.Text = discount_amount;
                tax_calcu();
                cashamount_recived_amount();
                if (chk_club_card.Checked)
                {
                    txtcardamount.Text = txtgrandtotal.Text;
                }
            }
        }
        LoyaltyPoints lp = new LoyaltyPoints();
        int customer_points=0;
        public void LoyalityPointCalculation()
        {
            if (loyalty_type == "AMT")//customer loyalty point calculation amount wise
            {
                customer_points = lp.amountpointCalculation(Convert.ToDecimal(txtgrandtotal.Text));
            }
            
        }
        public void area_button()
        {
            DataTable dt = blarea.get_all_data();
            if (customer_settlement == true)
            {
                dt.Rows.Add(0,"Customer");
            }
                flowLayoutPanel2.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    btn_area = new Button();
                    btn_area.Text = dt.Rows[x]["area_name"].ToString();
                    btn_area.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(50, 50));
                    btn_area.Name = dt.Rows[x]["area_id"].ToString();
                    btn_area.Size = new System.Drawing.Size(63, 71);
                    btn_area.ForeColor = Color.White;
                    btn_area.FlatStyle = FlatStyle.Flat;
                    btn_area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
                    btn_area.FlatAppearance.BorderSize = 0;
                    btn_area.Click += new System.EventHandler(this.btn_area_click);
                    flowLayoutPanel2.Controls.Add(btn_area);
                    btn_area.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                }
            }
            
               
        }
        private void btn_area_click(object sender, EventArgs e)
        {
            area_name = (((Button)sender).Text).ToString();
            if (area_name == "Customer")
            {
                btn_settlement.Enabled = false;
                dataGridView1.Rows.Clear();
                DataTable dt = blcd.getallcustomersettlement();
                customertouch(dt);
            }
            else
            {
                area_id = Convert.ToInt32((((Button)sender).Name).ToString());
                if (area_id > 0)
                {
                    btn_settlement.Enabled = true;
                    dataGridView1.Rows.Clear();
                    tabletuch();
                }
            }
        }
        Button[] newtable = new Button[99];
        public void tabletuch()
        {
            flow_table_panel.Controls.Clear();
            DataTable dt = bltab.get_all_rest_table_info(area_id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbl_table_name[i] = new Label();
                lbl_table_name[i].Text = dt.Rows[i]["rest_table_no"].ToString();
                lbl_table_name[i].Location = new Point(50, 65);
                lbl_table_name[i].ForeColor = Color.Black;
                newtable[i] = new Button();
                newtable[i].Name = dt.Rows[i]["rest_table_no"].ToString();
                newtable[i].Text = (dt.Rows[i]["rest_table_name"]).ToString();
                int rest_table_no = Convert.ToInt32(dt.Rows[i]["rest_table_no"].ToString());
                Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject("Large");
                newtable[i].Size = new System.Drawing.Size(120, 80);
                Bitmap resizeds = new Bitmap(images, new Size(120, 60));
                newtable[i].Image = resizeds;
                newtable[i].BackColor = Color.Transparent;
                newtable[i].FlatAppearance.BorderSize = 0;
                newtable[i].ForeColor = Color.White;
                newtable[i].FlatStyle = FlatStyle.Flat;
                newtable[i].ImageAlign = ContentAlignment.MiddleLeft;
                newtable[i].TextAlign = ContentAlignment.MiddleCenter;
                newtable[i].Font = new Font("Times New Roman", 10, FontStyle.Bold);
                DataTable dtms = blord.getallfromtblorder(rest_table_no);
                if (dtms.Rows.Count > 0)
                {
                    Bitmap images_order = global::POS_System.Properties.Resources.Large_21;
                    newtable[i].Size = new System.Drawing.Size(120, 80);
                    Bitmap resize = new Bitmap(images_order, new Size(120, 60));
                    newtable[i].Image = resize;
                }
                DataTable dtQu = blpst.GetAllQuotationByTableNO(rest_table_no.ToString());
                if (dtQu.Rows.Count > 0)
                {
                    Bitmap images_order = global::POS_System.Properties.Resources.LargeGreen;
                    newtable[i].Size = new System.Drawing.Size(120, 80);
                    Bitmap resize = new Bitmap(images_order, new Size(120, 60));
                    newtable[i].Image = resize;
                }
                newtable[i].Controls.Add(lbl_table_name[i]);
                flow_table_panel.Controls.Add(newtable[i]);
                newtable[i].Click += new EventHandler(newtable_Click);
                flow_table_panel.AutoScroll = true;


            }

        }
       
        public void customertouch(DataTable dt)
        {
            flow_table_panel.Controls.Clear();
          
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                btn_customer = new Button();
                btn_customer.Text = dt.Rows[x]["name"].ToString() +" "+ dt.Rows[x]["id"].ToString(); ;
                btn_customer.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(50, 50));
                customer_id= Convert.ToInt32(dt.Rows[x]["id"].ToString());
                btn_customer.Name = dt.Rows[x]["id"].ToString();
                btn_customer.Size = new System.Drawing.Size(110, 50);
                btn_customer.ForeColor = Color.White;
                btn_customer.FlatStyle = FlatStyle.Flat;
                btn_customer.BackColor = System.Drawing.Color.Chocolate;
                //DataTable dtms = blord.getallfromcustomerorder(customer_id);
                //if (dtms.Rows.Count > 0)
                //{
                //    btn_customer.BackColor = System.Drawing.Color.Lime;
                //}
                btn_customer.FlatAppearance.BorderSize = 0;
                flow_table_panel.Controls.Add(btn_customer);
                btn_customer.Click += new System.EventHandler(this.btn_customer_click);
                
                btn_customer.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            }

        }
        string customer_no;
        bool settlement;
      
        public void take_away()
        {
            flow_table_panel.Controls.Clear();
            DataTable dt = bltak.getallvaluesfromtable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button newtable = new Button();
                newtable.Name = dt.Rows[i]["take_away_id"].ToString();
                newtable.Text = "TA" + " " + dt.Rows[i]["take_away_id"].ToString();
                newtable.Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(100, 100));// here make use of your logic.
                newtable.Height = 60;
                newtable.Width = 130;
                newtable.FlatStyle = FlatStyle.Flat;
                newtable.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                flow_table_panel.Controls.Add(newtable);
                newtable.BackColor = Color.Chocolate;
                newtable.ForeColor = Color.White;
                newtable.Click += new EventHandler(newtakeaway_Click);
                flow_table_panel.AutoScroll = true;
            }
        }

        private void newtakeaway_Click(object sender, EventArgs e)
        {
            lbltable.Text = ((Button)sender).Name;
            lbltable.Hide();
            lbl_table_no_2.Text = ((Button)sender).Text;
            bill();
          
                DataTable dt = blord.getalldata(Convert.ToDecimal(lbltable.Text));
                datagridviewload(dt);
           
        }
        private void newtable_Click(object sender, EventArgs e)
        {
            string table_id;
            table_id = ((Button)sender).Name;
            lbltable.Text = table_id.ToString();
           
             DataTable dt = blord.getalldata(Convert.ToDecimal(lbltable.Text));
             datagridviewload(dt);
            
            bill();
            AdvanceDiscount();
        }

        public void btn_customer_click(object sender, EventArgs e)
        {
            //settlement = true;
            customer_no = ((Button)sender).Name;
           
           
            if (cd.BusinessType() == "Bakery")
            {
                lbltable.Text = customer_no;
                table_no2 = customer_no;
                DataTable dtm = blbo.getallKOTdata(customer_no, Gettablename);//table_no2 is kot_id for bakery and gettablename is for service_type for bakery
                datagridviewload(dtm);
                if (dtm.Rows.Count > 0)
                {
                    cbo_customer_name.Text = (dtm.Rows[0]["name"]+" "+ dtm.Rows[0]["lastname"]);
                }
                DataTable dtc = blbo.GetAllDataFromOrderDetails(table_no2, Gettablename);
                if (dtc.Rows.Count > 0)
                {
                    lbl_advance_amount.Text = dtc.Rows[0]["advance_amount"].ToString();
                }
                else
                {
                    lbl_advance_amount.Text = "0.00";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt = blord.GetCusotmerOrder(Convert.ToInt32(customer_no));
                datagridviewload(dt);
                DataTable dtms = blord.getallfromcustomerorder(Convert.ToInt32(customer_no));
                if (dtms.Rows.Count > 0)
                {
                    cbo_customer_name.Text = ((Button)sender).Text;
                }
                else
                {
                    CUstomer_name();
                    CUstomer_number();
                }

            }
            bill();
          

        }
        public void CUstomer_name()
        {
            DataTable dt = blcd.getallcustomersPhoneNoName();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_customer_name.DataSource = dt;
                cbo_customer_name.DisplayMember = "name";
                cbo_customer_name.ValueMember = "id";
            }
            else
            {
                cbo_customer_name.DisplayMember = "";
                cbo_customer_name.ValueMember = "";
            }
        }
        public void CUstomer_number()
        {
            DataTable dt = blcd.getallcustomersPhoneNoName();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["phone"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_customer_no.DataSource = dt;
                cbo_customer_no.DisplayMember = "phone";
                cbo_customer_no.ValueMember = "id";
            }
        }
        public void bill()
        {
            DataTable dt = blresll.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    txtnewbillno.Text = "1";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    txtnewbillno.Text = getinvoiceno.ToString();
                }
            }
        }
        int complementryInvoiceNo;
        public void ComplementryInvoiceNo()
        {
            DataTable dt = blcomp.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    complementryInvoiceNo = 1;
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    complementryInvoiceNo = getinvoiceno;
                }
            }
        }
        string service_provider;
        string serviceList;
        public void datagridviewload(DataTable dt)
        {
          
            dataGridView1.Rows.Clear();
            service_provider = "";

            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    int abc = dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["cal_kot_type"].Value = dt.Rows[z]["kot_print"].ToString();
                    dataGridView1.Rows[z].Cells["cal_sales_type"].Value = dt.Rows[z]["sales_type"].ToString();//database column phone is use for sales type 
                    dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";
                    if (dt.Rows[z]["service_provider"].ToString() != "" && dt.Rows[z]["service_provider"] != DBNull.Value)
                    {
                        dataGridView1.Rows[z].Cells["cal_service_provider"].Value = dt.Rows[z]["service_provider"].ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[z].Cells["cal_service_provider"].Value = "";
                    }
                    dataGridView1.Rows[z].Cells["cal_kot_id"].Value = dt.Rows[z]["kot_id"].ToString();
                    serviceList += dt.Rows[z]["service_provider"].ToString() + "  ";
                    if (loyalty_type == "IW")//customer loyalty point calculation item wise
                    {
                        customer_points += lp.itemPointCalculation(dt.Rows[z]["item"].ToString(),Convert.ToDecimal(dt.Rows[z]["quantity"]));
                    }
                }
                calculate_total();
                this.Refresh();
                CUstomer_name();
                CUstomer_number();
                AdvancePayment();
                txtpan_no.Text = "";
                service_provider = String.Join(" ", serviceList.Split(' ').Distinct());
                serviceList = "";
            }

            back_screan();
        }
       
        TaxCalculation tax = new TaxCalculation();
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
            if (Abbreviatedtax < sum && AbbreviatedtaxEnable == true)
            {
                txtgrandtotal.Text = sum.ToString("F");
                abbGrandTotal = sum;
                abbTaxCalculate();
            }
            else
            {

                txtsubtotal.Text = sum.ToString("F");
                lblsub_total.Text = sum.ToString("F");
                tax_calcu();
                adss.txt_discount_amount.Text = "0.00";
                adss.txt_discount_percent.Text = "0.00";
                adss.discount_amount = 0;
                adss.discount_amount_percent = 0;
                lbldiscount.Text = "0.00";
            }

            LoyalityPointCalculation();
        }

        public void AdvancePayment()
        {
            txtcashamount.Text = "0.00";
            txtcashamount.BackColor = System.Drawing.Color.White;
            DataTable dt = blcd.GetAdvancePay(lbltable.Text);
            if (dt.Rows.Count > 0)
            {
                txtcashamount.Text = dt.Rows[0]["received_amount"].ToString();
                txtremainingamount.Text = (Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtcashamount.Text)).ToString();
                txtcashamount.BackColor = System.Drawing.Color.Red;
                // txtremainingamount.Text = "0.00";
            }
        }
        decimal abbGrandTotal;
        public void abbTaxCalculate()
        {
            decimal abbtaxamount = tax.IncludingtaxCalculation(abbGrandTotal);
            decimal abbtaxableamount = abbGrandTotal - abbtaxamount;
            subtotal_with_services = abbtaxableamount;
            lbl_tax.Text = abbtaxamount.ToString("F");
            decimal abbserviceCharge = tax.IncludingserviceChargeCalculation(abbtaxableamount);
            decimal abbseviceamount = abbtaxableamount - abbserviceCharge;
            lbl_service_charge.Text = abbserviceCharge.ToString("F");
            lblsub_total.Text = (abbGrandTotal - abbtaxamount - abbserviceCharge).ToString("F");
            txtsubtotal.Text = lblsub_total.Text;
            tax_amount = abbtaxamount;
        }
        bool service_status;
        decimal abbrevated_taxAmount;

        public void tax_calcu()
        {

            if (lblsub_total.Text != "")
            {

                DataTable dttable = bldd.GetServiceTable();
                DataTable dttakeaway = bldd.GetServiceTakeaway();

                if (Convert.ToDecimal(lbltable.Text) < 1000)
                {

                    service_status = cd.TableServiceCharge();
                    if (service_status == true)
                    {
                        if (dttable.Rows.Count > 0)
                        {
                            service_charge = tax.service_calculation(Convert.ToDecimal(lblsub_total.Text));
                        }
                    }


                }
                subtotal_with_services = (Convert.ToDecimal(lblsub_total.Text) + service_charge);
                if (AbbreviatedtaxEnable == true)
                {
                    if (Abbreviatedtax < subtotal_with_services)
                    {
                        tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                    }
                    else
                    {
                        abbrevated_taxAmount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                    }
                }
                else
                {
                    tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                }
                static_grand_total = subtotal_with_services + tax_amount;
                txtgrandtotal.Text = static_grand_total.ToString("F");
                lbl_tax.Text = tax_amount.ToString("F");
                lbl_service_charge.Text = service_charge.ToString("F");
                if (Convert.ToDecimal(lbltable.Text) > 1000)
                {
                    service_status = cd.TakeAwayServiceCharge();
                    if (service_status == true)
                    {
                        if (dttakeaway.Rows.Count > 0)
                        {
                            service_charge = tax.service_calculation(Convert.ToDecimal(lblsub_total.Text));
                        }
                    }
                    // lbl_service_charge.Text = "0.00";
                }
                if (lbl_service_charge.Text == "")
                {
                    lbl_service_charge.Text = "0.00";
                }
                if (lbl_tax.Text == "")
                {
                    lbl_tax.Text = "0.00";
                }
            }
            else
            {
                lblsub_total.Text = "0.00";
                txtgrandtotal.Text = "0.00";
                lbl_tax.Text = "0.00";
                lbl_service_charge.Text = "0.00";
                txtsubtotal.Text = "0.00";
            }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (void_status == true)
                {

                    if (dgvColumnId >= 0)
                    {
                        dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) + 1;
                        if (Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) > 0)
                        {
                            dataGridView1.Rows[dgvColumnId].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_cost"].Value);
                            calculate_total();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please choose the data first.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This button will only enable on bill void mode.", "Invalid button", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }


        public void save_and_print()
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {

                if (!decimal.TryParse(lbltable.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                else if (txtsubtotal.Text.Length > 0 && dataGridView1.Rows.Count > 0 || txtcardamount.Text != "0.00" || txtcashamount.Text != "0.00")
                {

                    if (chkcash.Checked)
                    {
                        if (Convert.ToDecimal(donation_amount) > 0)
                        {
                            if (Convert.ToDecimal(donation_amount) + Convert.ToDecimal(txtgrandtotal.Text) > Convert.ToDecimal(txtcashamount.Text))
                            {
                                MessageBox.Show("Can't Complete The Transaction, Donation Amount and Billing Amount Is Low", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text))
                        {

                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Can't Complete The Transaction, Cash Amount Is  Low", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (chkcard.Checked || chk_fone_pay.Checked)
                    {
                        if ((Convert.ToDecimal(txtcardamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text)))
                        {

                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (chk_cheque.Checked)
                    {
                       
                        if ((Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text)))
                        {

                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (chk_club_card.Checked)
                    {
                        if (club_card_balance == true)
                        {


                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (chkcredit.Checked)
                    {
                        if (cbo_customer_name.SelectedIndex > 0 && cbo_customer_name.Text != "")
                        {
                            
                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Select Customers While Billing in Credit.", "Customer Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else if (chkcash_card.Checked)
                    {
                        if ((Convert.ToDecimal(txtcardamount.Text)+ Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text)))
                        {
                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else 
                    if (chk_cash_credit.Checked)
                    {
                        if (cbo_customer_name.SelectedIndex > 0 && cbo_customer_name.Text != "")
                        {
                            printer_checker();
                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Select Customers While Billing in Credit.", "Customer Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    if (save_only_trasaction == true)
                    {
                        if (save_after_print == true)
                        {
                            billing_save_with_multi();
                            if (save_data == true)
                            {

                                if (Convert.ToDecimal(lbltable.Text) >= 1000)
                                {


                                    take_away();
                                }

                                else
                                {
                                    tabletuch();
                                }

                            }
                            back_screan();
                            blp.save_after_print = false;
                        }
                    }
                }
            }

        }
        BLLComplementry blcomp = new BLLComplementry();
        BLLKitchenOrderInfo blkoi = new BLLKitchenOrderInfo();
        Ingredient im = new Ingredient();
        BLL_credit_paid blcp = new BLL_credit_paid();
        string x_report;
     
        public void billing_save_with_multi()
        {
            //try
            //{
            //    if (save_after_print == true || save_only_trasaction == true)
            {
                IRD();
                billVoid();
                x_report = VoidBill.x_report;
                if (multi_billing_check == true)
                {
                    int loop_id = 0;
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        string item = (dr.Cells["cal_item_name"].Value.ToString());
                        decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                        string category_name1 = dr.Cells["cal_category_name"].Value.ToString();
                        string kot_type = dr.Cells["cal_kot_type"].Value.ToString();
                        string sales_type = dr.Cells["cal_sales_type"].Value.ToString();
                        string complementru_status = dr.Cells["cal_comp_status"].Value.ToString();
                        string service_provider = dr.Cells["cal_service_provider"].Value.ToString();
                        int order_id = Convert.ToInt32(dr.Cells["cal_order_id"].Value.ToString());
                        if (x_report != "NULL")
                        {
                            x_report = "X";
                        }
                        int b = blresll.insertintosalesbook(Convert.ToInt32(txtnewbillno.Text), date, txtcashier.Text, category_name1, lbltable.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), sales_type, txtpan_no.Text, x_report, Convert.ToDecimal(lbl_service_charge.Text), subtotal_with_services, Convert.ToDecimal(lbl_tax.Text), fiscal_year, service_provider, date, customer_id, loop_id, date.ToString("HH:mm tt"), sync_with_ird, complementryInvoiceNo, complementru_status, void_status.ToString(), Convert.ToInt32(void_bill_no), "", order_id, Convert.ToDecimal(lbl_credit.Text));
                        //void_status = false;
                        if (b > 0)
                        {
                            loop_id++;
                            DataTable dt = blord.getallbyitem_name(item);
                            if (dt.Rows.Count > 0)
                            {
                                im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                            }
                            save_data = true;

                        }
                        x_report = "X";
                    }
                }

                else
                {
                        for (int a = 0; a < dataGridView1.Rows.Count; a++)
                        {
                            string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                            decimal quantity = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                            decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                            decimal total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                            string category_name1 = dataGridView1.Rows[a].Cells["cal_category_name"].Value.ToString();
                            string kot_type = dataGridView1.Rows[a].Cells["cal_kot_type"].Value.ToString();
                            string sales_type = dataGridView1.Rows[0].Cells["cal_sales_type"].Value.ToString();
                            string complementru_status = dataGridView1.Rows[a].Cells["cal_comp_status"].Value.ToString();
                            string service_provider = dataGridView1.Rows[a].Cells["cal_service_provider"].Value.ToString();
                            int order_id = Convert.ToInt32(dataGridView1.Rows[a].Cells["cal_order_id"].Value.ToString());
                            //if (area_name=="Customer")
                            //{
                            //    sales_type = "CS";
                            //}
                            if (x_report != "NULL")
                            {
                                x_report = "X";
                            }
                            int b = blresll.insertintosalesbook(Convert.ToInt32(txtnewbillno.Text), date, txtcashier.Text, category_name1, lbltable.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), sales_type, txtpan_no.Text, x_report, Convert.ToDecimal(lbl_service_charge.Text), subtotal_with_services, Convert.ToDecimal(lbl_tax.Text), fiscal_year, service_provider, date, customer_id, a, date.ToString("HH:mm tt"), sync_with_ird, complementryInvoiceNo, complementru_status, void_status.ToString(), Convert.ToInt32(void_bill_no), "", order_id, Convert.ToDecimal(lbl_credit.Text));

                            //  void_status = false;
                            if (b > 0)
                            {

                                save_data = true;
                                DataTable dt = blord.getallbyitem_name(item);
                                if (dt.Rows.Count > 0)
                                {
                                    im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                                }
                            }
                        }
                        if (payment_mode == "Cash/Credit")
                        {
                            int creditrecord = blc_credit.insert_into_credit(Convert.ToInt32(cbo_customer_name.SelectedValue), Convert.ToInt32(txtnewbillno.Text), date, Convert.ToDecimal(txtgrandtotal.Text), Login.sendtext, "RC");
                            int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txtgrandtotal.Text), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(lbl_credit.Text), txtcashier.Text, Convert.ToDateTime(date.ToShortDateString()), payment_mode, " ", "RP");
                        }
                    }
                }
            
            if (save_data == true)
            {
                if (customer_id > 0 && customer_points > 0)//customer loyalti point insert
                {
                    int pointsInsert = blloy.Insert_Customer_LoyalityPoint(Convert.ToInt32(txtnewbillno.Text), customer_id, customer_points, date);
                }
                DataTable dtKotInfo = blkoi.GetAlltableInfo(lbltable.Text);
                if (dtKotInfo.Rows.Count > 0)
                {
                    int insertCoverup = blkoi.InsertCoverUp(Convert.ToInt32(txtnewbillno.Text), Convert.ToInt32(dtKotInfo.Rows[0]["no_of_adult"]), Convert.ToInt32(dtKotInfo.Rows[0]["no_of_children"]), Convert.ToInt32(dtKotInfo.Rows[0]["total_no"]), lbltable.Text);
                }
                DonationInsert();

            }
            if (chk_club_card.Checked)
            {
                if (customer_id > 0)
                {
                    int club_amount_less = blcd.culbCardAmountLess(customer_id, Convert.ToDecimal(txtgrandtotal.Text));
                }
                customer_id = 0;
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
      
     
        public void clear()
        {

            txtcardamount.Text = "0.00";
            lbl_credit.Text = "0.00";
            txtcashamount.Text = "0.00";
            lbldiscount.Text = "0.00";
            lblrecivedamount.Text = "0.00";
            lblcardamount.Text = "0.00";
            lbl_credit.Text = "0.00";
            txtremainingamount.Text = "0.00";
            lblchangeamout.Text = "0.00";
            txtgrandtotal.Text = "0.00";
            lblsub_total.Text = "0.00";
            txtpan_no.Text = "";
            discount_amount = "0.00";
        }
        BillPrintingHotel bph = new BillPrintingHotel();
        private void btnprintonly_Click(object sender, EventArgs e)
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
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "C80")
                {
                    cp80.Headerstatus = headerstatus;
                    cp80.FooterStatus = Footerstatus;
                    cp80.billing_print_only = true;
                    cp80.printer_name = Qprintername;
                    billingForCoupon80();

                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                {
                    blp_76.Headerstatus = headerstatus;
                    blp_76.FooterStatus = Footerstatus;
                    blp_76.billing_print_only = true;
                    blp_76.printer_name = Qprintername;
                    bill_printing_for_76();

                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "A4")
                {
                    bA4.Headerstatus = headerstatus;
                    bA4.FooterStatus = Footerstatus;
                    bA4.billing_print_only = true;
                    bA4.printer_name = Qprintername;
                    bill_printing_for_A4();

                }

                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "P80" && dt_prt.Rows[0]["bill_printer"].ToString() == "P56")
                {
                    pn80.Headerstatus = headerstatus;
                    pn80.FooterStatus = Footerstatus;
                    pn80.billing_print_only = true;
                    pn80.printer_name = Qprintername;
                    PanBilling80();

                }
                else
                {
                    blp.billing_print_only = true;
                    bill_printing_for_58();

                }
            }
            if (txtcashamount.Text != "")
            {
                if (settlement == false)
                {
                    int insert = blpst.InsertQuotation(lbltable.Text, Convert.ToDecimal(txtcashamount.Text), txtcashier.Text, date);
                    tabletuch();
                }

            }
        }




        public void printer_checker()
        {
            DataTable dt_prt = blpst.getalldata();
            DataTable dt_p = blpst.getallPrintingTimes();
            bool BillFooterstatus = cd.BillingFooterPrint();
            bool Grandtotal = cd.GrandTotalRequired();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            blp_80.Headerstatus = true;
                            //blp_80.FooterStatus = true;
                            blp_80.BillFooter = BillFooterstatus;
                            blp_80.Grandtotal = Grandtotal;
                            blp_80.print_again = true;
                            blp_80.printer_name = "Billing";
                            at80.Headerstatus = true;
                            //at80.FooterStatus = true;
                            at80.BillFooter = BillFooterstatus;
                            at80.Grandtotal = Grandtotal;
                            at80.print_again = true;
                            at80.printer_name = "Billing";
                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp_80.print_again = false;
                                at80.print_again = false;
                            }
                            if (Abbreviatedtax > Convert.ToDecimal(txtgrandtotal.Text) && AbbreviatedtaxEnable == true)
                            {
                                AbbreviatedTax80();
                            }
                            else
                            {
                                bill_printing_for_80();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "C80")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            cp80.Headerstatus = true;
                            cp80.FooterStatus = true;
                            cp80.Grandtotal = Grandtotal;
                            cp80.print_again = true;
                            cp80.printer_name = "Billing";
                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                cp80.print_again = false;
                            }
                            billingForCoupon80();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "P80"|| dt_prt.Rows[0]["bill_printer"].ToString() == "P56")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            pn80.Headerstatus = true;
                            pn80.FooterStatus = true;
                            pn80.Grandtotal = Grandtotal;
                            pn80.print_again = true;
                            pn80.printerSize = dt_prt.Rows[0]["bill_printer"].ToString();
                            pn80.printer_name = "Billing";
                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                pn80.print_again = false;
                            }
                            PanBilling80();

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
                            blp_76.Grandtotal = Grandtotal;
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
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "A4")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            bA4.Headerstatus = true;
                            bA4.FooterStatus = true;
                            bA4.Grandtotal = Grandtotal;
                            bA4.print_again = true;

                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                bA4.printer_name = "Billing";
                                bA4.print_again = false;
                            }
                            bill_printing_for_A4();

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
                            blp.Grandtotal = Grandtotal;
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
            blp.bill_no = txtnewbillno.Text;
            blp.cashier = txtcashier.Text;
            blp.nepaliDate = nepaliDateConvert;
            blp.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            blp.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp.table_no = lbltable.Text;
            blp.customer_PAN_no = txtpan_no.Text;
            blp.customer_name = cbo_customer_name.Text;
            blp.customer_address = customer_address;
            blp.customer_phone_no = cbo_customer_no.Text;
            blp.discount_percent = discount_percent;
            blp.tax_amount = tax_amount.ToString("#.##");
            blp.service_charge = service_charge.ToString("#.##");
            blp.fiscal_year = fiscal_year;
            blp.area_name = area_name;
            blp.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            blp.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                blp.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            blp.billing_date = date;
            blp.taxable_amount = subtotal_with_services.ToString("#.##");
            blp.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    blp.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    blp.kot_no.Add(dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString());
                }
                blp.printtobill();
                save_after_print = blp.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        blp.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        blp.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        blp.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        blp.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        blp.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        blp.kot_no.Add(dr.Cells["cal_kot_id"].Value.ToString());
                    }
                    blp.printtobill();
                    save_after_print = blp.save_after_print;
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
        public void bill_printing_for_76()
        {
            blp_76.bill_no = txtnewbillno.Text;
            blp_76.nepaliDate = nepaliDateConvert;
            blp_76.cashier = txtcashier.Text;
            blp_76.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_76.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            blp_76.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_76.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_76.table_no = lbltable.Text;
            blp_76.customer_PAN_no = txtpan_no.Text;
            blp_76.customer_name = cbo_customer_name.Text;
            blp_76.customer_address = customer_address;
            blp_76.customer_phone_no = cbo_customer_no.Text;
            blp_76.discount_percent = discount_percent;
            blp_76.tax_amount = tax_amount.ToString("#.##");
            blp_76.service_charge = service_charge.ToString("#.##");
            blp_76.area_name = area_name;
            blp_76.fiscal_year = fiscal_year;
            payment_modeCheck();
            if (txtremainingamount.Text != "")
            {
                blp_76.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            blp_76.billing_date = date;
            blp_76.taxable_amount = subtotal_with_services.ToString("#.##");
            blp_76.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_76.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp_76.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp_76.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp_76.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    blp_76.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
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
                        blp_76.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
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
            blp_80.bill_no = txtnewbillno.Text;
            blp_80.cashier = txtcashier.Text;
            blp_80.nepaliDate = nepaliDateConvert;
            blp_80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_80.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            blp_80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_80.abbBilling = AbbreviatedtaxEnable;
            blp_80.abb_withoutdiscountgrand_total = abbGrandTotal.ToString("F");
            blp_80.table_no = lbltable.Text;
            blp_80.customer_PAN_no = txtpan_no.Text;
            blp_80.customer_name = cbo_customer_name.Text;
            blp_80.customer_address = customer_address;
            blp_80.customer_phone_no = cbo_customer_no.Text;
            blp_80.discount_percent = discount_percent;
            blp_80.tax_amount = tax_amount.ToString("#.##");
            blp_80.service_charge = service_charge.ToString("#.##");
            blp_80.fiscal_year = fiscal_year;
            blp_80.area_name = area_name;
            blp_80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            blp_80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                blp_80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            blp_80.billing_date = date;
            blp_80.taxable_amount = subtotal_with_services.ToString("#.##");
            blp_80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp_80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp_80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp_80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    blp_80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    blp_80.kot_no.Add(dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString());
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
                        blp_80.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        blp_80.kot_no.Add(dr.Cells["cal_kot_id"].Value.ToString());
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
        BillPrintingA4 bA4 = new BillPrintingA4();
        public void bill_printing_for_A4()
        {
            bA4.bill_no = txtnewbillno.Text;
            bA4.cashier = txtcashier.Text;
            bA4.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            bA4.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            bA4.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            bA4.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            bA4.table_no = lbltable.Text;
            bA4.customer_PAN_no = txtpan_no.Text;
            bA4.customer_name = cbo_customer_name.Text;
            bA4.customer_address = customer_address;
            bA4.customer_phone_no = cbo_customer_no.Text;
            bA4.discount_percent = discount_percent;
            bA4.tax_amount = tax_amount.ToString("#.##");
            bA4.service_charge = service_charge.ToString("#.##");
            bA4.fiscal_year = fiscal_year;
            bA4.area_name = area_name;
            bA4.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            bA4.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                bA4.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            bA4.billing_date = date;
            bA4.taxable_amount = subtotal_with_services.ToString("#.##");
            bA4.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bA4.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    bA4.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    bA4.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    bA4.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    bA4.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    bA4.kot_no.Add(dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString());
                }
                bA4.printtobill();
                save_after_print = bA4.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        bA4.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        bA4.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        bA4.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        bA4.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        bA4.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        bA4.kot_no.Add(dr.Cells["cal_kot_id"].Value.ToString());
                    }
                    bA4.printtobill();
                    save_after_print = bA4.save_after_print;
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
        CouponPrint cp80 = new CouponPrint();
        public void billingForCoupon80()
        {
            cp80.bill_no = txtnewbillno.Text;
            cp80.cashier = txtcashier.Text;
            cp80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            cp80.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            cp80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            cp80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            cp80.table_no = lbltable.Text;
            cp80.customer_PAN_no = txtpan_no.Text;
            cp80.customer_name = cbo_customer_name.Text;
            cp80.discount_percent = discount_percent;
            cp80.tax_amount = tax_amount.ToString("#.##");
            cp80.service_charge = service_charge.ToString("#.##");
            cp80.area_name = area_name;
            cp80.service_provider = service_provider;
            cp80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            cp80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                cp80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            cp80.billing_date = date;
            cp80.taxable_amount = subtotal_with_services.ToString("#.##");
            cp80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cp80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    cp80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    cp80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    cp80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    cp80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());

                }
                cp80.printtobill();
                save_after_print = cp80.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        cp80.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        cp80.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        cp80.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        cp80.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        cp80.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                    }
                    cp80.printtobill();
                    save_after_print = cp80.save_after_print;
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
        PANBillPrinting80 pn80 = new PANBillPrinting80();
        public void PanBilling80()
        {
            pn80.bill_no = txtnewbillno.Text;
            pn80.cashier = txtcashier.Text;
            pn80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            pn80.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            pn80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            pn80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            pn80.table_no = lbltable.Text;
            pn80.customer_PAN_no = txtpan_no.Text;
            pn80.customer_name = cbo_customer_name.Text;
            pn80.discount_percent = discount_percent;
            pn80.tax_amount = tax_amount.ToString("#.##");
            pn80.service_charge = service_charge.ToString("#.##");
            pn80.nepaliDate = nepaliDateConvert;
            pn80.sales_type = sales_type;
            pn80.area_name = area_name;
            pn80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            pn80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            pn80.fiscal_year = fiscal_year;
            if (txtremainingamount.Text != "")
            {
                pn80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            pn80.billing_date = date;
            pn80.taxable_amount = subtotal_with_services.ToString("#.##");
            pn80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    pn80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    pn80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    pn80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    pn80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    pn80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    pn80.kot_no += dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString();

                }
                pn80.printtobill();
                save_after_print = pn80.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        pn80.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        pn80.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        pn80.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        pn80.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        pn80.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        pn80.kot_no += dr.Cells["cal_kot_id"].Value.ToString();
                    }
                    pn80.printtobill();
                    save_after_print = pn80.save_after_print;
                }
                else
                {
                    MessageBox.Show("Data Row Select", "Please  Select Data Row!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error 404", "Transaction Failed! Please Do It Again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        AbbreviatedTax80 at80 = new AbbreviatedTax80();
        public void AbbreviatedTax80()
        {
            at80.bill_no = txtnewbillno.Text;
            at80.cashier = txtcashier.Text;
            at80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            at80.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            at80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            at80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            at80.table_no = lbltable.Text;
            at80.nepali_date = nepaliDateConvert;
            at80.customer_PAN_no = txtpan_no.Text;
            at80.customer_name = cbo_customer_name.Text;
            at80.discount_percent = discount_percent;
            at80.tax_amount = tax_amount.ToString("#.##");
            at80.service_charge = service_charge.ToString("#.##");
            at80.area_name = area_name;
            at80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            at80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            at80.fiscal_year = fiscal_year;
            if (txtremainingamount.Text != "")
            {
                at80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            at80.payment_mode = payment_mode;
            at80.billing_date = date;
            at80.taxable_amount = subtotal_with_services.ToString("#.##");
            at80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    at80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    at80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    at80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    at80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    at80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    at80.kot_no += dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString();

                }
                at80.printtobill();
                save_after_print = at80.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        at80.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        at80.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        at80.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        at80.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        at80.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        at80.kot_no += dr.Cells["cal_kot_id"].Value.ToString();
                    }
                    at80.printtobill();
                    save_after_print = at80.save_after_print;
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
        public void payment_modeCheck()
        {
            if (chkcard.Checked)
            {
                blp_80.payment_mode = "Card";
                blp_76.payment_mode = "Card";
                pn80.payment_mode = "Card";
                bA4.payment_mode = "Card";

            }
            else if (chkcash.Checked)
            {
                blp_80.payment_mode = "Cash";
                blp_76.payment_mode = "Cash";
                pn80.payment_mode = "Cash";
                bA4.payment_mode = "Cash";
            }
            else if (chkcash_card.Checked)
            {
                blp_80.payment_mode = "Card/Cash";
                blp_76.payment_mode = "Card/Cash";
                pn80.payment_mode = "Card/Cash";
                bA4.payment_mode = "Card/Cash";
            }
            else if (chk_club_card.Checked)
            {
                blp_80.payment_mode = "Club Card";
                blp_76.payment_mode = "Club Card";
                pn80.payment_mode = "Club Card";
                bA4.payment_mode = "Club Card";
            }
            else if (chk_cheque.Checked)
            {
                blp_80.payment_mode = "Cheque";
                blp_76.payment_mode = "Cheque";
                pn80.payment_mode = "Cheque";
                bA4.payment_mode = "Cheque";
            }
            else if (chkcredit.Checked)
            {
                blp_80.payment_mode = "Credit";
                blp_76.payment_mode = "Credit";
                pn80.payment_mode = "Credit";
                bA4.payment_mode = "Credit";
            }
            else if (chk_cash_credit.Checked)
            {
                blp_80.payment_mode = "Cash/Credit";
                blp_76.payment_mode = "Cash/Credit";
                pn80.payment_mode = "Cash/Credit";
                bA4.payment_mode = "Cash/Credit";
            }
            else if (chk_fone_pay.Checked)
            {
                blp_80.payment_mode = "FonePay";
                blp_76.payment_mode = "FonePay";
                pn80.payment_mode = "FonePay";
                bA4.payment_mode = "FonePay";
            }
            donation_paymentChecker();
        }


        public void billing_details_value()
        {
            bldetails.bill_no = txtnewbillno.Text;
            bldetails.cashier = txtcashier.Text;
            bldetails.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            bldetails.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            bldetails.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            bldetails.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            bldetails.table_no = lbltable.Text;
            bldetails.customer_pan_no = txtpan_no.Text;
            bldetails.customer_name = cbo_customer_name.Text;
            bldetails.discount_percent = discount_percent;
            bldetails.tax_amount = tax_amount.ToString("#.##");
            bldetails.service_charge = service_charge.ToString("#.##");
            bldetails.area_name = area_name;
            if (txtremainingamount.Text != "")
            {
                bldetails.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            bldetails.billing_date = date.ToString();
            bldetails.taxable_amount = subtotal_with_services.ToString("#.##");
            bldetails.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bldetails.item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    bldetails.item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    bldetails.total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    bldetails.quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    bldetails.Complementry.Add(dataGridView1.Rows[i].Cells["cal_complementary"].Value.ToString());
                }

            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        bldetails.item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        bldetails.item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        bldetails.total.Add(dr.Cells["cal_total"].Value.ToString());
                        bldetails.quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        bldetails.Complementry.Add(dr.Cells["cal_complementary"].Value.ToString());
                    }

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

    
        private void txtcashamount_TextChanged_1(object sender, EventArgs e)
        {
            cashamount_recived_amount();
            if (txtcashamount.Text == "" || txtcashamount.Text == "0.00")
            {
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";

            }
        }
        public void cashamount_recived_amount()
        {
            lblrecivedamount.Text = txtcashamount.Text;
            if (txtcashamount.Text.Length > 0)
            {

                if (chkcash_card.Checked)
                {
                    decimal grandtotal = Convert.ToDecimal(txtgrandtotal.Text);
                    decimal cashamount = Convert.ToDecimal(txtcashamount.Text);

                    if (grandtotal < cashamount)
                    {
                        txtremainingamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtcardamount.Text = "0.00";
                        lblcardamount.Text = "0.00";
                        lbl_credit.Text = "0.00";
                        lblchangeamout.Text = txtremainingamount.Text;

                    }
                    else
                    {
                        txtcardamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtremainingamount.Text = "0.00";
                        lblchangeamout.Text = "0.00";
                        lblcardamount.Text = txtcardamount.Text;
                    }

                }
                else if (chk_cash_credit.Checked)
                {
                    decimal grandtotal = Convert.ToDecimal(txtgrandtotal.Text);
                    decimal cashamount = Convert.ToDecimal(txtcashamount.Text);
                    if (grandtotal < cashamount)
                        {
                        txtremainingamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtcardamount.Text = "0.00";
                        lblcardamount.Text = "0.00";
                        lbl_credit.Text = "0.00";
                        lblchangeamout.Text = txtremainingamount.Text;
                        
                    }
                    else
                        {
                            lbl_credit.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                            txtremainingamount.Text = "0.00";
                            lblchangeamout.Text = "0.00";

                        }
                    }
                
                else if (chkcash.Checked && txtcashamount.Text != "0.00")
                {
                    txtremainingamount.Text = (Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                    lblchangeamout.Text = txtremainingamount.Text;
                }
                else if (chkcredit.Checked)
                {
                    txtremainingamount.Text = Math.Abs(Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtcashamount.Text)).ToString();
                    lblchangeamout.Text = txtremainingamount.Text;
                }
            }
            else if (txtcashamount.Text == "" || txtcashamount.Text == "0.00")
            {
                txtcardamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";

            }
            else if (txtcardamount.Text == "")
            {
                txtcardamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";

            }

        }
   
        public bool user_access_check;
        private void txtcashamount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtremainingamount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtsubtotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcardamount_KeyPress(object sender, KeyPressEventArgs e)
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
        //numberPad
        object lastFocused = null;
        void textBox_Enter(object sender, EventArgs e)
        {
            (lastFocused) = (TextBox)sender;
        }

        private void btnone_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "1";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "1";
                    }
                }


                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "1";
                }

            }
        }

        private void btntwo_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "2";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "2";
                    }
                }


                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "2";
                }
            }
        }

        private void btnthree_Click_1(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "3";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "3";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "3";
                }
            }
        }

        private void btnfour_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "4";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "4";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "4";
                }
            }
        }

        private void btnfive_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "5";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "5";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "5";
                }
            }
        }

        private void btnsix_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "6";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "6";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "6";
                }
            }
        }

        private void btnseven_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "7";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "7";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "7";
                }
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "8";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "8";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "8";
                }
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "9";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "9";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "9";
                }
            }
        }



        private void btnzero_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "0";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "0";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "0";
                }
            }
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += ".";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += ".";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += ".";
                }
            }
        }

        private void btnbackspace_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        int i = ((TextBox)lastFocused).Text.Length;
                        ((TextBox)lastFocused).Text = ((TextBox)lastFocused).Text.Substring(0, i - 1);
                    }
                    else
                    {
                        int i = ((TextBox)lastFocused).Text.Length;
                        if (i > 0)
                        {
                            ((TextBox)lastFocused).Text = ((TextBox)lastFocused).Text.Substring(0, i - 1);
                        }
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    string s = ((DataGridViewCell)lastFocused).Value.ToString();
                    ((DataGridViewCell)lastFocused).Value = s.Substring(0, s.Length - 1);
                }
            }

        }
        SerialPortDataSender spds = new SerialPortDataSender();
        public void back_screan()
        {
            
            spds.CustomerDisplayVFD(txtgrandtotal.Text, 0x31);
        }


        private void btncalcu_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (void_status == true)
                {
                    if (dgvColumnId >= 0)
                    {
                        if (Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) == 1)
                        {
                            MessageBox.Show("System cannot make quantity Zero.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) - 1;
                            if (Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) > 0)
                            {
                                dataGridView1.Rows[dgvColumnId].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvColumnId].Cells["cal_cost"].Value);
                                calculate_total();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please choose the data first.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This button will only enable on bill void mode.", "Invalid button", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtcashamount_Enter(object sender, EventArgs e)
        {
            if (txtcashamount.Text == "0.00")
            {
                txtcashamount.Text = "";
            }
        }

        private void txtcashamount_Leave_1(object sender, EventArgs e)
        {
            if (txtcashamount.Text == "")
            {
                txtcashamount.Text = "0.00";
            }
        }

        private void txtremainingamount_Leave(object sender, EventArgs e)
        {
            if (txtremainingamount.Text == "")
            {
                txtremainingamount.Text = "0.00";
            }
        }

        private void txtremainingamount_Enter(object sender, EventArgs e)
        {
            if (txtremainingamount.Text == "0.00")
            {
                txtremainingamount.Text = "";
            }
        }
        private void txtcardamount_Leave(object sender, EventArgs e)
        {
            if (txtcardamount.Text == "")
            {
                txtcardamount.Text = "0.00";
            }
        }

        private void txtcardamount_Enter(object sender, EventArgs e)
        {
            if (txtcardamount.Text == "0.00")
            {
                txtcardamount.Text = "";
            }
        }
        
        public void user_log_insert()
        {
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(user_name_log, day, "Billing");

            if (dt.Rows.Count == 0)
            {
                int abc = bulg.createuserlog(user_name_log, "Billing", date, day);
            }
        }
        AdvanceDiscount adss = new AdvanceDiscount();
        BillingDetails bldetails = new BillingDetails();
        string take_away_id;
        BLLTakeAway bltk = new BLLTakeAway();
        private void btnprintandsave_Click_1(object sender, EventArgs e)
        {
            
            if (txtpan_no.Text.Length > 0 && txtpan_no.Text.Length != 9 && label13.Text != "Club Card No")
            {
                MessageBox.Show("Incorrect Pan No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fiscal_year_status != "True")
            {
                MessageBox.Show("Fiscal year has been ended or set fiscal year.", "Fiscal Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chk_cash_credit.Checked == true && Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text))
            {
                MessageBox.Show("Payment Mode Not Correctly Applied Alert !!", "Change Payment Mode Alert  !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else
            {
                DataTable dtCheckBill = blresll.CheckBillNo(Convert.ToInt32(txtnewbillno.Text), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                if (dtCheckBill.Rows.Count > 0)
                {
                    MessageBox.Show("Cannot complete your transaction. Please resart your POS application", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    int billInc = blresll.autoBillIncrease();

                }
                else
                {
                    if (chk_club_card.Checked)
                    {
                        balanceCheck();
                    }

                    save_and_print();
                    if (save_data == true)
                    {

                        bldetails.grand_total = txtgrandtotal.Text;
                        bldetails.remaining_amount = txtremainingamount.Text;
                        bldetails.received_amount = txtcashamount.Text;
                        bldetails.bill_no_print = txtnewbillno.Text;
                        billing_details_value();
                        LoadTableAfterBilling();
                        clear();
                        dataGridView1.Rows.Clear();
                        txtnewbillno.Clear();
                        bill();
                        clear();
                        CUstomer_name();
                        CUstomer_number();
                        calculate_total();
                        AdminAccess.discount_access_value = false;
                        user_log_insert();
                        adss.txt_discount_amount.Text = "0.00";
                        adss.txt_discount_percent.Text = "0.00";
                        adss.discount_amount = 0;
                        adss.discount_amount_percent = 0;
                        club_card_balance = false;
                        dataGridView1.Columns["cal_delete"].Visible = false;
                        save_only_trasaction = false;
                        save_data = false;
                        btn_bill_void.Text = "Void";
                        spds.CustomerDisplayVFD(txtgrandtotal.Text, 0x30);
                        txtcardamount.ReadOnly = false;
                        
                    }
                }
                Customer_Management.AllCusomterList.customer_details = 0;
            }
        }
        BLL_Fiscal blfsc = new BLL_Fiscal();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());

        bool save_only_trasaction = false;

        private void btnsave_only_Click(object sender, EventArgs e)
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {

                if (!decimal.TryParse(lbltable.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (fiscal_year_status != "True")
                {
                    MessageBox.Show("Fiscal year has been ended or set fiscal year.", "Fiscal Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else 
                {
                    DataTable dtCheckBill = blresll.CheckBillNo(Convert.ToInt32(txtnewbillno.Text), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    if (dtCheckBill.Rows.Count > 0)
                    {
                        MessageBox.Show("Cannot complete your transaction. Please resart your POS application", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (chkcash.Checked)
                        {
                            if (Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text))
                            {
                                save_only_trasaction = true;
                            }
                            else
                            {
                                MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else if (chkcard.Checked)
                        {
                            if ((Convert.ToDecimal(txtcardamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text)))
                            {
                                save_only_trasaction = true;
                            }
                            else
                            {
                                MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (chk_club_card.Checked)
                        {
                            balanceCheck();
                            if (club_card_balance == true)
                            {

                                save_only_trasaction = true;
                            }
                            else
                            {
                                MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (chkcredit.Checked)
                        {
                            if (cbo_customer_name.SelectedIndex > 0)
                            {
                                txtcashamount.Text = "0.00";
                                txtcardamount.Text = "0.00";
                                save_only_trasaction = true;
                            }
                            else
                            {
                                MessageBox.Show("Please Choose Your Customer For Credit Transaction", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else if (chkcash_card.Checked)
                        {

                            save_only_trasaction = true;
                        }
                        else if (chk_cash_credit.Checked)
                        {
                            if (cbo_customer_name.SelectedIndex > 0)
                            {
                                txtcardamount.Text = "0.00";
                                save_only_trasaction = true;
                            }
                            else
                            {
                                MessageBox.Show("Please Choose Your Customer For Credit Transaction", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else if (chk_cheque.Checked)
                        {

                            save_only_trasaction = true;
                        }
                        if (save_only_trasaction == true)
                        {


                            billing_save_with_multi();
                            if (save_data == true)
                            {
                                LoadTableAfterBilling();
                                if (Convert.ToDecimal(lbltable.Text) >= 1000)
                                {
                                    bldetails.grand_total = txtgrandtotal.Text;
                                    bldetails.remaining_amount = txtremainingamount.Text;
                                    bldetails.received_amount = txtcashamount.Text;
                                    bldetails.bill_no_print = txtnewbillno.Text;
                                    billing_details_value();
                                }
                                txtnewbillno.Clear();
                                bill();
                                clear();
                                dataGridView1.Rows.Clear();
                                save_data = false;
                                txtcardamount.Text = "0.00";
                                txtcashamount.Text = "0.00";
                                lbldiscount.Text = "0.00";
                                lblrecivedamount.Text = "0.00";
                                lblcardamount.Text = "0.00";
                                lbl_credit.Text = "0.00";
                                txtremainingamount.Text = "0.00";
                                lblchangeamout.Text = "0.00";
                                AdminAccess.discount_access_value = false;
                                MessageBox.Show("Data has been save to database", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                adss.txt_discount_amount.Text = string.Empty;
                                adss.txt_discount_percent.Text = string.Empty;
                                adss.discount_amount = 0;
                                adss.discount_amount_percent = 0;
                                int deleteAdvanceDiscount = bld.DeleteAdvanceDiscount(lbltable.Text);
                            }


                            adss.txt_discount_amount.Text = string.Empty;
                            adss.txt_discount_percent.Text = string.Empty;
                            adss.discount_amount = 0;
                            adss.discount_amount_percent = 0;
                        }

                    }
                }
                dataGridView1.Columns["cal_delete"].Visible = false;
                CUstomer_name();
                CUstomer_number();
                back_screan();
                club_card_balance = false;
                save_only_trasaction = false;

            }
        }

        public void LoadTableAfterBilling()
        {
            

            if (cd.BusinessType() == "Bakery")
            {

                DataTable dtb = blbo.get_all_rest_table_info(Gettablename);
                customertouch(dtb);
            }
            else
            {
                bldetails.ShowDialog();
                if (bldetails.btn_create_new_billing.DialogResult == DialogResult.OK)
                {
                    Control ctls = this.Parent;
                    DataTable dt = bltk.getmaxNo();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "")
                        {
                            take_away_id = "1001";
                        }
                        else
                        {
                            int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                            take_away_id = getinvoiceno.ToString();

                        }
                    }
                    KOTOrder winfosr = new KOTOrder(take_away_id, "TA");
                    ctls.Controls.Clear();
                    ctls.Controls.Add(winfosr);

                }
                else
                {
                    if (Convert.ToDecimal(lbltable.Text) >= 1000)
                    {

                        take_away();
                    }
                    else
                    {
                        lbltable.Show();
                        tabletuch();

                    }
                }
            }

          
        }
      
        InternetConnection ic = new InternetConnection();
        BLLBusinessDyanmic blbd = new BLLBusinessDyanmic();
        string sync_with_ird = "false";
        public void IRD()
        {
            if (AbbreviatedtaxEnable == true && Abbreviatedtax > subtotal_with_services)
            {
                DataTable dtbd = blbd.selectAllData();
                if (dtbd.Rows.Count > 0)
                {
                    double taxable_sales_vat = Convert.ToDouble(txtgrandtotal.Text) - Convert.ToDouble(abbrevated_taxAmount);
                    if (dtbd.Rows[0]["sync_ird"].ToString() == "True")
                    {
                        var connec = ic.CheckForInternetConnection();
                        if (connec == true)
                        {
                            int IRT = apir.posBilling(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(taxable_sales_vat), Convert.ToDouble(abbrevated_taxAmount), true, fiscal_year, ird_username, ird_password);
                            sync_with_ird = "true";
                        }
                        else
                        {
                            int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, taxable_sales_vat.ToString(), abbrevated_taxAmount.ToString(), "", "", "", "", "", "", "", "");
                            sync_with_ird = "false";
                        }
                    }
                    else
                    {
                        int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, taxable_sales_vat.ToString(), abbrevated_taxAmount.ToString(), "", "", "", "", "", "", "", "");
                        sync_with_ird = "false";
                    }
                }
            }
            else
            {
                DataTable dtbd = blbd.selectAllData();
                if (dtbd.Rows.Count > 0)
                {
                    if (dtbd.Rows[0]["sync_ird"].ToString() == "True")
                    {
                        var connec = ic.CheckForInternetConnection();
                        if (connec == true)
                        {
                            int IRT = apir.posBilling(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(subtotal_with_services), Convert.ToDouble(lbl_tax.Text), true, fiscal_year, ird_username, ird_password);
                            sync_with_ird = "true";
                        }
                        else
                        {
                            int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
                            sync_with_ird = "false";
                        }
                    }
                    else
                    {
                        int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
                        sync_with_ird = "false";
                    }
                }
            }
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            if (cd.BusinessType() == "Bakery")
            {
                Control ctrl = this.Parent;
                BakeryKOTOrder vieret = new BakeryKOTOrder(table_no2, Gettablename);//table_no2 is kot_id for bakery and gettablename is for service_type for bakery
                ctrl.Controls.Clear();
                ctrl.Controls.Add(vieret);

            }
            else
            {
                if (Convert.ToDecimal(lbltable.Text) >= 1000)
                {
                    Control ctls = this.Parent;
                    KOTOrder vieret = new KOTOrder(lbltable.Text, "TA");
                    ctls.Controls.Clear();
                    ctls.Controls.Add(vieret);
                }
                else
                {
                    Control ctls = this.Parent;
                    KOTOrder vieret = new KOTOrder(lbltable.Text, lbltable.Text);
                    ctls.Controls.Clear();
                    ctls.Controls.Add(vieret);
                }
            }

        }





        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {

            int flags = effmap[(int)effect];

            if (ctl.Visible)
            {
                flags |= 0x10000; angle += 180;

            }

            else
            {

                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();

            }

            flags |= dirmap[(angle % 360) / 45];

            bool ok = AnimateWindow(ctl.Handle, msec, flags);

            if (!ok) throw new Exception("Animation failed");

            ctl.Visible = !ctl.Visible;

        }

        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };

        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]

        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);




        private void chkcard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcard.Checked)
            {

                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                lblrecivedamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";
                txtcardamount.Text = txtgrandtotal.Text;
                payment_mode = "Card";
                tax_calcu();
                txtcardamount.ReadOnly = true;
            }
        }

        private void chkcash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcash.Checked)
            {
                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                lblrecivedamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";
                payment_mode = "Cash";
                txtcashamount.ReadOnly = false;
                btn_exact.Visible = true;
                txtcashamount.Visible = true;
                txtcardamount.ReadOnly = false;
            }
        }

        private void chkcash_card_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcash_card.Checked)
            {

                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                lblrecivedamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";
                payment_mode = "Cash/Card";
                tax_calcu();
                txtcardamount.ReadOnly = false;
            }
        }

        private void txtremainingamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkcredit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcredit.Checked)
            {
                lbl_credit.Text = txtgrandtotal.Text;
                payment_mode = "Credit";
                tax_calcu();
            }

        }

        private void chkcredit_Click(object sender, EventArgs e)
        {
            panel3.Show();
            txtcardamount.Enabled = false;
            lbl_credit.Text = txtgrandtotal.Text;
            label14.Text = "Credit Amount";

        }

        private void cbo_customer_name_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo_customer_name.Text != "" && cbo_customer_name.Text != "Choose One" && cbo_customer_name.SelectedIndex > 0)
            {
                DataTable dt = blcd.getDataByitsId(Convert.ToInt32(cbo_customer_name.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    cbo_customer_no.Text = dt.Rows[0]["phone"].ToString();
                    customer_id = Convert.ToInt32(cbo_customer_name.SelectedValue);
                    customer_address = dt.Rows[0]["address"].ToString();
                    if (!chk_club_card.Checked)
                    {
                        txtpan_no.Text = dt.Rows[0]["phone2"].ToString();
                    }
                }
            }
            else if (cbo_customer_no.Text == "" && cbo_customer_no.Text == "Choose One")
            {
                cbo_customer_no.Text = "Choose One";
            }
        }
        string customer_address;
        private void cbo_customer_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_customer_no.Text != "" && cbo_customer_no.Text != "Choose One" )
            {
                DataTable dt = blcd.getDataByitsPhonenumbers(cbo_customer_no.Text);
                if (dt.Rows.Count > 0)
                {
                    cbo_customer_name.Text = dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                    customer_id = Convert.ToInt32(cbo_customer_name.SelectedValue);
                    if (!chk_club_card.Checked)
                    {
                        txtpan_no.Text = dt.Rows[0]["phone2"].ToString();
                    }
                    customer_address = dt.Rows[0]["address"].ToString();
                }
            }
            else if (cbo_customer_no.Text == "" && cbo_customer_no.Text == "Choose One")
            {
                cbo_customer_no.Text = "Choose One";
            }
        }
        private void chk_club_card_CheckedChanged(object sender, EventArgs e)
        {
            btn_card_balance.Visible = true;
            txtpan_no.Focus();
            label13.Text = "Club Card No";
            payment_mode = "Club Card";
            txtcashamount.ReadOnly = true;
            btn_exact.Visible = false;
            txtcashamount.Visible = false;
        }
        private void chkcash_Click(object sender, EventArgs e)
        {

            txtcardamount.Enabled = true;
            btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }

        private void chkcard_Click(object sender, EventArgs e)
        {

            txtcardamount.Enabled = true;
            btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }

        private void chkcash_card_Click(object sender, EventArgs e)
        {

            txtcardamount.Enabled = true;
            btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }


        private void lbltable_TextChanged(object sender, EventArgs e)
        {
            DataTable getcustomernamno = blord.getalldata(Convert.ToDecimal(lbltable.Text));
            if (getcustomernamno.Rows.Count > 0)
            {
                //if (getcustomernamno.Rows[0]["user_name"].ToString() == "" || getcustomernamno.Rows[0]["user_name"].ToString() == null)
                //{
                //    cbo_customer_name.Text = "";
                //}
                //else
                //{
                //    cbo_customer_name.Text = getcustomernamno.Rows[0]["user_name"].ToString();
                //}


                //if (getcustomernamno.Rows[0]["phone"].ToString() == "" || getcustomernamno.Rows[0]["phone"].ToString() == null)
                //{
                //    cbo_customer_no.Text = "";
                //}
                //else
                //{
                //    cbo_customer_no.Text = getcustomernamno.Rows[0]["phone"].ToString();
                //}

            }
        }


        private void Billing_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {

                Billing.Animate(panel3, Billing.Effect.Slide, 150, 90);

            }
        }

        private void Billing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Alt == true && e.KeyCode == Keys.C)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        public void rowheader_total_count()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                sum += Convert.ToDecimal(row.Cells["cal_total"].Value);
            }
            txtsubtotal.Text = sum.ToString();
            lblsub_total.Text = sum.ToString();
            tax_calcu();
            AdvanceDiscount();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {

            if (multi_billing_check == false)
            {
                multi_billing_check = true;
                dataGridView1.RowHeadersVisible = true;
            }
            else if (multi_billing_check == true)
            {
                dataGridView1.ClearSelection();
                multi_billing_check = false;
                dataGridView1.RowHeadersVisible = false;
                calculate_total();

            }
        }
        DataGridViewRow[] old;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow gr in old)
            {
                if (gr == dataGridView1.CurrentRow)
                {
                    gr.Selected = false;
                }
                else
                {
                    gr.Selected = true;
                }
            }
            // rowheader_total_count();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (multi_billing_check == true||reward_check==true)
            {
                rowheader_total_count();
            }
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //rowheader_total_count();
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            old = new DataGridViewRow[dataGridView1.SelectedRows.Count];
            dataGridView1.SelectedRows.CopyTo(old, 0);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvRowIndex = e.RowIndex;
            ItemSlipt();
        }

        string discount_percent;
        private void btn_advance_discount_Click(object sender, EventArgs e)
        {
            AdvanceDiscount adis = new AdvanceDiscount();
            user_access_check = AdminAccess.discount_access_value;
            if (user_access_check == true)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        adis.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                        adis.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                        adis.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                        adis.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                        adis.datagridview_KOT.Add(dataGridView1.Rows[i].Cells["cal_kot_type"].Value.ToString());
                    }
                    adis.table_no = lbltable.Text;
                    adis.ShowDialog();
                    if (adis.DialogResult == DialogResult.OK)
                    {
                        if (AbbreviatedtaxEnable == true && Abbreviatedtax < Convert.ToDecimal(txtgrandtotal.Text))
                        {
                            lbldiscount.Text = (adis.discount_amount).ToString();
                            discount_amount = lbldiscount.Text;
                            discount_percent = (adis.discount_amount_percent).ToString();
                            txtgrandtotal.Text = (abbGrandTotal - Convert.ToDecimal(lbldiscount.Text)).ToString("F");
                            abbTaxCalculate();
                            if (chk_club_card.Checked)
                            {
                                txtcardamount.Text = txtgrandtotal.Text;
                            }
                        }
                        else
                        {
                            lbldiscount.Text = (adis.discount_amount).ToString();
                            discount_percent = (adis.discount_amount_percent).ToString();
                            lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                            discount_amount = lbldiscount.Text;
                            tax_calcu();
                            cashamount_recived_amount();
                            if (chk_club_card.Checked)
                            {
                                txtcardamount.Text = txtgrandtotal.Text;
                            }
                        }
                    }

                }
            }
            else
            {
                DataTable dtaccess = bldd.GetAdminAccessDiscount();
                if (dtaccess.Rows.Count > 0)
                {
                    AdminAccess acc = new AdminAccess();
                    acc.ShowDialog();
                    user_access_check = AdminAccess.discount_access_value;
                    if (user_access_check == true)
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                adis.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                                adis.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                                adis.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                                adis.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                                adis.datagridview_KOT.Add(dataGridView1.Rows[i].Cells["cal_kot_type"].Value.ToString());
                            }
                            adis.table_no = lbltable.Text;
                            adis.ShowDialog();
                            if (adis.DialogResult == DialogResult.OK)
                            {
                                if (adis.DialogResult == DialogResult.OK)
                                {
                                    if (AbbreviatedtaxEnable == true && Abbreviatedtax < Convert.ToDecimal(txtgrandtotal.Text))
                                    {
                                        lbldiscount.Text = (adis.discount_amount).ToString();
                                        discount_amount = lbldiscount.Text;
                                        discount_percent = (adis.discount_amount_percent).ToString();
                                        txtgrandtotal.Text = (abbGrandTotal - Convert.ToDecimal(lbldiscount.Text)).ToString("F");
                                        abbTaxCalculate();
                                        if (chk_club_card.Checked)
                                        {
                                            txtcardamount.Text = txtgrandtotal.Text;
                                        }
                                    }
                                    else
                                    {
                                        lbldiscount.Text = (adis.discount_amount).ToString();
                                        discount_percent = (adis.discount_amount_percent).ToString();
                                        lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                                        discount_amount = lbldiscount.Text;
                                        tax_calcu();
                                        cashamount_recived_amount();
                                        if (chk_club_card.Checked)
                                        {
                                            txtcardamount.Text = txtgrandtotal.Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            adis.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                            adis.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                            adis.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                            adis.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                            adis.datagridview_KOT.Add(dataGridView1.Rows[i].Cells["cal_kot_type"].Value.ToString());
                        }
                        adis.table_no = lbltable.Text;
                        adis.ShowDialog();
                        if (adis.DialogResult == DialogResult.OK)
                        {
                            if (adis.DialogResult == DialogResult.OK)
                            {
                                if (AbbreviatedtaxEnable == true && Abbreviatedtax < Convert.ToDecimal(txtgrandtotal.Text))
                                {
                                    lbldiscount.Text = (adis.discount_amount).ToString();
                                    discount_amount = lbldiscount.Text;
                                    discount_percent = (adis.discount_amount_percent).ToString();
                                    txtgrandtotal.Text = (abbGrandTotal - Convert.ToDecimal(lbldiscount.Text)).ToString("F");
                                    abbTaxCalculate();
                                    if (chk_club_card.Checked)
                                    {
                                        txtcardamount.Text = txtgrandtotal.Text;
                                    }
                                }
                                else
                                {
                                    lbldiscount.Text = (adis.discount_amount).ToString();
                                    discount_percent = (adis.discount_amount_percent).ToString();
                                    lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                                    discount_amount = lbldiscount.Text;
                                    tax_calcu();
                                    cashamount_recived_amount();
                                    if (chk_club_card.Checked)
                                    {
                                        txtcardamount.Text = txtgrandtotal.Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_exact_Click(object sender, EventArgs e)
        {

            if (txtgrandtotal.Text != "0.00" && txtgrandtotal.Text.Length > 0)
            {
                if (chkcash.Checked)
                {
                    txtcashamount.Text = txtgrandtotal.Text;
                }
                else if (chkcard.Checked)
                {
                    txtcardamount.Text = txtgrandtotal.Text;
                }
                else if(chk_cheque.Checked)
                {
                    txtcashamount.Text = txtgrandtotal.Text;
                }

            }
        }

        private void txtpan_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (chk_club_card.Checked == true)
            //{
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = blcd.getnamebyno(txtpan_no.Text);
                if (dt.Rows.Count > 0)
                {
                    userLevelDiscuntCalculation();
                }
                if (chk_club_card.Checked == true)
                {

                    balanceCheck();
                }
                else if(reward_check==true)
                {
                    rewardDataInsert();
                }
                else
                {
                    DataTable dt_customer = blcd.getnamebyno(txtpan_no.Text);
                    if (dt_customer.Rows.Count > 0)
                    {

                        //cbo_customer_name.Text = dt_customer.Rows[0]["name"].ToString();
                        cbo_customer_no.Text = dt_customer.Rows[0]["phone"].ToString();

                    }
                    if (chkcash.Checked == true)
                    {
                        txtcashamount.Text = txtgrandtotal.Text;
                    }
                    if (chkcard.Checked == true)
                    {
                        txtcashamount.Text = txtgrandtotal.Text;
                    }
                }
            }
            //}
            //if (chkcash.Checked == true || chkcard.Checked == true|| chkcredit.Checked==true)
            //{

            //    if (e.KeyChar == (char)Keys.Enter)
            //    {
            //        DataTable dt = blcd.getnamebyno(txtpan_no.Text);
            //        if (dt.Rows.Count > 0)
            //        {
            //            userLevelDiscuntCalculation();
            //            cbo_customer_no.Text = dt.Rows[0]["phone"].ToString();
            //        }
            //    }
            //}

        }
        decimal real_blc = 0;
        public void balanceCheck()
        {
            DataTable dt = blcd.getnamebyno(txtpan_no.Text);
            if (dt.Rows.Count > 0)
            {
                customer_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                DataTable db = blcd.getcustomerbalance(customer_id);

                if (db.Rows.Count > 0)
                {
                    //  cbo_customer_name.Text = dt.Rows[0]["name"].ToString();
                    cbo_customer_no.Text = dt.Rows[0]["phone"].ToString();
                    if (Convert.ToDecimal(txtgrandtotal.Text) <= Convert.ToDecimal(db.Rows[0]["customer_balance"]))
                    {
                        real_blc = Convert.ToDecimal(db.Rows[0]["customer_balance"]) - Convert.ToDecimal(500);
                        if (Convert.ToDecimal(txtgrandtotal.Text) > real_blc)
                        {
                            MessageBox.Show("The customer have not enough balance, add balance.", "Not sufficient Balance!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            
                            txtcardamount.Text = txtgrandtotal.Text;
                            club_card_balance = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The customer have not enough balance to process to next step.", "Not Enough Balance!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("This customer have not enough balance to process to next step.", "Transaction Fail!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            else
            {
                MessageBox.Show("Invalid customer card no.", "Invalid Customer!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        UserLevelDiscount ulds = new UserLevelDiscount();
        public void userLevelDiscuntCalculation()
        {
            if (txtpan_no.Text.Length > 0 && txtsubtotal.Text != "0" && txtsubtotal.Text != "0.00")
            {
                lbldiscount.Text = (ulds.calculateDiscount(txtpan_no.Text, Convert.ToDecimal(txtsubtotal.Text))).ToString();
                if (Convert.ToDecimal(lbldiscount.Text) != 0)
                {
                    discount_percent = ulds.discountPercent.ToString();
                    lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                    discount_amount = lbldiscount.Text;
                    tax_calcu();
                    cashamount_recived_amount();
                }

            }
        }

        private void btn_card_balance_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerCardDetail cif = new Customer_Management.CustomerCardDetail();
            cif.ShowDialog();
        }


        string void_bill_no;
        bool void_status;
        VoidModel vm = new VoidModel();
        private void btn_bill_void_Click(object sender, EventArgs e)
        {
            if (void_status == true)
            {
                AddItemForVoid siv = new AddItemForVoid("VB");
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
                        dataGridView1.Rows[abc].Cells["cal_category_name"].Value = VoidModel.category_name[i];
                        dataGridView1.Rows[abc].Cells["cal_kot_type"].Value = VoidModel.kot_type[i];
                        dataGridView1.Rows[abc].Cells["cal_comp_status"].Value = "";
                        dataGridView1.Rows[abc].Cells["cal_service_provider"].Value = "";
                        dataGridView1.Rows[abc].Cells["cal_sales_type"].Value = "" ;
                        dataGridView1.Rows[abc].Cells["cal_order_id"].Value = "0";
                        dataGridView1.Rows[abc].Cells["cal_kot_id"].Value = "0";

                    }
                    calculate_total();

                }

            }
            if (void_status == false)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
                user_access_check = AdminAccess.discount_access_value;
                if (user_access_check == true)
                {

                    VoidBill vb = new VoidBill();
                    vb.fiscal_year = fiscal_year;
                    vb.ShowDialog();
                    if (vb.DialogResult == DialogResult.OK)
                    {
                        void_bill_no = vb.txt_void_bill_no.Text;
                        if (void_bill_no.Length > 0 && void_bill_no != "")
                        {

                            DataTable dt = blresll.get_all_value_by_bill_no(void_bill_no, fiscal_year);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.Rows.Clear();
                                for (int z = 0; z < dt.Rows.Count; z++)
                                {
                                    int abc = dataGridView1.Rows.Add();
                                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item_name"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_kot_type"].Value = dt.Rows[z]["kot_type"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_sales_type"].Value = dt.Rows[z]["sales_type"].ToString();//database column username is use for sales type 
                                    dataGridView1.Rows[z].Cells["cal_service_provider"].Value = dt.Rows[z]["service_provider"].ToString();
                                    dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";
                                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = "0";
                                    dataGridView1.Rows[abc].Cells["cal_kot_id"].Value = "0";

                                }

                                calculate_total();
                                dataGridView1.Columns["cal_delete"].Visible = true;
                                void_status = true;
                                btn_bill_void.Text = "Add Item";
                            }
                        }
                    }
                }
              
            }

        }
        int dgvColumnId = -1;//datagridview column id
        int dgvRowIndex;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0))
            {
                DataTable dtaccess = bldd.GetAdminAccessDelete();
                if (dtaccess.Rows.Count > 0)
                {
                    AdminAccess ac = new AdminAccess();
                    ac.ShowDialog();
                    if (ac.DialogResult == DialogResult.OK)
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        calculate_total();
                    }
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    calculate_total();
                }
            }
            if ((e.ColumnIndex == dataGridView1.Columns["cal_qty"].Index && e.RowIndex >= 0))
            {
                if (void_status == true)
                {
                    dgvColumnId = e.RowIndex;
                }
            }
            if ((e.ColumnIndex == dataGridView1.Columns["cal_complementary"].Index && e.RowIndex >= 0))
            {
                DataTable dtcaccess = bldd.GetAdminAccessComplementry();

                if (dtcaccess.Rows.Count > 0)
                {
                    AdminAccess ac = new AdminAccess();
                    ac.ShowDialog();
                    if (ac.DialogResult == DialogResult.OK)
                    {
                        if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cal_total"].Value) > 0)
                        {
                            if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cal_qty"].Value) > 1)
                            {
                                dgvRowIndex = e.RowIndex;
                                ComplementryBillSlip();
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["cal_comp_status"].Value = "C";
                                dataGridView1.Rows[e.RowIndex].Cells["cal_total"].Value = "0.00";
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                            }

                            AdvanceDiscount();
                            calculate_total();
                        }
                    }
                }
                else
                {
                    if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cal_total"].Value) > 0)
                    {
                        if (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cal_qty"].Value) > 1)
                        {
                            dgvRowIndex = e.RowIndex;
                            ComplementryBillSlip();
                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["cal_comp_status"].Value = "C";
                            dataGridView1.Rows[e.RowIndex].Cells["cal_total"].Value = "0.00";
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;

                        }

                        AdvanceDiscount();
                        calculate_total();
                    }
                }
            }
        }
        public void ComplementryBillSlip()
        {

            bool Found = false;
            if (dataGridView1.Rows.Count > 0)
            {

                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["cal_item_name"].Value.ToString() == dataGridView1.CurrentRow.Cells["cal_item_name"].Value.ToString() && row.Cells["cal_comp_status"].Value.ToString() == "C")
                    {
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        row.Cells["cal_qty"].Value = Convert.ToString(1 + Convert.ToDecimal(row.Cells["cal_qty"].Value ?? String.Empty));
                        row.Cells["cal_total"].Value = "0.00";
                        Found = true;

                    }
                }

            }
            if (!Found)
            {
                int rowCount = dataGridView1.Rows.Count;
                int isi = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowCount].Cells["cal_item_name"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_item_name"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_qty"].Value = 1;
                dataGridView1.Rows[rowCount].Cells["cal_cost"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value;
                decimal total = 1 * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].Cells["cal_category_name"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_category_name"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_total"].Value = "0.00";
                dataGridView1.Rows[rowCount].Cells["cal_sales_type"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_sales_type"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_kot_type"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_kot_type"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_comp_status"].Value = "C";
                dataGridView1.Rows[rowCount].Cells["cal_service_provider"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_service_provider"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_order_id"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_order_id"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_kot_id"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_kot_id"].Value;
                dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) - 1;
                dataGridView1.Rows[dgvRowIndex].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor = Color.DarkGray;

            }
        }
        public void ItemSlipt()
        {

            bool Found = false;
            if (dataGridView1.Rows.Count > 0)
            {

                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["cal_item_name"].Value.ToString() == dataGridView1.CurrentRow.Cells["cal_item_name"].Value.ToString() && row.Cells["cal_comp_status"].Value.ToString() == "S")
                    {
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        row.Cells["cal_qty"].Value = Convert.ToString(1 + Convert.ToDecimal(row.Cells["cal_qty"].Value ?? String.Empty));
                        row.Cells["cal_total"].Value = Convert.ToDecimal(row.Cells["cal_qty"].Value) * Convert.ToDecimal(row.Cells["cal_cost"].Value);
                        Found = true;

                    }
                }

            }
            if (!Found)
            {
                int rowCount = dataGridView1.Rows.Count;
                int isi = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowCount].Cells["cal_item_name"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_item_name"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_qty"].Value = 1;
                dataGridView1.Rows[rowCount].Cells["cal_cost"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value;
                decimal total = 1 * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].Cells["cal_category_name"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_category_name"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_total"].Value = "0.00";
                dataGridView1.Rows[rowCount].Cells["cal_sales_type"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_sales_type"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_kot_type"].Value = dataGridView1.Rows[dgvRowIndex].Cells["cal_kot_type"].Value;
                dataGridView1.Rows[rowCount].Cells["cal_comp_status"].Value = "S";
                dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) - 1;
                dataGridView1.Rows[dgvRowIndex].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[rowCount].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[rowCount].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor = Color.DarkGray;

            }
        }

        IRDSalesReturnAPI rsra = new IRDSalesReturnAPI();
        public void billVoid()
        {
            if (void_status == true)
            {
                if (void_bill_no.Length > 0 && void_bill_no != "")
                {

                    DataTable dtbd = blbd.selectAllData();
                    if (dtbd.Rows.Count > 0)
                    {
                        if (dtbd.Rows[0]["sync_ird"].ToString() == "True")
                        {
                            var connec = ic.CheckForInternetConnection();
                            if (connec == true)
                            {

                                int IRd = rsra.salesReturnAPI(txtpan_no.Text, cbo_customer_name.Text, void_bill_no, txtnewbillno.Text, nepaliDateConvert, "Billing Mistake", Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(subtotal_with_services), Convert.ToDouble(lbl_tax.Text), true);
                                int updateVoidAvtive = blfsc.updateVOidMateri(Convert.ToInt32(void_bill_no));

                            }
                            else
                            {
                                int irdVoid = blbt.irdCBMSsalesReturn(txtpan_no.Text, cbo_customer_name.Text, void_bill_no, txtnewbillno.Text, nepaliDateConvert, "Billing Mistake", txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
                                int updateVoidAvtive = blfsc.updateVOidMateri(Convert.ToInt32(void_bill_no));
                            }
                        }
                        else
                        {
                            int irdVoid = blbt.irdCBMSsalesReturn(txtpan_no.Text, cbo_customer_name.Text, void_bill_no, txtnewbillno.Text, nepaliDateConvert, "Billing Mistake", txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
                            int updateVoidAvtive = blfsc.updateVOidMateri(Convert.ToInt32(void_bill_no));
                        }
                    }
                }
            }
        }


        public void complementarySalesALL()
        {

            AdminAccess ac = new AdminAccess();
            ac.ShowDialog();
            if (ac.DialogResult == DialogResult.OK)
            {
                Complementryprinting_for_80();
                for (int a = 0; a < dataGridView1.Rows.Count; a++)
                {

                    string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                    decimal quantity = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                    decimal total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                    string category_name1 = dataGridView1.Rows[a].Cells["cal_category_name"].Value.ToString();
                    string kot_type = dataGridView1.Rows[a].Cells["cal_kot_type"].Value.ToString();
                    string sales_type = dataGridView1.Rows[a].Cells["cal_sales_type"].Value.ToString();
                    decimal comptotal = cost * quantity;
                    int insertcomplemenrtysaletra = blcomp.insertcomplementry_using_sp(date, txtcashier.Text, item, quantity, cost, kot_type, category_name1, cbo_customer_name.Text, cbo_customer_no.Text, "RS", "X", comptotal, complementryInvoiceNo);
                    if (insertcomplemenrtysaletra > 0)
                    {
                        int complementrInsert = blcomp.complementryInsert(Convert.ToInt32(txtnewbillno.Text), item, quantity, cost, date, txtcashier.Text, "RS", complementryInvoiceNo);


                        save_data = true;
                        DataTable dt = blord.getallbyitem_name(item);
                        if (dt.Rows.Count > 0)
                        {
                            im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                        }
                    }

                }


            }
            ComplementryInvoiceNo();
        }

        ComplementryPrint cpB80 = new ComplementryPrint();
        public void Complementryprinting_for_80()
        {
            cpB80.bill_no = complementryInvoiceNo.ToString();
            cpB80.cashier = txtcashier.Text;
            cpB80.printer_name = "Billing";
            cpB80.table_no = lbltable.Text;
            cpB80.customer_PAN_no = txtpan_no.Text;
            cpB80.customer_name = cbo_customer_name.Text;
            cpB80.customer_address = customer_address;
            cpB80.customer_phone_no = cbo_customer_no.Text;
            cpB80.area_name = area_name;
            cpB80.billing_date = date;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cpB80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                cpB80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                cpB80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                cpB80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                cpB80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());

            }
            cpB80.printtobill();
            save_after_print = cpB80.save_after_print;

        }
        bool comp_status = false;
        CheckDynamic cd = new CheckDynamic();
        private void txtcashamount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                if (cbo_customer_name.Text == "Choose One" && cbo_customer_name.Text != "")
                {
                    MessageBox.Show("Choose Customer Alert !!", "Message");
                }
                else
                {
                    comp_status = cd.ComplementryAllAccess();
                    if (comp_status == true)
                    {
                        complementarySalesALL();
                        if (save_data == true)
                        {
                            int i = blord.deletefromtable(Convert.ToInt32(lbltable.Text));
                            dataGridView1.Rows.Clear();
                            clear();
                            save_data = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Complemetry All Items Is Not Possible !!", "All Complementry Not Possible Alert !!");
                    }
                }
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                if (cbo_customer_name.Text == "Choose One" && cbo_customer_name.Text != "")
                {
                    MessageBox.Show("Choose Customer Alert !!", "Message");
                }
                else
                {
                    complementarySalesALL();
                    if (save_data == true)
                    {
                        int i = blord.deletefromtable(Convert.ToInt32(lbltable.Text));
                        int deleteQuotation = blpst.DeleteQuotation(lbltable.Text);
                        dataGridView1.Rows.Clear();
                        tabletuch();
                        clear();
                        save_data = false;
                    }
                }
            }

        }

        private void chk_fone_pay_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fone_pay.Checked)
            {
                if (Convert.ToDecimal(txtgrandtotal.Text) > 0)
                {
                    txtcardamount.Text = "0.00";
                    txtcashamount.Text = "0.00";
                    lblrecivedamount.Text = "0.00";
                    lblcardamount.Text = "0.00";
                    lbl_credit.Text = "0.00";
                    txtremainingamount.Text = "0.00";
                    lblchangeamout.Text = "0.00";
                    txtcardamount.Text = txtgrandtotal.Text;
                    payment_mode = "FonePay";
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("/", "");

                    QRCodeScan qrc = new QRCodeScan();
                    QRCodeScan.amount = txtgrandtotal.Text;
                    QRCodeScan.remarks2 = txtnewbillno.Text;
                    QRCodeScan.remarks = "Billing";
                    QRCodeScan.prnNo = fiscal_year + "-" + txtnewbillno.Text + "-" + GuidString.Substring(0,5);
                    qrc.ShowDialog();
                    if (qrc.DialogResult == DialogResult.OK)
                    {
                        btnprintandsave_Click_1(null, null);
                    }
                }
            }
        }
        public static string remaning_amount;
        private void btndonation_Click(object sender, EventArgs e)
        {
            Donation.Donation dd = new Donation.Donation();
            remaning_amount = txtremainingamount.Text;
            dd.ShowDialog();            
            donation_amount =Convert.ToDecimal(Donation.Donation.contribution_amount);
            event_id = Donation.Donation.event_id;
        }
        decimal donation_amount;
        string donation_payment_mode;
        int event_id;
        BLL_donation bldon = new BLL_donation();
        public void donation_paymentChecker()
        {
            if (Donation.Donation.con_payment_mode == "FonePay")
            {
                donation_payment_mode = "FonePay";
            }
            else
            {
                donation_payment_mode = payment_mode;
            }
        }
        public void DonationInsert()
        {
            if (event_id > 0 && donation_amount > 0)
            {
                int insertDonaation = bldon.insertDonationAmount(customer_id,event_id,donation_payment_mode,donation_amount.ToString(),date);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        string sales_type = "TS";
        BLLTable blta = new BLLTable();
       
        private void btn_settlement_Click(object sender, EventArgs e)
        {
            if (cbo_customer_name.Text != "" && cbo_customer_name.Text != "Choose One" && cbo_customer_name.SelectedIndex > 0)
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                        string item_name = dataGridView1.Rows[ib].Cells["cal_item_name"].Value.ToString();
                        decimal quantity = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_total"].Value.ToString());
                        string category_name = dataGridView1.Rows[ib].Cells["cal_category_name"].Value.ToString();
                        string kot_print = dataGridView1.Rows[ib].Cells["cal_kot_type"].Value.ToString();
                        string kot_id = dataGridView1.Rows[ib].Cells["cal_kot_id"].Value.ToString();
                        string service_provider = dataGridView1.Rows[ib].Cells["cal_service_provider"].Value.ToString();
                        DateTime todaydate = DateTime.Now;

                        int insert_order = blord.InsertOrder_Customer_sp(Convert.ToInt32(cbo_customer_name.SelectedValue), Login.sendtext, Convert.ToDecimal(lbltable.Text), item_name, quantity, total, cost, sales_type, category_name, kot_print, sales_type, service_provider, Convert.ToInt32(kot_id));

                    }

                    dataGridView1.Rows.Clear();
                    int transfer_order = blta.delete_table_order(Convert.ToInt32(lbltable.Text));
                    int deleteQuotation = blpst.DeleteQuotation(lbltable.Text);
                    Billing_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Nothing To Transfer Alert !!", "Cancel Alert !!");
                }
            }
            else
            {
                MessageBox.Show("Choose Settlement Customer Name Alert !!", "Required Name Alert !!");
            }
        }
        bool reward_check;
        private void btn_reward_Click(object sender, EventArgs e)
        {
            if (reward_check == false)
            {
                reward_check = true;
                dataGridView1.RowHeadersVisible = true;
                btn_x_billing.Enabled = false;
                btn_x_save_only.Enabled = false;
            }
            else if (reward_check == true)
            {
                dataGridView1.ClearSelection();
                reward_check = false;
                dataGridView1.RowHeadersVisible = false;
                calculate_total();

            }
        }
        public void rewardDataInsert()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    string item = (dr.Cells["cal_item_name"].Value.ToString());
                    decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                    decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                    string category_name1 = dr.Cells["cal_category_name"].Value.ToString();
                    string kot_type = dr.Cells["cal_kot_type"].Value.ToString();
                    string sales_type = dr.Cells["cal_sales_type"].Value.ToString();
                    int order_id = Convert.ToInt32(dr.Cells["cal_order_id"].Value);

                    int insertReward = blloy.insertLoyaltyReward(date, txtcashier.Text, item, quantity, cost, total,Convert.ToDecimal(txtgrandtotal.Text) , kot_type, category_name1, cbo_customer_name.Text, cbo_customer_no.Text, "RS", "X",  complementryInvoiceNo);
                    if (insertReward > 0)
                    {
                        int deleteOrder = blord.deletefromorder_id(order_id);
                        dataGridView1.Rows.RemoveAt(dr.Index);
                    }
                }
            }
        }

        private void chk_cheque_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cheque.Checked)
            {
                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                lblrecivedamount.Text = "0.00";
                lblcardamount.Text = "0.00";
                lbl_credit.Text = "0.00";
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";
                payment_mode = "Cheque";
                txtcashamount.ReadOnly = false;
                btn_exact.Visible = true;
                txtcashamount.Visible = true;
                txtcardamount.ReadOnly = false;
            }

        }

        private void chk_cheque_Click(object sender, EventArgs e)
        {
            bool checkdetail = cd.ChequeDetailAccess();
            if (checkdetail == true)
            {
                string paystatus = "Bill Payment";
                ChequeDetail cpd = new ChequeDetail(paystatus);
                cpd.ShowDialog();
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
           // groupBox1.Hide();
            groupBox2.Show();
            chkcash.Checked = true;
        }

        private void rbn_others_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
        }

        private void txtpan_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void chk_cash_credit_CheckedChanged(object sender, EventArgs e)
        {
            txtcardamount.Text = "0.00";
            txtcashamount.Text = "0.00";
            lblrecivedamount.Text = "0.00";
            lblcardamount.Text = "0.00";
            lbl_credit.Text = "0.00";
            txtremainingamount.Text = "0.00";
            lblchangeamout.Text = "0.00";
            payment_mode = "Cash/Credit";
            tax_calcu();
            txtcashamount.ReadOnly = false;
            btn_exact.Visible = true;
            txtcashamount.Visible = true;
            txtcardamount.ReadOnly = true;
        }

        private void chk_cash_credit_Click(object sender, EventArgs e)
        {
            txtcardamount.Enabled = true;
            chkcash.Checked = false;
            payment_mode = "Cash/Credit";
            // btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }
    }
}



