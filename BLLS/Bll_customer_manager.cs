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
    public class Bll_customer_manager
    {
        public int insertVipCustomers(string title, string firstname, string lastname, string address, string city, string zip, string email,    DateTime DateofBirth, string phone, string license, string custometype,string states, string pics, string attatchments) {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@title",title),
                new SqlParameter("@firstname",firstname),
                new SqlParameter("@lastname",lastname),
                new SqlParameter("@address",address),
                new SqlParameter("@city",city),
                new SqlParameter("@zip",zip),
                new SqlParameter("@email",email),
                new SqlParameter("@DateofBirth",DateofBirth),
                new SqlParameter("@phone",phone),
                new SqlParameter("@license",license),
                new SqlParameter("@custometype",custometype),
                new SqlParameter("@states",states),
                new SqlParameter("@pics",pics),
                new SqlParameter("@attatchments",attatchments)
            };
            return DAL.IDU("insert into tbl_customer_mng (title,firstname,lastname,address,city,zip,email,dateofbirth,phone,license,customer_type,states,pics,attachment) values (@title,@firstname,@lastname,@address,@city,@zip,@email,@DateofBirth,@phone,@license,@custometype,@states,@pics,@attatchments)", parm);
        }
        public DataTable getallCustomerMng() {
            return DAL.getuser("select * from tbl_customer_mng",null);
        }
        public int DeleteCustomersmMng(string id) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("delete from tbl_customer_mng where Reg_customer_id=@id",parm);
        }

    }
}
