using DOA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
    public class BLL_credit_paid
    {
        public int Insert_credit_paid(int customer_id, decimal credit_amount, decimal credit_paid, decimal credit_left, string credit_checked_by, DateTime checked_date, string payment_mode, string status, string paid_status)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_paid",credit_paid),
              new SqlParameter("@credit_left",credit_left),
              new SqlParameter("@credit_checked_by",credit_checked_by),
              new SqlParameter("@checked_date",checked_date),
               new SqlParameter("@payment_mode",payment_mode),
              new SqlParameter("@status",status),
              new SqlParameter("@paid_status",paid_status),

            };
            return DAL.IDU("Insert into tbl_credit_paid(customer_id,credit_amount,credit_paid,credit_left,credit_checked_by,checked_date,payment_mode,status,paid_status) values(@customer_id,@credit_amount,@credit_paid,@credit_left,@credit_checked_by,@checked_date,@payment_mode,@status,@paid_status)", parm);
        }
        public int Insert_credit_received(int customer_id, decimal credit_amount, decimal credit_received, DateTime credit_received_date, string payment_mode, string paid_status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_received",credit_received),
              new SqlParameter("@credit_received_date",credit_received_date),
              new SqlParameter("@payment_mode",payment_mode),
                 new SqlParameter("@paid_status",paid_status),
             };
            return DAL.IDU("Insert into tbl_credit_received(customer_id,credit_amount,credit_received,credit_received_date,credit_status,payment_mode,paid_status) values(@customer_id,@credit_amount,@credit_received,@credit_received_date,'X',@payment_mode,@paid_status)", parm);
        }
  
        public int Insert_credit_received(int customer_id, decimal credit_amount, decimal credit_received, DateTime credit_received_date,string payment_mode)
        { 

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_received",credit_received),
              new SqlParameter("@credit_received_date",credit_received_date),
              new SqlParameter("@payment_mode",payment_mode)

            };
            return DAL.IDU("Insert into tbl_credit_received(customer_id,credit_amount,credit_received,credit_received_date,credit_status,payment_mode) values(@customer_id,@credit_amount,@credit_received,@credit_received_date,'X',@payment_mode)", parm);
        }
        public int Update_customer_credit(int customer_id, decimal credit_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter("@customer_id", customer_id),
              new SqlParameter("@credit_amount", credit_amount)
                };
            return DAL.IDU("update tbl_customer_credits set credit_amount=@credit_amount where customer_id=@customer_id", parm);
        }
    }
}
