using BLLS;
using POS_System.FonePayApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Donation
{
    public partial class Donation : Form
    {
        public Donation()
        {
            InitializeComponent();
        }
        public static string contribution_amount="0.00";
        public static string con_payment_mode;
        public static int event_id=0;
        BLL_donation bld = new BLL_donation();
        private void Donation_Load(object sender, EventArgs e)
        {
            DonationEvent();
            lbl_remaining_amount.Text = Billing.remaning_amount;
            if (rbtn_all.Checked)
            {
                txt_contribution_amount.Text = lbl_remaining_amount.Text;
                contribution_amount = txt_contribution_amount.Text;
                con_payment_mode = "Billing";
            }
        }
        public void DonationEvent()
        {
            DataTable dt = bld.GetDonation();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["title"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_event.DataSource = dt;
                cbo_event.DisplayMember = "title";
                cbo_event.ValueMember = "donation_id";
            }
        }

        private void rbtn_phonepay_Click(object sender, EventArgs e)
        {
            if (rbtn_phonepay.Checked && txt_contribution_amount.Text != "")
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("/", "");

                QRCodeScan qrc  = new QRCodeScan();
                qrc.amount = txt_contribution_amount.Text;
                qrc.remarks2 = "Donation";
                qrc.remarks = "Contribution";
                qrc.prnNo = GuidString;
                qrc.ShowDialog();
                con_payment_mode = "FonePay";
            }
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rbtn_billing_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_billing.Checked)
            {
                con_payment_mode = "Billing";
            }


        }

        private void txt_contribution_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_contribution_amount.Text != "")
            {
                contribution_amount = txt_contribution_amount.Text;
            }
        }

        private void cbo_event_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_event.SelectedIndex > 0)
            {
                event_id = Convert.ToInt32(cbo_event.SelectedValue);
            }
        }
    }
}
