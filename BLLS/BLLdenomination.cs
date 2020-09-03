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
   public class BLLdenomination
    {
        public DataTable GetDenomination()
        {
            return DAL.getuser("select * from tbl_denomination", null);
        }
        public int InsertDenomination(int id,string ic,string thousand,string five_hundred,string hundred,string fifty,string twenty,string ten,string five,string two, string one, string total,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                  new SqlParameter("@id",id),
     new SqlParameter("@ic",ic),
      new SqlParameter("@thousand",thousand),
     new SqlParameter("@five_hundred",five_hundred),
     new SqlParameter("@hundred",hundred),
       new SqlParameter("@fifty",fifty),
      new SqlParameter("@twenty",twenty),
     new SqlParameter("@ten",ten),
     new SqlParameter("@five",five),
       new SqlParameter("@two",two),
      new SqlParameter("@one",one),
     new SqlParameter("@total",total),
     new SqlParameter("@date",date),

            };
            return DAL.IDU("insert into tbl_denomination(id,ic,thousand,five_hundred ,hundred,fifty,twenty,ten,five,two,one,total,date) values(@id,@ic,@thousand,@five_hundred,@hundred,@fifty,@twenty,@ten,@five,@two,@one,@total,@date)", parm);
        }
        public DataTable GetId()
        {
            return DAL.getuser("select max(id) from tbl_dailyend", null);
        }
        public DataTable GetSum()
        {
            return DAL.getuser("SELECT SUM(CAST(ic as int)),sum(cast(thousand as int)),sum(cast(five_hundred as int)),sum(cast(hundred as int)),sum(cast(fifty as int)),sum(cast(twenty as int)),sum(cast(ten as int)),sum(cast(five as int)),sum(cast(total as decimal)) from tbl_denomination", null);
        }
        
    }
}
