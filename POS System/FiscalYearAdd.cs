using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class FiscalYearAdd : Form
    {
        public FiscalYearAdd()
        {
            InitializeComponent();
        }
        BLL_Fiscal bfis = new BLL_Fiscal();
        int id = FiscalYear.id;
        private void FiscalYearAdd_Load(object sender, EventArgs e)
        {
            DataTable dt = bfis.GetFiscalById(id);
            if (dt.Rows.Count>0)
            {
                txt_fixcal_year.Text = dt.Rows[0]["fiscal_year"].ToString();
                dtp_fiscal_year_from.Text = dt.Rows[0]["fiscal_year_start"].ToString();
                dtp_fiscal_year_to.Text = dt.Rows[0]["fiscal_year_end"].ToString();
            }
                
        }
        private void btn_new_fiscal_year_Click(object sender, EventArgs e)
        {
            if (txt_fixcal_year.Text == "")
            {
                MessageBox.Show("Insert Fiscal Year", "Fiscal Year Alert !!");
            }
            else
            {
                if (id > 0)
                {
                    int abc = bfis.UpdateNewFiscalYear(id, Convert.ToDateTime(dtp_fiscal_year_to.Text), txt_fixcal_year.Text, "True");
                    if (abc > 0)
                    {
                        MessageBox.Show("New Fiscal Year", "Your New Fiscal Year Has Been Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                       
                    }
                    FiscalYear.id = 0;
                    
                }
                else
                {
                    int abc = bfis.add_new_fiscal_year(Convert.ToDateTime(dtp_fiscal_year_from.Text), Convert.ToDateTime(dtp_fiscal_year_to.Text), txt_fixcal_year.Text, "True");
                    if (abc > 0)
                    {
                        MessageBox.Show("New Fiscal Year", "Your New Fiscal Year Has Been Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void txt_fixcal_year_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }

        private void dtp_fiscal_year_from_ValueChanged(object sender, EventArgs e)
        {
            NepaliDateConverter.DateConverter dp = new NepaliDateConverter.DateConverter();

            var nepalidate = dp.EngToNep(Convert.ToInt32(dtp_fiscal_year_from.Value.Year), Convert.ToInt32(dtp_fiscal_year_from.Value.Month), Convert.ToInt32(dtp_fiscal_year_from.Value.Day));
            string nyear = nepalidate.ConvertedDate.Year.ToString();
            string nday = nepalidate.ConvertedDate.Day.ToString();
            string nmonths = nepalidate.ConvertedDate.Month.ToString();
            lbl_nepali_date_from.Text = nyear + ".0" + nmonths + "." + nday;
        }

        private void dtp_fiscal_year_to_ValueChanged(object sender, EventArgs e)
        {
            NepaliDateConverter.DateConverter dp = new NepaliDateConverter.DateConverter();

            var nepalidate = dp.EngToNep(Convert.ToInt32(dtp_fiscal_year_to.Value.Year), Convert.ToInt32(dtp_fiscal_year_to.Value.Month), Convert.ToInt32(dtp_fiscal_year_to.Value.Day));
            string nyear = nepalidate.ConvertedDate.Year.ToString();
            string nday = nepalidate.ConvertedDate.Day.ToString();
            string nmonths = nepalidate.ConvertedDate.Month.ToString();
            lbl_nepali_date_to.Text = nyear + "." + nmonths + "." + nday;
        }

      
    }
}
