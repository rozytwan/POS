using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.Hotel
{
    public class BLL_Report
    {
        public DataTable GetBooking()
        {

            return DAL.getuser("select (f_name + ' ' + l_name) as name,c.contact,c.country,b.booking_date,d.room_no,b.check_in,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id inner join hotel_room_details d on b.room_id=d.room_id ", null);
        }
        public DataTable SimilarName(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@name", name)
            };
            return DAL.getuser("select (f_name + ' ' + l_name) as name,c.contact,c.country,b.booking_date,d.room_no,b.check_in,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id inner join hotel_room_details d on b.room_id=d.room_id where (f_name + ' ' + l_name) like '%' + @name + '%'", parm);
        }
        public DataTable RoomCharge(DateTime check_in)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_in",check_in)
              };
            return DAL.getuser("select sum(grand_total) from tbl_sales_record where item_name='Room Charge' and cast(date_of_sale as date)=@check_in", parm);
        }
        public DataTable Similarphone(string phone)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@phone", phone)
            };
            return DAL.getuser("select (f_name + ' ' + l_name) as name,c.contact,c.country,b.booking_date,d.room_no,b.check_in,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id inner join hotel_room_details d on b.room_id=d.room_id where c.contact like '%' + @phone + '%'", parm);
        }
        public DataTable SearchCheckin(DateTime datefrom,DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto)
              };
            return DAL.getuser("select (f_name + ' ' + l_name) as name,c.contact,c.country,b.booking_date,d.room_no,b.check_in,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id inner join hotel_room_details d on b.room_id=d.room_id where cast(check_in as date) between @datefrom and @dateto", parm);
        }
        public DataTable SearchCheckout(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto)
              };
            return DAL.getuser("select (f_name + ' ' + l_name) as name,c.contact,c.country,b.booking_date,d.room_no,b.check_in,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id inner join hotel_room_details d on b.room_id=d.room_id where cast(check_out as date) between @datefrom and @dateto", parm);
        }
        public DataTable Dailycheckin(DateTime check_in)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_in",check_in)
              };
            return DAL.getuser("select count(check_in),sum(no_of_guest) from hotel_bookings where cast(check_in as date)=@check_in", parm);
        }
        public DataTable Dailycheckout(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_out",check_out)
              };
            return DAL.getuser("select count(check_out) from hotel_bookings where check_out=@check_out", parm);
        }
        public DataTable HotelCheckout(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_out",check_out)
              };
            return DAL.getuser("select count(check_out) from hotel_checkout where cast(checkout_date as date)=@check_out", parm);
        }
        public DataTable RoomCollection(DateTime date_of_sale)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@date_of_sale",date_of_sale)
              };
            return DAL.getuser("select * from tbl_sales_record where item_name='Room Charge' and cast(date_of_sale as date)=@date_of_sale", parm);
        }
        public DataTable NumofRoom()
        {

            return DAL.getuser("select count(room_no) from hotel_room_details", null);
        }
        public DataTable SearchItem(string item_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
               
            };
            return DAL.getuser("select * from tbl_sales_record where item_name=@item_name and cast(date_of_sale as date) between @dateFrom and @dataTo and sales_type='HS'", parm);
        }
        public DataTable SearchCategory(string category_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@category_name",category_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),

            };
            return DAL.getuser("select * from tbl_sales_record where category_name=@category_name and cast(date_of_sale as date) between @dateFrom and @dataTo and sales_type='HS'", parm);
        }
        public DataTable GetSales( DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
          
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
           
            };
            return DAL.getuser("select * from tbl_sales_record where cast(date_of_sale as date) between @dateFrom and @dataTo and sales_type='HS'", parm);
        }
        public DataTable DailyBooking(DateTime booking)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@booking",booking)
              };
            return DAL.getuser("select count(booking_date) from hotel_bookings where cast(booking_date as date)=@booking", parm);
        }
        public DataTable Bookings()
        {
           
            return DAL.getuser("select count(booking_date) from hotel_bookings", null);
        }

        public DataTable Dailypendingcheckin(DateTime check_in)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_in",check_in)
              };
            return DAL.getuser("select count(check_in) from hotel_pending_book where cast(check_in as date)=@check_in", parm);
        }
        public DataTable DailyPendingCheckout(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_out",check_out)
              };
            return DAL.getuser("select count(check_out) from hotel_pending_book where cast(check_out as date)=@check_out", parm);
        }
        public DataTable DailyCancelCheckin(DateTime cancel_date)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@cancel_date",cancel_date)
              };
            return DAL.getuser("select count(cancel_date) from hotel_cancel_booking where cast(cancel_date as date)=@cancel_date and status='Check_In Cancel'", parm);
        }
        public DataTable DailyCancelBooking(DateTime cancel_date)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@cancel_date",cancel_date)
              };
            return DAL.getuser("select count(cancel_date) from hotel_cancel_booking where cast(cancel_date as date)=@cancel_date and status='Booking Cancel'", parm);
        }
        public DataTable Dailyreservedcheckin(DateTime check_in)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_in",check_in)
              };
            return DAL.getuser("select count(check_in) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='busy' and check_in=@check_in", parm);
        }
        public DataTable DailyfixCheckout(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@check_out",check_out)
              };
            return DAL.getuser("select count(check_out) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='busy' and check_out=@check_out", parm);
        }
        public DataTable Dailycheckinbet(DateTime checkinfrom,DateTime checkinto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@checkinfrom",checkinfrom),
                      new SqlParameter("@checkinto",checkinto)
              };
            return DAL.getuser("select count(check_in),sum(no_of_guest) from hotel_bookings where check_in between @checkinfrom and @checkinto", parm);
        }
        public DataTable Dailycheckoutbet(DateTime checkoutfrom,DateTime checkoutto)
        {
            SqlParameter[] parm = new SqlParameter[]
              { new SqlParameter("@checkoutfrom",checkoutfrom),
                      new SqlParameter("@checkoutto",checkoutto)
              };
            return DAL.getuser("select count(check_out) from hotel_bookings where check_out between @checkoutfrom and @checkoutto", parm);
        }
        public DataTable DailyBookingbet(DateTime bookingfrom,DateTime bookingto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@bookingfrom",bookingfrom),
                    new SqlParameter("@bookingto",bookingto),
              };
            return DAL.getuser("select count(booking_date) from hotel_bookings where booking_date between @bookingfrom and @bookingto", parm);
        }
        public DataTable Dailypendingcheckinbet(DateTime checkinfrom,DateTime checkinto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@checkinfrom",checkinfrom),
                    new SqlParameter("@checkinto",checkinto)
              };
            return DAL.getuser("select count(check_in) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='booked' and check_in between @checkinfrom and @checkinto", parm);
        }
        public DataTable DailyPendingCheckoutbet(DateTime checkoutfrom, DateTime checkoutto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                  new SqlParameter("@checkoutfrom",checkoutfrom),
                      new SqlParameter("@checkoutto",checkoutto)
              };
            return DAL.getuser("select count(check_out) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='booked' and check_out between @checkoutfrom and @checkoutto", parm);
        }
        public DataTable Dailyreservedcheckin(DateTime checkinfrom, DateTime checkinto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                      new SqlParameter("@checkinfrom",checkinfrom),
                      new SqlParameter("@checkinto",checkinto)
              };
            return DAL.getuser("select count(check_in) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='busy' and check_in between @checkinfrom and @checkinto", parm);
        }
        public DataTable DailyfixCheckoutbet(DateTime checkoutfrom, DateTime checkoutto)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@checkoutfrom",checkoutfrom),
                      new SqlParameter("@checkoutto",checkoutto)
              };
            return DAL.getuser("select count(check_out) from hotel_bookings b inner join hotel_room_details r on b.room_id=r.room_id where status='busy' and check_out between @checkoutfrom and @checkoutto", parm);
        }
    }
}
