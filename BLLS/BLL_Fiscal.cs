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
    public class BLL_Fiscal
    {
        public int insert_Materialized_View(string fiscal_year, int bill_no, string customer_name, string customer_pan, DateTime bill_date, decimal amount, decimal discount, decimal taxable_amount, decimal tax_amount, string is_printed, string is_active, string printed_time, string entered_by, string printed_by, string sync_with_ird, string is_real_time)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@fiscal_year",fiscal_year),
                new SqlParameter("@bill_no",bill_no),
                new SqlParameter("@customer_name",customer_name),
                new SqlParameter("@customer_pan",customer_pan),
                new SqlParameter("@bill_date",bill_date),
                new SqlParameter("@amount",amount),
                new SqlParameter("@discount",discount),
                new SqlParameter("@taxable_amount",taxable_amount),
                new SqlParameter("@tax_amount",tax_amount),
                new SqlParameter("@is_printed",is_printed),
                new SqlParameter("@printed_time",printed_time),
                 new SqlParameter("@is_active",is_active),
                new SqlParameter("@entered_by",entered_by),
                new SqlParameter("@printed_by",printed_by),
                  new SqlParameter("@sync_with_ird",sync_with_ird),
                new SqlParameter("@is_real_time",is_real_time)

            };
            return DAL.IDU("insert into tbl_materialized_view (fiscal_year,bill_no,customer,customer_pan,bill_date,amount,discount,taxable_amount,tax_amount,is_printed,is_active,printed_time,entered_by,printed_by,Sync_with_ird,is_real_time)values(@fiscal_year,@bill_no,@customer_name,@customer_pan,@bill_date,@amount,@discount,@taxable_amount,@tax_amount,@is_printed,@is_active,@printed_time,@entered_by,@printed_by,@Sync_with_ird,@is_real_time)", parm);
        }
        public DataTable get_all_data_from_fiscal(string is_active)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@is_active",is_active)
           };
            return DAL.getuser("select * from tbl_fiscal_year where is_active =@is_active", parm);
        }
     
        public DataTable get_all_data_from_fiscal_year()
        {
          
            return DAL.getuser("select * from tbl_fiscal_year ", null);
        }
        public int add_new_fiscal_year(DateTime fiscal_year_start, DateTime fiscal_year_to,string fiscal_year,string is_active)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@fiscal_year_start",fiscal_year_start),
                    new SqlParameter("@fiscal_year_end",fiscal_year_to),
                     new SqlParameter("@fiscal_year",fiscal_year),
                     new SqlParameter("@is_active",is_active)

                };
            return DAL.IDU("insert into tbl_fiscal_year (fiscal_year_start,fiscal_year_end,fiscal_year,is_active) values (@fiscal_year_start,@fiscal_year_end,@fiscal_year,@is_active)", parm);
                
        }
        public int update_fiscal_year()
        {
          
            return DAL.IDU("update tbl_fiscal_year set is_active='False' where is_active ='True'", null);
        }
        public int update__materialized(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.IDU("update tbl_materialized_view set is_printed='True' where bill_no =@bill_no", parm);
        }
        public int updateSyncIRD(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.IDU("update tbl_materialized_view set sync_with_ird='true' where bill_no =@bill_no", parm);
        }
        public int updateVOidMateri(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.IDU("update tbl_materialized_view set is_active='false' where bill_no =@bill_no", parm);
        }
        public DataTable search_materialized_by_bill(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),
              
            };
            return DAL.getuser("select * from tbl_materialized_view where bill_no =@bill_no ", parm);
        }
        public DataTable search_materialized_by_fiscal(string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@fiscal_year",fiscal_year),

            };
            return DAL.getuser("select * from tbl_materialized_view where fiscal_year =@fiscal_year ", parm);
        }
        public DataTable search_materialized_by_all( DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
              
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_materialized_view where CAST(bill_date as date) between @dateFrom and @dataTo", parm);
        }
        public DataTable GetFiscalYear()
        {
            return DAL.getuser("select cast(fiscal_year_end as date) from tbl_fiscal_year ", null);
        }
        public int UpdateNewFiscalYear(int fiscal_id, DateTime fiscal_year_to, string fiscal_year, string is_active)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@fiscal_id",fiscal_id),
                    new SqlParameter("@fiscal_year_end",fiscal_year_to),
                     new SqlParameter("@fiscal_year",fiscal_year),
                     new SqlParameter("@is_active",is_active)

                };
            return DAL.IDU("update tbl_fiscal_year set fiscal_year_end=@fiscal_year_end,fiscal_year=@fiscal_year,is_active=@is_active where fiscal_id=@fiscal_id", parm);

        }
        public DataTable GetFiscalById(int fiscal_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@fiscal_id",fiscal_id),

            };
            return DAL.getuser("select * from tbl_fiscal_year where fiscal_id =@fiscal_id ", parm);
        }
    }
} 
