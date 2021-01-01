using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BLLS;
using POS;
using System.IO;
using POS_Systems;
using POS_System.Discount;
using NepaliDateConverter;
using System.Windows;
using Tulpep.NotificationWindow;
using POS_System.Customer_Management;
using POS_System.Hotel;
using DocumentFormat.OpenXml.Bibliography;
using System.Web;
using POS_System.Table_Management;
using POS_System.CustomerAttendance;

namespace POS_System
{
    public partial class second_user_interface : Form
    {
        public second_user_interface(string user)
        {
            //Thread th = new Thread(new ThreadStart(spstart));
            //th.Start();
            //Thread.Sleep(5000);


            InitializeComponent();
            //th.Abort();

            label_logger.Text = user;
            SessionUser users = new SessionUser();
            users.userid(user);
            users.user_name = user;


        }
        //public void spstart() {
        //    Application.Run(new SplashScreen() );
        //}



        BLLUser blu = new BLLUser();
        BLLToken blt = new BLLToken();
        BLLTakeAway blta = new BLLTakeAway();
        BLL_Login_logout blog = new BLL_Login_logout();
        BLLCustomer_details blcustom = new BLLCustomer_details();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLDynamic bld = new BLLDynamic();
        BLLStock blls = new BLLStock();
        public string working_day;
        public DateTime working_date;
        public string working_time;
        string user_name;
        DateConverter ndc = new DateConverter();
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.systime.Text = System.DateTime.Now.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.systime.Text = System.DateTime.Now.ToString();
        }

        private void systime_Click(object sender, EventArgs e)
        {
            this.systime.Text = System.DateTime.Now.ToString();
        }




        private void viewPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Stock_Purchase viepur = new View_Stock_Purchase();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(viepur);
        }





        //Stock
        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl_purchase_form stopur = new UserControl_purchase_form();
            string bill_no = SupplierPayment.bill_no = "";
            string supplier_names = SupplierPurchase.supplier_name = "";
            bill_no = "";
            supplier_names = "";
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(stopur);
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addDamageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDamages vieret = new AddDamages();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vieret);
        }




        private void viewRestaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewrestaurant vieret = new Viewrestaurant();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vieret);
        }



        BLLTakeAway bltk = new BLLTakeAway();
        string take_away_id;
        string today = DateTime.Now.ToShortDateString();
        CheckDynamic cd = new CheckDynamic();
        DataTable dtqty = new DataTable();

        private void second_user_interface_Load(object sender, EventArgs e)
        {
            TakeawayRename = cd.TakeAwayAccess();
            ServiceProvider = cd.ServiceProviderAccess();
            ProviderName = cd.ProviderName();
            KOTRename = cd.KOTRename();
            TakeawayRename = cd.TakeAwayAccess();
            ServiceProvider = cd.ServiceProviderAccess();
            ProviderName = cd.ProviderName();
            KOTRename = cd.KOTRename();
            QuotationAccess = cd.QuotationAccess();
            QuotationName = cd.QuotationName();
            hotelenabledisable = cd.HotelEnableDisable();
   
            DateTime dateTimeconvert = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateConvertToNepali();
            businessLoad();

            signUpNewUserToolStripMenuItem.Visible = false;
            changePasswordToolStripMenuItem.Visible = false;
            viewToolStripMenuItem.Visible = false;
            stockToolStripMenuItem.Visible = false;
            resturentToolStripMenuItem.Visible = false;
            hotel.Visible = false;//Hotel Tab
            if (hotelenabledisable == true)
            {
                hotel.Visible = true;
            }
            if (cd.AccountAccess() == true)//accountAccess
            {
                accountToolStripMenuItem.Visible = true;
            }
            fileToolStripMenuItem.Visible = false;
            addItemToolStripMenuItem.Visible = false;
            tokenBillingToolStripMenuItem.Visible = false;
            addTableToolStripMenuItem.Visible = false;
            //  orderListToolStripMenuItem.Visible = false;
            editBusinessToolStripMenuItem.Visible = false;
            addItemModifierToolStripMenuItem.Visible = false;
            menuItemBarCodeToolStripMenuItem.Visible = false;
            dtqty = blls.GetCalculationQty();
            if (dtqty.Rows.Count > 0)
            {
                this.stockToolStripMenuItem.ForeColor = Color.BlanchedAlmond;
            }
            addTableToolStripMenuItem.Visible = false;
            iNgTestToolStripMenuItem.Visible = false;
            addItemToolStripMenuItem.Visible = false;
            editBusinessToolStripMenuItem.Visible = false;
            setOpeningBalanceToolStripMenuItem.Visible = false;
            dayEndToolStripMenuItem.Visible = false;
            careOfToolStripMenuItem.Visible = false;
            //customer
            addNewCustomerToolStripMenuItem.Visible = false;
           // customerCreditToolStripMenuItem.Visible = false;
            //ingredientManagementToolStripMenuItem.Visible = false;
            messToolStripMenuItem.Visible = false;
            clubCustomerToolStripMenuItem.Visible = false;
            toolStripMenuItem3.Visible = false;
            userLevelDiscountToolStripMenuItem.Visible = false;
            //lbl_notification. = 70;
            user_name = Login.sendtext;
            DataTable dtnotification = blcustom.GetCount(Convert.ToDateTime(today));
            DataTable dtappointment = blcustom.GetCountAppointment(Convert.ToDateTime(today));
            DataTable dthotelnotification = blcustom.GetCountHotel(Convert.ToDateTime(today));
            if (dtnotification.Rows[0][0].ToString() != "0" || dtappointment.Rows[0][0].ToString() != "0")
            {
                int notification = Convert.ToInt32(dtnotification.Rows[0][0].ToString());
                int appointment = Convert.ToInt32(dtappointment.Rows[0][0].ToString());

                lbl_notification.Text = Convert.ToString(notification + appointment);
                int hotelnotification = Convert.ToInt32(dthotelnotification.Rows[0][0].ToString());
                lbl_notification.Text = Convert.ToString(notification + appointment + hotelnotification);
            }
            else
            {
                lbl_notification.Visible = false;
            }
            DataTable dt = blu.getusername(user_name);
            if (dt.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["account"].ToString() == "True")
                    {

                    }
                    if (dtm.Rows[0]["sales"].ToString() == "True")
                    {
                        resturentToolStripMenuItem.Visible = true;
                    }
                    if (dtm.Rows[0]["stock"].ToString() == "True")
                    {
                        stockToolStripMenuItem.Visible = true;
                    }
                    if (dtm.Rows[0]["restaurant"].ToString() == "True")
                    {
                        resturentToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        resturentToolStripMenuItem.Enabled = false;
                    }
                    if (dtm.Rows[0]["hotel"].ToString() == "True")
                    {
                        stockToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        hotel.Enabled = false;
                        
                    }
                    if (dtm.Rows[0]["report"].ToString() == "True")
                    {
                        viewToolStripMenuItem.Visible = true;
                    }
                    if (dtm.Rows[0]["admin"].ToString() == "True")
                    {
                        signUpNewUserToolStripMenuItem.Visible = true;
                        changePasswordToolStripMenuItem.Visible = true;
                        fileToolStripMenuItem.Visible = true;
                        addTableToolStripMenuItem.Visible = true;
                        // orderListToolStripMenuItem.Visible = true;
                        editBusinessToolStripMenuItem.Visible = true;
                        addItemToolStripMenuItem.Visible = true;
                        addItemToolStripMenuItem.Visible = true;
                        tokenBillingToolStripMenuItem.Visible = true;
                        addItemModifierToolStripMenuItem.Visible = true;
                        menuItemBarCodeToolStripMenuItem.Visible = true;
                        addTableToolStripMenuItem.Visible = true;
                        iNgTestToolStripMenuItem.Visible = true;
                        editBusinessToolStripMenuItem.Visible = true;
                        dayEndToolStripMenuItem.Visible = true;
                        setOpeningBalanceToolStripMenuItem.Visible = true;
                        careOfToolStripMenuItem.Visible = true;
                        //customer
                        addNewCustomerToolStripMenuItem.Visible = true;
                        customerCreditToolStripMenuItem.Visible = true;
                        //ingredientManagementToolStripMenuItem.Visible = true;
                        messToolStripMenuItem.Visible = true;
                        clubCustomerToolStripMenuItem.Visible = true;
                        toolStripMenuItem3.Visible = true;
                        userLevelDiscountToolStripMenuItem.Visible = true;
                    }

                }
                WindowState = FormWindowState.Maximized;
                //touchBillingToolStripMenuItem.Visible = false;
                //billingToolStripMenuItem.Visible = false;
                //addTableToolStripMenuItem.Visible = false;
                tokenBillingToolStripMenuItem.Visible = false;
            }
            
        }

        public void businessLoad()
        {
            BusinessType = cd.BusinessType();
            if (BusinessType == "Bakery")
            {
                BakeryTable_Billing winfor = new BakeryTable_Billing("TA");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(winfor);
            }
            else
            {
                DataTable dtload = bld.GetFirstLoadDynamic();
                if (dtload.Rows.Count > 0)
                {
                    string load = dtload.Rows[0]["description"].ToString();
                    //TABLE Load
                    if (load == "Table Load")
                    {
                        Table_Management.Table_Billing winfor = new Table_Management.Table_Billing();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfor);
                    }
                    ////KFC LOAD
                    else if (load == "KFC Load")
                    {
                        FastBilling winfosr = new FastBilling();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfosr);
                    }

                    ////  TAKE AWAY LOAD
                    else if (load == "TakeAway Load")
                    {

                        DataTable dt_id = bltk.getmaxNo();
                        if (dt_id.Rows.Count > 0)
                        {
                            if (dt_id.Rows[0][0].ToString() == "")
                            {
                                take_away_id = "1001";
                            }
                            else
                            {
                                int getinvoiceno = Convert.ToInt32(dt_id.Rows[0][0].ToString()) + 1;
                                take_away_id = getinvoiceno.ToString();

                            }
                        }
                        KOTOrder winfosr = new KOTOrder(take_away_id, "TA");
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfosr);
                    }
                }
                else
                {
                    Table_Management.Table_Billing winfor = new Table_Management.Table_Billing();
                    contentpanel.Controls.Clear();
                    contentpanel.Controls.Add(winfor);
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var colors = new[] { Color.Yellow, Color.Green };
            var index = DateTime.Now.Second % colors.Length;
            this.BackColor = colors[index];
        }
        public void dateConvertToNepali()
        {
            NepaliDateConverter.DateConverter dp = new NepaliDateConverter.DateConverter();

            var nepalidate = dp.EngToNep(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")));
            string nyear = nepalidate.ConvertedDate.Year.ToString();
            string nday = nepalidate.ConvertedDate.Day.ToString();
            string nmonths = nepalidate.ConvertedDate.Month.ToString();
            lbl_nepali_date.Text = nyear + "." + nmonths + "." + nday;
        }
       

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewrestaurantSalesByWeekDay ancd = new ViewrestaurantSalesByWeekDay();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ancd);
        }


        private void veiwDeliveryPaymentCheckListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl_delivery_status dbs = new UserControl_delivery_status();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dbs);

        }
        public static string TakeawayRename;
        public static bool ServiceProvider;
        public static string ProviderName;
        public static string KOTRename;
        public static bool QuotationAccess;
        public static string QuotationName;
        public static string BusinessType;
        bool hotelenabledisable;
        private void touchBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Bakery")
            {
                BakeryTable_Billing vsbb = new BakeryTable_Billing("TA");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(vsbb);

            }
            else
            {
                DataTable dtload = bld.GetFirstLoadDynamic();
                if (dtload.Rows.Count > 0)
                {
                    string load = dtload.Rows[0]["description"].ToString();
                    //Table Load
                    if (load == "Table Load")
                    {
                        Table_Management.Table_Billing win = new Table_Management.Table_Billing();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(win);
                    }
                    //KFC Load
                    else if (load == "KFC Load")
                    {
                        FastBilling winfosr = new FastBilling();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfosr);

                    }
                    //TAKE AWAY LOAD
                    else if (load == "TakeAway Load")
                    {
                        DataTable dt_id = bltk.getmaxNo();
                        if (dt_id.Rows.Count > 0)
                        {
                            if (dt_id.Rows[0][0].ToString() == "")
                            {
                                take_away_id = "1001";


                            }
                            else
                            {
                                int getinvoiceno = Convert.ToInt32(dt_id.Rows[0][0].ToString()) + 1;
                                take_away_id = getinvoiceno.ToString();
                                DataTable dtm = bltk.getallfromtable();
                            }
                        }
                        KOTOrder winfosr = new KOTOrder(take_away_id, "TA");
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfosr);

                    }
                    else
                    {
                        Table_Management.Table_Billing win = new Table_Management.Table_Billing();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(win);
                    }

                }
            }
        }

        private void contentpanel_Paint_1(object sender, PaintEventArgs e)
        {
        }



        private void addTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table_Management.Table_create_edit tbl = new Table_Management.Table_create_edit();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(tbl);
        }


        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockList al = new StockList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(al);
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Restaurant")
            {
                allmenu al = new allmenu();
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(al);
            }
            else if(BusinessType == "Bakery")
            {
                allmenu al = new allmenu();
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(al);
            }
            else
            {
                Parlour al = new Parlour();
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(al);
            }
        }

        private void editBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperAdminAccess saa = new SuperAdminAccess();
            saa.ShowDialog();
            if (saa.DialogResult == DialogResult.OK)
            {
                Edit_Rest_details erd = new Edit_Rest_details();
                erd.ShowDialog(this);
            }

        }



        private void homeDeliveryStatusToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UserControl_delivery_status stats = new UserControl_delivery_status();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(stats);
        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_user user = new edit_user();
            user.ShowDialog();
        }

        private void cashWithdrawlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashWithdrawl cashwith = new CashWithdrawl("Restaurant");
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(cashwith);
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Bakery")
            {
                BakeryTable_Billing vsbb = new BakeryTable_Billing("TA");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(vsbb);

            }
            else
            {
                Billing vsbc = new Billing(1.ToString(), null);
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(vsbc);
            }
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierList sup = new SupplierList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(sup);
        }

        private void homeDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["homedelivery"].ToString() == "True")
                    {
                        home hm = new home("103");
                        hm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Home Delivery ALert !!", "No Access Alert !!");
                    }
                }
            }

        }

        private void tokenBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBilling tok = new FastBilling();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(tok);
        }


        private void userAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccess tok = new UserAccess();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(tok);
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            working_day = System.DateTime.Now.ToString("dddd");
            working_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            working_time = System.DateTime.Now.ToString("hh:mm:ss tt");
            int session_id = Login.log_session_id;
            int logout = blog.insert_into_login_logout(user_name, working_day, working_date, working_time, "Logout", session_id.ToString());
            DialogResult dialogResult = MessageBox.Show("Do You Like To Change Shift", "Shift Change", MessageBoxButtons.YesNo);

            DataTable dt = blta.select_all_data_higher();
            if (dt.Rows.Count == 0)
            {
                int truncate = blta.truncate_take_away();
            }
            if (dialogResult == DialogResult.Yes)
            {
                ShiftChange shc = new ShiftChange();
                shc.ShowDialog();

            }

            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void dayEndToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["dayend"].ToString() == "True")
                    {
                        DayEndReport dayer = new DayEndReport();
                        dayer.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You Have No Permission To Print A Report");
                    }
                }
            }
        }

        private void setOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningBalance opbn = new OpeningBalance("Restaurant");
            opbn.ShowDialog();
        }


        private void viewXReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XReportView vsbb = new XReportView();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsbb);
        }

        private void careOfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["cashdrop"].ToString() == "True")
                    {
                        CashWithdrawl cashwith = new CashWithdrawl("Restaurant");
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(cashwith);
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Cash Drop Access ALert !!", "No Access Alert !!");
                    }
                }
            }
        }

        private void cashWithDrawRecivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CountercashReturnedForm cash = new CountercashReturnedForm();
            //cash.ShowDialog();
        }

        private void viewDailyEndingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDayendReport cashwith = new ViewDayendReport();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(cashwith);
        }

        private void viewLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLoginLogout vlog = new ViewLoginLogout();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vlog);
        }

        private void viewShiftChangeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewShiftChangeForm visc = new ViewShiftChangeForm();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(visc);
        }

        private void viewOrderCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrderCancelForm vod = new ViewOrderCancelForm();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vod);
        }

        private void viewSalesDeleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRestaurantDeleteRecord vsd = new ViewRestaurantDeleteRecord();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsd);
        }

        private void addInHouseUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InhoueseUnit unit = new InhoueseUnit();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(unit);
        }

        private void addItemModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item_Modifier unit = new Item_Modifier();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(unit);
        }

        private void signUpNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUpdateUser sn = new EditUpdateUser();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(sn);
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDetailform vsbb = new CustomerDetailform("NC");
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsbb);
        }

        private void customerMessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerMessProgram vod = new Customer_Management.CustomerMessProgram();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vod);
        }

        private void viewCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management.ViewPakageChooser vod = new Customer_Management.ViewPakageChooser();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vod);
        }

        private void customerAttendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerAttendance vod = new Customer_Management.CustomerAttendance();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vod);
        }

        private void backDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUP.DatabaseBackup back_up = new BackUP.DatabaseBackup();
            back_up.ShowDialog();
        }

        private void menuItemBarCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarCodeSet vsbb = new BarCodeSet();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsbb);
        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllCreditsLists alcr = new AllCreditsLists();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(alcr);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            notify();
        }
        public void notify()
        {
            blllCustomerDetailednyo bllcus = new blllCustomerDetailednyo();
            DataTable getallcusto = bllcus.getallcustomersHavingPakges();
            if (getallcusto.Rows.Count > 0)
            {
                for (int i = 0; i < getallcusto.Rows.Count; i++)
                {
                    DateTime getdate = Convert.ToDateTime(getallcusto.Rows[i]["startingDate"].ToString());
                    int getdays = Convert.ToInt32(getallcusto.Rows[i]["noofdays"].ToString());
                    DateTime CalcDate = getdate.AddDays(getdays);
                    if (DateTime.Now.Date == CalcDate.Date)
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.Tag = getallcusto.Rows[i]["id"].ToString();
                        notifyIcon1.ShowBalloonTip(10000, getallcusto.Rows[i]["pakage_name"].ToString() + " Package Expired Notice", "Package  will Expired  today for " + getallcusto.Rows[i]["name"].ToString() + " " + getallcusto.Rows[i]["lastname"].ToString(), ToolTipIcon.Info);

                    }

                }

            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }




        private void billPrintingSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing_print_setting kot = new Billing_print_setting();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(kot);
        }

        private void kOTPrintingSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KOT_printing_setting kot = new KOT_printing_setting();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(kot);
        }


        private void addMenuCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddIMenuCategory ing = new AddIMenuCategory();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ing);
        }

        private void addMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMenuItemList amil = new AddMenuItemList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(amil);
        }

        private void iNgTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fiscalYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalYear fis = new FiscalYear();
            fis.ShowDialog();
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:\POS Guid.pdf");
        }

        private void viewMaterializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Materialize vm = new View_Materialize();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vm);
        }

        private void salesTaxReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewrestaurant_copy vm = new Viewrestaurant_copy();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vm); 
        }

        private void viewUserLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUserLog vug = new ViewUserLog();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vug);
        }
        private void viewItemUpdateLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemUpdate iu = new ItemUpdate();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(iu);
        }

        private void viewSalesDetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewrestaurant_sales_report vsr = new Viewrestaurant_sales_report();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void customerCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creditload = "";
            CustomerDetail vsr = new CustomerDetail();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void viewCashDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Counter_Cash_Withdrawl vsr = new Counter_Cash_Withdrawl();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void addStockCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl_product_add adpro = new UserControl_product_add();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(adpro);
        }

        private void addStockProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockProductList spl = new StockProductList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(spl);
        }

        private void addIngredientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddIngredient adpro = new AddIngredient();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(adpro);
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department dr = new Department();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Discount dr = new Discount();
            //contentpanel.Controls.Clear();
            //contentpanel.Controls.Add(dr);
        }

        private void clubCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerList dr = new Customer_Management.CustomerList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerCard_Type dr = new Customer_Management.CustomerCard_Type();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void viewCustomerBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Management.CustomerCardDetail dr = new Customer_Management.CustomerCardDetail();
            dr.ShowDialog();
        }

        private void openingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList dr = new ProductList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void userLevelDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDiscount dr = new UserDiscount();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void viewCardDetailsLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCard dr = new CheckCard();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void viewVoidSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoidSales dr = new VoidSales();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //    HotelDashBoard dr = new HotelDashBoard();
            //    contentpanel.Controls.Clear();
            //    contentpanel.Controls.Add(dr);
    
        }
        string min_stock;
        string remain_qty;
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dtqty = blls.GetCalculationQty();
            //if (dtqty.Rows.Count > 0)
            //{

            //    if (dtqty.Rows.Count > 0)
            //    {
            //        if (dtqty.Rows.Count > i)
            //        {

            //            popup.Image = Properties.Resources.icon;
            //            name = dtqty.Rows[i]["product_name"].ToString();
            //            min_stock = dtqty.Rows[i]["min_stock"].ToString();
            //            remain_qty = dtqty.Rows[i]["qty"].ToString();
            //        }
            //        else
            //        {
            //            i = 0;
            //            name = dtqty.Rows[i]["product_name"].ToString();
            //            min_stock = dtqty.Rows[i]["min_stock"].ToString();
            //            remain_qty = dtqty.Rows[i]["qty"].ToString();
            //        }
            //        popup.TitleColor = Color.Red;
            //        popup.TitleText = "Notification";
            //        popup.BodyColor = Color.LightGray;
            //        popup.ContentText = name + " " + "Quantiy is = " + remain_qty + "\n" + "Your Minimum Stock Is" + " " + min_stock + "\n" + "Stock Is Lacking ";
            //        popup.Popup();
            //    }
            //    i = i + 1;
            //}
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrder dr = new ViewOrder();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void clubCardCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardCreditRecord ccr = new CardCreditRecord();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void viewComplementryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Complementry_Sales ccr = new View_Complementry_Sales();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void viewStockSalesLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStockSales ccr = new ViewStockSales();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void viewDailyStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStockLog ccr = new ViewStockLog();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void hotDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DyanmicDiscount ccr = new DyanmicDiscount();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }
        string name;
        string phone;
        string remarks;
        public int i = 0;
        PopupNotifier popup = new PopupNotifier();
        private void lbl_notification_Click(object sender, EventArgs e)
        {
            //   DataTable dtnotification = blcustom.GetCustomerNotification(Convert.ToDateTime(today));
            DataTable dtnotification = blcustom.GetCustomerAppointment(Convert.ToDateTime(today));
            if (dtnotification.Rows.Count > 0)
            {
                if (dtnotification.Rows.Count > i)
                {

                    popup.Image = Properties.Resources.icon;
                    name = dtnotification.Rows[i]["name"].ToString();
                    phone = dtnotification.Rows[i]["phone"].ToString();
                    remarks = dtnotification.Rows[i]["Remarks"].ToString();


                }
                else
                {
                    i = 0;
                    name = dtnotification.Rows[i]["name"].ToString();
                    phone = dtnotification.Rows[i]["phone"].ToString();
                    remarks = dtnotification.Rows[i]["Remarks"].ToString();
                }
                popup.TitleColor = Color.Red;
                popup.TitleText = "Notification";
                popup.BodyColor = Color.LightGray;
                popup.ContentText = remarks + " " + "Of" + " " + name + "\n" + "Contact number:" + " " + phone;
                popup.Popup();
            }
            i = i + 1;

        }

        public void hotelNotification()
        {
            DataTable dthotelnotification = blcustom.GetHotelNotification(Convert.ToDateTime(today));
            if (dthotelnotification.Rows.Count > 0)
            {
                if (dthotelnotification.Rows.Count > i)
                {
                    popup.Image = Properties.Resources.icon;
                    name = dthotelnotification.Rows[i]["name"].ToString();
                    phone = dthotelnotification.Rows[i]["contact"].ToString();
                    remarks = dthotelnotification.Rows[i]["check_out"].ToString();

                }
                else
                {
                    i = 0;
                    name = dthotelnotification.Rows[i]["name"].ToString();
                    phone = dthotelnotification.Rows[i]["contact"].ToString();
                    remarks = dthotelnotification.Rows[i]["check_out"].ToString();
                }
                popup.TitleColor = Color.Red;
                popup.TitleText = "Notification";
                popup.BodyColor = Color.LightGray;
                popup.ContentText = "CheckOut" + " " + "Of" + " " + name + "\n" + "Contact number:" + " " + phone;
                popup.Popup();
            }

            i = i + 1;

        }

        private void customerAppointmentGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentGraph ccr = new AppointmentGraph();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void customerAppointmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAppointment ccr = new EditAppointment();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void stockAdjustmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StockAdjustments ccr = new StockAdjustments();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void stockLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Stock_Product ccr = new Purchase_Stock_Product();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void stockCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stock_Calculation ccr = new Stock_Calculation();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void wasteManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WasteMgnt ccr = new WasteMgnt();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ccr);
        }

        private void serialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CustomerDisplayModified ccr = new CustomerDisplayModified();
            ccr.ShowDialog();
        }

        public class RandomGenerator
        {
            // Generate a random number between two numbers    
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

        }


        private void resturentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        string username = Login.sendtext;
        public static bool access = false;
        private void frontEndViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            access = false;
            HotelDashBoard dr = new HotelDashBoard();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }
        private void backEndViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string user_name = Login.sendtext;
            DataTable dt = blu.getusername(user_name);
            if (dt.Rows.Count > 0)
            {
                DataTable dtm = blu.Getuserhotelaccess(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["admin"].ToString() == "True")
                    {
                        access = true;
                        HotelDashBoard dr = new HotelDashBoard();
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(dr);
                    }
                    else
                    {
                        MessageBox.Show("Sorry You Don't Have Access In Backend !!", "No Access Alert !!");
                    }
                }
            }

        }

        private void hotelUserAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotelUserAccess dr = new HotelUserAccess();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void consulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerConsolation dr = new CustomerConsolation();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void viewCardReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCardReport al = new ViewCardReport();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(al);
        }

        private void dynamicSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            if (acc.DialogResult == DialogResult.OK)
            {
                if (Application.OpenForms.OfType<Dynamic>().Count() == 1)
                    Application.OpenForms.OfType<Dynamic>().First().Close();
                Dynamic frm = new Dynamic();
                frm.Show();
            }
        }

        private void addCategoryGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryGrouping al = new AddCategoryGrouping();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(al);
        }
        public static string creditload = "";
        private void hotelDayEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creditload = "Hotel Credit";
            CustomerDetail vsr = new CustomerDetail();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void viewSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport vsr = new SalesReport();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void viewComplementryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HotelComplementrySales vsr = new HotelComplementrySales();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void viewVoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotelVoidSales vsr = new HotelVoidSales();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void viewDailyEndReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHotelOrder vsr = new ViewHotelOrder();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void hotelRoomStatusUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotelStatusUpdate vsr = new HotelStatusUpdate();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }



        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewRestaurantSalesWithOwnCalculate vsr = new ViewRestaurantSalesWithOwnCalculate();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void purchasePayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierPurchase vsr = new SupplierPurchase();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            if (AdminAccess.AccountAccess == true)
            {
                System.Diagnostics.Process.Start("http://localhost.account.com:8018");
            }

        }

        private void hotelDayEndToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DayEndHotel deh = new DayEndHotel();
            deh.ShowDialog();
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningBalance opbn = new OpeningBalance("Hotel");
            opbn.ShowDialog();
        }

        private void hotelTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotelTransfer ht = new HotelTransfer();
            ht.Show();
        }

        private void viewDonationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDonationReport vsr = new ViewDonationReport();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void cashDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["cashdrop"].ToString() == "True")
                    {
                        CashWithdrawl cashwith = new CashWithdrawl("Hotel");
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(cashwith);
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Cash Drop Access ALert !!", "No Access Alert !!");
                    }
                }
            }
        }

        private void roomTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Room_Transfer ht = new Room_Transfer();
            ht.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           string path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS\\POSGuid.pdf";
            System.Diagnostics.Process.Start(path);
        }

        private void cardAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEventType vsr = new AddEventType();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void eventAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventAttendance vsr = new EventAttendance();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void addStockGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStockGrouping adsg= new AddStockGrouping();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(adsg);
        }
    }
}




