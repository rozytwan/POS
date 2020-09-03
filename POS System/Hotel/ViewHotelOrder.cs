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
    public partial class ViewHotelOrder : UserControl
    {
        public ViewHotelOrder()
        {
            InitializeComponent();
        }
        bll_orderCancel boc = new bll_orderCancel();
        private void ViewHotelOrder_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
        }
        public void loadcategorys()
        {
            DataTable getcat = boc.getallcategory();
            if (getcat.Rows.Count > 0)
            {
                DataRow dr = getcat.NewRow();
                dr["category"] = "Choose One";
                getcat.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getcat;
                txt_searchText.DisplayMember = "category";

            }

        }

        public void loadproducts()
        {
            DataTable getpro = boc.getalitems();
            if (getpro.Rows.Count > 0)
            {
                DataRow dr = getpro.NewRow();
                dr["item"] = "Choose One";
                getpro.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getpro;
                txt_searchText.DisplayMember = "item";

            }

        }
        public void loadtableno()
        {
            DataTable getno = boc.getalltableno();
            if (getno.Rows.Count > 0)
            {
                DataRow dr = getno.NewRow();
                dr["table_no"] = 0.00;
                getno.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getno;
                txt_searchText.DisplayMember = "table_no";

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

                if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable getdt = boc.getbyHotelcategoryorder(txt_searchText.Text);
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["hotel_order_id"].ToString(), getdt.Rows[i]["room_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["order_date"].ToString());


                        }

                        panel1.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }


                }
                else if (cbo_searchTYpe.Text == "Item")
                {
                    DataTable getdt = boc.getbyHotelitemsorder(txt_searchText.Text);
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["hotel_order_id"].ToString(), getdt.Rows[i]["room_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["order_date"].ToString());


                        }

                        panel1.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }


                }
           
                else if (cbo_searchTYpe.Text == "ALL")
                {

                    DataTable getdt = boc.getallHotelOrdersbydates();
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["hotel_order_id"].ToString(), getdt.Rows[i]["room_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["order_date"].ToString());
                        }

                        panel1.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }

                }
     
            }
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Item")
            {
                loadproducts();
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                loadcategorys();
            }
            //else if (cbo_searchTYpe.Text == "Table No")
            //{
            //    loadtableno();
            //}

            else if (cbo_searchTYpe.Text == "ALL")
            {

                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                List<string> li = new List<string>();
                li.Add("TS");
                li.Add("TA");
                li.Add("HD");
                txt_searchText.DataSource = li;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }
    }
}
