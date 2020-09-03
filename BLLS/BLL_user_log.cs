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
    public class BLL_user_log
    {
        public int createuserlog(string user_name, string user_activity, DateTime activity_date, string activity_day)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
       new SqlParameter("@user_name",user_name),
       new SqlParameter("@user_activity",user_activity),
       new SqlParameter("@activity_date",activity_date),
       new SqlParameter("@activity_day",activity_day)
              };
            return DAL.IDU("insert into tbl_user_log(user_name,user_activity,activity_date,activity_day) values(@user_name,@user_activity,@activity_date,@activity_day)", parm);
        }

        public DataTable getall_user_log(string user_name, string activity_day,string user_activity)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
       new SqlParameter("@user_name",user_name),
       new SqlParameter("@activity_day",activity_day),
        new SqlParameter("@user_activity",user_activity)
               };
            return DAL.getuser("select * from tbl_user_log where user_name=@user_name and activity_day=@activity_day and user_activity=@user_activity", parm);
        }
        public DataTable get_all_data_user_log()
        {
            return DAL.getuser("select * from tbl_user_log", null);
        }
        public DataTable get_all_data_by_date_user_log(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to)
                };
            return DAL.getuser("Select * from tbl_user_log where  activity_date between @from and @to", parm);
        }
        public DataTable get_all_data_by_date_by_user_log(DateTime from, DateTime to, string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@from",from),
                    new SqlParameter("@to",to),
                    new SqlParameter("@user_name",user_name)
                };
            return DAL.getuser("Select * from tbl_user_log where  user_name=@user_name and activity_date between @from and @to", parm);
        }
    }
}

