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
   public  class BLLInvoice
    {
       public DataTable getinvoiceno()
       {
           DataTable dt = new DataTable();
           dt=DAL.getuser("select max(invoice_no) from tbl_invoice" ,null);
           return dt;
       }

       public int createinvoice(int invoice_no, DateTime invoice_date)
       {
           SqlParameter[] parm = new SqlParameter[]
        {
            new SqlParameter("@invoice_no",invoice_no),
            new SqlParameter("@invoice_date",invoice_date)
        };
           return DAL.IDU("insert into tbl_invoice values (@invoice_no,@invoice_date)", parm);
       }
       public DataTable getsellinvoiceno()
       {
           DataTable dt = new DataTable();
           dt = DAL.getuser("select max(sellinvoice_no) from tbl_sellinvoice", null);
           return dt;
       }
    }
}
