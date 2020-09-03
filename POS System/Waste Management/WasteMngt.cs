using BLLS;
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
    public partial class WasteMgnt : UserControl
    {
        public WasteMgnt()
        {
            InitializeComponent();
        }
        BLLOrder blord = new BLLOrder();
        BLLMenuItem blmi = new BLLMenuItem();
        BLLdays_wise blldays_wise = new BLLdays_wise();
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        BLLIngredientManagement blim = new BLLIngredientManagement();
        BLLUser blu = new BLLUser();
        int next_panel = 25;
        int pre_cat = 0;
        int i = 0;
        bool back_click;
        int nxt = 0;
        int phg = 25;
        string category_name = "Null";
        private void WasteMgnt_Load(object sender, EventArgs e)
        {
            categorysub(pre_cat, next_panel);
            flowLayoutPanel1.Hide();
            txtrichbox.Hide();
            //datagridviewload();
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
           // button_addwasclick = true;
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
        string item_id;
        string modifier_text;
      //  private bool button_addwasclick = false;
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

              //  button_addwasclick = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string grandtotal;
        decimal static_grand_total = 0;
        decimal tax_amount = 0;
        public void calculate_total()
        {
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["cal_total"].Value);
            }


            lbl_total.Text = sum.ToString();
         //   tax_calcu();
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
        bool minus_click = false;
        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 1)
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

        string emo_desc;
        private void btn_cancel_Click(object sender, EventArgs e)
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
                            //for_minus_cancel();
                            minus_click = false;
                        }
                        else
                        {
                           // cancel_selected_rows();
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
                      //  tax_calcu();

                    }
                }
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Table_Management.Table_Billing vieret = new Table_Management.Table_Billing();
            Control ctls = this.Parent;
            ctls.Controls.Clear();
            ctls.Controls.Add(vieret);
        }
        Ingredient im = new Ingredient();
        string today = DateTime.Now.ToString();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                for (int a = 0; a < dataGridView1.Rows.Count; a++)
                {
                    string item = (dataGridView1.Rows[a].Cells["cal_item_name"].Value.ToString());
                    decimal quantity = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_qty"].Value.ToString());
                    decimal cost = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_cost"].Value.ToString());
                    decimal total = Convert.ToDecimal(dataGridView1.Rows[a].Cells["cal_total"].Value.ToString());
                    DataTable dt = blord.getallbyitem_name(item);
                    if (dt.Rows.Count > 0)
                    {
                        im.ingredientManage(Convert.ToInt32(dt.Rows[0]["item_id"]), quantity);//item sales wise stock decrease 
                        int insert =blim.StockWasteInsert (Convert.ToInt32(dt.Rows[0]["item_id"]), quantity,Convert.ToDateTime(today));
                        MessageBox.Show("Successfully Inserted Waste", "Insert Data Alert !!");
                        dataGridView1.Rows.Clear();
                    }
                }

            }
            else
            {
                MessageBox.Show("Nothing To Save", "No Data Alert !!");
            }
    
        }

        private void btn_x_note_Click(object sender, EventArgs e)
        {
            txtrichbox.Show();
        }
    }
}
