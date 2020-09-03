using BLLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
   
   public class IngridentCostCalculation
    {
        BLLIngredientManagement bim = new BLLIngredientManagement();
        public decimal IngredintCostCalculation(string unit,decimal cost,int product_id,string punit)
        {
           
            if (unit == punit)
            {
                decimal totalCost = cost;
                return totalCost;
            }
            else
            {
                DataTable dtm = bim.getAllProductById(product_id);
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["inhouse_unit_1"].ToString() == punit)
                    {
                        if (dtm.Rows[0]["inhouse_unit_3"].ToString() == "")
                        {
                            decimal lastqty = Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_2"]);
                            if (lastqty > 0)
                            {
                                decimal total_price = cost / lastqty;
                                return total_price;
                            }
                        }
                        else
                        {
                            decimal lastqty = Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_2"]);
                            if (lastqty > 0)
                            {
                                decimal total_price = cost / lastqty;
                                return total_price;
                            }
                        }
                    }
                   else if (dtm.Rows[0]["inhouse_unit_2"].ToString() == punit)
                    {
                        decimal lastqty = Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]);
                        if (lastqty > 0)
                        {
                            decimal total_price = cost / lastqty;
                            return total_price;
                        }
                    }
                }
                
            }
            return 0;
            //else if ()
            //{ }

        }
    } 
}
