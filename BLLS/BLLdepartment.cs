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
    public class BLLdepartment
    {
        public DataTable Getdepartment()
        {
            return DAL.getuser("select * from tbl_department", null);
        }
        public DataTable get_department_by_name(string department)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@department", department)
            };
            return DAL.getuser("Select * from tbl_department where department = @department", parm);
        }
        public int InsertDepartment(string department)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@department_name",department)
            };
            return DAL.IDU("Insert into tbl_department(department) values (@department_name)", parm);
        }
        public int UpdateDepartment(int id,string department)
        {
            SqlParameter[] parm = new SqlParameter[]
          {new SqlParameter("@id",id),
                new SqlParameter("@department_name",department)
           };
            return DAL.IDU("update tbl_department set department=@department_name where id=@id",parm);
        }
       public int DeleteDepartment(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {new SqlParameter("@id",id)
               
           };
            return DAL.IDU("delete from tbl_department where id=@id", parm);
        }
    }
}
