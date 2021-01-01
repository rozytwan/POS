using BLLS;
using BLLS.BLLHotel;
using BLLS.Hotel;
using POS_System.Hotel;
using POS_System.IRT;
using POS_System.Void;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class HotelBilling : UserControl
    {
        public HotelBilling(string room_no,string room_id)
        {
            InitializeComponent();
            hotel_room_no = room_no;
            hotel_room_id = room_id;
        }
        AdvanceDiscount adss = new AdvanceDiscount();
        BillingDetails bldetails = new BillingDetails();
        string hotel_room_no;
        string hotel_room_id;
        BLLTakeAway bltk = new BLLTakeAway();
        BillPrinting blp = new BillPrinting();
        HotelBilling80 blp_80 = new HotelBilling80();
        HotelBilling76 blp_76 = new HotelBilling76();
        BLL_Pending pend = new BLL_Pending();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        BLLRestSell blresll = new BLLRestSell();
        BLLcustomer_credit blc_credit = new BLLcustomer_credit();
        BLLOrder blord = new BLLOrder();
        BLL_hotel_order order = new BLL_hotel_order();
        BLL_HotelCustomer customer = new BLL_HotelCustomer();
        BLLHotelRoom room = new BLLHotelRoom();
        BLL_checkout checkout=new BLL_checkout();
        bool save_only_trasaction = false;
        bool save_data = false;
        string discount_percent;
        public string area_name;
        Button btn_category = new Button();
        BLL_HotelCategory category = new BLL_HotelCategory();
        IRT.IRTAPI apir = new IRT.IRTAPI();
        InternetConnection ic = new InternetConnection();
        BLLComplementry blcomp = new BLLComplementry();
        Ingredient im = new Ingredient();
        CheckDynamic cd = new CheckDynamic();
        bool checkoutChange = false;
        string fiscal_year;
        public string category_name = "";
        public static int room_category_id = 0;
        DataTable dt4 = new DataTable();
        private void HotelBilling_Load(object sender, EventArgs e)
        {
            lbl_room.Text = hotel_room_no;
        
            CUstomer_name();
            CUstomer_number();
            LoadPackage();
            dateConvertToNepali();
            bill();
            ComplementryInvoiceNo();
            DataTable dt1 = room.GetDates(Convert.ToInt32(hotel_room_id));
            if (dt1.Rows.Count>0)
            {
                dtp_checkin.Text = dt1.Rows[0]["check_in"].ToString();
                dtp_check_out.Text = dt1.Rows[0]["check_out"].ToString();
            }
            dt4 = room.GetBookCustomer(hotel_room_id);
            lbl_visited_customer.Text = dt4.Rows[0]["customer_id"].ToString();
            customer_id = Convert.ToInt32(lbl_visited_customer.Text);
      
            if (dt4.Rows.Count > 0)
            {
                cbo_customer_no.Text = dt4.Rows[0]["contact"].ToString();
                cbo_customer_name.Text = dt4.Rows[0]["f_name" ].ToString()+" "+ dt4.Rows[0]["l_name"].ToString();
               
            }
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            DataTable dtvc = checkout.SearchCustomer(customer_id);
            if (dtvc.Rows.Count > 0)
            {
                lbl_visited_customer.Text = "Visited Customer";
                //DialogResult dig = MessageBox.Show("Visted Customer would you like to give discount?", "Discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dig == DialogResult.Yes)
                //{
                //    MessageBox.Show("distoucyt ");
                //}
            }
            GetDays();
            datagridviewload();
  }
        string room_price;
        public void GetDays()
        {
            status = false;
            DateTime check_inDate = Convert.ToDateTime(dtp_checkin.Text);
            DateTime check_outDate = Convert.ToDateTime(dtp_check_out.Text);
            TimeSpan ts = check_outDate - check_inDate;
            int days = Math.Abs(ts.Days);
            if (ts.Days >= 0)
            {
                int timenow = DateTime.Now.Hour;
                if (timenow <= 12)
                {
                    lbl_days.Text = ((days) - 1).ToString();
                }
                else
                {
                    lbl_days.Text = (days).ToString();
                }

                DataTable dt1 = checkout.GetPriceByid(Convert.ToInt32(hotel_room_id));
                if (dt1.Rows.Count > 0)
                {
                    room_price = dt1.Rows[0][0].ToString();
                    if (Convert.ToInt32(lbl_days.Text) > 0)
                    {

                        txt_room_charge.Text = (Math.Abs(Convert.ToInt32(lbl_days.Text)) * Convert.ToDecimal(room_price)).ToString();

                    }
                    else
                    {
                        txt_room_charge.Text = room_price.ToString();
                        lbl_days.Text = "1";
                    }
                }

            }
            else
            {
                MessageBox.Show("Checkout Date Is Greater Than Checkin date . ", "Checkout Date Must Extend Alert !!");
                //HotelBilling_Load(null, null);

            }
        }
        public void LoadPackage()
        {
            DataTable dt = category.GetRoomPackage();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["package_name"] = "Choose Package";
                dt.Rows.InsertAt(dr, 0);
                cmb_package.DataSource = dt;
                cmb_package.DisplayMember = "package_name";
                cmb_package.ValueMember = "package_id";
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
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
      
        string package_name;
        decimal price;
        int package_id;
        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();

            dt = order.GetRoomOrder(hotel_room_id);
            //  dt2 = room.GetRoomId(hotel_room_no);
            //dt4 = room.GetBookCustomer(hotel_room_id);
            package_id = Convert.ToInt32(dt4.Rows[0]["package_id"].ToString());

            dt3 = category.GetRoompackageById(package_id);
            if (dt3.Rows.Count>0)
            {
                package_name = dt3.Rows[0]["package_name"].ToString();
                price = Convert.ToDecimal(dt3.Rows[0]["price"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Add("Room Charge", lbl_days.Text, room_price, txt_room_charge.Text, "Room", "K1", "HR", "0");
            
                if (dt3.Rows.Count > 0 ||package_id!=0)
                {
                    dataGridView1.Rows.Add(package_name, 1, price, price, "Package", "K1", "HR", "0");
                    checkoutChange = true;
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        dataGridView1.Rows[z + 2].Cells["cal_order_id"].Value = dt.Rows[z]["hotel_order_id"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_kot_type"].Value = dt.Rows[z]["kot_print"].ToString();
                        dataGridView1.Rows[z + 2].Cells["cal_sales_type"].Value = dt.Rows[z]["phone"].ToString();
                        dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";//database column username is use for sales type 
                    }
                }

                else
                {
                    checkoutChange = true;
                    for (int z = 0; z < dt.Rows.Count; z++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        dataGridView1.Rows[z + 1].Cells["cal_order_id"].Value = dt.Rows[z]["hotel_order_id"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_kot_type"].Value = dt.Rows[z]["kot_print"].ToString();
                        dataGridView1.Rows[z + 1].Cells["cal_sales_type"].Value = dt.Rows[z]["phone"].ToString();
                        dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";//database column username is use for sales type 
                    }
                }
                calculate_total();
                AdvancePayment();

            }
            else
            {
                dataGridView1.Rows.Add("Room Charge", lbl_days.Text, room_price, txt_room_charge.Text, "Room", "K1", "HR", "0");
                 if (dt3.Rows.Count > 0|| package_id!=0 && package_id>0)
                    {
                        dataGridView1.Rows.Add(package_name, 1, price,price, "Package", "K1", "HR", "0");

                    }
                  checkoutChange = true;
                calculate_total();
                AdvancePayment();


            }
            back_screan();
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
        public void calculate_total()
        {
            decimal sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1.Rows[i].Cells["cal_total"].Value.ToString() !="")
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                }
            }
            txtsubtotal.Text = sum.ToString("#.##");
            lblsub_total.Text = sum.ToString("#.##");
            tax_calcu();
            adss.txt_discount_amount.Text = "0.00";
            adss.txt_discount_percent.Text = "0.00";
            adss.discount_amount = 0;
            adss.discount_amount_percent = 0;
            lbldiscount.Text = "0.00";
            back_screan();
        }
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
        decimal service_charge = 0;
        bool save_after_print;
        decimal subtotal_with_services;
        string discount_amount = "0.00";
        bool multi_billing_check = false;
        bool club_card_balance = false;
        public string payment_mode="Cash";
        bool service_status;
        public void tax_calcu()
        {
            if (lblsub_total.Text != "")
            {
                lbl_chargeableamt.Text = (Convert.ToDecimal(lblsub_total.Text) - Convert.ToDecimal(txt_room_charge.Text)).ToString();
                TaxCalculation tax = new TaxCalculation();
                service_status = cd.RoomServiceCharge();
                if (service_status==true)
                {
                    service_charge = tax.service_calculation(Convert.ToDecimal(lbl_chargeableamt.Text));
                }

                subtotal_with_services = (Convert.ToDecimal(lblsub_total.Text) + service_charge);
                tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                static_grand_total = Convert.ToDecimal(lblsub_total.Text) + tax_amount + service_charge;
                txtgrandtotal.Text = static_grand_total.ToString("#.##");
                lbl_tax.Text = tax_amount.ToString("#.##");
                lbl_service_charge.Text = service_charge.ToString("#.##");
             
                if (lbl_service_charge.Text == "")
                {
                    lbl_service_charge.Text = "0.00";
                }
                if (lbl_tax.Text == "")
                {
                    lbl_tax.Text = "0.00"; 
                }
            }
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
        public void back_screan()
        {
            try
            {
                SerialPort serialPort = new SerialPort("COM2");
                serialPort.PortName = "COM2";
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.None;
                serialPort.RtsEnable = true;
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    byte[] bytesToSend = new byte[1] { 0x0C }; // send hex code 0C to clear screen
                    serialPort.Write(bytesToSend, 0, 1);
                    serialPort.ReadTimeout = 200;
                    serialPort.WriteLine(String.Format("Grand Total" + "         " + txtgrandtotal.Text));

                    serialPort.Close();
                    serialPort.Dispose();
                }
            }
              catch (Exception)
            {


            }
        }
        public void AdvancePayment()
        {
            txtcashamount.Text = "0.00";
            txtcashamount.BackColor = System.Drawing.Color.White;
            DataTable dt = blcd.GetAdvancePay(lbl_room.Text);
            if (dt.Rows.Count > 0)
            {
                txtcashamount.Text = dt.Rows[0]["received_amount"].ToString();
                txtremainingamount.Text = (Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtcashamount.Text)).ToString();
                txtcashamount.BackColor = System.Drawing.Color.Red;
                // txtremainingamount.Text = "0.00";
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
        private void btn_x_billing_Click(object sender, EventArgs e)
        {
            if (txtpan_no.Text.Length > 0 && txtpan_no.Text.Length != 9 && label13.Text != "Club Card No")
            {
                MessageBox.Show("Incorrect Pan No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do You Like Create New Billing ", "Billing Process", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        save_and_print();

                        if (save_data == true)
                        {
                            bldetails.grand_total = txtgrandtotal.Text;
                            bldetails.remaining_amount = txtremainingamount.Text;
                            bldetails.received_amount = txtcashamount.Text;
                            bldetails.bill_no_print = txtnewbillno.Text;
                            billing_details_value();
                            bldetails.ShowDialog();
                            clear();
                            dataGridView1.Rows.Clear();
                            CUstomer_name();
                            txtnewbillno.Clear();
                            bill();
                            clear();
                            CUstomer_name();
                            CUstomer_number();
                            calculate_total();
                            HotelAdminAccess.discount_access_value = false;
                            user_log_insert();
                            adss.txt_discount_amount.Text = "0.00";
                            adss.txt_discount_percent.Text = "0.00";
                            adss.discount_amount = 0;
                            adss.discount_amount_percent = 0;
                            club_card_balance = false;
                            dataGridView1.Columns["cal_delete"].Visible = false;
                            save_only_trasaction = false;
                            save_data = false;
                        }
                    }
                }
                }
            
        
        int customer_id = 0;
        string sync_with_ird = "false";
        public void materialized_view_save()
        {
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                
                int fiscal = blfsc.insert_Materialized_View(fiscal_year, Convert.ToInt32(txtnewbillno.Text), cbo_customer_name.Text, "", date, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), subtotal_with_services, tax_amount, "False", "True", date.ToString("HH:mm tt"), txtcashier.Text, txtcashier.Text, sync_with_ird, sync_with_ird);
            }
            else
            {
                int fiscal = blfsc.insert_Materialized_View("", Convert.ToInt32(txtnewbillno.Text), cbo_customer_name.Text, "", date, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), subtotal_with_services, tax_amount, "False", "True", date.ToString("HH:mm tt"), txtcashier.Text, txtcashier.Text, sync_with_ird, sync_with_ird);
                MessageBox.Show("Information", "Please Set The Fiscal Year", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        string complementru_status;
        string kot_type;
        public void billing_save_with_multi()
        {
            if (save_after_print == true || save_only_trasaction == true)
            {
                if (multi_billing_check == true)
                {

                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        string item = (dr.Cells["cal_item_name"].Value.ToString());
                        decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                        string category_name1 = dr.Cells["cal_category_name"].Value.ToString();
                        string kot_type = dr.Cells["cal_kot_type"].Value.ToString();
                        if (category_name1=="Room")
                        {
                            kot_type = "R1";
                        }
                       string sales_type = dr.Cells["cal_sales_type"].Value.ToString();
                       // string complementru_status = dr.Cells["cal_comp_status"].Value.ToString();
                        if (chkcash.Checked || chkcard.Checked || chkcash_card.Checked)
                        {

                            int b = order.inserthotelsales(Convert.ToInt32(txtnewbillno.Text), date, username, lbl_room.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), category_name1,service_charge,subtotal_with_services,Convert.ToDecimal(lbl_tax.Text),fiscal_year,"X");
                            if (b > 0)
                            {
                                if (b > 0)
                                {
                                    // int deleteadvancepay = bld.DeleteAdvancePay(lbl_room.Text);
                                    if (complementru_status == "C")
                                    {
                                        int complementrInsert = blcomp.complementryInsert(Convert.ToInt32(txtnewbillno.Text), item, quantity, cost, date, comp_user, "HC", complementryInvoiceNo);
                                    }

                                    DataTable dt = blord.getallbyitem_name(item);
                                    if (dt.Rows.Count > 0)
                                    {
                                        im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                                    }
                                    save_data = true;

                                }
                            }
                        }
                        
                        else if (chkcredit.Checked)
                        {
                            if (customer_id > 0)
                            {
                                int b = order.inserthotelsales(Convert.ToInt32(txtnewbillno.Text), date, username, lbl_room.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), category_name1,service_charge,subtotal_with_services, Convert.ToDecimal(lbl_tax.Text), fiscal_year,"X");

                                if (b > 0)
                                {
                                    customer_id = 0;
                                    save_data = true;
                                }
                            }
                        }
                    }
                    //IRD();
                    //billVoid();
                    //int vb = blresll.voidBillInsert(Convert.ToInt32(void_bill_no), Convert.ToInt32(txtnewbillno.Text), "", "True", date, Login.sendtext);//void bill no save 
                    //if (vb > 0)
                    //{
                    //    void_status = false;
                    //}
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
                        if (category_name1 == "Room")
                        {
                            kot_type = "R1";
                        }
                        string sales_type = dataGridView1.Rows[a].Cells["cal_sales_type"].Value.ToString();
                        if (dataGridView1.Rows[a].Cells["cal_comp_status"].Value == null)
                        {
                            complementru_status = "";
                        }
                        else
                        {
                             complementru_status = dataGridView1.Rows[a].Cells["cal_comp_status"].Value.ToString();
                        }
                        if (chkcash.Checked || chkcard.Checked || chkcash_card.Checked)
                        {
                       
                            int b = order.inserthotelsales(Convert.ToInt32(txtnewbillno.Text), date, username, lbl_room.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), category_name1,service_charge,subtotal_with_services, Convert.ToDecimal(lbl_tax.Text), fiscal_year,"X");
                            if (b > 0)
                            {
                                if (b > 0)
                                {
                                   // int deleteadvancepay = bld.DeleteAdvancePay(lbl_room.Text);
                                    if (complementru_status == "C")
                                    {
                                        int complementrInsert = blcomp.complementryInsert(Convert.ToInt32(txtnewbillno.Text), item, quantity, cost, date,comp_user,"HC", complementryInvoiceNo);
                                    }

                                    DataTable dt = blord.getallbyitem_name(item);
                                    if (dt.Rows.Count > 0)
                                    {
                                        im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                                    }
                                    save_data = true;

                                }
                            }


                        }
                        else if (chkcredit.Checked)
                        {
                            decimal actualcreditamount = Convert.ToDecimal(txtgrandtotal.Text);
                            int b = order.inserthotelsales(Convert.ToInt32(txtnewbillno.Text), date, username, lbl_room.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discount_amount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), category_name1,service_charge,subtotal_with_services, Convert.ToDecimal(lbl_tax.Text), fiscal_year,"X");
                            if (b > 0)
                            {
                                save_data = true;
                                customer_id = 0;
                            }
                        }
                    }
                    //IRD();
                    //billVoid();
                    //int vb = blresll.voidBillInsert(Convert.ToInt32(void_bill_no), Convert.ToInt32(txtnewbillno.Text), "", "True", date, Login.sendtext);//void bill no save 
                    //if (vb > 0)
                    //{
                    //    void_status = false;
                    //}
                }
                if (chkcredit.Checked)
                {
                    decimal actualcreditamount = Convert.ToDecimal(txtgrandtotal.Text);
                    int creditrecord = blc_credit.insert_into_credit(Convert.ToInt32(cbo_customer_name.SelectedValue), Convert.ToInt32(txtnewbillno.Text), date, actualcreditamount,Login.sendtext,"HC");
                    customer_id = 0;
                }
            }
        }
        //public void IRD()
        //{
        //    var connec = ic.CheckForInternetConnection();
        //    if (connec == true)
        //    {
        //        int IRT = apir.posBilling(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(subtotal_with_services), Convert.ToDouble(lbl_tax.Text), true);
        //        sync_with_ird = "true";
        //        DataTable dt = blbt.checkDataIRDCBMS();
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                int IRDOnline = apir.posBilling(dt.Rows[i]["buyer_pan"].ToString(), dt.Rows[i]["buyer_name"].ToString(), dt.Rows[i]["invoice_number"].ToString(), dt.Rows[i]["invoice_date"].ToString(), Convert.ToDouble(dt.Rows[i]["total_sales"]), Convert.ToDouble(dt.Rows[i]["taxable_sales_vat"]), Convert.ToDouble(dt.Rows[i]["vat"]), false);
        //                if (IRDOnline > 0)
        //                {
        //                    int syncWithIRD = blfsc.updateSyncIRD(Convert.ToInt32(dt.Rows[i]["invoice_number"]));
        //                }
        //            }
        //            int irdTruncate = blbt.truncateIRDData();
        //        }

        //    }
        //    else
        //    {
        //        int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
        //        sync_with_ird = "false";
        //    }
        //}
        IRDSalesReturnAPI rsra = new IRDSalesReturnAPI();
        public void billVoid()
        {
            if (void_status == true)
            {
                if (void_bill_no.Length > 0 && void_bill_no != "")
                {

                    var connec = ic.CheckForInternetConnection();
                    if (connec == true)
                    {
                        int IRd = rsra.salesReturnAPI(txtpan_no.Text, cbo_customer_name.Text, void_bill_no, txtnewbillno.Text, nepaliDateConvert, "Billing Mistake", Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(subtotal_with_services), Convert.ToDouble(lbl_tax.Text), true);
                        int updateVoidAvtive = blfsc.updateVOidMateri(Convert.ToInt32(void_bill_no));
                        DataTable dt = blbt.checkDataIRDCBMSSalesReturn();
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int IRDOnlineSalesReturn = rsra.salesReturnAPI(dt.Rows[i]["buyer_pan"].ToString(), dt.Rows[i]["buyer_name"].ToString(), dt.Rows[i]["ref_invoice_number"].ToString(), dt.Rows[i]["credit_note_number"].ToString(), dt.Rows[i]["credit_note_date"].ToString(), dt.Rows[i]["reason_for_return"].ToString(), Convert.ToDouble(dt.Rows[i]["total_sales"]), Convert.ToDouble(dt.Rows[i]["taxable_sales_vat"]), Convert.ToDouble(dt.Rows[i]["vat"]), false);
                            }

                            int truncate = blbt.truncateIRDDataSalesReturn();
                        }
                    }
                    else
                    {
                        int irdVoid = blbt.irdCBMSsalesReturn(txtpan_no.Text, cbo_customer_name.Text, void_bill_no, txtnewbillno.Text, nepaliDateConvert, "Billing Mistake", txtgrandtotal.Text, subtotal_with_services.ToString(), lbl_tax.Text, "", "", "", "", "", "", "", "");
                        int updateVoidAvtive = blfsc.updateVOidMateri(Convert.ToInt32(void_bill_no));
                    }
                }

                void_bill_no = "";

            }
        }
        public void clear()
        {

            txtcardamount.Text = "0.00";
            txtcashamount.Text = "0.00";
            lbldiscount.Text = "0.00";
            lblrecivedamount.Text = "0.00";
            lblcardamount.Text = "0.00";
            txtremainingamount.Text = "0.00";
            lblchangeamout.Text = "0.00";
            txtgrandtotal.Text = "0.00";
            lblsub_total.Text = "0.00";
            txtpan_no.Text = "";
        }
        BillPrintingHotel bph = new BillPrintingHotel();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        BLLTakeAway bltak = new BLLTakeAway();
        Label[] lbl_table_name = new Label[99];
        Button[] newroom = new Button[99];
        BLLTable bltab = new BLLTable();
        public static int area_id = 0;
        public void save_and_print()
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {
                
                if (txtsubtotal.Text.Length > 0 && dataGridView1.Rows.Count > 0 || txtcardamount.Text != "0.00" || txtcashamount.Text != "0.00")
                {

                    if (chkcash.Checked)
                    {
                        if (Convert.ToDecimal(txtcashamount.Text) >= Convert.ToDecimal(txtgrandtotal.Text))
                        {

                            printer_checker();


                            save_only_trasaction = true;
                        }
                        else
                        {
                            MessageBox.Show("Can't Complete The Transaction, Cash Amount Is Too Low", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (chkcard.Checked)
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

                        printer_checker();
                        save_only_trasaction = true;
                    }
                    if (save_only_trasaction == true)
                    {
                        if (save_after_print == true)
                        {


                            billing_save_with_multi();
                         
                            if (save_data == true)
                            {
                                if (all_bill == true)
                                {
                                    if (multi_billing_check == true)
                                    {
                                        multi_billing();
                                    }
                                    else
                                    {
                                        int i = order.deleteallcustomerorder(Convert.ToInt32(lbl_visited_customer.Text));

                                        DataTable dtcb = room.SelectCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));
                                        if (dtcb.Rows.Count > 0)
                                        {
                                            for (int j = 0; j < dtcb.Rows.Count; j++)
                                            {
                                                int insertcheckouts = room.bulk_data_insert();
                                                string room_id = (dtcb.Rows[j]["room_id"].ToString());
                                                int updateRoom = category.UpdateRoombyid(Convert.ToInt32(room_id));
                                                int hotelBookingDelete = room.DeleteCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));
                                            }
                                        }
                                        // int hotelBookingDelete = room.DeleteCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));

                                    }
                                }
                                else if (multi_billing_check == true)
                                {
                                    multi_billing();
                                }
                                else
                                {
                                    int i = order.deletefromtable((hotel_room_id));
                                    int insertcheckout = room.bulk_data_insert();
                                    int hotelBookingDelete = room.deleteBooking(hotel_room_id);
                                    int updateRoom = category.UpdateRoombyid(Convert.ToInt32(hotel_room_id));
                                }
                                
                                int ibiza = blresll.insert_into_bill_invoice(Convert.ToInt32(txtnewbillno.Text));
                                int deleteQuotation = blpst.DeleteQuotation(hotel_room_no);
                                // int tax_bill = blbt.billing_tax(Convert.ToInt32(txtnewbillno.Text), Convert.ToDecimal(lbl_tax.Text), Convert.ToDecimal(lbl_service_charge.Text), date);
                                materialized_view_save();
                            }
                            back_screan();
                            blp.save_after_print = false;
                        }
                    }
                }
            }

        }
         public void billing_details_value()
        {
            bldetails.bill_no = txtnewbillno.Text;
            bldetails.cashier = txtcashier.Text;
            bldetails.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            bldetails.discount = Convert.ToDecimal(discount_amount).ToString("#.##");
            bldetails.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            bldetails.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            bldetails.table_no = lbl_room.Text;
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
                        blp_80.printer_name = "H1";
                        blp_80.print_again = true;
                        blp_80.Headerstatus = true;
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            if (i > 0)
                            {
                                blp_80.print_again = true;
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
                        blp_76.printer_name = "H1";
                        blp_76.print_again = true;
                        blp_76.Headerstatus = true;
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            if (i > 0)
                            {
                                blp_76.print_again = true;
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
                        blp.printer_name = "H1";
                        bA4.print_again = true;
                        bA4.Headerstatus = true;
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            if (i > 0)
                            {
                                blp.print_again = true;
                            }
                            bill_printing_for_A4();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "A5")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        blp.printer_name = "H1";
                        bA5.print_again = true;
                        bA5.Headerstatus = true;
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            if (i > 0)
                            {
                                blp.print_again = true;
                            }
                            bill_printing_for_A5();

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
                        blp.printer_name = "H1";
                        blp_76.print_again = true;
                        blp_76.Headerstatus = true;
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {
                            if (i > 0)
                            {
                                blp.print_again = true;
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
        }
        HotelBillingA4 bA4 = new HotelBillingA4();
        HotelBillingA5 bA5= new HotelBillingA5();
        public void bill_printing_for_A4()
        {
            bA4.bill_no = txtnewbillno.Text;
            bA4.cashier = txtcashier.Text;
            bA4.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            bA4.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            bA4.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            bA4.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            bA4.table_no = lbl_room.Text;
            bA4.customer_PAN_no = txtpan_no.Text;
            bA4.customer_name = cbo_customer_name.Text;
          //  bA4.customer_address = customer_address;
            bA4.customer_phone_no = cbo_customer_no.Text;
            bA4.discount_percent = discount_percent;
            bA4.tax_amount = tax_amount.ToString("#.##");
            bA4.service_charge = service_charge.ToString("#.##");
            bA4.fiscal_year = fiscal_year;
            bA4.area_name = area_name;
            bA4.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
           // bA4.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
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
                    //bA4.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    //bA4.kot_no.Add(dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString());
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
                        //bA4.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        //bA4.kot_no.Add(dr.Cells["cal_kot_id"].Value.ToString());
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
        public void bill_printing_for_A5()
        {
            bA5.bill_no = txtnewbillno.Text;
            bA5.cashier = txtcashier.Text;
            bA5.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            bA5.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            bA5.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            bA5.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            bA5.table_no = lbl_room.Text;
            bA5.customer_PAN_no = txtpan_no.Text;
            bA5.customer_name = cbo_customer_name.Text;
            //  bA4.customer_address = customer_address;
            bA5.customer_phone_no = cbo_customer_no.Text;
            bA5.discount_percent = discount_percent;
            bA5.tax_amount = tax_amount.ToString("#.##");
            bA5.service_charge = service_charge.ToString("#.##");
            bA5.fiscal_year = fiscal_year;
            bA5.area_name = area_name;
            bA5.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            // bA4.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                bA5.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            bA5.billing_date = date;
            bA5.taxable_amount = subtotal_with_services.ToString("#.##");
            bA5.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
            if (multi_billing_check == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bA5.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    bA5.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    bA5.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    bA5.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    //bA4.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                    //bA4.kot_no.Add(dataGridView1.Rows[i].Cells["cal_kot_id"].Value.ToString());
                }
                bA5.printtobill();
                save_after_print = bA5.save_after_print;
            }
            else if (multi_billing_check == true)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        bA5.datagridview_item_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                        bA5.datagridview_item_price.Add(dr.Cells["cal_cost"].Value.ToString());
                        bA5.datagridview_total.Add(dr.Cells["cal_total"].Value.ToString());
                        bA5.datagridview_quantity.Add(dr.Cells["cal_qty"].Value.ToString());
                        //bA4.datagridview_complementary.Add(dr.Cells["cal_comp_status"].Value.ToString());
                        //bA4.kot_no.Add(dr.Cells["cal_kot_id"].Value.ToString());
                    }
                    bA5.printtobill();
                    save_after_print = bA5.save_after_print;
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
        public void bill_printing_for_58()
        {
            blp.bill_no = txtnewbillno.Text;
            blp.cashier = txtcashier.Text;
            blp.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp.discount = Convert.ToDecimal(discount_amount).ToString("#.##");
            blp.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp.table_no = lbl_room.Text;
            blp.customer_PAN_no = txtpan_no.Text;
            blp.customer_name = cbo_customer_name.Text;
            blp.discount_percent = discount_percent;
            blp.tax_amount = tax_amount.ToString("#.##");
            blp.service_charge = service_charge.ToString("#.##");
            blp.area_name = area_name;
            blp.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");

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
            blp_76.cashier = txtcashier.Text;
            blp_76.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_76.discount = Convert.ToDecimal(discount_amount).ToString("#.##");
            blp_76.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_76.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_76.table_no = lbl_room.Text;
            blp_76.customer_PAN_no = txtpan_no.Text;
            blp_76.customer_name = cbo_customer_name.Text;
            blp_76.discount_percent = discount_percent;
            blp_76.tax_amount = tax_amount.ToString("#.##");
            blp_76.service_charge = service_charge.ToString("#.##");
            blp_76.area_name = area_name;
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
            blp_80.bill_no = txtnewbillno.Text;
            blp_80.cashier = txtcashier.Text;
            blp_80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_80.discount = Convert.ToDecimal(discount_amount).ToString("#.##");
            blp_80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_80.table_no = lbl_room.Text;
            blp_80.customer_PAN_no = txtpan_no.Text;
            blp_80.customer_name = cbo_customer_name.Text;
            blp_80.discount_percent = discount_percent;
            blp_80.tax_amount = tax_amount.ToString("#.##");
            blp_80.service_charge = service_charge.ToString("#.##");
            blp_80.area_name = area_name;
            blp_80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
           
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
        public void payment_modeCheck()
        {
            if (chkcard.Checked)
            {
                blp_80.payment_mode = "Card";
            }
            else if (chkcash.Checked)
            {
                blp_80.payment_mode = "Cash";
            }
            else if (chkcash_card.Checked)
            {
                blp_80.payment_mode = "Card/Cash";
            }
           
        }

        public void multi_billing()
        {
            if (multi_billing_check == true)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    //DataGridViewRow startingBalanceRow = dataGridView1.Rows[2];
                    //if (dataGridView1.SelectedRows.Contains("Room Charge"))
                    //{

                    //}
                    int order_id = Convert.ToInt32(row.Cells["cal_order_id"].Value);
                    if (order_id>0)
                    {
                        int hotelOrder = room.deleteHotelOrderByid(order_id);
                    }
                
                }
            }  
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {                    
                    int order_id = Convert.ToInt32(row.Cells["cal_order_id"].Value);
                    int hotelOrder = room.deleteHotelOrderByid(order_id);
                    int insertcheckout = room.bulk_data_insert();
                    int hotelBookingDelete = room.deleteBooking(hotel_room_id);
                  int updateRoom = category.UpdateRoombyid(Convert.ToInt32(hotel_room_id));
                }
            }


        }
      
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            blp_80.printer_name = "Billing";
             blp_80.billing_print_only = true;
            bill_printing_for_80();
            if (txtcashamount.Text != "")
            {
                int insert = blpst.InsertQuotation(lbl_room.Text, Convert.ToDecimal(txtcashamount.Text), username, date);

            }


        }

        private void btn_x_save_only_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //if (dataGridView1.SelectedRows[0].Cells["cal_item_name"].Value.ToString()=="Room Charge")
                //{

                //}
         
                if (txtcardamount.Text != "0.00" || txtcashamount.Text != "0.00" || chkcredit.Checked)
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

                    else if (chkcredit.Checked)
                    {
                        if (cbo_customer_name.SelectedIndex > 0)
                        {
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
                    if (save_only_trasaction == true)
                    { 
                        billing_save_with_multi();

                        if (save_data == true)
                        {
                            if (all_bill == true)
                            {
                                if (multi_billing_check == true)
                                {
                                    multi_billing();
                                }
                                else
                                {
                                    int i = order.deleteallcustomerorder(Convert.ToInt32(lbl_visited_customer.Text));

                                    DataTable dtcb = room.SelectCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));
                                    if (dtcb.Rows.Count > 0)
                                    {
                                        for (int j = 0; j < dtcb.Rows.Count; j++)
                                        {
                                            int insertcheckouts = room.bulk_data_insert();
                                            string room_id = (dtcb.Rows[j]["room_id"].ToString());
                                            int updateRoom = category.UpdateRoombyid(Convert.ToInt32(room_id));
                                            int hotelBookingDelete = room.DeleteCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));
                                        }
                                    }
                                    // int hotelBookingDelete = room.DeleteCustomerBookings(Convert.ToInt32(lbl_visited_customer.Text));

                                }
                            }
                            else if (multi_billing_check == true)
                            {
                                multi_billing();

                            }
                            else
                            {
                                int i = order.deletefromtable((hotel_room_id));
                                int insertcheckout = room.bulk_data_insert();
                                int hotelBookingDelete = room.deleteBooking(hotel_room_id);
                                int updateRoom = category.UpdateRoombyid(Convert.ToInt32(hotel_room_id));
                            }
                               
                               
                            }
                            int ibiza = blresll.insert_into_bill_invoice(Convert.ToInt32(txtnewbillno.Text));
                            materialized_view_save();
                           // multi_billing();

                            bldetails.grand_total = txtgrandtotal.Text;
                            bldetails.remaining_amount = txtremainingamount.Text;
                            bldetails.received_amount = txtcashamount.Text;
                            bldetails.bill_no_print = txtnewbillno.Text;
                            billing_details_value();
                            bldetails.ShowDialog();

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
                            txtremainingamount.Text = "0.00";
                            lblchangeamout.Text = "0.00";
                            HotelAdminAccess.discount_access_value = false;
                            MessageBox.Show("Data has been save to database", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            adss.txt_discount_amount.Text = string.Empty;
                            adss.txt_discount_percent.Text = string.Empty;
                            adss.discount_amount = 0;
                            adss.discount_amount_percent = 0;
                        
                        }
                        dataGridView1.Columns["cal_delete"].Visible = false;
                        CUstomer_name();
                        CUstomer_number();
                        back_screan();
                        club_card_balance = false;
                        save_only_trasaction = false;
                    }
                }
            }
        

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (all_bill == false)
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
                else if (chkcash.Checked)
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

            }
            else if (txtcardamount.Text == "")
            {
                txtcardamount.Text = "0.00";
                lblcardamount.Text = "0.00";

            }

        }

        public bool user_access_check;
        AdvanceDiscount adis = new AdvanceDiscount();

        private void btn_advance_discount_Click(object sender, EventArgs e)
        {
            AdvanceDiscount adis = new AdvanceDiscount();
            user_access_check = HotelAdminAccess.discount_access_value;
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
                    adis.ShowDialog();
                    if (adis.DialogResult == DialogResult.OK)
                    {
                        lbldiscount.Text = (adis.discount_amount).ToString();
                        discount_percent = (adis.discount_amount_percent).ToString();
                        lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                        discount_amount = lbldiscount.Text;
                        tax_calcu();
                        cashamount_recived_amount();
                   
                    }

                }
            }
            else
            {
                HotelAdminAccess acc = new HotelAdminAccess();
                acc.ShowDialog();
                user_access_check = HotelAdminAccess.discount_access_value;
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
                        adis.ShowDialog();
                        if (adis.DialogResult == DialogResult.OK)
                        {
                            if (adis.DialogResult == DialogResult.OK)
                            {
                                lbldiscount.Text = (adis.discount_amount).ToString();
                                discount_percent = (adis.discount_amount_percent).ToString();
                                lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                                discount_amount = lbldiscount.Text;
                                tax_calcu();
                                cashamount_recived_amount();
                      
                            }
                        }
                    }
                }
            }

        }
        string void_bill_no;
        bool void_status;
        
        private void btn_bill_void_Click(object sender, EventArgs e)
        {
            HotelAdminAccess acc = new HotelAdminAccess();
            acc.ShowDialog();
            user_access_check = HotelAdminAccess.discount_access_value;
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
                        DataTable dt = blresll.get_all_value_by_bill_no(void_bill_no,fiscal_year);
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
                            }
                            calculate_total();
                            dataGridView1.Columns["cal_delete"].Visible = true;
                            void_status = true;
                        }
                    }
                }
            }
        }

      
        private void dtp_checkin_ValueChanged(object sender, EventArgs e)
        {
            GetDays();
            status = true;
        }

        private void dtp_check_out_ValueChanged(object sender, EventArgs e)
        {
            GetDays();
            status = true;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_exact_Click(object sender, EventArgs e)
        {
            if (txtgrandtotal.Text != "0.00" && txtgrandtotal.Text.Length > 0)
            {
                txtcashamount.Text = txtgrandtotal.Text;
            }
        }

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

        private void txtcashamount_Leave(object sender, EventArgs e)
        {
            if (txtcashamount.Text == "")
            {
                txtcashamount.Text = "0.00";
            }
        }

        private void txtcashamount_Enter(object sender, EventArgs e)
        {
            if (txtcashamount.Text == "0.00")
            {
                txtcashamount.Text = "";
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

        private void txtcashamount_TextChanged(object sender, EventArgs e)
        {
            cashamount_recived_amount();
            if (txtcashamount.Text == "" || txtcashamount.Text == "0.00")
            {
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";

            }
        }

        private void txtremainingamount_TextChanged(object sender, EventArgs e)
        {

        }  
        private void btn_booking_cancel_Click(object sender, EventArgs e)
        {
          
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string checkin = dtp_checkin.Value.ToString("yyyy-MM-dd");
                DataTable dt = checkout.GetHotelBooking(Convert.ToInt32(hotel_room_id));
                DataTable dtm = room.GetDates(Convert.ToInt32(hotel_room_id));
                int customer_id = Convert.ToInt32(dtm.Rows[0]["customer_id"].ToString());
                DataTable dt1 = room.GetOrderByCustomerId(Convert.ToInt32(customer_id));
                if (checkin != today)
                {
                    MessageBox.Show("You Do Have Room Charge.", "Room Charge Alert !!");
                }
                else if (dt1.Rows.Count > 0 && dt1.Rows[0][0].ToString() != " ")
                {
                    MessageBox.Show("Please Do Billing First.", "Order Alert !!");
                }

                else if (dtm.Rows.Count > 0)
                {
                DialogResult res = MessageBox.Show("Are you sure you want to Cancel booking", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    int insert = checkout.Insert_Cancel(customer_id, Convert.ToInt32(hotel_room_id), Convert.ToDateTime(today), "Check_In Cancel");
                    int hotelBookingDelete = room.deleteBooking(hotel_room_id);
                    int hotelOrder = room.deleteHotelOrder(hotel_room_id);
                    int deleteCustomer = pend.DeleteCustomer(customer_id);
                    int deleteDetails = pend.DeleteCustomer(customer_id);
                    if (insert > 0)
                    {
                        MessageBox.Show("Successfully Booking Cancel !!", "Cancel Booking Alert !!");
                        dataGridView1.Rows.Clear();
                    }
                }
            }
        }
        
        private void lbl_days_TextChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(lbl_days.Text) != 0 && Convert.ToDecimal(txt_room_charge.Text) > 0 && checkoutChange == true)
            {
                
                    //dataGridView1.Rows[0].Cells[1].Value = lbl_days.Text;
                    //dataGridView1.Rows[0].Cells[3].Value = (Math.Abs(Convert.ToInt32(lbl_days.Text)) * Convert.ToDecimal(room_price)).ToString();
             
                // calculate_total();

                //dataGridView1.Rows.Add();

            }
        }
        DataGridViewRow[] old;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            old = new DataGridViewRow[dataGridView1.SelectedRows.Count];
            dataGridView1.SelectedRows.CopyTo(old, 0);
            //foreach (DataGridViewRow gr in old)
            //{
            //    if (gr == dataGridView1.CurrentRow)
            //    {
            //        gr.Selected = false;
            //    }
            //    else
            //    {
            //        gr.Selected = true;
            //    }
            //}
            //rowheader_total_count();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            old = new DataGridViewRow[dataGridView1.SelectedRows.Count];
            dataGridView1.SelectedRows.CopyTo(old, 0);
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
           
        }
        int dgvColumnId = -1;//datagridview column id
        int dgvRowIndex;
        string username = Login.sendtext;
        string comp_user;
        bool status = false;
        BLLDynamic bldd = new BLLDynamic();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["cal_qty"].Index && e.RowIndex >= 0))
            {
                if (void_status == true)
                {
                    dgvColumnId = e.RowIndex;
                }
            }
            if ((e.ColumnIndex == dataGridView1.Columns["cal_item_name"].Index && e.RowIndex >= 0))
            {
                if (status == true)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["cal_item_name"].Value.ToString() == "Room Charge")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = lbl_days.Text;
                        
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = (Math.Abs(Convert.ToInt32(lbl_days.Text)) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cal_cost"].Value)).ToString();
                        calculate_total();
                        status = false;
                    }
                }
                    
             }
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
            if ((e.ColumnIndex == dataGridView1.Columns["cal_complementary"].Index && e.RowIndex >= 0))
            {
                HotelAdminAccess ac = new HotelAdminAccess();
                ac.ShowDialog();
                if (ac.DialogResult == DialogResult.OK)
                {
                    comp_user = ac.txt_user_name.Text;
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

                        calculate_total();
                       // AdvanceDiscount();
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
                    if (dataGridView1.CurrentRow.Cells["cal_comp_status"].Value==null)
                    {
                        dataGridView1.CurrentRow.Cells["cal_comp_status"].Value = "";
                    }
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
                dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) - 1;
                dataGridView1.Rows[dgvRowIndex].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor = Color.DarkGray;
                

            }
            ComplementryInvoiceNo();
        }

        public void complementarySalesALL()
        {
            //if (cbo_customer_name.Text == "Choose One" && cbo_customer_name.Text != "")
            //{
            //    MessageBox.Show("Choose Customer Alert !!", "Message");
            //}
           
            {
                HotelAdminAccess ac = new HotelAdminAccess();
                ac.ShowDialog();
                if (ac.DialogResult == DialogResult.OK)
                {

                    for (int a = 0; a < dataGridView1.Rows.Count; a++)
                    {

                        string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                        decimal quantity = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                        string category_name1 = dataGridView1.Rows[a].Cells["cal_category_name"].Value.ToString();
                        string kot_type = dataGridView1.Rows[a].Cells["cal_kot_type"].Value.ToString();
                        string sales_type = dataGridView1.Rows[a].Cells["cal_sales_type"].Value.ToString();

                        int insertcomplemenrtysaletra = blcomp.insertcomplementry_using_sp(date, txtcashier.Text, item, quantity, cost, kot_type, category_name1, cbo_customer_name.Text, cbo_customer_no.Text, "HC", "X", total, complementryInvoiceNo);
                        if (insertcomplemenrtysaletra > 0)
                        {
                            int complementrInsert = blcomp.complementryInsert(Convert.ToInt32(txtnewbillno.Text), item, quantity, cost, date, txtcashier.Text, "HC",complementryInvoiceNo);
                           // int i = blord.deletefromtable(Convert.ToInt32(lbl_room.Text));
                            save_data = true;
                            DataTable dt = blord.getallbyitem_name(item);
                            if (dt.Rows.Count > 0)
                            {
                                im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                            }
                        }

                        dataGridView1.Rows.Clear();
                        ComplementryInvoiceNo();
                    }
                }
            }
        }

        private void txtcashamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                complementarySalesALL();
                clear();
            }
        }

        private void lbl_visited_customer_Click(object sender, EventArgs e)
        {

        }
        public void customerorder()
        {
            DataTable dt2 = order.GetCustomerOrder(Convert.ToInt32(lbl_visited_customer.Text));
            if (dt2.Rows.Count > 0)
            {
              
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt2.Rows[i]["hotel_order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt2.Rows[i]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt2.Rows[i]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt2.Rows[i]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt2.Rows[i]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt2.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["cal_kot_type"].Value = dt2.Rows[i]["kot_print"].ToString();
                    dataGridView1.Rows[z].Cells["cal_sales_type"].Value = dt2.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";
                    z++;

                }
                
              calculate_total();
                //z = 0;
            }

        }
        public void customerallroom()
        {
            DataTable dt2 = customer.GetBookingall(Convert.ToInt32(lbl_visited_customer.Text),hotel_room_id);
            if (dt2.Rows.Count > 0)
            {
                dataGridView1.Rows.Add("Room Charge", lbl_days.Text, room_price, txt_room_charge.Text, "Room", "K1", "HR", "0");
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    //dataGridView1.Rows.Add();
                    dataGridView1.Rows.Add("Room Charge", lbl_days.Text, room_price, txt_room_charge.Text, "Room", "K1", "HR", "0");
                i++;

                }

                // calculate_total();
                //z = 0;
            }

        }
        public void customerPackage()
        {
            DataTable dt2 = customer.GetPackage(Convert.ToInt32(lbl_visited_customer.Text));
            if (dt2.Rows.Count > 0)
            {
                
                     for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                      
                        dataGridView1.Rows.Add();
                        // dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt3.Rows[i]["package_id"].ToString();
                        int package_id= Convert.ToInt32(dt2.Rows[i]["package_id"].ToString());
                        DataTable dt3 = category.GetRoompackageById(package_id);
                 
                        if (dt3.Rows.Count > 0)
                        {
                            dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt3.Rows[0]["package_name"].ToString();
                            dataGridView1.Rows[z].Cells["cal_qty"].Value = 1;
                            dataGridView1.Rows[z].Cells["cal_total"].Value = dt3.Rows[0]["price"].ToString();
                            dataGridView1.Rows[z].Cells["cal_cost"].Value = dt3.Rows[0]["price"].ToString();
                            dataGridView1.Rows[z].Cells["cal_category_name"].Value = "package";
                            dataGridView1.Rows[z].Cells["cal_kot_type"].Value = "K1";
                            dataGridView1.Rows[z].Cells["cal_sales_type"].Value = "HR";
                            dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "0";
                            z++;

                        }
                    
                    calculate_total();
                   // z = 0;
                }
                }
        }
        public static int z = 0;

       
        bool all_bill = false;
        
        private void btn_bill_all_Click(object sender, EventArgs e)
        {
            all_bill = true;
            
            DataTable dt1 = room.GetDates(Convert.ToInt32(hotel_room_id));
            lbl_visited_customer.Text = dt1.Rows[0]["customer_id"].ToString();
            int count = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            if (dt1.Rows.Count > 0)
            {
                DataTable dt = customer.GetBooking(Convert.ToInt32(lbl_visited_customer.Text));
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i< dt.Rows.Count; i++)
                    {
                       // dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add();
                         dtp_checkin.Text = dt.Rows[i]["check_in"].ToString();
                         dtp_check_out.Text = dt.Rows[i]["check_out"].ToString();
                        hotel_room_id = dt.Rows[i]["room_id"].ToString();
                        GetDays();
                       
                        dataGridView1.Rows[z].Cells["cal_item_name"].Value = "Room Charge";
                        dataGridView1.Rows[z].Cells["cal_qty"].Value = lbl_days.Text;
                        dataGridView1.Rows[z].Cells["cal_cost"].Value = Convert.ToDecimal(room_price);
                        dataGridView1.Rows[z].Cells["cal_total"].Value = Convert.ToDecimal(lbl_days.Text) * Convert.ToDecimal(room_price);
                        dataGridView1.Rows[z].Cells["cal_category_name"].Value = "Room";
                        dataGridView1.Rows[z].Cells["cal_kot_type"].Value = "K1";
                        dataGridView1.Rows[z].Cells["cal_sales_type"].Value = "HR";
                        dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "0";
                        z++;
                    }
                }
             // customerallroom();
                customerPackage();
                customerorder();
                z = 0;

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
                txtremainingamount.Text = "0.00";
                lblchangeamout.Text = "0.00";
                payment_mode = "Cash/Card";
                tax_calcu();
            }
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
                    //customer_address = dt.Rows[0]["address"].ToString();
                    txtpan_no.Text = dt.Rows[0]["phone2"].ToString();
                }
            }
            else if (cbo_customer_no.Text == "" && cbo_customer_no.Text == "Choose One")
            {
                cbo_customer_no.Text = "Choose One";
            }
        }

        private void chkcredit_CheckedChanged(object sender, EventArgs e)
        {

            if (chkcredit.Checked)
            {
                payment_mode = "Credit";
              //  tax_calcu();
            }
        }

        private void chkcredit_Click(object sender, EventArgs e)
        {
            panel3.Show();
            txtcardamount.Enabled = false;
            
            label14.Text = "Credit Amount";
        }

        private void chkcard_Click(object sender, EventArgs e)
        {
            txtcardamount.Enabled = true;
            btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }

        private void chkcard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcard.Checked)
            {
                payment_mode = "Card";
                //  tax_calcu();
            }
        }

        private void chkcash_card_Click(object sender, EventArgs e)
        {

            txtcardamount.Enabled = true;
            btn_card_balance.Visible = false;
            label14.Text = "Change Amount";
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (multi_billing_check == true)
            {
                rowheader_total_count();
            }
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
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
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvRowIndex = e.RowIndex;
            ItemSlipt();
        }

        private void cmb_package_Enter(object sender, EventArgs e)
        {
            //if (cmb_package.SelectedIndex!=0)
            //{
            //    dt3 = category.GetRoompackageById(cmb_package.SelectedIndex);
            //    if (dt3.Rows.Count > 0)
            //    {
            //        price = Convert.ToDecimal(dt3.Rows[0]["price"].ToString());
            //    }
            //    dataGridView1.Rows.Add(cmb_package.Text, 1, price, price, "Package", "K1", "HR", "0");
            //    calculate_total();
            
            //}
        }

        private void cmb_package_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  dataGridView1.Rows.Add(cmb_package.Text, 1, price, price, "Package", "K1", "HR", "0");
            //customerPackage();
        }
        BLL_HotelDetails hotel = new BLL_HotelDetails();
        private void cmb_package_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cmb_package.SelectedIndex != 0)
            {
                dt3 = category.GetRoompackageById(cmb_package.SelectedIndex);
                if (dt3.Rows.Count > 0)
                {
                    price = Convert.ToDecimal(dt3.Rows[0]["price"].ToString());
                }
                dataGridView1.Rows.Add(cmb_package.Text, 1, price, price, "Package", "K1", "HR", "0");
               // int insert_booking = hotel.Insert_Booking(customer_id, Convert.ToDateTime(today), Convert.ToDateTime(today), cmb_room_type.Text, Convert.ToInt32(txt_guest.Text), Convert.ToDateTime(dtp_checkout.Text), txt_roomno.Text, room_id, Convert.ToInt32(cmb_package.SelectedValue));
                calculate_total();

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Hotel.Hotel rp = new Hotel.Hotel();
            GetDetails.Controls.Clear();
            GetDetails.Controls.Add(rp);
        }
    }
    }

