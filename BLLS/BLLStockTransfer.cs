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
    public class BLLStockTransfer
    {
        public DataTable selectallid()
        {
            return DAL.getuser("select * from tbl_stocks_transfer", null);
        }

        public int stocktransfer(string category_name, string product_name, int quantity, DateTime transfer_date, int unit_on_stock, string transfer_by, string transfer_to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       new SqlParameter("@category_name",category_name),
       new SqlParameter("@product_name",product_name),
       new SqlParameter("@quantity",quantity),
        new SqlParameter("@unit_on_stock",unit_on_stock),
         new SqlParameter("@transfer_by",transfer_by),
          new SqlParameter("@transfer_to",transfer_to),
        new SqlParameter("@transfer_date",transfer_date)

       };
            return DAL.IDU("insert into tbl_stocks_transfer(transfer_date,category_name,product_name,quantity,unit_on_stock,transfer_by,transfer_to) values (@transfer_date,@category_name,@product_name,@quantity,@unit_on_stock,@transfer_by,@transfer_to)", parm);
        }
        public int stockdelete(int quantity, string product_name)
        {

            SqlParameter[] parm = new SqlParameter[]
               {
       new SqlParameter("@quantity",quantity),
       new SqlParameter("@product_name",product_name),
               };
            return DAL.IDU("UPDATE tbl_stocks SET quantity = quantity-@quantity WHERE product_name=@product_name", parm);
        }
        public DataTable SearchByProduct(int product_id, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id",product_id),
                new SqlParameter("@datefrom",datefrom),
                new SqlParameter("@dateto",dateto)

            };
            return DAL.getuser("select * from tbl_stock_transfer where product_id=@product_id and transfer_date between @datefrom and @dateto", parm);
        }
        public DataTable SearchByCategory(int category_id, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id",category_id),
                new SqlParameter("@datefrom",datefrom),
                new SqlParameter("@dateto",dateto)

            };
            return DAL.getuser("select * from tbl_stock_transfer where category_id=@category_id and transfer_date between @datefrom and @dateto", parm);
        }
        public DataTable QuantitySum()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select sum(qty) from tbl_stock_transfer", null);
            return dt;
        }
    }
}
