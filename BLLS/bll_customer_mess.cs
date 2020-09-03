using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DOA;

namespace BLLS
{
   public class bll_customer_mess
    {
        public DataTable getallItems() {

            return DAL.getuser("select *from tbl_items order by item_name asc",null);
        }
        public DataTable getallPakagesLists()
        {

            return DAL.getuser("select *from tbl_messPakage order by name asc", null);
        }

        public int deletepakages(int id) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("delete from tbl_messPakage where pg_id = @id", parm);
        }

        public DataTable CheckExistedPakagename(String Name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@Name",Name)
            };

            return DAL.getuser("select *from tbl_messPakage where name=@Name", parm);
        }
        public DataTable SearchPakagename(String Name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@Name",Name)
            };

            return DAL.getuser("select *from tbl_messPakage where name like @Name+'%'", parm);
        }

        public DataTable searchallItems(string ItemName)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@ItemName",ItemName)
            };
            return DAL.getuser("select *from tbl_items where item_name like @ItemName +'%'", parm);
        }

        public  int insertintomessPakage(string name, decimal price, string details) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@price",price),
                new SqlParameter("@details",details)
            };
            return DAL.IDU("insert into tbl_messPakage values(@name,@price,@details)", parm);
            
        }
        public int insertintoBreakfast(string itemname, string day, string pakage_name) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@itemname",itemname),
                new SqlParameter("@day",day),
                new SqlParameter("@pakage_name",pakage_name),
               
            };
            return DAL.IDU("insert into tbl_breakfast values(@itemname,@day,@pakage_name)", parm);

        }

        public int insertintoLunch(string itemname, string day, string pakage_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@itemname",itemname),
                new SqlParameter("@day",day),
                new SqlParameter("@pakage_name",pakage_name),

            };
            return DAL.IDU("insert into tbl_Lunch values(@itemname,@day,@pakage_name)", parm);

        }

        public int insertintosnacks(string itemname, string day, string pakage_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@itemname",itemname),
                new SqlParameter("@day",day),
                new SqlParameter("@pakage_name",pakage_name),

            };
            return DAL.IDU("insert into tbl_snacks values(@itemname,@day,@pakage_name)", parm);

        }
        public int insertintoDinner(string itemname, string day, string pakage_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@itemname",itemname),
                new SqlParameter("@day",day),
                new SqlParameter("@pakage_name",pakage_name),

            };
            return DAL.IDU("insert into tbl_Dinner values(@itemname,@day,@pakage_name)", parm);

        }
        public DataTable getPakageNameFromCustomer(String id) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id), };
            return DAL.getuser("select pakage_name from tbl_customerDetailnyo where id = @id",parm);
        }
       



    }
}
