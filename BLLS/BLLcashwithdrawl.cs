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
    public class BLLcashwithdrawl
    {
        public DataTable Search_data_ByDate(DateTime fromdate, DateTime Todate)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@fromdate",fromdate),
new SqlParameter("@Todate",Todate)
            };
            return DAL.getuser("select * from tbl_withdrawl_log where CAST(date as date) between @fromdate and @todate", parm);
        }
        public DataTable Sum_Cash(DateTime fromdate, DateTime Todate)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@fromdate",fromdate),
new SqlParameter("@Todate",Todate)
            };
            return DAL.getuser("select cash from tbl_withdrawl_log where CAST(date as date) between @fromdate and @todate", parm);
        }



    }
}
