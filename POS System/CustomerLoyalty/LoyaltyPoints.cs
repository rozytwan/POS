using BLLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.CustomerLoyalty
{
   public class LoyaltyPoints
    {
        BLLLoyalty blt = new BLLLoyalty();
        public int amountpointCalculation(decimal amount )
        {
           
            DataTable dtm = blt.getLoyaltyAmountPoint(amount);
            if (dtm.Rows.Count > 0)
            {
                return Convert.ToInt32(dtm.Rows[0][0]);

            }
            return 0;
        }
        public int itemPointCalculation(string item, decimal qty)
        {
           
            DataTable dtm = blt.getLoyaltyItemPoint(item,qty);
            if (dtm.Rows.Count > 0)
            {
                return Convert.ToInt32(dtm.Rows[0][0]);
            }
            return 0;
        }
    }
}
