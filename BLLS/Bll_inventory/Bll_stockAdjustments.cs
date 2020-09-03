using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS.Bll_inventory
{
 public   class Bll_stockAdjustments
    {
        public int insertintotable(int stock_id, DateTime ad_date,string description, decimal quantity, decimal stockonHand)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@stock_id",stock_id),
            new SqlParameter("@ad_date",ad_date),
            new SqlParameter("@description",description),
            new SqlParameter("@quantity",quantity),
            new SqlParameter("@stockonHand",stockonHand)
            };
            return DAL.IDU("insert into tbl_ad_stocks values(@stock_id,@ad_date,@description,@quantity,@stockonHand)", parm);
          
        }
        public int UpdateStockByAdjustments(decimal quantity, string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
         new SqlParameter("@quantity",quantity),
         new SqlParameter("@product_name",product_name)
         };
            return DAL.IDU("UPDATE tbl_stocks SET quantity = quantity +@quantity WHERE product_name=@product_name", parm);
        }

        public int UpdateStockByAdjustmentsminus(decimal quantity, string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
         new SqlParameter("@quantity",quantity),
         new SqlParameter("@product_name",product_name)
         };
            return DAL.IDU("UPDATE tbl_stocks SET quantity = quantity -@quantity WHERE product_name=@product_name", parm);
        }

        public DataTable getallAdStocksbyId(string stockId)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@stockId",stockId)
            };
            return DAL.getuser("select * from tbl_stock_adjust where stock_id=@stockId", parm);
        }
        public int InsertAdjustStock(int stock_id, DateTime adjust_date, string unit, decimal quantity, decimal stockon_hand, string note, string status, string username)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@stock_id",stock_id),
            new SqlParameter("@adjust_date",adjust_date),
            new SqlParameter("@unit",unit),
            new SqlParameter("@quantity",quantity),
             new SqlParameter("@stockon_hand",stockon_hand),
            new SqlParameter("@note",note),
            new SqlParameter("@status",status),
            new SqlParameter("@username",username)
            };
            return DAL.IDU("insert into tbl_stock_adjust(stock_id,qty,unit,adjust_date,stockon_hand,note,status,username) values(@stock_id,@quantity,@unit,@adjust_date,@stockon_hand,@note,@status,@username)", parm);

        }


    }
}
