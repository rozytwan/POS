using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS.Bll_mess_days
{
    public class bll_mess_each_records
    {
        public int insertintotbl(int custo_id,DateTime dates,string packagename,decimal packageprice,string days,string food_type) {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@custo_id",custo_id),
                 new SqlParameter("@dates",dates),
                  new SqlParameter("@packagename",packagename),
                   new SqlParameter("@packageprice",packageprice),
                    new SqlParameter("@days",days),
                     new SqlParameter("@food_type",food_type),
            };
            return DAL.IDU("insert into tbl_customer_mess_each values( @custo_id,@dates,@packagename,@packageprice,@days,@food_type)", parm);
        }
    }
}
