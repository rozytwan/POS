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

namespace POS_System.Void
{
    public partial class VoidBill : Form
    {
        public VoidBill()
        {
            InitializeComponent();
        }
        BLLRestSell brs = new BLLRestSell();
        public string fiscal_year;
             
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_void_bill_no.Text.Length > 0 && txt_void_bill_no.Text != "")
            {
                DataTable dt_void = brs.GetBillVoid(Convert.ToInt32(txt_void_bill_no.Text));
                if (dt_void.Rows.Count > 0)
                {
                    int new_bill_no = Convert.ToInt32(dt_void.Rows[0]["new_bill_no"].ToString());
                    MessageBox.Show("This Bill No. is already void and replace with " + new_bill_no + " ", "Cannot void more than once Alert !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                 {
                    DataTable dt = brs.get_all_value_by_bill_no(txt_void_bill_no.Text, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Bill No please check your bill no.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }

            else
            {
                MessageBox.Show("Text box in empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_void_bill_no_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
