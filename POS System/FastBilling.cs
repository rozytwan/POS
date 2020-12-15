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
using System.Runtime.InteropServices;
using System.IO.Ports;
using DevComponents.DotNetBar;
using System.IO;
using NepaliDateConverter;
using POS_System.Printing_Billing;
using POS_System.IRT;

namespace POS_System
{
    public partial class FastBilling : UserControl
    {
        public FastBilling()
        {
            InitializeComponent();
            txtcardamount.Text = "0.00";
            this.txtcardamount.Leave += new System.EventHandler(this.txtcardamount_Leave);
            this.txtcardamount.Enter += new System.EventHandler(this.txtcardamount_Enter);
            txtcashamount.Text = "0.00";
            this.txtcashamount.Leave += new System.EventHandler(this.txtcashamount_Leave);
            this.txtcashamount.Enter += new System.EventHandler(this.txtcashamount_Enter);

         

            foreach (TextBox tb in panelEx2.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }
        BLLCategory bllcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blord = new BLLOrder();
        BLLUser blu = new BLLUser();
        BLLTable blta = new BLLTable();
        BLLRestSell blresll = new BLLRestSell();
        Button newPanelcategory = new Button();
        BLLKotDisplay bllkot = new BLLKotDisplay();
        BLLhome_delivery blhd = new BLLhome_delivery();
        BLLToken blt = new BLLToken();
        BLLTakeAway bltak = new BLLTakeAway();
        bll_orderCancel boc = new bll_orderCancel();
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        BLLMenuItem blmi = new BLLMenuItem();
        BLLdays_wise blldays_wise = new BLLdays_wise();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLSystemDyanmic blds = new BLLSystemDyanmic();
        DateTime datetime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        BLLPrinterSetting blpt = new BLLPrinterSetting();
        BLLKitchenOrderToken blkot = new BLLKitchenOrderToken();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting76 blp_76 = new BillPrinting76();
        PANBillPrinting80 pn80 = new PANBillPrinting80();
        BLLcustomer_credit blc_credit = new BLLcustomer_credit();
        BillPrinting blp = new BillPrinting();
        CouponPrint cp80 = new CouponPrint();
        AdvanceDiscount adss = new AdvanceDiscount();
        InternetConnection ic = new InternetConnection();
        BLLDynamic bld = new BLLDynamic();
        IRT.IRTAPI apir = new IRT.IRTAPI();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        TokenPrint tp = new TokenPrint();
        BLL_Login_logout bllgin = new BLL_Login_logout();

        private bool button_addwasclick = false;
        bool multi_billing_check = false;
        bool kot_printer_1 = false;
        bool kot_printer_2 = false;
        bool kot_printer_3 = false;
        bool kot_printer_4 = false;
        bool kot_printer_5 = false;

        string getCustomerPhone = "";
        bool user_access_check = false;
        string emo_desc;
        BLL_Fiscal blfsc = new BLL_Fiscal();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        int nxt = 0;
        int phg = 25;
        int next_panel = 25;
        int pre_cat = 0;
        string fiscal_year;
        string user_name;
        string ird_username;
        string ird_password;
        private void FastBilling_Load(object sender, EventArgs e)
        {
            DataTable dt1 = bllgin.GetIrdInfo();
            if (dt1.Rows.Count > 0)
            {
                ird_password = Encryption.StringEncryption.Decrypt(dt1.Rows[0]["password"].ToString(), "sblw-3hn8-sqoy19");
                ird_username = dt1.Rows[0]["username"].ToString();
            }
            //fiscal year
            dateConvertToNepali();
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            flw_panel.Controls.Clear();
            dyanmicCodeChecker();
            txtrichbox.Hide();
            ComplementryInvoiceNo();
             user_name = Login.sendtext;
            categorysub(0, 30, 0);
            bill();
            token_no();
            chkcash.Checked = true;
            button_addwasclick = true;
            CUstomer_name();
            CUstomer_number();
            datagridviewload();

        }
        decimal discountAmount;
        bool salesItemTop = false;
        public void dyanmicCodeChecker()
        {
            //DataTable dtd = blsd.getALLDynamicByCode("SM001");
            //if (dtd.Rows.Count > 0)
            //{
            //    string status = dtd.Rows[0]["Status"].ToString();
            //    if (status == "True")
            //    {
            //        btn_category_grouping.Visible = true;
            //    }
            //}
            DataTable dts = blds.getALLDynamicByCode("SM002");
            if (dts.Rows.Count > 0)
            {
                string status = dts.Rows[0]["Status"].ToString();
                if (status == "True")
                {
                    salesItemTop = true;
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
        public void tabletuch()
        {
            flowLayoutPanel2.Controls.Clear();
            DataTable dt = blt.get_all_data_token();
            //lbltable.Hide();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button[] newtable = new Button[99];
                newtable[i] = new Button();
                newtable[i].Name = dt.Rows[i]["token_no"].ToString();
                newtable[i].Text = "TN " + (dt.Rows[i]["token_no"]).ToString();
                newtable[i].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(50, 50));// here make use of your logic.
                newtable[i].Height = 40;
                newtable[i].Width = 50;
                newtable[i].FlatStyle = FlatStyle.Flat;
                newtable[i].Font = new Font("Times New Roman", 10, FontStyle.Bold);
                newtable[i].BackColor = Color.Chocolate;
                newtable[i].ForeColor = Color.White;
                newtable[i].Click += new EventHandler(newtable_Click);
                flw_panel.Controls.Add(newtable[i]);

            }
        }
        string token_noClick;

        private void newtable_Click(object sender, EventArgs e)
        {
            token_noClick = ((Button)sender).Name;
            lbltokenno.Text = token_noClick;
            datagridviewload();
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
        public void bill()
        {
            DataTable dt = blresll.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    txtnewbillno.Text = "100";
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
        public void token_no()
        {
            DataTable dt = blt.get_token_no();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    lbltokenno.Text = "1";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    lbltokenno.Text = getinvoiceno.ToString();
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
            flw_panel.Controls.Clear();
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

                flw_panel.Controls.Add(newPanelcategory[low]);
                newPanelcategory[low].Click += new EventHandler(newPanelcategorys_Click);
                // lblcateogry_item.Hide();
                //lblitem_id.Hide();
            }

        }

        private void btnnext_Click_1(object sender, EventArgs e)
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

       // string item_category_name;
        string category_name;
        string category_id;

        public void newPanelcategorys_Click(object sender, EventArgs e)
        {

            try
            {
                category_name = ((Button)sender).Text;
                category_id = ((Button)sender).Name;
                flw_panel.Controls.Clear();
                btnnext.Hide();
                btnpre.Hide();
                lblcategory_name.Text = "Items";
                // KOTOrder.Animate(flw_panel, KOTOrder.Effect.Roll, 150, 45);
                item_by_category_id(nxt, phg);
                DataTable dts = blmi.getcategoryDetailsByCategoryIds((Convert.ToInt32(category_id)));
                if (dts.Rows.Count > 25)
                {
                    btnitem_next.Show();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void item_by_category_id(int item_id_db, int item_id2_db)
        {
            DataTable dts = new DataTable();
            if (salesItemTop == true)
            {
                dts = blmi.getitembycategoryid_temp_viewOrderBySalesQty(Convert.ToInt32(category_id), item_id_db, item_id2_db, fiscal_year);
            }
            else
            {
                dts = blmi.getitembycategoryid_temp_view(Convert.ToInt32(category_id), item_id_db, item_id2_db);
            }
            flw_panel.Controls.Clear();
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

                    flw_panel.Controls.Add(panelButtons);
                }
                else if (applicable_days == "Days of Week")
                {
                    for (int xy = 0; xy < dt.Rows.Count; xy++)
                    {
                        if (dt.Rows[xy]["days"].ToString() == today)
                        {
                            flw_panel.Controls.Add(panelButtons);
                        }
                    }

                }

                panelButtons.Click += new EventHandler(panelButtons_Click);
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
        private void btnitem_next_Click(object sender, EventArgs e)
        {
            nxt = nxt + 25;
            phg = phg + 25;
            DataTable dtcheck = blord.get_item_by_category_id2(Convert.ToInt32(category_id));
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
       





        string item_id;
        public static string item_modifier_Item_id;
        string modifier_text;
        Item_modifier_list iml = new Item_modifier_list();
        //item button click
        public void panelButtons_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = 1;
                item_id = ((Button)sender).Name;
                iml.item_id = item_id;
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
        private void btn_kot_Click(object sender, EventArgs e)
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {

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
                        int insert_order_print = blkot.insertTokenorder_using_sp(Login.sendtext, lbltokenno.Text, item_name, quantity, total, cost, "TO", category_name, kot_print, "TO", "");

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
                button_addwasclick = true;
                int insertTOken = blkot.insert_into_token(lbltokenno.Text);
                kot_printChecker();
                datagridviewload();

            }
        }
        public List<string> datagridview_qty = new List<string>();
        public void datagridviewload()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = blkot.getalldata(lbltokenno.Text);
            if (dt.Rows.Count > 0)
            {
                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[z].Cells["cal_order_id"].Value = dt.Rows[z]["order_id"].ToString();
                    dataGridView1.Rows[z].Cells["cal_item_name"].Value = dt.Rows[z]["item"].ToString();
                    dataGridView1.Rows[z].Cells["cal_qty"].Value = dt.Rows[z]["quantity"].ToString();
                    dataGridView1.Rows[z].Cells["cal_total"].Value = dt.Rows[z]["total"].ToString();
                    dataGridView1.Rows[z].Cells["cal_cost"].Value = dt.Rows[z]["cost"].ToString();
                    dataGridView1.Rows[z].Cells["cal_category_name"].Value = dt.Rows[z]["category_name"].ToString();
                    dataGridView1.Rows[z].Cells["calkot_print"].Value = dt.Rows[z]["kot_print"].ToString();
                    dataGridView1.Rows[z].Cells["cal_note"].Value = "";
                    dataGridView1.Rows[z].Cells["cal_comp_status"].Value = "";

                }
                calculate_total();
            }
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                datagridview_qty.Add(dr.Cells["cal_qty"].Value.ToString());
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
                            kot80.printerName = "BOT";
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
                            kot80.printerName = "BOT2";
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
                            kot.printer_name = "BOT";
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
                            kot.printer_name = "BOT2";
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
            kot.table_no = lbltokenno.Text;
            kot.table_name = lbltokenno.Text;
            kot.note_pad = txtrichbox.Text;
            kot.cashier = Login.sendtext;
            kot.service_provider = "";
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
            kot80.table_no = lbltokenno.Text;
            kot80.table_displayNo = lbltokenno.Text;
            kot80.table_name = lbltokenno.Text;
            kot80.note_pad = txtrichbox.Text;
            kot80.cashier = Login.sendtext;
            kot80.service_provider_name = "";
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
        public void TokenPrint80()
        {
            tp.table_no = lbltokenno.Text;
            tp.table_displayNo = lbltokenno.Text;
            tp.table_name = lbltokenno.Text;
            tp.note_pad = txtrichbox.Text;
            tp.cashier = Login.sendtext;
            tp.service_provider_name = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["cal_order_id"].Value == null)
                {
                    tp.datagridview_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    tp.datagridview_qty.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    tp.datagridview_kot_print.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                    tp.datagridview_modifier.Add((dataGridView1.Rows[i].Cells["cal_description"].Value ?? string.Empty).ToString());
                }
            }
            tp.printkot();

        }

       
       
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
            txtsubtotal.Text = sum.ToString("F");
            lblsub_total.Text = sum.ToString("F");
            tax_calcu();
            adss.txt_discount_amount.Text = "0.00";
            adss.txt_discount_percent.Text = "0.00";
            adss.discount_amount = 0;
            adss.discount_amount_percent = 0;
            lbldiscount.Text = "0.00";

        }
        decimal tax_amount;
        decimal service_charge;
        decimal static_grand_total;
        decimal subtotal_with_services;




        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            lblcategory_name.Text = "Category";
            btnnext.Show();
            categorysub(0, 30, 0);
        }


        private void btnprintandsave_Click(object sender, EventArgs e)
        {
            if (txtpan_no.Text.Length > 0 && txtpan_no.Text.Length != 9 && label13.Text != "Club Card No")
            {
                MessageBox.Show("Incorrect Pan No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    
                    save_and_print();
                    if (save_data == true)
                    {
                        clear();
                        txtnewbillno.Clear();
                        bill();
                        clear();
                        dataGridView1.Rows.Clear();
                        CUstomer_name();
                        CUstomer_number();
                        calculate_total();
                        AdminAccess.discount_access_value = false;
                        adss.txt_discount_amount.Text = "0.00";
                        adss.txt_discount_percent.Text = "0.00";
                        adss.discount_amount = 0;
                        adss.discount_amount_percent = 0;
                        save_only_trasaction = false;
                        save_data = false;
                        token_no();
                    }
                }
            }
        }
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
                            payment_modeCheck();
                            billing_save_with_multi();
                           
                             
                            blp.save_after_print = false;
                        }
                    }
                }
            }

        }
        bool save_only_trasaction = false;
        bool save_data = false;
        private void btn_save_only_Click(object sender, EventArgs e)
        {
            decimal parsdec;
            if (dataGridView1.Rows.Count > 0)
            {

               if (txtcardamount.Text != "0.00" || txtcashamount.Text != "0.00" || chkcredit.Checked)
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
                        //else if (chk_club_card.Checked)
                        //{
                        //    balanceCheck();
                        //    if (club_card_balance == true)
                        //    {

                        //        save_only_trasaction = true;
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Transaction Cannot Be Processed With Out Cash Or Card Amount", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    }
                        //}
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

                            payment_modeCheck();
                            billing_save_with_multi();

                            if (save_data == true)
                            {

                               
                           
                                int delete_TokenNo = blkot.deleteTokenNo(lbltokenno.Text);
                                txtnewbillno.Clear();
                                bill();
                                clear();
                                dataGridView1.Rows.Clear();
                                save_data = false;
                                dataGridView1.Rows.Clear();
                                AdminAccess.discount_access_value = false;
                                MessageBox.Show("Data has been save to database", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                adss.txt_discount_amount.Text = string.Empty;
                                adss.txt_discount_percent.Text = string.Empty;
                                adss.discount_amount = 0;
                                adss.discount_amount_percent = 0;
                                dataGridView1.Rows.Clear();
                                token_no();

                            }
                          
                        }

                    }
                }
              //  dataGridView1.Columns["cal_delete"].Visible = false;     
                save_only_trasaction = false;

            }

        }
        public void multi_billing()
        {
            if (multi_billing_check == true)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int order_id = Convert.ToInt32(row.Cells["cal_order_id"].Value);
                    int i = blkot.deletefromorder_id(order_id);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int order_id = Convert.ToInt32(row.Cells["cal_order_id"].Value);
                    int i = blkot.deletefromorder_id(order_id);
                }
            }


        }
        BLLBusinessDyanmic blbd = new BLLBusinessDyanmic();
        string sync_with_ird = "false";
        public void IRD()
        {
            DataTable dtbd = blbd.selectAllData();
            if (dtbd.Rows.Count > 0)
            {
                if (dtbd.Rows[0]["sync_ird"].ToString() == "True")
                {
                    var connec = ic.CheckForInternetConnection();
                    if (connec == true)
                    {
                        int IRT = apir.posBilling(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(subtotal_with_services), Convert.ToDouble(lbl_tax_amount.Text), true,fiscal_year,ird_username,ird_password);
                        sync_with_ird = "true";
                        //DataTable dt = blbt.checkDataIRDCBMS();
                        //if (dt.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dt.Rows.Count; i++)
                        //    {
                        //        int IRDOnline = apir.posBilling(dt.Rows[i]["buyer_pan"].ToString(), dt.Rows[i]["buyer_name"].ToString(), dt.Rows[i]["invoice_number"].ToString(), dt.Rows[i]["invoice_date"].ToString(), Convert.ToDouble(dt.Rows[i]["total_sales"]), Convert.ToDouble(dt.Rows[i]["taxable_sales_vat"]), Convert.ToDouble(dt.Rows[i]["vat"]), false);
                        //        if (IRDOnline > 0)
                        //        {
                        //            int syncWithIRD = blfsc.updateSyncIRD(Convert.ToInt32(dt.Rows[i]["invoice_number"]));
                        //        }
                        //    }
                        //    int irdTruncate = blbt.truncateIRDData();
                        //}

                    }
                    else
                    {
                        int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, subtotal_with_services.ToString(),lbl_tax_amount.Text
                            
                            
                            
                            
                            
                            , "", "", "", "", "", "", "", "");
                        sync_with_ird = "false";
                    }
                }
                else
                {
                    int offline = blbt.irdCBMS(txtpan_no.Text, cbo_customer_name.Text, txtnewbillno.Text, nepaliDateConvert, txtgrandtotal.Text, subtotal_with_services.ToString(),lbl_tax_amount.Text, "", "", "", "", "", "", "", "");
                    sync_with_ird = "false";
                }
            }
        }
        public void materialized_view_save()
        {
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                string fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
                int fiscal = blfsc.insert_Materialized_View(fiscal_year, Convert.ToInt32(txtnewbillno.Text), cbo_customer_name.Text,txtpan_no.Text, date, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discountAmount), subtotal_with_services, tax_amount, "False", "True", date.ToString("HH:mm tt"), Login.sendtext, Login.sendtext, sync_with_ird, sync_with_ird);
            }
            
        }
        BLLComplementry blcomp = new BLLComplementry();
        Ingredient im = new Ingredient();
        public void billing_save_with_multi()
        {
            //try
            //{
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
                            string kot_type = dr.Cells["calkot_print"].Value.ToString();
                            string sales_type ="TNo";
                            string complementru_status = dr.Cells["cal_comp_status"].Value.ToString();
                            string service_provider = "";
                            int order_id =Convert.ToInt32(dr.Cells["cal_order_id"].Value.ToString());
                        int b = blresll.insertintosalesbook(Convert.ToInt32(txtnewbillno.Text), date, Login.sendtext, category_name1, lbltokenno.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discountAmount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), sales_type, txtpan_no.Text, "X", Convert.ToDecimal(lbl_service_charge.Text), subtotal_with_services, Convert.ToDecimal(tax_amount), fiscal_year, service_provider, date, customer_id, dr.Index, date.ToString("HH:mm tt"), sync_with_ird, complementryInvoiceNo, complementru_status,"", 0, "", order_id,Convert.ToDecimal(0.00));
                        if (b > 0)
                            {

                            int i = blkot.deletefromtable(lbltokenno.Text);
                                DataTable dt = blord.getallbyitem_name(item);
                                if (dt.Rows.Count > 0)
                                {
                                    im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                                }
                                save_data = true;

                            }

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
                            string kot_type = dataGridView1.Rows[a].Cells["calkot_print"].Value.ToString();
                            string sales_type = "TNo";
                            string complementru_status = dataGridView1.Rows[a].Cells["cal_comp_status"].Value.ToString();
                             string service_provider = "";
                        int order_id = Convert.ToInt32(dataGridView1.Rows[a].Cells["cal_order_id"].Value.ToString());
                        int b = blresll.insertintosalesbook(Convert.ToInt32(txtnewbillno.Text), date, Login.sendtext, category_name1, lbltokenno.Text, cbo_customer_name.Text, txtpan_no.Text, item, quantity, cost, total, payment_mode, kot_type, Convert.ToDecimal(txtsubtotal.Text), Convert.ToDecimal(discountAmount), Convert.ToDecimal(txtcashamount.Text), Convert.ToDecimal(txtcardamount.Text), Convert.ToDecimal(txtgrandtotal.Text), sales_type, txtpan_no.Text, "X", Convert.ToDecimal(lbl_service_charge.Text), subtotal_with_services, Convert.ToDecimal(tax_amount), fiscal_year, service_provider, date, customer_id, a, date.ToString("HH:mm tt"), sync_with_ird, complementryInvoiceNo, complementru_status, "", 0, "", order_id,Convert.ToDecimal(0.00));
                        if (b > 0)
                            {
                                 int i = blkot.deletefromtable(lbltokenno.Text);
                                save_data = true;
                                DataTable dt = blord.getallbyitem_name(item);
                                if (dt.Rows.Count > 0)
                                {
                                    im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                                }
                            }
                        }
                    }

                }
                if (save_data == true)
                {
                   
                    IRD();
                
                }
            
               
           
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        string payment_mode;
        int customer_id;
        public void payment_modeCheck()
        {
            if (chkcard.Checked)
            {
                blp_80.payment_mode = "Card";
                blp_76.payment_mode = "Card";
                pn80.payment_mode = "Card";
                payment_mode = "Card";
            }
            else if (chkcash.Checked)
            {
                blp_80.payment_mode = "Cash";
                blp_76.payment_mode = "Cash";
                pn80.payment_mode = "Cash";
                payment_mode = "Cash";
            }
            else if (chkcash_card.Checked)
            {
                blp_80.payment_mode = "Card/Cash";
                blp_76.payment_mode = "Card/Cash";
                pn80.payment_mode = "Card/Cash";
                payment_mode = "Card/Cash";
            }
          
            else if (chkcredit.Checked)
            {
                blp_80.payment_mode = "Credit";
                blp_76.payment_mode = "Credit";
                pn80.payment_mode = "Credit";
                payment_mode = "Credit";
            }
        }
        public void printer_checker()
        {
            DataTable dt_prt = blpt.getalldata();
            DataTable dt_p = blpt.getallPrintingTimes();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {

                            blp_80.print_again = true;
                            blp_80.printer_name = "B1";
                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp_80.print_again = false;
                            }
                            bill_printing_for_80();

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

                            cp80.print_again = true;
                            cp80.printer_name = "B1";
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
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "P80")
                {
                    if (dt_p.Rows.Count > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dt_p.Rows[0]["B1"]); i++)
                        {

                            pn80.print_again = true;
                            pn80.printer_name = "B1";
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
                            blp_76.print_again = true;

                            if (i == Convert.ToInt32(dt_p.Rows[0]["B1"]) - 1)
                            {
                                blp_76.printer_name = "B1";
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
               
            }
            else
            {
                MessageBox.Show("Printing setting does not set.", "Printing Size is Zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool save_after_print;
        private void btnprintonly_Click(object sender, EventArgs e)
        {
            DataTable dt_prt = blpt.getalldata();

            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                    blp_80.billing_print_only = true;
                    blp_80.printer_name = "U";
                    bill_printing_for_80();

                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "C80")
                {
                    cp80.billing_print_only = true;
                    cp80.printer_name = "U";
                    billingForCoupon80();

                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                {
                    blp_76.billing_print_only = true;
                    blp_76.printer_name = "U";
                    bill_printing_for_76();

                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "P80")
                {
                    pn80.billing_print_only = true;
                    pn80.printer_name = "U";
                    PanBilling80();

                }
               
            }
        }
        public void clear()
        {
           
            txtcardamount.Text = "0.00";
            txtcashamount.Text = "0.00";
            txtremainingamount.Text = "0.00";
            txtsubtotal.Text = "0.00";
            txtgrandtotal.Text = "0.00";
            lblsub_total.Text = "0.00";
            lbl_service_charge.Text = "0.00";
            lbl_tax_amount.Text = "0.00";
            lbldiscount.Text = "0.00";
            

        }




       
        public void bill_printing_for_80()
        {
            blp_80.bill_no = txtnewbillno.Text;
            blp_80.cashier =user_name;
            blp_80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_80.discount = Convert.ToDecimal(lbldiscount.Text).ToString("#.##");
            blp_80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_80.table_no = lbltokenno.Text;
            blp_80.customer_PAN_no = txtpan_no.Text;
            blp_80.customer_name = "";
            blp_80.customer_address = customer_address;
            blp_80.customer_phone_no = cbo_customer_no.Text;
          //  blp_80.discount_percent = discount_percent;
            blp_80.tax_amount = tax_amount.ToString("#.##");
            blp_80.service_charge = service_charge.ToString("#.##");
           // blp_80.area_name = area_name;
            blp_80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
           // blp_80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                blp_80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
           // payment_modeCheck();
            blp_80.billing_date = date;
            blp_80.taxable_amount = subtotal_with_services.ToString("#.##");
            blp_80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
          
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                    blp_80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                    blp_80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                    blp_80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                    blp_80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());

                }
                blp_80.printtobill();
                save_after_print = blp_80.save_after_print;
           
         

        }
       
        public void billingForCoupon80()
        {
            cp80.bill_no = txtnewbillno.Text;
            cp80.cashier =user_name;
            cp80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
           cp80.discount = Convert.ToDecimal(discountAmount).ToString("#.##");
            cp80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            cp80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            cp80.table_no = lbltokenno.Text;
            cp80.customer_PAN_no = txtpan_no.Text;
            cp80.customer_name = cbo_customer_name.Text;
           // cp80.discount_percent = discount_percent;
            cp80.tax_amount = tax_amount.ToString("#.##");
            cp80.service_charge = service_charge.ToString("#.##");
         
           // cp80.service_provider = service_provider;
            cp80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            //cp80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                cp80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
           // payment_modeCheck();
            cp80.billing_date = date;
            cp80.taxable_amount = subtotal_with_services.ToString("#.##");
            cp80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
          
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

        public void PanBilling80()
        {
            pn80.bill_no = txtnewbillno.Text;
            pn80.cashier = user_name;
            pn80.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
             pn80.discount = Convert.ToDecimal(discountAmount).ToString("#.##");
            pn80.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            pn80.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            pn80.table_no = lbltokenno.Text;
            pn80.customer_PAN_no = txtpan_no.Text;
            pn80.customer_name = "";
           // pn80.discount_percent = discount_percent;
            pn80.tax_amount = tax_amount.ToString("#.##");
            pn80.service_charge = service_charge.ToString("#.##");
             //pn80.area_name = area_name;
            pn80.card_amount = Convert.ToDecimal(txtcardamount.Text).ToString("#.##");
            // pn80.customer_card_balance = (real_blc - Convert.ToDecimal(txtgrandtotal.Text)).ToString("#.##");
            if (txtremainingamount.Text != "")
            {
                pn80.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            payment_modeCheck();
            pn80.billing_date = date;
            pn80.taxable_amount = subtotal_with_services.ToString("#.##");
            pn80.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                pn80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["cal_item_name"].Value.ToString());
                pn80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["cal_cost"].Value.ToString());
                pn80.datagridview_total.Add(dataGridView1.Rows[i].Cells["cal_total"].Value.ToString());
                pn80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString());
                pn80.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());

            }
            pn80.printtobill();
            save_after_print = pn80.save_after_print;

           
        }

        public void bill_printing_for_76()
        {
            blp_76.bill_no = txtnewbillno.Text;
            blp_76.cashier = user_name;
            blp_76.cash_amount = Convert.ToDecimal(txtcashamount.Text).ToString("#.##");
            blp_76.discount = Convert.ToDecimal(discountAmount).ToString("#.##");
            blp_76.grand_total = Convert.ToDecimal(txtgrandtotal.Text).ToString("#.##");
            blp_76.sub_total = Convert.ToDecimal(txtsubtotal.Text).ToString("#.##");
            blp_76.table_no = lbltokenno.Text;
            blp_76.customer_PAN_no = txtpan_no.Text;
            blp_76.customer_name ="";
            blp_76.customer_address = customer_address;
            blp_76.customer_phone_no = cbo_customer_no.Text;
            //blp_76.discount_percent = discount_percent;
            blp_76.tax_amount = tax_amount.ToString("#.##");
            blp_76.service_charge = service_charge.ToString("#.##");
            //blp_76.area_name = area_name;
            payment_modeCheck();
            if (txtremainingamount.Text != "")
            {
                blp_76.change_amount = Convert.ToDecimal(txtremainingamount.Text).ToString("#.##");
            }
            blp_76.billing_date = date;
            blp_76.taxable_amount = subtotal_with_services.ToString("#.##");
            blp_76.discount_sub_total = Convert.ToDecimal(lblsub_total.Text).ToString("#.##");
          
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
        //number key pad

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

        private void btnthree_Click(object sender, EventArgs e)
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

        private void btndoublezero_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "00";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "00";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value += "00";
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0.00")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text = "";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text = "";
                    }
                }
                else if (lastFocused is DataGridViewCell)
                {
                    ((DataGridViewCell)lastFocused).Value = "";
                }
            }
        }


        private void btnbackspace_Click(object sender, EventArgs e)
        {
            if (((TextBox)lastFocused).Text != "")
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
                        ((TextBox)lastFocused).Text = ((TextBox)lastFocused).Text.Substring(0, i - 1);
                    }

                }
                else if (lastFocused is DataGridViewCell)
                {
                    string s = ((DataGridViewCell)lastFocused).Value.ToString();
                    ((DataGridViewCell)lastFocused).Value = s.Substring(0, s.Length - 1);
                }


            }

        }
        bool minus_click = false;
        private void btnminus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value)>1)
                    {
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1);
                        decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        decimal quantitys = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value);
                        decimal total = quantitys * cost;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = total;
                        calculate_total();
                        tax_calcu();
                        DataTable dt = blkot.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                        if (dt.Rows.Count > 0)
                        {
                            minus_click = true;
                        }
                    }
                
                else
                {
                    MessageBox.Show("Quantity cannot be less than 1.");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //{
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            bool user_access_check = AdminAccess.discount_access_value;
            if (user_access_check == true)
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    DataTable dt = blkot.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
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
                            grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value));
                            dataGridView1.Rows.Remove(dr);
                            calculate_total();
                            tax_calcu();
                        }
                    }
                }
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
                    if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K2")
                    {
                        kot_cancel_printer_2 = true;
                    }
                    if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B1")
                    {
                        kot_cancel_printer_3 = true;
                    }
                    if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "B2")
                    {
                        kot_cancel_printer_4 = true;
                    }
                    if (dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString() == "K3")
                    {
                        kot_cancel_printer_5 = true;
                    }
                    int uup = blkot.updateorderstable(Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_qty"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_order_id"].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value));
                }
            }
            cancel_minus = true;
            print_cancel();
            calculate_total();
        }
        decimal grandtotal;
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
                else if (dr.Cells["calkot_print"].Value.ToString() == "B1")
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
            print_cancel();
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
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
                grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value));
                int i = blkot.deleteitemfromorder(Convert.ToInt32(dr.Cells["cal_order_id"].Value));
                int deleteTokenNo = blkot.deleteTokenNo(lbltokenno.Text);
                int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltokenno.Text), item_name, quantity, total, cost, "Active", category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TNo");
                dataGridView1.Rows.Remove(dr);
            }

            calculate_total();
        }
        bool cancel_all = false;
        bool cancel_selected = false;
        bool cancel_minus = false;
        bool kot_cancel_printer_1 = false;
        bool kot_cancel_printer_2 = false;
        bool kot_cancel_printer_3 = false;
        bool kot_cancel_printer_4 = false;
        bool kot_cancel_printer_5 = false;
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
                    kotc_80.printer_name = "BOT";
                    kot_printing_cancel_80();
                    kotc_80.printcalcel();
                    kot_cancel_printer_3 = kotc_80.kot_printer_1;
                }
                if (kot_cancel_printer_4 == true)
                {
                    kotc_80.printer_name = "BOT2";
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
                    kotc_56.printer_name = "BOT";
                    kot_printing_cancel_56();
                    kotc_56.printkot();
                    kot_cancel_printer_3 = kotc_56.kot_printer_1;
                }
                if (kot_cancel_printer_4 == true)
                {
                    kotc_56.printer_name = "BOT2";
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
            kotc_80.table_no = lbltokenno.Text;
            kotc_80.table_displayNo = lbltokenno.Text;
            kotc_80.table_name = "TNo";
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
            kotc_56.table_no = lbltokenno.Text;
            kotc_56.table_name = lbltokenno.Text;
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
        private void btnenter_Click(object sender, EventArgs e)
        {

        }

        private void txtcashamount_TextChanged(object sender, EventArgs e)
        {

            if (txtcashamount.Text.Length > 0)
            {
                if (chkcash_card.Checked)
                {
                    

                    if (Convert.ToDecimal(txtgrandtotal.Text) <= Convert.ToDecimal(txtcashamount.Text))
                    {
                        txtremainingamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtcardamount.Text = "0.00";


                    }
                    else
                    {
                        txtcardamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtremainingamount.Text = "0.00";

                    }
                }
                else if (chkcash.Checked)
                {
                    txtremainingamount.Text = (Convert.ToDecimal(txtcashamount.Text) - (Convert.ToDecimal(txtgrandtotal.Text))).ToString();

                }
            }
            else if (txtcardamount.Text == "")
            {
                txtcardamount.Text = "0.00";


            }

        }



      

        private void chkcash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcash.Checked)
            {
                
                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                txtremainingamount.Text = "0.00";

            }
        }

        private void chkcard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcard.Checked)
            {
               
                txtcardamount.Text = "0.00";
                txtcashamount.Text = "0.00";
                txtremainingamount.Text = "0.00";
                txtcardamount.Text = static_grand_total.ToString();
            }
        }
        private void chkcash_card_CheckedChanged(object sender, EventArgs e)
        {
          
            txtcardamount.Text = "0.00";
            txtcashamount.Text = "0.00";
            txtremainingamount.Text = "0.00";
            txtcardamount.Text = "0.00";
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



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            token_no();
        }
        private void chkhome_delivery_CheckedChanged(object sender, EventArgs e)
        {
            homeDelevery();
        }
        public void homeDelevery()
        {
            DataTable dt = blhd.gethomedelevery();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    lbltokenno.Text = "106";
                    lbltoken_no_text.Text = "Home Delivery";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    lbltokenno.Text = getinvoiceno.ToString();
                    lbltoken_no_text.Text = "Home Delivery";

                }
            }
        }
        public Point _cellClick;
        //int rp;
        int dgvRowIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["cal_complementry"].Index && e.RowIndex >= 0))
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
                dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) - 1;
                dataGridView1.Rows[dgvRowIndex].Cells["cal_total"].Value = Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_qty"].Value) * Convert.ToDecimal(dataGridView1.Rows[dgvRowIndex].Cells["cal_cost"].Value);
                dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor = Color.DarkGray;

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
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            old = new DataGridViewRow[dataGridView1.SelectedRows.Count];
            dataGridView1.SelectedRows.CopyTo(old, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void txtdiscount_Click(object sender, EventArgs e)
        {
            user_access_check = AdminAccess.discount_access_value;
            if (user_access_check == false)
            {
                AdminAccess aass = new AdminAccess();
                aass.ShowDialog();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            flw_panel.Controls.Clear();
            //flowLayoutPanel2.Show();
            //flw_panel.Controls.Add(flowLayoutPanel2);
            lblcategory_name.Text = "Token No";
            tabletuch();
        }
        bool billingButtonClick = false;
        private void btn_billing_viewer_Click(object sender, EventArgs e)
        {
            if (billingButtonClick == true)
            {
                categorysub(pre_cat, next_panel, 0);
                billingButtonClick = false;
            }
            else
            {
                flw_panel.Controls.Clear();
                panelEx1.Show();
                panelEx2.Show();
                groupBox1.Show();
                flw_panel.Controls.Add(panelEx2);
                flw_panel.Controls.Add(panelEx1);
                flw_panel.Controls.Add(groupBox1);
                flw_panel.Controls.Add(pln_customer);
                txtsubtotal.Text = lblsub_total.Text;
                lblcategory_name.Text = "Billing";
                billingButtonClick = true;
            }
        }


        private void btncalcu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }




        private void btn_cancel_all_Click(object sender, EventArgs e)
        {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            bool user_access_check = AdminAccess.discount_access_value;
            if (user_access_check == true)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    //DataTable dt = blord.getallfromorder_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_order_id"].Value));
                    if (button_addwasclick == true)
                    {
                        if (lbltokenno.Text.Length > 0)
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
                                int i = blkot.deletefromtable(lbltokenno.Text);
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
                                    grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dr.Cells["cal_total"].Value));

                                    int bocs = boc.insertordercancellation(Login.sendtext, Convert.ToDecimal(lbltokenno.Text), item_name, quantity, total, cost, "active", category_name, kot_print, getCustomerPhone, Convert.ToDateTime(DateTime.Now.ToLongTimeString()), emo_desc, "TNo");

                                }
                                int deleteToken = blt.delete_token_no(Convert.ToInt32(lbltokenno.Text));
                                dataGridView1.Rows.Clear();
                              
                            }
                        }

                    }
                    else
                    {

                        // decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["cal_total"].Value);
                        grandtotal = (Convert.ToDecimal(grandtotal) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value));
                        dataGridView1.Rows.Clear();
                      

                    }
                    clear();
                }
                button_addwasclick = false;
                cancel_all = false;
            }
        }

        private void btn_advanceDiscount_Click(object sender, EventArgs e)
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
                        adis.datagridview_KOT.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                    }
                    adis.table_no = lbltokenno.Text;
                    adis.ShowDialog();
                    if (adis.DialogResult == DialogResult.OK)
                    {
                        lbldiscount.Text = (adis.discount_amount).ToString();
                        //discount_percent = (adis.discount_amount_percent).ToString();
                        lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                        discountAmount = Convert.ToDecimal(lbldiscount.Text);
                       tax_calcu();
                       cashamount_recived_amount();
                        if (chkcard.Checked)
                        {
                            txtcardamount.Text = txtgrandtotal.Text;
                        }
                    }

                }
            }
            else
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
                            adis.datagridview_KOT.Add(dataGridView1.Rows[i].Cells["calkot_print"].Value.ToString());
                        }
                        adis.table_no = lbltokenno.Text;
                        adis.ShowDialog();
                        if (adis.DialogResult == DialogResult.OK)
                        {
                            if (adis.DialogResult == DialogResult.OK)
                            {
                                lbldiscount.Text = (adis.discount_amount).ToString();
                               // discount_percent = (adis.discount_amount_percent).ToString();
                                lblsub_total.Text = (Convert.ToDecimal(txtsubtotal.Text) - Convert.ToDecimal(lbldiscount.Text)).ToString();
                                discountAmount = Convert.ToDecimal(lbldiscount.Text);
                               tax_calcu();
                              cashamount_recived_amount();
                                if (chkcard.Checked)
                                {
                                    txtcardamount.Text = txtgrandtotal.Text;
                                }
                            }
                        }
                    }
                }
            }

        }
        CheckDynamic cd = new CheckDynamic();
        public void tax_calcu()
        {

            if (lblsub_total.Text != "")
            {
                TaxCalculation tax = new TaxCalculation();
                DataTable dttakeaway = bld.GetServiceToken();
                if (dttakeaway.Rows.Count > 0)
                {
                   bool service_status = cd.TokenBillingServiceCharge();
                    if (service_status == true)
                    {
                        service_charge = tax.service_calculation(Convert.ToDecimal(lblsub_total.Text));
                    }
                }

                subtotal_with_services = (Convert.ToDecimal(lblsub_total.Text) + service_charge);
                tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                static_grand_total = subtotal_with_services + tax_amount;
                txtgrandtotal.Text = static_grand_total.ToString("F");
                lbl_tax_amount.Text = tax_amount.ToString("F");
                lbl_service_charge.Text = service_charge.ToString("F");

                if (lbl_service_charge.Text == "")
                {
                    lbl_service_charge.Text = "0.00";
                }
                if (lbl_tax_amount.Text == "")
                {
                    lbl_tax_amount.Text = "0.00";
                }
            }
            else
            {
                lblsub_total.Text = "0.00";
                txtgrandtotal.Text = "0.00";
                lbl_tax_amount.Text = "0.00";
                lbl_service_charge.Text = "0.00";
                txtsubtotal.Text = "0.00";
            }
        }
        public void cashamount_recived_amount()
        {
           
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
                       

                    }
                    else
                    {
                        txtcardamount.Text = Math.Abs(Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                        txtremainingamount.Text = "0.00";
                       
                    }

                }
                else if (chkcash.Checked)
                {
                    txtremainingamount.Text = (Convert.ToDecimal(txtcashamount.Text) - Convert.ToDecimal(txtgrandtotal.Text)).ToString();
                    
                }
                else if (chkcredit.Checked)
                {
                    txtremainingamount.Text = Math.Abs(Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtcashamount.Text)).ToString();
                   
                }
            }
            else if (txtcashamount.Text == "" || txtcashamount.Text == "0.00")
            {
                txtcardamount.Text = "0.00";
             

            }
            else if (txtcardamount.Text == "")
            {
                txtcardamount.Text = "0.00";
              

            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
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
            }   
        }
        string customer_address;
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
                    txtpan_no.Text = dt.Rows[0]["phone2"].ToString();
                }
            }
            else if (cbo_customer_no.Text == "" && cbo_customer_no.Text == "Choose One")
            {
                cbo_customer_no.Text = "Choose One";
            }
        }

        private void cbo_customer_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_customer_no.Text != "" && cbo_customer_no.Text != "Choose One" && cbo_customer_name.SelectedIndex < 0)
            {
                DataTable dt = blcd.getDataByitsPhonenumbers(cbo_customer_no.Text);
                if (dt.Rows.Count > 0)
                {
                    cbo_customer_name.Text = dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                    customer_id = Convert.ToInt32(cbo_customer_name.SelectedValue);
                    txtpan_no.Text = dt.Rows[0]["phone2"].ToString();
                    customer_address = dt.Rows[0]["address"].ToString();
                }
            }
            else if (cbo_customer_no.Text == "" && cbo_customer_no.Text == "Choose One")
            {
                cbo_customer_no.Text = "Choose One";
            }
        }
    }
}
