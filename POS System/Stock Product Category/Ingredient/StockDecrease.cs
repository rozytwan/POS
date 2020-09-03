using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLLS;

namespace POS_System.Stock_Product_Category.Ingredient
{
  public class StockDecrease
    {
        BLLIngredientManagement tgm = new BLLIngredientManagement();
        public void ItemSalesStockDecrease(int item_id,int qty)
        {
            if (item_id > 0 && qty > 0)
            {
                DataTable dt = tgm.getAllIngredientWithJoin(item_id);
                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string location = dt.Rows[i]["location"].ToString();
                        decimal ingredentQty = Convert.ToDecimal(dt.Rows[i]["qty"]);
                        int product_id = Convert.ToInt32(dt.Rows[i]["product_id"]);
                        decimal totalQty = ingredentQty * qty;
                    }
                   

                }
            }
        }
    }
}
