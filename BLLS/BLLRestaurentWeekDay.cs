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
  public  class BLLRestaurentWeekDay
    {

        public DataTable searchALLSalesRecord(DateTime dateFrom, DateTime dataTo,string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@weekday",weekday),
                     new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  Count(bill_no) FROM    tbl_sales_record WHERE   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and date_of_sale  between @dateFrom and @dataTo and datename(WEEKDAY,date2)=@weekday", parm);
        }

        public DataTable searchbybill2Count(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),
               

            };
            return DAL.getuser("select count(bill_no) from tbl_sales_record where bill_no = @bill_no  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) ", parm);
        }
        public DataTable searchitembyname2Count(string item_name, DateTime dateFrom, DateTime dataTo, string column_name,string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select count(bill_no) from tbl_sales_record where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and datename(WEEKDAY,date2)=@weekday", parm);
        }
        public DataTable searchALLSalesWithoutpagination(DateTime dateFrom, DateTime dataTo,string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)


            };
            return DAL.getuser("SELECT  sr.bill_no,sr.item_name,sr.quantity,sr.total,sr.date_of_sale,sr.cost,sr.payment_mode,sr.sub_total,sr.discount,sr.cash_amount,sr.card_amount,sr.service_charge,sr.tax_amount,sr.grand_total,sr.sales_type,sr.cashier_name,sr.customer_name FROM    tbl_sales_record sr   WHERE   sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year)  and date_of_sale  between @dateFrom and @dataTo and datename(WEEKDAY,date2)=@weekday order by sr.bill_no asc  ", parm);
        }
        public DataTable searchALLSales(DateTime dateFrom, DateTime dataTo, int minpagesize, int intskip, string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@weekday",weekday),
                  new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  Top " + minpagesize + " * FROM    tbl_sales_record WHERE  date_of_sale  between @dateFrom and @dataTo and datename(WEEKDAY,date2)=@weekday and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and rest_sale_id not in (select top " + intskip + " rest_sale_id from tbl_sales_record where date_of_sale  between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year))", parm);
        }
        public DataTable totalSalesSum(DateTime dateFrom, DateTime dataTo, string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr  where date_of_sale between @dateFrom and @dataTo   and   sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year)  and datename(WEEKDAY,date2)=@weekday group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable searchbybill2(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.getuser("SELECT  sr.bill_no,sr.item_name,sr.quantity,sr.total,sr.date_of_sale,sr.payment_mode,sr.sub_total,sr.discount,sr.cost,sr.cashier_name,sr.date2,sr.rest_sale_id,sr.cash_amount,sr.card_amount, sr.service_charge, sr.tax_amount, sr.grand_total, sr.sales_type, sr.table_no, sr.category_name, sr.customer_no, sr.customer_name FROM tbl_sales_record sr   where   sr.bill_no = @bill_no  and  sr.bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void ) ", parm);
        }
        public DataTable totalSalesSumByBillNo(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@bill_no",bill_no)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where sr.bill_no=@bill_no  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)  group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable searchitembyname2(string item_name, DateTime dateFrom, DateTime dataTo, string column_name, string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                 new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select * from tbl_sales_record where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and datename(WEEKDAY,date2)=@weekday", parm);
        }
        public DataTable totalSalesSumBYdifferentColumn(string item_name, DateTime dateFrom, DateTime dataTo, string column_name, string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                 new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from (select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and datename(WEEKDAY,date2)=@weekday group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable searchALLSalesWithWeekDay(DateTime dateFrom, DateTime dateTo, string weekday)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dateTo",dateTo),
                 new SqlParameter("@weekday",weekday)


            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S WHERE bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void) and  date2 between @dateFrom and @dateTo and datename(WEEKDAY,date2)=@weekday)SELECT s.* FROM summary s WHERE s.rk = 1  order by s.bill_no asc  ", parm);
        }
        public DataTable sumALLSalesWithWeekDay(DateTime dateFrom, DateTime dateTo, string weekday,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dateTo",dateTo),
                 new SqlParameter("@weekday",weekday),
                   new SqlParameter("@fiscal_year",fiscal_year)


            };
            return DAL.getuser("select sum(DISTINCT sr.sub_total) as total, sum(sr.quantity) as quantity, sum(DISTINCT sr.discount)as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount, SUM(c.credit_amount) as credit_amount,SUM(DISTINCT sr.tax_amount) as tax_amount, SUM(DISTINCT sr.service_charge) as service_charge, sr.date2  from tbl_sales_record sr left join tbl_customer_credits c on (sr.bill_no = c.bill_no) WHERE sr.bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year) and  date2 between @dateFrom and @dateTo and datename(WEEKDAY, date2) = @weekday  group by date2 order by date2 asc ", parm);
        }
    }
}
