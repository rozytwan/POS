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
    public partial class InhoueseUnit : UserControl
    {
        public InhoueseUnit()
        {
            InitializeComponent();
        }
        string measure_type;
        BLLInhouse_Unit blihu = new BLLInhouse_Unit();
        int inhouse_unit_id;
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_unit_name.Text != "")
            {
                DataTable dt = blihu.get_unit_name(txt_unit_name.Text, measure_type);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This InHouse Unit Is Already Exists..");
                }
                else
                {
                    int insert_ihhouse = blihu.insert_inhouse_unit(txt_unit_name.Text, measure_type);
                    data_grid_load();
                    txt_unit_name.Text = "";
                }

            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                measure_type = "Weight";
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                measure_type = "Volumn";
            }
        }

        private void InHouseUnit_Load(object sender, EventArgs e)
        {
            measure_type = "Weight";
            data_grid_load();
            btn_update.Hide();
        }
        public void data_grid_load()
        {
            DataTable dt = blihu.get_all_data();
            dataGridView1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
               
                for (int i = 0; dt.Rows.Count > i; i++)
                {
                    int abc = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["cal_unit_name"].Value = dt.Rows[i]["unit_name"].ToString();
                    dataGridView1.Rows[i].Cells["cal_measure_type"].Value = dt.Rows[i]["measure_type"].ToString();
                    dataGridView1.Rows[i].Cells["cal_inhouse_unit_id"].Value = dt.Rows[i]["inhouse_unit_id"].ToString();
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_unit_name.Text != "")
            {

                int update_inhouse = blihu.update_inhouse(txt_unit_name.Text, measure_type, inhouse_unit_id);
                if (update_inhouse > 0)
                {
                    MessageBox.Show("InHouse Unit Has Been Update");
                    data_grid_load();
                    txt_unit_name.Text = "";

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_edit"].Index && e.RowIndex >= 0)
            {
                btnadd.Hide();
                btn_update.Show();
                txt_unit_name.Text = dataGridView1.CurrentRow.Cells["cal_unit_name"].Value.ToString();
                string measure_type = dataGridView1.CurrentRow.Cells["cal_measure_type"].Value.ToString();
                inhouse_unit_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_inhouse_unit_id"].Value.ToString());
                if (measure_type == "Weight")
                {
                    radioButton1.Checked = true;
                    measure_type = "Weight";
                }
                else
                {
                    radioButton2.Checked = false;
                    measure_type = "Volumn";
                }

            }
            else if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            {
                inhouse_unit_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_inhouse_unit_id"].Value.ToString());
                int delete_unit = blihu.delete_inhouse_unit(inhouse_unit_id);
                if (delete_unit > 0)
                {
                    MessageBox.Show("InHouse Unit Has Been Delete");
                    data_grid_load();
                }
            }
            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {
                Control ctls = this.Parent;
                allmenu als = new allmenu();
                ctls.Controls.Clear();
                ctls.Controls.Add(als);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
