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
    public partial class AddCategoryGrouping : UserControl
    {
        public AddCategoryGrouping()
        {
            InitializeComponent();
        }

       
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string color;
        List<string> days_selected = new List<string> { };

        ImageConverter imgcon = new ImageConverter();
      
     

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

    
        public void show_in_datagridview()
        {
            DataTable dt = blcg.getallItemcategoryGrouping();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category"].Value = dt.Rows[i]["group_name"].ToString();
                   
                }
            }
            dataGridView1.ClearSelection();
        }

        public static int category_id;
        private void AddCategory_Load(object sender, EventArgs e)
        {
            category_id = 0;
            show_in_datagridview();           
            btn_update.Enabled = false;
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            color = "DarkBlue";
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
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

        int id;
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
         

            if (dataGridView1.SelectedRows.Count > 0)
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;

                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_category_id"].Value);
                DataTable dt = blcg.getallitemcategoryGrouping(id);
                if (dt.Rows.Count > 0)
                {
                    txt_group_name.Text = dt.Rows[0]["group_name"].ToString();

                    string category_color_chk = dt.Rows[0]["button_colour"].ToString();
                    if (category_color_chk != null && category_color_chk != "")
                    {
                        btn_darkblue.Image = null;
                        string category_color = dt.Rows[0]["button_colour"].ToString();
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
                }
            }

            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            show_in_datagridview();
            txt_group_name.Text = "";
            category_id = 0;
         
            pn_displaybutton.BackColor = btn_darkblue.BackColor;
            btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
            pn_displaybutton.Show();
            pn_displaybutton.BringToFront();
          
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
                if (txt_group_name.Text == "")
                {
                    MessageBox.Show("Please Enter Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
                else
                {
                       int update = blcg.updateCategoryGrouping(id,txt_group_name.Text,color);
                        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pn_displaybutton.Show();
                        pn_displaybutton.BringToFront();
                        pn_displaybutton.BackColor = btn_darkblue.BackColor;
                        btn_darkblue.Image = global::POS_System.Properties.Resources._checked;
                        show_in_datagridview();
                        txt_group_name.Text = "";                     
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
                       

                    }

                }
        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_group_name.Text == "" || txt_group_name.Text.Length < 0)
            {

                MessageBox.Show("Group Name is empty.", "Empty!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int insert = blcg.insertCategoryGrouping(txt_group_name.Text, color);
                if (insert > 0)
                {
                    btn_refresh_Click(null, null);
                }
            }
        }
    }
    }

