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
    public partial class Cancel_emo : Form
    {
        public Cancel_emo()
        {
            InitializeComponent();
          
        }
        public static string emo_text;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            emo_text = "Angry";
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            emo_text = "Bad";
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            emo_text = "Late";
            this.DialogResult = DialogResult.OK;
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            emo_text = txt_other_dec.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnaadd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void Cancel_emo_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }
    }
}
