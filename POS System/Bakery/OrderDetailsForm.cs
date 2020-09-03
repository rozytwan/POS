using BLLS.bakery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Bakery
{
    public partial class OrderDetailsForm : Form
    {
        public OrderDetailsForm(int kotId,string serviceType)
        {
            InitializeComponent();
            kot_id = kotId;
            service_type = serviceType;
        }
        int kot_id;
        string service_type;
        string payment_mode="Cash";
        int orderDetailsId = 0;
        BllBakeryOrder blbo = new BllBakeryOrder();
        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            cbo_coating_type.SelectedIndex = 0;
            cbo_from_hours.SelectedIndex = 0;
            cbo_minuts_from.SelectedIndex = 0;
            DataTable dtc = blbo.GetAllDataFromOrderDetails(kot_id.ToString(), service_type);
            if (dtc.Rows.Count > 0)
            {
                txt_shape.Text = dtc.Rows[0]["shape"].ToString();
                txt_note.Text = dtc.Rows[0]["note"].ToString();
                txt_message.Text = dtc.Rows[0]["message"].ToString();
                cbo_coating_type.Text = dtc.Rows[0]["coating_type"].ToString();
                txt_advance_amount.Text = dtc.Rows[0]["advance_amount"].ToString();
                dtp_date.Text = dtc.Rows[0]["receving_time"].ToString();
                cbo_from_hours.Text =Convert.ToDateTime(dtc.Rows[0]["receving_time"]).Hour.ToString();
                cbo_minuts_from.Text = Convert.ToDateTime(dtc.Rows[0]["receving_time"]).Minute.ToString();
                orderDetailsId= Convert.ToInt32(dtc.Rows[0]["order_details_id"]);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {

            if (kot_id > 0 && service_type != "")
            {
                if (orderDetailsId > 0)
                {
                    int updateBakeryOrder = blbo.UpdateBakeryorderDetails(txt_shape.Text, Convert.ToDateTime(dtp_date.Text + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text), txt_message.Text, txt_note.Text, cbo_coating_type.Text, payment_mode, Convert.ToDecimal(txt_advance_amount.Text), orderDetailsId);
                }
                else
                {
                    int insertOrder = blbo.insertBakeryorderDetails(txt_shape.Text, Convert.ToDateTime(dtp_date.Text + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text), txt_message.Text, txt_note.Text, cbo_coating_type.Text, payment_mode, Convert.ToDecimal(txt_advance_amount.Text), kot_id, service_type);
                }
                this.Hide();
            }
        }

        private void rbtn_Cash_CheckedChanged(object sender, EventArgs e)
        {
            payment_mode = "Cash";
        }

        private void rbtn_card_CheckedChanged(object sender, EventArgs e)
        {
            payment_mode = "Card";
        }
       
        private void btn_print_and_save_Click(object sender, EventArgs e)
        {
            if (kot_id > 0 && service_type != "")
            {
                BakeryKOTPrinting80.shape = txt_shape.Text;
                BakeryKOTPrinting80.receving_time = dtp_date.Text + ":" + cbo_from_hours.Text + ":" + cbo_minuts_from.Text;
                BakeryKOTPrinting80.Message = txt_message.Text;
                BakeryKOTPrinting80.Coating = cbo_coating_type.Text;
                BakeryKOTPrinting80.advance_amount = txt_advance_amount.Text;
                BakeryKOTPrinting80.note_pad = txt_note.Text;
                BakeryKOTPrinting80.payment_mode = payment_mode;
                if (orderDetailsId > 0)
                {
                    int updateBakeryOrder = blbo.UpdateBakeryorderDetails(txt_shape.Text, Convert.ToDateTime(dtp_date.Text + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text), txt_message.Text, txt_note.Text, cbo_coating_type.Text, payment_mode, Convert.ToDecimal(txt_advance_amount.Text), orderDetailsId);

                }
                else
                {
                    int insertOrder = blbo.insertBakeryorderDetails(txt_shape.Text, Convert.ToDateTime(dtp_date.Text + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text), txt_message.Text, txt_note.Text, cbo_coating_type.Text, payment_mode, Convert.ToDecimal(txt_advance_amount.Text), kot_id, service_type);
                    if (insertOrder > 0)
                    {
                        this.Hide();
                    }
                }
             
            }
          
        }

        private void txt_advance_amount_Leave(object sender, EventArgs e)
        {
            if (txt_advance_amount.Text == "")
            {
                txt_advance_amount.Text = "0.00";
            }
        }

        private void txt_advance_amount_Enter(object sender, EventArgs e)
        {
            if (txt_advance_amount.Text == "0.00")
            {
                txt_advance_amount.Text = "";
            }
        }

        private void txt_advance_amount_KeyPress(object sender, KeyPressEventArgs e)
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
