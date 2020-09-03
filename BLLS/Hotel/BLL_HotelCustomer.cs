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
   public class BLL_HotelCustomer
    {
        public DataTable GetCustomerbyname(string fname)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

        new SqlParameter("@fname",fname),

 };
            return DAL.getuser("Select * from hotel_customer where f_name=@fname", parm);
        }
        public DataTable GetCustomerName()
        {
     return DAL.getuser("Select * from hotel_customer order by f_name asc", null);
        }

        public DataTable GetCustomerbycontact(string contact)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@contact",contact),

 };
            return DAL.getuser("Select * from hotel_customer where contact=@contact", parm);
        }
        public DataTable GetBooking(int  customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@customer_id",customer_id),

 };
            return DAL.getuser("Select * from hotel_bookings where customer_id=@customer_id", parm);
        }
        public DataTable Getcheckincustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@customer_id",customer_id),

 };
            return DAL.getuser("Select * from hotel_customer where customer_id=@customer_id", parm);
        }
        public DataTable GetCheckIn(DateTime check_in)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@check_in",check_in),

 };
            return DAL.getuser("Select * from hotel_bookings where check_in=@check_in", parm);
        }
        public DataTable GetSimilarName(string f_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@f_name", f_name)
            };
            return DAL.getuser("Select * from hotel_customer where f_name like '%' + @f_name + '%'", parm);
        }
        public DataTable GetPackage(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@customer_id",customer_id),

        };
            return DAL.getuser("Select * from hotel_bookings where customer_id=@customer_id and package_id!=0", parm);
        }
        public DataTable GetBookingall(int customer_id, string room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

               new SqlParameter("@customer_id",customer_id),
                new SqlParameter("@room_id",room_id),

        };
            return DAL.getuser("Select * from hotel_bookings where customer_id=@customer_id and room_id!=@room_id", parm);
        }
    }
}
