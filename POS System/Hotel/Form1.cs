using BLLS;
using POS_System.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class HotelDashBoard : UserControl
    {
        public HotelDashBoard()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
     
        private void HotelDashBoard_Load(object sender, EventArgs e)
          {
            string user_name = Login.sendtext;
            GetDetails details = new GetDetails();
            panel1.Controls.Clear();
            panel1.Controls.Add(details);
            btn_sales_report.Visible = false;
            bunifuFlatButton8.Visible = false;
            bunifuFlatButton7.Visible = false;
            bunifuroompackage.Visible = false;
            bunifuFlatButton4.Visible = false;
            bunifuFlatButton9.Visible = false;
            bunifuFlatButton2.Visible = false;
            btn_booking_report.Visible = false;
            bunifuFlatButton1.Visible = false;
            bunifuFlatButton5.Visible = false;
            bunifuFlatButton6.Visible = true;

            DataTable dt = blu.getusername(user_name);
            if (dt.Rows.Count > 0)
            {
                DataTable dtm = blu.Getuserhotelaccess(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["sales"].ToString() == "True")
                    {
                        bunifuFlatButton5.Visible = true;
                        bunifuFlatButton1.Visible = true;
                    }
       
                    if (dtm.Rows[0]["room_access"].ToString() == "True")
                    {
                        bunifuFlatButton7.Visible = true;
                        bunifuFlatButton8.Visible = true;
                        bunifuroompackage.Visible = true;
                        bunifuFlatButton9.Visible = true;
                    }
                    if (dtm.Rows[0]["report"].ToString() == "True")
                    {
                        bunifuFlatButton4.Visible = true;
                        btn_sales_report.Visible = true;
                        btn_booking_report.Visible = true;
                    }
                    else if (dtm.Rows[0]["admin"].ToString() == "True")
                    {
                        btn_sales_report.Visible = true;
                        bunifuFlatButton8.Visible = true;
                        bunifuFlatButton7.Visible = true;
                        bunifuroompackage.Visible = true;
                        bunifuFlatButton4.Visible = true;
                        bunifuFlatButton9.Visible = true;
                        bunifuFlatButton2.Visible = true;
                        btn_booking_report.Visible = true;
                        bunifuFlatButton9.Visible = true;
                    }
        

                }

            }
           // WindowState = FormWindowState.Maximized;

        }
    
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            GetDetails gd = new GetDetails();
            panel1.Controls.Clear();
            panel1.Controls.Add(gd);
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
      
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            Search srch = new Search();
            panel1.Controls.Clear();
            panel1.Controls.Add(srch);
          

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Report rp = new Report();
            panel1.Controls.Clear();
            panel1.Controls.Add(rp);
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Hotel.Hotel rp = new Hotel.Hotel();
            panel1.Controls.Clear();
            panel1.Controls.Add(rp);
            bunifuFlatButton5.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            RoomCategory category = new RoomCategory();
            panel1.Controls.Clear();
            panel1.Controls.Add(category);
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton8.BackColor = Color.Transparent;

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            RoomDetails details = new RoomDetails();
            panel1.Controls.Clear();
            panel1.Controls.Add(details);

            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.FromArgb(10, 24, 45);

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            HotelCoupon coupon = new HotelCoupon();
            panel1.Controls.Clear();
            panel1.Controls.Add(coupon);
            bunifuFlatButton9.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_sales_report_Click(object sender, EventArgs e)
        {
            SalesReport coupon = new SalesReport();
            panel1.Controls.Clear();
            panel1.Controls.Add(coupon);
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            btn_booking_report.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            btn_sales_report.BackColor = Color.FromArgb(10, 24, 45);

        }

        private void btn_booking_report_Click(object sender, EventArgs e)
        {
            BookingReport coupon = new BookingReport();
            panel1.Controls.Clear();
            panel1.Controls.Add(coupon);
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            btn_booking_report.BackColor = Color.FromArgb(10, 24, 45);
            bunifuFlatButton3.BackColor = Color.Transparent;
            btn_sales_report.BackColor = Color.Transparent;
        }

        private void bunifuroompackage_Click(object sender, EventArgs e)
        {
            RoomPackage coupon = new RoomPackage();
            panel1.Controls.Clear();
            panel1.Controls.Add(coupon);
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            btn_booking_report.BackColor = Color.Transparent;
            btn_sales_report.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.Transparent;
            bunifuroompackage.BackColor = Color.FromArgb(10, 24, 45);
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            HotelStatusUpdate coupon = new HotelStatusUpdate();
            panel1.Controls.Clear();
            panel1.Controls.Add(coupon);
            bunifuFlatButton9.BackColor = Color.Transparent;
            bunifuFlatButton1.BackColor = Color.Transparent;
            bunifuFlatButton2.BackColor = Color.Transparent;
            bunifuFlatButton5.BackColor = Color.Transparent;
            bunifuFlatButton4.BackColor = Color.Transparent;
            bunifuFlatButton6.BackColor = Color.Transparent;
            bunifuFlatButton7.BackColor = Color.Transparent;
            bunifuFlatButton8.BackColor = Color.Transparent;
            btn_booking_report.BackColor = Color.Transparent;
            btn_sales_report.BackColor = Color.Transparent;
            bunifuroompackage.BackColor = Color.Transparent;
            bunifuFlatButton3.BackColor = Color.FromArgb(10, 24, 45);
        }
    }
}
