using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using BLLS.Bll_mess_days;

namespace POS_System.Customer_Management
{
    public partial class Mess_detail_record : Form
    {
        public Mess_detail_record()
        {
            InitializeComponent();
        }
        bll_breakfast blf = new bll_breakfast();
        Bll_customerMess_record bcr = new Bll_customerMess_record();
        bll_customer_mess bcm = new bll_customer_mess();

        private void Mess_detail_record_Load(object sender, EventArgs e)
        {

        }
        decimal sumof=0;

        private void lbl_cusId_TextChanged(object sender, EventArgs e)
        {


            DataTable forbreakfast = blf.getallBreakfastsbyUserid(lbl_cusId.Text);
            if (forbreakfast.Rows.Count > 0)
            {
                for (int i = 0; i < forbreakfast.Rows.Count; i++)
                {
                    dgv_br.Rows.Add(forbreakfast.Rows[i]["customer_ID"].ToString(), forbreakfast.Rows[i]["dates"].ToString(), forbreakfast.Rows[i]["day"].ToString(), forbreakfast.Rows[i]["package_name"].ToString());
                }
            }
            DataTable forlunch = blf.getallLunchbyUserid(lbl_cusId.Text);
            if (forlunch.Rows.Count > 0)
            {
                for (int i = 0; i < forlunch.Rows.Count; i++)
                {
                    dgv_lunch.Rows.Add(forlunch.Rows[i]["customer_ID"].ToString(), forlunch.Rows[i]["dates"].ToString(), forlunch.Rows[i]["day"].ToString(), forlunch.Rows[i]["package_name"].ToString());
                }
            }
            DataTable forsnacks = blf.getallsnacksbyUserid(lbl_cusId.Text);
            if (forsnacks.Rows.Count > 0)
            {
                for (int i = 0; i < forsnacks.Rows.Count; i++)
                {
                    dgv_snacks.Rows.Add(forsnacks.Rows[i]["customer_ID"].ToString(), forsnacks.Rows[i]["dates"].ToString(), forsnacks.Rows[i]["day"].ToString(), forsnacks.Rows[i]["package_name"].ToString());
                }
            }
            DataTable forDinner = blf.getallDinnerbyUserid(lbl_cusId.Text);
            if (forDinner.Rows.Count > 0)
            {
                for (int i = 0; i < forDinner.Rows.Count; i++)
                {
                    dgv_dinner.Rows.Add(forDinner.Rows[i]["customer_ID"].ToString(), forDinner.Rows[i]["dates"].ToString(), forDinner.Rows[i]["day"].ToString(), forDinner.Rows[i]["package_name"].ToString());
                }
            }
            DataTable forextrapayales = bcr.getallMessrecordbyUserid(lbl_cusId.Text);
            if (forextrapayales.Rows.Count > 0)
            {
                for (int i = 0; i < forextrapayales.Rows.Count; i++)
                {
                    String dddt = Convert.ToDateTime(forextrapayales.Rows[i]["dates"].ToString()).ToShortDateString();
                    dgv_extras.Rows.Add(forextrapayales.Rows[i]["cus_id"].ToString(), forextrapayales.Rows[i]["package"].ToString(), dddt, forextrapayales.Rows[i]["day"].ToString(), forextrapayales.Rows[i]["description"].ToString(), forextrapayales.Rows[i]["atetime"].ToString(), forextrapayales.Rows[i]["amount"].ToString());
                }
            }
            DataTable getpacakage = bcm.CheckExistedPakagename(lbl_packages.Text);
            if (getpacakage.Rows.Count>0) {
                lbl_packageCost.Text = getpacakage.Rows[0]["price"].ToString();
            }
            addupdatagridviewcols();

           lbl_totalamount.Text = ((Convert.ToDecimal(lbl_packageCost.Text) * Convert.ToInt32(lbl_noofdays.Text)) + Convert.ToDecimal(lbl_sum.Text)).ToString();
        }

        public void addupdatagridviewcols() {

            foreach (DataGridViewRow row in dgv_extras.Rows)
            {
                sumof += Convert.ToDecimal(row.Cells["colamount"].Value.ToString());
                lbl_sum.Text = sumof.ToString();
            }
        }

        private void lbl_cusId_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_now.Text = DateTime.Now.ToLongDateString();
            lbl_time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
