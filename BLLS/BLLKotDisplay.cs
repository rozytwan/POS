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
    public class BLLKotDisplay
    {
        public DataTable getallkot(decimal kot_display_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@kot_display_id",kot_display_id)
            };
            return DAL.getuser("select * from tbl_kot_display where kot_display_id=@kot_display_id", parm);
        }
        public DataTable getallkot_display()
        {           
            return DAL.getuser("select * from tbl_kot_display", null);
        }

        public DataTable distinct_time()
        {
            return DAL.getuser("select distinct time from tbl_kot_display", null);
        }
        public DataTable getallkot_display_countTotal()
        {
            return DAL.getuser("select kot_display_id,count(*) from tbl_kot_display group by kot_display_id", null);
        }
       

        public DataTable getallkotDisplay_byid(int kot_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@kot_id",kot_id)
            };
            return DAL.getuser("select * from tbl_kot_display where kot_display_id=@kot_id", parm);
        }
        public DataTable count_table()
        {
            return DAL.getuser("select count(table_no) from tbl_kot_display group by table_no", null);
        }
        public DataTable distinct()
        {
            return DAL.getuser("select distinct table_no from tbl_kot_display", null);
        }
        public DataTable distinct_kot_id()
        {
            return DAL.getuser("select distinct kot_display_id from tbl_kot_display", null);
        }
        public int insertkot_display(decimal table_no, string item, int quantity, int kot_display_id, string note, string time,string status, int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {

        new SqlParameter("@table_no",table_no),
        new SqlParameter ("@item",item),
        new SqlParameter("@quantity",quantity),
         new SqlParameter("@kot_display_id",kot_display_id),
         new SqlParameter("@note",note),
          new SqlParameter("@time",time),
          new SqlParameter("@status",status),
          new SqlParameter("@order_id",order_id)


          };
            return DAL.IDU("insert into tbl_kot_display(table_no,item,quantity,kot_display_id,note,time,status,order_id) values(@table_no,@item,@quantity,@kot_display_id,@note,@time,@status,@order_id)", parm);
        }
        public DataTable getkot_displayID()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(kot_display_id) from tbl_kot_display", null);
            return dt;
        }
        public int delete_kot_display(int kot_display_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@kot_display_id",kot_display_id)
            };
            return DAL.IDU("delete from tbl_kot_display where kot_display_id=@kot_display_id", parm);
        }
        public int cancel_update(decimal kot_id,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@kot_id",kot_id),
                new SqlParameter("@status",status)

           };
            return DAL.IDU("update tbl_kot_display set status=@status where kot_id=@kot_id", parm);
        }
        public DataTable getallwarning()
        {
            return DAL.getuser("select * from tbl_kot_warning", null);
        }
        public int insert_into_warning(int time, string color)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@time",time),
                    new SqlParameter("@color",color)
                };
            return DAL.IDU("insert into tbl_kot_warning(time,color) values (@time,@color)", parm);
        }
        public int warning_update(int time, string color,int warning_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@time",time),
                    new SqlParameter("@color",color),
                      new SqlParameter("@warning_id",warning_id)
                };
            return DAL.IDU("update tbl_kot_warning set time=@time,color=@color where warning_id=@warning_id", parm);
        }
        public DataTable count_quantity()
        {
            return DAL.getuser("select count(quantity) from tbl_kot_display", null);
        }

    }
}
