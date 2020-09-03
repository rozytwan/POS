using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DOA;
using System.Data;

namespace BLLS
{
    public class BLL_Tax
    {
        public int insert_into_tax(int business_id, string tax_value, decimal tax_amount, string service_charge_value, decimal service_charge_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@business_id",business_id),
                    new SqlParameter("@tax_value",tax_value),
                    new SqlParameter("@tax_amount",tax_amount),
                    new SqlParameter("@service_charge_value",service_charge_value),
                    new SqlParameter("@service_charge_amount",service_charge_amount)
                };
            return DAL.IDU("insert into tbl_business_tax (business_id,tax_value,tax_amount,service_charge_value,service_charge_amount) values(@business_id,@tax_value,@tax_amount,@service_charge_value,@service_charge_amount)", parm);
        }
        public DataTable get_all_tax_data()
        {
            return DAL.getuser("select * from tbl_business_tax", null);
        }
        public int update_table_tax(int business_id, string tax_value, decimal tax_amount, string service_charge_value, decimal service_charge_amount)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@business_id",business_id),
                    new SqlParameter("@tax_value",tax_value),
                    new SqlParameter("@tax_amount",tax_amount),
                    new SqlParameter("@service_charge_value",service_charge_value),
                    new SqlParameter("@service_charge_amount",service_charge_amount)
                };
            return DAL.IDU("update tbl_business_tax set tax_value=@tax_value,tax_amount=@tax_amount,service_charge_value=@service_charge_value,service_charge_amount=@service_charge_amount where business_id=@business_id", parm);
        }
        public DataTable Get_Tax_Service()
        {
            return DAL.getuser("select * from tbl_tax_service_access", null);
        }
        public DataTable Get_Tax_Service_ById(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@id",id),
                };
            return DAL.getuser("select * from tbl_tax_service where id=@id", parm);
        }
        public int updateuser_access(int id, string tax,string service)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                  new SqlParameter("@user_id",id),
                  new SqlParameter("@tax",tax),
                    new SqlParameter("@service",service)

                };
            return DAL.IDU("update tbl_user_access set admin=@admin,account=@account,sales=@sales,report=@report,stock=@stock,discount=@discount where user_id=@user_id", parm);
        }

    }
}
