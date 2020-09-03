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
  public  class BLL_DayendHotel
    {
        public DataTable get_oening_balance_details()
        {
            return DAL.getuser("select * from tbl_daily_ocs where cash_type = 'OB'", null);
        }
        public DataTable get_oening_balance_detailshotel()
        {
            return DAL.getuser("select * from tbl_daily_ocs where cash_type = 'OBH'", null);
        }
        public DataTable getopeningbalance()
        {
            return DAL.getuser("select sum(opening_balc) from tbl_daily_ocs where cash_type = 'OB'", null);
        }
        public DataTable getopeningbalancehotel()
        {
            return DAL.getuser("select sum(opening_balc) from tbl_daily_ocs where cash_type = 'OBH'", null);
        }
        public DataTable sum_grand_total(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)

                };
            return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total,discount,tax_amount,service_charge from tbl_sales_record where x_report=@x_report and sales_type='HS'and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable Count_bill_no(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };

            return DAL.getuser("select count (distinct bill_no),min(bill_no), max(bill_no)  from tbl_sales_record where x_report=@x_report  and sales_type='HS' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable sum_Cash_card_sales(String x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount,grand_total from tbl_sales_record where x_report=@x_report and sales_type='HS' and payment_mode='Cash/Card' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable sum_cash_sale(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                    new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report  and sales_type='HS' and payment_mode='Cash' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) ", parm);
        }
        public DataTable sum_card_sale(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report  and sales_type='HS' and payment_mode='Card' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable Sum_Credit_Amount_receive(string credit_status, string payment_mode)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@credit_status",credit_status),
                    new SqlParameter("@payment_mode",payment_mode)
                };
            return DAL.getuser("select sum(credit_received) from tbl_credit_received where credit_status=@credit_status and paid_status='HP' and payment_mode=@payment_mode", parm);
        }
        public DataTable getallcomplementrysalebystatus(string status)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@status",status)

                };
            return DAL.getuser("select sum(total),sum(quantity) from tbl_complementry_sales where x_report=@status and status='HS'", parm);
        }
        public DataTable GetCountShiftChange(string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                          {
                    new SqlParameter("@status",status)

                          };
            return DAL.getuser("select count(user_name) from tbl_shift_change where status=@status", parm);
        }
        public DataTable Sum_Credit_Amount(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report  and sales_type='HS' and payment_mode='Credit'", parm);
        }
        public DataTable sum_get_care_of()
        {
            return DAL.getuser("select sum(cash) from tbl_Counter_withdrawl where status='Hotel'", null);
        }
        public DataTable Count_total_Table(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@x_report",x_report)
               };
            return DAL.getuser("select DISTINCT bill_no from tbl_sales_record where sales_type='TS' and x_report='X' ", parm);
        }
        public DataTable Count_total_Take_away()
        {

            return DAL.getuser("select  count(bill_no) from tbl_sales_record where sales_type='TA' and x_report='X' group by bill_no ", null);
        }
        public DataTable Count_total_Home_delivery()
        {

            return DAL.getuser("select count(bill_no) from tbl_sales_record where sales_type='HD' and x_report='X' group by bill_no ", null);
        }
        public DataTable Count_totalDinning()
        {

            return DAL.getuser("select count(bill_no) from tbl_sales_record where sales_type='DA' and x_report='X' group by bill_no ", null);
        }
        public DataTable count_cancelitem(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@date",date)
            };
            return DAL.getuser("select count(item) from tbl_ordercancel where delete_type='HS' and cast(date as date)=@date", parm);
        }
        public DataTable Count_Voidbill()
        {

            return DAL.getuser("select count(new_bill_no) from tbl_bill_void where cast(void_date as date)=cast(getdate() as date)", null);
        }
        public DataTable SumKOTType()
        {

            return DAL.getuser("select sum(case when kot_type ='K1' then total end)as K1,sum(case when kot_type = 'K2' then total end) as K2,sum(case when kot_type='K3' then total end) as k3,sum(case when kot_type='B1' then total end) as B1,sum(case when kot_type='B2' then total end) as B2,sum(case when kot_type='R1' then total end) as Room from tbl_sales_record where x_report='X' and sales_type='HS' ", null);
        }
        public int update_sale_x_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_sales_record set x_report='NULL' where x_report=@x_report and sales_type='HS' ", parm);
        }
        public int update_complementry_x_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_complementry_sales set x_report='NULL' where x_report=@x_report", parm);
        }
        public int updateCreditPaystatus(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_credit_received set credit_status='NULL' where credit_status=@x_report and paid_status='HP'", parm);
        }
        public int bulk_data_insert()
        {
            return DAL.IDU("insert into tbl_withdrawl_log (date,name,cash,withdrawl_type,status,remarks) select date,name,cash,withdrawl_type,status,remarks from tbl_Counter_withdrawl", null);
        }
 
 
        public int truncate_everyday_credit()
        {
            return DAL.IDU("truncate table tbl_credit_received", null);
        }
        public DataTable GetTransactioncashdrop()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from account_category where category_name='Cash Settlement'", null);
            return dt;
        }
        public int CreateTransactionPurchase(int category_id, string category_name, DateTime date, string description, decimal amount, string fiscal_year, string paymentmode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       new SqlParameter("@category_id",category_id),
       new SqlParameter("@category_name",category_name),
       new SqlParameter("@date",date),
       new SqlParameter("@description",description),
       new SqlParameter("@amount",amount),
       new SqlParameter("@fiscal_year",fiscal_year),
         new SqlParameter("@paymentmode",paymentmode),
            };
            return DAL.IDU("insert into acc_transactions (category_id,category_name,date,description,amount,fiscal_year,paymentmode) values(@category_id,@category_name,@date,@description,@amount,@fiscal_year,@paymentmode)", parm);
        }
        public int updateCreditPaidstatus(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                          {
                    new SqlParameter("@x_report",x_report)
                          };
            return DAL.IDU("update  tbl_credit_paid set status='NULL' where status=@x_report and paid_status='HP'", parm);
        }
        public int UpdateShiftChange(string status)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@status",status)
                };
            return DAL.IDU("update  tbl_shift_change set status='NULL' where status=@status", parm);
        }
        public DataTable itemGroup()
        {

            return DAL.getuser("select SUM(quantity) as quantity, item_name, sum(total) as cost from tbl_sales_record where x_report = 'X' and sales_type='HS' group by item_name", null);
        }
     
        public DataTable cancelitemGroup(DateTime dateFrom)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),

            };
            return DAL.getuser("select SUM(quantity) as quantity ,item,cost,cancel_type from tbl_ordercancel where delete_type='HS' and cast(date as date)=@dateFrom group by item,cost,cancel_type", parm);
        }
    }
}
