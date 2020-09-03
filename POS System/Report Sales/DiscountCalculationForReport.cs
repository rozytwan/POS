using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    class DiscountCalculationForReport
    {
        public float calculateDiscount(decimal amount, decimal discount_percent)
        {
            if (amount != null && discount_percent != null && discount_percent > 0 && amount > 0)
            {
                float discount_amount = (float)((amount * discount_percent) /100);
                return discount_amount;
            }
            return 0;
        }
        public decimal calculateDiscountPercent(decimal amount, decimal discount)
        {
            if (amount != null && discount != null && discount > 0 && amount > 0)
            {
                decimal discount_amount = (((Convert.ToDecimal(discount)) * 100) / (Convert.ToDecimal(amount)));
                return discount_amount;
            }
            return 0;
        }
    }
   
}
