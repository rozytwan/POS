using BLLS;
using BLLS.bakery;
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
    public partial class BakeryTable_Billing : UserControl
    {
        public BakeryTable_Billing(string service_type)
        {
            KOTService_type = service_type;
            InitializeComponent();
            

        }
        string kot_id;
     
  
      
        Button[] pictureBox2 = new Button[1000];
      
      
        Button btn_area = new Button();
        BLLDynamic bld = new BLLDynamic();
      
      //  Label[] lbl_table_name = new Label[1000];
        public void pic_load_with_table_info(string service_type)
        {
            DataTable dt = blbo.get_all_rest_table_info(service_type);
            dt.Rows.Add(kot_id);
            panel1.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    string _image_name = "Large";
                    pictureBox2[x] = new Button();               
                    if (dt.Rows[x]["name"].ToString() == "")
                    {

                        if (service_type == "TA")
                        {
                            
                            pictureBox2[x].Name = dt.Rows[x]["id"].ToString();
                            pictureBox2[x].Text = "New Take \n Away " + dt.Rows[x]["id"].ToString();
                        }
                        else
                        {
                            pictureBox2[x].Text = "New Home \n Delivery " + dt.Rows[x]["id"].ToString();
                            pictureBox2[x].Name = dt.Rows[x]["id"].ToString();
                        }
                    }
                    else
                    {
                        if (service_type == "TA")
                        {
                            pictureBox2[x].Text = " Take Away \n" + dt.Rows[x]["id"].ToString();
                            pictureBox2[x].Name = dt.Rows[x]["id"].ToString();
                        }
                        else
                        {
                            pictureBox2[x].Text = "Home Delivery \n" + dt.Rows[x]["id"].ToString();
                            pictureBox2[x].Name = dt.Rows[x]["id"].ToString();
                        }
                    }

                  
                    Bitmap images = (Bitmap)(Image)POS_System.Properties.Resources.ResourceManager.GetObject("Large");

                    pictureBox2[x].TextAlign = ContentAlignment.MiddleCenter;

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

                 
                    pictureBox2[x].Click += new EventHandler(newupTable_Click);
                  //  lbl_table_name[x].Click+= new EventHandler(newupTable_Click);
                    panel1.Controls.Add(pictureBox2[x]);
                    //pictureBox2[x].Controls.Add(lbl_table_name[x]);
                }
            }

        }


      
       
        public void newupTable_Click(object sender, EventArgs e)
        {
            label1.Text = ((Button)sender).Name;
            Control ctrl = this.Parent;
            BakeryKOTOrder vieret = new BakeryKOTOrder(label1.Text, KOTService_type);
            ctrl.Controls.Clear();
            ctrl.Controls.Add(vieret);
        }


       



     
        string TakeawayRename;
        private void BakeryTable_Billing_Load(object sender, EventArgs e)
        {

            TakeawayRename = second_user_interface.TakeawayRename;
            buttonX3.Text = TakeawayRename;
            if (KOTService_type == "TA")
            {
                btntakeaway_Click(null, null);
            }
            else
            {
                btnhomedelivery1_Click(null, null);
            }


        }
        BLLUser blu = new BLLUser();

        CheckDynamic cd = new CheckDynamic();
        string KOTService_type = "TA";
        private void btnhomedelivery1_Click(object sender, EventArgs e)
        {
            txt_header.Text="Home Delivery";
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["homedelivery"].ToString() == "True")
                    {
                       
                        DataTable dt = blbo.getmaxNo("HD");
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString() == "")
                            {
                                kot_id = "1";
                            }
                            else
                            {
                                int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                                kot_id = getinvoiceno.ToString();

                            }
                        }
                        pic_load_with_table_info("HD");
                        KOTService_type = "HD";
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Home Delivery ALert !!", "No Access Alert !!");
                    }
                }
            }
        }
        BllBakeryOrder blbo = new BllBakeryOrder();
        private void btntakeaway_Click(object sender, EventArgs e)
        {
            txt_header.Text = "Take Away";
            DataTable dt_user = blu.getusername(Login.sendtext);
            if (dt_user.Rows.Count > 0)
            {
                DataTable dta = blu.get_user_and_type_inner(Convert.ToInt32(dt_user.Rows[0]["user_id"].ToString()));
                if (dta.Rows.Count > 0)
                {
                    if (dta.Rows[0]["takeaway"].ToString() == "True")
                    {
                        DataTable dt = blbo.getmaxNo("TA");
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString() == "")
                            {
                                kot_id = "1";
                            }
                            else
                            {
                                int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                                kot_id = getinvoiceno.ToString();

                            }
                            pic_load_with_table_info("TA");
                            KOTService_type = "TA";
                        }

                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Access To Take Away ALert !!", "No Access Alert !!");
                    }
                }
            }
        }


       
     

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }



        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            //  e.Effect = DragDropEffects.Copy;
        }

        private void txt_header_Click(object sender, EventArgs e)
        {

        }
    }
}
