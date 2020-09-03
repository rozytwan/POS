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
    public partial class PakageNameSet : Form
    {
        public PakageNameSet()
        {
            InitializeComponent();
        }
        bll_customer_mess Bllmess = new bll_customer_mess();

        private void PakageNameSet_Load(object sender, EventArgs e)
        {
            getallPakages();
        }

        public void getallPakages() {
            dataGridView1.Rows.Clear();
            DataTable dtst = Bllmess.getallPakagesLists();
            if (dtst.Rows.Count>0) {
                for (int i = 0; i < dtst.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add("",dtst.Rows[i]["pg_id"].ToString(), dtst.Rows[i]["name"].ToString(), dtst.Rows[i]["price"].ToString(), dtst.Rows[i]["details"].ToString());
                }
            }

        }

       
        public String pakageName = "";
        private void btn_save_Click(object sender, EventArgs e)
        {
            decimal a;
            if (txt_pakagename.Text == "" || txt_pakageDetails.Text == "" || txt_price.Text == "")
            {
                MessageBox.Show("Please Fill Requird inputs.");

            }
            else if (!decimal.TryParse(txt_price.Text, out a))
            {
                MessageBox.Show("Price Name must be Numeric.");
            }
            else

            {
                DataTable getPakageName = Bllmess.CheckExistedPakagename(txt_pakagename.Text);
                if (getPakageName.Rows.Count > 0)
                {
                    MessageBox.Show("Pakage Name Already Exists");
                }
                else
                {
                    int pakages = Bllmess.insertintomessPakage(txt_pakagename.Text, Convert.ToDecimal(txt_price.Text), txt_pakageDetails.Text);
                    if (pakages > 0)
                    {
                        pakageName = txt_pakagename.Text;
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Pakage Created");
                        getallPakages();
                        this.Hide();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colSelect"].Index && e.RowIndex >= 0) {

                pakageName = dataGridView1.CurrentRow.Cells["colName"].Value.ToString();
                this.Hide();
                this.DialogResult = DialogResult.OK;
            }
            else if (e.ColumnIndex==dataGridView1.Columns["coldelete"].Index && e.RowIndex >=0) {
                DialogResult dialog = MessageBox.Show(" Customer associated With this Package will be Deleted too. "+"\n"+"Are you sure want to delete selected Package? ", "Deleting pakage", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {

                    int delete = Bllmess.deletepakages(Convert.ToInt32(dataGridView1.CurrentRow.Cells["colid"].Value.ToString()));
                    if (delete > 0)
                    {
                        bll_breakfast bllbrk = new bll_breakfast();
                        bllbrk.deletebypackaeNamefrombreakfast(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllbrk.deletebypackaeNamefromDinner(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllbrk.deletebypackaeNamefromlunch(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllbrk.deletebypackaeNamefromsnacks(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        //*************
                        Bll_mess_dailyrecord bllmessdaily = new Bll_mess_dailyrecord();
                        bllmessdaily.deletebypackaeNamefrombreakfastdaily(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllmessdaily.deletebypackaeNamefromDinnerdaily(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllmessdaily.deletebypackaeNamefromlunchdaily(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());
                        bllmessdaily.deletebypackaeNamefromsnacksdaily(dataGridView1.CurrentRow.Cells["colName"].Value.ToString());

                        //************
                        MessageBox.Show("Successfully Deleted");
                        getallPakages();
                    }
                }
                else if(dialog==DialogResult.No) {
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_noofdays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
