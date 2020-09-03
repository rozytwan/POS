using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOA;


namespace BLLS
{
    public class Bll_CashwithDrawl
    {
   
        public int insertintotable(DateTime date, string name, string withdrawltype, decimal cash, string status,string remark) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date",date),
                 new SqlParameter("@name",name),
                  new SqlParameter("@withdrawltype",withdrawltype),
                   new SqlParameter("@cash",cash),
                   new SqlParameter("@status",status),
                    new SqlParameter("@remark",remark)

            };
            return DAL.IDU("insert into tbl_Counter_withdrawl (date,name,cash,withdrawl_type,status,remarks)values (@date,@name,@cash,@withdrawltype,@status,@remark)", parm);
        }

        public DataTable getalldatas(string status)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter ("@status",status)};
            return DAL.getuser("select * from tbl_Counter_withdrawl where status=@status", parm);
        }
      
        public int delete_care_of(string status)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter ("@status",status)
            };

            return DAL.IDU("delete from tbl_Counter_withdrawl where status= @status", parm);
        }
        public int bulk_data_insert()
        {
            return DAL.IDU("insert into tbl_withdrawl_log (date,name,cash,withdrawl_type,status,remarks) select date,name,cash,withdrawl_type,status,remarks from tbl_Counter_withdrawl", null);
        }
        public int delete_care_of_by_id(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter ("@id",id)};

            return DAL.IDU("delete from tbl_Counter_withdrawl where id  = @id", parm);
        }

        public int updateaftaReceivingMoneyinWithdrawl( string name, DateTime date,decimal amount, String status,String  counterman, string desc) {

            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@name",name),
                new SqlParameter("@date",date),
                new SqlParameter("@amount",amount),
                new SqlParameter("@status",status),
                new SqlParameter("@counterman",counterman),
                new SqlParameter("@desc",desc)
            };
            return DAL.IDU("insert into tbl_petty_received values (@name,@status,@amount,@counterman,@desc,@date)", parm);
        }

        public int update(int id, DateTime date, string name, string withdrawltype, decimal cash, string status, string remarks)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@id",id),
    new SqlParameter("@date",date),
    new SqlParameter("@name",name),
    new SqlParameter("@withdrawl_type",withdrawltype),
    new SqlParameter("@cash",cash),
    new SqlParameter("@status",status),
    new SqlParameter("@remarks",remarks),


            };
            return DAL.IDU("Update tbl_Counter_withdrawl set date=@date,name=@name,cash=@cash,withdrawl_type=@withdrawl_type,status=@status,remarks=@remarks where id=@id", parm);
        }
        public DataTable sum_get_care_of()
        {
            return DAL.getuser("select sum(cash) from tbl_Counter_withdrawl where status!='Hotel' ", null);
        }

        public DataTable sum_get_care_of_restaurant(string status)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter ("@status",status)
            };
            return DAL.getuser("select sum(cash) from tbl_Counter_withdrawl where status=@status", parm);
        }

    }
    }

