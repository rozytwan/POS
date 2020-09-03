using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS.Bll_mess_days
{
    public class Bll_customerMess_record
    {

        public DataTable getallMessrecord(){

            return DAL.getuser("select *from tbl_mess_extra_rcd", null);
            
        }

        public DataTable getallMessrecordbyUserid(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };

            return DAL.getuser("select *from tbl_mess_extra_rcd where cus_id=@id", parm);

        }
        public int inserinto(string cus_id,string days,DateTime dates, string package, decimal amount, string description,string type) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@cus_id",cus_id),
                new SqlParameter("@days",days),
                new SqlParameter("@dates",dates),
                new SqlParameter("@amount",amount),
                new SqlParameter("@description",description),
                new SqlParameter("@package",package),
                new SqlParameter("@type",type)
            };

            return DAL.IDU("insert into tbl_mess_extra_rcd values(@cus_id,@days,@dates,@amount,@description,@package,@type)", parm);
        }

        public DataTable getallby(string customerid,string day,DateTime dates,string packages) {

            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@day",day),
                new SqlParameter("@dates",dates),
                new SqlParameter("@packages",packages),
           };
            return DAL.getuser("select *from tbl_mess_extra_rcd where cus_id=@customerid and day=@day and dates=@dates and package=@packages",parm);
        }
        public int updateamount(string customerid, string day, DateTime dates, string packages,decimal extraamount) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customerid",customerid),
                new SqlParameter("@day",day),
                new SqlParameter("@dates",dates),
                new SqlParameter("@packages",packages),
                new SqlParameter("@extraamount",extraamount)
           };
            return DAL.IDU("update tbl_mess_extra_rcd set amount = amount+@extraamount  where cus_id=@customerid and day=@day and dates=@dates and package=@packages",parm);
        }

    }
}
