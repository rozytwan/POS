﻿using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Loyality
{
    public partial class Loyality_Amount : UserControl
    {
        public Loyality_Amount()
        {
            InitializeComponent();
        }
        BLLLoyalty blll = new BLLLoyalty();
        private void Loyality_Amount_Load(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            DataGridViewLoad();
        }
        public void DataGridViewLoad()
        {
            DataTable dt = blll.GetLoyalityAmount();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["col_from"].Value = dt.Rows[i]["amount_from"].ToString();
                    dataGridView1.Rows[i].Cells["col_to"].Value = dt.Rows[i]["amount_to"].ToString();
                    dataGridView1.Rows[i].Cells["col_points"].Value = dt.Rows[i]["points"].ToString();
                    dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                }
            }
            dataGridView1.ClearSelection();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
          int save = blll.Insert_LoyalityAmount(Convert.ToDecimal(txt_from.Text), Convert.ToDecimal(txt_to.Text), Convert.ToInt32(txt_points.Text), status);
            if (save>0)
            {
                MessageBox.Show("Inserted Successfully !!", "Success Alert !!");
                Clear();
            }
            DataGridViewLoad();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (status == null)
            {
                status = "True";
            }
            int update = blll.Update_LoyalityAmount(id,Convert.ToDecimal(txt_from.Text), Convert.ToDecimal(txt_to.Text), Convert.ToInt32(txt_points.Text),status);
            if (update > 0)
            {
                MessageBox.Show("Updated Successfully !!", "Success Alert !!");
                Clear();
            }
            DataGridViewLoad();
        }
        public void Clear()
        {
            txt_from.Text = "";
            txt_to.Text = "";
            txt_points.Text = "";
            rbn_true.Checked = true;
        }
        public int id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                     id = Convert.ToInt32(dr.Cells["col_id"].Value);
                    DataTable dt = blll.GetLoyalityAmountId(id);
                    if (dt.Rows.Count > 0)
                    {
                        txt_from.Text = dt.Rows[0]["amount_from"].ToString();
                        txt_to.Text = dt.Rows[0]["amount_to"].ToString();
                        txt_points.Text = dt.Rows[0]["points"].ToString();
                        if (dt.Rows[0]["status"].ToString()== "True")
                        {
                            rbn_true.Checked = true;
                        }
                        else
                        {
                            rbn_false.Checked = false;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void txt_from_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_to_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_points_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        string status;
        private void rbn_true_Click(object sender, EventArgs e)
        {
            rbn_true.Checked = true;
            status = "True";
        }

        private void rbn_false_Click(object sender, EventArgs e)
        {
            rbn_false.Checked = true;
            status = "False";
        }
    }
}
