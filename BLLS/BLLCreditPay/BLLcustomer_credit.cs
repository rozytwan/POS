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
    public class BLLcustomer_credit
    {
        public int insert_into_credit(int customer_id, int bill_no, DateTime credit_date, decimal credit_amount, string credit_by,string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@customer_id",customer_id),
                       new SqlParameter("@credit_amount",credit_amount),
                         new SqlParameter("@bill_no",bill_no),
                           new SqlParameter("@credit_date",credit_date),
                             new SqlParameter("@credit_by",credit_by),
                             new SqlParameter("@status",status)

                };
            return DAL.IDU("insert into tbl_customer_credits (customer_id,credit_amount,bill_no,credit_date,credit_by,status) values (@customer_id,@credit_amount,@bill_no,@credit_date,@credit_by,@status)", parm);
        }

        public int Insert_Cheque_Detail(string bank_name, string cheque_no, decimal amount, string cheque_pay_to, string cheque_holder, string receiver, string pay_status, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@bank_name",bank_name),
              new SqlParameter("@cheque_no",cheque_no),
              new SqlParameter("@amount",amount),
              new SqlParameter("@cheque_pay_to",cheque_pay_to),
              new SqlParameter("@cheque_holder",cheque_holder),
              new SqlParameter("@receiver",receiver),
                 new SqlParameter("@pay_status",pay_status),
                 new SqlParameter("@date",date),
             };
            return DAL.IDU("Insert into tbl_cheque_detail(bank_name,cheque_no,amount,cheque_pay_to,cheque_holder,received_by,pay_status,date) values(@bank_name,@cheque_no,@amount,@cheque_pay_to,@cheque_holder,@receiver,@pay_status,@date)", parm);
        }
        public DataTable Search_by_CustomerCredit(string full_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@full_name",full_name),

            };
            return DAL.getuser("select * from tbl_customer_credits cc inner join tbl_customerDetailnyo cd on cc.customer_id=cd.id where cd.name like @full_name +'%' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') and cc.status='RC' ", parm);
        }
        public DataTable Search_Hotel_CustomerCredit(string full_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@full_name",full_name),

            };
            return DAL.getuser("select * from tbl_customer_credits cc inner join tbl_customerDetailnyo cd on cc.customer_id=cd.id where cd.name like @full_name +'%' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') and cc.status='HC' ", parm);
        }

        public DataTable Get_Customer_creditsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_amount) FROM tbl_customer_credits where customer_id=@customer_id and status='RC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable Get_hotel_creditsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_amount) FROM tbl_customer_credits where customer_id=@customer_id and status='HC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable Get_Customer_paidsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_paid) as paid FROM tbl_credit_paid where customer_id=@customer_id and paid_status='RP'", parm);
        }

        public DataTable Get_hotelcustomer_paidsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_paid) FROM tbl_credit_paid where customer_id=@customer_id and paid_status='HP'", parm);
        }
        public DataTable Get_Credit_Left(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("SELECT credit_left FROM tbl_credit_paid WHERE checked_date=(SELECT MAX(checked_date) FROM tbl_credit_paid WHERE customer_id=@customer_id and paid_status='RP');", parm);
        }
        public DataTable Get_Hotel_CreditLeft(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("SELECT credit_left FROM tbl_credit_paid WHERE checked_date=(SELECT MAX(checked_date) FROM tbl_credit_paid WHERE customer_id=@customer_id and paid_status='HP');", parm);
        }
        public DataTable Get_Customer_ById(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",id)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where id=@id", parm);
        }
  
        public DataTable Get_CreditPaid_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select * from tbl_credit_paid where customer_id=@id and paid_status='RP'", parm);
        }
        public DataTable Get_HotelCreditPaid_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select * from tbl_credit_paid where customer_id=@id and paid_status='HP'", parm);
        }
        public DataTable Get_Latest_ByCustomerId(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                       {
              new SqlParameter("@id",customer_id)
                       };
            return DAL.getuser("SELECT credit_left from tbl_credit_paid WHERE checked_date In (SELECT MAX(checked_date) FROM tbl_credit_paid GROUP BY customer_id)", parm);
        }
        public DataTable Get_Credit_Amount_ByUsername(string credit_by,DateTime credit_date)
        {
            SqlParameter[] parm = new SqlParameter[]
                        {
              new SqlParameter("@credit_by",credit_by),
              new SqlParameter("@credit_date",credit_date)
             
                        };

            return DAL.getuser("select sum(credit_amount) from tbl_customer_credits where credit_by=@credit_by and credit_date=@credit_date", parm);
        }
        public DataTable Get_Credit_Receive_ByUsernameandCash(string credit_checked_by, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                        {
              new SqlParameter("@credit_checked_by",credit_checked_by),
               new SqlParameter("@status",status)
                        };

            return DAL.getuser("select sum(credit_paid) from tbl_credit_paid where credit_checked_by=@credit_checked_by and status=@status and payment_mode='Cash'", parm);
        }
        public DataTable Get_Credit_Receive_ByUsernameandCard(string credit_checked_by, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
                        {
              new SqlParameter("@credit_checked_by",credit_checked_by),
               new SqlParameter("@status",status)
                        };

            return DAL.getuser("select sum(credit_paid) from tbl_credit_paid where credit_checked_by=@credit_checked_by and status=@status and payment_mode='Card'", parm);
        }

        public DataTable Get_Data_ByGrouping_Customer_Id(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select customer_id,sum_credit_amount=Sum(credit_amount) FROM tbl_customer_credits where status='RC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') GROUP BY customer_id", parm);
        }
        public DataTable Get_Hotel_Credit_Groupbyid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select customer_id,sum_credit_amount=Sum(credit_amount) FROM tbl_customer_credits where status='HC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') GROUP BY customer_id", parm);
        }
        public DataTable Get_customer_credit_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select * from tbl_customer_credits where customer_id=@id and status='RC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable Get_Hotel_credit_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select * from tbl_customer_credits where customer_id=@id and status='HC' and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') ", parm);
        }
        public DataTable Get_Data_By_Customer_Id(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select sum_credit_amount=Sum(credit_amount) FROM tbl_customer_credits where status='RC' and customer_id=@id and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable Get_HotelData_By_Customer_Id(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select sum_credit_amount=Sum(credit_amount) FROM tbl_customer_credits where status='HC' and customer_id=@id and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable Get_Sum_Credit_Paid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select sum(credit_paid) from tbl_credit_paid where paid_status='RP' and @customer_id=customer_id", parm);
 }
        public DataTable Get_Sum_HotelCredit_Paid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select sum(credit_paid) from tbl_credit_paid where paid_status='HP' and customer_id=@customer_id", parm);
        }
        public DataTable GetALltodayCreditList()
        {
            
            return DAL.getuser("select name,lastname,bill_no,credit_amount from tbl_customer_credits c join tbl_customerDetailnyo cd on (c.customer_id=cd.id) where credit_date=(select convert (date ,getdate()));", null);
        }
        public DataTable Get_Credit_Amount(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select distinct sum(credit_amount) from tbl_customer_credits where status='RC' and @customer_id=customer_id", parm);
        }
        public DataTable Get_HotelCredit_Amount(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select distinct sum(credit_amount) from tbl_customer_credits where status='HC' and  @customer_id=customer_id", parm);
        }


        public int Delete_paid_customer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.IDU("delete from tbl_credit_paid where customer_id in (select customer_id where customer_id=@customer_id)", parm);
        }
        public int Delete_Clear_customer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.IDU("delete from tbl_customer_credits where customer_id in (select customer_id where customer_id=@customer_id)", parm);
        }
      
        public DataTable Check_NextTable_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select * from tbl_credit_paid where customer_id=@customer_id and paid_status='RP'", parm);
        }
        public DataTable Check_HotelPaid_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select * from tbl_credit_paid where customer_id=@customer_id and paid_status='HP'", parm);
        }
        public DataTable Get_Credit_Clear(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select * from tbl_credit_clear where customer_id=@customer_id", parm);
        }
        public DataTable Get_creditpay_Byid(int creditpay_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@creditpay_id",creditpay_id)
            };
            return DAL.getuser("select * from tbl_credit_paid where creditpay_id=@creditpay_id", parm);
        }
        public int Update_creditpay(int creditpay_id,decimal credit_paid,decimal credit_left)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                  new SqlParameter("@creditpay_id",creditpay_id),
                   new SqlParameter("@credit_paid",credit_paid),
                    new SqlParameter("@credit_left",credit_left)
            
            };
            return DAL.IDU("update tbl_credit_paid set credit_paid=@credit_paid,credit_left=@credit_left where creditpay_id=@creditpay_id", parm);
        }
        public int Delete_paid_customer(int customer_id, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@status",status),
            };
            return DAL.IDU("delete from tbl_credit_paid where customer_id in (select customer_id where customer_id=@customer_id) and paid_status=@status", parm);
        }
        public int Delete_Clear_customer(int customer_id, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
               new SqlParameter("@status",status),
            };
            return DAL.IDU("delete from tbl_customer_credits where customer_id in (select customer_id where customer_id=@customer_id) and status=@status", parm);
        }
    }
}