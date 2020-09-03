using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.bakery
{
    public class BllBakeryOrder
    {
        public DataTable getmaxNo(string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@service_type",service_type)
                };
            return DAL.getuser("Select Max(kot_id) from tbl_bakery_orders where service_type=@service_type ", parm);
        }

        public DataTable get_all_rest_table_info(string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
              {
                    new SqlParameter("@service_type",service_type)
              };
            return DAL.getuser("select distinct(kot_id) as id,service_type as name from tbl_bakery_orders where service_type=@service_type", parm);
        }
        public int insertBakeryorder_using_sp(string user_name, string item, decimal quantity, decimal total, decimal cost, string category_name, string kot_print, int customer_id, string service_type, int KOTId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@user_name",user_name),
            new SqlParameter ("@item",item),
            new SqlParameter("@quantity",quantity),
            new SqlParameter("@total",total),
            new SqlParameter("@cost",cost),
            new SqlParameter("@category_name",category_name),
            new SqlParameter("@kot_print",kot_print),
            new SqlParameter("@customer_id",customer_id),
            new SqlParameter("@service_type",service_type),
            new SqlParameter("@kot_id",KOTId)

            };
            return DAL.IUD_SP("dbo.sp_Bakerykitchen_orders", CommandType.StoredProcedure, parm);
        }
        public DataTable getallKOTdata(string kot_id, string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
         new SqlParameter("@kot_id",kot_id),
          new SqlParameter("@service_type",service_type)
         };
            return DAL.getuser("select *,service_type as sales_type,user_name as service_provider from tbl_bakery_orders b left join tbl_customerDetailnyo c on(b.customer_id=c.id) where  service_type=@service_type and kot_id=@kot_id", parm);

        }

        public int insertBakeryorderDetails(string shape, DateTime receving_time, string message, string note, string coating_type, string payment_type, decimal advance_amount, int KOTId, string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@shape",shape),
            new SqlParameter ("@receving_time",receving_time),
            new SqlParameter("@message",message),
            new SqlParameter("@note",note),
            new SqlParameter("@coating_type",coating_type),
            new SqlParameter("@payment_type",payment_type),
            new SqlParameter("@advance_amount",advance_amount),
            new SqlParameter("@service_type",service_type),
            new SqlParameter("@kot_id",KOTId)

            };
            return DAL.IDU("Insert into tbl_bakery_order_details (shape,receving_time,message,note,coating_type,payment_mode,advance_amount,service_type,kot_id,x_report) values (@shape,@receving_time,@message,@note,@coating_type,@payment_type,@advance_amount,@service_type,@kot_id,'X')", parm);
        }

        public int UpdateBakeryorderDetails(string shape, DateTime receving_time, string message, string note, string coating_type, string payment_type, decimal advance_amount, int order_details_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@shape",shape),
            new SqlParameter ("@receving_time",receving_time),
            new SqlParameter("@message",message),
            new SqlParameter("@note",note),
            new SqlParameter("@coating_type",coating_type),
            new SqlParameter("@payment_type",payment_type),
            new SqlParameter("@advance_amount",advance_amount),
            new SqlParameter("@order_details_id",order_details_id)

            };
            return DAL.IDU("update tbl_bakery_order_details set shape=@shape,receving_time=@receving_time,message=@message,note=@note,coating_type=@coating_type,payment_mode=@payment_type,advance_amount=@advance_amount where order_details_id=@order_details_id", parm);
        }
        public int deletefromBakeryOrder(string kot_id, string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@kot_id",kot_id),
         new SqlParameter ("@service_type",service_type)
        };
            return DAL.IDU("delete from tbl_bakery_orders where kot_id=@kot_id and service_type=@service_type", parm);
        }
        public int deletefromBakeryOrderDetails(string kot_id, string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@kot_id",kot_id),
         new SqlParameter ("@service_type",service_type)
        };
            return DAL.IDU("delete from tbl_bakery_order_details where kot_id=@kot_id and service_type=@service_type", parm);
        }
        public int deleteitemfromorder(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@order_id",order_id)

               };
            return DAL.IDU("delete from tbl_bakery_orders where order_id=@order_id", parm);

        }
        public DataTable getallfromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            return DAL.getuser("select * from tbl_bakery_orders where order_id=@order_id", parm);

        }
        public int updateorderstable(decimal quantity, int order_id, decimal total)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

          new SqlParameter("quantity",quantity),
          new SqlParameter("order_id",order_id),
          new SqlParameter("total",total)
            };

            return DAL.IDU("update tbl_bakery_orders set quantity=@quantity,total=@total where order_id=@order_id", parm);
        }
        public DataTable GetAllDataFromOrderDetails(string kot_id, string service_type)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@kot_id",kot_id),
         new SqlParameter ("@service_type",service_type)
        };
            return DAL.getuser("select *  from tbl_bakery_order_details where kot_id=@kot_id and service_type=@service_type", parm);
        }
        public DataTable SumAdvanceAmount(string payment_mode)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                 new SqlParameter ("@payment_mode",payment_mode)
             };
            return DAL.getuser("select sum(advance_amount) as advance_amount from tbl_bakery_order_details where x_report='X' and payment_mode=@payment_mode ", parm);
        }
    }
}
