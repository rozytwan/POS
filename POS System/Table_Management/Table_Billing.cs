using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Table_Management
{
    public partial class Table_Billing : UserControl
    {
        public Table_Billing()
        {
            InitializeComponent();
            loopTimer = new System.Windows.Forms.Timer();
            bool coverup = cd.CoverUpDynamic();
            if (coverup == true)
            {
                loopTimer.Interval = 2000;
                loopTimer.Enabled = true;
                loopTimer.Tick += loopTimerEvent;
            }
            else
            {
                loopTimer.Enabled = false;
            }
           
        }
        string take_away_id;
        public bool long_press = false;
        private System.Windows.Forms.Timer loopTimer;
        BLLTable_Area blta = new BLLTable_Area();
        BLLTable blt = new BLLTable();
        BLLOrder blod = new BLLOrder();
        BLLTakeAway bltk = new BLLTakeAway();
        Button[] pictureBox2 = new Button[1000];
        BLLReserved blres = new BLLReserved();
        BLLPrinterSetting bps = new BLLPrinterSetting();
        Button btn_area = new Button();
        BLLDynamic bld = new BLLDynamic();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        int area_id = 0;
        public static string area_name = "";
        int position_x;
        int position_y;
        Label[] lbl_table_name = new Label[1000];
        public void pic_load_with_table_info()
        {
            DataTable dt = blt.get_all_rest_table_info(area_id);
            panel1.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    int position_x = Convert.ToInt32(dt.Rows[x]["position_X"].ToString());
                    int position_y = Convert.ToInt32(dt.Rows[x]["position_Y"].ToString());

                    string _image_name = dt.Rows[x]["image_name"].ToString();
                    pictureBox2[x] = new Button();
                    lbl_table_name[x] = new Label();
                    lbl_table_name[x].Text = dt.Rows[x]["rest_table_no"].ToString();
                    lbl_table_name[x].Location = new Point(408, 80);
                    lbl_table_name[x].ForeColor = Color.Black;
                    int rest_table_no = Convert.ToInt32(dt.Rows[x]["rest_table_no"].ToString());
                    //Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.dinner;
                    Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name);
                    pictureBox2[x].Text = dt.Rows[x]["rest_table_name"].ToString();
                    pictureBox2[x].TextAlign = ContentAlignment.TopCenter;
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
                        pictureBox2[x].Size = new System.Drawing.Size(80, 95);
                        Bitmap resizeds = new Bitmap(images, new Size(80, 71));
                        pictureBox2[x].Image = resizeds;

                    }
                    else
                    {
                        pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                        Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                        pictureBox2[x].Image = resizeds;

                    }

                    pictureBox2[x].MouseDown += new System.Windows.Forms.MouseEventHandler(newdowntable_Click);
                    pictureBox2[x].MouseUp += new System.Windows.Forms.MouseEventHandler(newupTable_Click);
               


                    DataTable dtmss = blod.getallfromtblorder(rest_table_no);
                    if (dtmss.Rows.Count > 0)
                    {
                        if (_image_name == "Large")
                        {
                            Bitmap images_order = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name + "_21");
                            // Bitmap images_order = global::POS_System.Properties.Resources.dinner;
                            pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                            Bitmap resizeds = new Bitmap(images_order, new Size(100, 71));
                            pictureBox2[x].Image = resizeds;
                        }
                        else if (_image_name == "cricle")
                        {
                            Bitmap images_order = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name + "_21");
                            //Bitmap images_order = (Bitmap)(Image)POS_System.Properties.Resources.dinner;
                            pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                            Bitmap resizeds = new Bitmap(images_order, new Size(80, 71));
                            pictureBox2[x].Image = resizeds;

                        }
                        else if (_image_name == "single_h")
                        {
                            Bitmap images_order = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name + "_21");
                            pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                            Bitmap resizeds = new Bitmap(images_order, new Size(100, 71));
                            pictureBox2[x].Image = resizeds;
                        }
                        else if (_image_name == "single_v")
                        {
                            Bitmap images_order = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject(_image_name + "_21");
                            pictureBox2[x].Size = new System.Drawing.Size(100, 95);
                            Bitmap resizeds = new Bitmap(images_order, new Size(100, 71));
                            pictureBox2[x].Image = resizeds;
                        }

                    }
                    DataTable dtQu = blpst.GetAllQuotationByTableNO(rest_table_no.ToString());
                    if (dtQu.Rows.Count > 0)
                    {
                        Bitmap images_order = global::POS_System.Properties.Resources.LargeGreen;
                        pictureBox2[x].Size = new System.Drawing.Size(120, 80);
                        Bitmap resize = new Bitmap(images_order, new Size(120, 60));
                        pictureBox2[x].Image = resize;
                    }
                    panel1.Controls.Add(pictureBox2[x]);
                    pictureBox2[x].Controls.Add(lbl_table_name[x]);
                }
            }
            reserved_checker();
        }

        string image_name = "";
        string table_num;
   
        public void newdowntable_Click(object sender, MouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Left)
            //{
            //    image_name = (((Button)sender).Name).ToString();
            //    if (image_name.Length > 3)
            //    {
            //        // new_item_drag = "New";

            //    }
            //    else
            //    {
            //        table_no = Convert.ToInt32(image_name);
            //        // new_item_drag = "Old";
            //    }
            //    ((Button)sender).DoDragDrop(((Button)sender), DragDropEffects.Copy);

            //}
            if (e.Button == MouseButtons.Right)
            {
                //Control ctrl = this.Parent;
               // KitchenOrderInfo koi = new KitchenOrderInfo();
                //koi.table_no = (((Button)sender).Name).ToString();
                //ctrl.Controls.Clear();
                //ctrl.Controls.Add(koi);

            }
            //loopTimer.Start();
            label1.Text = ((Button)sender).Name;

        }

        private bool mouseUp = false;
        private const int holdButtonDuration = 2000; //milliseconds
      
     
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
                        Bitmap resizeds = new Bitmap(images, new Size(100, 95));
                        pictureBox2[y].Image = resizeds;

                        pictureBox2[y].Size = new System.Drawing.Size(100, 71);
                    }
                }
            }
        }
        public string table_names;
     
        public void newupTable_Click(object sender, MouseEventArgs e)
        {
           
               
                    label1.Text = ((Button)sender).Name;
                    string table_name = ((Button)sender).Text;
            if (long_press == false)
            {
                loopTimer.Stop();
                    loopTimer.Dispose();
                    Control ctls = this.Parent;
                    if (codeForprinting == "C80")
                    {
                        DataTable dt1 = bld.GetServiceProvider();
                        if (dt1.Rows.Count > 0)
                        {
                            ServiceProviderUser vieret = new ServiceProviderUser();
                            vieret.ShowDialog();
                            KOTOrder ss = new KOTOrder(label1.Text, table_name);
                            ctls.Controls.Clear();
                            ctls.Controls.Add(ss);
                        }
                        else
                        {
                            KOTOrder vieret = new KOTOrder(label1.Text, table_name);
                            ctls.Controls.Clear();
                            ctls.Controls.Add(vieret);
                        }

                    }
                    else
                    {
                        KOTOrder vieret = new KOTOrder(label1.Text, table_name);
                        ctls.Controls.Clear();
                        ctls.Controls.Add(vieret);
                    }
                }
         
            else
            {
                bool coverup = cd.CoverUpDynamic();
                if (coverup==true)
                {
                    Control ctrl = this.Parent;
                    KitchenOrderInfo koi = new KitchenOrderInfo();
                    koi.table_no = (((Button)sender).Name).ToString();
                    //koi.table_names = ((Button)sender).Text;
                    koi.ShowDialog();
                    if (koi.DialogResult == DialogResult.OK)
                    {
                        KOTOrder vieret = new KOTOrder(label1.Text, table_name);
                        ctrl.Controls.Clear();
                        ctrl.Controls.Add(vieret);
                    }
                }
         

            }
            long_press = false;
          
        }
    

        private void loopTimerEvent(object source, EventArgs e)
        {
            long_press =true;          
            loopTimer.Dispose();

        }
        public void area_button()
        {
            DataTable dt = blta.get_all_data();

            if (dt.Rows.Count > 0)
            {
                flowLayoutPanel2.Controls.Clear();
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    btn_area = new Button();
                    btn_area.Text = dt.Rows[x]["area_name"].ToString();
                    btn_area.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(50, 50));
                    btn_area.Name = dt.Rows[x]["area_id"].ToString();
                    btn_area.Size = new System.Drawing.Size(63, 71);
                    btn_area.ForeColor = Color.White;
                    btn_area.FlatStyle = FlatStyle.Flat;
                  
                    if (area_id == Convert.ToInt32(dt.Rows[x]["area_id"]))
                    {
                        btn_area.BackColor = System.Drawing.Color.SlateGray;
                    }
                    else
                    {
                        btn_area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
                    }
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
                ModelAreaId.area_id = area_id;
                pic_load_with_table_info();
                area_button();
            }

        }
        string codeForprinting;
        string TakeawayRename;
        private void Table_Billing_Load(object sender, EventArgs e)
        {
          //  panel1.AllowDrop = true;
            //pictureBox4.AllowDrop = true;
            //this.AllowDrop = true;
            TakeawayRename = second_user_interface.TakeawayRename;
            buttonX3.Text = TakeawayRename;
            DataTable dt_prt = bps.getalldata();
            if (dt_prt.Rows.Count > 0)
            {
                codeForprinting = dt_prt.Rows[0]["bill_printer"].ToString();
            }
            DataTable dt = blta.get_all_data();
            if (dt.Rows.Count > 0)
            {
                if (ModelAreaId.area_id > 0)
                {
                    area_id = ModelAreaId.area_id;
                }
                else
                {
                    area_id = 1;
                }

                pic_load_with_table_info();

            }
            else
            {
                MessageBox.Show("No Table Has Been Added", "Table Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            area_button();
        }
        BLLUser blu = new BLLUser();
        private void btntabletransfer_Click(object sender, EventArgs e)
        {
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["tabletransfer"].ToString() == "True")
                    {
                        TableTransfer tar = new TableTransfer();
                        tar.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Table Transfer ALert !!", "No Access Alert !!");
                    }
                }
            }
        }
        CheckDynamic cd = new CheckDynamic();
        private void btnhomedelivery1_Click(object sender, EventArgs e)
        {

            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["homedelivery"].ToString() == "True")
                    {
                        string homedeliveryload = cd.HomeDeliveryLoad();
                        if (homedeliveryload == "Customer First")
                        {
                            Control ctls = this.Parent;
                            Customer_Management.AllCusomterList vieret = new Customer_Management.AllCusomterList("HD");
                            ctls.Controls.Clear();
                            ctls.Controls.Add(vieret);

                        }
                        else
                        {
                            loopTimer.Stop();
                            loopTimer.Dispose();
                            Control ctls = this.Parent;
                            KOTOrder vieret = new KOTOrder("520", null);
                            ctls.Controls.Clear();
                            ctls.Controls.Add(vieret);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Home Delivery ALert !!", "No Access Alert !!");
                    }
                }
            }
        }

        private void btntakeaway_Click(object sender, EventArgs e)
        {

            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dta = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dta.Rows.Count > 0)
                {
                    if (dta.Rows[0]["takeaway"].ToString() == "True")
                    {
                        DataTable dt = bltk.getmaxNo();
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString() == "")
                            {
                                take_away_id = "1001";
                            }
                            else
                            {
                                int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                                take_away_id = getinvoiceno.ToString();
                                DataTable dtm = bltk.getallfromtable();
                            }
                        }

                        loopTimer.Stop();
                        loopTimer.Dispose();
                        Control ctls = this.Parent;
                        KOTOrder vieret = new KOTOrder(take_away_id, "TA");
                        ctls.Controls.Clear();
                        ctls.Controls.Add(vieret);
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Take Away ALert !!", "No Access Alert !!");
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = blt.get_all_rest_table_info(area_id);
            for (int y = 0; y < dt.Rows.Count; y++)
            {
                int rest_table_no = Convert.ToInt32(dt.Rows[y]["rest_table_no"].ToString());
                DataTable dtmss = blod.getallfromtblorder(Convert.ToInt32(rest_table_no));
                if (dtmss.Rows.Count > 0)
                {
                    int abc = (int)Convert.ToDecimal((dtmss.Rows[0]["table_no"].ToString()));
                    DataTable dt_check = blt.chheck_table_info(abc.ToString());
                    if (dt_check.Rows.Count > 0)
                    {
                        string image_name_check = dt_check.Rows[0]["image_name"].ToString();
                        if (image_name_check == "Large")
                        {
                            Bitmap images = global::POS_System.Properties.Resources.Large_21;
                            Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                            pictureBox2[y].Image = resizeds;
                          
                        }
                        else if (image_name_check == "cricle")
                        {
                            Bitmap images = global::POS_System.Properties.Resources.cricle_21;
                            Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                            pictureBox2[y].Image = resizeds;
                       
                        }
                        else if (image_name_check == "single_v")
                        {
                            Bitmap images = global::POS_System.Properties.Resources.single_v_21;
                            Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                            pictureBox2[y].Image = resizeds;
                          
                        }
                        else if (image_name_check == "single_h")
                        {
                            Bitmap images = global::POS_System.Properties.Resources.single_h_21;
                            Bitmap resizeds = new Bitmap(images, new Size(100, 71));
                            pictureBox2[y].Image = resizeds;
                    
                        }
                    }
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        int table_no = 0;
        private void pictureBox4_DragDrop(object sender, DragEventArgs e)
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

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
          //  e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
