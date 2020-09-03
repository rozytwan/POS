using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.BLLHotel
{
   public class BLL_checkout
    {
        public DataTable GetPriceByid(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@room_id",room_id),
            
            };
            return DAL.getuser("select price from hotel_room_details where room_id=@room_id", parm);
        }
        public DataTable GetDateDifference(DateTime checkindate,DateTime Checkoutdate)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@checkindate",checkindate),
                new SqlParameter("@checkoutdate",Checkoutdate)
            };
            return DAL.getuser("SELECT DATEDIFF(day, @checkindate,@checkoutdate) AS DateDiff", parm);
        }
        public int Insert_Cancel(int customer_id, int room_id, DateTime cancel_date, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
         new SqlParameter("@customer_id",customer_id),
        new SqlParameter ("@room_id",room_id),
        new SqlParameter("@cancel_date",cancel_date),
        new SqlParameter ("@status",status),


         };
            return DAL.IDU("Insert into hotel_cancel_booking(customer_id,room_id,cancel_date,status) values (@customer_id,@room_id,@cancel_date,@status)", parm);
        }
        public DataTable GetHotelBooking(int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@room_id",room_id),

            };
            return DAL.getuser("select * from hotel_bookings where room_id=@room_id", parm);
        }
        public DataTable SearchCustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
        new SqlParameter("@customer_id",customer_id),
            };
            return DAL.getuser("select count(distinct checkout_date) from hotel_checkout  where customer_id=@customer_id", parm);
        }
    }
}
