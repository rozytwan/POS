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
  public class BLLBillingTaxCalculate
    {
        public DataTable getAllNullData()
        {
            return DAL.getuser("select distinct bill_no,sub_total,discount,grand_total,date2,sales_type from tbl_sales_record  where tax_amount is null", null);
        }
        public DataTable getAllData()
        {
            return DAL.getuser("select distinct bill_no,sub_total,discount,grand_total,date2,sales_type from tbl_sales_record ", null);
        }

        public int updatetaxandservice(string bill_no, DateTime date2, decimal tax_amount, decimal service, decimal taxable_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                    new SqlParameter("date2",date2),
                     new SqlParameter("@tax_amount",tax_amount),
                    new SqlParameter("service",service),
                     new SqlParameter("@taxable_amount",taxable_amount)

                };
            return DAL.IDU("update tbl_sales_record set tax_amount=@tax_amount,service_charge=@service,taxable_amount=@taxable_amount where bill_no=@bill_no and date2=@date2", parm);
        }
        public int updatetaxandserviceMet(string bill_no, DateTime date2, decimal tax_amount, decimal taxable_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                    new SqlParameter("date2",date2),
                     new SqlParameter("@tax_amount",tax_amount),               
                     new SqlParameter("@taxable_amount",taxable_amount)

                };
            return DAL.IDU("update tbl_materialized_view set tax_amount=@tax_amount,taxable_amount=@taxable_amount where bill_no=@bill_no", parm);
        }
        public DataTable getAllServiceTax()
        {
            return DAL.getuser("select * from tbl_business_tax", null);
        }
    }
}
