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
    public class BLLdiscount
    {
        public DataTable GetDiscount()
        {
            return DAL.getuser("select * from tbl_discount", null);

        }
        public DataTable Select_name(string discont_name)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
                new SqlParameter("@discount_name", discont_name)
         };
            return DAL.getuser("select * from tbl_discount where discount_name=@discount_name", parm);

        }
        public int InsertDiscount(string discont_name, decimal discont)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@discount_name", discont_name),
                new SqlParameter("@discount", discont)
            };

            return DAL.IDU("Insert into tbl_discount(discount,discount_name) values (@discount,@discount_name)", parm);
        
    }

        public int UpdateDiscount(int discount_id,string discont_name, decimal discont)
        {
            SqlParameter[] parm = new SqlParameter[]
            {new SqlParameter("@discount_id", discount_id),
                new SqlParameter("@discount_name", discont_name),
                new SqlParameter("@discount", discont)
            };

            return DAL.IDU("update  tbl_discount set discount_name=@discount_name,discount=@discount where discount_id=@discount_id", parm);

        }
        public int insertAdvanceDiscount(string table_no, string discount_amount, string discount_percent)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
              new SqlParameter("@table_no", table_no),
                new SqlParameter("@discount_amount", discount_amount),
                new SqlParameter("@discount_percent", discount_percent)
          };
            return DAL.IDU("insert into tbl_advance_discount (table_no,discount_amount,discount_percent) values (@table_no,@discount_amount,@discount_percent)", parm);
        }
        public DataTable ad_tableNoCheck(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
              new SqlParameter("@table_no", table_no)
        };
            return DAL.getuser("select * from tbl_advance_discount where table_no=@table_no", parm);        

      }
        public int UpdateAdvanceDiscount(string table_no, string discount_amount,string discount_percent)
        {
            SqlParameter[] parm = new SqlParameter[]
      {
              new SqlParameter("@table_no", table_no),
                new SqlParameter("@discount_amount", discount_amount),
                 new SqlParameter("@discount_percent", discount_percent)

      };
            return DAL.IDU("update  tbl_advance_discount set discount_amount=@discount_amount,discount_percent=@discount_percent where table_no=@table_no", parm);
        }
        public int DeleteAdvanceDiscount(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@table_no", table_no)
             };
            return DAL.IDU("delete tbl_advance_discount where table_no=@table_no", parm);
        }
        public int DeleteAdvancePay(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@table_no", table_no)
            };
            return DAL.IDU("delete tbl_quotation where table_no=@table_no", parm);
        }
    }

}
