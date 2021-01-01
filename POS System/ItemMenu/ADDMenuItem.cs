using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.IO;
using System.Runtime.InteropServices;

namespace POS_System
{
    public partial class ADDMenuItem : UserControl
    {
        public ADDMenuItem()
        {
            InitializeComponent();

        }

        BLLItemcategory bllcat = new BLLItemcategory();
        BLLMenuItem bllpro = new BLLMenuItem();
        BLLS.Bll_inventory.bll_inv BIV = new BLLS.Bll_inventory.bll_inv();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        CheckDynamic cd = new CheckDynamic();
        BLLUser blu = new BLLUser();
        string color;
        decimal update_item_price;
  
        int item_id;
        byte[] img = null;
        ImageConverter imgCon = new ImageConverter();
        string date_save;
       // bool discount_status = false;
        private void AddProductItems_Load(object sender, EventArgs e)
        {
            panel16.Hide();
            panel18.Hide();
            var Chk_items = checkedListBox1.Items;
            Chk_items.Add("Sunday");
            Chk_items.Add("Monday");
            Chk_items.Add("Tuesday");
            Chk_items.Add("Wednesday");
            Chk_items.Add("Thursday");
            Chk_items.Add("Friday");
            Chk_items.Add("Saturday");
            panel17.Hide();
            lbl_preview_selling_price.Hide();
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            btn_darkblue.Select();
            color = "DarkBlue";
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            loadcategory();
           btn_save.Enabled = true;
           btn_update.Enabled = false;
           cbo_applicabletimeperiod.Text = "Always";
           cbo_kot_print.Text = "K1";
            item_id = AddMenuItemList.item_id;
            if (item_id > 0)
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;
                //discount_status = cd.DiscountBelowDiscountCost(); 
                //if (discount_status == false)
                //{
                //    panel_discount.Hide();
                //}
                //else
                //{
                //    panel_discount.Show();
                //}
                DataTable dtcost = BIV.GetItemCost(item_id);
                if (dtcost.Rows.Count>0)
                {
                    lbl_estimatecost.Text = dtcost.Rows[0]["total_cost"].ToString();
                }
                else
                {
                    lbl_estimatecost.Hide();
                }
                DataTable dt = bllpro.get_item_by_item_id(item_id);
                if (dt.Rows.Count > 0)
                {
                    //pn_displaybutton.BackColor = Color.White;
                    btn_darkblue.Image = null;
                    btn_darkgreen.Image = null;
                    btn_blue.Image = null;
                    btn_goldenrod.Image = null;
                    btn_red.Image = null;
                    btn_mediumblue.Image = null;
                    btn_limegreen.Image = null;
                    btn_firebrick.Image = null;
                    btn_maroon.Image = null;

                    txt_name.Text = dt.Rows[0]["item_name"].ToString();
                    int categoryid = Convert.ToInt32(dt.Rows[0]["category_id"].ToString());
                    DataTable dt1 = bllpro.getcategorybycategoryid(categoryid);
                    cbo_category.Text = dt1.Rows[0]["category_name"].ToString();
                    update_item_price = Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                    txt_sellingprice.Text = update_item_price.ToString();
                    txt_costprice.Text = dt.Rows[0]["item_cost_price"].ToString();
                    cbo_applicabletimeperiod.Text = dt.Rows[0]["applicable_time_period"].ToString();
                    txt_discount.Text=(dt.Rows[0]["discount"].ToString());
                    DataTable dtb = bllpro.getdayswiserecords(item_id);
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        date_save = dtb.Rows[i]["days"].ToString();
                        days_selected.Add(date_save);
                        days_with_comma = string.Join(",", days_selected);
                        txt_selecteddays.Text = days_with_comma;
                        int index = checkedListBox1.Items.IndexOf(date_save);
                        if (index >= 0)
                        {
                            checkedListBox1.SetItemChecked(index, true);
                        }
                    }

                    cbo_kot_print.Text = dt.Rows[0]["kot_print"].ToString();

                    //DataTable dtb1 = bllpro.getimage_namebyitem_id(item_id);
                    string image_color = dt.Rows[0]["image_color"].ToString();
                    if (image_color.Length > 0 && image_color != "")
                    {                      
                        pn_displaybutton.BackColor = Color.FromName(image_color);
                        if (btn_blue.BackColor == Color.FromName(image_color))
                        {
                            btn_blue.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_darkblue.BackColor == Color.FromName(image_color))
                        {
                            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_mediumblue.BackColor == Color.FromName(image_color))
                        {
                            btn_mediumblue.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_darkgreen.BackColor == Color.FromName(image_color))
                        {
                            btn_darkgreen.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_firebrick.BackColor == Color.FromName(image_color))
                        {
                            btn_firebrick.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_goldenrod.BackColor == Color.FromName(image_color))
                        {
                            btn_goldenrod.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_limegreen.BackColor == Color.FromName(image_color))
                        {
                            btn_limegreen.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_maroon.BackColor == Color.FromName(image_color))
                        {
                            btn_maroon.Image = global::POS_System.Properties.Resources._checked;
                        }
                        else if (btn_red.BackColor == Color.FromName(image_color))
                        {
                            btn_red.Image = global::POS_System.Properties.Resources._checked;
                        }
                    }

                    else
                    {
                        Byte[] imge_byte = (byte[])dt.Rows[0]["image_name"];
                        var stream = new MemoryStream(imge_byte);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                        pictureBox1.BringToFront();
                        pn_displaybutton.BackColor = Color.Empty;
                        image_color = "";
                       

                    }
                }
            }
            else
            {
                lbl_estimatecost.Hide();
            }
            //AddMenuItemList.item_id = 0;
        }

        public void loadcategory()
        {
            DataTable dt = bllcat.getcategories();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose Category";
                dt.Rows.InsertAt(dr, 0);

                cbo_category.DataSource = dt;
                cbo_category.DisplayMember = "category_name";
                cbo_category.ValueMember = "category_id";
            }
        }


        private void btn_darkblue_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            btn_darkblue.Select();
            color = "DarkBlue";
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_darkblue.BackColor;

        }

        private void btn_mediumblue_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_mediumblue.BackColor;
            btn_mediumblue.Select();
            color = "MediumBlue";

            btn_mediumblue.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_mediumblue.BackColor;
        }

        private void btn_blue_Click_1(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_blue.BackColor;
            btn_blue.Select();
            color = "Blue";
            btn_blue.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_mediumblue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_blue.BackColor;
        }

        private void btn_maroon_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_maroon.BackColor;
            btn_maroon.Select();
            color = "Maroon";
            btn_maroon.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_mediumblue.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_maroon.BackColor;
        }

        private void btn_firebrick_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_firebrick.BackColor;
            btn_firebrick.Select();
            color = "Firebrick";
            btn_firebrick.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_mediumblue.Image = null;
            btn_limegreen.Image = null;

            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_firebrick.BackColor;
        }

        private void btn_red_Click_1(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_red.BackColor;
            btn_red.Select();
            color = "red";
            btn_red.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_mediumblue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_red.BackColor;
        }

        private void btn_darkgreen_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_darkgreen.BackColor;
            btn_darkgreen.Select();
            color = "DarkGreen";
            btn_darkgreen.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;

            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_darkgreen.BackColor;
        }

        private void btn_limegreen_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_limegreen.BackColor;
            btn_limegreen.Select();
            color = "LimeGreen";
            btn_limegreen.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_goldenrod.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_mediumblue.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_limegreen.BackColor;
        }

        private void btn_goldenrod_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_goldenrod.BackColor;
            btn_goldenrod.Select();
            color = "Goldenrod";
            btn_goldenrod.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_blue.Image = null;
            btn_mediumblue.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_limegreen.Image = null;
            pictureBox1.Hide();
            pn_displaybutton.Show();
            panel17.BackgroundImage = null;
            panel17.BackColor = btn_goldenrod.BackColor;
        }



        private void btn_selectimage_Click_1(object sender, EventArgs e)
        {


            openFileDialog1.InitialDirectory = "c:\\Program File";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            pictureBox1.Controls.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog1.FileName;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(sourceFile);
                if (fileInfo.Exists)
                {
                    bytes = fileInfo.Length;
                    kilobytes = (double)bytes / 1024;
                }

                if (btn_update.Enabled != true)
                {
                    if (txt_name.Text != "")
                    {
                        //System.IO.File.Copy(openFileDialog1.FileName, path + txt_name.Text);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        color = "";
                    }
                    else
                    {
                        MessageBox.Show("Please Type A Name First", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                                  
                }
                else
                {

                    if (btn_update.Enabled == true)
                    {
                        if (txt_name.Text != "")
                        {
                            //System.IO.File.Copy(openFileDialog1.FileName, path + txt_name.Text);
                            pictureBox1.Show();
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            // pn_displaybutton.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            color = "";

                            pn_displaybutton.BackColor = Color.Empty;

                            btn_darkblue.Image = null;
                            btn_darkgreen.Image = null;
                            btn_blue.Image = null;
                            btn_goldenrod.Image = null;
                            btn_red.Image = null;
                            btn_mediumblue.Image = null;
                            btn_limegreen.Image = null;
                            btn_firebrick.Image = null;
                            btn_maroon.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Please Type A Name First", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (pictureBox1.Image != null)
                    {
                        Bitmap image = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                        Bitmap new_image = new Bitmap(image, new Size(150, 100));
                        panel17.BackgroundImage = new_image;
                        panel17.BackgroundImageLayout = ImageLayout.Center;
                        //panel17.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                        panel17.BackColor = Color.Black;
                    }
                }
            }
        }
        



        ToolTip t1 = new ToolTip();
      
        private void btn_selectimage_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Select Image From Disk", btn_selectimage);
        }

        long bytes = 0;
        double kilobytes = 0;
        //private bool btnsave_clicked;
        private void btn_save_Click(object sender, EventArgs e)
        {
            //btnsave_clicked = true;
            if (cbo_applicabletimeperiod.SelectedIndex == 1 && txt_selecteddays.Text == "")
            {
                MessageBox.Show("Please Select Days From Below", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cbo_category.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Choose a Category");
                }
                else if (txt_name.Text == "" || txt_costprice.Text == "" || txt_sellingprice.Text == "" || txt_discount.Text == "" || cbo_category.Text == "" || cbo_kot_print.Text == "" || cbo_applicabletimeperiod.Text == "")
                {
                    MessageBox.Show("Please Fill The Required Fields");
                }
                else if (kilobytes > 200)
                {
                    MessageBox.Show("Image Size Mustn't Be Greater Than 200KB !!", "Small Image Size Alert !!");
                }
                else
                {
                    DataTable dt = bllpro.get_item_byname(txt_name.Text);
                    if (dt.Rows.Count == 0)
                    {
                        if (txt_discount.Text=="")
                        {
                            txt_discount.Text = "0.00";
                        }
                       
                        int save;
                        if (color != "")
                        {
                            save = bllpro.addproductitems(txt_name.Text, Convert.ToDecimal(txt_costprice.Text), Convert.ToDecimal(txt_sellingprice.Text), Convert.ToInt32(cbo_category.SelectedValue), cbo_kot_print.Text, new byte[0], cbo_applicabletimeperiod.Text, color,Convert.ToDecimal(txt_discount.Text));
                        }
                        else
                        {
                         
                            img = (byte[])imgCon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                            save = bllpro.addproductitems(txt_name.Text, Convert.ToDecimal(txt_costprice.Text), Convert.ToDecimal(txt_sellingprice.Text), Convert.ToInt32(cbo_category.SelectedValue), cbo_kot_print.Text, img, cbo_applicabletimeperiod.Text, "", Convert.ToDecimal(txt_discount.Text));
                        }
                        if (save > 0)
                        {
                            
                           
                            }
                            DataTable dt1 = bllpro.getitemby_dec();
                            int a = Convert.ToInt32(dt1.Rows[0]["item_id"].ToString());
                            if (cbo_applicabletimeperiod.SelectedIndex == 1)
                            {
                                foreach (string days in txt_selecteddays.Text.Split(','))
                                {
                                    int aa = bllpro.adddays(a, days);
                                }
                            }
                            MessageBox.Show("Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_name.Text = "";
                            txt_costprice.Text = "";
                            txt_sellingprice.Text = "";
                           // loadcategory();
                            cbo_kot_print.Text = "K1";
                            txt_discount.Text = "0.00";
                            lbl_estimatecost.Hide();
                            pictureBox1.Image = null;
                            cbo_applicabletimeperiod.Text = "Always";
                            txt_selecteddays.Text = "";
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
                                checkedListBox1.SetItemChecked(i, false);
                            }
                            pn_displaybutton.BackColor = btn_darkblue.BackColor;
                            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                            btn_darkgreen.Image = null;
                            btn_blue.Image = null;
                            btn_goldenrod.Image = null;
                            btn_red.Image = null;
                            btn_mediumblue.Image = null;
                            btn_limegreen.Image = null;
                            btn_firebrick.Image = null;
                            btn_maroon.Image = null;
                            panel17.BackgroundImage = null;
                          
                        
                    }
                    else
                    {
                        MessageBox.Show("This Menu Item Has Been Already Inserted", "Fail To Inserted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            user_log_insert();
        }
        public void user_log_insert()
        {
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            int abc = bulg.createuserlog(user_name_log, "ADD Menu Item", date, day);

        }
        private void btn_update_Click(object sender, EventArgs e)
        {

            //try
            //{
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["menuupdate"].ToString() == "True")
                    {
                        if (txt_name.Text == "" || txt_costprice.Text == "" || txt_sellingprice.Text == "" || cbo_category.Text == "" || txt_discount.Text == "" || cbo_applicabletimeperiod.Text == "" || cbo_kot_print.Text == "" || cbo_category.Text == "Choose One" || cbo_category.SelectedIndex == 0)
                        {
                            MessageBox.Show("Fill The Required Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (kilobytes > 200)
                        {
                            MessageBox.Show("Image Size Mustn't Be Greater Than 200KB !!", "Small Image Size Alert !!");
                        }
                        else
                        {
                            int b = bllpro.deleterecords(item_id);
                            if (b > 0)
                            {
                                foreach (string days in txt_selecteddays.Text.Split(','))
                                {
                                    int aa = bllpro.adddays(item_id, days);
                                }
                            }

                            int update;
                            DataTable dt = bllpro.getimage_namebyitem_id(item_id);
                            string image_name = dt.Rows[0]["image_name"].ToString();
                            if (color != "")
                            {

                                update = bllpro.updateproductitems(item_id, txt_name.Text, Convert.ToInt32(cbo_category.SelectedValue), Convert.ToDecimal(txt_costprice.Text), Convert.ToDecimal(txt_sellingprice.Text), cbo_applicabletimeperiod.Text, cbo_kot_print.Text, new byte[0], color, Convert.ToDecimal(txt_discount.Text));
                            }
                            else
                            {

                                img = (byte[])imgCon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                                update = bllpro.updateproductitems(item_id, txt_name.Text, Convert.ToInt32(cbo_category.SelectedValue), Convert.ToDecimal(txt_costprice.Text), Convert.ToDecimal(txt_sellingprice.Text), cbo_applicabletimeperiod.Text, cbo_kot_print.Text, img, "", Convert.ToDecimal(txt_discount.Text));
                            }
                            if (update > 0)
                            {
                                if (Convert.ToDecimal(update_item_price) != Convert.ToDecimal(txt_sellingprice.Text))
                                {
                                    update_item();
                                }
                                MessageBox.Show("Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt_name.Text = "";
                                txt_costprice.Text = "";
                                txt_sellingprice.Text = "";
                                loadcategory();
                                cbo_kot_print.Text = "K1";
                                txt_discount.Text = "";
                                lbl_estimatecost.Hide();
                                pictureBox1.Image = null;
                                cbo_applicabletimeperiod.Text = "Always";
                                btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                                pn_displaybutton.BackColor = btn_darkblue.BackColor;
                                btn_darkgreen.Image = null;
                                btn_blue.Image = null;
                                btn_goldenrod.Image = null;
                                btn_red.Image = null;
                                btn_mediumblue.Image = null;
                                btn_limegreen.Image = null;
                                btn_firebrick.Image = null;
                                btn_maroon.Image = null;
                                btn_update.Enabled = false;

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Update Menu ALert !!", "No Access Alert !!");
                    }
                }
            }
            // }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        BLL_Item_update_record bliur =new BLL_Item_update_record();
       
        public void update_item()
        {
            string user_name = Login.sendtext;
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            if (color != "")
            {
                int update_item = bliur.insert_update_record(item_id, txt_name.Text, Convert.ToDecimal(txt_costprice.Text), Convert.ToInt32(update_item_price), Convert.ToInt32(cbo_category.SelectedValue), cbo_kot_print.Text,new byte[0],cbo_applicabletimeperiod.Text, color, DateTime.Now, user_name);
            }
            else
            {
                img = (byte[])imgCon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                int update_item = bliur.insert_update_record(item_id, txt_name.Text, Convert.ToDecimal(txt_costprice.Text), Convert.ToInt32(update_item_price), Convert.ToInt32(cbo_category.SelectedValue), cbo_kot_print.Text, img, cbo_applicabletimeperiod.Text, "", date, user_name);

            }
        }
        bool app_period;
        private void cbo_applicabletimeperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_applicabletimeperiod.SelectedIndex == 1)
            {
                checkedListBox1.Show();               
                ADDMenuItem.Animate(panel18, ADDMenuItem.Effect.Slide, 150, 90);
                ADDMenuItem.Animate(panel16, ADDMenuItem.Effect.Slide, 150, 90);               
                app_period = true;
            }
            else if (cbo_applicabletimeperiod.SelectedIndex == 0)
            {
                if (app_period == true)
                {
                    
                    ADDMenuItem.Animate(panel18, ADDMenuItem.Effect.Slide, 150, 270);
                    ADDMenuItem.Animate(panel16, ADDMenuItem.Effect.Slide, 150, 270);
                    app_period = false;
                }

            }
        }

        List<string> days_selected = new List<string> { };
        string days_with_comma;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = checkedListBox1.SelectedIndex;
            if (selected >= 0)
            {
                if (checkedListBox1.GetItemCheckState(selected) == CheckState.Checked)
                {

                    if (selected != -1)
                    {
                        days_selected.Add(checkedListBox1.Items[selected].ToString());
                        days_with_comma = string.Join(",", days_selected);
                        txt_selecteddays.Text = days_with_comma;
                    }
                }
                else
                {
                    if (selected != -1)
                    {
                        days_selected.Add(checkedListBox1.Items[selected].ToString());
                        foreach (string abc in days_selected.ToArray())
                        {
                            if (abc == checkedListBox1.Items[selected].ToString())
                            {
                                days_selected.Remove(abc);
                                days_with_comma = string.Join(",", days_selected);
                                txt_selecteddays.Text = days_with_comma;
                            }
                        }
                    }
                }

            }
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbo_category_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbo_category_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        bool text_value;
        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            lbl_preview_name.Text = txt_name.Text;
            panel17.BackColor = btn_darkblue.BackColor;
            if (text_value == false)
            {
                if (txt_name.TextLength == 1)
                {
                    ADDMenuItem.Animate(panel17, ADDMenuItem.Effect.Slide, 150, 90);
                    text_value = true;
                }

            }
            else
            {
                if (txt_name.TextLength == 0)
                {
                    ADDMenuItem.Animate(panel17, ADDMenuItem.Effect.Slide, 150, 90);
                    text_value = false;
                }
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
        private void txt_sellingprice_TextChanged(object sender, EventArgs e)
        {
            lbl_preview_selling_price.Text = txt_sellingprice.Text;
            lbl_preview_selling_price.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
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
                int CurrId = item_id;
                Control ctls = this.Parent;
                AddMenuItemList alls = new AddMenuItemList();
                ctls.Controls.Clear();
                ctls.Controls.Add(alls);
            }
        }

        private void btn_inclusive_vat_Click(object sender, EventArgs e)
        {
            txt_sellingprice.Text = Convert.ToString(Convert.ToDecimal(0.13)* Convert.ToDecimal(txt_sellingprice.Text)+Convert.ToDecimal(txt_sellingprice.Text));
            txt_sellingprice.ReadOnly = true;
        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
