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
    public partial class HotelComplementrySales : UserControl
    {
        public HotelComplementrySales()
        {
            InitializeComponent();
        }
        BLLComplementry bllcom = new BLLComplementry();
        BLLUser blu = new BLLUser();
        public void Category_name()
        {
            DataTable dt = bllcom.GetCategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "category_name";

            }
        }
        public void Item_Name()
        {
            DataTable dt = bllcom.GetComplementryitem();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "item_name";

            }
        }
        public void Complementry_User()
        {
            DataTable dt = bllcom.GetUser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["com_user"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "com_user";

            }
        }
        public void Complementry_Customer()
        {
            DataTable dt = bllcom.GetCustomer();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["customer_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "customer_name";

            }
        }
        private void HotelComplementrySales_Load(object sender, EventArgs e)
        {
            backpanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
        }
        public void grandtotal()
        {
            decimal qty = 0;
            decimal cost = 0;
            decimal total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    qty += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_quantity"].Value.ToString());
                    cost += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_cost"].Value.ToString());
                    total += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_total"].Value.ToString());

                }
                lbl_cost.Text = cost.ToString();
                lbl_qty.Text = qty.ToString();
                lbl_total.Text = total.ToString();
            }

        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
                string dateOne = Convert.ToDateTime(dtp_from.Text).ToShortDateString();
                string datetwo = Convert.ToDateTime(dtp_to.Text).ToShortDateString();


                if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable dt = bllcom.GetHotelCategoryComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();

                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "Item Name")
                {
                    DataTable dt = bllcom.GetHotelItemComplementrysales((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "Complementry Customer")
                {
                    DataTable dt = bllcom.GetHotelCustomerComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "Cashier Complementry")
                {
                    DataTable dt = bllcom.GetHotelCashierComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "ALL")
                {
                    DataTable dt = bllcom.GetAllHotelComplementrysales(Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();
                            // dataGridView1.Rows[er].Cells["col_bill_no"].Value = dt.Rows[er]["bill_no"].ToString();
                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                            qty += Convert.ToDecimal(qty);
                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Can't find " + txt_searchText.Text + " from " + dtp_from.Text + " To" + dtp_to.Text);
                    }

                }
                grandtotal();
            }

        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Category")
            {
                Category_name();
            }
            else if (cbo_searchTYpe.Text == "Item Name")
            {

                Item_Name();
            }
            else if (cbo_searchTYpe.Text == "Complementry Customer")
            {
                Complementry_Customer();
            }
            else if (cbo_searchTYpe.Text == "Cashier Complementry")
            {
                Complementry_User();
            }
            else if (cbo_searchTYpe.Text == "ALL")
            {
                txt_searchText.Text = "ALL";
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
