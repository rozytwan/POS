using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DOA;
using System.Data.SqlClient;

namespace BLLS
{
   public class BLLAppointmentGraph
    {
        public DataTable GetAllAppointment()
        {
            return DAL.getuser("select * from tbl_customer_appointment", null);
        }
        public DataTable GetCustomer(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id)
            };
            return DAL.getuser("select * from tbl_customerDetailnyo where id=@customer_id", parm);
        
        }
        public DataTable GetAppointment(int appo_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@appo_id",appo_id)
            };
            return DAL.getuser("select ca.customer_id,c.id,c.name,ca.table_no,ca.start_time,ca.end_time,ca.reminder_time,ca.Remarks from tbl_customer_appointment ca left join tbl_customerDetailnyo c on(ca.customer_id=c.id) where appo_id=@appo_id", parm);

        }
        public int InsertAppointment(int customer_id, string table_no, DateTime start_time, DateTime end_time, string reminder, string reminder_time, string remarks,char status)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_id",customer_id),
                  new SqlParameter("@table_no",table_no),
                 new SqlParameter("@start_time",start_time),
                  new SqlParameter("@end_time",end_time),
                   new SqlParameter("@reminder",reminder),
                   new SqlParameter("@reminder_time",reminder_time),
                    new SqlParameter("@remark",remarks),
                      new SqlParameter("@status",status)
 };
            return DAL.IDU("insert into tbl_customer_appointment (customer_id,table_no,start_time,end_time,Reminder,reminder_time,remarks,status)values (@customer_id,@table_no,@start_time,@end_time,@reminder,@reminder_time,@remark,@status)", parm);
        }
        public int UpdateAppointment(int appo_id,int customer_id, string table_no, DateTime start_time, DateTime end_time, string reminder, int reminder_time, string remarks, char status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                 new SqlParameter("@appo_id",appo_id),
                       new SqlParameter("@customer_id",customer_id),
                  new SqlParameter("@table_no",table_no),
                 new SqlParameter("@start_time",start_time),
                  new SqlParameter("@end_time",end_time),
                   new SqlParameter("@reminder",reminder),
                   new SqlParameter("@reminder_time",reminder_time),
                    new SqlParameter("@remark",remarks),
                      new SqlParameter("@status",status)
            };
            return DAL.IDU("Update tbl_customer_appointment set customer_id = @customer_id, table_no = @table_no, start_time = @start_time, end_time = @end_time, Reminder = @reminder, reminder_time = @reminder_time, Remarks = @remark, status = @status where appo_id = @appo_id", parm);
        }
        public int DeleteAppointment(int appo_id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@appo_id",appo_id)
            };
            return DAL.IDU("delete from tbl_customer_appointment where appo_id=@appo_id", parm);

        }
    }
}
