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
   public class BLLHotelReport
    {

        public DataTable totalHotelSalesSum(DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr  where date_of_sale between @dateFrom and @dataTo   and   sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and sales_type='HS' group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable totalhotelSalesSumByBillNo(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@bill_no",bill_no)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from(select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where sr.bill_no=@bill_no  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and sales_type='HS'  group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable totalHotelSalesSumBYdifferentColumn(string item_name, DateTime dateFrom, DateTime dataTo, string column_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name)
            };
            return DAL.getuser("select sum(sr.grand_total) as grand_total,Sum(sr.tax_amount)as tax_amount,SUM(sr.total) as total,Sum(sr.discount) as discount,SUM(sr.quantity) as quantity,SUM(sr.service_charge) as service_charge, SUM(sr.taxable_amount) as taxable_amount from (select sum(DISTINCT sr.sub_total) as total, sum(DISTINCT sr.quantity) as quantity, sum(DISTINCT sr.discount) as discount, SUM(DISTINCT sr.grand_total) as grand_total, SUM(DISTINCT sr.taxable_amount) as taxable_amount,SUM(DISTINCT sr.tax_amount) as tax_amount,SUM(DISTINCT sr.service_charge) as service_charge, sr.bill_no as bill_no,sr.date2  from tbl_sales_record sr where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and sales_type='HS' group by sr.bill_no,sr.date2) sr", parm);
        }
        public DataTable searchitembyname2_taX_SALES(string item_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and item_name like @item_name +'%' and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and  date2 between @dateFrom and @dataTo and sales_type='HS'", parm);
        }
        public DataTable searchby_kot_type(string kot_type, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kot_type",kot_type),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_sales_record where kot_type=@kot_type and date2 between @dateFrom and @dataTo and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and sales_type='HS'", parm);
        }
        public DataTable searchbycategory_for_tax_(string category_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@category_name",category_name),
                 new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and category_name like @category_name +'%'  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and  date2 between @dateFrom and @dataTo and sales_type='HS'", parm);
        }
        public DataTable searchbybill2_for_tax(string bill_no, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),
                 new SqlParameter("@date2",date2)

            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no asc) AS rk FROM tbl_sales_record S where  datepart(month,date2) = datepart(month,date2) and datepart(year, date2) = datepart(year, @date2))SELECT s.*FROM summary s WHERE s.rk = 1 and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and bill_no = @bill_no and sales_type='HS' ", parm);
        }
        public DataTable searchALL_for_tax(DateTime dateFrom, DateTime dateTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dateTo",dateTo)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S WHERE bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void) and  date2 between @dateFrom and @dateTo  and sales_type='HS')SELECT s.* FROM summary s WHERE s.rk = 1; ", parm);
        }
        public DataTable searchpayment_mode_for_tax(string payment_mode, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@payment_mode",payment_mode),
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and payment_mode=@payment_mode and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and date2 between @dateFrom and @dataTo  and sales_type='HS' ", parm);
        }
        public DataTable searchsale_by_user_for_tax(string cashier_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@cashier_name",cashier_name),
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and cashier_name=@cashier_name and date2 between @dateFrom and @dataTo  and sales_type='HS'", parm);
        }
        public DataTable searchsale_by_serviceprovider_for_tax(string service_provider, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@service_provider",service_provider),
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) and service_provider=@service_provider and date2 between @dateFrom and @dataTo  and sales_type='HS' ", parm);
        }
    }
}
