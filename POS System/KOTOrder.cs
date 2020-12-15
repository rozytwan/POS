using BLLS;
using POS_System.Customer_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class KOTOrder : UserControl
    {
        public KOTOrder(string table_no, string table_type)
        {

            table_no2 = table_no;
            gettableName = table_type;
            InitializeComponent();
            txtsearch.Text = "Bar Code";
            txtsearch.ForeColor = SystemColors.GrayText;
            this.txtsearch.Leave += new System.EventHandler(this.txtsearch_Leave);
            this.txtsearch.Enter += new System.EventHandler(this.txtsearch_Enter);
            txt_item_search.Text = "Search Item";
            txtsearch.ForeColor = SystemColors.GrayText;
            this.txt_item_search.Leave += new System.EventHandler(this.txt_item_search_Leave);
            this.txt_item_search.Enter += new System.EventHandler(this.txt_item_search_Enter);
        }
        public void spstart()
        {
            Application.Run(new Loding());
        }
        string table_no2;
        BLLCategory bllcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blord = new BLLOrder();
        BLLUser blu = new BLLUser();
        BLLTable blta = new BLLTable();
        BLLRestSell blresll = new BLLRestSell();
        Button newPanelcategory = new Button();
        BLLKotDisplay bllkot = new BLLKotDisplay();
        BLLhome_delivery blhd = new BLLhome_delivery();
        BLLTakeAway bltak = new BLLTakeAway();
        bll_orderCancel boc = new bll_orderCancel();
        BLLBarCode blbar = new BLLBarCode();
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        BLLkot_kitchen blps = new BLLkot_kitchen();
        BLLMenuItem blmi = new BLLMenuItem();
        BLLdays_wise blldays_wise = new BLLdays_wise();
        BLLPrinterSetting blpt = new BLLPrinterSetting();
        BLLdiscount bld = new BLLdiscount();
        BLLSystemDyanmic blsd = new BLLSystemDyanmic();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        blllCustomerDetailednyo blcdn = new blllCustomerDetailednyo();
        CheckDynamic cd = new CheckDynamic();
        // DateTime datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());

        string sales_type = "TS";
        private bool button_addwasclick = false;
        string category_name = "Null";
        string active = "yes";
        private delegate void CloseDelegate();
        public bool dgv_leave;
        string gettableName;
        //  string getCustomername = "";
        string getCustomerPhone = "";
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
        //  decimal service_charge = 0;

        bool back_click;
        int nxt = 0;
        int phg = 25;

        int next_panel = 25;
        int pre_cat = 0;
        string fiscal_year = "0";
        bool ServiceProvider;
        string ProviderName;
        string KOTRename;
        string billingSize;
        bool KotEnableDisable;
        bool KotSaveEnableDisable;
        bool Fixgrouping;
        bool Hidegrouping;
        string CheckoutRename;
        private void KOTOrder_Load(object sender, EventArgs e)
        {
            ServiceProvider = second_user_interface.ServiceProvider;
            ProviderName = second_user_interface.ProviderName;
            KOTRename = second_user_interface.KOTRename;
            KotEnableDisable = cd.KotEnableDisable();
            KotSaveEnableDisable = cd.KotSaveEnableDisable();
            Fixgrouping = cd.Fixgrouping();
            Hidegrouping = cd.Hidegrouping();
            CheckoutRename = cd.CheckoutRename();
            CheckPrinterForA4Billing();

            if (ServiceProvider == true)
            {
                btn_service_provider.Text = ProviderName;
                btn_service_provider.Visible = true;
            }
            else
            {
                btn_service_provider.Visible = false;
            }
            if (Fixgrouping == true)
            {
                btn_category_grouping_Click(null,null);
            }
            if (Hidegrouping == true)
            {
                btn_category_grouping.Visible=false;
            }
       
            if (KotEnableDisable == true)
            {
                btn_x_kot.Visible = true;
            }
            else
            {
                btn_x_note.Text = KOTRename + " Save & Billing";
                btn_x_kot.Visible = false;
            }
            if (KotSaveEnableDisable == true)
            {
                buttonX1.Visible = true;
            }
            else
            {
                buttonX1.Visible = false;
            }
            btn_x_kot.Text = KOTRename;
            btn_x_check_out.Text = CheckoutRename;
            buttonX1.Text = KOTRename + "(save)";
            service_provider_id = ServiceProviderUser.id;

            service_provider_name = ServiceProviderUser.service_provider_name;
            if (service_provider_name == null || service_provider_name == "Null")
            {
                service_provider_name = "admin";
                service_provider_id = 1;
            }
            //fiscal year
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            dyanmicCodeChecker();
            lbltable_real_no.Text = table_no2;
            if (lbltable_real_no.Text != "")
            {
                btn_takeaway.Hide();
                btn_dinning.Hide();
            }
            lbltable_real_no.Hide();
            label_table_no.Text = table_no2;
            lbl_table_name.Text = gettableName;
            if (lbltable_real_no.Text == "520")
            {
                homeDelevery();
                lbltable_name_hd.Text = "Home Delivery";
                lbl_table_name.Hide();
                label13.Hide();
                sales_type = "HD";
            }
            else if (Convert.ToInt32(lbltable_real_no.Text) >= 1001)
            {
                if (gettableName == "TA")
                {
                    btn_dinning.Show();
                    btn_takeaway.Show();
                    sales_type = "TA";
                    btn_dinning.Enabled = true;
                    btn_takeaway.Enabled = false;
                    DataTable dtm = bltak.get_twk_id(Convert.ToInt32(lbltable_real_no.Text));
                    if (dtm.Rows.Count > 0)
                    {
                        label_table_no.Text = (Convert.ToInt32(dtm.Rows[0][0].ToString())).ToString();
                        lbltable_name_hd.Text = "Take Away ID";
                        lbl_table_name.Hide();
                        label13.Show();

                    }
                    else
                    {
                        take_away();

                    }
                    // btn_x_note.Text = "KOT Save & Billing";

                }
            }
            else if (Convert.ToInt32(lbltable_real_no.Text) >= 100 && Convert.ToInt32(lbltable_real_no.Text) <= 519)
            {
                lbltable_name_hd.Text = "Room No";
            }
            KotOrcerId();
            table_active_count();
            quantity_count();
            categorysub(pre_cat, next_panel, 0);
            txtrichbox.Hide();
            flwpln_item.Hide();
            btnitem_next.Hide();
            btn_item_preview.Hide();
            btnpre.Hide();
            btnnext.Hide();
            //Thread.Sleep(500);
            // th.Abort();
            datagridviewload();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
            DataTable dtcheck = blord.getallcategory();
            if (dtcheck.Rows.Count > 0)
            {
                btnnext.Show();
            }
            button_addwasclick = true;
            DynamicChecker();
            // }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public void CheckPrinterForA4Billing()
        {
            DataTable dt_prt = blpst.getalldata();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "A4")
                {
                    billingSize = "A4";
                }

            }
        }
        bool cancelCheckAccess = false;
        public void DynamicChecker()
        {
            DataTable dtcancel = bldd.GetDynamic("AACL");
            if (dtcancel.Rows.Count > 0)
            {
                string status = dtcancel.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    cancelCheckAccess = true;

                }
                else
                {
                    cancelCheckAccess = false;
                }
            }
            else
            {
                cancelCheckAccess = false;
            }
        }
        public void homeDelevery()
        {
            DataTable dt = blhd.gethomedelevery();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    label_table_no.Text = "520";
                    lbltable_real_no.Text = label_table_no.Text;
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    label_table_no.Text = getinvoiceno.ToString();
                    lbltable_real_no.Text = label_table_no.Text;

                }
            }
        }
        int kot_id;
        public void KotOrcerId()
        {
            DataTable dt = blord.GetMaxKotId();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    kot_id = 1;

                }
                else
                {
                    kot_id = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;

                }
            }

        }
        public void take_away()
        {
            DataTable dt = bltak.getmaxNo();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    lbltable_real_no.Text = "1001";
                    label_table_no.Text = "1001";
                    lbltable_name_hd.Text = "Take Away ID";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString())+1 ;
                    lbltable_real_no.Text = getinvoiceno.ToString();

                    label_table_no.Text = getinvoiceno.ToString();
                    lbltable_name_hd.Text = "Take Away ID";

                }
            }
        }
        bool salesItemTop = false;
        public void dyanmicCodeChecker()
        {
            DataTable dtd = blsd.getALLDynamicByCode("SM001");
            if (dtd.Rows.Count > 0)
            {
                string status = dtd.Rows[0]["Status"].ToString();
                if (status == "True")
                {
                    btn_category_grouping.Visible = true;
                }
            }
            DataTable dts = blsd.getALLDynamicByCode("SM002");
            if (dts.Rows.Count > 0)
            {
                string status = dts.Rows[0]["Status"].ToString();
                if (status == "True")
                {
                    salesItemTop = true;
                }
            }
        }
        public void table_active_count()
        {
            DataTable dt = blresll.count_table();
            tbl_count.Text = dt.Rows.Count.ToString();
        }
        public void quantity_count()
        {
            DataTable dt_count = blresll.count_quantity();
            lblcount_quantity.Text = dt_count.Rows[0][0].ToString();
        }
        public void categorysub(int cat_id_db, int cat_id_db2, int id)
        {
            DataTable dt = new DataTable();
            if (id > 0)
            {
                dt = blord.get_all_categoryGroupingById(cat_id_db, cat_id_db2, id);
            }
            else
            {
                dt = blord.get_all_category_category_id(cat_id_db, cat_id_db2);
            }
            flwpln_category.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] newPanelcategory = new Button[99];
                newPanelcategory[low] = new Button();
                newPanelcategory[low].Name = dt.Rows[low]["category_id"].ToString();
                newPanelcategory[low].Text = dt.Rows[low]["category_name"].ToString();
                newPanelcategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(50, 50));
                newPanelcategory[low].Height = 98;
                newPanelcategory[low].Width = 114;
                newPanelcategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newPanelcategory[low].FlatStyle = FlatStyle.Flat;
                newPanelcategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //newPanelcategory[low].BackColor = ColorTranslator.FromHtml("#33A6FF");

                newPanelcategory[low].ForeColor = Color.White;

                string image_color = dt.Rows[low]["category_color"].ToString();

                if (image_color.Length > 0 && image_color != null && image_color != "")
                {

                    newPanelcategory[low].BackColor = Color.FromName(image_color);
                    newPanelcategory[low].TextAlign = ContentAlignment.TopCenter;
                }
                else
                {
                    Byte[] imge_byte = (byte[])dt.Rows[low]["category_image"];
                    var stream = new MemoryStream(imge_byte);
                    var image = (Bitmap)Image.FromStream(stream);
                    var new_image = new Bitmap(image, new Size(112, 80));
                    newPanelcategory[low].TextAlign = ContentAlignment.BottomCenter;
                    newPanelcategory[low].BackgroundImage = new_image;
                    newPanelcategory[low].BackgroundImageLayout = ImageLayout.None;
                    newPanelcategory[low].ImageAlign = ContentAlignment.TopCenter;
                }

                flwpln_category.Controls.Add(newPanelcategory[low]);
                newPanelcategory[low].Click += new EventHandler(newPanelcategorys_Click);
                lblcateogry_item.Hide();
                //lblitem_id.Hide();
            }

        }
        private void btnnext_Click(object sender, EventArgs e)
        {
            next_panel = next_panel + 25;
            pre_cat = pre_cat + 25;
            DataTable dtcheck = blord.getallcategory();
            if (pre_cat <= dtcheck.Rows.Count)
            {
                categorysub(pre_cat, next_panel, 0);
                btnpre.Show();

            }
            if (next_panel >= dtcheck.Rows.Count)
            {
                btnnext.Hide();
            }
        }


        private void btnpre_Click(object sender, EventArgs e)
        {
            next_panel = next_panel - 25;
            pre_cat = pre_cat - 25;
            if (next_panel >= 0)
            {
                categorysub(pre_cat, next_panel, 0);
                if (pre_cat == 0)
                {
                    btnpre.Hide();
                    btnnext.Show();
                }
                else
                {
                    btnnext.Show();
                }
            }

        }

        public void newPanelcategorys_Click(object sender, EventArgs e)
        {
            //try
            //{
            category_name = ((Button)sender).Text;
            lblcateogry_item.Text = ((Button)sender).Name;
            flwpln_item.Controls.Clear();
            btnnext.Hide();
            btnpre.Hide();
            lblcategory_name.Text = "Items";
            KOTOrder.Animate(flwpln_item, KOTOrder.Effect.Roll, 150, 45);
            item_by_category_id(nxt, phg);
            DataTable dts = blmi.getcategoryDetailsByCategoryIds((Convert.ToInt32(lblcateogry_item.Text)));
            if (dts.Rows.Count > 25)
            {
                btnitem_next.Show();
            }
            back_click = true;

            // }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void item_by_category_id(int item_id_db, int item_id2_db)
        {
            DataTable dts = new DataTable();
            if (salesItemTop == true)
            {
                dts = blmi.getitembycategoryid_temp_viewOrderBySalesQty(Convert.ToInt32(lblcateogry_item.Text), item_id_db, item_id2_db, fiscal_year);
            }
            else
            {
                dts = blmi.getitembycategoryid_temp_view(Convert.ToInt32(lblcateogry_item.Text), item_id_db, item_id2_db);
            }
            flwpln_item.Controls.Clear();
            for (int xIx = 0; xIx < dts.Rows.Count; xIx++)
            {
                Button panelButtons = new Button();
                Label lbl_price = new Label();
                panelButtons = new Button();
                panelButtons.Tag = xIx;
                panelButtons.Text = dts.Rows[xIx]["item_name"].ToString();
                panelButtons.BackColor = Color.Black;
                panelButtons.Font = new Font(panelButtons.Font.FontFamily, 10);
                panelButtons.Name = dts.Rows[xIx]["item_id"].ToString();
                panelButtons.Location = System.Drawing.Point.Add(new Point(4 + xIx * 70, 4), new Size(50, 50));
                panelButtons.Height = 98;
                panelButtons.Width = 112;
                panelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                string image_color_name = dts.Rows[xIx]["image_color"].ToString();

                if (image_color_name.Length > 0 && image_color_name != "" && image_color_name != "")
                {

                    panelButtons.BackColor = Color.FromName(image_color_name);
                    panelButtons.TextAlign = ContentAlignment.TopCenter;
                    lbl_price.Text = dts.Rows[xIx]["item_price"].ToString();
                    lbl_price.Dock = DockStyle.Bottom;
                    lbl_price.TextAlign = ContentAlignment.MiddleCenter;
                    lbl_price.BackColor = Color.Transparent;
                    panelButtons.Controls.Add(lbl_price);
                }
                else
                {
                    Byte[] imge_byte = (byte[])dts.Rows[xIx]["image_name"];
                    var stream = new MemoryStream(imge_byte);
                    var image = (Bitmap)Image.FromStream(stream);
                    var new_image = new Bitmap(image, new Size(112, 80));
                    panelButtons.TextAlign = ContentAlignment.BottomCenter;
                    panelButtons.BackgroundImage = new_image;
                    panelButtons.BackgroundImageLayout = ImageLayout.None;
                    panelButtons.ImageAlign = ContentAlignment.TopCenter;

                }
                panelButtons.ForeColor = Color.White;
                panelButtons.FlatStyle = FlatStyle.Flat;


                panelButtons.BringToFront();

                int item_id_select = Convert.ToInt32(dts.Rows[xIx]["item_id"].ToString());
                DataTable dt = blldays_wise.getdayswisedatabyItem_Id(item_id_select);


                string today = DateTime.Now.DayOfWeek.ToString();
                string applicable_days = dts.Rows[xIx]["applicable_time_period"].ToString();
                if (applicable_days == "Always")
                {

                    flwpln_item.Controls.Add(panelButtons);
                }
                else if (applicable_days == "Days of Week")
                {
                    for (int xy = 0; xy < dt.Rows.Count; xy++)
                    {
                        if (dt.Rows[xy]["days"].ToString() == today)
                        {
                            flwpln_item.Controls.Add(panelButtons);
                        }
                    }

                }

                panelButtons.Click += new EventHandler(panelButtons_Click);

                back_click = true;
            }
        }
        private void btnitem_next_Click_1(object sender, EventArgs e)
        {
            nxt = nxt + 25;
            phg = phg + 25;
            DataTable dtcheck = blord.get_item_by_category_id2(Convert.ToInt32(lblcateogry_item.Text));
            if (nxt <= dtcheck.Rows.Count)
            {
                item_by_category_id(nxt, phg);
                btn_item_preview.Show();
            }
            if (phg >= dtcheck.Rows.Count)
            {
                btnitem_next.Hide();
            }
        }
        private void btn_item_preview_Click_1(object sender, EventArgs e)
        {
            nxt = nxt - 25;
            phg = phg - 25;
            if (nxt >= 0)
            {
                item_by_category_id(nxt, phg);
                btnitem_next.Show();
            }
            if (nxt <= 0)
            {
                btn_item_preview.Hide();
            }
        }
        int i = 0;
        string item_id;
        string modifier_text;

        private void txt_item_search_TextChanged(object sender, EventArgs e)
        {
            search_item_by_item_name();
        }
        public void search_item_by_item_name()
        {
            if (txt_item_search.Text != "" && txt_item_search.Text != "Search Item" && txt_item_search.TextLength > 3)
            {
                DataTable dts = blmi.getproductbyproductname(txt_item_search.Text);
                flwpln_item.Controls.Clear();
                flwpln_item.Show();
                for (int xIx = 0; xIx < dts.Rows.Count; xIx++)
                {
                    Button panelButtons = new Button();
                    Label lbl_price = new Label();
                    panelButtons = new Button();
                    panelButtons.Tag = xIx;
                    panelButtons.Text = dts.Rows[xIx]["item_name"].ToString();
                    panelButtons.BackColor = Color.Black;
                    panelButtons.Font = new Font(panelButtons.Font.FontFamily, 10);
                    panelButtons.Name = dts.Rows[xIx]["item_id"].ToString();
                    panelButtons.Location = System.Drawing.Point.Add(new Point(4 + xIx * 70, 4), new Size(50, 50));
                    panelButtons.Height = 98;
                    panelButtons.Width = 112;
                    panelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    string image_color_name = dts.Rows[xIx]["image_color"].ToString();
                    if (image_color_name.Length > 0 && image_color_name != "" && image_color_name != "")
                    {

                        panelButtons.BackColor = Color.FromName(image_color_name);
                        panelButtons.TextAlign = ContentAlignment.TopCenter;
                        lbl_price.Text = dts.Rows[xIx]["item_price"].ToString();
                        lbl_price.Dock = DockStyle.Bottom;
                        lbl_price.TextAlign = ContentAlignment.MiddleCenter;
                        lbl_price.BackColor = Color.Transparent;
                        panelButtons.Controls.Add(lbl_price);
                    }
                    else
                    {
                        Byte[] imge_byte = (byte[])dts.Rows[xIx]["image_name"];
                        var stream = new MemoryStream(imge_byte);
                        var image = (Bitmap)Image.FromStream(stream);
                        var new_image = new Bitmap(image, new Size(112, 80));
                        panelButtons.TextAlign = ContentAlignment.BottomCenter;
                        panelButtons.BackgroundImage = new_image;
                        panelButtons.BackgroundImageLayout = ImageLayout.None;
                        panelButtons.ImageAlign = ContentAlignment.TopCenter;

                    }
                    panelButtons.ForeColor = Color.White;
                    panelButtons.FlatStyle = FlatStyle.Flat;
                    DataTable dt_arabic = blu.checkbusiness();
                    panelButtons.Font = new Font("Times New Roman", 8, FontStyle.Bold);
                    flwpln_item.Controls.Add(panelButtons);
                    panelButtons.BringToFront();
                    panelButtons.Click += new EventHandler(panelButtons_Click);
                    back_click = true;
                }
            }
        }
        //item button click
        public void panelButtons_Click(object sender, EventArgs e)
        {
            try
            {
                decimal quantity = 1;
                item_id = ((Button)sender).Name;

                DataTable dt = blord.getitembyitem_id(Convert.ToInt32(item_id));
                bool Found = false;
                if (dataGridView1.Rows.Count > 0)
                {

                    //Check if the product Id exists with the same Price
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["cal_item_name"].Value.ToString() == ((Button)sender).Text && row.Cells["cal_order_id"].Value == null)
                        {

                            if (Convert.ToString(row.Cells["cal_item_name"].Value) == ((Button)sender).Text)
                            {

                                row.Cells["cal_qty"].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells["cal_qty"].Value ?? String.Empty));
                                decimal cost = Convert.ToDecimal(row.Cells["cal_cost"].Value);
                                decimal quantitys = Convert.ToInt32(row.Cells["cal_qty"].Value ?? String.Empty);
                                decimal total = quantitys * cost;
                                row.Cells["cal_total"].Value = total;

                                Found = true;
                            }
                        }

                    }
                    if (!Found)
                    {
                        DataTable dt_check_modifier = blmd.get_all_modifier_by_item_id(Convert.ToInt32(item_id));
                        if (dt_check_modifier.Rows.Count > 0)
                        {

                            Item_modifier_list iml = new Item_modifier_list();
                            iml.item_id = item_id;
                            iml.ShowDialog();
                            modifier_text = Item_modifier_list.md_text;
                            int isi = dataGridView1.Rows.Add();
                            dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt.Rows[0]["item_name"].ToString();
                            dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                            dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt.Rows[0]["item_price"].ToString();
                            decimal total = quantity * Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                            dataGridView1.Rows[isi].Cells["cal_category_name"].Value = category_name;
                            dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                            dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt.Rows[0]["kot_print"].ToString();
                            dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                            dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                            dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;


                        }
                        else
                        {
                            //Add the row to grid view
                            int isi = dataGridView1.Rows.Add();
                            dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt.Rows[0]["item_name"].ToString();
                            dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                            dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt.Rows[0]["item_price"].ToString();
                            decimal total = quantity * Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                            dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                            dataGridView1.Rows[isi].Cells["cal_category_name"].Value = category_name;
                            dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt.Rows[0]["kot_print"].ToString();
                            dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;
                            dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                        }

                    }
                }
                else
                {
                    DataTable dt_check_modifier = blmd.get_all_modifier_by_item_id(Convert.ToInt32(item_id));
                    if (dt_check_modifier.Rows.Count > 0)
                    {
                        Item_modifier_list iml = new Item_modifier_list();
                        iml.item_id = item_id;
                        iml.ShowDialog();
                        modifier_text = Item_modifier_list.md_text;
                        int isi = dataGridView1.Rows.Add();
                        dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt.Rows[0]["item_name"].ToString();
                        dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                        dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt.Rows[0]["item_price"].ToString();
                        decimal total = quantity * Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                        dataGridView1.Rows[isi].Cells["cal_category_name"].Value = category_name;
                        dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                        dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt.Rows[0]["kot_print"].ToString();
                        dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                        dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                        dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;


                    }
                    else
                    {
                        //Add the row to grid view for the first time
                        int isi = dataGridView1.Rows.Add();
                        dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt.Rows[0]["item_name"].ToString();
                        dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                        dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt.Rows[0]["item_price"].ToString();
                        decimal total = quantity * Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                        dataGridView1.Rows[isi].Cells["cal_category_name"].Value = category_name;
                        dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                        dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt.Rows[0]["kot_print"].ToString();
                        dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;
                        dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                    }


                }

                calculate_total();

                button_addwasclick = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string grandtotal;
        public void calculate_total()
        {
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
            }


            grandtotal = sum.ToString();
            tax_calcu();
        }
        //kot cancel print
        SerialPortDataSender spds = new SerialPortDataSender();
        public void tax_calcu()
        {
            if (grandtotal != "")
            {
                TaxCalculation tax = new TaxCalculation();

                tax_amount = tax.tax_calculation(Convert.ToDecimal(grandtotal));
                static_grand_total = Convert.ToDecimal(grandtotal) + tax_amount;
                lbl_total.Text = static_grand_total.ToString("#.##");
                // spds.CustomerDisplayVFD(lbl_total.Text, 0x32);

            }
        }

        public void clear()
        {
            grandtotal = "0.00";
        }

        int order_id;
        public void order_id_sender()
        {
            DataTable dt = blord.getalldata_order();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    order_id = 1;
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    order_id = getinvoiceno;
                }
            }
        }
        int kot_display_id;

        bool kot_printer_1 = false;
        bool kot_printer_2 = false;
        bool kot_printer_3 = false;
        bool kot_printer_4 = false;
        bool kot_printer_5 = false;

        BLLReserved blres = new BLLReserved();
        public void delete_reserved()
        {
            DataTable dt = blres.get_value_by_table_no(Convert.ToInt32(lbltable_real_no.Text));
            if (dt.Rows.Count > 0)
            {
                int delete = blres.delete_table_reserved(Convert.ToInt32(lbltable_real_no.Text));
            }
        }
        int insert_order_print;
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        HomeDeliveryModel hdm = new HomeDeliveryModel();
        private void btnkot_Click(object sender, EventArgs e)
        {

            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows.Count > 17)
                {
                    if (billingSize == "A4")
                    {
                        MessageBox.Show("Sorry you can't order more than 17 item in A4 size billing.", "Excessive Item Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                if (!decimal.TryParse(lbltable_real_no.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No");
                }

                else
                {
                    //  kot_display();
                    for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                        order_id_sender();
                        string item_name = dataGridView1.Rows[ib].Cells["cal_item_name"].Value.ToString();
                        decimal quantity = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_total"].Value.ToString());
                        string category_name = dataGridView1.Rows[ib].Cells["cal_category_name"].Value.ToString();
                        string kot_print = dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString();
                        DateTime todaydate = DateTime.Now;
                        string time = DateTime.Now.ToShortTimeString();
                        if (dataGridView1.Rows[ib].Cells["cal_order_id"].Value == null)
                        {
                            insert_order_print = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, sales_type, category_name, kot_print, sales_type, service_provider_name.ToString(), kot_id);

                            if (dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString() == "K1")
                            {
                                kot_printer_1 = true;
                            }
                            if (dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString() == "K2")
                            {
                                kot_printer_2 = true;
                            }
                            if (dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString() == "B1")
                            {
                                kot_printer_3 = true;
                            }
                            if (dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString() == "B2")
                            {
                                kot_printer_4 = true;
                            }
                            if (dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString() == "K3")
                            {
                                kot_printer_5 = true;
                            }
                        }
                    }
                    if (insert_order_print > 0)
                    {
                        if (Convert.ToDecimal(lbltable_real_no.Text) >= 106)
                        {
                            if (Convert.ToDecimal(lbltable_real_no.Text) < 1000)
                            {
                                int hd_no = blhd.inserthomedeleveryid(Convert.ToInt32(lbltable_real_no.Text));
                                int customer_id = HomeDeliveryModel.customer_id;
                                if (customer_id > 0)
                                {
                                    int insertCustomerid = blcdn.insertHomeDeliveryCustomer(customer_id.ToString(), lbltable_real_no.Text);
                                }
                                //else
                                //{
                                //    int customer_id2 = CustomerDetailform
                                //}
                            }
                        }
                        KotOrcerId();
                        kot_printChecker();
                        KotPrintStatus();
                        datagridviewload();
                        table_active_count();
                        quantity_count();
                        delete_reserved();
                        button_addwasclick = true;
                        if (Convert.ToDecimal(lbltable_real_no.Text) >= 1000)
                        {
                            DataTable dt = bltak.get_all_take_away_id(Convert.ToInt32(lbltable_real_no.Text));

                            if (dt.Rows.Count == 0)
                            {
                                int insert = bltak.insert_into_take_away(Convert.ToInt32(lbltable_real_no.Text));
                            }

                        }
                        user_log_insert();
                    }
                    else
                    {
                        MessageBox.Show("Cannot Order Your Item Please Do It Again", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void user_log_insert()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(user_name_log, day, "KOT Order");

            if (dt.Rows.Count == 0)
            {
                int abc = bulg.createuserlog(user_name_log, "KOT Order", date, day);
            }

        }

        public void kot_printChecker()
        {
            DataTable dt_prt = blpt.getalldata();
            DataTable dtp = blpt.getallPrintingTimes();
            if (dt_prt.Rows[0]["kot_printer"].ToString() == "80")
            {
                if (kot_printer_1 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot80.printerName = "K1";
                            kot_printing_80();
                            kot80.printkot();
                            kot80.clear_data();
                            kot_printer_1 = kot80.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_2 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K2"]); i++)
                        {
                            kot80.printerName = "K2";
                            kot_printing_80();
                            kot80.printkot();
                            kot_printer_2 = kot80.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_3 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "B1";
                            kot_printing_80();
                            kot80.printkot();
                            kot_printer_3 = kot80.kot_printer_1;

                        }
                    }
                }
                if (kot_printer_4 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "B2";
                            kot_printing_80();
                            kot80.printkot();
                            kot_printer_4 = kot80.kot_printer_1;

                        }
                    }
                }
                if (kot_printer_5 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot80.printerName = "K3";
                            kot_printing_80();
                            kot80.printkot();
                            kot_printer_5 = kot80.kot_printer_1;

                        }
                    }
                }
            }
            else
            {
                if (kot_printer_1 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot.printer_name = "K1";
                            kot_printing_56_2();
                            kot.printkot();
                            kot_printer_1 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_2 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K2"]); i++)
                        {
                            kot.printer_name = "K2";
                            kot_printing_56_2();
                            kot.printkot();
                            kot_printer_2 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_3 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot.printer_name = "B1";
                            kot_printing_56_2();
                            kot.printkot();
                            kot_printer_3 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_4 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot.printer_name = "B2";
                            kot_printing_56_2();
                            kot.printkot();
                            kot_printer_4 = kot.kot_printer_1;
                        }
                    }
                }
                if (kot_printer_5 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K1"]); i++)
                        {
                            kot.printer_name = "K3";
                            kot_printing_56_2();
                            kot.printkot();
                            kot_printer_5 = kot.kot_printer_1;
                        }
                    }
                }
            }
        }


        public void KotPrintStatus()
        {
            kot_printer_1 = false;
            kot_printer_2 = false;
            kot_printer_3 = false;
            kot_printer_4 = false;
            kot_printer_5 = false;
        }

        KOTPrinting56 kot = new KOTPrinting56();

        public void kot_printing_56_2()
        {
            kot.table_no = lbltable_real_no.Text;
            kot.table_display_no = label_table_no.Text;
            kot.table_name = lbl_table_name.Text;
            kot.note_pad = txtrichbox.Text;
            kot.cashier = Login.sendtext;
            kot.service_provider = service_provider_name;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["cal_order_id"].Value == null)
                {
                    kot.datagridview_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    kot.datagridview_qty.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    kot.datagridview_kot_print.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                    kot.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }


        }
        KOTPrinting80 kot80 = new KOTPrinting80();
        public void kot_printing_80()
        {
            kot80.table_no = lbltable_real_no.Text;
            kot80.table_displayNo = label_table_no.Text;
            kot80.table_name = lbl_table_name.Text;
            kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
            kot80.kot_id = kot_id.ToString();
            kot80.kid = KitchenOrderInfo.kid;
            kot80.adult = KitchenOrderInfo.adult;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["cal_order_id"].Value == null)
                {
                    kot80.datagridview_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    kot80.datagridview_qty.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    kot80.datagridview_kot_print.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                    kot80.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }

        }
        int insert_order;
        bool kot_after_billing = false;

        private void btn_kot_withoutPrint_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows.Count > 17)
                { 
                    if (billingSize == "A4")
                    {
                        MessageBox.Show("Sorry you can't order more than 17 item in A4 size billing.", "Excessive Item Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                if (!decimal.TryParse(lbltable_real_no.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No");
                }
                else
                {
                    for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                        string item_name = dataGridView1.Rows[ib].Cells["cal_item_name"].Value.ToString();
                        decimal quantity = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_total"].Value.ToString());
                        string category_name = dataGridView1.Rows[ib].Cells["cal_category_name"].Value.ToString();
                        string kot_print = dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString();
                        DateTime todaydate = DateTime.Now;
                        if (dataGridView1.Rows[ib].Cells["cal_order_id"].Value == null)
                        {
                            insert_order = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, sales_type, category_name, kot_print, sales_type, service_provider_name, kot_id);
                        }

                    }
                    if (insert_order > 0)
                    {
                        KotOrcerId();
                        delete_reserved();
                        datagridviewload();
                        table_active_count();
                        quantity_count();
                        button_addwasclick = true;
                        if (Convert.ToDecimal(lbltable_real_no.Text) >= 520)
                        {
                            if (Convert.ToDecimal(lbltable_real_no.Text) < 1000)
                            {
                                int hd_no = blhd.inserthomedeleveryid(Convert.ToInt32(lbltable_real_no.Text));
                                int customer_id = HomeDeliveryModel.customer_id;
                                if (customer_id > 0)
                                {
                                    int insertCustomerid = blcdn.insertHomeDeliveryCustomer(customer_id.ToString(), lbltable_real_no.Text);

                                }
                            }
                        }
                        if (Convert.ToDecimal(lbltable_real_no.Text) >= 1000)
                        {
                            DataTable dt = bltak.get_all_take_away_id(Convert.ToInt32(lbltable_real_no.Text));
                            if (dt.Rows.Count == 0)
                            {
                                int insert = bltak.insert_into_take_away(Convert.ToInt32(lbltable_real_no.Text));

                            }

                        }
                        if (Convert.ToInt32(lbltable_real_no.Text) >= 1001)
                        {
                            if (kot_after_billing == false)
                            {
                                //take_away();
                                kot_after_billing = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot Order Your Item Please Do It Again", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        public static string row_id;
        private void btnenter_Click_1(object sender, EventArgs e)
        {
            if (btn_x_note.Text == "Note")
            {
                //row_id = dataGridView1.CurrentRow.Cells["cal_description"].Value.ToString();

                //Control ctls = this.Parent;
                //NoteItem cl = new NoteItem();
                //ctls.Controls.Clear();
                //ctls.Controls.Add(cl);

                  KOTOrder.Animate(txtrichbox, KOTOrder.Effect.Slide, 150, 180);
            }
            else
            {
                kot_after_billing = true;
                btn_kot_withoutPrint_Click_1(null, null);
                Control ctls = this.Parent;
                Billing blb = new Billing(lbltable_real_no.Text, label_table_no.Text);
                ctls.Controls.Clear();
                ctls.Controls.Add(blb);

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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (back_click == true)
            {
                lblcategory_name.Text = "Category";
                categorysub(pre_cat, next_panel, 0);
                KOTOrder.Animate(flwpln_item, KOTOrder.Effect.Slide, 150, 180);
                flwpln_item.Hide();
                flwpln_category.Show();
                txt_item_search.Text = "Search Item";
                txt_item_search.ForeColor = SystemColors.GrayText;

            }
            else if (flag_visiable == false)
            {

                txtsearch.Text = "Bar Code";
                txtsearch.ForeColor = SystemColors.GrayText;
            }
            DataTable dtcheck = blord.getallcategory();
            if (pre_cat <= dtcheck.Rows.Count)
            {
                btnpre.Show();
            }

            if (pre_cat >= 0)
            {
                if (pre_cat == 0)
                {
                    btnpre.Hide();
                    btnnext.Show();
                }
                else
                {
                    btnnext.Show();
                }
            }
            if (next_panel >= dtcheck.Rows.Count)
            {
                btnnext.Hide();
            }
            nxt = 0;
            phg = 25;
            btnitem_next.Hide();
            btn_item_preview.Hide();
            back_click = false;
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length == 0)
            {
                txtsearch.Text = "Bar Code";
                txtsearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Bar Code")
            {
                txtsearch.Text = "";
                txtsearch.ForeColor = SystemColors.GrayText;
            }
        }
        private void txt_item_search_Leave(object sender, EventArgs e)
        {
            if (txt_item_search.Text.Length == 0)
            {
                txt_item_search.Text = "Search Item";
                txt_item_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void txt_item_search_Enter(object sender, EventArgs e)
        {
            if (txt_item_search.Text == "Search Item")
            {
                txt_item_search.Text = "";
                txt_item_search.ForeColor = SystemColors.GrayText;
            }
        }


        bool flag_visiable = true;
        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsearch.TextLength > 0 && txtsearch.Text != "" && txtsearch.Text != "Bar Code")
                {
                    DataTable dt = blbar.get_all_item_by_bar_code(txtsearch.Text);
                    if (dt.Rows.Count > 0)
                    {
                        int item_id = Convert.ToInt32(dt.Rows[0]["item_id"].ToString());
                        DataTable dt_item = blord.getitembyitem_id(item_id);
                        string bar_code_item_name = dt_item.Rows[0]["item_name"].ToString();
                        int category_id = Convert.ToInt32(dt_item.Rows[0]["category_id"].ToString());
                        DataTable dt_category = bllcat.getallitemcategory_byid(category_id);
                        string bar_code_category = dt_category.Rows[0]["category_name"].ToString();
                        decimal quantity = 1;
                        bool Found = false;
                        if (button_addwasclick == true)
                        {
                            dataGridView1.Rows.Clear();
                            button_addwasclick = false;
                        }

                        if (dataGridView1.Rows.Count > 0)
                        {
                            //Check if the product Id exists with the same Price
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToString(row.Cells["cal_item_name"].Value) == bar_code_item_name)
                                {
                                    //Update the Quantity of the found row
                                    row.Cells["cal_qty"].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells["cal_qty"].Value ?? String.Empty));

                                    decimal cost = Convert.ToDecimal(row.Cells["cal_cost"].Value);
                                    decimal quantitys = Convert.ToInt32(row.Cells["cal_qty"].Value ?? String.Empty);
                                    decimal total = quantitys * cost;
                                    row.Cells["cal_total"].Value = total;
                                    decimal sum = 0;
                                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                                    {
                                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                                    }
                                    grandtotal = sum.ToString();
                                    Found = true;
                                    txtsearch.Text = "";
                                }
                            }
                            if (!Found)
                            {
                                //Add the row to grid view
                                int isi = dataGridView1.Rows.Add();
                                dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt_item.Rows[0]["item_name"].ToString();
                                dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                                dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt_item.Rows[0]["item_price"].ToString();
                                decimal total = quantity * Convert.ToDecimal(dt_item.Rows[0]["item_price"].ToString());
                                dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                                dataGridView1.Rows[isi].Cells["cal_category_name"].Value = bar_code_category;
                                dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt_item.Rows[0]["kot_print"].ToString();
                                decimal sum = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                                {
                                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                                }

                                grandtotal = sum.ToString();

                                i++;
                                txtsearch.Text = "";
                            }

                        }
                        else
                        {
                            //Add the row to grid view for the first time
                            int isi = dataGridView1.Rows.Add();
                            dataGridView1.Rows[isi].Cells["cal_item_name"].Value = dt_item.Rows[0]["item_name"].ToString();
                            dataGridView1.Rows[isi].Cells["cal_qty"].Value = quantity;
                            dataGridView1.Rows[isi].Cells["cal_cost"].Value = dt_item.Rows[0]["item_price"].ToString();
                            decimal total = quantity * Convert.ToDecimal(dt_item.Rows[0]["item_price"].ToString());
                            dataGridView1.Rows[isi].Cells["cal_category_name"].Value = bar_code_category;
                            dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                            dataGridView1.Rows[isi].Cells["calkot_print"].Value = dt_item.Rows[0]["kot_print"].ToString();

                            decimal sum = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
                            }
                            grandtotal = sum.ToString();

                            i++;
                            txtsearch.Text = "";
                        }


                    }
                    else
                    {
                        MessageBox.Show("Cannot Find Your Bar Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lbltable_real_no.Text) >= 519)
            {
                if (Convert.ToDecimal(lbltable_real_no.Text) < 1000)
                {
                    home blbc = new home(lbltable_real_no.Text);
                    blbc.ShowDialog();
                    dataGridView1.Rows.Clear();
                    homeDelevery();
                }
                else
                {
                    Control ctls = this.Parent;
                    Billing blb = new Billing(lbltable_real_no.Text, label_table_no.Text);
                    ctls.Controls.Clear();
                    ctls.Controls.Add(blb);
                }
            }
            else
            {

                Control ctls = this.Parent;
                Billing blb = new Billing(lbltable_real_no.Text, null);
                ctls.Controls.Clear();
                ctls.Controls.Add(blb);
            }
        }
        bool minus_click = false;
        private void btnminus_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    if ((Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1) >= 1)
                    {
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1);
                        decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        decimal quantitys = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                        decimal total = quantitys * cost;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = total;
                        calculate_total();
                        // tax_calcu();
                        DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                        if (dt.Rows.Count > 0)
                        {
                            minus_click = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select row first or select only one row");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void for_minus_cancel()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (datagridview_qty[i] != dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString())
                {
                    if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K1")
                    {
                        kot_cancel_printer_1 = true;
                    }
                    else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K2")
                    {
                        kot_cancel_printer_2 = true;
                    }
                    else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K3")
                    {
                        kot_cancel_printer_5 = true;
                    }
                    else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B1")
                    {
                        kot_cancel_printer_3 = true;
                    }
                    else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B2")
                    {
                        kot_cancel_printer_4 = true;
                    }
                    int uup = blord.updateorderstable(Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_order_id"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value));
                }
            }
            cancel_minus = true;
            print_cancel();
            KotCancelPrinterStatus();
            calculate_total();
        }
        private void cancel_selected_rows()
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                if (dr.Cells["calkot_print"].Value.ToString() == "K1")
                {
                    kot_cancel_printer_1 = true;
                }
                if (dr.Cells["calkot_print"].Value.ToString() == "K2")
                {
                    kot_cancel_printer_2 = true;
                }
                if (dr.Cells["calkot_print"].Value.ToString() == "B1")
                {
                    kot_cancel_printer_3 = true;
                }
                if (dr.Cells["calkot_print"].Value.ToString() == "B2")
                {
                    kot_cancel_printer_4 = true;
                }
                if (dr.Cells["calkot_print"].Value.ToString() == "K3")
                {
                    kot_cancel_printer_5 = true;
                }
            }
            cancel_selected = true;

            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                string item_name = dr.Cells["cal_item_name"].Value.ToString();

                decimal quantity = Convert.ToDecimal(datagridview_qty[dataGridView1.SelectedRows[0].Index]) - Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                string category_name = dr.Cells["cal_category_name"].Value.ToString();
                string kot_print = dr.Cells["calkot_print"].Value.ToString();
                DateTime todaydate = DateTime.Now;
                string time = DateTime.Now.ToShortTimeString();
                decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();

                int j = bllkot.cancel_update(Convert.ToInt32(dr.Cells["cal_order_id"].Value), "cancel");
                if (Convert.ToDecimal(lbltable_real_no.Text) < 520)
                {
                    if (Convert.ToDecimal(lbltable_real_no.Text) < 99)
                    {
                        int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TS");
                    }
                    else
                    {
                        int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "RS");
                    }
                }
                else if (Convert.ToDecimal(lbltable_real_no.Text) > 1000)
                {
                    int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TA");

                }
                if (minus_click == false)
                {
                    print_cancel();
                    int i = blord.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
                    dataGridView1.Rows.Remove(dr);
                }

            }

            calculate_total();
        }
        bool cancel_all = false;
        bool cancel_selected = false;
        bool cancel_minus = false;
        BLLDynamic bldd = new BLLDynamic();
        private void btnaadd_Click_1(object sender, EventArgs e)
        {

            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["itemcancel"].ToString() == "True")
                    {
                        if (cancelCheckAccess == true)
                        {
                            AdminAccess acc = new AdminAccess();
                            acc.ShowDialog();
                            user_access_check = AdminAccess.discount_access_value;
                        }
                        else
                        {
                            user_access_check = true;
                        }
                        if (user_access_check == true)
                        {
                            if (user_access_check == true)
                            {
                                if (dataGridView1.Rows.Count > 0)
                                {
                                    //DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                                    if (button_addwasclick == true)
                                    {
                                        if (lbltable_real_no.Text.Length > 0)
                                        {
                                            Cancel_emo canemo = new Cancel_emo();
                                            canemo.ShowDialog();
                                            emo_desc = Cancel_emo.emo_text;
                                            if (canemo.DialogResult != DialogResult.Cancel)
                                            {
                                                foreach (DataGridViewRow dr in dataGridView1.Rows)
                                                {
                                                    if (dr.Cells["calkot_print"].Value.ToString() == "K1")
                                                    {
                                                        kot_cancel_printer_1 = true;
                                                    }
                                                    else if (dr.Cells["calkot_print"].Value.ToString() == "K2")
                                                    {
                                                        kot_cancel_printer_2 = true;
                                                    }
                                                    else if (dr.Cells["calkot_print"].Value.ToString() == "B1")
                                                    {
                                                        kot_cancel_printer_3 = true;
                                                    }
                                                    else if (dr.Cells["calkot_print"].Value.ToString() == "B2")
                                                    {
                                                        kot_cancel_printer_4 = true;
                                                    }
                                                    else if (dr.Cells["calkot_print"].Value.ToString() == "K3")
                                                    {
                                                        kot_cancel_printer_5 = true;
                                                    }
                                                }
                                                cancel_all = true;
                                                print_cancel();
                                                KotCancelPrinterStatus();
                                                int i = blord.deletefromtable(Convert.ToDecimal(lbltable_real_no.Text));
                                                int deleteAdvanceDiscount = bld.DeleteAdvanceDiscount(lbltable_real_no.Text);
                                                int deleteQuotation = blpst.DeleteQuotation(lbltable_real_no.Text);
                                                if (gettableName == "TA")
                                                {
                                                    int twk = bltak.deletefromTake_away(Convert.ToInt32(lbltable_real_no.Text));
                                                }
                                                foreach (DataGridViewRow dr in dataGridView1.Rows)
                                                {
                                                    string item_name = dr.Cells["cal_item_name"].Value.ToString();
                                                    decimal quantity = Convert.ToDecimal(dr.Cells["cal_qty"].Value.ToString());
                                                    decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                                                    decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                                                    string category_name = dr.Cells["cal_category_name"].Value.ToString();
                                                    string kot_print = dr.Cells["calkot_print"].Value.ToString();
                                                    DateTime todaydate = DateTime.Now;
                                                    string time = DateTime.Now.ToShortTimeString();
                                                    decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                                                    grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();
                                                    if (Convert.ToDecimal(lbltable_real_no.Text) < 520)
                                                    {
                                                        if (Convert.ToDecimal(lbltable_real_no.Text) < 99)
                                                        {
                                                            int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TS");
                                                        }
                                                        else
                                                        {
                                                            int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "RS");
                                                        }
                                                    }
                                                    else if (Convert.ToDecimal(lbltable_real_no.Text) > 1000)
                                                    {
                                                        int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, active, category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TA");

                                                    }

                                                }
                                                dataGridView1.Rows.Clear();
                                                datagridviewload();
                                            }
                                        }

                                    }
                                    else
                                    {

                                        // decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                                        grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value)).ToString();
                                        dataGridView1.Rows.Clear();
                                        datagridviewload();

                                    }
                                    clear();
                                }
                                button_addwasclick = false;
                                cancel_all = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Cancel Access Alert !!", "Contact Your Admin Alert !!");
                    }
                }
            }
        }


        bool kot_cancel_printer_1 = false;
        bool kot_cancel_printer_2 = false;
        bool kot_cancel_printer_3 = false;
        bool kot_cancel_printer_4 = false;
        bool kot_cancel_printer_5 = false;
        public void KotCancelPrinterStatus()
        {
            kot_cancel_printer_1 = false;
            kot_cancel_printer_2 = false;
            kot_cancel_printer_3 = false;
            kot_cancel_printer_4 = false;
            kot_cancel_printer_5 = false;
        }
        KotCancel80 kotc_80 = new KotCancel80();
        Kot_cancel_56 kotc_56 = new Kot_cancel_56();
        public void print_cancel()
        {
            DataTable dt_prt = blpt.getalldata();
            if (dt_prt.Rows[0]["kot_printer"].ToString() == "80")
            {
                if (kot_cancel_printer_1 == true)
                {
                    kotc_80.printer_name = "K1";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_1 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_2 == true)
                {
                    kotc_80.printer_name = "K2";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_2 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_3 == true)
                {
                    kotc_80.printer_name = "B1";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_3 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_4 == true)
                {
                    kotc_80.printer_name = "B2";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_4 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_5 == true)
                {
                    kotc_80.printer_name = "K3";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_5 = kotc_80.kot_printer_1;
                }
            }
            else
            {
                if (kot_cancel_printer_1 == true)
                {
                    kotc_56.printer_name = "K1";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_1 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_2 == true)
                {
                    kotc_56.printer_name = "K2";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_2 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_3 == true)
                {
                    kotc_56.printer_name = "B1";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_3 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_4 == true)
                {
                    kotc_56.printer_name = "B2";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_4 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_5 == true)
                {
                    kotc_56.printer_name = "K3";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_5 = kotc_56.kot_printer_1;
                }
            }
            cancel_all = false;
            cancel_selected = false;
            cancel_minus = false;
        }


        public void kot_printing_cancel_80()
        {
            kotc_80.table_no = lbltable_real_no.Text;
            kotc_80.table_displayNo = label_table_no.Text;
            kotc_80.table_name = lbl_table_name.Text;
            kotc_80.note_pad = txtrichbox.Text;
            kotc_80.cashier = Login.sendtext;
            if (cancel_all == true)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    kotc_80.datagridview_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                    kotc_80.datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
                    kotc_80.datagridview_kot_print.Add(dr.Cells["calkot_print"].Value.ToString());
                    kotc_80.datagridview_modifier.Add((dr.Cells["cal_description"].Value ?? string.Empty).ToString());
                }


            }
            else if (cancel_selected == true)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    kotc_80.datagridview_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                    kotc_80.datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
                    kotc_80.datagridview_kot_print.Add(dr.Cells["calkot_print"].Value.ToString());
                    kotc_80.datagridview_modifier.Add((dr.Cells["cal_description"].Value ?? string.Empty).ToString());
                }


            }
            else if (cancel_minus == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (datagridview_qty[i] != dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString())
                    {
                        kotc_80.datagridview_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                        kotc_80.datagridview_qty.Add((Convert.ToDecimal(datagridview_qty[i]) - Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value)).ToString());
                        kotc_80.datagridview_kot_print.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                        kotc_80.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                    }

                }


            }
        }

        public void kot_printing_cancel_56()
        {
            kotc_56.table_no = lbltable_real_no.Text;
            kotc_56.table_name = label_table_no.Text;
            kotc_56.note_pad = txtrichbox.Text;
            kotc_56.cashier = Login.sendtext;
            if (cancel_all == true)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    kotc_56.datagridview_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                    kotc_56.datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
                    kotc_56.datagridview_kot_print.Add(dr.Cells["calkot_print"].Value.ToString());
                    kotc_56.datagridview_modifier.Add((dr.Cells["cal_description"].Value ?? string.Empty).ToString());
                }
                cancel_all = false;

            }
            else if (cancel_selected == true)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    kotc_56.datagridview_name.Add(dr.Cells["cal_item_name"].Value.ToString());
                    kotc_56.datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
                    kotc_56.datagridview_kot_print.Add(dr.Cells["calkot_print"].Value.ToString());
                    kotc_56.datagridview_modifier.Add((dr.Cells["cal_description"].Value ?? string.Empty).ToString());
                }
                cancel_selected = false;

            }
            else if (cancel_minus == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (datagridview_qty[i] != dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString())
                    {
                        kotc_56.datagridview_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                        kotc_56.datagridview_qty.Add((Convert.ToDecimal(datagridview_qty[i]) - Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value)).ToString());
                        kotc_56.datagridview_kot_print.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                        kotc_56.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                    }
                }
                cancel_minus = false;

            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {

                Table_Management.Table_Billing vieret = new Table_Management.Table_Billing();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);
            }

            //allmenu vieret = new allmenu();
            //Control ctls = this.Parent;
            //ctls.Controls.Clear();
            //ctls.Controls.Add(vieret);
        }

        public List<string> datagridview_qty = new List<string>();


        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blord.getalldata(Convert.ToDecimal(lbltable_real_no.Text));
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    string xyz = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = xyz;

                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["calkot_print"].Value = dt.Rows[z]["kot_print"].ToString();
                    dataGridView1.Rows[z].Cells["cal_note"].Value = "";

                }
                calculate_total();
            }
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
            }
        }


        public Point _cellClick;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == dataGridView1.Columns["cal_qty"].Index && e.RowIndex >= 0)
            //    {
            //        rp = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            //        var h = dataGridView1.Rows[0].Height;
            //        if (MousePosition.Y % h == 0)
            //        {
            //            _cellClick = new Point(MousePosition.X, MousePosition.Y);
            //        }
            //        else
            //        {
            //            var y = MousePosition.Y;
            //            do
            //            {
            //                y++;
            //            }
            //            while (y % h != 0);
            //            _cellClick = new Point(MousePosition.X, y);

            //        }
            //        if (!_cellClick.IsEmpty)
            //        {
            //            pnlnumpad.Location = System.Drawing.Point.Add(new Point(_cellClick.X - 80, _cellClick.Y - 40), new Size(0, 0));
            //        }
            //        if (e.ColumnIndex == dataGridView1.Columns["cal_qty"].Index && e.RowIndex >= 0)
            //        {
            //            pnlnumpad.Show();
            //        }
            //        dgv_leave = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
            txtrichbox.Text = dataGridView1.CurrentRow.Cells["cal_note"].Value.ToString();
        }
        //string tempQty = "1";

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            old = new DataGridViewRow[dataGridView1.SelectedRows.Count];
            dataGridView1.SelectedRows.CopyTo(old, 0);
            //if (e.ColumnIndex == dataGridView1.Columns["cal_qty"].Index && e.RowIndex > 0)
            //{
            //    tempQty = dataGridView1.Rows[e.RowIndex].Cells["cal_qty"].Value.ToString();

            //}

        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["cal_qty"].Index)
            {
                if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) > 0)
                {
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                        decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                        decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = (qty * cost);
                    }
                }
                else
                {
                    MessageBox.Show("Quantity Cannot be 0 or less that 0.", "Low Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        string emo_desc;
        bool user_access_check = false;
        private void Cancel_Click(object sender, EventArgs e)
        {

            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["itemcancel"].ToString() == "True")
                    {
                        if (cancelCheckAccess == true)
                        {
                            AdminAccess acc = new AdminAccess();
                            acc.ShowDialog();
                            user_access_check = AdminAccess.discount_access_value;
                        }
                        else
                        {
                            user_access_check = true;
                        }
                        if (user_access_check == true)
                        {
                            if (dataGridView1.Rows.Count > 0)
                            {
                                DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                                if (dt.Rows.Count > 0)
                                {

                                    Cancel_emo canemo = new Cancel_emo();
                                    canemo.ShowDialog();
                                    if (canemo.DialogResult != DialogResult.Cancel)
                                    {
                                        emo_desc = Cancel_emo.emo_text;
                                        if (minus_click == true)
                                        {
                                            for_minus_cancel();
                                            cancel_selected_rows();
                                            minus_click = false;
                                        }
                                        else
                                        {
                                            cancel_selected_rows();
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                                    {
                                        decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                                        grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();
                                        dataGridView1.Rows.Remove(dr);
                                        calculate_total();
                                        tax_calcu();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Cancel ALert !!", "No Access Alert !!");
                    }
                }
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
            }


        }

        private void btn_takeaway_Click(object sender, EventArgs e)
        {
            lbl_table_name.Text = "TA";
            sales_type = "TA";
            lbltable_name_hd.Text = "Take Away:";
            btn_dinning.Enabled = true;
            btn_takeaway.Enabled = false;
        }

        private void btn_dinning_Click(object sender, EventArgs e)
        {
            lbl_table_name.Text = "DA";
            sales_type = "DA";
            lbltable_name_hd.Text = "Dinning:";
            btn_takeaway.Enabled = true;
            btn_dinning.Enabled = false;
        }

        private void txtrichbox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.CurrentRow.Cells["cal_description"].Value = txtrichbox.Text;
            }
        }

        private void btn_item_transfer_Click(object sender, EventArgs e)
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["itemtransfer"].ToString() == "True")
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            ItemTransfer it = new ItemTransfer();
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells["cal_order_id"].Value != null)
                                {
                                    it.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                                    it.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                                    it.datagridview_order_id.Add(dataGridView1.Rows[i].Cells["cal_order_id"].Value.ToString());
                                    it.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                                    it.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                                    it.datagridview_category.Add(dataGridView1.Rows[i].Cells["cal_category_name"].Value.ToString());
                                    it.datagridview_kotType.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                                }
                            }
                            it.table_no = lbl_table_name.Text;
                            it.ShowDialog();
                            datagridviewload();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Item Transfer ALert !!", "No Access Alert !!");
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Cells["cal_qty"].Value != null && dataGridView1.CurrentRow.Cells["cal_qty"].Value.ToString() != "" && dataGridView1.CurrentRow.Cells["cal_cost"].Value != null && dataGridView1.CurrentRow.Cells["cal_cost"].Value.ToString() != "")
                {
                    if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) > 0)
                    {

                        decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                        decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = (qty * cost);
                        calculate_total();
                    }

                }

            }
        }
        int service_provider_id = 0;
        string service_provider_name = "";
        private void btn_service_provider_Click(object sender, EventArgs e)
        {

            ServiceProviderUser spu = new ServiceProviderUser();
            spu.ShowDialog();
            service_provider_id = ServiceProviderUser.id;
            service_provider_name = ServiceProviderUser.service_provider_name;
        }

        private void btn_category_grouping_Click(object sender, EventArgs e)
        {
            if (flwpln_categoryGrouping.Visible == false)
            {
                flwpln_categoryGrouping.Visible = true;
                CategoryGrouping();
            }
            else
            {
                flwpln_categoryGrouping.Visible = false;

            }

        }
        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
        public void CategoryGrouping()
        {
            DataTable dt = blcg.getallItemcategoryGrouping();
            flwpln_categoryGrouping.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] GroupCategory = new Button[99];
                GroupCategory[low] = new Button();
                GroupCategory[low].Name = dt.Rows[low]["id"].ToString();
                GroupCategory[low].Text = dt.Rows[low]["group_name"].ToString();
                GroupCategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(25, 20));
                GroupCategory[low].Height = 55;
                GroupCategory[low].Width = 80;
                GroupCategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                GroupCategory[low].FlatStyle = FlatStyle.Flat;
                GroupCategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //GroupCategory[low].BackColor = ColorTranslator.FromHtml("#33A6FF");

                GroupCategory[low].ForeColor = Color.White;

                string image_color = dt.Rows[low]["button_colour"].ToString();
                GroupCategory[low].BackColor = Color.FromName(image_color);
                GroupCategory[low].TextAlign = ContentAlignment.TopCenter;

                flwpln_categoryGrouping.Controls.Add(GroupCategory[low]);
                GroupCategory[low].Click += new EventHandler(GroupCategorys_Click);
                lblcateogry_item.Hide();
                //lblitem_id.Hide();
            }

        }
        private void GroupCategorys_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Name);
            if (id > 0)
            {
                lblcategory_name.Text = "Category";
                categorysub(pre_cat, next_panel, id);
                KOTOrder.Animate(flwpln_item, KOTOrder.Effect.Slide, 150, 180);
                flwpln_item.Controls.Clear();
                flwpln_item.Hide();
                flwpln_category.Show();
                txt_item_search.Text = "Search Item";
                txt_item_search.ForeColor = SystemColors.GrayText;

            }
        }
    }
}



