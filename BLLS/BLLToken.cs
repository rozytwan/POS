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
    public class BLLToken
    {
        public DataTable get_token_no()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(token_no) from tbl_token_no", null);
            return dt;
        }
        public DataTable get_all_data_token()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select top 25 token_no from tbl_token_no t right join tbl_orders_token o on(t.token_no=o.table_no) group by token_no order by token_no desc", null);
            return dt;
        }
        public DataTable get_all_data_by_dec()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_token_no order by token_no asc", null);
            return dt;

        }
        public int delete_token_no(int token_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@token_no",token_no)
                };
            return DAL.IDU("delete from tbl_token_no where token_no=@token_no", parm);
        }

        public DataTable get_all_data_by_bill_no(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no)
                };
            return DAL.getuser("select * from tbl_sales_record where bill_no=@bill_no", parm);
        }

      
 
        public DataTable getallfromosales_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            DataTable dt = DAL.getuser("select * from tbl_sales_record where rest_sale_id=@order_id", parm);
            return dt;
        }
        public int deleteitemfromsales(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@order_id",order_id)

               };
            return DAL.IDU("delete from tbl_sales_record where rest_sale_id=@order_id", parm);
        }
        public DataTable getallfromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            DataTable dt = DAL.getuser("select * from tbl_orders_token where order_id=@order_id", parm);
            return dt;
        }
    }
}
