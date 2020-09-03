using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data.SqlClient;

namespace BLLS
{
    public class BLLMenuItem
    {
        public DataTable getproductitems()
        {
            return DAL.getuser("Select i.item_id,item_name,item_price,i.category_id,kot_print,item_cost_price,sum(ingredient_id) as ingredient_id,applicable_time_period from tbl_items i left join tbl_ingredients ig on (i.item_id = ig.item_id) group by i.item_id, item_name, item_price, i.category_id, kot_print, item_cost_price,applicable_time_period order by i.item_name ASC ", null);
        }

        public DataTable getproductitemWithoutJoin()
        {
            return DAL.getuser("Select i.item_id,item_name,item_price,i.category_id,kot_print,item_cost_price,applicable_time_period from tbl_items i", null);
        }
        public DataTable GetLessIngredientByItem(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@item_id", item_id)
          };
            return DAL.getuser("select product_name,s.product_id,unit,location,ingredient_id,qty,price from tbl_ingredients i join tbl_stock_products s on (i.product_id=s.product_id) where item_id=@item_id and qty=min_stock or qty<min_stock and location='M'", parm);
        }
        public DataTable GetIngredient(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id)
            };

            return DAL.getuser("Select * from tbl_ingredients where item_id = @item_id", parm);
        }

        public DataTable getitemby_dec()
        {
            return DAL.getuser("Select * from tbl_items order by item_id DESC", null);
        }
        public int addproductitems(string item_name, decimal item_cost_price, decimal item_selling_price, int category_id, string kot_print, byte[] image_name, string applicable_time_period, string image_color, decimal discount)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_name", item_name),
                new SqlParameter("@item_cost_price", item_cost_price),
                new SqlParameter("@item_selling_price", item_selling_price),
                new SqlParameter("@category_id", category_id),
                new SqlParameter("@kot_print", kot_print),
                new SqlParameter("@image_name", image_name),
                new SqlParameter("@applicable_time_period", applicable_time_period),
                new SqlParameter("@image_color", image_color),
                new SqlParameter("@discount", discount),

            };

            return DAL.IDU("Insert into tbl_items(item_name,item_cost_price,item_price,category_id,kot_print,image_name,applicable_time_period,image_color,discount) values(@item_name,@item_cost_price,@item_selling_price,@category_id,@kot_print,@image_name,@applicable_time_period,@image_color,@discount)", parm);
        }

        public DataTable getcategorybycategoryid(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };

            return DAL.getuser("Select * from tbl_item_category where category_id = @category_id", parm);
        }
        public DataTable getcategorybycategoryid_by_order(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };

            return DAL.getuser("Select * from tbl_items where category_id = @category_id order by image_name DESC", parm);
        }
        public DataTable getcategorybycategoryNames(string  category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_name", category_name)
            };

            return DAL.getuser("Select * from tbl_item_category where category_name like @category_name + '%'", parm);
        }

        public int updateproductitems(int itemid, string name, int categoryid, decimal cost_price, decimal selling_price, string applicabletimeperiod, string kotprint, byte[] imagename, string color, decimal discount)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@itemid", itemid),
                    new SqlParameter("@name", name),
                    new SqlParameter("@categoryid", categoryid),
                    new SqlParameter("@cost_price", cost_price),
                    new SqlParameter("@selling_price", selling_price),
                    new SqlParameter("@applicabletimeperiod", applicabletimeperiod),
                    new SqlParameter("@kotprint", kotprint),
                    new SqlParameter("@imagename", imagename),
                    new SqlParameter("@color", color),
                    new SqlParameter("@discount", discount),
            };
            return DAL.IDU("Update tbl_items set item_name = @name, item_cost_price = @cost_price, item_price = @selling_price, category_id = @categoryid, kot_print = @kotprint, image_name = @imagename, applicable_time_period = @applicabletimeperiod, image_color = @color,discount=@discount where item_id = @itemid", parm);
        }
        public int deleteproductitems(int itemid)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@itemid", itemid)
            };
            return DAL.IDU("Delete from tbl_items where item_id = @itemid", parm);
        }
        public DataTable get_item_by_item_id(int itemid)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@itemid", itemid)
            };
            return DAL.getuser("select * from tbl_items where item_id = @itemid", parm);
        }

        public DataTable getproductbyproductname(string productname)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@productname", productname)
            };
            return DAL.getuser("Select * from tbl_items where item_name like '%' + @productname + '%'", parm);
        }
       
        public DataTable get_item_byname(string productname)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@productname", productname)
            };
            return DAL.getuser("Select * from tbl_items where item_name =@productname", parm);
        }

        public int adddays(int item_id, string days)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id),
                new SqlParameter("@days", days)
            };
            return DAL.IDU("Insert into tbl_dayswise values(@item_id,@days)", parm);
        }

        public int deleterecords(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id)
            };
            return DAL.IDU("Delete from tbl_dayswise where item_id = @item_id", parm);
        }

        public DataTable getdayswiserecords(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id)
            };
            return DAL.getuser("Select * from tbl_dayswise where item_id = @item_id", parm);
        }
     
        public DataTable getimage_namebyitem_id(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id)
            };
            return DAL.getuser("Select * from tbl_items where item_id = @item_id", parm);
        }

      
        public DataTable getcategoryDetailsByCategoryIds(int category)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category", category)
            };
            return DAL.getuser("Select * from tbl_items where category_id = @category", parm);
        }

        public DataTable getitembycategoryid_temp_view(int category_id, int db_item_id, int db_item_id2)
        {
            SqlParameter[] parm = new SqlParameter[]
                       {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@db_item_id",db_item_id),
             new SqlParameter("@db_item_id2",db_item_id2)
                       };
            return DAL.getuser("with temp as (SELECT ROW_NUMBER() over (order by item_name) as ROW_NUMBER,item_id,item_name,item_price,category_id,kot_print,applicable_time_period,image_color,item_cost_price,image_name from tbl_items where category_id=@category_id )(select * from temp where ROW_NUMBER between @db_item_id AND @db_item_id2)", parm);
        }
        //for temp only
        public DataTable getitembycategoryid_temp_viewOrderBySalesQty(int category_id, int db_item_id, int db_item_id2, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[]
                       {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@db_item_id",db_item_id),
             new SqlParameter("@db_item_id2",db_item_id2),
              new SqlParameter("@fiscal_year",fiscal_year)
                       };
            return DAL.getuser("with temp as(select ROW_NUMBER() over (order by item_name) as ROW_NUM, * from ViewItemOrderBYSales where category_id = @category_id)(select * from temp where ROW_NUM between @db_item_id AND @db_item_id2)order by qty desc", parm);
        }


    }
}
