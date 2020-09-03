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

namespace POS_System.Loyality
{
    public partial class Loyality : UserControl
    {
        public Loyality()
        {
            InitializeComponent();
        }
        BLLLoyalty blll = new BLLLoyalty();
        private void Loyality_Load(object sender, EventArgs e)
        {
            DataGridViewLoad();
        }
        public void DataGridViewLoad()
        {
            DataTable dt = blll.GetLoyality();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["loyality_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_type"].Value = dt.Rows[i]["loyality_type"].ToString();
                     dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["loyality_status"].ToString();
                }
            }
            dataGridView1.ClearSelection();
        }
        public void Clear()
        {
            txt_type.Text = "";
            rbn_true.Checked = true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            int save = blll.Insert_Loyality((txt_type.Text), status);
            if (save > 0)
            {
                MessageBox.Show("Inserted Successfully !!", "Success Alert !!");
                Clear();
            }
            DataGridViewLoad();
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
                    DataTable dt = blll.GetLoyalityById(id);
                    if (dt.Rows.Count > 0)
                    {
                        txt_type.Text = dt.Rows[0]["loyality_type"].ToString();
                    
                        if (dt.Rows[0]["loyality_status"].ToString() == "True")
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
                MessageBox.Show("Please First Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (status==null)
            {
                status = "True";
            }
            int update = blll.Update_Loyality(id, (txt_type.Text), status);
            if (update > 0)
            {
                MessageBox.Show("Updated Successfully !!", "Success Alert !!");
                Clear();
            }
            DataGridViewLoad();
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

        private void rbn_true_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbn_true.Checked==true)
            //{
            //    status = "True";
            //}
        }

        private void rbn_false_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
