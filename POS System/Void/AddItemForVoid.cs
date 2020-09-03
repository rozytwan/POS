using BLLS;
using POS_System.Customer_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Void
{
    public partial class AddItemForVoid : Form
    {
        public AddItemForVoid(string status)
        {
            orderstatus = status;
            InitializeComponent();
        }
        BLLCategory bllcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blord = new BLLOrder();
        BLLMenuItem blmi = new BLLMenuItem();
        BLLSystemDyanmic blsd = new BLLSystemDyanmic();
        BLLdays_wise blldays_wise = new BLLdays_wise();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        BLLPrinterSetting blpt = new BLLPrinterSetting();
        int nxt = 0;
        int phg = 25;
        int next_panel = 25;
        int pre_cat = 0;
        string fiscal_year = "0";
        string category_name = "Null";
        bool back_click;
        string category_item_id;

        private void AddItemForVoid_Load(object sender, EventArgs e)
        {
            //fiscal year
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            dyanmicCodeChecker();
            categorysub(pre_cat, next_panel, 0);
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
                newPanelcategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + low * 55), new Size(50, 50));
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
            try
            {
                category_name = ((Button)sender).Text;
                category_item_id = ((Button)sender).Name;
                flwpln_item.Controls.Clear();
                btnnext.Hide();
                btnpre.Hide();
                lblcategory_name.Text = "Items";
                AddItemForVoid.Animate(flwpln_category, AddItemForVoid.Effect.Roll, 150, 45);
                item_by_category_id(nxt, phg);
                DataTable dts = blmi.getcategoryDetailsByCategoryIds((Convert.ToInt32(category_item_id)));
                if (dts.Rows.Count > 25)
                {
                    btnitem_next.Show();
                }
                back_click = true;

            }
            catch (Exception ex)
            {
                throw ex;
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
        bool salesItemTop = false;
        public void dyanmicCodeChecker()
        {
           
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
        public void item_by_category_id(int item_id_db, int item_id2_db)
        {
            DataTable dts = new DataTable();
            if (salesItemTop == true)
            {
                dts = blmi.getitembycategoryid_temp_viewOrderBySalesQty(Convert.ToInt32(category_item_id), item_id_db, item_id2_db, fiscal_year);
            }
            else
            {
                dts = blmi.getitembycategoryid_temp_view(Convert.ToInt32(category_item_id), item_id_db, item_id2_db);
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
        string item_id;
        string modifier_text;
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

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddItemForVoid.Animate(flwpln_category, AddItemForVoid.Effect.Roll, 150, 45);
            categorysub(pre_cat, next_panel, 0);
        }
        string home_delivery_id = home.home_delivery_id;
        string orderstatus=home.orderstatus;
        string service_provider_name = "";
        BLLhome_delivery blhd = new BLLhome_delivery();
        blllCustomerDetailednyo blcdn = new blllCustomerDetailednyo();
        int kot_id;
        bool kot_printer_1 = false;
        bool kot_printer_2 = false;
        bool kot_printer_3 = false;
      //  bool kot_printer_4 = false;
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
        HomeDeliveryModel hdm = new HomeDeliveryModel();
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                clearModel();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    VoidModel.item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    VoidModel.qty.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    VoidModel.total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    VoidModel.cost.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    VoidModel.category_name.Add(dataGridView1.Rows[i].Cells["cal_category_name"].Value.ToString());
                    VoidModel.kot_type.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                   if (orderstatus=="HD")
                    {
                        if (dataGridView1.Rows[i].Cells["cal_order_id"].Value == null)
                        {
                           
                            int insert_order = blord.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(home_delivery_id), VoidModel.item_name[i], Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_cost"].Value), "HD", VoidModel.category_name[i], VoidModel.kot_type[i], "HD", service_provider_name.ToString(), kot_id);
                            if (insert_order > 0)
                            {
                                if (Convert.ToDecimal(home_delivery_id) >= 106)
                                {
                                    if (Convert.ToDecimal(home_delivery_id) < 1000)
                                    {
                                        int hd_no = blhd.inserthomedeleveryid(Convert.ToInt32(home_delivery_id));
                                        int customer_id = HomeDeliveryModel.customer_id;
                                        if (customer_id > 0)
                                        {
                                            int insertCustomerid = blcdn.insertHomeDeliveryCustomer(customer_id.ToString(), home_delivery_id);
                                        }
                                    }
                                }
                            }
                            if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K1")
                            {
                                kot_printer_1 = true;
                            }
                            if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K2")
                            {
                                kot_printer_2 = true;
                            }
                            if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B1")
                            {
                                kot_printer_3 = true;
                            }
                        }
                    }
               

                }
                if (orderstatus=="HD")
                {
                  
                    kot_printChecker();
                    // this.Close();
                    if (Application.OpenForms.OfType<home>().Count() == 1)
                        Application.OpenForms.OfType<home>().First().Close();
                    home h = new home(home_delivery_id);
                    h.ShowDialog();
                   
                }
                this.Hide();
            }
            else
            {
                clearModel();
                this.Hide();
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
         
            }
        }
        KOTPrinting56 kot = new KOTPrinting56();

        public void kot_printing_56_2()
        {
            kot.table_no =home_delivery_id;
            //kot.table_name = label_table_no.Text;
           // kot.note_pad = txtrichbox.Text;
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
            kot80.table_no = home_delivery_id;
            //kot80.table_displayNo = label_table_no.Text;
            //kot80.table_name = lbl_table_name.Text;
            //kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = service_provider_name;
            kot80.kot_id = kot_id.ToString();
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

        public void clearModel()
        {
            VoidModel.item_name.Clear();
            VoidModel.qty.Clear();
            VoidModel.total.Clear();
            VoidModel.cost.Clear();
            VoidModel.category_name.Clear();
            VoidModel.kot_type.Clear();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(dr);
                }
            }
        }
    }
}
