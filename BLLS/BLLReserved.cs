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
   public class BLLReserved
    {
        public int insert_to_reserved(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no)
            };
            return DAL.IDU("insert into tbl_reserved(table_no) values(@table_no)", parm);
        }
        public DataTable get_value_by_table_no(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no)
            };
            return DAL.getuser("select * from tbl_reserved where table_no=@table_no", parm);
        }
        public int delete_table_reserved(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no)
            };
            return DAL.IDU("delete from tbl_reserved where table_no=@table_no", parm);
        }

    }
}
