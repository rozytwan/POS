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
   public class BLLKitchenOrderInfo
    {
        public int InsertKitchenInfo(string table_no, int no_of_adult, int no_of_children, int total)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no),
                    new SqlParameter("@no_of_adult",no_of_adult),
                    new SqlParameter("@no_of_children",no_of_children),
                    new SqlParameter("@total",total)
                };
            return DAL.IDU("insert into tbl_orders_info (table_no,no_of_adult,no_of_children,total_no) values (@table_no,@no_of_adult,@no_of_children,@total)", parm);
        }
        public int UpdateKitchenInfo(string table_no, int no_of_adult, int no_of_children, int total)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no),
                    new SqlParameter("@no_of_adult",no_of_adult),
                    new SqlParameter("@no_of_children",no_of_children),
                    new SqlParameter("@total",total)
                };
            return DAL.IDU("update  tbl_orders_info set no_of_adult=@no_of_adult,no_of_children=@no_of_children,total_no=@total where table_no=@table_no", parm);
        }
        public DataTable GetAlltableInfo(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no)
                };
            return DAL.getuser("select * from tbl_orders_info where table_no=@table_no", parm);
        }
        public int InsertCoverUp(int bill_no, int no_of_adult, int no_of_children, int total,string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                    new SqlParameter("@no_of_adult",no_of_adult),
                    new SqlParameter("@no_of_children",no_of_children),
                    new SqlParameter("@total",total),
                      new SqlParameter("@table_no",table_no)
                };
            return DAL.IDU("insert into tbl_sales_coverup (bill_no,no_of_adult,no_of_children,total_no,table_no) values (@bill_no,@no_of_adult,@no_of_children,@total,@table_no)", parm);
        }
    }
}
