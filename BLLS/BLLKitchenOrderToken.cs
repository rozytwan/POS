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
  public  class BLLKitchenOrderToken
    {
       
        public int insertTokenorder_using_sp(string user_name, string table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string phone, string service_provider)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@user_name",user_name),
        new SqlParameter("@table_no",table_no),
        new SqlParameter ("@item",item),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@total",total),
        new SqlParameter("@cost",cost),
         new SqlParameter("@active",active),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@kot_print",kot_print),
           new SqlParameter("@phone",phone),
           new SqlParameter("@service_provider",service_provider)

            };
            return DAL.IUD_SP("dbo.sp_Token_kitchen_orders", CommandType.StoredProcedure, parm);
        }
        public DataTable getalldata(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select * from tbl_orders_token where table_no=@table_no", parm);

        }
        public int insert_into_token(string token_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
        new SqlParameter("@token_no",token_no),


          };
            return DAL.IDU("insert into tbl_token_no(token_no) values(@token_no)", parm);
        }
        public int deleteitemfromorder(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@order_id",order_id)

               };
            return DAL.IDU("delete from tbl_orders_token where order_id=@order_id", parm);
        }
        public int deletefromtable(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@table_no",table_no)
        };
            return DAL.IDU("delete from tbl_orders_token where table_no=@table_no", parm);
        }
        public int updateorderstable(decimal quantity, int order_id, decimal total)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

          new SqlParameter("quantity",quantity),
          new SqlParameter("order_id",order_id),
          new SqlParameter("total",total)
            };

            return DAL.IDU("update tbl_orders_token set quantity=@quantity,total=@total where order_id=@order_id", parm);
        }
        public DataTable getallfromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            DataTable dt = DAL.getuser("select * from tbl_orders_token where order_id=@order_id", parm);
            return dt;
        }
        public int deleteTokenNo(string token_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
        new SqlParameter("@token_no",token_no),


          };
            return DAL.IDU("delete from tbl_token_no where token_no=@token_no", parm);
        }
        public int deletefromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@order_id",order_id)
        };
            return DAL.IDU("delete from tbl_orders_token where order_id=@order_id", parm);
        }
    }
}
