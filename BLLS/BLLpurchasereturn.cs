using DOA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
   public class BLLpurchasereturn
    {
        public int DeleteProduct(int purchase_return_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@purchase_return_id", purchase_return_id)
            };
            return DAL.IDU("Delete from tbl_purchase_return where purchase_return_id = @purchase_return_id", parm);
        }
        public int InsertPurchasereturn(int category_id, int product_id, decimal qty, string unit, decimal price, decimal discount, decimal total, DateTime expiry_date, decimal tax,DateTime purchase_date, string po_no, string supplier_name, decimal sub_total, string received_by, decimal grand_total, string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@category_id",category_id),
               new SqlParameter("@product_id",product_id),
               new SqlParameter("@qty",qty),
              // new SqlParameter("@invoice_no",invoice_no),
               new SqlParameter("@price",price),
               new SqlParameter("@discount",discount),
               new SqlParameter("@total",total),
               new SqlParameter("@expiry_date",expiry_date),
               new SqlParameter("@tax",tax),
                new SqlParameter("@purchase_date",purchase_date),
                 new SqlParameter("@unit",unit),
                 new SqlParameter("@supplier_name",supplier_name),
                  new SqlParameter("@sub_total",sub_total),
                 new SqlParameter("@received_by",received_by),
                 new SqlParameter("@grand_total",grand_total),
                 new SqlParameter("@po_no",po_no),
                 new SqlParameter("@bill_no",bill_no)

            };
            return DAL.IDU("insert into tbl_purchase_return (category_id,product_id,qty,price,discount,total,expiry_date,tax,purchase_date,unit,po_no,supplier_name,sub_total,received_by,grand_total) values(@category_id,@product_id,@qty,@price,@discount,@total,@expiry_date,@tax,@purchase_date,@unit,@po_no,@supplier_name,@sub_total,@received_by,@grand_total)", parm);
        }
        public int updatestock(int category_id,int product_id,decimal qty)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
               new SqlParameter("@qty",qty)
            };
            return DAL.IDU("update tbl_stock set qty=qty-@qty where category_id=@category_id and product_id=@product_id", parm);
        }
        public int getqty(int category_id, int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
      
            };
            return DAL.IDU("select * from tbl_stock where category_id=@category_id and product_id=@product_id", parm);
        }
        public int getdatabypurchase(int purchase_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@purchase_id",purchase_id),
            };
            return DAL.IDU("select * from tbl_purchase where purchase_id=@purchase_id", parm);
        }
        public int updatestockdamage(int category_id, int product_id, string location, decimal qty)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
               new SqlParameter("@location",location),
               new SqlParameter("@qty",qty)
            };
            return DAL.IDU("update tbl_stock set qty=qty-@qty where category_id=@category_id and product_id=@product_id and location=@location", parm);
        }
    }
}
