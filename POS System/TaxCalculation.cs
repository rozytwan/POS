using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLS;
using System.Data;

namespace POS_System
{
    class TaxCalculation
    {
        BLL_Tax blt = new BLL_Tax();
        public decimal tax_calculation(decimal amount)
        {
            DataTable dt = blt.get_all_tax_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tax_value"].ToString() == "True")
                {
                    decimal tax_per = Convert.ToDecimal(dt.Rows[0]["tax_amount"].ToString());
                    decimal cal_with = (amount*tax_per)/100;
                    return cal_with;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
       
        public decimal service_calculation(decimal amount)
        {
            DataTable dt = blt.get_all_tax_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["service_charge_value"].ToString() == "True")
                {
                    decimal service_per = Convert.ToDecimal(dt.Rows[0]["service_charge_amount"].ToString());
                    decimal cal_with = (amount * service_per) / 100;
                    return cal_with;
                }
                else
                {
                    
                    return 0;
                }
            }
            return 0;
        }
        public decimal IncludingtaxCalculation(decimal amount)
        {
            DataTable dt = blt.get_all_tax_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tax_value"].ToString() == "True")
                {
                    decimal tax_per = Convert.ToDecimal(dt.Rows[0]["tax_amount"].ToString());
                    decimal ca_inctax = (amount - (amount * (100 / (100 + tax_per))));
                    return ca_inctax;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public decimal IncludingserviceChargeCalculation(decimal amount)
        {
            DataTable dt = blt.get_all_tax_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["service_charge_value"].ToString() == "True")
                {
                    decimal serper_per = Convert.ToDecimal(dt.Rows[0]["tax_amount"].ToString());
                    decimal cal_servi = (amount - (amount * (100 / (100 + serper_per))));
                    return cal_servi;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
