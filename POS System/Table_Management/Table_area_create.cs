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

namespace POS_System.Table_Management
{
    public partial class Table_area_create : Form
    {
        public Table_area_create()
        {
            InitializeComponent();
        }
        BLLTable_Area blta = new BLLTable_Area();
        private void tbn_create_Click(object sender, EventArgs e)
        {
            if (txt_area_name.Text != "")
            {
                int new_a = blta.new_area_create(txt_area_name.Text);
                if (new_a > 0)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("New Area Cannnot Be Set Without Area Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
