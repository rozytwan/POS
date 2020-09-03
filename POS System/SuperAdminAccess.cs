using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class SuperAdminAccess : Form
    {
        public SuperAdminAccess()
        {
            InitializeComponent();
        }
   
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionString = "";
      
        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = "Data Source=" + txt_server_name.Text + "; User Id=" + txtuser_id.Text + "; Password=" + txtpassword.Text + "";
                conn = new SqlConnection(connectionString);
                conn.Open();
                //sql = "EXEC sp_databases";
                sql = "Select * From sys.databases d where d.database_id>4";
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                reader.Dispose();
                conn.Close();
                conn.Dispose();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                txt_server_name.Show();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SuperAdminAccess_Load(object sender, EventArgs e)
        {
            txt_server_name.Hide();
        }
    }
}
