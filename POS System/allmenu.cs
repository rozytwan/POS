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
using POS_Systems;
using System.IO;
using POS_System.Customer_Management;
using POS_System.Table_Management;

namespace POS_System
{
    public partial class allmenu : UserControl
    {
        public allmenu()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        BLLDynamic bld = new BLLDynamic();
        string TakeawayRename;
        string BusinessType;
        private void Main_menu_Load(object sender, EventArgs e)
        {
            BusinessType = cd.BusinessType();
            if(BusinessType=="Bakery")
            {
                metroTouchBilling.TitleText = "Add Customer";
            }
            string user_name = Login.sendtext;
            //DataTable dt = blu.get_user_and_type_inner(user_name);
            DataTable dt = blu.getusername(user_name);
            DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
            dt = bld.GetDynamic("IHD");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroorderitem.Image = image;
                }
            }
            dt = bld.GetDynamic("ITA");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroTileItem6.Image = image;
                }
            }
            dt = bld.GetDynamic("ITB");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroTouchBilling.Image = image;
                }
            }
            dt = bld.GetDynamic("IHD");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroorderitem.Image = image;
                }
            }
            dt = bld.GetDynamic("IVS");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroTileItem5.Image = image;
                }
            }
            dt = bld.GetDynamic("IAM");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroTileItem8.Image = image;
                }
            }
            dt = bld.GetDynamic("IT");
            if (dt.Rows.Count > 0)
            {
                string image_name = dt.Rows[0]["description"].ToString();
                if (File.Exists(image_name))
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    metroTileItem7.Image = image;
                }
            }

            TakeawayRename = second_user_interface.TakeawayRename;
            metroTileItem6.TitleText = TakeawayRename + " " + "Billing";
            DataTable dttoken = bld.GetDynamic("TBR");
            if (dttoken.Rows.Count > 0)
            {
                string status = dttoken.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    metroTileItem7.TitleText = dttoken.Rows[0]["description"].ToString() + " " + "Billing";
                }
            }
            DataTable dthd = bld.GetDynamic("HDR");
            if (dthd.Rows.Count > 0)
            {
                string status = dthd.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    metroorderitem.TitleText = dthd.Rows[0]["description"].ToString();
                }
            }
            DataTable dtvsr = bld.GetDynamic("VSR");
            if (dtvsr.Rows.Count > 0)
            {
                string status = dtvsr.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    metroTileItem5.TitleText = dtvsr.Rows[0]["description"].ToString();
                }
            }
            DataTable dttr = bld.GetDynamic("TR");
            if (dttr.Rows.Count > 0)
            {
                string status = dttr.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    metroTouchBilling.TitleText = dttr.Rows[0]["description"].ToString();
                }
            }
            DataTable dtmir = bld.GetDynamic("MIR");
            if (dtmir.Rows.Count > 0)
            {
                string status = dtmir.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    metroTileItem8.TitleText = dtmir.Rows[0]["description"].ToString();
                }
            }

            itemContainer2.Enabled = false;
            itemContainer1.Enabled = false;
            metroTileItem8.Enabled = false;
            metroorderitem.Enabled = false;
            metroTileItem5.Enabled = false;
            metroTileItem6.Enabled = false;
            metroTileItem7.Enabled = false;

            if (dtm.Rows[0]["sales"].ToString() == "True")
            {
                itemContainer2.Enabled = true;
            }
            if (dtm.Rows[0]["stock"].ToString() == "True")
            {
                itemContainer1.Enabled = true;
            }
            if (dtm.Rows[0]["admin"].ToString() == "True")
            {
                metroTileItem8.Enabled = true;
                metroorderitem.Enabled = true;
                metroTileItem5.Enabled = true;
                metroTileItem6.Enabled = true;
                metroTileItem7.Enabled = true;
            }
           // metroTouchBilling.TitleText = "Token Billing";

          
        }

        private void add_product_Click_1(object sender, EventArgs e)
        {
            UserControl_product_add abcd = new UserControl_product_add();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(abcd);
        }

        private void add_category_Click_1(object sender, EventArgs e)
        {
            UserControl_Product adpro = new UserControl_Product();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(adpro);
        }

        private void adddamage_Click_1(object sender, EventArgs e)
        {
            ProductList dr = new ProductList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(dr);
        }

        private void metropruchases_Click_1(object sender, EventArgs e)
        {
            UserControl_purchase_form stopur = new UserControl_purchase_form();
            string bill_no = SupplierPayment.bill_no = "";
            string supplier_names = SupplierPurchase.supplier_name = "";
            bill_no = "";
            supplier_names = "";
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(stopur);
        }

        private void metroviestocks_Click_1(object sender, EventArgs e)
        {
            StockList al = new StockList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(al);
        }

    
        private void metroVieworder_Click_1(object sender, EventArgs e)
        {
           
        }

        private void metroResturantsell_Click_1(object sender, EventArgs e)
        {
            Viewrestaurant vieret = new Viewrestaurant();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vieret);
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void contentpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Bakery")
            {
                BakeryTable_Billing winfosr = new BakeryTable_Billing("TA");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(winfosr);
            }
            else
            {
                DataTable dt_user = blu.getusername(Login.sendtext);
                if (dt_user.Rows.Count > 0)
                {
                    DataTable dta = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                    if (dta.Rows.Count > 0)
                    {
                        if (dta.Rows[0]["takeaway"].ToString() == "True")
                        {
                            string takeawayload = cd.TakeAwayLoad();
                            if (takeawayload == "Customer First")
                            {
                                Control ctls = this.Parent;
                                Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("TakeAway");
                                ctls.Controls.Clear();
                                ctls.Controls.Add(vieret);
                            }
                            else
                            {
                                //  TAKE AWAY LOAD
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
                        }
                        else
                        {
                            MessageBox.Show("You Dont Have Access To Take Away ALert !!", "No Access Alert !!");
                        }
                    }
                }
            }

          
        }
        CheckDynamic cd = new CheckDynamic();
        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            string tokenload = cd.TokenLoad();
            if (tokenload == "Customer First")
            {
                Control ctls = this.Parent;
                Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("Token");
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);

            }
            else
            {
                DataTable dt = bld.EnableTokenBilling();
                if (dt.Rows.Count > 0)
                {
                    FastBilling fb = new FastBilling();
                    contentpanel.Controls.Clear();
                    contentpanel.Controls.Add(fb);
                }
                else
                {
                    MessageBox.Show("This features is disable in this pc", "Cant Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroTileItem8_Click(object sender, EventArgs e)
        {
            ADDMenuItem ist = new ADDMenuItem();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ist);
        }
        BLLTakeAway bltk = new BLLTakeAway();
        string take_away_id;
        private void metroTouchBilling_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Bakery")
            {
                CustomerDetailform vsbb = new CustomerDetailform("NC");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(vsbb);

            }
            else
            { 
                string tableload = cd.TableLoad();
                if (tableload == "Customer First")
                {
                    Control ctls = this.Parent;
                    Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("TableLoad");
                    ctls.Controls.Clear();
                    ctls.Controls.Add(vieret);

                }
                else
                {
                    Table_Management.Table_Billing winfor = new Table_Management.Table_Billing();
                    contentpanel.Controls.Clear();
                    contentpanel.Controls.Add(winfor);
                }
            }
        }
 

        private void metroorderitem_Click(object sender, EventArgs e)
        {
            if (BusinessType == "Bakery")
            {
                BakeryTable_Billing vsbb = new BakeryTable_Billing("HD");
                contentpanel.Controls.Clear();
                contentpanel.Controls.Add(vsbb);

            }
            else
            {
                DataTable dt_user = blu.getusername(Login.sendtext);
                if (dt_user.Rows.Count > 0)
                {
                    DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                    if (dtm.Rows.Count > 0)
                    {
                        if (dtm.Rows[0]["homedelivery"].ToString() == "True")
                        {
                            string homedeliveryload = cd.HomeDeliveryLoad();
                            if (homedeliveryload == "Customer First")
                            {
                                Control ctls = this.Parent;
                                Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("HomeDelivery");
                                ctls.Controls.Clear();
                                ctls.Controls.Add(vieret);

                            }
                            else
                            {
                                Control ctls = this.Parent;
                                KOTOrder vieret = new KOTOrder("520", null);
                                ctls.Controls.Clear();
                                ctls.Controls.Add(vieret);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You Dont Have Access To Home Delivery ALert !!", "No Access Alert !!");
                        }
                    }
                }
            }

        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            Sales_Chart.SalesChart sc = new Sales_Chart.SalesChart();
            panel1.Controls.Clear();
            panel1.Controls.Add(sc);
            //Viewrestaurant vieret = new Viewrestaurant();
            //contentpanel.Controls.Clear();
            //contentpanel.Controls.Add(vieret);
        }

        private void metroTileItem15_Click(object sender, EventArgs e)
        {
            Viewrestaurant vieret = new Viewrestaurant();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vieret);
        }

        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            CashWithdrawl cashwith = new CashWithdrawl("Restaurant");
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(cashwith);
        }

        private void metroTileItem14_Click(object sender, EventArgs e)
        {
            SupplierPurchase vsr = new SupplierPurchase();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsr);
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            Supplier_Details sup = new Supplier_Details();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(sup);
        }

        private void metroTileItem12_Click(object sender, EventArgs e)
        {

            ADDMenuItem ing = new ADDMenuItem();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(ing);
        }

        private void metroexpiry_Click(object sender, EventArgs e)
        {
            InhoueseUnit unit = new InhoueseUnit();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(unit);
        }
    }
}
