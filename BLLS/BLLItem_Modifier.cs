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
    public class BLLItem_Modifier
    {
        public int insert_item_modifier_item(int item_id, string category_name, string item_name, decimal item_price, string modifier_name,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_id",item_id),
                    new SqlParameter("@category_name",category_name),
                    new SqlParameter("@item_name",item_name),
                    new SqlParameter("@item_price",item_price),
                    new SqlParameter("@modifier_name",modifier_name),
                      new SqlParameter("@status",status)
                };

            return DAL.IDU("insert into tbl_item_modifier(item_id,category_name,item_name,item_price,modifier_name,status) values (@item_id,@category_name,@item_name,@item_price,@modifier_name,@status)", parm);
        }
        public DataTable get_all_data()
        {
            return DAL.getuser("select * from tbl_item_modifier", null);
        }
        public int update_item_modifier(int modifier_id, string modifier_name,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@modifier_id",modifier_id),
                    new SqlParameter("@modifier_name",modifier_name),
                     new SqlParameter("@status",status)
                 };
            return DAL.IDU("update tbl_item_modifier set modifier_name=@modifier_name,status=@status where modifier_id=@modifier_id", parm);
        }
        public int delete_item_modifier(int modifier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@modifier_id",modifier_id)
                };

            return DAL.IDU("delete from tbl_item_modifier where modifier_id=@modifier_id", parm);
                
        }
        public DataTable get_all_modifier_by_item_id(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_id",item_id)
                };
            return DAL.getuser("select * from tbl_item_modifier where item_id=@item_id", parm);
        }
        public DataTable get_all_modifier_by_item_id_and_status(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_id",item_id)
                };
            return DAL.getuser("select * from tbl_item_modifier where item_id=@item_id  or status='All'", parm);
        }
    }
}
