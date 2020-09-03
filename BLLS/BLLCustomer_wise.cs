using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;


namespace BLLS
{
   public class BLLCustomer_wise
    {
        public int insertintotable(string user_name, int table_no, string items, int quantity,decimal paid_amount,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
            new SqlParameter("@user_name",user_name),
            new SqlParameter("@table_no",table_no),
             new SqlParameter("@quantity",quantity),
              new SqlParameter("@paid_amount",paid_amount),
              new SqlParameter("@date",date),
              new SqlParameter("@items",items)

        };

            return DAL.IDU("insert into tbl_customerwises values (@user_name,@table_no,@quantity,@paid_amount,@date,@items)", parm);
        }
        public DataTable getitembycustomername(string customername)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@customername",customername)
          };
            return DAL.getuser("select * from tbl_customerwises where user_name=@customername", parm);
        }

        public DataTable getitembyitemname(string itemname)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@itemname",itemname)
          };
            return DAL.getuser("select * from tbl_customerwises where items=@itemname", parm);
        }
        public DataTable getalldata()
        {
          
            return DAL.getuser("select * from tbl_customerwises ", null);
        }

    }

}
