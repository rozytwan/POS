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
    public class BLLdamage
    {
        public DataTable GetDamage()
        {
            return DAL.getuser("Select * from tbl_damage", null);
        }
       

        public int InsertDamage(int category_id, int product_id, string user_name, DateTime date, decimal quantity, string unit, string note)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id",category_id),
                new SqlParameter("@product_id",product_id),
                new SqlParameter("@user_name",user_name),
                new SqlParameter("@date",date),
                new SqlParameter("@quantity",quantity),
                new SqlParameter("@unit",unit),
                new SqlParameter("@note",note),
            };
            return DAL.IDU("insert into tbl_damage(category_id,product_id,user_name,date,quantity,unit,note) values (@category_id,@product_id,@user_name,@date,@quantity,@unit,@note)", parm);
        }
      

    }
}
