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
    public class BLL_Card_Credit
    {
        public DataTable GetCustomer()
        {
            return DAL.getuser("select * from tbl_customerDetailnyo where card_type='owner' and card_no is not null", null);
        }
        public DataTable GetPaid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter ("@customer_id",customer_id)
           };
            return DAL.getuser("select * from tbl_card_creditpay where customer_id=@customer_id", parm);
        }
        public DataTable GetLastName(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@name",name)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where card_type='owner' and name=@name", parm);
        }
        public DataTable GetDetails(string name,string lastname)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@name",name),
                new SqlParameter ("@lastname",lastname)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where name=@name and lastname=@lastname", parm);
        }
        public int InsertReferCustomer(string name,string lastname,string phone,decimal refer_balance)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter ("@name",name),
                      new SqlParameter ("@lastname",lastname),
                            new SqlParameter ("@phone",phone),
                                  new SqlParameter ("@refer_balance",refer_balance),
            };
            return DAL.IDU("Insert into tbl_refer_customer(name,lastname,phone,refer_balance) values (@name,@lastname,@phone,@refer_balance)", parm);
        }
        public int InsertCredit(int customer_id, decimal credit_amount, DateTime credit_date, string credit_by, string refer_by)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_date",credit_date),
              new SqlParameter("@credit_by",credit_by),
              new SqlParameter("@refer_by",refer_by),
             

            };
            return DAL.IDU("Insert into tbl_card_credit(customer_id,credit_amount,credit_date,credit_by,refer_by) values(@customer_id,@credit_amount,@credit_date,@credit_by,@refer_by)", parm);
        }
        public int Insert_credit_received(int customer_id, decimal credit_amount, decimal credit_received, DateTime credit_received_date,string credit_received_by)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),

              new SqlParameter("@credit_received",credit_received),
              new SqlParameter("@credit_received_date",credit_received_date),
               new SqlParameter("@credit_received_by",credit_received_by)

            };
            return DAL.IDU("Insert into tbl_cardcreditpaid_record(customer_id,credit_amount,credit_received,credit_received_date,credit_received_by) values(@customer_id,@credit_amount,@credit_received,@credit_received_date,@credit_received_by)", parm);
        }
        public int Insert_credit_paid(int customer_id, decimal credit_amount, decimal credit_paid, decimal credit_left, string credit_checked_by, DateTime checked_date)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_paid",credit_paid),
              new SqlParameter("@credit_left",credit_left),
              new SqlParameter("@credit_checked_by",credit_checked_by),
              new SqlParameter("@checked_date",checked_date)

            };
            return DAL.IDU("Insert into tbl_card_creditpay(customer_id,credit_amount,credit_paid,credit_left,credit_checked_by,checked_date) values(@customer_id,@credit_amount,@credit_paid,@credit_left,@credit_checked_by,@checked_date)", parm);
        }
        public DataTable Get_Data_ByGrouping_Customer_Id(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select customer_id,sum_credit_amount=Sum(credit_amount) FROM tbl_card_credit GROUP BY customer_id", parm);
        }
        public DataTable Get_customer_credit_Customerid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@id",customer_id)
            };
            return DAL.getuser("select * from tbl_card_credit where customer_id=@id", parm);
        }
        public DataTable GetCustomerByPhone(string phone)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@phone",phone)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where phone=@phone", parm);
        }
        public DataTable Get_Customer_creditsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_amount) FROM tbl_card_credit where customer_id=@customer_id", parm);
        }
        public DataTable Get_Customer_paidsum(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                     {
              new SqlParameter("@customer_id",customer_id)
                     };
            return DAL.getuser("Select Sum(credit_paid) FROM tbl_card_creditpay where customer_id=@customer_id", parm);
        }
        public DataTable Get_Credit_Amount(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select distinct sum(credit_amount) from tbl_card_credit where @customer_id=customer_id", parm);
        }
        public int Delete_Clear_customer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.IDU("delete from tbl_card_credit where customer_id in (select customer_id where customer_id=@customer_id)", parm);
        }
        public int Delete_Credit_Paid(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id)
            };
            return DAL.IDU("delete from tbl_card_creditpay where customer_id in (select customer_id where customer_id=@customer_id)", parm);
        }
    }
}
