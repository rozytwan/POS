using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data.SqlClient;
using System.Data;

namespace BLLS
{


    public class Bll_profit_loss
    {
        public DataTable getallIDfromPLTable()
        {
            return DAL.getuser("select pl_id from tbl_ProfitnLoss", null);

        }

        public DataTable getalldatafromPLTable()
        {
            return DAL.getuser("select * from tbl_ProfitnLoss", null);

        }



        public int insertintoPL(decimal netprofit, decimal netloss)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@netprofit",netprofit),
                new SqlParameter("@netloss",netloss),

            };
            return DAL.IDU("insert into  tbl_ProfitnLoss(net_profit,net_loss) values(@netprofit,@netloss)", parm);


        }

        public int updatentoPL(decimal netprofit, decimal netloss, int nid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 new SqlParameter("@netprofit",netprofit),
                new SqlParameter("@netloss",netloss),
                new SqlParameter("@nid",nid)

            };
            return DAL.IDU("update tbl_ProfitnLoss set net_profit=@netprofit,net_loss=@netloss where pl_id=@nid", parm);


        }



    }



}
