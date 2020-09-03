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
    public partial class DenominationList : Form
    {
        public DenominationList()
        {
            InitializeComponent();
        }
        BLLdenomination bld = new BLLdenomination();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DenominationList_Load(object sender, EventArgs e)
        {
            LoadDenomination();
            CalculateSum();
       
        }
        public void CalculateSum()
        {
            DataTable dt = bld.GetSum();
            if (dt.Rows.Count>0)
            {
                lbl_ic.Text = dt.Rows[0][0].ToString();
                lbl_thousand.Text = dt.Rows[0][1].ToString();
                lbl_fivehundred.Text = dt.Rows[0][2].ToString();
                lbl_hundred.Text = dt.Rows[0][3].ToString();
                lbl_fifty.Text = dt.Rows[0][4].ToString();
                lbl_twenty.Text = dt.Rows[0][5].ToString();
                lbl_ten.Text = dt.Rows[0][6].ToString();
                lbl_five.Text = dt.Rows[0][7].ToString();
                lbl_total.Text = dt.Rows[0][8].ToString();
            }
        }
        public void LoadDenomination()
        {
            DataTable dt = bld.GetDenomination();
         if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                
                    dataGridView1.Rows[i].Cells["col_ic"].Value = dt.Rows[i]["ic"].ToString();
                    dataGridView1.Rows[i].Cells["col_thousand"].Value = dt.Rows[i]["thousand"].ToString();

                    dataGridView1.Rows[i].Cells["col_fivehundred"].Value = dt.Rows[i]["five_hundred"].ToString();

                    dataGridView1.Rows[i].Cells["col_hundred"].Value = dt.Rows[i]["hundred"].ToString();

                    dataGridView1.Rows[i].Cells["col_fifty"].Value = dt.Rows[i]["fifty"].ToString();

                    dataGridView1.Rows[i].Cells["col_twenty"].Value = dt.Rows[i]["twenty"].ToString();

                    dataGridView1.Rows[i].Cells["col_ten"].Value = dt.Rows[i]["ten"].ToString();

                    dataGridView1.Rows[i].Cells["col_five"].Value = dt.Rows[i]["five"].ToString();

                 //   dataGridView1.Rows[i].Cells["col_two"].Value = dt.Rows[i]["two"].ToString();

                   // dataGridView1.Rows[i].Cells["col_one"].Value = dt.Rows[i]["one"].ToString();

                    dataGridView1.Rows[i].Cells["col_total"].Value = dt.Rows[i]["total"].ToString();


                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
