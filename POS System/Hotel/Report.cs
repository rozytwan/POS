using BLLS.Hotel;
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
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }
        BLL_Report report = new BLL_Report();
        string today = DateTime.Now.ToShortDateString();

        private void Report_Load(object sender, EventArgs e)
        {
            LoadDailyReport();
            LoadDaily();
            LoadWeekly();
            panel_daily.Hide();
            panel_week.Hide();
        }
   
        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_monthly_report_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_daily_report_Click(object sender, EventArgs e)
        {
            panel_daily.Show();
            panel_week.Hide();
        }
        public void LoadDailyReport()
        {
            lbl_today.Show();
            DataTable dt_total = report.NumofRoom();
            txt_total_room.Text = dt_total.Rows[0][0].ToString();
            DataTable dt1 = report.DailyBooking(Convert.ToDateTime(today));
            DataTable dt_bookings = report.Bookings();
            txt_book.TextAlign = HorizontalAlignment.Center;
            txt_book.Text = dt1.Rows[0][0].ToString();
            txt_total_room.TextAlign = HorizontalAlignment.Center;
            txt_total_free.TextAlign = HorizontalAlignment.Center;
            txt_total_free.Text = (Convert.ToInt32(dt_total.Rows[0][0].ToString()) - Convert.ToInt32(dt_bookings.Rows[0][0].ToString())).ToString() ;
            DataTable dt = report.Dailycheckin(Convert.ToDateTime(today));
            if (dt.Rows.Count > 0)
            {
                txt_check_in.TextAlign = HorizontalAlignment.Center;
                txt_check_in.Text = dt.Rows[0][0].ToString();
            }
     
            DataTable dt4 = report.Dailypendingcheckin(Convert.ToDateTime(today));
            if (dt4.Rows.Count > 0)
            {
                txt_pend_checkin.TextAlign = HorizontalAlignment.Center;
                txt_pend_checkin.Text = dt4.Rows[0][0].ToString();
            }
            DataTable dt5 = report.DailyPendingCheckout(Convert.ToDateTime(today));
            if (dt5.Rows.Count > 0)
            {
                txt_pend_checkout.TextAlign = HorizontalAlignment.Center;
                txt_pend_checkout.Text = dt5.Rows[0][0].ToString();
            }
          
            DataTable dt6 = report.DailyCancelCheckin(Convert.ToDateTime(today));
            if (dt6.Rows.Count > 0)
            {
                txt_cancel_check_in.TextAlign = HorizontalAlignment.Center;
                txt_cancel_check_in.Text = dt6.Rows[0][0].ToString();
            }
            DataTable dt7 = report.DailyCancelBooking(Convert.ToDateTime(today));
            if (dt7.Rows.Count > 0)
            {
                txt_cancel_book.TextAlign = HorizontalAlignment.Center;
                txt_cancel_book.Text = dt7.Rows[0][0].ToString();
            }
            DataTable dt2 = report.HotelCheckout(Convert.ToDateTime(today));
            if (dt2.Rows.Count > 0)
            {
                txt_checkout.TextAlign = HorizontalAlignment.Center;
                txt_checkout.Text = dt2.Rows[0][0].ToString();
            }
            DataTable dt3 = report.Dailycheckin(Convert.ToDateTime(today));
            if (dt3.Rows.Count > 0)
            {
                txt_guests.TextAlign = HorizontalAlignment.Center;
                txt_guests.Text = dt3.Rows[0][1].ToString();
            }
            DataTable dt_room_charge = report.RoomCharge(Convert.ToDateTime(today));
            if (dt_room_charge.Rows.Count > 0)
            {
                txt_room_charge.TextAlign = HorizontalAlignment.Center;
                txt_room_charge.Text = dt_room_charge.Rows[0][0].ToString();
            }

        }
        public void LoadDaily()
        {
            DataTable dt = report.DailyBooking(Convert.ToDateTime(dtp_daily.Text));
            txt_check_in.Text = dt.Rows[0][0].ToString();
            DataTable dt1 = report.Dailycheckin(Convert.ToDateTime(dtp_daily.Text));
            txt_book.Text = dt1.Rows[0][0].ToString();
            DataTable dt2 = report.Dailycheckout(Convert.ToDateTime(dtp_daily.Text));
            txt_checkout.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = report.Dailycheckin(Convert.ToDateTime(dtp_daily.Text));
            txt_guests.Text = dt3.Rows[0][1].ToString();
            DataTable dt4 = report.Dailypendingcheckin(Convert.ToDateTime(dtp_daily.Text));
            txt_pend_checkin.Text = dt4.Rows[0][0].ToString();
            DataTable dt5 = report.DailyPendingCheckout(Convert.ToDateTime(dtp_daily.Text));
            txt_pend_checkout.Text = dt5.Rows[0][0].ToString();
            //DataTable dt6 = report.Dailyreservedcheckin(Convert.ToDateTime(dtp_daily.Text));
            //txt_reserve.Text = dt6.Rows[0][0].ToString();
            //DataTable dt7 = report.DailyfixCheckout(Convert.ToDateTime(dtp_daily.Text));
            //txt_fix_checkout.Text = dt7.Rows[0][0].ToString();

        }
        public void LoadWeekly()
        {
            DataTable dt = report.DailyBookingbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_check_in.Text = dt.Rows[0][0].ToString();
            DataTable dt1 = report.Dailycheckinbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_book.Text = dt1.Rows[0][0].ToString();
            DataTable dt2 = report.Dailycheckoutbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_checkout.Text = dt2.Rows[0][0].ToString();
            DataTable dt3 = report.Dailycheckinbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_guests.Text = dt3.Rows[0][1].ToString();
            DataTable dt4 = report.Dailypendingcheckinbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_pend_checkin.Text = dt4.Rows[0][0].ToString();
            DataTable dt5 = report.DailyPendingCheckoutbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            txt_pend_checkout.Text = dt5.Rows[0][0].ToString();
            //DataTable dt6 = report.Dailyreservedcheckin(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            //txt_reserve.Text = dt6.Rows[0][0].ToString();
            //DataTable dt7 = report.DailyfixCheckoutbet(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            //txt_fix_checkout.Text = dt7.Rows[0][0].ToString();

        }

        private void btn_weekly_report_Click(object sender, EventArgs e)
        {
            panel_week.Show();
            panel_daily.Hide();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void btn_day_Click(object sender, EventArgs e)
        {
            LoadDaily();
        }

        private void btn_date_Click_1(object sender, EventArgs e)
        {
            LoadWeekly();
        }
    }
}
