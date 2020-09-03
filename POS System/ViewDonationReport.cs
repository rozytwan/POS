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
    public partial class ViewDonationReport : UserControl
    {
        public ViewDonationReport()
        {
            InitializeComponent();
        }
        BLL_donation blld = new BLL_donation();
        private void ViewDonationReport_Load(object sender, EventArgs e)
        {
            // DatagridViewLoad();
            cbo_searchTYpe.SelectedIndex = 0;
            backpanel.Hide();
            searchPanel.Show();
        }
        public void CustomerName()
        {
            DataTable dt = blld.GetCustomer();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "name";
            }
        }
        public void grandtotalCalculation()
        {
            lbl_amount.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["col_amount"].Value))).ToString();
        }

        public void DatagridViewLoad()
        {
            DataTable dt = blld.GetDonations();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sd = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_event_id"].Value = dt.Rows[i]["event_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_payment"].Value = dt.Rows[i]["payment_mode"].ToString();
                    dataGridView1.Rows[i].Cells["col_amount"].Value = dt.Rows[i]["donation_amount"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                }
                backpanel.Show();
                searchPanel.Hide();
                grandtotalCalculation();
            }

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == ""||txt_searchText.Text=="Choose One")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
            else
            {
                if (cbo_searchTYpe.Text == "Customer")
                {
                    DataTable dt = blld.GetDonationByCustomer(txt_searchText.Text, Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int sd = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_event_id"].Value = dt.Rows[i]["event_id"].ToString();
                            dataGridView1.Rows[i].Cells["col_payment"].Value = dt.Rows[i]["payment_mode"].ToString();
                            dataGridView1.Rows[i].Cells["col_amount"].Value = dt.Rows[i]["donation_amount"].ToString();
                            dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                        grandtotalCalculation();
                    }
                    else
                    {
                        MessageBox.Show("No Record Available Alert !!", "No Record Alert !!");
                    }

                }
                else if (cbo_searchTYpe.Text == "Payment Mode")
                {
                    DataTable dt = blld.GetDonationByPayment(txt_searchText.Text, Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int sd = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_event_id"].Value = dt.Rows[i]["event_id"].ToString();
                            dataGridView1.Rows[i].Cells["col_payment"].Value = dt.Rows[i]["payment_mode"].ToString();
                            dataGridView1.Rows[i].Cells["col_amount"].Value = dt.Rows[i]["donation_amount"].ToString();
                            dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                        grandtotalCalculation();
                    }
                    else
                    {
                        MessageBox.Show("No Record Available Alert !!", "No Record Alert !!");
                    }

                }
                else if (cbo_searchTYpe.Text == "All")
                {
                    DatagridViewLoad();
                }
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {

        }
        public void clearcombo(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is ComboBox)
                    ((ComboBox)c).ResetText();
                else
                    clearcombo(c);
            }
        }
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cbo_searchTYpe.Text == "Customer")
            {

                CustomerName();
            }
            else if (cbo_searchTYpe.Text == "Payment Mode")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("Cash");
                mylist.Add("Card");
                mylist.Add("Credit");
                txt_searchText.DataSource = mylist;
            }
           else if (cbo_searchTYpe.Text == "All")
            {
                txt_searchText.Text = "All";
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backpanel.Hide();
            searchPanel.Show();
        }
    }
}
