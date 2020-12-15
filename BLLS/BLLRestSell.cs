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
    public class BLLRestSell
    {
        public DataTable getinvoiceno()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(bill_no) from tbl_bill_invoice", null);
            return dt;
        }
        public int insert_into_bill_invoice(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no)
                };
            return DAL.IDU("Insert into tbl_bill_invoice (bill_no) values (@bill_no)", parm);
        }
        public int autoBillIncrease()
        {
           
            return DAL.IDU("Insert into tbl_bill_invoice (bill_no)  (select max(bill_no) from tbl_sales_record where x_report='X')", null);
        }
        public DataTable CheckBillNo(int bill_no, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                     new SqlParameter("@date2",date2)
                };
            return DAL.getuser("select bill_no from tbl_sales_record where bill_no=@bill_no and date2=@date2", parm);
        }
        public int insertintosalesbook(int bill_no, DateTime date_of_sale, string cashier_name, string category_name, string table_no, string customer_name, string customer_no, string item_name, decimal quantity, decimal cost, decimal total, string payment_mode, string kot_type, decimal sub_total, decimal discount, decimal cash_amount, decimal card_amount, decimal grand_total, string sales_type, string customer_pan_no, string x_report, decimal service_charge, decimal taxable_amount, decimal tax_amount, string fiscal_year, string service_provider, DateTime date2, int customer_id, int loopId, string timeOnly, string sync_with_ird, int complementryInvoiceNo, string complementry_status, string void_status, int void_bill_no, string void_reason, int order_id,decimal credit_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                      new SqlParameter("@date_of_sale",date_of_sale),
                        new SqlParameter("@cashier_name",cashier_name),
                        new SqlParameter("@table_no",table_no),
                        new SqlParameter("@customer_name",customer_name),
                        new SqlParameter("@customer_no",customer_no),
                        new SqlParameter("@item_name",item_name),
                          new SqlParameter("@quantity",quantity),
                        new SqlParameter("@cost",cost),
                        new SqlParameter("@total",total),
                        new SqlParameter("@payment_mode",payment_mode),
                        new SqlParameter("@kot_type",kot_type),
                        new SqlParameter("@sub_total",sub_total),
                        new SqlParameter("@discount",discount),
                        new SqlParameter("@cash_amount",cash_amount),
                         new SqlParameter("@card_amount",card_amount),
                        new SqlParameter("@grand_total",grand_total),
                         new SqlParameter("@category_name",category_name),
                        new SqlParameter("@date2",date2),
                        new SqlParameter("@sales_type",sales_type),
                          new SqlParameter("@customer_pan_no",customer_pan_no),
                        new SqlParameter("@x_report",x_report),
                         new SqlParameter("@service_charge",service_charge),
                        new SqlParameter("@taxable_amount",taxable_amount),
                        new SqlParameter("@tax_amount",tax_amount),
                        new SqlParameter("@fiscal_year",fiscal_year),
                        new SqlParameter("@service_provider",service_provider),
                         new SqlParameter("@customer_id",customer_id),
                        new SqlParameter("@loopId",loopId),
                        new SqlParameter("@timeOnly",timeOnly),
                        new SqlParameter("@sync_with_ird",sync_with_ird),
                        new SqlParameter("@complementryInvoiceNo",complementryInvoiceNo),
                         new SqlParameter("@complementry_status",complementry_status),
                         new SqlParameter  ("@void_status",void_status),
                        new SqlParameter("@void_bill_no",void_bill_no),
                        new SqlParameter("@void_reason",void_reason),
                        new SqlParameter("@order_id",order_id),
                         new SqlParameter("@credit_amount",credit_amount),
           };

            return DAL.IUD_SP("spSalesRecord", CommandType.StoredProcedure, parm);

        }
        public DataTable Count_bill_no(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };

            return DAL.getuser("select count (distinct bill_no),min(bill_no), max(bill_no)  from tbl_sales_record where x_report=@x_report and sales_type!='HS' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }

        public DataTable Sum_Club_Card_Sales(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                 {
                    new SqlParameter("@x_report",x_report)
                 };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Club Card'", parm);
        }
        public DataTable GetCountShiftChange(string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                          {
                    new SqlParameter("@status",status)

                          };
            return DAL.getuser("select count(user_name) from tbl_shift_change where status=@status", parm);
        }

        public DataTable get_all_value_by_bill_no(string bill_no, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select * from tbl_sales_record where fiscal_year=@fiscal_year and bill_no=@bill_no", parm);
            //datepart(MM,date_of_sale)=DATEPART(MM,GETDATE()) and  datepart(YYYY,date_of_sale)=DATEPART(YYYY,GETDATE())
        }
        public DataTable get_bill_by_xreport(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                   
                };
            return DAL.getuser("select * from tbl_sales_record where x_report='X' and bill_no=@bill_no", parm);
            //datepart(MM,date_of_sale)=DATEPART(MM,GETDATE()) and  datepart(YYYY,date_of_sale)=DATEPART(YYYY,GETDATE())
        }
        public int voidBillInsert(int void_bill_no, int new_bill_no, string void_reason, string void_status, DateTime void_date, string void_user)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@void_bill_no",void_bill_no),
                      new SqlParameter("@new_bill_no",new_bill_no),
                        new SqlParameter("@void_reason",void_reason),
                        new SqlParameter("@void_status",void_status),
                        new SqlParameter("@void_date",void_date),
                        new SqlParameter("@void_user",void_user)
                };
            return DAL.IDU("insert into tbl_bill_void (void_bill_no,new_bill_no,void_reason,void_status,void_date,void_user) values (@void_bill_no,@new_bill_no,@void_reason,@void_status,@void_date,@void_user) ", parm);

        }
        public DataTable GetBillVoid(int void_bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@void_bill_no",void_bill_no),
                   
              };
            return DAL.getuser("select * from tbl_bill_void where void_bill_no=@void_bill_no", parm);
        }
        public DataTable count_table()
        {
            return DAL.getuser("select count(table_no) from tbl_orders where table_no<100 group by table_no", null);
        }
        public DataTable count_quantity()
        {
            return DAL.getuser("select count(quantity) from tbl_orders", null);
        }
        public int delete_sale_by_id(int rest_sale_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_sale_id",rest_sale_id)

                };
            return DAL.IDU("delete from tbl_sales_record where rest_sale_id=@rest_sale_id", parm);
        }
        public int delete_Sale_delete_by_id(int rest_sale_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@rest_sale_id",rest_sale_id)

                };
            return DAL.IDU("delete from tbl_sales_record_delete where rest_sale_id=@rest_sale_id", parm);
        }
        public int inser_delete_record(int rest_sale_id, int bill_no, DateTime date_of_sale, string cashier_name, string table_no, string customer_name, string customer_no, string item_name, decimal quantity, decimal cost, decimal total, string payment_mode, string card_no, decimal sub_total, decimal discount, decimal cash_amount, decimal card_amount, decimal grand_total, string category_name, string sales_type, DateTime delete_date, string delete_by)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                        new SqlParameter("@rest_sale_id",rest_sale_id),
                        new SqlParameter("@bill_no",bill_no),
                        new SqlParameter("@date_of_sale",date_of_sale),
                        new SqlParameter("@cashier_name",cashier_name),
                        new SqlParameter("@table_no",table_no),
                        new SqlParameter("@customer_name",customer_name),
                        new SqlParameter("@customer_no",customer_no),
                        new SqlParameter("@quantity",quantity),
                        new SqlParameter("@item_name",item_name),
                        new SqlParameter("@cost",cost),
                        new SqlParameter("@total",total),
                        new SqlParameter("@payment_mode",payment_mode),
                        new SqlParameter("@card_no",card_no),
                        new SqlParameter("@sub_total",sub_total),
                        new SqlParameter("@discount",discount),
                        new SqlParameter("@card_amount",card_amount),
                        new SqlParameter("@cash_amount",cash_amount),
                        new SqlParameter("@grand_total",grand_total),
                        new SqlParameter("@category_name",category_name),
                        new SqlParameter("@date2",date_of_sale),
                        new SqlParameter("@sales_type",sales_type),
                        new SqlParameter("@delete_date",delete_date),
                        new SqlParameter("@delete_by",delete_by)


                };

            return DAL.IDU("insert into tbl_sales_record_delete (rest_sale_id,bill_no,date_of_sale,cashier_name,table_no,customer_name,customer_no,item_name,quantity,cost,total,payment_mode,card_no,sub_total,discount,card_amount,cash_amount,grand_total,category_name,date2,sales_type,delete_date,delete_by)" +
                " values(@rest_sale_id,@bill_no,@date_of_sale,@cashier_name,@table_no,@customer_name,@customer_no,@item_name,@quantity,@cost,@total,@payment_mode,@card_no,@sub_total,@discount,@card_amount,@cash_amount,@grand_total,@category_name,@date2,@sales_type,@delete_date,@delete_by)", parm);

        }
        public DataTable sum_grand_total(string x_report,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)

                };
            return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total,discount,tax_amount,service_charge from tbl_sales_record where x_report=@x_report and sales_type!='HS' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }

        public DataTable GetAllVoids(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@datefrom",datefrom),
                new SqlParameter("@dateto",dateto),


            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*,void_date FROM summary s right join tbl_bill_void v on (s.bill_no=v.new_bill_no) WHERE s.rk = 1 and void_date between cast(@datefrom as date) and cast(@dateto as date)", parm);
        }
        public DataTable GetCredit(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@name",name)
               };
            return DAL.getuser("select * from tbl_sales_record s where payment_mode='Credit' and customer_name=@name", parm);
        }
        public DataTable sum_cash_sale(string x_report,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                    new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Cash' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) ", parm);
        }
        public DataTable sum_fonepay_sale(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                    new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='FonePay' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) ", parm);
        }
        public DataTable sum_cash_sale_Bysalestype(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
            
                    new SqlParameter("@x_report",x_report),
                    new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and sales_type='HS' and payment_mode='Cash' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) ", parm);
        }
        public DataTable sum_card_sale(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Card' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }

        public DataTable Sum_Credit_Amount_received(string paid_status,DateTime checked_date)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@paid_status",paid_status),
                    new SqlParameter("@checked_date",checked_date)
                };
            return DAL.getuser("select sum(credit_received) from tbl_credit_received where paid_status=@paid_status and credit_received_date=@checked_date", parm);
        }
        public DataTable Sum_Credit_Amoun(DateTime credit_date)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@credit_date",credit_date)
                };
            return DAL.getuser("select credit_amount from tbl_customer_credits where credit_date=@credit_date", parm);
        }
        public DataTable sum_credit_sales(DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@date2",date2)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where date2=@date2 and payment_mode='Credit'", parm);
        }
        public DataTable sum_Cash_card_sales(String x_report,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount,grand_total from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Cash/Card' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable sum_Cash_Credit_sales(String x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,cash_amount,grand_total from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Cash/Credit' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable Sum_Credit_Amount(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Credit' and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable Sum_Credit_cash_Amount(string x_report, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@fiscal_year",fiscal_year)
                };
            return DAL.getuser("select DISTINCT bill_no,credit_amount,cash_amount from tbl_sales_record where x_report=@x_report and sales_type!='HS' and payment_mode='Cash/Credit' and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
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
        public DataTable count_cancelitem( DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@date",date)
            };
            return DAL.getuser("select count(item) from tbl_ordercancel where delete_type!='HS' and cast(date as date)=@date", parm);
        }
        public DataTable Count_Voidbill()
        {

            return DAL.getuser("select count(new_bill_no) from tbl_bill_void where cast(void_date as date)=cast(getdate() as date)", null);
        }
        public int update_sale_x_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_sales_record set x_report='NULL' where x_report=@x_report and sales_type!='HS'", parm);
        }
        public int update_complementry_x_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_complementry_sales set x_report='NULL' where x_report=@x_report and status!='HS'", parm);
        }
        public int updateCreditPaystatus(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_credit_received set credit_status='NULL' where credit_status=@x_report and paid_status='RP'", parm);
        }
        public int update_addbalance_Log_x_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_add_balance_log set status='NULL' where status=@x_report", parm);
        }
        public int update_cashBackLog_report(string x_report)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report)
                };
            return DAL.IDU("update  tbl_cash_back set x_report='NULL' where x_report=@x_report", parm);
        }
        public DataTable search_all_x_data()
        {

            return DAL.getuser("select * from tbl_sales_record where x_report = 'X' ", null);
        }
        public DataTable search_all_x_data_by_cash()
        {

            return DAL.getuser("select * from tbl_sales_record where x_report = 'X' and payment_mode='Cash'", null);
        }
        public DataTable search_all_x_data_by_Card()
        {

            return DAL.getuser("select * from tbl_sales_record where x_report = 'X' and payment_mode='Card'", null);
        }
        public DataTable search_all_x_data_by_Zomato()
        {

            return DAL.getuser("select * from tbl_sales_record where x_report = 'X' and payment_mode='Zomato'", null);
        }
        public DataTable search_all_x_data_by_Credit()
        {

            return DAL.getuser("select * from tbl_sales_record where x_report = 'X' and payment_mode='Credit'", null);
        }
        public int truncate_bill_no()
        {
            return DAL.IDU("truncate table tbl_bill_invoice", null);
        }
        public DataTable GetBillVoid(string bill_no,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no)


            };
            DataTable dt = DAL.getuser("select * from tbl_bill_void where new_bill_no=@bill_no ", parm);
            return dt;
        }
     
        public DataTable SearchBy(string find)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@find",find)


            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*,void_date FROM summary s right join tbl_bill_void v on (s.bill_no=v.new_bill_no) WHERE s.rk = 1 and bill_no=@find", parm);

        }

        public DataTable GetVoidBill()
        {
            return DAL.getuser("select * from tbl_bill_void", null);
        }
        public DataTable GetVoids()
        {
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s right join tbl_bill_void v on (s.bill_no=v.new_bill_no) WHERE s.rk = 1", null);
        }
        public DataTable Sum_Credit_Amount_receive(string credit_status,string payment_mode)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@credit_status",credit_status),
                    new SqlParameter("@payment_mode",payment_mode)
                };
            return DAL.getuser("select sum(credit_received) from tbl_credit_received where credit_status=@credit_status and paid_status='RP' and payment_mode=@payment_mode", parm);
        }
        public DataTable getallcomplementrysalebystatus(string status)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@status",status)
                    
                };
            return DAL.getuser("select sum(total),sum(quantity) from tbl_complementry_sales where x_report=@status and status!='HS'", parm);
        }


        public DataTable SumKOTType(string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                     new SqlParameter("@fiscal_year",fiscal_year)
              };
            return DAL.getuser("select sum(case when kot_type ='K1' then total end)as K1,sum(case when kot_type = 'K2' then total end) as K2,sum(case when kot_type='K3' then total end) as k3,sum(case when kot_type='B1' then total end) as B1,sum(case when kot_type='B2' then total end) as B2 from tbl_sales_record where x_report='X' and sales_type!='HS' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)  ", parm);
        }
        public int updateCreditPaidstatus(string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                          {
                    new SqlParameter("@x_report",x_report)
                          };
            return DAL.IDU("update  tbl_credit_paid set status='NULL' where status=@x_report and paid_status='RP'", parm);
        }
        public int UpdateShiftChange(string status)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@status",status)
                };
            return DAL.IDU("update  tbl_shift_change set status='NULL' where status=@status", parm);
        }
        public DataTable GetHotelCredit(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@name",name)
               };
            return DAL.getuser("select * from tbl_sales_record s where payment_mode='Credit' and sales_type='HS' and customer_name=@name", parm);
        }
    }

}
