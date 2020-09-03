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
    public   class BLLOrderFire
    {

        public int insertorder_using_sp(string user_name, decimal table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string phone, string service_provider, int KOTId,string fire_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@user_name",user_name),
            new SqlParameter("@table_no",table_no),
            new SqlParameter ("@item",item),
            new SqlParameter("@quantity",quantity),
            new SqlParameter("@total",total),
            new SqlParameter("@cost",cost),
            new SqlParameter("@active",active),
            new SqlParameter("@category_name",category_name),
            new SqlParameter("@kot_print",kot_print),
            new SqlParameter("@phone",phone),
            new SqlParameter("@service_provider",service_provider),
            new SqlParameter("@kot_id",KOTId),
            new SqlParameter("@fire_type",fire_type),

            };
            return DAL.IUD_SP("dbo.sp_kitchen_orders", CommandType.StoredProcedure, parm);
        }
    }
}
