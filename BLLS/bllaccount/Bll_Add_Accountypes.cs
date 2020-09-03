using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data.SqlClient;
using System.Data;

namespace BLLS
{
   public class Bll_Add_Accountypes
    {

        public DataTable Getalldata() {

            return DAL.getuser("Select * from tbl_accounting_accounttype order by name asc", null);

        }

        public DataTable getdatabyName(string accountname) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@accountname",accountname)
            };
            return DAL.getuser("select type from tbl_accounting_accounttype where name= @accountname", parm);
        }
        public DataTable SearchNames(string search)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@search",search)
            };

            return DAL.getuser("Select * from tbl_accounting_accounttype where name like  '%'+ @search + '%'", parm);

        }

        public int insertIntoactypes( string name,string description, string accounttype,string radio,string dr_cr)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@description",description),
                  new SqlParameter("@accounttype",accounttype),
                  new SqlParameter("@radio",radio),
                  new SqlParameter("@dr_cr",dr_cr)
            };
            return DAL.IDU("insert into tbl_accounting_accounttype values (@name,@description,@accounttype,@radio,@dr_cr)", parm);

        }

        public int deletefromtable(int idpass) {
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@idpass",idpass)
            };
            return DAL.IDU("Delete from tbl_accounting_accounttype where ac_id =@idpass", parm);

        }
    }
}
