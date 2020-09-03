using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUP
{
    public partial class DatabaseBackup : Form
    {
        public DatabaseBackup()
        {
            InitializeComponent();
           
        }
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionString = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = "Data Source=" + cbo_server_name.Text + "; User Id="+txtuser_id.Text+"; Password="+txtpassword.Text+"";
                conn = new SqlConnection(connectionString);
                conn.Open();
                //sql = "EXEC sp_databases";
                sql = "Select * From sys.databases d where d.database_id>4";
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                cbo_database_name.Items.Clear();
                while (reader.Read())
                {
                    cbo_database_name.Items.Add(reader[0].ToString());
                }
                reader.Dispose();
                conn.Close();
                conn.Dispose();
                cbo_server_name.Enabled = false;
                txtpassword.Enabled = false;
                txtuser_id.Enabled = false;
                btn_connect.Enabled = false;
                btn_backup.Enabled = true;
                btn_restore.Enabled = true;
                cbo_database_name.Enabled = true;
                btn_disconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            cbo_server_name.Enabled = true;
            txtpassword.Enabled = true;
            txtuser_id.Enabled = true;
            btn_connect.Enabled = true;
            cbo_database_name.Enabled = false;
            btn_backup.Enabled = false;
            btn_restore.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_disconnect.Enabled = false;
            cbo_database_name.Enabled = false;
            btn_backup.Enabled = false;
            btn_restore.Enabled = false;
            try
            {
                DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow server in dt.Rows)
                {
                    string server_name = server[dt.Columns["ServerName"]].ToString();
                    string instace_name = server[dt.Columns["InstanceName"]].ToString();
                    string sqlversion = server[dt.Columns["Version"]].ToString();
                    string sqlserverfullname = String.Format("{0}\\{1}", server_name, instace_name);
                    cbo_server_name.Items.Add(sqlserverfullname);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        public void user_log_insert()
        {
            BLL_user_log bulg = new BLL_user_log();
            // string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(txtuser_id.Text, day, "BackUp");
            if (dt.Rows.Count == 0)
            {
                int abc = bulg.createuserlog(txtuser_id.Text, "BackUp", date, day);
            }
        }
        public void user_log_insert_restore()
        {
            BLL_user_log bulg = new BLL_user_log();
            // string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(txtuser_id.Text, day, "Restore");
            if (dt.Rows.Count == 0)
            {
                int abc = bulg.createuserlog(txtuser_id.Text, "Restore", date, day);
            }
        }
        private void btn_backup_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_database_name.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please Select A Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "Backup Database " + cbo_database_name.Text + " To Disk = '" + txt_backup_loaction.Text + "\\" + cbo_database_name.Text + "-" + DateTime.Now.ToString("yyyy-mm-dd hh") + ".bak'";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Successfully Database Backup Completed.");
                user_log_insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void btn_backup_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txt_backup_loaction.Text = dlg.SelectedPath;
            }
        }

        private void btn_restore_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup File(*.bak)|*.bak|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtrestore_location.Text = dlg.FileName;
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_database_name.Text.CompareTo("")==0)
                {
                    MessageBox.Show("Please Select A Database.", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "Alter Database " + cbo_database_name.Text + " Set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                sql = "Restore Database " + cbo_database_name.Text + " From Disk ='" + txtrestore_location.Text + "'WITH REPLACE;";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Successfully Restore Database", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                user_log_insert_restore();
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
