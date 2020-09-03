using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DOA;


namespace BLLS
{
   public class BLLSupplier_details
    {
        public int InsertIntoSupplierDetails(string title, string name,string adress ,string phone, string mobile,string email, string city, string ecc_no, string cst_no, string pan_no,string iban, string account_no, string bank, string remarks)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                     
                       new SqlParameter("@title",title),
                        new SqlParameter("@name",name),
                          new SqlParameter("@adress",adress),
                           new SqlParameter("@phone",phone),
                            new SqlParameter("@mobile",mobile),
                              new SqlParameter("@email",email),
                               new SqlParameter("@city",city),
                               new SqlParameter("@ecc_no",ecc_no),
                                new SqlParameter("@cst_no",cst_no),
                                  new SqlParameter("@pan_no",pan_no),
                                   new SqlParameter("@iban",iban),
                                    new SqlParameter("@account_no",account_no),
                                     new SqlParameter("@bank",bank),
                                      new SqlParameter("@remarks",remarks)

                };
            //inserting into suppliers details table by parameter

            return DAL.IDU("insert into tbl_supplier_details(title,name,adress,phone,mobile,email,city,ecc_no,cst_no,pan_no,iban,account_no,bank,remarks) values(@title, @name, @adress ,@phone, @mobile,@email, @city,@ecc_no, @cst_no,@pan_no,@iban,@account_no,@bank,@remarks)", parm);
        }

        public DataTable Fectching_All_Table_data()
        {
            DataTable dt = new DataTable();
            return DAL.getuser("select * from tbl_supplier_details", null);
        }
        public DataTable Fectching_id()
        {
            DataTable dt = new DataTable();
            return DAL.getuser("select new_supplier_id from tbl_supplier_details order by  new_supplier_id desc", null);
        }


        public int UpdateIntoSupplierDetail(int sup_id, string title, string name, string adress, string phone, string mobile, string email, string city, string iban, string account_no, string bank, string remarks, string ecc_no, string cst_no, string pan_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                      new SqlParameter("@sup_id",sup_id),
                       new SqlParameter("@title",title),
                        new SqlParameter("@name",name),

                          new SqlParameter("@adress",adress),
                           new SqlParameter("@phone",phone),
                            new SqlParameter("@mobile",mobile),

                              new SqlParameter("@email",email),
                               new SqlParameter("@city",city),
                                new SqlParameter("@iban",iban),
                                 new SqlParameter("@account",account_no),
                                  new SqlParameter("@bank",bank),
                                   new SqlParameter("@remarks",remarks),
                               new SqlParameter("@ecc_no",ecc_no),
                                new SqlParameter("@cst_no",cst_no),

                                        new SqlParameter("@pan_no",pan_no)

                };
            //inserting into suppliers details table by parameter

            return DAL.IDU("update tbl_supplier_details set title=@title, name=@name, adress=@adress ,phone=@phone, mobile=@mobile,email=@email, city=@city,iban=@iban,account_no=@account,bank=@bank,remarks=@remarks,ecc_no=@ecc_no, cst_no=@cst_no,pan_no= @pan_no where sup_id = @sup_id", parm);
        }

        public DataTable GetSupplierbyname(string name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@name", name)
            };
            return DAL.getuser("Select * from tbl_supplier_details where name like '%' + @name + '%'", parm);
        }
        public int Deletesupplier(int sup_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@sup_id", sup_id)
            };
            return DAL.IDU("Delete from tbl_supplier_details where sup_id = @sup_id", parm);
        }
        public DataTable Getsupplierbyid(int sup_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@sup_id", sup_id)
            };
            return DAL.getuser("select * from tbl_supplier_details where sup_id = @sup_id", parm);
        }
    }
}
