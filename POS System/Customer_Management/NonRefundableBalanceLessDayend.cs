using BLLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Customer_Management
{
    public class NonRefundableBalanceLessDayend
    {
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        decimal total_spend_amount;
        public void balanceLessNonRefundable()
        {
            
            decimal fix_balance;
            decimal total_balance_in_card;
            decimal total_balance_to_less;
            DataTable dt = blcd.getAllNonfedundableUser();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    DataTable dtm = blcd.getAllsalesById(Convert.ToInt32(dt.Rows[i]["customer_id"]));
                    if (dtm.Rows.Count > 0)
                    {
                        total_spend_amount = 0;
                        for (int j = 0; j < dtm.Rows.Count; j++)
                        {
                            total_spend_amount+=Convert.ToDecimal(dtm.Rows[j]["grand_total"]);
                        }
                    }
                    else
                    {
                        total_spend_amount = 0;
                    }
                    fix_balance = Convert.ToDecimal(dt.Rows[i]["fix_spend_balance"]);
                    total_balance_in_card = Convert.ToDecimal(dt.Rows[i]["customer_balance"]);
                    if (fix_balance > total_spend_amount)
                    {
                        total_balance_to_less = total_balance_in_card + total_spend_amount - fix_balance;
                        if (total_balance_to_less > 0)
                        {
                            int lessunspendBalance = blcd.totalCardBalanceUnspendLess(Convert.ToInt32(dt.Rows[i]["customer_id"]), total_balance_to_less);
                          
                               
                            
                        }
                    }
                 }
            }

        }
    }
}
