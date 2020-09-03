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
  public  class BLL_hotel_order
    {
        public int Insert_Hotel_Order(string user_name, string room_no, string item, int quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string phone, int customer_id,DateTime order_date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@user_name",user_name),
        new SqlParameter("@room_no",room_no),
        new SqlParameter ("@item",item),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@total",total),
        new SqlParameter("@cost",cost),
         new SqlParameter("@active",active),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@kot_print",kot_print),
           new SqlParameter("@phone",phone),         
             new SqlParameter("@customer_id",customer_id),
               new SqlParameter("@order_date",order_date)

            };
            return DAL.IUD_SP("dbo.sp_hotel_kitchen_orders", CommandType.StoredProcedure, parm);
        }
        public int inserthotelsales(int bill_no, DateTime date_of_sale, string cashier_name, string table_no, string customer_name, string customer_no, string item_name, decimal quantity, decimal cost, decimal total, string payment_mode, string kot_type, decimal sub_total, decimal discount, decimal cash_amount, decimal card_amount, decimal grand_total, string category_name, decimal service_charge, decimal taxable_amount, decimal tax_amount, string fiscal_year, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                      new SqlParameter("@date_of_sale",date_of_sale),
                        new SqlParameter("@cashier_name",cashier_name),
                        new SqlParameter("@table_no",table_no),
                        new SqlParameter("@customer_name",customer_name),
                        new SqlParameter("@customer_no",customer_no),
                        new SqlParameter("@quantity",quantity),
                        new SqlParameter("@item_name",item_name),
                        new SqlParameter("@cost",cost),
                        new SqlParameter("@total",total),
                        new SqlParameter("@payment_mode",payment_mode),
                        new SqlParameter("@kot_type",kot_type),
                        new SqlParameter("@sub_total",sub_total),
                        new SqlParameter("@discount",discount),
                        new SqlParameter("@card_amount",card_amount),
                        new SqlParameter("@cash_amount",cash_amount),
                        new SqlParameter("@grand_total",grand_total),
                        new SqlParameter("@category_name",category_name),
                        new SqlParameter("@date2",date_of_sale),
                          new SqlParameter("@service_charge",service_charge),
                        new SqlParameter("@taxable_amount",taxable_amount),
                        new SqlParameter("@tax_amount",tax_amount),
                          new SqlParameter("@fiscal_year",fiscal_year),
                          new SqlParameter("@x_report",x_report)

                };

            return DAL.IDU("insert into tbl_sales_record (bill_no,date_of_sale,cashier_name,table_no,customer_name,customer_no,item_name,quantity,cost,total,payment_mode,kot_type,sub_total,discount,card_amount,cash_amount,grand_total,category_name,date2,sales_type,service_charge,taxable_amount,tax_amount,fiscal_year,x_report)" +
                     " values(@bill_no,@date_of_sale,@cashier_name,@table_no,@customer_name,@customer_no,@item_name,@quantity,@cost,@total,@payment_mode,@kot_type,@sub_total,@discount,@card_amount,@cash_amount,@grand_total,@category_name,@date2,'HS',@service_charge,@taxable_amount,@tax_amount,@fiscal_year,@x_report)", parm);

        }
        public DataTable GetOrders(int hotel_order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",hotel_order_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_order where hotel_order_id=@order_id", parm);
            return dt;
        }
        public DataTable GetCustomerOrder(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@customer_id",customer_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_order where customer_id=@customer_id", parm);
            return dt;
        }
        public DataTable GetRoomOrder(string room_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@room_no",room_no)

                };
            DataTable dt = DAL.getuser("select * from hotel_order where room_no=@room_no", parm);
            return dt;
        }
        public DataTable GetRoomOrder()
        {
            DataTable dt = DAL.getuser("select * from hotel_order",null);
            return dt;
        }
        public DataTable getalldata_order()
        {
            return DAL.getuser("select max(order_id) from hotel_order", null);

        }
        public DataTable getalldata(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select * from hotel_order where room_no=@table_no", parm);

        }
        public int deleteitemfromorder(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@order_id",order_id)

               };
            return DAL.IDU("delete from hotel_order where hotel_order_id=@order_id", parm);
        }
        public int deleteallcustomerorder(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@customer_id",customer_id)

               };
            return DAL.IDU("delete from hotel_order where customer_id=@customer_id", parm);
        }
        public int updateorderstable(int quantity, int order_id, decimal total)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

          new SqlParameter("quantity",quantity),
          new SqlParameter("order_id",order_id),
          new SqlParameter("total",total)
            };

            return DAL.IDU("update hotel_order set quantity=@quantity,total=@total where hotel_order_id=@order_id", parm);
        }
        public DataTable getallfromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            DataTable dt = DAL.getuser("select * from hotel_order where hotel_order_id=@order_id", parm);
            return dt;
        }
        public int deletefromtable(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@table_no",table_no)
        };
            return DAL.IDU("delete from hotel_order where room_no=@table_no", parm);
        }
        public int updateroom(int room_id, int room_ids)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("room_id",room_id),
          new SqlParameter("room_ids",room_ids)
            };

            return DAL.IDU("update hotel_bookings set room_id=@room_id where room_id=@room_ids", parm);
        }
        public int updateroomorder(string room_no, int room_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("room_no",room_no),
          new SqlParameter("room_id",room_id)
            };

            return DAL.IDU("update hotel_order set room_no=@room_no where room_no=@room_id", parm);
        }
    }
}
