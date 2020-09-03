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
   public class BLL_Pending
    {
        public DataTable GetPendingBook()
        {

            return DAL.getuser("select * from hotel_pending_book", null);
        }
        public int CancelationCustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),

            };
            return DAL.IDU("delete from hotel_pending_book where customer_id=@customer_id", parm);
        }
        public int Cancelation(int pending_booking_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@pending_booking_id",pending_booking_id),

             };
            return DAL.IDU("delete from hotel_pending_book where pending_booking_id=@pending_booking_id", parm);
        }
        public int DeleteCustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),

             };
            return DAL.IDU("delete from hotel_customer where customer_id=@customer_id", parm);
        }
        public int DeleteCustomerDetails(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),

            };
            return DAL.IDU("delete from hotel_customer_details where customer_id=@customer_id", parm);
        }
        public DataTable GetCustomerName()
        {

            return DAL.getuser("select p.customer_id,(p.l_name + ' ' + p.f_name) AS name from hotel_customer p inner join hotel_pending_book b on p.customer_id=b.customer_id", null);
        }
        public DataTable GetReturnCustomer(string f_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@f_name",f_name),

             };
            return DAL.getuser("select (f_name + ' ' + l_name) as name from hotel_customer where (f_name + ' ' + l_name)=@f_name ", parm);
        }
        public DataTable GetReturnCustomerId(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),

             };
            return DAL.getuser("select * from hotel_customer p inner join hotel_pending_book b on p.customer_id=b.customer_id where b.customer_id=@customer_id", parm);
        }
        public DataTable GetName(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@customer_id",customer_id),

             };
            return DAL.getuser("select (f_name + ' ' + l_name) as name from hotel_customer where customer_id=@customer_id", parm);
        }
        public DataTable GetpendingDetails(int pending_booking_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@pending_booking_id",pending_booking_id)

             };
            return DAL.getuser("select * from hotel_pending_book where pending_booking_id=@pending_booking_id", parm);
        }
        public int Updatepending(int pending_booking_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@pending_booking_id",pending_booking_id),

             };
            return DAL.IDU("update hotel_pending_book set no_of_room=no_of_room-1 where pending_booking_id=@pending_booking_id", parm);
        }
    }
}
