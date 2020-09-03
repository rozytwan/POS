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
   public class BLLkot_kitchen
    {
        public int insert_into_kot(string business_name, string address,  string time, string take_away, string header, string items, string discription)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@business_name", business_name),
                new SqlParameter("@address", address),
                new SqlParameter("@time", time),
                new SqlParameter("@take_away", take_away),
                new SqlParameter("@header", header),
                new SqlParameter("@items", items),
                new SqlParameter("@discription", discription)
                
            };
            return DAL.IDU("Insert into tbl_printer_setting_kot(business_name,address,time,take_away,header,items,discription) values (@business_name,@address,@time,@take_away,@header,@items,@discription)", parm);
        }
        public DataTable getall_kot_data()
        {
            return DAL.getuser("select * from tbl_printer_setting_kot", null);
        }
       
        public int update_kot(string business_name, string address,  string time, string take_away, string header, string items, string discription, int kot_kitchen_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                  new SqlParameter("@business_name", business_name),
                new SqlParameter("@address", address),
                 new SqlParameter("@time", time),
                 new SqlParameter("@take_away", take_away),
                new SqlParameter("@header", header),
                new SqlParameter("@items", items),
                new SqlParameter("@discription", discription), 
                new SqlParameter("@kot_kitchen_id", kot_kitchen_id)

            };
            return DAL.IDU("update tbl_printer_setting_kot set business_name=@business_name,address=@address,time=@time,take_away=@take_away,header=@header,items=@items,discription=@discription where kot_kitchen_id=@kot_kitchen_id", parm);

        }                    
    }
}
