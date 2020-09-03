using BLLS;
using BLLS.bakery;
using POS_System.Bakery;
using POS_System.Customer_Management;
using POS_System.Table_Management;
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
    public partial class BakeryKOTOrder : UserControl
    {
        public BakeryKOTOrder(string table_no, string table_type)
        {

            Kot_id = table_no;
            service_type = table_type;
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
        
        string Kot_id;
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
        BllBakeryOrder blbo = new BllBakeryOrder();
             

        // DateTime datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());

      
        private bool button_addwasclick = false;
        string category_name = "Null";   
        private delegate void CloseDelegate();
        public bool dgv_leave;
        string service_type;
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
        int customer_id=0;
        string customer_name;
        bool back_click;
        int nxt = 0;
        int phg = 25;

        int next_panel = 25;
        int pre_cat = 0;
        string fiscal_year = "0";
     
        string ProviderName;
        string KOTRename;
     
        bool KotEnableDisable;
        bool KotSaveEnableDisable;
        private void KOTOrder_Load(object sender, EventArgs e)
        {
         
            ProviderName = second_user_interface.ProviderName;
            KOTRename = second_user_interface.KOTRename;
            KotEnableDisable = cd.KotEnableDisable();
            KotSaveEnableDisable = cd.KotSaveEnableDisable();
         
            cbo_qty.SelectedIndex = 0;
         
            if (KotEnableDisable == true)
            {
                btn_x_kot.Visible = true;
            }
            else
            {
            
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
            label_table_no.Text = Kot_id;
            lbl_total.Text = service_type;

            categorysub(pre_cat, next_panel, 0);
        
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
               spds.CustomerDisplayVFD(lbl_total.Text, 0x32);

            }
        }

        public void clear()
        {
            grandtotal = "0.00";
        }

    
    
    
     
        int insert_order_print;
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        private void btnkot_Click(object sender, EventArgs e)
        {
            OrderDetailsForm ocd = new OrderDetailsForm(Convert.ToInt32(Kot_id), service_type);
            ocd.ShowDialog();
            if (ocd.DialogResult == DialogResult.OK)
            {
                kot_printing_80();
                
                kot80.printkot();

            }


            //  kot_display();
            for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                      
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
                            insert_order_print = blbo.insertBakeryorder_using_sp(Login.sendtext,item_name, quantity, total, cost,  category_name, kot_print, customer_id, service_provider_name.ToString(), Convert.ToInt32(Kot_id));

                           
                        }
                    }
                    if (insert_order_print > 0)
                    {
                         kot_printing_80();
                kot80.printkot();
                datagridviewload();
                        
                        button_addwasclick = true;
                      
                    }
                    else
                    {
                        MessageBox.Show("Cannot Order Your Item Please Do It Again", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
            
        }

     

     

        KOTPrinting56 kot = new KOTPrinting56();

        public void kot_printing_56_2()
        {
            kot.table_no = Kot_id;
            kot.table_display_no = label_table_no.Text;
            kot.table_name = lbl_total.Text;
         
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
        BakeryKOTPrinting80 kot80 = new BakeryKOTPrinting80();
        public void kot_printing_80()
        {
            kot80.kot_id =Kot_id;
            kot80.service_type = service_type;
            kot80.printerName = "K1";
            kot80.service_provider_name = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
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
       
        private void btn_kot_withoutPrint_Click_1(object sender, EventArgs e)
        {
            OrderDetailsForm ocd = new OrderDetailsForm(Convert.ToInt32(Kot_id),service_type);
            ocd.ShowDialog();
            if (ocd.DialogResult == DialogResult.OK)
            {
                kot_printing_80();
                kot80.printkot();

            }
            
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
                        insert_order = blbo.insertBakeryorder_using_sp(Login.sendtext, item_name, quantity, total, cost, category_name, kot_print, customer_id, service_type, Convert.ToInt32(Kot_id));
                    }

                }
                if (insert_order > 0)
                {
                    datagridviewload();
                    button_addwasclick = true;
                }
                else
                {
                    MessageBox.Show("Cannot Order Your Item Please Do It Again", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          
                Control ctls = this.Parent;
                Billing blb = new Billing(Kot_id, service_type);
                ctls.Controls.Clear();
                ctls.Controls.Add(blb);
            
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
                        DataTable dt = blbo.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
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
                    
                    int uup = blbo.updateorderstable(Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_order_id"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value));
                }
            }
            cancel_minus = true;
         
            calculate_total();
        }
        private void cancel_selected_rows()
        {
          
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
       
                int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(Kot_id), item_name, quantity, total, cost, "yes", category_name, kot_print, customer_id.ToString(), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, service_type);              
                if (minus_click == false)
                {
                 
                    int i = blbo.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
                    dataGridView1.Rows.Remove(dr);
                }

            }

            calculate_total();
        }
        bool cancel_all = false;
        bool cancel_selected = false;
        bool cancel_minus = false;
        BLLDynamic bldd = new BLLDynamic();
        private void btn_x_cancel_all_Click(object sender, EventArgs e)
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
                                          Cancel_emo canemo = new Cancel_emo();
                                            canemo.ShowDialog();
                                            emo_desc = Cancel_emo.emo_text;
                                            if (canemo.DialogResult != DialogResult.Cancel)
                                            {
                                                cancel_all = true;
                                            int i = blbo.deletefromBakeryOrder(Kot_id,service_type);
                                            int j = blbo.deletefromBakeryOrderDetails(Kot_id, service_type);
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
                                              
                                                     int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(Kot_id), item_name, quantity, total, cost, "Yes", category_name, kot_print, customer_id.ToString(), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, service_type);

                                                

                                                }
                                                dataGridView1.Rows.Clear();
                                                datagridviewload();
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


      
        KotCancel80 kotc_80 = new KotCancel80();
        Kot_cancel_56 kotc_56 = new Kot_cancel_56();
    


        public void kot_printing_cancel_80()
        {
            kotc_80.table_no = Kot_id;
            kotc_80.table_displayNo = label_table_no.Text;
            kotc_80.table_name = lbl_total.Text;
       
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

    
        private void pictureBox5_Click(object sender, EventArgs e)
        {


            BakeryTable_Billing vieret = new BakeryTable_Billing(service_type);
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);
            

        }

        public List<string> datagridview_qty = new List<string>();

        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blbo.getallKOTdata(Kot_id,service_type);
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
                    customer_id = Convert.ToInt32(dt.Rows[z]["customer_id"]);
                }
                if (dt.Rows[0]["name"].ToString() + dt.Rows[0]["lastname"].ToString() != "")
                {
                    lbl_customer_name.Text = dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
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
                                DataTable dt = blbo.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
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
        private void btn_Customer_Click(object sender, EventArgs e)
        {

            CustomerChoose spu = new CustomerChoose();
            spu.ShowDialog();
            if (spu.DialogResult == DialogResult.OK)
            {
                customer_id = Convert.ToInt32(spu.customer_id);
                customer_name =spu.customer_name;
                lbl_customer_name.Text = customer_name;
            }
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
        private void btn_add_menu_Click(object sender, EventArgs e)
        {
            bool Found = false;
            if (dataGridView1.Rows.Count > 0 && txt_menu_text.Text!="")
            {

                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["cal_item_name"].Value.ToString() == txt_menu_text.Text && row.Cells["cal_order_id"].Value == null)
                    {

                        if (Convert.ToString(row.Cells["cal_item_name"].Value) == txt_menu_text.Text)
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
                        dataGridView1.Rows[isi].Cells["cal_item_name"].Value = txt_menu_text.Text;
                        dataGridView1.Rows[isi].Cells["cal_qty"].Value = cbo_qty.Text;
                        dataGridView1.Rows[isi].Cells["cal_cost"].Value = txt_cost_price.Text;
                        decimal total = Convert.ToDecimal(cbo_qty.Text) * Convert.ToDecimal(txt_cost_price.Text);
                        dataGridView1.Rows[isi].Cells["cal_category_name"].Value = "Design";
                        dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                        dataGridView1.Rows[isi].Cells["calkot_print"].Value = "K1";
                        dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                        dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                        dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;


                    }
                    else
                    {
                        //Add the row to grid view
                        int isi = dataGridView1.Rows.Add();
                        dataGridView1.Rows[isi].Cells["cal_item_name"].Value = txt_menu_text.Text;
                        dataGridView1.Rows[isi].Cells["cal_qty"].Value = cbo_qty.Text;
                        dataGridView1.Rows[isi].Cells["cal_cost"].Value = txt_cost_price.Text;
                        decimal total = Convert.ToDecimal(cbo_qty.Text) * Convert.ToDecimal(txt_cost_price.Text);
                        dataGridView1.Rows[isi].Cells["cal_category_name"].Value = "Design";
                        dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                        dataGridView1.Rows[isi].Cells["calkot_print"].Value = "K1";
                        dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                        dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                        dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;
                       
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
                    dataGridView1.Rows[isi].Cells["cal_item_name"].Value = txt_menu_text.Text;
                    dataGridView1.Rows[isi].Cells["cal_qty"].Value = cbo_qty.Text;
                    dataGridView1.Rows[isi].Cells["cal_cost"].Value = txt_cost_price.Text;
                    decimal total = Convert.ToDecimal(cbo_qty.Text) * Convert.ToDecimal(txt_cost_price.Text);
                    dataGridView1.Rows[isi].Cells["cal_category_name"].Value = "Design";
                    dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                    dataGridView1.Rows[isi].Cells["calkot_print"].Value = "K1";
                    dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                    dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                    dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;


                }
                else
                {
                    //Add the row to grid view for the first time
                    int isi = dataGridView1.Rows.Add();
                    dataGridView1.Rows[isi].Cells["cal_item_name"].Value = txt_menu_text.Text;
                    dataGridView1.Rows[isi].Cells["cal_qty"].Value = cbo_qty.Text;
                    dataGridView1.Rows[isi].Cells["cal_cost"].Value = txt_cost_price.Text;
                    decimal total = Convert.ToDecimal(cbo_qty.Text) * Convert.ToDecimal(txt_cost_price.Text);
                    dataGridView1.Rows[isi].Cells["cal_category_name"].Value = "Design";
                    dataGridView1.Rows[isi].Cells["cal_total"].Value = total;
                    dataGridView1.Rows[isi].Cells["calkot_print"].Value = "K1";
                    dataGridView1.Rows[isi].Cells["cal_description"].Value = modifier_text;
                    dataGridView1.Rows[isi].Cells["cal_note"].Value = "";
                    dataGridView1.Rows[isi].DefaultCellStyle.BackColor = Color.DarkGray;
                   
                }


            }

            calculate_total();
            txt_menu_text.Text = "";
            cbo_qty.SelectedIndex = 0;
            txt_cost_price.Text = "0.00";
        }

        private void txt_cost_price_Enter(object sender, EventArgs e)
        {

            if (txt_cost_price.Text == "0.00")
            {
                txt_cost_price.Text = "";
            }
        }

        private void txt_cost_price_Leave(object sender, EventArgs e)
        {
            if (txt_cost_price.Text == "")
            {
                txt_cost_price.Text = "0.00";
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_cost_price_KeyPress(object sender, KeyPressEventArgs e)
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



