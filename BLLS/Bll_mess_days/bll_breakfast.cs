using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOA;
using System.Data;
namespace BLLS.Bll_mess_days
{
    public class bll_breakfast
    {
        public DataTable getallBreakfastsforfromPakage(String pakagename, String days)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@days",days)
            };

            return DAL.getuser("select *from tbl_breakfast where day=@days and pakage_name=@pakagename", parm);
        }

        public DataTable getallLunchforfromPakage(String pakagename, String days)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@days",days)
            };

            return DAL.getuser("select *from tbl_Lunch where day=@days and pakage_name=@pakagename", parm);
        }

        public DataTable getallSnacksforfromPakage(String pakagename, String days)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@days",days)
            };

            return DAL.getuser("select *from tbl_snacks where day=@days and pakage_name=@pakagename", parm);
        }

        public DataTable getallDinnerforfromPakage(String pakagename, String days)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@days",days)
            };

            return DAL.getuser("select *from tbl_Dinner where day=@days and pakage_name=@pakagename", parm);
        }

        public int deletepakagesbydays(string pakagename, string dayname) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@dayname",dayname) };

            return DAL.IDU("delete  from tbl_breakfast where day=@dayname and pakage_name=@pakagename", parm);
        }
        public int deletepakagesbydayslunch(string pakagename, string dayname)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@dayname",dayname) };

            return DAL.IDU("delete  from tbl_Lunch where day=@dayname and pakage_name=@pakagename", parm);
        }
        public int deletepakagesbydayssnacks(string pakagename, string dayname)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@dayname",dayname) };

            return DAL.IDU("delete  from tbl_snacks where day=@dayname and pakage_name=@pakagename", parm);
        }
        public int deletepakagesbydaysdinner(string pakagename, string dayname)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@pakagename",pakagename),
                new SqlParameter("@dayname",dayname) };

            return DAL.IDU("delete  from tbl_Dinner where day=@dayname and pakage_name=@pakagename", parm);
        }

        public int deletebypackaeNamefrombreakfast(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_breakfast where pakage_name=@packagename ", parm);

        }

        public int deletebypackaeNamefromlunch(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_Lunch where pakage_name=@packagename ", parm);

        }
        public int deletebypackaeNamefromsnacks(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_snacks where pakage_name=@packagename ", parm);

        }

        public int deletebypackaeNamefromDinner(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_Dinner where pakage_name=@packagename ", parm);

        }

        public DataTable getallBreakfastsbyUserid(String userid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@userid",userid)
               };

            return DAL.getuser("select *from tbl_breakfast_daily where customer_ID=@userid", parm);
        }

        public DataTable getallLunchbyUserid(String userid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@userid",userid)
               };

            return DAL.getuser("select *from tbl_Lunch_daily where customer_ID=@userid", parm);
        }
        public DataTable getallsnacksbyUserid(String userid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@userid",userid)
               };

            return DAL.getuser("select *from tbl_snacks_daily where customer_ID=@userid", parm);
        }
        public DataTable getallDinnerbyUserid(String userid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@userid",userid)
               };

            return DAL.getuser("select *from tbl_Dinner_daily where customer_ID=@userid", parm);
        }


    }
}
