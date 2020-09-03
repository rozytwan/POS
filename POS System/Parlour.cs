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

namespace POS_System
{
    public partial class Parlour : UserControl
    {
        public Parlour()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        BLLDynamic bld = new BLLDynamic();
        string TakeawayRename;
        private void Parlour_Load(object sender, EventArgs e)
        {
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
                  
                }
            }
            DataTable dthd = bld.GetDynamic("HDR");
            if (dthd.Rows.Count > 0)
            {
                string status = dthd.Rows[0]["status"].ToString();
                if (status == "True")
                {
                   
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
         
            metroTileItem5.Enabled = false;
            metroTileItem6.Enabled = false;
          

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
               
                metroTileItem5.Enabled = true;
                metroTileItem6.Enabled = true;
              
            }
            metroTouchBilling.TitleText = "Billing";


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
            SupplierList sup = new SupplierList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(sup);
        }

        private void metropruchases_Click_1(object sender, EventArgs e)
        {
            UserControl_purchase_form viepur = new UserControl_purchase_form();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(viepur);
        }

        private void metroviestocks_Click_1(object sender, EventArgs e)
        {
            StockList al = new StockList();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(al);
        }

        private void metroexpiry_Click_1(object sender, EventArgs e)
        {
            InhoueseUnit unit = new InhoueseUnit();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(unit);
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
        private void metroTileItem6_Click(object sender, EventArgs e)
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
        CheckDynamic cd = new CheckDynamic();

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

            string tableload = cd.TableLoad();
            DataTable dtload = bld.GetFirstLoadDynamic();
            if (dtload.Rows.Count > 0)
            {
                string load = dtload.Rows[0]["description"].ToString();
                //TABLE Load
                if (load == "Table Load")
                {
                    if (tableload == "Customer First")
                    {
                        Control ctls = this.Parent;
                        Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("TableLoad");
                        ctls.Controls.Clear();
                        ctls.Controls.Add(vieret);

                    }
                    else
                    {
                        Billing winfor = new Billing(1.ToString(), null);
                        contentpanel.Controls.Clear();
                        contentpanel.Controls.Add(winfor);
                    }
                }
                else
                {
                    Billing winfor = new Billing(1000.ToString(), null);
                    contentpanel.Controls.Clear();
                    contentpanel.Controls.Add(winfor);
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

        private void contentpanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void metroorderitem_Click(object sender, EventArgs e)
        {
            CashWithdrawl cashwith = new CashWithdrawl("Restaurant");
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(cashwith);
        }

        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            CustomerDetailform vsbb = new CustomerDetailform("NC");
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(vsbb);
        }

        private void metroTileItem4_Click(object sender, EventArgs e)
        {
            InhoueseUnit unit = new InhoueseUnit();
            contentpanel.Controls.Clear();
            contentpanel.Controls.Add(unit);
        }
    }
}
