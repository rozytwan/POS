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
    public class BLLTable_Area
    {
        public int new_area_create(string area_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@area_name",area_name)
                };
            return DAL.IDU("insert into tbl_table_area (area_name) values( @area_name)", parm);
        }
        public DataTable get_all_data()
        {
            return DAL.getuser("select * from tbl_table_area", null);
        }
        public DataTable get_all_data_area_id(int area_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@area_id",area_id)
                };
            return DAL.getuser("select * from tbl_table_area where area_id=@area_id", parm);
        }

    }
}
