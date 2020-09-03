using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
  public  class BLLDynamic
    {
        public DataTable GetTrueDynamic()
        {
            return DAL.getuser("select * from tbl_dyanmic where status='True'", null);
        }
        public DataTable GetFirstLoadDynamic()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='FL' and status='True'", null);
        }
        public DataTable GetQuotationAccess()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='QA' and status='True'", null);
        }
        public DataTable GetChequeDetailAccess()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='CD' and status='True'", null);
        }
        public DataTable GetImageTb()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='ITB' and status='true'", null);
        }
        public DataTable GetQuotationName()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='QR' and status='True'", null);
        }
        public DataTable GetTakeAwayDynamic()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='TA' and status='True'", null);
        }
        public DataTable GetAdminAccessDiscount()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='AAD'and status='true'", null);
        }
        public DataTable GetAdminAccessComplementry()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='AAC' and status='true'", null);
        }
        public DataTable GetAdminAccessDelete()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='AADlt' and status='true'", null);
        }
        public DataTable GetServiceTable()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='SCT'and status='true'", null);
        }
        public DataTable GetServiceToken()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='SCTB' and status='true'", null);
        }
        public DataTable GetServiceTakeaway()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='SCTA' and status='true'", null);
        }
        public DataTable GetServiceProvider()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='SPA' and status='True'", null);
        }
        public DataTable GetKotName()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='KOTR' and status='True'", null);
        }
        public DataTable GetLoadImage()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='LI' and status='True'", null);
        }
        public DataTable GetProviderRename()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='SPR' and status='True'", null);
        }
        public DataTable EnableTokenBilling()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='TB' and status='True'", null);
        }
        public DataTable GetPanVat()
        {
            return DAL.getuser("select * from tbl_dyanmic where code='PVNo' and status='true'", null);
        }
        public int UpdateDynamic(string description,string code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                   new SqlParameter("@description",description),
                     
                    new SqlParameter("@code",code)
                };
            return DAL.IDU("update  tbl_dyanmic set description=@description,status='True' where code=@code", parm);
        }
        public int UpdateDynamicFalse(string code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                 new SqlParameter("@code",code)
                };
            return DAL.IDU("update  tbl_dyanmic set status='False' where code=@code", parm);
        }
        public DataTable GetDynamic(string code)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
               new SqlParameter("@code",code)
               };
            return DAL.getuser("select * from tbl_dyanmic where code=@code", parm);
        }
        public int InsertDynamic(string controller, string description, string remarks, string code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@controller",controller),
                   new SqlParameter("@description",description),
                   new SqlParameter("@remarks",remarks),
                    new SqlParameter("@code",code),

                };
            return DAL.IDU("Insert into tbl_dyanmic(controller,description,remarks,code,status) values (@controller,@description,@remarks,@code,'True')", parm);
        }
    }
}
