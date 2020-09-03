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
   public class BLLcredit_clear
    {
        public DataTable Get_Credit_Clear()
        {
            return DAL.getuser("select * from tbl_credit_clear", null);
        }
        public int Insert_credit_clear(int customer_id, decimal credit_amount, decimal credit_paid, decimal debit_amount, string checked_by, DateTime checked_date,string remark)
        {

            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@customer_id",customer_id),
              new SqlParameter("@credit_amount",credit_amount),
              new SqlParameter("@credit_paid",credit_paid),
              new SqlParameter("@debit_amount",debit_amount),
              new SqlParameter("@checked_by",checked_by),
              new SqlParameter("@checked_date",checked_date),
               new SqlParameter("@remark",remark)

            };
            return DAL.IDU("Insert into tbl_credit_clear(customer_id,credit_amount,credit_paid,debit_amount,checked_by,checked_date,remark) values(@customer_id,@credit_amount,@credit_paid,@debit_amount,@checked_by,@checked_date,@remark)", parm);
        }
    }
}
