using DOA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
  public  class BLLSystemCommand
    {
        public int TruncateTablebillInvoice()
        {
            return DAL.IDU("truncate table tbl_bill_invoice;",null);
        }
        public int TruncateTablebillReprint()
        {
            return DAL.IDU("truncate table tbl_bill_reprint;", null);
        }
        public int TruncateTablematerilizedView()
        {
            return DAL.IDU("truncate table tbl_materialized_view;", null);
        }
        public int TruncateTableSalesRecord()
        {
            return DAL.IDU("truncate table tbl_sales_record;", null);
        }
        public int TruncateTablebillVoid()
        {
            return DAL.IDU("truncate table tbl_bill_void;", null);
        }
        public int TruncateTableComplementrySales()
        {
            return DAL.IDU("truncate table tbl_complementry_sales;", null);
        }
        public int TruncateTableComplemenrtyTracking()
        {
            return DAL.IDU("truncate table tbl_complementry_tracking;", null);
        }
        public int TruncateTableIrdCBMSOffline()
        {
            return DAL.IDU("truncate table tbl_ird_cbms_offline;", null);
        }
        public int TruncateTableIrdCBMSSROffline()
        {
            return DAL.IDU("truncate table tbl_ird_cbms_sr_offline;", null);
        }
        public int TruncateTableOrderCancel()
        {
            return DAL.IDU("truncate table tbl_ordercancel;", null);
        }
    }
}
