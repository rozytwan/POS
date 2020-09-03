using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
   public class BLLCustomer_details
    {
        public int InsertIntoCustomersDetails(int new_customer_id, string title, string name, string spouse, string adress, DateTime birthdate, DateTime anniversary, string phone, string mobile, int fax, string email, string city)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@new_customer_id",new_customer_id),

                    new SqlParameter("@title",title),
                    new SqlParameter("@name",name),
                    new SqlParameter("@spouse",spouse),
                    new SqlParameter("@adress",adress),
                    new SqlParameter("@birthdate",birthdate),
                    new SqlParameter("@anniversary",anniversary),
                    new SqlParameter("@phone",phone),
                    new SqlParameter("@mobile",mobile),
                    new SqlParameter("@fax",fax),
                    new SqlParameter("@email",email),
                    new SqlParameter("@city",city)


                };
            //inserting into customer details table by parameter

            return DAL.IDU("insert into tbl_customer_details values(@new_customer_id,@title,@name,@spouse,@adress,@birthdate,@anniversary,@phone,@mobile,@fax,@email,@city )", parm);
        }
        public int UpdateIntoCustomersDetails(int new_customer_id, string title, string name, string spouse, string adress, DateTime birthdate, DateTime anniversary, String phone, string mobile, int fax, string email, string city)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@new_customer_id",new_customer_id),

                    new SqlParameter("@title",title),
                    new SqlParameter("@name",name),
                    new SqlParameter("@spouse",spouse),
                    new SqlParameter("@adress",adress),
                    new SqlParameter("@birthdate",birthdate),
                    new SqlParameter("@anniversary",anniversary),
                    new SqlParameter("@phone",phone),
                    new SqlParameter("@mobile",mobile),
                    new SqlParameter("@fax",fax),
                    new SqlParameter("@email",email),
                    new SqlParameter("@city",city)


                };
            return DAL.IDU("update tbl_customer_details set title=@title,name=@name,spouse=@spouse,adress=@adress,birthdate=@birthdate,anniversary=@anniversary,phone=@phone,mobile=@mobile,fax=@fax,email=@email,city=@city where new_customer_id = @new_customer_id", parm);
        }
      

        public DataTable GetCount(DateTime birthdate)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@birthdate", birthdate)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select count(birthdate) from  tbl_customerDetailnyo where birthdate=cast(GETDATE()as date)", parm);
            return dt;
        }
        public DataTable GetCountAppointment(DateTime start_time)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@start_time", start_time)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select count(start_time) from  tbl_customer_appointment where start_time=cast(GETDATE()as date)", parm);
            return dt;
        }
        public DataTable GetCustomerAppointment(DateTime start_time)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@start_time", start_time)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from (select name as name ,phone as phone ,'Birthday' as Remarks from tbl_customerDetailnyo where birthdate=cast(GETDATE()as date) union all select c.name as name,c.phone as phone,remarks as Remarks from tbl_customer_appointment ca left join tbl_customerDetailnyo c on (c.id=ca.customer_id) where start_time=cast(GETDATE()as date)) as customerBdayApp order by name;", parm);
            return dt;
        }
        public DataTable GetHotelNotification(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@check_out", check_out)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select c.f_name+' '+ l_name as name,c.contact,b.check_out from hotel_bookings b inner join hotel_customer c on b.customer_id=c.customer_id where check_out=cast(GETDATE()as date)", parm);
            return dt;
        }
        public DataTable GetCountHotel(DateTime check_out)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@check_out", check_out)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select count(check_out) from  hotel_bookings where check_out=cast(GETDATE()as date)", parm);
            return dt;
        }
    }


}

