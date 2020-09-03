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
  public  class BLLcardreport
    {
        public DataTable GetAddBalance(string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@status",status)
              
            };
            return DAL.getuser("select sum(balance_add) as balance_add  from tbl_add_balance_log where status=@status", parm);
        }
        public DataTable Getallbalance()
        {

            return DAL.getuser("select sum(distinct customer_balance) from tbl_customer_card_info", null);
        }
        public DataTable Club_card_sales()
        {
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where payment_mode='Club Card'", null);
        }
        public DataTable GetCashBack(string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@status",status)

            };
            return DAL.getuser("select sum(cash_back) as cash_back from tbl_cash_back where x_report=@status", parm);
        }
        public DataTable CardNo()
        {
            
            return DAL.getuser("select count(distinct customer_id) from tbl_customer_card_info", null);
        }
        public DataTable FixBack()
        {
            return DAL.getuser("select count(distinct customer_id) from tbl_cash_back", null);
        }
        public int Update_Customer(int customer_id, string customer_no)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_no",customer_no),
                new SqlParameter("@customer_id",customer_id)

            };
            return DAL.IDU("Update tbl_customerDetailnyo set card_no=@customer_no where id=@customer_id", parm);
        }
        public DataTable GetcustomerSales(string customer_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_no",customer_no)

            };
            return DAL.getuser("select * from tbl_sales_record where customer_no=@customer_no", parm);
        }
        public int Update_Cardno(int bill_no, string customer_no)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_no",customer_no),
                new SqlParameter("@bill_no",bill_no)

            };
            return DAL.IDU("Update tbl_sales_record set customer_no=@customer_no where bill_no=@bill_no", parm);
        }
        public int Insert_Card_Replace(int customer_id, string oldcard_no, string newcard_no, DateTime date, decimal oldcard_blc)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
                    new SqlParameter("@oldcard_no",oldcard_no),
                new SqlParameter("@newcard_no",newcard_no),
                new SqlParameter("@oldcard_blc",oldcard_blc),
                new SqlParameter("@date",date),

            };
            return DAL.IDU("insert into tbl_card_replaces(customer_id,oldcard_no,newcard_no,date,oldcard_blc) values (@customer_id,@oldcard_no,@newcard_no,@date,@oldcard_blc)", parm);
        }
        public DataTable GetBalanceAdd(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
       {
                new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto),

       };
            return DAL.getuser("select * from tbl_card_transactionlog where date between @datefrom and @dateto", parm);
        }
        public DataTable GetCardCashBack(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
       {
                new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto),

       };
            return DAL.getuser("select * from tbl_card_transactionlog where status='Cash Back' and date between @datefrom and @dateto", parm);
        }
        public DataTable GetAllBalanceAdd(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
       {

                new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto),

       };
            return DAL.getuser("select * from tbl_card_transactionlog where status='Balance Added' and date between @datefrom and @dateto", parm);
        }
        public DataTable GetBalancebyRechargeType(string recharge_type, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
       {          new SqlParameter("@recharge_type",recharge_type),
                new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto),

       };
            return DAL.getuser("select * from tbl_card_transactionlog where payment_mode=@recharge_type and date between @datefrom and @dateto", parm);
        }


        public DataTable Getblanancebyuser(string user_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
       {          new SqlParameter("@user_name",user_name),
                new SqlParameter("@datefrom",datefrom),
                    new SqlParameter("@dateto",dateto),

       };
            return DAL.getuser("select * from tbl_card_transactionlog where user_name=@user_name and date between @datefrom and @dateto", parm);
        }
    }
}
