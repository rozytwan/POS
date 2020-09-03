using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS.Bll_mess_days
{
    public class Bll_mess_dailyrecord
    {
        public int insertintoBreakfast(string customerid,string dayname,string dates,String status,string package) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@dates",dates),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)

            };
            return DAL.IDU("insert into tbl_breakfast_daily values(@customerid,@dayname,@dates,@status,@package)",parm);
        }

        public int deletestatusZerobreakfast() {

            return DAL.IDU("Delete from tbl_breakfast_daily where status=0",null);
        }
        public int deletestatusZerolunch()
        {

            return DAL.IDU("Delete from tbl_Lunch_daily where status=0", null);
        }
        public int deletestatusZerosnacks()
        {

            return DAL.IDU("Delete from tbl_snacks_daily where status=0", null);
        }
        public int deletestatusZerodinner()
        {

            return DAL.IDU("Delete from tbl_Dinner_daily where status=0", null);
        }

        public int updatefrombreakfast(string customerId,string dayname,string status,string package) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)
            };
            return DAL.IDU("update tbl_breakfast_daily set status=@status where  id in (select id from tbl_breakfast_daily where customer_ID=@customerId and day=@dayname and package_name=@package)", parm);
        }

        public DataTable getRowBYdatePush(string dates,string customerId,string days,string package) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@dates",dates),
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@days",days),
                new SqlParameter("@package",package)
            };
            return DAL.getuser("select * from tbl_breakfast_daily where dates=@dates and customer_ID=@customerId and day=@days and package_name=@package", parm);
        }

        public int insertintoLunch(string customerid, string dayname, string dates, String status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@dates",dates),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)

            };
            return DAL.IDU("insert into tbl_Lunch_daily values(@customerid,@dayname,@dates,@status,@package)", parm);
        }
        public int updatefroLunch(string customerId, string dayname, string status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)
            };
            return DAL.IDU("update tbl_Lunch_daily set status=@status where  id in (select id from tbl_Lunch_daily where customer_ID=@customerId and day=@dayname and package_name=@package)", parm);
        }

        public DataTable getRowBYdatePushlunch(string dates, string customerId, string days, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@dates",dates),
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@days",days),
                new SqlParameter("@package",package)
            };
            return DAL.getuser("select * from tbl_Lunch_daily where dates=@dates and customer_ID=@customerId and day=@days and package_name=@package", parm);
        }


        public int insertintosnacks(string customerid, string dayname, string dates, String status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@dates",dates),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)

            };
            return DAL.IDU("insert into tbl_snacks_daily values(@customerid,@dayname,@dates,@status,@package)", parm);
        }
        public int updatefrosnacks(string customerId, string dayname, string status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)
            };
            return DAL.IDU("update tbl_snacks_daily set status=@status where  id in (select id from tbl_snacks_daily where customer_ID=@customerId and day=@dayname and package_name=@package)", parm);
        }

        public DataTable getRowBYdatePushsnacks(string dates, string customerId, string days, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@dates",dates),
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@days",days),
                new SqlParameter("@package",package)
            };
            return DAL.getuser("select * from tbl_snacks_daily where dates=@dates and customer_ID=@customerId and day=@days and package_name=@package", parm);
        }

        public int insertintodinnner(string customerid, string dayname, string dates, String status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@dates",dates),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)

            };
            return DAL.IDU("insert into tbl_Dinner_daily values(@customerid,@dayname,@dates,@status,@package)", parm);
        }
        public int updatefrodinnner(string customerId, string dayname, string status, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@dayname",dayname),
                new SqlParameter("@status",status),
                new SqlParameter("@package",package)
            };
            return DAL.IDU("update tbl_Dinner_daily set status=@status where  id in (select id from tbl_Dinner_daily where customer_ID=@customerId and day=@dayname and package_name=@package)", parm);
        }

        public DataTable getRowBYdatePushdinner(string dates, string customerId, string days, string package)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@dates",dates),
                new SqlParameter("@customerId",customerId),
                new SqlParameter("@days",days),
                new SqlParameter("@package",package)
            };
            return DAL.getuser("select * from tbl_Dinner_daily where dates=@dates and customer_ID=@customerId and day=@days and package_name=@package", parm);
        }

        public int deletebypackaeNamefrombreakfastdaily(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_breakfast_daily where package_name=@packagename ", parm);

        }

        public int deletebypackaeNamefromlunchdaily(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_Lunch_daily where package_name=@packagename ", parm);

        }
        public int deletebypackaeNamefromsnacksdaily(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_snacks_daily where package_name=@packagename ", parm);

        }

        public int deletebypackaeNamefromDinnerdaily(string packagename)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename)
            };
            return DAL.IDU("Delete from tbl_Dinner_daily where package_name=@packagename ", parm);

        }


        public int deletebyCustomerpackaeNamefrombreakfastdaily(string packagename,string customerid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename),
                new SqlParameter("@customerid",customerid)
            };
            return DAL.IDU("Delete from tbl_breakfast_daily where package_name=@packagename and customer_ID=@customerid", parm);

        }

        public int deletebyCustomerpackaeNamefromlunchdaily(string packagename,string customerid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename),
                 new SqlParameter("@customerid",customerid)
            };
            return DAL.IDU("Delete from tbl_Lunch_daily where package_name=@packagename and customer_ID=@customerid ", parm);

        }
        public int deletebyCustomerpackaeNamefromsnacksdaily(string packagename, string customerid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename),
                 new SqlParameter("@customerid",customerid)
            };
            return DAL.IDU("Delete from tbl_snacks_daily where package_name=@packagename and customer_ID=@customerid ", parm);

        }

        public int deletebyCustomerpackaeNamefromDinnerdaily(string packagename, string customerid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@packagename",packagename),
                 new SqlParameter("@customerid",customerid)
            };
            return DAL.IDU("Delete from tbl_Dinner_daily where package_name=@packagename and customer_ID=@customerid ", parm);

        }


    }
}
