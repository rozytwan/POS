using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Table_Management
{
    public partial class Table_create_edit : UserControl
    {
        public Table_create_edit()
        {
            InitializeComponent();
           

        }
        Button[] pictureBox1 = new Button[8];
        Button[] pictureBox2 = new Button[1000];
     
        Button btn_area = new Button();
        BLLTable_Area blta = new BLLTable_Area();
        BLLOrder blod = new BLLOrder();
        BLLTable bltable = new BLLTable();
        int xy = 4;
        BLLTable blt = new BLLTable();
        List<string> li = new List<string>();
        string new_item_drag="";
        string image_name="";
        int table_no=0;
        public static string area_name="";
        int area_id=0;
     
        private void Form1_Load(object sender, EventArgs e)
        {
            pic_load();
            panel1.AllowDrop = true;
            pic_load_with_table_info();
            area_button();
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
        }
      
        
        public void pic_load()
        {           
            li.Add("Large");
            li.Add("cricle");
            li.Add("single_h");
            li.Add("single_v");
            for (int x = 0; xy > x; x++)
            {
                pictureBox1[x] = new Button();
                pictureBox1[x].AllowDrop = true;                    
                pictureBox1[x].Name = li[x];               
                pictureBox1[x].Size = new System.Drawing.Size(63, 71);
                Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(li[x]);
                Bitmap resizeds = new Bitmap(images, new Size(63, 71));
                pictureBox1[x].Image = resizeds;
                pictureBox1[x].BackColor = Color.Transparent;
                pictureBox1[x].FlatAppearance.BorderSize = 0;
                pictureBox1[x].ForeColor = Color.White;
                pictureBox1[x].FlatStyle = FlatStyle.Flat;
                pictureBox1[x].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);           
                flowLayoutPanel1.Controls.Add(pictureBox1[x]);
            }
        }
        Label [] lbl_table_name = new Label[1000];
        public void pic_load_with_table_info()
        {
            DataTable dt = blt.get_all_rest_table_info(area_id);
            panel1.Controls.Clear();
                if (dt.Rows.Count > 0)
                {               
                    for (int x = 0; dt.Rows.Count >x; x++)
                    {
                        int position_x =Convert.ToInt32(dt.Rows[x]["position_X"].ToString());
                        int position_y = Convert.ToInt32(dt.Rows[x]["position_Y"].ToString());
                        string _image_name = dt.Rows[x]["image_name"].ToString();
                     pictureBox2[x] = new Button();
                    lbl_table_name[x] = new Label();
                    lbl_table_name[x].Text= dt.Rows[x]["rest_table_no"].ToString();
                    lbl_table_name[x].Location = new Point(40,80);
                    lbl_table_name[x].ForeColor = Color.Black;
                 
                    Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name);                 
                    pictureBox2[x].Text= dt.Rows[x]["rest_table_name"].ToString();
                    pictureBox2[x].Location = new Point(position_x, position_y);
                    pictureBox2[x].Name = dt.Rows[x]["rest_table_no"].ToString();
                    pictureBox2[x].BackColor = Color.Transparent;
                    pictureBox2[x].FlatAppearance.BorderSize = 0;
                    pictureBox2[x].ForeColor = Color.White;
                    pictureBox2[x].FlatStyle = FlatStyle.Flat;
                   
                    if (_image_name == "Large")
                    {
                        pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                        Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                        pictureBox2[x].Image = resizeds;

                    }
                    else if (_image_name == "cricle")
                    {
                        pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                        Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                        pictureBox2[x].Image = resizeds;

                    }
                    else
                    {
                        pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                        Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                        pictureBox2[x].Image = resizeds;

                    }                                               
                    pictureBox2[x].MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);                   
                    pictureBox2[x].Click += new System.EventHandler(this.PictureBox2_Click);
                    panel1.Controls.Add(pictureBox2[x]);
                    pictureBox2[x].Controls.Add(lbl_table_name[x]);

                }               
              }
            reserved_checker();


        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;

            // add border, do whatever else you want.
        }
        public void area_button()
        {
            DataTable dt = blta.get_all_data();
            flowLayoutPanel2.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    btn_area = new Button();
                    btn_area.Text= dt.Rows[x]["area_name"].ToString();
                    btn_area.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(50, 50));
                    btn_area.Name = dt.Rows[x]["area_id"].ToString();
                    btn_area.Size = new System.Drawing.Size(63, 71);                
                    btn_area.ForeColor = Color.White;
                    btn_area.FlatStyle = FlatStyle.Flat;
                    btn_area.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
                    btn_area.FlatAppearance.BorderSize = 0;
                    btn_area.Click += new System.EventHandler(this.btn_area_click);
                    flowLayoutPanel2.Controls.Add(btn_area);
                    btn_area.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                }
            }
        }

    
        private void btn_area_click(object sender, EventArgs e)
        {
            area_name = (((Button)sender).Text).ToString();
            area_id = Convert.ToInt32((((Button)sender).Name).ToString());
            if (area_id > 0)
            {
                pic_load_with_table_info();
            }

        }
        Table_update tblup = new Table_update();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                image_name = (((Button)sender).Name).ToString();
                if (image_name.Length > 3)
                {
                    new_item_drag = "New";

                }
                else
                {
                    table_no = Convert.ToInt32(image_name);
                    new_item_drag = "Old";
                }
                ((Button)sender).DoDragDrop(((Button)sender), DragDropEffects.Copy);

            }
            else if (e.Button == MouseButtons.Right)
            {
                tblup.table_no = (((Button)sender).Name).ToString();

                tblup.ShowDialog();
               
            }
        }
      
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        bool tnc_chk;
        int new_table_no;
        string new_table_name;
     
        private void panel1_DragDrop_1(object sender, DragEventArgs e)
        {
            try
            {
                if (new_item_drag == "New")
                {
                    if (area_name != "" && area_name != null)
                    {
                        Table_new_insert tnc = new Table_new_insert();
                        tnc.ShowDialog();
                        tnc_chk = Table_new_insert.dig_reg;
                     
                        if (tnc_chk == true)
                        {
                            new_table_no = Convert.ToInt32(Table_new_insert.table_no);

                            new_table_name = tnc.table_name;
                            if (image_name.Length > 0)
                            {

                                int abc = blt.insertintotable(new_table_no);
                                int inser_table_info = blt.insertintotable_info(new_table_no,new_table_name, e.X - 185, e.Y - 75, image_name, area_id);
                                Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
                                ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
                                ctrl.Location = ((Panel)sender).PointToClient(new Point(e.X, e.Y));
                                flowLayoutPanel1.Controls.Clear();
                                pic_load();
                                panel1.Controls.Clear();
                                pic_load_with_table_info();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Choose Area", "Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (new_item_drag == "Old")
                {
                    if (table_no > 0)
                    {
                        int update_position = blt.update_table_location(table_no, e.X - 185, e.Y - 75);
                        Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
                        ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
                        ctrl.Location = ((Panel)sender).PointToClient(new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_area_Click(object sender, EventArgs e)
        {
            Table_area_create tar = new Table_area_create();
            tar.ShowDialog();
            area_button();

        }

        private void pictureBox3_DragDrop(object sender, DragEventArgs e)
        {
            if (table_no > 0)
            {
                DialogResult dig = MessageBox.Show("Do You Like To Delete Table ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    int delete_table = blt.delete_table(table_no);
                    if (delete_table > 0)
                    {
                        int delete_int = blt.delete_table_info(table_no);
                        pic_load_with_table_info();
                        pictureBox3.Image = global::POS_System.Properties.Resources.Delete_Empty;
                    }
                }
            }
        }

        private void pictureBox3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox3_DragOver(object sender, DragEventArgs e)
        {
            pictureBox3.Image= global::POS_System.Properties.Resources.Delete_Empty2;
        }

        private void pictureBox3_DragLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = global::POS_System.Properties.Resources.Delete_Empty;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
        BLLReserved blres = new BLLReserved();
        private void btn_table_reserved_DragDrop(object sender, DragEventArgs e)
        {
            if (table_no > 0)
            {
                DataTable dt = blres.get_value_by_table_no(table_no);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Table No " + table_no + " Has Been Already Reserved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int abc = blres.insert_to_reserved(table_no);
                    if (abc > 0)
                    {
                        reserved_checker();
                        MessageBox.Show("Table No " + table_no + " Has Been Reserved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void btn_table_reserved_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        public void reserved_checker()
        {
            DataTable dt = blt.get_all_rest_table_info(area_id);
            for (int y = 0; y < dt.Rows.Count; y++)
            {
                int rest_table_no = Convert.ToInt32(dt.Rows[y]["rest_table_no"].ToString());
                DataTable dtmss = blres.get_value_by_table_no(Convert.ToInt32(rest_table_no));
                if (dtmss.Rows.Count > 0)
                {
                    int abc = (int)Convert.ToDecimal((dtmss.Rows[0]["table_no"].ToString()));
                    DataTable dt_check = blt.chheck_table_info(abc.ToString());
                    if (dt_check.Rows.Count > 0)
                    {
                        Bitmap images = global::POS_System.Properties.Resources.Reserved;
                        Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                        pictureBox2[y].Image = resizeds;
                        pictureBox2[y].BackColor = Color.White;
                        pictureBox2[y].Size = new System.Drawing.Size(100, 71);
                    }
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
