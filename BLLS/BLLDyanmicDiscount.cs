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
   public  class BLLDyanmicDiscount
    {
        public int inserDyanmicDiscount(string discount_type, string discount_percent)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@discount_type",discount_type),
                    new SqlParameter("@discount_percent",discount_percent)
                };
            return DAL.IDU("insert into tbl_dyanmic_discount (discount_type,discount_percent) values (@discount_type,@discount_percent)",parm);
        }
        public DataTable GetDyanmiDiscountby(string discount_type, string discount_percent)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@discount_type",discount_type),
                    new SqlParameter("@discount_percent",discount_percent)
                };
            return DAL.getuser("select * from tbl_dyanmic_discount where discount_type=@discount_type and discount_type=@discount_type", parm);
        }
        public DataTable get_all_data()
        {
            return DAL.getuser("select * from tbl_dyanmic_discount", null);
        }
        public int UpdateDyanmicDiscount(string discount_type, string discount_percent,int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@discount_type",discount_type),
                    new SqlParameter("@discount_percent",discount_percent),
                    new SqlParameter("@id",id)
                };
            return DAL.IDU("update  tbl_dyanmic_discount set discount_type=@discount_type,discount_percent=@discount_percent where id=@id", parm);
        }
        public int delete_dyanmicDiscount(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     new SqlParameter("@id",id),

                };
            return DAL.IDU("delete from tbl_dyanmic_discount where id=@id", parm);
        }
    }
}
