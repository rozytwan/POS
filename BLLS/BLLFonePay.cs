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
   public class BLLFonePay
    {
        public int FonePayInsert(string user_name, string password, string merchantCode, string secretKey)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_name",user_name),
                new SqlParameter("@password",password),
                new SqlParameter("@merchantCode",merchantCode),
                new SqlParameter("@secretKey",secretKey)

            };
            return DAL.IDU("Insert into tbl_fonePay (user_name,password,merchant_code,secret_key) values (@user_name,@password,@merchantCode,@secretKey)", parm);
        }
        public DataTable getALLFonePayData()
        {
            return DAL.getuser("select * from tbl_fonePay", null);
        }
        public int FonePayUpdate(string user_name, string password, string merchantCode, string secretKey,int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@user_name",user_name),
                new SqlParameter("@password",password),
                new SqlParameter("@merchantCode",merchantCode),
                new SqlParameter("@secretKey",secretKey),
                   new SqlParameter("@id",id)

            };
            return DAL.IDU("update tbl_fonePay set user_name=@user_name,password=@password,merchant_code=@merchantCode,secret_key=@secretKey where id=@id", parm);
        }
        public int InsertFonePayLog(int bill_no, string cashier, decimal amount, string prdno, string fiscal_year, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@bill_no",bill_no),
                new SqlParameter("@cashier",cashier),
                new SqlParameter("@amount",amount),
                new SqlParameter("@prdno",prdno),
                   new SqlParameter("@fiscal_year",fiscal_year),
                new SqlParameter("@date",date)

            };
            return DAL.IDU("Insert into tbl_fonePayLog(bill_no,cashier,amount,product_no,fiscal_year,date) values (@bill_no,@cashier,@amount,@prdno,@fiscal_year,@date)", parm);
        }
    }
}
