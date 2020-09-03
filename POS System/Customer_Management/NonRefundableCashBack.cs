using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLLS;

namespace POS_System.Customer_Management
{
  public class NonRefundableCashBack
    {
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        public decimal RefundableAmount(decimal total_balance, decimal total_bill_amount,decimal non_refundable_amount,int customer_id)
        {
            DataTable dt = blcd.getcustomerbalance(customer_id);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["fix_spend_status"].ToString() == "Active")
                {
                    if (total_bill_amount >= non_refundable_amount)
                    {
                        return total_balance;
                    }
                    else if (total_bill_amount < non_refundable_amount)
                    {
                        return total_balance + total_bill_amount - non_refundable_amount;
                    }
                }
                else
                {
                    return total_balance;
                }
            }
            return 0;
        }
    }
}
