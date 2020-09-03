using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DOA;
namespace BLLS
{
        public  class Bll_balancesheet
    {
        public DataTable getallIDfromPLTable()
        {
            return  DAL.getuser("select blc_id from tbl_balancesheet", null);

        }

        public DataTable getalldatafromPLTable()
        {
            return  DAL.getuser("select * from tbl_balancesheet", null);

        }



        public int insertintoPL(decimal debitbalc, decimal creditbalc)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@debitbalc",debitbalc),
                new SqlParameter("@creditbalc",creditbalc),

            };
            return  DAL.IDU("insert into  tbl_ProfitnLoss values(@debitbalc,@creditbalc)", parm);


        }

        public int updatentoPL(decimal debitbalc, decimal creditbalc,int bl_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 new SqlParameter("@debitbalc",debitbalc),
                new SqlParameter("@creditbalc",creditbalc),
                new SqlParameter("@bl_id",bl_id)

            };
            return  DAL.IDU("update tbl_ProfitnLoss set debit_total=@debitbalc,credit_total=@creditbalc where blc_id=@bl_id", parm);


        }



    }
}
