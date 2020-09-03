using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using BLLS;

namespace POS_System
{
    public partial class AddIMenuCategory : UserControl
    {
        public AddIMenuCategory()
        {
            InitializeComponent();
        }

         BLLItemcategory bllcat = new BLLItemcategory();
        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\POS\\Category Image\\";
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string color;
        List<string> days_selected = new List<string> { };
        string days_with_comma;
        byte[] img = null;
        ImageConverter imgcon = new ImageConverter();
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

        bool app_period;
        private void cbo_applicabletimeperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_applicabletimeperiod.SelectedIndex == 1)
            {
                if (app_period == false)
                {
                    //checkedListBox1.Show();
                    AddIMenuCategory.Animate(panel18, AddIMenuCategory.Effect.Slide, 150, 90);
                    AddIMenuCategory.Animate(panel16, AddIMenuCategory.Effect.Slide, 150, 90);
                    app_period = true;
                }
            }
            else if (cbo_applicabletimeperiod.SelectedIndex == 0)
            {
                if (app_period == true)
                {
                    AddIMenuCategory.Animate(panel18, AddIMenuCategory.Effect.Slide, 150, 270);
                    AddIMenuCategory.Animate(panel16, AddIMenuCategory.Effect.Slide, 150, 270);
                    app_period = false;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                    txt_selecteddays.Text = "";
                    days_selected.Clear();
                    days_with_comma = "";
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

        private void btn_selectimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\Program File";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            pictureBox1.Controls.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                color = "";
                if (!Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);

                    if (btn_update.Enabled != true)
                    {
                        if (txt_category.Text != "")
                        {
                            pictureBox1.BringToFront();
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
                        category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_category_id"].Value);
                        DataTable dt = bllcat.getcategorybycategory_id(category_id);
                        string category_image = dt.Rows[0]["category_image"].ToString();
                        if (category_image.Length > 0)
                        {
                            pictureBox1.BringToFront();
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            color = "";
                        }
                    }
                }
                else
                {

                    if (btn_update.Enabled != true)
                    {
                        if (txt_category.Text != "")
                        {
                            pictureBox1.Show();
                            pictureBox1.BringToFront();
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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
                    else
                    {
                        category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_category_id"].Value);
                        if (category_id > 0)
                        {
                            DataTable dtb = bllcat.getcategorybycategory_id(category_id);
                            if (dtb.Rows.Count > 0)
                            {
                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Controls.Clear();
                                    pictureBox1.Image.Dispose();
                                    pictureBox1.BringToFront();
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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
                                    pictureBox1.BringToFront();
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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
                            }
                        }
                    }
                }
            }
        }

        public void show_in_datagridview()
        {
            DataTable dt = bllcat.getcategories();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category"].Value = dt.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_applicable_time"].Value = dt.Rows[i]["applicable_time"].ToString();
                }
            }
            dataGridView1.ClearSelection();
        }

        public void add_items_in_checklistbox()
        {
            checkedListBox1.Items.Add("Sunday");
            checkedListBox1.Items.Add("Monday");
            checkedListBox1.Items.Add("Tuesday");
            checkedListBox1.Items.Add("Wednesday");
            checkedListBox1.Items.Add("Thursday");
            checkedListBox1.Items.Add("Friday");
            checkedListBox1.Items.Add("Saturday");
        }

        public void add_items_in_combobox()
        {
            cbo_applicabletimeperiod.Items.Add("Always");
            cbo_applicabletimeperiod.Items.Add("Days of Week");
            cbo_applicabletimeperiod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_applicabletimeperiod.SelectedIndex = 0;
        }

        public static int category_id;
        private void AddCategory_Load(object sender, EventArgs e)
        {
            category_id = 0;
            show_in_datagridview();
            add_items_in_checklistbox();
            add_items_in_combobox();
            panel18.Hide();
            panel16.Hide();
            btn_update.Enabled = false;
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            color = "DarkBlue";
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            loadcategory();
        }


        public void loadcategory()
        {
            DataTable dt = blcg.getallItemcategoryGrouping();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["group_name"] = "Choose Category";
                dr["id"] = "0";
                dt.Rows.InsertAt(dr, 0);

                cbo_group_category.DataSource = dt;
                cbo_group_category.DisplayMember = "group_name";
                cbo_group_category.ValueMember = "id";
            }
        }
        private void btn_darkblue_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            color = "DarkBlue";
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_mediumblue_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_mediumblue.BackColor;
            color = "MediumBlue";
            btn_mediumblue.Image = global::POS_System.Properties.Resources._checked;
            btn_darkblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_blue.BackColor;
            color = "Blue";
            btn_blue.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_darkblue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_maroon_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_maroon.BackColor;
            color = "Maroon";
            btn_maroon.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_darkblue.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_firebrick_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_firebrick.BackColor;
            color = "Firebrick";
            btn_firebrick.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_darkblue.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_red.BackColor;
            color = "Red";
            btn_red.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_darkgreen_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_darkgreen.BackColor;
            color = "DarkGreen";
            btn_darkgreen.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkblue.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_limegreen_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_limegreen.BackColor;
            color = "LimeGreen";
            btn_limegreen.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_darkblue.Image = null;
            btn_goldenrod.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }

        private void btn_goldenrod_Click(object sender, EventArgs e)
        {
            pn_displaybutton.BackColor = btn_goldenrod.BackColor;
            color = "Goldenrod";
            btn_goldenrod.Image = global::POS_System.Properties.Resources._checked;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_darkblue.Image = null;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_darkblue.Image = null;
            btn_darkgreen.Image = null;
            btn_red.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_goldenrod.Image = null;
            btn_limegreen.Image = null;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            //pn_displaybutton.Hide();
            days_selected.Clear();
            days_with_comma = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    int category_id = Convert.ToInt32(dr.Cells["col_category_id"].Value);
                    DataTable dt = bllcat.getcategorybycategory_id(category_id);
                    if (dt.Rows.Count > 0)
                    {
                        txt_category.Text = dt.Rows[0]["category_name"].ToString();
                        cbo_applicabletimeperiod.Text = dt.Rows[0]["applicable_time"].ToString();
                        string category_color_chk = dt.Rows[0]["category_color"].ToString();
                        int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        DataTable dt1 = blcg.getallitemcategoryGrouping(id);
                        if (dt1.Rows.Count>0)
                        {
                            cbo_group_category.Text = dt1.Rows[0]["group_name"].ToString();
                        }
                        else
                        {
                            if(cbo_group_category.Text!="")
                            cbo_group_category.SelectedIndex = 0;
                        }
                        if (category_color_chk != null&& category_color_chk != "")
                        {
                            btn_darkblue.Image = null;
                            string category_color = dt.Rows[0]["category_color"].ToString();
                            if (category_color.Length != 0)
                            {
                                pn_displaybutton.BackColor = Color.FromName(category_color);
                                color = category_color;
                                pn_displaybutton.BringToFront();
                                if (btn_blue.BackColor == Color.FromName(category_color))
                                {
                                    btn_blue.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_darkblue.BackColor == Color.FromName(category_color))
                                {
                                    btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_mediumblue.BackColor == Color.FromName(category_color))
                                {
                                    btn_mediumblue.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_darkgreen.BackColor == Color.FromName(category_color))
                                {
                                    btn_darkgreen.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_firebrick.BackColor == Color.FromName(category_color))
                                {
                                    btn_firebrick.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_goldenrod.BackColor == Color.FromName(category_color))
                                {
                                    btn_goldenrod.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_limegreen.BackColor == Color.FromName(category_color))
                                {
                                    btn_limegreen.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_maroon.BackColor == Color.FromName(category_color))
                                {
                                    btn_maroon.Image = global::POS_System.Properties.Resources._checked;
                                }
                                else if (btn_red.BackColor == Color.FromName(category_color))
                                {
                                    btn_red.Image = global::POS_System.Properties.Resources._checked;
                                }
                            }

                        }
                        else
                        {
                            Byte[] image = (byte[])dt.Rows[0]["category_image"];
                            var img_cat = new MemoryStream(image);
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = System.Drawing.Image.FromStream(img_cat);
                            pictureBox1.BringToFront();
                            pn_displaybutton.BackColor = Color.Empty;
                            color = "";
                            
                        }

                        DataTable dtb = bllcat.getcategory_dayswisebycategory_id(category_id);
                        if (dtb.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtb.Rows.Count; i++)
                            {
                                string data_save = dtb.Rows[i]["days"].ToString();
                                days_selected.Add(data_save);
                                days_with_comma = string.Join(",", days_selected);
                                txt_selecteddays.Text = days_with_comma;
                                int index = checkedListBox1.Items.IndexOf(data_save);
                                if (index >= 0)
                                {
                                    checkedListBox1.SetItemChecked(index, true);
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Controls.Clear();
                pictureBox1.Image.Dispose();
            }
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    int category_id = Convert.ToInt32(dr.Cells["col_category_id"].Value);
                    if (category_id > 0)
                    {
                       
                        int delete_category = bllcat.delete_category(category_id);
                        int delete_category_dayswise = bllcat.delete_category_dayswise(category_id);                      
                        if (delete_category > 0)
                        {
                            MessageBox.Show("Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            show_in_datagridview();
            txt_category.Text = "";
            category_id = 0;
            cbo_applicabletimeperiod.SelectedIndex = 0;
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
            txt_selecteddays.Text = "";
            for (int index = 0; index < checkedListBox1.Items.Count; ++index)
            {
                checkedListBox1.SetItemChecked(index, false);
            }
            checkedListBox1.ClearSelected();
            days_with_comma = "";
            days_selected.Clear();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_mediumblue.Image = null;
            btn_blue.Image = null;
            btn_maroon.Image = null;
            btn_firebrick.Image = null;
            btn_red.Image = null;
            btn_darkgreen.Image = null;
            btn_limegreen.Image = null;
            btn_goldenrod.Image = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
                if (txt_category.Text == "")
                {
                    MessageBox.Show("Please Enter Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbo_applicabletimeperiod.SelectedIndex == 1 && txt_selecteddays.Text == "")
                {
                    MessageBox.Show("Please Select Days From Below", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                
                    int update;
                    category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_category_id"].Value);
                    DataTable dt = bllcat.getcategorybycategory_id(category_id);
                    string category_image = dt.Rows[0]["category_image"].ToString();

                    if (color != "")
                    {

                        update = bllcat.update_category(category_id, txt_category.Text, new byte[0], color, cbo_applicabletimeperiod.Text, Convert.ToInt32(cbo_group_category.SelectedValue));
                    }
                    else
                    {

                        img = (byte[])imgcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                        update = bllcat.update_category(category_id, txt_category.Text, img, "", cbo_applicabletimeperiod.Text, Convert.ToInt32(cbo_group_category.SelectedValue));
                    }
                    if (update > 0)
                    {
                        if (dt.Rows[0]["applicable_time"].ToString() == "Days of Week")
                        {
                            int deletefrom_dayswise = bllcat.delete_dayswise_records(category_id);
                            if (deletefrom_dayswise > 0)
                            {
                                if (cbo_applicabletimeperiod.SelectedIndex == 1)
                                {
                                    foreach (string days in txt_selecteddays.Text.Split(','))
                                    {
                                        int aa = bllcat.adddays(category_id, days);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cbo_applicabletimeperiod.SelectedIndex != 0)
                            {
                                foreach (string days in txt_selecteddays.Text.Split(','))
                                {
                                    int aa = bllcat.adddays(category_id, days);
                                }
                            }
                        }


                        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pn_displaybutton.Show();
                        pn_displaybutton.BringToFront();
                        pn_displaybutton.BackColor = btn_darkblue.BackColor;
                        btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                        show_in_datagridview();
                        txt_category.Text = "";
                        cbo_group_category.SelectedIndex = 0;
                        cbo_applicabletimeperiod.SelectedIndex = 0;
                        btn_darkgreen.Image = null;
                        btn_blue.Image = null;
                        btn_goldenrod.Image = null;
                        btn_red.Image = null;
                        btn_mediumblue.Image = null;
                        btn_limegreen.Image = null;
                        btn_firebrick.Image = null;
                        btn_maroon.Image = null;
                        btn_update.Enabled = false;
                        btn_save.Enabled = true;
                        category_id = 0;
                        openFileDialog1.FileName = null;
                        checkedListBox1.ClearSelected();

                    }

                }
            
    
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (txt_category.Text == "")
            {
                MessageBox.Show("Please Enter Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbo_applicabletimeperiod.SelectedIndex == 1 && txt_selecteddays.Text == "")
            {
                MessageBox.Show("Please Select Days From Below", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataTable dt = bllcat.get_all_category_by_name(txt_category.Text);
                DateTime date = Convert.ToDateTime(DateTime.Now.ToString());

                if (dt.Rows.Count == 0)
                {
                    int save;
                    if (color != "")
                    {
                        save = bllcat.add_category(txt_category.Text, new byte[0], color, cbo_applicabletimeperiod.Text,Convert.ToInt32(cbo_group_category.SelectedValue));
                    }
                    else
                    {

                        img = (byte[])imgcon.ConvertTo(pictureBox1.Image, typeof(byte[]));
                        save = bllcat.add_category(txt_category.Text, img, "", cbo_applicabletimeperiod.Text, Convert.ToInt32(cbo_group_category.SelectedValue));
                    }
                    if (save > 0)
                    {
                        DataTable dt1 = bllcat.getcategorybyid_desc();
                        int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                        if (cbo_applicabletimeperiod.SelectedIndex == 1)
                        {
                            foreach (string days in txt_selecteddays.Text.Split(','))
                            {
                                int aa = bllcat.adddays(category_id, days);
                            }
                        }
                        MessageBox.Show("Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pn_displaybutton.Show();
                        pn_displaybutton.BringToFront();
                        txt_category.Text = "";
                        cbo_applicabletimeperiod.Text = "Always";
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
                        show_in_datagridview();
                        category_id = 0;
                        txt_selecteddays.Text = "";
                        for (int index = 0; index < checkedListBox1.Items.Count; index++)
                        {
                            checkedListBox1.SetItemChecked(index, false);
                        }
                        checkedListBox1.ClearSelected();
                        days_selected.Clear();
                        days_with_comma = "";
                        color = "DarkBlue";
                    }

                }
                else
                {
                    MessageBox.Show("This Category Has Been Already Inserted", "Fail To Insert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            user_log_insert();
        }
        public void user_log_insert()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(user_name_log, day, "AddMenuCategory");

            if (dt.Rows.Count == 0)
            {
                int abc = bulg.createuserlog(user_name_log, "AddMenuCategory", date, day);

            }
        }
    }
}
