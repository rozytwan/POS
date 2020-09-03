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
    public class BLLStockCategory
    {
        public DataTable GetCategories()
        {
            return DAL.getuser("Select * from tbl_categorys order by category_name ASC", null);
        }
        public DataTable GetDepartment()
        {
            return DAL.getuser("Select * from tbl_department order by department ASC", null);
        }
        public DataTable GetUnit()
        {
            return DAL.getuser("Select * from tbl_inhouse_unit order by unit_name ASC", null);
        }
        public DataTable GetproductList()
        {
            return DAL.getuser("Select * from tbl_stock_products", null);
        }

        public DataTable GetProductByCategoryid(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
new SqlParameter("@category_id",category_id)
         };
            return DAL.getuser("Select * from tbl_stock_products where category_id=@category_id", parm);
        }

        public DataTable GetCategory(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@category_id",category_id)
            };
            return DAL.getuser("Select * from tbl_categorys where category_id=@category_id", parm);
        }

        public DataTable GetDepartment(int department_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter("@id",department_id)
                };
            return DAL.getuser("Select * from tbl_department where id=@id", parm);
        }
        public DataTable GetUnit1(decimal inhouse_unit_1)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@inhouse_unit_id1",inhouse_unit_1)
            };
            return DAL.getuser("Select * from tbl_inhouse_unit where inhouse_unit_id=@inhouse_unit_id1", parm);
        }
        public DataTable GetUnit2(decimal inhouse_unit_2)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@inhouse_unit_id1",inhouse_unit_2)
            };
            return DAL.getuser("Select * from tbl_inhouse_unit where inhouse_unit_id=@inhouse_unit_id1", parm);
        }
        public DataTable GetUnit3(decimal inhouse_unit_3)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@inhouse_unit_id1",inhouse_unit_3)
            };
            return DAL.getuser("Select * from tbl_inhouse_unit where inhouse_unit_id=@inhouse_unit_id1", parm);
        }


        public int InsertProduct(int category_id, string product_name, int id, decimal inhouse_qty1, string inhouse_unit_id1, decimal inhouse_qty2, string inhouse_unit_id2, decimal inhouse_qty3, string inhouse_unit_id3, string min_stock)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
new SqlParameter("@category_id",category_id),
new SqlParameter("@product_name",product_name),
new SqlParameter("@id",id),
new SqlParameter("@inhouse_qty1",inhouse_qty1),
new SqlParameter("@inhouse_unit1",inhouse_unit_id1),
new SqlParameter("@inhouse_qty2",inhouse_qty2),
new SqlParameter("@inhouse_unit2",inhouse_unit_id2),
new SqlParameter("@inhouse_qty3",inhouse_qty3),
new SqlParameter("@inhouse_unit3",inhouse_unit_id3),
new SqlParameter("@min_stock",min_stock),
  };
            return DAL.IDU("Insert into tbl_stock_products(category_id,product_name,department_id,inhouse_qty_1,inhouse_unit_1,inhouse_qty_2,inhouse_unit_2,inhouse_qty_3,inhouse_unit_3,min_stock) values (@category_id,@product_name,@id,@inhouse_qty1,@inhouse_unit1,@inhouse_qty2,@inhouse_unit2,@inhouse_qty3,@inhouse_unit3,@min_stock)", parm);
        }

        public int UpdateProduct(int product_id, int category_id, string product_name, int id, decimal qty1, string inhouse_unit_id1, decimal qty2, string inhouse_unit_id2, decimal qty3, string inhouse_unit_id3, string min_stock)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
           new SqlParameter("@product_id",product_id),
new SqlParameter("@category_id",category_id),
new SqlParameter("@product_name",product_name),
new SqlParameter("@id",id),
new SqlParameter("@inhouse_qty1",qty1),
new SqlParameter("@inhouse_unit1",inhouse_unit_id1),
new SqlParameter("@inhouse_qty2",qty2),
new SqlParameter("@inhouse_unit2",inhouse_unit_id2),
new SqlParameter("@inhouse_qty3",qty3),
new SqlParameter("@inhouse_unit3",inhouse_unit_id3),
new SqlParameter("@min_stock",min_stock),
     };
            return DAL.IDU("Update tbl_stock_products set category_id=@category_id,product_name=@product_name,department_id=@id,inhouse_qty_1=@inhouse_qty1,inhouse_unit_1=@inhouse_unit1,inhouse_qty_2=@inhouse_qty2,inhouse_unit_2=@inhouse_unit2,inhouse_qty_3=@inhouse_qty3,inhouse_unit_3=@inhouse_unit3,min_stock=@min_stock where product_id=@product_id", parm);
        }
        public int DeleteProduct(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Delete from tbl_stock_products where product_id = @product_id", parm);
        }
        public DataTable Getproductbyid(string product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                new SqlParameter("@product_id",product_id)
            };
            return DAL.getuser("Select * from tbl_stock_products where product_id=@product_id", parm);
        }
       
        public DataTable Getunitbyproductid(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@product_id",product_id)
            };
            return DAL.getuser("select inhouse_unit_1,inhouse_unit_2,inhouse_unit_3 from tbl_stock_products where product_id=@product_id", parm);
        }
        public DataTable GetQtybyProductid(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@product_id",product_id)
            };
            return DAL.getuser("select product_name,inhouse_unit_1,inhouse_qty_1,inhouse_unit_2,inhouse_qty_2,inhouse_unit_3,inhouse_qty_3 from tbl_stock_products where product_id=@product_id", parm);
        }
        public DataTable SearchProductbyName(string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
            new SqlParameter("@product_name",product_name)
           };
            return DAL.getuser("select * from tbl_stock_products where product_name like '%' +@product_name+ '%'", parm);
        }
        public DataTable Searchproductbydepartment(string department)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                new SqlParameter("@department",department)
             };
            return DAL.getuser("SELECT product_name,category_name,department,inhouse_qty_1,inhouse_unit_1,inhouse_qty_2,inhouse_unit_2,inhouse_qty_3,inhouse_unit_3 FROM tbl_stock_products s JOIN tbl_department d   ON s.department_id = d.id join tbl_categorys c on s.category_id = c.category_id   where department like '%' +@department+ '%'", parm);
        }
        public DataTable GetDepartmentbyproduct_id(int category_id, int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter("@category_id",category_id),
            new SqlParameter("@product_id",product_id)
            };
            return DAL.getuser("select * from tbl_stock where category_id=@category_id and product_id=@product_id", parm);
        }

        public int UpdateProductbyproductid(int category_id, int product_id, decimal qty)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@category_id", category_id),
            new SqlParameter("@product_id", product_id),
              new SqlParameter("@qty", qty),

            };
            return DAL.IDU("update tbl_stock set qty=@qty+qty where category_id=@category_id and product_id=@product_id", parm);

        }
        public DataTable GetItemName(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
new SqlParameter("@item_id",item_id)
            };
            return DAL.getuser("Select * from tbl_items where item_id=@item_id", parm);
        }
        public DataTable GetAllCategory()
        {
            return DAL.getuser("Select * from tbl_categorys", null);
        }
        public DataTable GetAllItems()
        {
            return DAL.getuser("Select * from tbl_items", null);
        }
        public DataTable SearchProductName(string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
            new SqlParameter("@product_name",product_name)
           };
            return DAL.getuser("select * from tbl_stock_products where product_name=@product_name", parm);
        }
        public int ActivateProduct(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Update tbl_stock_products set column1='null' where product_id = @product_id", parm);
        }
        public int DeleteProductIngredient(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Delete from tbl_ingredients where product_id = @product_id", parm);
        }
      
        public int DeleteProductPurchase(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Delete from tbl_purchase where product_id = @product_id", parm);
        }
        public int DeleteProductStock(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Delete from tbl_stock where product_id = @product_id", parm);
        }
        public int DeleteProductTransfer(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_id", product_id)
            };
            return DAL.IDU("Delete from tbl_stock_transfer where product_id = @product_id", parm);
        }
    }
}