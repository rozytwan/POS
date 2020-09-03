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
    public partial class Table_new_insert : Form
    {
        public Table_new_insert()
        {
            InitializeComponent();
        }
        BLLTable blt = new BLLTable();
        int max_table_no;
       
        public static string table_no;
        public static bool dig_reg;
        public string table_name;
        private void Table_new_insert_Load(object sender, EventArgs e)
        {
            dig_reg = false;
            txt_area.Text = Table_create_edit.area_name;
            DataTable dt = blt.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataTable dt_max = blt.gettableno_max();
                max_table_no = (Convert.ToInt32(dt_max.Rows[0][0].ToString()) + 1);
            }
            else
            {
                max_table_no = 1;
            }
            txt_table_no.Text = max_table_no.ToString();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txt_table_no.Text != "" || txt_table_no.Text.Length <= 3 || txt_tablename.Text==null)
            {
                DataTable dt = blt.chheck_rest_table(Convert.ToInt32(txt_table_no.Text));
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This Table No Is Already Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    table_no = txt_table_no.Text;
                    table_name = txt_tablename.Text;
                    this.Close();
                    dig_reg = true;
                }
            }
            else
            {
                MessageBox.Show("Table No Cant Be Empty Or More Than 3 digit" + (Environment.NewLine) + "Table name may be empty", "Cant Create New Table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txt_table_no_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
   