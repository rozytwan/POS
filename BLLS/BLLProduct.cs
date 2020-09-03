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
    public class BLLProduct
    {
        

        public DataTable getproductid(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
            new SqlParameter ("@category_id", category_id)
             };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_stock_products where category_id=@category_id", parm);
            return dt;
        }
        public DataTable getallproductid(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
            new SqlParameter ("@product_id",product_id)
         };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_product where product_id=@product_id", parm);
            return dt;
        }
     
        public DataTable getallproduct()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_product", null);
            return dt;
        }
    

        public DataTable getallItems()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_items", null);
            return dt;
        }
    }
}

