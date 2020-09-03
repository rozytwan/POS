using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.IRT
{
    class IRDOfflineSync
    {

        //  DataTable dt = blbt.checkDataIRDCBMS();
        //if (dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        int IRDOnline = apir.posBilling(dt.Rows[i]["buyer_pan"].ToString(), dt.Rows[i]["buyer_name"].ToString(), dt.Rows[i]["invoice_number"].ToString(), dt.Rows[i]["invoice_date"].ToString(), Convert.ToDouble(dt.Rows[i]["total_sales"]), Convert.ToDouble(dt.Rows[i]["taxable_sales_vat"]), Convert.ToDouble(dt.Rows[i]["vat"]), false);
        //        if (IRDOnline > 0)
        //        {
        //          int syncWithIRD = blfsc.updateSyncIRD(Convert.ToInt32(dt.Rows[i]["invoice_number"]));
        //        }
        //    }
        //    int irdTruncate = blbt.truncateIRDData();
    }


}
