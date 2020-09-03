using BLLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    public class Ingredient
    {
        BLLIngredientManagement bim = new BLLIngredientManagement();
        string unit;
        decimal qty_unit;
        public void ingredientManage(int item_id, decimal quantity)
        {
            if (item_id > 0)
            {
                DataTable dt = bim.getAllIngredient(item_id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        DataTable dtm = bim.getAllProductById(Convert.ToInt32(dt.Rows[i]["product_id"]));
                        if (dtm.Rows.Count > 0)
                        {
                            if ((dtm.Rows[0]["inhouse_qty_3"]) == DBNull.Value)
                            {
                                (dtm.Rows[0]["inhouse_qty_3"]) = 0;
                            }
                            if ((dtm.Rows[0]["inhouse_qty_2"]) == DBNull.Value)
                            {
                                (dtm.Rows[0]["inhouse_qty_2"]) = 0;
                            }
                            if (dt.Rows[0]["unit"].ToString() == dtm.Rows[0]["inhouse_unit_1"].ToString())
                            {
                                //logic not working properly        
                                // inhouse unit 1 empty bhayo bhane 
                                //inhouse unit 2 empty bhayo bhane
                                //and test it well         
                                if (Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) > 0)
                                {
                                    qty_unit = (Convert.ToDecimal(Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity));
                                    unit = dt.Rows[0]["unit"].ToString();
                                }
                                else if (Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_2"]) > 0)
                                {
                                    qty_unit = (Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity);
                                    unit = dt.Rows[0]["unit"].ToString();
                                }
                                else
                                {
                                    qty_unit = (Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity);
                                    unit = dt.Rows[0]["unit"].ToString();
                                }
                            }

                            else if (dt.Rows[0]["unit"].ToString() == dtm.Rows[0]["inhouse_unit_2"].ToString())
                            {
                                if (Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) > 0)
                                {
                                    qty_unit = Convert.ToDecimal(dtm.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity;
                                    unit = dt.Rows[0]["unit"].ToString();
                                }
                                else
                                {
                                    qty_unit = Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity;
                                    unit = dt.Rows[0]["unit"].ToString();

                                }
                            }
                            else
                            {
                                qty_unit = Convert.ToDecimal(dt.Rows[i]["qty"]) * quantity;
                                unit = dt.Rows[0]["unit"].ToString();
                            }

                            int abc = bim.StockIngredientUpdate(Convert.ToInt32(dt.Rows[i]["product_id"]), qty_unit, dt.Rows[i]["location"].ToString());
                            if (abc > 0)
                            {
                                int stockSalesLog = bim.stockSalesLog(item_id, Convert.ToInt32(dt.Rows[i]["product_id"]), qty_unit, unit, dt.Rows[i]["location"].ToString(), Convert.ToDateTime(DateTime.Now.ToShortDateString()), "");
                            }
                        }

                    }
                }
            }
        }
    }
}

