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
    public class BLLSift_Change
    {
        public DataTable sum_grand_total_by_user(string cashier_name, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@x_report",x_report)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total from tbl_sales_record where x_report=@x_report and cashier_name=@cashier_name and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void) ", parm);
        }
        public DataTable sum_card_sale(string cashier_name, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                   new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@x_report",x_report)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report and payment_mode='Card' and cashier_name=@cashier_name and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        public DataTable sum_zomato_sales(string cashier_name, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                   new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@x_report",x_report)
                };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report and payment_mode='Zomato'and cashier_name=@cashier_name", parm);
        }
        public DataTable sum_grand_total_by_user_cash(string cashier_name, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@x_report",x_report)

                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and cashier_name=@cashier_name and payment_mode='Cash' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        //public DataTable sum_grand_total(string x_report)
        //{
        //    SqlParameter[] parm = new SqlParameter[]
        //        {
        //            new SqlParameter("@x_report",x_report)
        //        };
        //    return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total,discount,tax_amount,service_charge from tbl_sales_record where x_report=@x_report and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        //}

        public DataTable Sum_service_tax_discount(string cashier_name, string x_report)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@x_report",x_report)

                };
            return DAL.getuser("select DISTINCT bill_no,grand_total,service_charge,tax_amount,discount from tbl_sales_record where x_report=@x_report and cashier_name=@cashier_name and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        public DataTable sum_get_care_of()
        {
            
            return DAL.getuser("select sum(cash) from tbl_Counter_withdrawl", null);
        }
        public DataTable sum_get_care_of_by_user(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@name",name)
                };
            return DAL.getuser("select sum(cash) from tbl_Counter_withdrawl where name=@name", parm);
        }
        public DataTable Sum_Club_Card_Sales(string x_report,string cashier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
                 {
                    new SqlParameter("@x_report",x_report),
                    new SqlParameter("@cashier_name",cashier_name),
                 };
            return DAL.getuser("select DISTINCT bill_no,card_amount from tbl_sales_record where x_report=@x_report and payment_mode='Club Card' and cashier_name=@cashier_name", parm);
        }
        public DataTable sum_total_cash_counter()
        {
            
            return DAL.getuser("select Sum(opening_balc) from tbl_daily_ocs ", null);
        }
        public DataTable Sum_Credit_Amount(string x_report,string cashier_name)
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@x_report",x_report),
                     new SqlParameter("@cashier_name",cashier_name)
                };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where x_report=@x_report and payment_mode='Credit' and cashier_name=@cashier_name", parm);
        }
        public DataTable Sum_Credit_Amount_receive(string credit_status, string payment_mode )
        {

            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@credit_status",credit_status),
                    new SqlParameter("@payment_mode",payment_mode)
                };
            return DAL.getuser("select sum(credit_received) from tbl_credit_received where credit_status=@credit_status and payment_mode=@payment_mode", parm);
        }
        public DataTable Count_total_Table(string cashier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@cashier_name",cashier_name)
               };
            return DAL.getuser("select DISTINCT bill_no from tbl_sales_record where sales_type='TS'and x_report='X' and cashier_name=@cashier_name  and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        public DataTable Count_total_Take_away(string cashier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@cashier_name",cashier_name)
               };
            return DAL.getuser("select DISTINCT bill_no,grand_total from tbl_sales_record where sales_type='TA' and x_report='X' and cashier_name=@cashier_name and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        public DataTable Count_total_Home_delivery(string cashier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@cashier_name",cashier_name)
               };
            return DAL.getuser("select DISTINCT bill_no from tbl_sales_record where sales_type='HD' and x_report='X' and cashier_name=@cashier_name and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
        public DataTable count_total_table_busy()
        {
            return DAL.getuser("Select Distinct table_no from tbl_orders where table_no<100", null);
        }
        public DataTable count_total_home_delivery_left(string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                    new SqlParameter("@user_name",user_name)
            };
            return DAL.getuser("select count(bill_no) from tbl_sales_record where sales_type='HD' and x_report='X' and cashier_name=@user_name group by bill_no", parm);
        }
        public DataTable count_total_takeaway(string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@user_name",user_name)
            };
           return DAL.getuser("select count(bill_no)from tbl_sales_record where sales_type = 'TA' and x_report = 'X' and cashier_name=@user_name  group by bill_no", parm);
        }
        public DataTable count_cancelitem(string user_name,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@user_name",user_name),
                    new SqlParameter("@date",date)
            };
            return DAL.getuser("select count(item) from tbl_ordercancel where user_name=@user_name and cast(date as date)=@date", parm);
        }
        public DataTable count_total_cost_to_be_recived_ts()
        {
            return DAL.getuser("select sum(total) from tbl_orders where table_no<100", null);
        }
        public DataTable Sum_hold_By_HomeDelivery(string user_name)
        {
            SqlParameter[] parm = new SqlParameter[]
       {
              new SqlParameter("@user_name",user_name)
       };
            return DAL.getuser("select sum(total) from tbl_orders where table_no>100 and table_no<1000 and user_name=@user_name ", parm);
        }
        public DataTable get_login_time_staff_name(string staff_name, DateTime working_date)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@staff_name",staff_name),
                    new SqlParameter("@working_date",working_date)
                };
            return DAL.getuser("select * from tbl_Login_logout where staff_name=@staff_name and working_date=@working_date", parm);
        }
        public int insert_into_tbl(string user_name, decimal total_cash_sales, decimal total_card_sales, decimal total_sales, decimal total_cash_in_counter, string total_busy_table, decimal total_amount_hold_in_table, decimal total_amount_hold_in_hd, string total_delivery_left, string hand_over_to, DateTime session_date, DateTime session_date_time,decimal cash_drop, decimal service_charge,decimal tax_amount, decimal discount,decimal grand_total,decimal counting_cash,decimal closing_balance,decimal cash_settlement)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@user_name",user_name),
                    new SqlParameter("@total_cash_sales",total_cash_sales),
                    new SqlParameter("@total_card_sales",total_card_sales),
                    new SqlParameter("@total_sales",total_sales),
                    new SqlParameter("@total_cash_in_counter",total_cash_in_counter),
                    new SqlParameter("@total_busy_table",total_busy_table),
                    new SqlParameter("@total_amount_hold_in_table",total_amount_hold_in_table),
                    new SqlParameter("@total_amount_hold_in_hd",total_amount_hold_in_hd),
                    new SqlParameter("@total_delivery_left",total_delivery_left),
                    new SqlParameter("@hand_over_to",hand_over_to),
                    new SqlParameter("@session_date",session_date),
                    new SqlParameter("@session_date_time",session_date_time),
                    new SqlParameter("@cash_drop",cash_drop),
                    new SqlParameter("@service_charge",service_charge),
                    new SqlParameter("@tax_amount",tax_amount),
                    new SqlParameter("@discount",discount),
                    new SqlParameter("@grand_total",grand_total),
                    new SqlParameter("@counting_cash",counting_cash),
                    new SqlParameter("@closing_balance",closing_balance),
                    new SqlParameter("@cash_settlement",cash_settlement),

                 };
            return DAL.IDU("insert into tbl_shift_change (user_name,total_cash_sales,total_card_sales,total_sales,total_cash_in_counter,total_busy_table,total_amount_hold_in_table,total_amount_hold_in_hd,total_delivery_left,hand_over_to,session_date,session_date_time,cash_drop,service_charge,tax_amount,discount,grand_total,counting_cash,closing_balance,cash_settlement) values(@user_name,@total_cash_sales,@total_card_sales,@total_sales,@total_cash_in_counter,@total_busy_table,@total_amount_hold_in_table,@total_amount_hold_in_hd,@total_delivery_left,@hand_over_to,@session_date,@session_date_time,@cash_drop,@service_charge,@tax_amount,@discount,@grand_total,@counting_cash,@closing_balance,@cash_settlement)", parm);
        }
       
        public DataTable getall()
        {

            return DAL.getuser("select * from tbl_shift_change", null);
        }
  public DataTable getallbetweendates(DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };


            return DAL.getuser("select * from tbl_shift_change where  session_date between @dateFrom and @dataTo", parm);
        }

        public DataTable getusernames()
        {

            return DAL.getuser("SELECT user_name,COUNT(*) FROM tbl_shift_change group by user_name ", null);

        }
        public DataTable gethandovetto()
        {

            return DAL.getuser("SELECT hand_over_to,COUNT(*) FROM tbl_shift_change group by hand_over_to ", null);

        }

        public DataTable searchbyUsername(string username, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@username",username),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_shift_change where user_name like @username +'%' and  session_date between @dateFrom and @dataTo", parm);
        }

        public DataTable searchbyhandovertto(string username, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@username",username),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_shift_change where hand_over_to like @username +'%' and  session_date between @dateFrom and @dataTo", parm);
        }

    }
}
