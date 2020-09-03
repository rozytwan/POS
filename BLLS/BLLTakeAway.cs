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
  public  class BLLTakeAway
    {
        public DataTable getmaxNo()
        {
            return DAL.getuser("Select Max(take_away_id) from tbl_take_away ", null);
        }
        public DataTable getallfromtable()
        {
            return DAL.getuser("Select Max(twk_id) from tbl_take_away", null);
        }
        public DataTable get_twk_id(int take_away_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@take_away_id",take_away_id)
                };
            return DAL.getuser("Select twk_id from tbl_take_away where take_away_id=@take_away_id", parm);
        }
        public DataTable getallvaluesfromtable()
        {
            return DAL.getuser("Select top 30 * from tbl_take_away order by take_away_id desc", null);
        }
        public DataTable get_all_take_away_id(int take_away_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@take_away_id",take_away_id)
                };
            return DAL.getuser("select * from tbl_take_away  where take_away_id=@take_away_id", parm);
        }
        public int insert_into_take_away(int take_away_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@take_away_id",take_away_id)
                };
            return DAL.IDU("Insert into tbl_take_away(take_away_id) values (@take_away_id)", parm);
        }
        public int deletefromorder(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@order_id",order_id)
        };
            return DAL.IDU("delete from tbl_orders where order_id=@order_id", parm);
        }
        public int deletefromTake_away(int take_away_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@take_away_id",take_away_id)
        };
            return DAL.IDU("delete from tbl_take_away where take_away_id=@take_away_id", parm);
        }
        public int updatefromTake_away(int take_away_id,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@take_away_id",take_away_id),
         new SqlParameter ("@status",status)
        };
            return DAL.IDU("update from tbl_take_away set status=@status where take_away_id=@take_away_id", parm);
        }
        public DataTable select_all_data_higher()
        {
            return DAL.getuser(" select* from tbl_orders where table_no>'1000'", null);
        }
        public int truncate_take_away()
        {
            return DAL.IDU("truncate table tbl_take_away", null);
        }
    }
}
