using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data.SqlClient;
using System.Data;

namespace BLLS
{
    public class BLLBill_printing
    {
        public int insert(string store_name, string table_name, string seat_name, string date_and_time, string cashier, string order_summary, string header, string items, string sub_total, string received_amt, string discount, string change_amt, string total, string payment_mode, string address)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@store_name", store_name),
                new SqlParameter("@table_name", table_name),
                new SqlParameter("@seat_name", seat_name),
                new SqlParameter("@date_and_time", date_and_time),
                new SqlParameter("@cashier", cashier),
                new SqlParameter("@order_summary", order_summary),
                new SqlParameter("@header", header),
                new SqlParameter("@items", items),
                new SqlParameter("@sub_total", sub_total),
                new SqlParameter("@received_amt", received_amt),
                new SqlParameter("@discount", discount),
                new SqlParameter("@change_amt", change_amt),
                new SqlParameter("@total", total),
                new SqlParameter("@payment_mode", payment_mode),
                new SqlParameter("@address", address)

                  };
            return DAL.IDU("Insert into tbl_printer_setting_billing(store_name,table_name,seat_name,date_and_time,cashier,order_summary,header,items,sub_total,received_amt,discount,change_amt,payment_mode,total,address) values(@store_name,@table_name,@seat_name,@date_and_time,@cashier,@order_summary,@header,@items,@sub_total,@received_amt,@discount,@change_amt,@payment_mode,@total,@address)", parm);
        }
        public DataTable getall_Printing_data()
        {

            return DAL.getuser("select * from tbl_printer_setting_billing", null);
        }



        public int update(string store_name, string table_name, string seat_name, string date_and_time, string cashier, string order_summary, string header, string items, string sub_total, string received_amt, string discount, string change_amt, string total, string payment_mode, string address, int kot_print_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@store_name", store_name),
                new SqlParameter("@table_name", table_name),
                new SqlParameter("@seat_name", seat_name),
                new SqlParameter("@date_and_time", date_and_time),
                new SqlParameter("@cashier", cashier),
                new SqlParameter("@order_summary", order_summary),
                new SqlParameter("@header", header),
                new SqlParameter("@items", items),
                new SqlParameter("@sub_total", sub_total),
                new SqlParameter("@received_amt", received_amt),
                new SqlParameter("@discount", discount),
                new SqlParameter("@change_amt", change_amt),
                new SqlParameter("@total", total),
                new SqlParameter("@payment_mode", payment_mode),
                 new SqlParameter("@address", address),
                new SqlParameter("@kot_print_id", kot_print_id)

           };
            return DAL.IDU("update tbl_printer_setting_billing set store_name=@store_name,seat_name=@seat_name,table_name=@table_name,date_and_time=@date_and_time,cashier=@cashier,order_summary=@order_summary,header=@header,items=@items,sub_total=@sub_total,received_amt=@received_amt,discount=@discount,change_amt=@change_amt,total=@total,payment_mode=@payment_mode,address=@address where kot_print_id=@kot_print_id", parm);

        }
        public int insert_bill_reprint(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@bill_no", bill_no)
            };
            return DAL.IDU("Insert into tbl_bill_reprint (bill_no) values (@bill_no)", parm); 
        }

        public DataTable getall_bill_no(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@bill_no", bill_no)
           };
            return DAL.getuser("select * from tbl_bill_reprint where bill_no=@bill_no", parm);
        }


    }
}




    

        

    
    

    


