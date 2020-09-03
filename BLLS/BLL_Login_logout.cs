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
   public class BLL_Login_logout
    {
        public int insert_into_login_logout(string staff_name, string working_day, DateTime working_date, string working_time, string log_type,string session_id)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                 new SqlParameter("@staff_name",staff_name),
                 new SqlParameter("@working_day",working_day),
                 new SqlParameter("@working_date",working_date),
                 new SqlParameter("@working_time",working_time),
                 new SqlParameter("@log_type",log_type),
                 new SqlParameter("@session_id",session_id)
            };
            return DAL.IDU("Insert into tbl_Login_logout(staff_name,working_day,working_date,working_time,log_type,session_id) Values(@staff_name,@working_day,@working_date,@working_time,@log_type,@session_id)", parm);

        }
        public DataTable getMaxid()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(session_id) from tbl_Login_logout", null);
            return dt;
        }
        public DataTable get_all_data_by_date(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Login' and working_date between @from and @to", parm);
        }
        public DataTable get_all_data_by_date_by_user(DateTime from, DateTime to,string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@user_name",user_name)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Login' and staff_name=@user_name and working_date between @from and @to", parm);
        }
        public DataTable get_all_Login__time(DateTime from, DateTime to,string session_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@session_id",session_id)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Login' and session_id=@session_id and working_date between @from and @to", parm);
        }
        public DataTable get_all_Login__time_customer(DateTime from, DateTime to, string session_id,string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@session_id",session_id),
                    new SqlParameter("@user_name",user_name)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Login' and session_id=@session_id and staff_name=@user_name and working_date between @from and @to", parm);
        }
        public DataTable get_all_logout_time(DateTime from, DateTime to, string session_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@session_id",session_id)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Logout' and session_id=@session_id and working_date between @from and @to", parm);
        }
        public DataTable get_all_logout_time(DateTime from, DateTime to, string session_id,string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@session_id",session_id),
                    new SqlParameter("@user_name",user_name)
                };
            return DAL.getuser("Select * from tbl_Login_logout where log_type='Logout' and session_id=@session_id and staff_name=@user_name and working_date between @from and @to", parm);
        }
        public int InsertIrdInfo(string username, string password, string ip_address)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@username",username),
                    new SqlParameter("@password",password),
                    new SqlParameter("@ip_address",ip_address),
                 };
            return DAL.IDU("insert into tbl_ird_info(username,password,ip_address) values (@username,@password,@ip_address)", parm);
        }
        public int UpdateIrdInfo(int ird_id, string username, string password, string ip_address)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                   new SqlParameter("@ird_id",ird_id),
                    new SqlParameter("@username",username),
                    new SqlParameter("@password",password),
                    new SqlParameter("@ip_address",ip_address),
                 };
            return DAL.IDU("update tbl_ird_info set username=@username,password=@password,ip_address=@ip_address where ird_id=@ird_id", parm);
        }

        public DataTable GetIrdInfo()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_ird_info", null);
            return dt;
        }

    }
}
