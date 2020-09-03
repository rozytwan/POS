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
   public class BLL_donation
    {
        public int InsertDonation( string title, string remark, decimal amount, string organizer, string status,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@title",title),
                 new SqlParameter("@remark",remark),
                  new SqlParameter("@amount",amount),
                   new SqlParameter("@organizer",organizer),
                   new SqlParameter("@status",status),
                    new SqlParameter("@date",date)

            };
            return DAL.IDU("insert into tbl_donation_program (title,remarks,amount,organizer,status,date)values (@title,@remark,@amount,@organizer,@status,@date)", parm);
        }
        public int UpdateDonation(int id,string title, string remark, decimal amount, string organizer, string status, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 new SqlParameter("@id",id),
                new SqlParameter("@title",title),
                 new SqlParameter("@remark",remark),
                  new SqlParameter("@amount",amount),
                   new SqlParameter("@organizer",organizer),
                   new SqlParameter("@status",status),
                    new SqlParameter("@date",date)

            };
            return DAL.IDU("Update tbl_donation_program set title=@title,remarks=@remark,amount=@amount,organizer=@organizer,status=@status,date=@date where donation_id=@id", parm);
        }
        public DataTable GetDonation()
        {
            return DAL.getuser("select * from tbl_donation_program order by date", null);
        }
        public int DeleteDonation(int id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),
             
            };
            return DAL.IDU("update tbl_donation_program set status='false' where donation_id=@id", parm);
        }
        public DataTable SeleteDonation(int id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),

            };
            return DAL.getuser("select * from tbl_donation_program where donation_id=@id", parm);
        }
        public int insertDonationAmount(int customer_id, int event_id, string payment_mode, string donation_amount, DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@event_id",event_id),
                 new SqlParameter("@customer_id",customer_id),
                  new SqlParameter("@payment_mode",payment_mode),
                   new SqlParameter("@donation_amount",donation_amount),
                   new SqlParameter("@date",date)
            };
            return DAL.IDU("insert into tbl_donation (customer_id,event_id,payment_mode,donation_amount,date) values (@customer_id,@event_id,@payment_mode,@donation_amount,@date)",parm);
        }
        public DataTable GetDonationByPayment(string payment, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@payment",payment),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select d.id,c.id,name+' '+lastname as name,event_id,payment_mode,date,donation_amount from tbl_donation d inner join tbl_customerDetailnyo c on d.customer_id=c.id where payment_mode=@payment and cast(date as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetDonationByCustomer(string name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@name",name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select d.id,c.id,name+' '+lastname as name,event_id,payment_mode,date,donation_amount from tbl_donation d inner join tbl_customerDetailnyo c on d.customer_id=c.id where name+' '+lastname=@name and cast(date as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetDonations()
        {
            return DAL.getuser("select d.id,c.id,name+' '+lastname as name,event_id,payment_mode,date,donation_amount from tbl_donation d inner join tbl_customerDetailnyo c on d.customer_id=c.id", null);
        }
        public DataTable GetCustomer()
        {
            return DAL.getuser("select distinct(name+' '+lastname)as name from tbl_customerDetailnyo", null);
        }
    }
}
