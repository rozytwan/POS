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
    public partial class FonePay : Form
    {
        public FonePay()
        {
            InitializeComponent();
        }
        BLLFonePay blfp = new BLLFonePay();
        int id;
        private void FonePay_Load(object sender, EventArgs e)
        {
            DataTable dt = blfp.getALLFonePayData();
            if (dt.Rows.Count > 0)
            {
                txt_userName.Text = dt.Rows[0]["user_name"].ToString();
                txt_merchantCode.Text = dt.Rows[0]["merchant_code"].ToString();
                txt_secret_key.Text = dt.Rows[0]["secret_key"].ToString();
                id=Convert.ToInt32(dt.Rows[0]["id"].ToString());
            }
            if (id > 0)
            {
                btn_save.Text = "Update";
            }
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (btn_save.Text == "Save")
            {
                if (txt_userName.Text == "" && txt_secret_key.Text == "" && txt_password.Text == "" && txt_merchantCode.Text == "")
                {
                    MessageBox.Show("Please fill all text box.", "Empty Text Box", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    int insertData = blfp.FonePayInsert(txt_userName.Text, Encryption.StringEncryption.Encrypt(txt_password.Text, "sblw-3hn8-sqoy19"), txt_merchantCode.Text, txt_secret_key.Text);
                }
            }
            else
            {
                if (id > 0)
                {
                    int updateData = blfp.FonePayUpdate(txt_userName.Text, Encryption.StringEncryption.Encrypt(txt_password.Text, "sblw-3hn8-sqoy19") ,txt_merchantCode.Text, txt_secret_key.Text,id);
                }
            }
        }

       
    }
}
