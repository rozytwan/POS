using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLLS;

namespace POS_System
{
   public class UserLevelDiscount
    {
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLUserLevelDiscount blud = new BLLUserLevelDiscount();
       public decimal discountPercent;
        public decimal discountamount;
        public decimal calculateDiscount(string card_no, decimal grand_total)
        {
            DataTable dt = blcd.getnamebyno(card_no);
            if (dt.Rows.Count > 0)
            {
                DataTable dtm = blud.getByDiscountUserLevel(dt.Rows[0]["card_type"].ToString(), grand_total);
                if (dtm.Rows.Count > 0)
                {
                    discountPercent = Convert.ToDecimal(dtm.Rows[0]["discount_percent"]);
                    if (discountPercent != 0)
                    {
                        discountamount = (grand_total * discountPercent / 100);
                        return discountamount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
           
        }
    }
}
