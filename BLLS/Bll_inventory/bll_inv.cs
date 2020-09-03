using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DOA;
namespace BLLS.Bll_inventory
{
  public  class bll_inv
    {
        public DataTable getalldata() {
            return DAL.getuser("select *from tbl_inventory",null);
        }
        public DataTable getalldatabyMunuId(string name) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name)
            };
            return DAL.getuser("select *from tbl_inventory where MenuName=@name", parm);
        }
        public int insert(string menuCatId, string MenuName, string invCatId, string InvProductname, decimal unit, string unitmeasures) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@menuCatId",menuCatId),
                 new SqlParameter("@MenuName",MenuName),
                  new SqlParameter("@invCatId",invCatId),
                   new SqlParameter("@InvProductname",InvProductname),
                    new SqlParameter("@unit",unit),
                     new SqlParameter("@unitmeasures",unitmeasures),
                     
            };
            return DAL.IDU("insert into tbl_inventory values(@menuCatId,@MenuName,@invCatId,@InvProductname,@unit,@unitmeasures)", parm);
        }

        public int InsertIngredient(int item_id, int category_id, int product_id, string location, decimal qty, string unit, decimal cost)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_id",item_id),
                 new SqlParameter("@category_id",category_id),
                  new SqlParameter("@product_id",product_id),
                   new SqlParameter("@location",location),
                    new SqlParameter("@qty",qty),
                    new SqlParameter("@unit",unit),
                    new SqlParameter("@cost",cost),
             };
            return DAL.IDU("insert into tbl_ingredients(item_id,category_id,product_id,location,qty,unit,price) values(@item_id,@category_id,@product_id,@location,@qty,@unit,@cost)", parm);
        }
        public int UpdateIngredientCalculation(int item_id, decimal product_price, decimal labour_cost, decimal overhead_cost, decimal total_cost)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@item_id",item_id),
                 new SqlParameter("@product_price",product_price),
                  new SqlParameter("@labour_cost",labour_cost),
                   new SqlParameter("@overhead_cost",overhead_cost),
                     new SqlParameter("@total_cost",total_cost),

             };
            return DAL.IDU("update tbl_ingredient_calculation set product_price=@product_price,labour_cost=@labour_cost,overhead_cost=@overhead_cost,total_cost=@total_cost where item_id=@item_id", parm);
        }
        public int InsertIngredientCalculation(int ingredient_id, int item_id, decimal product_price, decimal labour_cost, decimal overhead_cost, decimal total_cost)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@ingredient_id",ingredient_id),
                new SqlParameter("@item_id",item_id),
                 new SqlParameter("@product_price",product_price),
                  new SqlParameter("@labour_cost",labour_cost),
                   new SqlParameter("@overhead_cost",overhead_cost),
                   new SqlParameter("@total_cost",total_cost),

             };

            return DAL.IDU("insert into tbl_ingredient_calculation(ingredient_id, item_id, product_price, labour_cost, overhead_cost,total_cost) values(@ingredient_id, @item_id, @product_price, @labour_cost, @overhead_cost,@total_cost)", parm);
        }
        public DataTable GetIngredientId()
        {
            return DAL.getuser("select max(ingredient_id) from tbl_ingredients", null);
        }
        public DataTable GetItemCost(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_id",item_id)
            };
            return DAL.getuser("select *from tbl_ingredient_calculation where item_id=@item_id", parm);
        }
    }
}
