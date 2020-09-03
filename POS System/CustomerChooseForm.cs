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


namespace POS_System
{
    public partial class CustomerChooseForm : Form
    {
        public CustomerChooseForm()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo custor = new blllCustomerDetailednyo();
        BLLOrder blod = new BLLOrder();
        private void CustomerChooseForm_Load(object sender, EventArgs e)
        {
            //Customers();

        }
        //public void Customers() {
        //    dataGridView1.Rows.Clear();
        //    DataTable dtrecentimages = custor.getallcustomersrecent();
        //        for (int i = 0; i < dtrecentimages.Rows.Count; i++) {
        //        dataGridView1.Rows.Add(dtrecentimages.Rows[i]["id"].ToString(), dtrecentimages.Rows[i]["name"].ToString(), dtrecentimages.Rows[i]["lastname"].ToString(), dtrecentimages.Rows[i]["phone"].ToString());
        //    }
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (txt_namesearch.Text == "" || txt_lastnamesearch.Text == "")
            {
                MessageBox.Show("Input the Seach Fieds..");

            }
            else
            {


                DataTable searchdata = custor.getDataByitsusername(txt_namesearch.Text, txt_lastnamesearch.Text);
                dataGridView1.Rows.Clear();

                for (int i = 0; i < searchdata.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(searchdata.Rows[i]["id"].ToString(), searchdata.Rows[i]["name"].ToString(), searchdata.Rows[i]["lastname"].ToString(), searchdata.Rows[i]["phone"].ToString());
                }
            }
        }

        private void txt_fone_TextChanged(object sender, EventArgs e)
        {
            if (txt_fone.Text.Length > 0)
            {


                DataTable searchdata = custor.getDataByitsPhonenumbers(txt_fone.Text);
                dataGridView1.Rows.Clear();

                for (int i = 0; i < searchdata.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(searchdata.Rows[i]["id"].ToString(), searchdata.Rows[i]["name"].ToString(), searchdata.Rows[i]["lastname"].ToString(), searchdata.Rows[i]["phone"].ToString());
                }
            }
            else {
                //Customers();
            }
        }

        private void txt_emailsearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_emailsearch.Text.Length > 0)
            {

                DataTable searchdata = custor.getDataByitsemails(txt_emailsearch.Text);
                dataGridView1.Rows.Clear();

                for (int i = 0; i < searchdata.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(searchdata.Rows[i]["id"].ToString(), searchdata.Rows[i]["name"].ToString(), searchdata.Rows[i]["lastname"].ToString(), searchdata.Rows[i]["phone"].ToString());
                }
            }
            else {

                //Customers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_namesearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_namesearch.Text == "")
            {
                //Customers();
            }
        }

        public string name = "";
        public string Lastname = "";
        public string phoneno = "";
        public string table_no;

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_select"].Index && e.RowIndex >= 0)
            {
                //name = dataGridView1.CurrentRow.Cells["colName"].Value.ToString();
                //Lastname = dataGridView1.CurrentRow.Cells["colLastname"].Value.ToString();
                //phoneno = dataGridView1.CurrentRow.Cells["colphone"].Value.ToString();
                //table_no = KOTOrder.table_no_for_user;
                //DataTable dt = blod.getalldata(Convert.ToDecimal(table_no));
                //if (dt.Rows.Count > 0)
                //{
                //    int update_user_in_kot = blod.update_table_for_customer(Convert.ToDecimal(table_no), name, phoneno);
                //}
                //this.DialogResult = DialogResult.OK;

               
            }
        }
    }
}
