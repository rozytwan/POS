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
    public class BLLLoyalty
    {
        public DataTable getLoyaltyType(string lType)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@loyality_type",lType)
                };
            return DAL.getuser("select * from tbl_loyality where loyality_status='True' and loyality_type=@loyality_type", parm);
        }


        public DataTable getLoyaltyAmountPoint(decimal loyalty_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@loyalty_amount",loyalty_amount)
                };
            return DAL.getuser("select points from tbl_loyality_amount where @loyalty_amount between amount_from and amount_to and status = 'True';", parm);
        }
        public DataTable getLoyaltyItemPoint(string item_name, decimal qty)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_name",item_name),
                    new SqlParameter("@qty",qty)
                };
            return DAL.getuser("select points*@qty from tbl_loyality_itemwise l left join tbl_items i on(l.item_id=i.item_id) where i.item_name=@item_name and status = 'True';", parm);
        }
        public DataTable GetLoyalityAmount()
        {
            return DAL.getuser("Select * from tbl_loyality_amount", null);
        }
        public DataTable GetLoyality()
        {
            return DAL.getuser("Select * from tbl_loyality", null);
        }
        public DataTable GetLoyalityItemwise()
        {
            return DAL.getuser("select * from tbl_loyality_itemwise l inner join tbl_items i on l.item_id=i.item_id", null);
        }
        public DataTable GetLoyalityAmountId(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@id", id),

          };
            return DAL.getuser("Select * from tbl_loyality_amount where id=@id", parm);
        }
        public DataTable GetLoyalityId(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@id", id),

          };
            return DAL.getuser("select * from tbl_loyality_itemwise l inner join tbl_items i on l.item_id=i.item_id where id=@id", parm);
        }
        public DataTable GetLoyalityById(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@id", id),

          };
            return DAL.getuser("select * from tbl_loyality where loyality_id=@id", parm);
        }
        public DataTable GetLoyalityItemId(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@item_id", item_id),

          };
            return DAL.getuser("Select * from tbl_loyality_itemwise where item_id=@item_id", parm);
        }

        public int Insert_LoyalityItem(int item_id, decimal qty, int points, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@item_id", item_id),
                new SqlParameter("@qty", qty),
                new SqlParameter("@points", points),
                new SqlParameter("@status", status),

            };
            return DAL.IDU("Insert into tbl_loyality_itemwise(item_id,qty,points,status) values(@item_id,@qty,@points,@status)", parm);
        }
        public int Insert_Loyality(string loyality_type, string loyality_status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

                new SqlParameter("@loyality_type", loyality_type),
                new SqlParameter("@loyality_status", loyality_status),

            };
            return DAL.IDU("Insert into tbl_loyality(loyality_type,loyality_status) values(@loyality_type,@loyality_status)", parm);
        }
        public int Insert_LoyalityAmount(decimal amount_from, decimal amount_to, int points, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@amount_from", amount_from),
                new SqlParameter("@amount_to", amount_to),
                new SqlParameter("@points", points),
                new SqlParameter("@status", status),

            };
            return DAL.IDU("Insert into tbl_loyality_amount(amount_from,amount_to,points,status) values(@amount_from,@amount_to,@points,@status)", parm);
        }
        public int Update_LoyalityAmount(int id, decimal amount_from, decimal amount_to, int points, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@id", id),
                new SqlParameter("@amount_from", amount_from),
                new SqlParameter("@amount_to", amount_to),
                new SqlParameter("@points", points),
                new SqlParameter("@status", status),

            };
            return DAL.IDU("Update tbl_loyality_amount set amount_from=@amount_from,amount_to=@amount_to,points=@points,status=@status where id=@id", parm);
        }
        public int Update_Loyality(int loyality_id, string loyality_type, string loyality_status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@id", loyality_id),
                new SqlParameter("@loyality_type", loyality_type),
                new SqlParameter("@loyality_status", loyality_status),

            };
            return DAL.IDU("Update tbl_loyality set loyality_type=@loyality_type,loyality_status=@loyality_status where loyality_id=@id", parm);
        }
        public int Update_LoyalityItem(int id, int item_id, decimal qty, int points, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@id", id),
                new SqlParameter("@item_id", item_id),
                new SqlParameter("@qty", qty),
                new SqlParameter("@points", points),
                new SqlParameter("@status", status),

            };
            return DAL.IDU("Update tbl_loyality_itemwise set item_id=@item_id,qty=@qty,points=@points,status=@status where id=@id", parm);
        }
        public int Insert_Customer_LoyalityPoint(int bill_no, int customer_id, int loyality_points, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@bill_no", bill_no),
                new SqlParameter("@customer_id", customer_id),
                new SqlParameter("@loyality_points", loyality_points),
                new SqlParameter("@date", date),

            };
            return DAL.IDU("Insert into tbl_loyality_customerpoints(bill_no,customer_id,loyality_points,date) values(@bill_no,@customer_id,@loyality_points,@date)", parm);
        }
        public DataTable getAllCustomerPoints()
        {
            return DAL.getuser("select customer_id,sum(loyality_points)as customer_point,name +' ' +lastname as customer_name,phone,card_no from tbl_loyality_customerpoints l left join tbl_customerDetailnyo c on(l.customer_id=c.id) group by customer_id,name +' ' +lastname,phone,card_no", null);
        }
        public DataTable getAllCustomerPointsByName(string customer_name)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
                new SqlParameter("@customer_name", customer_name),

         };
            return DAL.getuser("select customer_id,sum(loyality_points)as customer_point,name +' ' +lastname as customer_name,phone,card_no from tbl_loyality_customerpoints l left join tbl_customerDetailnyo c on(l.customer_id=c.id) where name +' ' +lastname like @customer_name +'%' group by customer_id,name +' ' +lastname,phone,card_no", parm);
        }
        public int insertLoyaltyReward(DateTime date_of_sales, string cashier_name, string item_name, decimal quantity, decimal cost, decimal total, decimal grand_total, string kot_type, string category_name, string customer_name, string customer_no, string status, string x_report, int comp_invoice)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
        new SqlParameter("@date_of_sales",date_of_sales),
        new SqlParameter("@cashier_name",cashier_name),
        new SqlParameter ("@item_name",item_name),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@cost",cost),
         new SqlParameter("@total",total),
          new SqlParameter("@grand_total",grand_total),
         new SqlParameter("@kot_type",kot_type),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@customer_name",customer_name),
          new SqlParameter("@customer_no",customer_no),
          new SqlParameter("@status",status),
           new SqlParameter("@x_report",x_report),        
           new SqlParameter("@comp_invoice",comp_invoice)

            };
            return DAL.IDU("INSERT INTO tbl_LoyaltyRewards (date_of_sales,cashier_name,item_name,quantity,cost,total,grand_total,kot_type,category_name,customer_name,customer_no,status,x_report,comp_invoice)VALUES (@date_of_sales,@cashier_name,@item_name,@quantity,@cost,@total,@grand_total,@kot_type,@category_name,@customer_name,@customer_no,@status,@x_report,@comp_invoice) ", parm);
        }
    }
}
