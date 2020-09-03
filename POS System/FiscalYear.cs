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
    public partial class FiscalYear : Form
    {
        public FiscalYear()
        {
            InitializeComponent();
        }
        BLL_Fiscal blfs = new BLL_Fiscal();
        BLLRestSell blres = new BLLRestSell();
     
        public void FiscalYear_Load(object sender, EventArgs e)
        {
            datagridviewload();
        }
        public void datagridviewload()
        {
            DataTable dt = blfs.get_all_data_from_fiscal_year();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int abc = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["fiscal_id"].ToString();
                    dataGridView1.Rows[i].Cells["cal_fiscal_year_start"].Value = dt.Rows[i]["fiscal_year_start"].ToString();
                    dataGridView1.Rows[i].Cells["cal_fiscal_year_to_date"].Value = dt.Rows[i]["fiscal_year_end"].ToString();
                    dataGridView1.Rows[i].Cells["cal_is_active"].Value = dt.Rows[i]["is_active"].ToString();
                }
            }
        }

        private void btn_end_fiscal_year_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want End This Fiscal Year", "End Fiscal Year", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int end_fiscal = blfs.update_fiscal_year();
                if(end_fiscal>0)
                {
                    int bill = blres.truncate_bill_no();
                    datagridviewload();
                }
            }
        }
        public static int id;
        private void btn_new_fiscal_year_Click(object sender, EventArgs e)
        {
            FiscalYearAdd fya = new FiscalYearAdd();
            fya.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());
            FiscalYearAdd fya = new FiscalYearAdd();
           // fya.id = id;
            fya.Show();
        }
            
    }
}
