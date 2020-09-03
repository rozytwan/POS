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
 public  class BLLRestaurantReport
    {
        public DataTable totalSalesSum(DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr  where date_of_sale between @dateFrom and @dataTo   and   sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)  group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable totalSalesSumByBillNo(string bill_no, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@bill_no",bill_no),
                  new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where sr.bill_no=@bill_no  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)  group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable totalSalesSumBYdifferentColumn(string item_name, DateTime dateFrom, DateTime dataTo, string column_name,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from (select sum(sr.total) as total, sum( sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable searchitembyColumnNameDynamic(string item_name, DateTime dateFrom, DateTime dataTo, string column_name, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                  new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  sr.bill_no,sr.item_name,sr.quantity,sr.total,sr.date_of_sale,sr.cost,sum(sr.total) over (partition by bill_no) sub_total,((discount*100)/sub_total) as discount,sr.cash_amount, sr.card_amount, sr.service_charge, sr.tax_amount, sr.grand_total, sr.sales_type FROM    tbl_sales_record sr where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable GetFiscalYearsales( DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {      
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select fiscal_year from tbl_sales_record where date_of_sale between @dateFrom and @dataTo", parm);
        }
        public DataTable GetFiscalYearsalesBydate2(DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select fiscal_year from tbl_sales_record where date2 between @dateFrom and @dataTo", parm);
        }


    }
}
