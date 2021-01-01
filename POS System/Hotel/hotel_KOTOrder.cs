using BLLS;
using BLLS.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class hotel_KOTOrder : UserControl
    {
        public hotel_KOTOrder(string roomNo,string hotelroom_id)
        {
            InitializeComponent();
            room_no = roomNo;
            room_id = hotelroom_id;
        }
        string room_id;
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
        BLL_hotel_order order = new BLL_hotel_order();
        BLLHotelRoom blroom = new BLLHotelRoom();
        int insert_order;
        //bool kot_after_billing = false;
        //String getCustomername = "";
        string getCustomerPhone = "";
        string room_no;
 
        private bool button_addwasclick = false;
        int pre_cat = 0;
        int next_panel = 25;
        bool back_click;
        int nxt = 0;
        int phg = 25;

        string category_name = "Null";
        private void hotel_KOTOrder_Load(object sender, EventArgs e)
        {
            lbltable_real_no.Text = room_id;
            lbltable_real_no.Hide();
            label_table_no.Text = room_no;
            lbl_table_name.Text = room_no;
            categorysub(pre_cat, next_panel);
            txtrichbox.Hide();
            flowLayoutPanel1.Hide();
            btnitem_next.Hide();
            btn_item_preview.Hide();
            btnpre.Hide();
            btnnext.Hide();
         
            datagridviewload();
            DataTable dt = blu.checkbusiness();
            if (dt.Rows[0]["language"].ToString() == "Arabic")
            {
                dataGridView1.Columns["cal_item_name"].DefaultCellStyle.Font = new Font("ArabicNaskhSSK", 9, FontStyle.Regular);
                dataGridView1.Columns["cal_item_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
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
        }
        public void categorysub(int cat_id_db, int cat_id_db2)
        {
            DataTable dt = blord.get_all_category_category_id(cat_id_db, cat_id_db2);
            flowLayoutPanel3.Controls.Clear();
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
                newPanelcategory[low].Font = new Font("Times New Roman", 10, FontStyle.Bold);
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

                //this.Controls.Add(newPanelcategory);
                DataTable dt_arabic = blu.checkbusiness();
                if (dt_arabic.Rows[0]["language"].ToString() == "Arabic")
                {
                    newPanelcategory[low].Font = new Font("ArabicNaskhSSK", 9, FontStyle.Regular);
                }

                flowLayoutPanel3.Controls.Add(newPanelcategory[low]);
                newPanelcategory[low].Click += new EventHandler(newPanelcategorys_Click);
                lblcateogry_item.Hide();
                //lblitem_id.Hide();
            }

        }
        public void newPanelcategorys_Click(object sender, EventArgs e)
        {
            try
            {
                category_name = ((Button)sender).Text;
                lblcateogry_item.Text = ((Button)sender).Name;
                flowLayoutPanel1.Controls.Clear();
                btnnext.Hide();
                btnpre.Hide();
                lblcategory_name.Text = "Items";
                KOTOrder.Animate(flowLayoutPanel1, KOTOrder.Effect.Roll, 150, 45);
                item_by_category_id(nxt, phg);
                DataTable dts = blmi.getcategoryDetailsByCategoryIds((Convert.ToInt32(lblcateogry_item.Text)));
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
        public void item_by_category_id(int item_id_db, int item_id2_db)
        {

            DataTable dts = blmi.getitembycategoryid_temp_view(Convert.ToInt32(Convert.ToInt32(lblcateogry_item.Text)), item_id_db, item_id2_db);
            flowLayoutPanel1.Controls.Clear();
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
                if (dt_arabic.Rows[0]["language"].ToString() == "Arabic")
                {
                    panelButtons.Font = new Font("ArabicNaskhSSK", 9, FontStyle.Regular);
                }
                else
                {
                    panelButtons.Font = new Font("Times New Roman", 8, FontStyle.Bold);
                }

                panelButtons.BringToFront();

                int item_id_select = Convert.ToInt32(dts.Rows[xIx]["item_id"].ToString());
                DataTable dt = blldays_wise.getdayswisedatabyItem_Id(item_id_select);


                string today = DateTime.Now.DayOfWeek.ToString();
                string applicable_days = dts.Rows[xIx]["applicable_time_period"].ToString();
                if (applicable_days == "Always")
                {

                    flowLayoutPanel1.Controls.Add(panelButtons);
                }
                else if (applicable_days == "Days of Week")
                {
                    for (int xy = 0; xy < dt.Rows.Count; xy++)
                    {
                        if (dt.Rows[xy]["days"].ToString() == today)
                        {
                            flowLayoutPanel1.Controls.Add(panelButtons);
                        }
                    }

                }

                panelButtons.Click += new EventHandler(panelButtons_Click);

                back_click = true;
            }
        }
        int i = 0;
        string item_id;
        string modifier_text;

        public void panelButtons_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = 1;
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
                                int quantitys = Convert.ToInt32(row.Cells["cal_qty"].Value ?? String.Empty);
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


        private void btn_kot_save_Click(object sender, EventArgs e)
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {
                if (!decimal.TryParse(lbltable_real_no.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No");
                }
                else
                {
                    for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                        string item_name = dataGridView1.Rows[ib].Cells["cal_item_name"].Value.ToString();
                        int quantity = Convert.ToInt32(dataGridView1.Rows[ib].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_total"].Value.ToString());
                        string category_name = dataGridView1.Rows[ib].Cells["cal_category_name"].Value.ToString();
                        string kot_print = dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString();
                        DateTime todaydate = DateTime.Now;
                        if (dataGridView1.Rows[ib].Cells["cal_order_id"].Value == null)
                        {
                            DataTable dtm = blroom.GetDates(Convert.ToInt32(room_id));
                            if (dtm.Rows.Count > 0)
                            {
                                int customer_id = Convert.ToInt32(dtm.Rows[0]["customer_id"].ToString());
                                insert_order = order.Insert_Hotel_Order(Login.sendtext, lbltable_real_no.Text, item_name, quantity, total, cost, sales_type,category_name, kot_print, sales_type, customer_id, todaydate);
                            }

                        }
                    }
                        if (insert_order > 0)
                        {

                        datagridviewload();
                        button_addwasclick = true;
                        insert_order = 0;
                        }
                    }
                   
                }
            }


        //int order_id;
        //public void order_id_sender()
        //{
        //    DataTable dt = order.getalldata_order();
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0][0].ToString() == "")
        //        {
        //            order_id = 1;
        //        }
        //        else
        //        {
        //            int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
        //            order_id = getinvoiceno;
        //        }
        //    }
        //}
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
                if (kot_printer_4 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "B2";
                            kot_printing_80();
                            kot80.printkot();
                            kot_printer_3 = kot80.kot_printer_1;

                        }
                    }
                }
                if (kot_printer_5 == true)
                {
                    if (dtp.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["BOT"]); i++)
                        {
                            kot80.printerName = "K3";
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
                        for (int i = 0; i < Convert.ToInt32(dtp.Rows[0]["K2"]); i++)
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
        KOTPrinting56 kot = new KOTPrinting56();

        public void kot_printing_56_2()
        {
            kot.table_no = lbltable_real_no.Text;
            kot.table_name = label_table_no.Text;
            kot.note_pad = txtrichbox.Text;
            kot.cashier = Login.sendtext;
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
        //int kot_display_id;
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
       // decimal service_charge = 0;
      
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
        public void tax_calcu()
        {
            if (grandtotal != "")
            {
                TaxCalculation tax = new TaxCalculation();

                tax_amount = tax.tax_calculation(Convert.ToDecimal(grandtotal));
                static_grand_total = Convert.ToDecimal(grandtotal) + tax_amount;
                lbl_total.Text = static_grand_total.ToString("#.##");

            }
        }
        public List<string> datagridview_qty = new List<string>();
      
        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = order.getalldata(lbltable_real_no.Text);
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["hotel_order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["calkot_print"].Value = dt.Rows[z]["kot_print"].ToString();

                }
                calculate_total();
            }
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
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

        bool kot_printer_1 = false;
        bool kot_printer_2 = false;
        bool kot_printer_3 = false;
        bool kot_printer_4 = false;
        bool kot_printer_5 = false;
        BLLReserved blres = new BLLReserved();
        int insert_order_print;
        string sales_type = "HR";
        string grandtotal;
  

        private void btn_kot_Click(object sender, EventArgs e)
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {
                if (!decimal.TryParse(lbltable_real_no.Text, out parsdec))
                {
                    MessageBox.Show("Input Error In Table No");
                }
                else
                {
                  
                    for (int ib = 0; ib < dataGridView1.Rows.Count; ib++)
                    {
                        //order_id_sender();
                        string item_name = dataGridView1.Rows[ib].Cells["cal_item_name"].Value.ToString();
                        int quantity = Convert.ToInt32(dataGridView1.Rows[ib].Cells["cal_qty"].Value.ToString());
                        decimal cost = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_cost"].Value.ToString());
                        decimal total = Convert.ToDecimal(dataGridView1.Rows[ib].Cells["cal_total"].Value.ToString());
                        string category_name = dataGridView1.Rows[ib].Cells["cal_category_name"].Value.ToString();
                        string kot_print = dataGridView1.Rows[ib].Cells["calkot_print"].Value.ToString();
                        DateTime todaydate = DateTime.Now;
                        string time = DateTime.Now.ToShortTimeString();
                        if (dataGridView1.Rows[ib].Cells["cal_order_id"].Value == null)
                        {
                            DataTable dtm = blroom.GetDates(Convert.ToInt32(room_id));
                            if (dtm.Rows.Count > 0)
                            {
                                int customer_id = Convert.ToInt32(dtm.Rows[0]["customer_id"].ToString());
                                insert_order_print = order.Insert_Hotel_Order(Login.sendtext, lbltable_real_no.Text, item_name, quantity, total, cost, sales_type, category_name, kot_print, sales_type, customer_id, todaydate);

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


                    }
                    if (insert_order_print > 0)
                    {
                        
                        kot_printChecker();
                        datagridviewload();                       
                        button_addwasclick = true;
                       
                        user_log_insert();
                    }
                    else
                    {
                        MessageBox.Show("Cannot Order Your Item Please Do It Again", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_x_check_out_Click(object sender, EventArgs e)
        {
          
                    Control ctls = this.Parent;
                    HotelBilling blb = new HotelBilling(room_no,room_id);
                    //HotelBilling blb = new HotelBilling(lbltable_real_no.Text, label_table_no.Text);// for reference
                    ctls.Controls.Clear();
                    ctls.Controls.Add(blb);
          
        }
        bool minus_click = false;
        private void btn_minus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {

                    dataGridView1.CurrentRow.Cells["cal_qty"].Value = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1);
                    decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                    int quantitys = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                    decimal total = quantitys * cost;
                    dataGridView1.CurrentRow.Cells["cal_total"].Value = total;
                    calculate_total();
                    tax_calcu();
                    DataTable dt = order.GetOrders(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                    if (dt.Rows.Count > 0)
                    {
                        minus_click = true;
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

        private void btn_x_note_Click(object sender, EventArgs e)
        {
           
                KOTOrder.Animate(txtrichbox, KOTOrder.Effect.Slide, 150, 180);
            

        }

      
        private void btnnext_Click(object sender, EventArgs e)
        {
            next_panel = next_panel + 25;
            pre_cat = pre_cat + 25;
            DataTable dtcheck = blord.getallcategory();
            if (pre_cat <= dtcheck.Rows.Count)
            {
                categorysub(pre_cat, next_panel);
                btnpre.Show();

            }
            if (next_panel >= dtcheck.Rows.Count)
            {
                btnnext.Hide();
            }
        }

        private void btnitem_next_Click(object sender, EventArgs e)
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

        private void btn_item_preview_Click(object sender, EventArgs e)
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

        private void btnpre_Click(object sender, EventArgs e)
        {
            next_panel = next_panel - 25;
            pre_cat = pre_cat - 25;
            if (next_panel >= 0)
            {
                categorysub(pre_cat, next_panel);
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
        bool flag_visiable = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (back_click == true)
            {
                lblcategory_name.Text = "Category";
                categorysub(pre_cat, next_panel);
                KOTOrder.Animate(flowLayoutPanel1, KOTOrder.Effect.Slide, 150, 180);
                flowLayoutPanel1.Hide();
                flowLayoutPanel3.Show();
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
        string emo_desc;
        bool cancel_minus;
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataTable dt = order.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
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
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        private void for_minus_cancel()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //    if (datagridview_qty[i] != dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString())
                //    {
                //        if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K1")
                //        {
                //            kot_cancel_printer_1 = true;
                //        }
                //        else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K2")
                //        {
                //            kot_cancel_printer_2 = true;
                //        }
                //        else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B1")
                //        {
                //            kot_cancel_printer_3 = true;
                //        }
                int uup = order.updateorderstable(Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_qty"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_order_id"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value));
            }
            //}
            cancel_minus = true;
           // print_cancel();
            calculate_total();
        }
        bool cancel_selected;
        bool kot_cancel_printer_1 = false;
        bool kot_cancel_printer_2 = false;
        bool kot_cancel_printer_3 = false;
        bool kot_cancel_printer_4 = false;
        bool kot_cancel_printer_5 = false;
        KotCancel80 kotc_80 = new KotCancel80();
        Kot_cancel_56 kotc_56 = new Kot_cancel_56();
        private void cancel_selected_rows()
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                if (dr.Cells["calkot_print"].Value.ToString() == "K1")
                {
                    kot_cancel_printer_1 = true;
                }
                else if (dr.Cells["calkot_print"].Value.ToString() == "K2")
                {
                    kot_cancel_printer_2 = true;
                }
                else if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B1")
                {
                    kot_cancel_printer_3 = true;
                }
            }
            cancel_selected = true;
            print_cancel();
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                string item_name = dr.Cells["cal_item_name"].Value.ToString();
                int quantity = Convert.ToInt32(dr.Cells["cal_qty"].Value.ToString());
                decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                string category_name = dr.Cells["cal_category_name"].Value.ToString();
                string kot_print = dr.Cells["calkot_print"].Value.ToString();
                DateTime todaydate = DateTime.Now;
                string time = DateTime.Now.ToShortTimeString();
                decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();
                int i = order.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
               //int j = bllkot.cancel_update(Convert.ToInt32(dr.Cells["cal_order_id"].Value), "cancel");
                int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, "active", category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "HS");
                  
                dataGridView1.Rows.Remove(dr);
            }

            calculate_total();
        }
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
                    kot_cancel_printer_3 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_5 == true)
                {
                    kotc_80.printer_name = "K3";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_3 = kotc_80.kot_printer_1;
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
                    kot_cancel_printer_2 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_5 == true)
                {
                    kotc_56.printer_name = "K3";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_3 = kotc_56.kot_printer_1;
                }
            }
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
                cancel_all = false;
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
                cancel_selected = false;
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
            }
        }
        bool cancel_all;
        private void btn_x_cancel_all_Click(object sender, EventArgs e)
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
                            }
                            cancel_all = true;
                            print_cancel();
                            int i = order.deletefromtable((lbltable_real_no.Text));

                            foreach (DataGridViewRow dr in dataGridView1.Rows)
                            {
                                string item_name = dr.Cells["cal_item_name"].Value.ToString();
                                int quantity = Convert.ToInt32(dr.Cells["cal_qty"].Value.ToString());
                                decimal cost = Convert.ToDecimal(dr.Cells["cal_cost"].Value.ToString());
                                decimal total = Convert.ToDecimal(dr.Cells["cal_total"].Value.ToString());
                                string category_name = dr.Cells["cal_category_name"].Value.ToString();
                                string kot_print = dr.Cells["calkot_print"].Value.ToString();
                                DateTime todaydate = DateTime.Now;
                                string time = DateTime.Now.ToShortTimeString();
                                decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                                grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value)).ToString();
                                int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltable_real_no.Text), item_name, quantity, total, cost, "active", category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "HS");
                                
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
                //clear();
                //  }
                //button_addwasclick = false;
                cancel_all = false;
            }
        }
        private void txt_item_search_TextChanged(object sender, EventArgs e)
        {
            search_item_by_item_name();
        }
        public void search_item_by_item_name()
        {
            if (txt_item_search.Text != "" && txt_item_search.Text != "Search Item" && txt_item_search.TextLength > 3)
            {
                DataTable dts = blmi.getproductbyproductname(txt_item_search.Text);
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Show();
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
                    flowLayoutPanel1.Controls.Add(panelButtons);
                    panelButtons.BringToFront();
                    panelButtons.Click += new EventHandler(panelButtons_Click);
                    back_click = true;
                }
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
        private void txt_item_search_Leave(object sender, EventArgs e)
        {
            if (txt_item_search.Text.Length == 0)
            {
                txt_item_search.Text = "Search Item";
                txt_item_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //Hotel.Hotel rp = new Hotel.Hotel();
            //panel1.Controls.Clear();
            //panel1.Controls.Add(rp);
            Hotel.Hotel al = new Hotel.Hotel();
            Control ctls = this.Parent;
            ctls.Controls.Clear();
            ctls.Controls.Add(al);

        }
    }
}
