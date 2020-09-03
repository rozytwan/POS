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
  public class BLLBarCode
    {
        public int insert_bar_code(int product_id, int item_id, string bar_code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id),
                    new SqlParameter("@item_id",item_id),
                    new SqlParameter("@bar_code",bar_code)
                 
                };
            return DAL.IDU("Insert into tbl_barcode (product_id,item_id,bar_code)values(@product_id,@item_id,@bar_code)", parm);
        }
        public DataTable get_all_byitenm_id(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@item_id",item_id)
                };
            return DAL.getuser("select * from tbl_barcode where item_id=@item_id", parm);
        }
        public DataTable get_all_item_barcode()
        {
            return DAL.getuser("select * from tbl_barcode", null);
        }
        public int update_barcode(int barcode_id, string bar_code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@barcode_id",barcode_id),
                    new SqlParameter("@bar_code",bar_code)
                };
            return DAL.IDU("update tbl_barcode set bar_code=@bar_code where bar_code_id=@barcode_id", parm);
        }
        public int delete_barcode(int barcode_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@barcode_id",barcode_id)
                    };
            return DAL.IDU("delete from tbl_barcode where bar_code_id=@barcode_id", parm);

        }
        public DataTable get_all_item_by_bar_code(string bar_code)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bar_code",bar_code)
                };
            return DAL.getuser("select * from tbl_barcode where bar_code=@bar_code", parm);
        }
    }
}
