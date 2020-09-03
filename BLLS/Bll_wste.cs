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
    public class Bll_wste
    {
       public DataTable getall()
        {
            return DAL.getuser("select * from  tbl_wasteMngt", null);
        }

        public int insernt(decimal quantity, DateTime DOE, string ingredient_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@quantity",quantity),
            new SqlParameter("@DOE",DOE),
            new SqlParameter("@ingredient_id",ingredient_id)
            };
            return DAL.IDU("insert into tbl_wasteMngt values(@quantity,@DOE,@ingredient_id) ", parm);
        }
        public int deletebyId(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@id",id),
            };
            return DAL.IDU("delete  from tbl_wasteMngt where id=@id", parm);

        }
        public DataTable searcByItme(string item)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@item",item),
            };
            return DAL.getuser("select * from tbl_wasteMngt where ingredient_id = @item ", parm);
        }
        public DataTable searchByTwodates(DateTime from, DateTime to,string item)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@from",from),
            new SqlParameter("@to",to),
            new SqlParameter("@item",item)
            
            };
            return DAL.getuser("select * from tbl_wasteMngt where ingredient_id=@item and  DOE between @from and @to ", parm);
        }
       
       
        
    }
}
