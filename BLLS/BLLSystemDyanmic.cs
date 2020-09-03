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
   public class BLLSystemDyanmic
    {
        public DataTable getALLDynamicByCode(string code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@code",code)
                };
            return DAL.getuser("select * from tbl_dyanmic where code=@code", parm);
        }
    }
}
