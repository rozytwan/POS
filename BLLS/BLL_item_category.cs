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
    public class BLLItemcategory
    {
        public DataTable getcategories()
        {
            return DAL.getuser("Select * from tbl_item_category order by category_name ASC", null);
        }
        
        public int add_category(string category_name,byte[] category_image,string category_color,string applicable_time,int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_name", category_name),
                new SqlParameter("@category_image", category_image),
                new SqlParameter("@category_color", category_color),
                new SqlParameter("@applicable_time", applicable_time),
                new SqlParameter("@id",id)
            };
            return DAL.IDU("Insert into tbl_item_category(category_name,category_image,category_color,applicable_time,id) values(@category_name,@category_image,@category_color,@applicable_time,@id)", parm);
        }

        public int update_category(int category_id, string category_name, byte[] category_image, string category_color, string applicable_time, int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id),
                new SqlParameter("@category_name", category_name),
                new SqlParameter("@category_image", category_image),
                new SqlParameter("@category_color", category_color),
                new SqlParameter("@applicable_time", applicable_time),
                  new SqlParameter("@id ", id)

            };
            return DAL.IDU("Update tbl_item_category set category_name = @category_name, category_image = @category_image, category_color = @category_color, applicable_time = @applicable_time,id=@id where category_id = @category_id", parm);
        }
        public DataTable getcategorybycategory_id(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };
            return DAL.getuser("Select * from tbl_item_category where category_id = @category_id", parm);
        }

        public DataTable get_all_category_by_name(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_name", category_name)
            };
            return DAL.getuser("Select * from tbl_item_category where category_name = @category_name", parm);
        }
        public DataTable getcategorybyid_desc()
        {
            return DAL.getuser("Select * from tbl_item_category order by category_id desc", null);
        }

        public int adddays(int category_id, string days)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id),
                new SqlParameter("@days", days)
            };
            return DAL.IDU("Insert into tbl_category_dayswise(category_id,days) values (@category_id,@days)", parm);
        }

        public DataTable getcategory_dayswisebycategory_id(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };
            return DAL.getuser("Select * from tbl_category_dayswise where category_id = @category_id", parm);
        }

        public int update_category_dayswise(int category_dayswise_id, string days)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_dayswise_id", category_dayswise_id),
                new SqlParameter("@days", days)
            };
            return DAL.IDU("Update tbl_category_dayswise set days = @days where category_dayswise_id = @category_dayswise_id", parm);
        }

        public int delete_dayswise_records(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };
            return DAL.IDU("Delete from tbl_item_category_dayswise where category_id = @category_id", parm);
        }

        public int delete_category(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };
            return DAL.IDU("Delete from tbl_item_category where category_id = @category_id", parm);
        }

        public int delete_category_dayswise(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id", category_id)
            };
            return DAL.IDU("Delete from tbl_category_dayswise where category_id = @category_id", parm);
        }
    }
}
