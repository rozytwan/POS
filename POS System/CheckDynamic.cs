using BLLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace POS_System
{
    class CheckDynamic
    {
        BLLDynamic bld = new BLLDynamic();
        string returnno;
        bool access=false;
        string panvat;
        public string TakeAwayAccess()
        {
            returnno = "Take Away";
            DataTable dt1 = bld.GetTakeAwayDynamic();
            if (dt1.Rows.Count > 0)
            {
                string rename = dt1.Rows[0]["description"].ToString();
                return returnno = rename;
               
            }
            return returnno;
        }
        public string ProviderName()
        {
            returnno = "Service Provider";
            DataTable dtrename = bld.GetProviderRename();
            if (dtrename.Rows.Count > 0)
            {
                returnno = dtrename.Rows[0]["description"].ToString();

            }
             return returnno;
        }
        public string CheckoutRename()
        {
            returnno = "Check Out";
            DataTable dtrename = bld.GetDynamic("COR");
            if (dtrename.Rows.Count > 0)
            {
                returnno = dtrename.Rows[0]["description"].ToString();

            }
            return returnno;
        }
        public bool ServiceProviderAccess()
        {
            access = false;
            returnno = "Service Provider";
            DataTable dt1 = bld.GetServiceProvider();
            DataTable dtkot = bld.GetKotName();
            if (dt1.Rows.Count > 0)
            {
              
                access = true;
            }
          
            return access;
        }
        public string KOTRename()
        {
            returnno = "KOT";
            DataTable dtkot = bld.GetKotName();
            if (dtkot.Rows.Count > 0)
            {
                returnno = dtkot.Rows[0]["description"].ToString();

            }
            return returnno;
        }
        public string DynamicPan()
        {
            panvat = "Pan No.";
            DataTable dtpanorvat = bld.GetPanVat();
            if (dtpanorvat.Rows.Count > 0)
            {
                panvat = dtpanorvat.Rows[0]["description"].ToString();
            }
            return panvat;
        }
        public string QuotationName()
        {
           
            DataTable dtname = bld.GetQuotationName();
            if (dtname.Rows.Count > 0)
            {
                 return  dtname.Rows[0]["description"].ToString();
            
            }
            return "Quotation Print";
        }
        public string HomeDeliveryLoad()
        {
            DataTable dtload = bld.GetDynamic("CHDP");
            if (dtload.Rows.Count > 0)
            {
                return dtload.Rows[0]["description"].ToString();

            }
            return "KOTOrder First";
        }
        public string TableLoad()
        {
            DataTable dtload = bld.GetDynamic("TOP");
            if (dtload.Rows.Count > 0)
            {
                return dtload.Rows[0]["description"].ToString();

            }
            return "KOTOrder First";
        }
        public string BusinessType()
        {
            DataTable dtload = bld.GetDynamic("BT");
            if (dtload.Rows.Count > 0)
            {
                return dtload.Rows[0]["description"].ToString();
             }
            return "Restaurant";
        }
        public string TokenLoad()
        {
            DataTable dtload = bld.GetDynamic("TP");
            if (dtload.Rows.Count > 0)
            {
                return dtload.Rows[0]["description"].ToString();

            }
            return "KOTOrder First";
        }
        public string TakeAwayLoad()
        {
            DataTable dtload = bld.GetDynamic("TAP");
            if (dtload.Rows.Count > 0)
            {
                return dtload.Rows[0]["description"].ToString();

            }
            return "KOTOrder First";
        }
        public bool QuotationAccess()
        {
         
            DataTable dtload = bld.GetQuotationAccess();
            if (dtload.Rows.Count > 0)
            {
                return  true;
            }

            return false;
        }
        public bool ChequeDetailAccess()
        {

            DataTable dtload = bld.GetChequeDetailAccess();
            if (dtload.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        public bool PurchaseCashDropAccess()
        {
            DataTable dtload = bld.GetDynamic("PCD");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }
        public string CheckPrinterName()
        {
             DataTable dtname = bld.GetDynamic("QPN");
            if (dtname.Rows.Count > 0)
            {
               return dtname.Rows[0]["description"].ToString();

            }
            return "U";
        }
        public string CheckDayEndPrint()
        {
            DataTable dtname = bld.GetDynamic("DEP");
            if (dtname.Rows.Count > 0)
            {
                return dtname.Rows[0]["description"].ToString();

            }
            return "U";
        }
        public string CheckBillingPrint()
        {
            DataTable dtname = bld.GetDynamic("BPN");
            if (dtname.Rows.Count > 0)
            {
                return dtname.Rows[0]["description"].ToString();

            }
            return "Billing";
        }
        public bool QuotationHeaderPrint()
        {
           DataTable dtload = bld.GetDynamic("QPH");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status=="True")
                {
                 return true;
                }
                else
                {
                    return false;
                }
               
            }

            return false;
        }

        public bool QuotationFooterPrint()
        {
            DataTable dtload = bld.GetDynamic("QPF");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public bool BillingFooterPrint()
        {
            DataTable dtload = bld.GetDynamic("BPF");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool ComplementryAllAccess()
        {
            DataTable dtload = bld.GetDynamic("CSA");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool TableServiceCharge()
        {
            DataTable dtload = bld.GetDynamic("SCT");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool RoomServiceCharge()
        {
            DataTable dtload = bld.GetDynamic("RSC");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool TakeAwayServiceCharge()
        {
            DataTable dtload = bld.GetDynamic("SCTA");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool DiscountBelowEstimate()
        {
            DataTable dtload = bld.GetDynamic("BEC");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool DiscountBelowDiscountCost()
        {
            DataTable dtload = bld.GetDynamic("BDC");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool KotEnableDisable()
        {
            DataTable dtload = bld.GetDynamic("KED");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool GrandTotalRequired()
        {
            DataTable dtload = bld.GetDynamic("GTIW");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool CoverUpDynamic()
        {
            DataTable dtload = bld.GetDynamic("CU");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool KotSaveEnableDisable()
        {
            DataTable dtload = bld.GetDynamic("KSED");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool Fixgrouping()
        {
            DataTable dtload = bld.GetDynamic("FG");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool Hidegrouping()
        {
            DataTable dtload = bld.GetDynamic("HG");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool TokenBillingServiceCharge()
        {
            DataTable dtload = bld.GetDynamic("SCTB");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool HotelEnableDisable()
        {
            DataTable dtload = bld.GetDynamic("HED");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool CheckabbreviatedTax()
        {
            DataTable dtload = bld.GetDynamic("ATU");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool CheckCustomerSettlement()
        {
            DataTable dtload = bld.GetDynamic("CS");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public decimal CheckabbreviatedTaxAmount()
        {
            DataTable dtload = bld.GetDynamic("ATU");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return Convert.ToDecimal(dtload.Rows[0]["description"].ToString());
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }
        public bool ComplementryAllPrint()
        {
            DataTable dtload = bld.GetDynamic("CPA");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool AccountAccess()
        {
            DataTable dtload = bld.GetDynamic("AA");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }
        public string LoyaltyPoint()
        {
            DataTable dtload = bld.GetDynamic("LP");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return dtload.Rows[0]["description"].ToString();
                }
                else
                {
                    return "";
                }

            }

            return "";
        }
        public string FonePayCheck()
        {
            DataTable dtload = bld.GetDynamic("FP");
            if (dtload.Rows.Count > 0)
            {
                string status = dtload.Rows[0]["status"].ToString();
                if (status == "True")
                {
                    return dtload.Rows[0]["description"].ToString();
                }
                else
                {
                    return "";
                }

            }

            return "";
        }
    }
}
