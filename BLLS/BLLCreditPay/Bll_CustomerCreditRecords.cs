using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOA;

namespace BLLS.creditPay
{
   public class Bll_CustomerCreditRecords
    {
        public DataTable getalldata(string id) {
             SqlParameter[] parm= new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.getuser("select *from tbl_creditsRecords where  cus_id=@id", parm);
        }
        
    }
}
