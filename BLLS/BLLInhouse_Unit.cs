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
  public class BLLInhouse_Unit
    {
        public DataTable get_unit_name(string unit_name,string measure_type)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@unit_name",unit_name),
                    new SqlParameter("@measure_type",measure_type)
                };
            return DAL.getuser("select * from tbl_inhouse_unit where unit_name=@unit_name and measure_type=@measure_type", parm);
        }
        public int insert_inhouse_unit(string unit_name, string measure_type)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@unit_name",unit_name),
                    new SqlParameter("@measure_type",measure_type)
                };
            return DAL.IDU("Insert into tbl_inhouse_unit (unit_name,measure_type) values (@unit_name,@measure_type)", parm);
        }
        public int update_inhouse(string unit_name, string measure_type,int inhouse_unit_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@inhouse_unit_id",inhouse_unit_id),
                    new SqlParameter("@unit_name",unit_name),
                    new SqlParameter("@measure_type",measure_type)
                };
            return DAL.IDU("update  tbl_inhouse_unit set unit_name=@unit_name,measure_type=@measure_type where inhouse_unit_id=@inhouse_unit_id", parm);
        }
        public int delete_inhouse_unit (int inhouse_unit_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@inhouse_unit_id",inhouse_unit_id),
                 
                };
            return DAL.IDU("delete from tbl_inhouse_unit where inhouse_unit_id=@inhouse_unit_id", parm);
        }
        public DataTable get_all_data()
        {
            return DAL.getuser("select * from tbl_inhouse_unit", null);
        }

    }
}
