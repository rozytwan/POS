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
  public  class BLLIngredientManagement
    {
        public DataTable getAllIngredient(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id",item_id)
            };
            return DAL.getuser("select * from tbl_ingredients where item_id=@item_id", parm);
        }
        public DataTable getAllIngredientWithJoin(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id",item_id)
            };
            return DAL.getuser("select product_name,s.product_id,unit,location,ingredient_id,qty,price from tbl_ingredients i join tbl_stock_products s on (i.product_id=s.product_id) where item_id=@item_id", parm);
        }
        public DataTable getAllProductById(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id)
                };
            return DAL.getuser("select * from tbl_stock_products where product_id=@product_id", parm);
        }

        public int StockIngredientUpdate(int product_id, decimal qty,string location)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id),
                     new SqlParameter("@qty",qty),
                      new SqlParameter("@location",location)
                };
            return DAL.IUD_SP("SP_ingredients", CommandType.StoredProcedure, parm);
        }

        public int stockSalesLog(int item_id,int product_id, decimal qty, string unit,string location,DateTime date_of_sales,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id),
                     new SqlParameter("@qty",qty),
                      new SqlParameter("@location",location),
                    new SqlParameter("@item_id",item_id),
                     new SqlParameter("@unit",unit),
                      new SqlParameter("@date_of_sales",date_of_sales),
                        new SqlParameter("@status",status)
                };

            return DAL.IUD_SP("SP_Stock_sales_log", CommandType.StoredProcedure, parm);
        }
        public int deleteIngrendent(int ingredient_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@ingredient_id",ingredient_id)
            };
            return DAL.IDU("delete from tbl_ingredients where ingredient_id=@ingredient_id", parm);
        }

        public int StockWasteInsert(int item_id, decimal qty, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_id",item_id),
                     new SqlParameter("@qty",qty),
                      new SqlParameter("@date",date)
                };
            return DAL.IDU("Insert into tbl_wasteMngt(item_id,quantity,DOE) values (@item_id,@qty,@date)", parm);
        }
    }
}
