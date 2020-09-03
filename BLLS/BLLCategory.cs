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
    public class BLLCategory
    {
        public DataTable getallcategory()
        {
            DataTable dt = new DataTable();
           return DAL.getuser("select * from tbl_categorys", null);
          
        }
        public DataTable getallItemcategory()
        {
            DataTable dt = new DataTable();
            return DAL.getuser("select * from tbl_item_category", null);

        }

        public DataTable getallcategorydecending()
        {
            DataTable dt = new DataTable();
            return DAL.getuser("select * from tbl_categorys order by category_id desc", null);

        }
        public int addcategory(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@category_name",category_name)
            };
            return DAL.IDU("insert into tbl_categorys values(@category_name)", parm);
        }
        public DataTable checkcategory(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@category_name",category_name)

          };
            return DAL.getuser("select * from tbl_categorys where category_name=@category_name", parm);
        }
        public int deletecategory(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter("@category_name",category_name)
        };
            return DAL.IDU("delete from tbl_categorys where category_name=@category_name", parm);
        }

        public int deletecategorybyid(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter("@category_id",category_id)
        };
            return DAL.IDU("delete from tbl_categorys where category_id=@category_id", parm);
        }

        public DataTable getallitemcategory_byid(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@category_id",category_id)
                };
            return DAL.getuser("select * from tbl_item_category where category_id=@category_id", parm);
        }

       
      

      
        public DataTable getallitemcategory_byitemscategory(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@category_name",category_name)
                };
            return DAL.getuser("select * from tbl_categorys where category_name like @category_name +'%'", parm);
        }
        public int updatecategory(int category_id, string new_category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@category_id",category_id),
          new SqlParameter("@new_category_name",new_category_name)
            };
            return DAL.IDU("update tbl_categorys set category_name=@new_category_name where category_id=@category_id", parm);
        }

    }
}
