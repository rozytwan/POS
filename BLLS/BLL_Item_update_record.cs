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
    public class BLL_Item_update_record
    {
        public int insert_update_record(int item_id, string item_name, decimal item_cost_price, decimal item_selling_price, int category_id, string kot_print, byte[] image_name, string applicable_time_period, string image_color, DateTime update_time, string update_by)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id),
                new SqlParameter("@item_name", item_name),
                new SqlParameter("@item_cost_price", item_cost_price),
                new SqlParameter("@item_selling_price", item_selling_price),
                new SqlParameter("@category_id", category_id),
                new SqlParameter("@kot_print", kot_print),
                new SqlParameter("@image_name", image_name),
                new SqlParameter("@applicable_time_period", applicable_time_period),
                new SqlParameter("@image_color", image_color),
                 new SqlParameter("@update_time", update_time),
                new SqlParameter("@update_by", update_by)
            };

            return DAL.IDU("Insert into tbl_items_update(item_id,item_name,item_cost_price,item_price,category_id,kot_print,image_name,applicable_time_period,image_color,update_time,update_by) values(@item_id,@item_name,@item_cost_price,@item_selling_price,@category_id,@kot_print,@image_name,@applicable_time_period,@image_color,@update_time,@update_by)", parm);
        }
        public DataTable get_all_record()
        {
            return DAL.getuser("Select * from tbl_items_update", null);

        }
    }
}
