using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS
{
    public class BLLdays_wise
    {
        public DataTable getdayswisedatabyItem_Id(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id)
            };
            return DAL.getuser("Select * from tbl_dayswise where item_id = @item_id", parm);
        }
    }
}
