using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;


namespace BLLS
{
    public class Bll_cashcounter
    {

        public int insertinto(decimal opening_balc,DateTime date,string set_by,string cash_type)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@opening_balc",opening_balc),              
                                new SqlParameter("@date",date),
                                 new SqlParameter("@set_by",set_by),
                                   new SqlParameter("@cash_type",cash_type)
            };
            return DAL.IDU("insert into tbl_daily_ocs(opening_balc,date,set_by,cash_type) values (@opening_balc,@date,@set_by,@cash_type)", parm);

        }
        public int insertclosing(decimal closing, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@closing",closing),

                                new SqlParameter("@date",date)
            };
            return DAL.IDU("insert into tbl_daily_ocs(closing_balc,date) values (@closing,@date)", parm);

        }
        public DataTable getlatestopeningblc()
        {
            return DAL.getuser("SELECT sum(opening_balc) from tbl_daily_ocs WHERE cash_type='OB'", null);
        }
   
        public DataTable getlatestopeningblchotel()
        {
            return DAL.getuser("SELECT sum(opening_balc) from tbl_daily_ocs WHERE cash_type='OBH'", null);
        }
        public DataTable getalldata() {
            return DAL.getuser("select * from tbl_daily_ocs order by id desc", null);
        }

        public DataTable getallopeningtoday()
        {
            return DAL.getuser("select * from tbl_daily_ocs", null);
        }     
        public DataTable getallclosingdata()
        {
            return DAL.getuser("select * from tbl_daily_ocs order by id desc", null);
        }
        public DataTable sum_total_cash_counter()
        {
            return DAL.getuser("select Sum(opening_balc) from tbl_daily_ocs", null);
        }
        public DataTable sum_servicecharge()
        {
            return DAL.getuser("select Sum(opening_balc) from tbl_daily_ocs", null);
        }

        public DataTable sum_total_Today_salesByDate(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@x_report",x_report)
            };
            return DAL.getuser("select Sum(grand_total) as salestotal from tbl_sales_record where x_report = @x_report", parm);
        }

        public DataTable getdatabydate(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date",date)
            };
            return DAL.getuser("select SUM(opening_balc) as total from tbl_daily_ocs where date=@date", parm);
            
        }

        public DataTable getsellcashamount(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date",date)
            };
            return DAL.getuser("select sum(cash_amount) as amount from tbl_sales_record where date_of_sale=@date", parm);
        }
        public int add_opening(decimal opening_balc)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
         new SqlParameter("@opening_balc",opening_balc),
        
         };
            return DAL.IDU("UPDATE tbl_daily_ocs SET opening_balc = @opening_balc +opening_balc ", parm);
        }
        public int delete_opening_balance()
        {
            return DAL.IDU("truncate table tbl_daily_ocs", null);
        }
        public int truncate_everyday_credit()
        {
            return DAL.IDU("truncate table tbl_credit_received", null);
        }
        public DataTable get_oening_balance_details()
        {
            return DAL.getuser("select * from tbl_daily_ocs where cash_type = 'OB'", null);
        }
        public int delete_opening_balancehotel()
        {
            return DAL.IDU("delete tbl_daily_ocs where cash_type='OBH'", null);
        }
        public DataTable getopeningbalance()
        {        
            return DAL.getuser("select sum(opening_balc) from tbl_daily_ocs where cash_type = 'OB'", null);
        }
        public DataTable get_oening_balance_detailshotel()
        {
            return DAL.getuser("select * from tbl_daily_ocs where cash_type = 'OBH'", null);
        }
        public int delete_opening_balancerestaurant()
        {
            return DAL.IDU("delete tbl_daily_ocs where cash_type='OB'", null);
        }
        public DataTable get_oening_balance_restaurant(string cash_type)
        {
            SqlParameter[] parm = new SqlParameter[]
       {
         new SqlParameter("@cash_type",cash_type),

       };
            return DAL.getuser("select * from tbl_daily_ocs where cash_type = @cash_type", parm);
        }
        public DataTable getopeningbalancerestaurant(string cash_type)
        {
            SqlParameter[] parm = new SqlParameter[]
       {
         new SqlParameter("@cash_type",cash_type),

       };
            return DAL.getuser("select sum(opening_balc) from tbl_daily_ocs where cash_type= @cash_type", parm);
        }
        public int delete_creditrestaurant()
        {
            return DAL.IDU("delete tbl_credit_received where paid_status!='HP'", null);
        }
        public int delete_credithotel()
        {
            return DAL.IDU("delete tbl_credit_received where paid_status='HP'", null);
        }
    }
   

}
