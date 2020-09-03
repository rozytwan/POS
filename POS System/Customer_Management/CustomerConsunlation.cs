using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace POS_System.Customer_Management
{
    public partial class CustomerConsolation : UserControl
    {
        public CustomerConsolation()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
    
      
        DataTable dt = new DataTable();
        int customer_id;
        string CreateFormFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CustomerSampleForms";
        private void CustomerConsunlation_Load(object sender, EventArgs e)
        {
            Loadcustomer();
            Customer_Remark();
            panel_code.Hide();
            panel_remarks.Hide();
            panel_document.Hide();
            cmb_doucments.Text = "Choose One";
           

            if (!Directory.Exists(CreateFormFolder))
            {
                Directory.CreateDirectory(CreateFormFolder);
            }
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CustomerSampleForms", "*.docx");
            foreach (string filePath in files)
            cmb_doucments.Items.Add(Path.GetFileName(filePath));

        }
        public void Customer_Remark()
        {
            DataTable dt = blcd.GetConsulation();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["remarks"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_remarks.DataSource = dt;
                cmb_remarks.DisplayMember = "remarks";
                
            }
        }
        public void Loadcustomer()
        {
            
            dt = blcd.getallcustomers();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                    dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[i].Cells["col_address"].Value = dt.Rows[i]["address"].ToString();
                    dataGridView1.Rows[i].Cells["col_gender"].Value = dt.Rows[i]["gender"].ToString();

                }
            }
         }
   private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public class RandomGenerator
        {
            // Generate a random number between two numbers    
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }
        }
        string destinationfile;
        string createfolder;
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             createfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "POS" + "\\" + "Customer Documents";

            if (!Directory.Exists(createfolder))
            {
                Directory.CreateDirectory(createfolder);
            }

            if (e.ColumnIndex == dataGridView1.Columns["col_hair"].Index && e.RowIndex >= 0)
            {
                customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                DataTable dt = blcd.GetCusotmerConsulation(customer_id);
                if (dt.Rows.Count>0)
                {
                    panel_remarks.Show();
                    panel_document.Hide();
                    panel_code.Hide();
                 }
          
                else
                {
                  panel_document.Show();
                    panel_remarks.Hide();
                    //OpenFileDialog ofd = new OpenFileDialog();
                    //    if (ofd.ShowDialog() == DialogResult.OK)
                    //    {
                    //        string sourceFile = ofd.FileName;
                    //        string sourceFolder = sourceFile;
                    //        string filenameWithoutPath = Path.GetFileName(sourceFile);
                    //        // System.IO.File.Move(filenameWithoutPath, "Sample");
                    //        destinationfile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + filenameWithoutPath;
                    //        FileInfo fi = new FileInfo(sourceFile);
                    //        RandomGenerator generator = new RandomGenerator();
                    //        int rand = generator.RandomNumber(1000, 100000);
                    //        string rsg = generator.RandomString(4, false);

                    //        txt_location.Text = rsg + rand.ToString();
                    //        panel_code.Visible = true;
                    //        //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + cmb_doucments.Text + ".docx";
                    //        if (!File.Exists(destinationfile))
                    //        {
                    //            fi.CopyTo(destinationfile);
                    //        }
                    //        System.Diagnostics.Process.Start(destinationfile);
                    //    }
                    }
                 
                }
            }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_remarks.Text == "")
            {
                MessageBox.Show("Remark is required");
               // panel_code.Show();
            }
            else
            {
              
                string curFile = createfolder + "\\"+ generatedcode + ".docx";

                if (File.Exists(curFile))
                    {
                        int insert = blcd.Insert_hair_Consulation(Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()), curFile, generatedcode, txt_remarks.Text);
                        if (insert > 0)
                        {
                            MessageBox.Show("Your Doucment Is saved At Documents/POS/Customer Documents Folder !!", "Document Save Alert !!");
                            panel_code.Hide();
                        }
                    }
                    else if (!File.Exists(curFile))
                    {
                        MessageBox.Show("Your Doucment Is MisPlaced !!", "Document Not Saved Alert !!");
                    }
                }
            CustomerConsunlation_Load(null, null);
            }
        
        private void btn_remarks_Click(object sender, EventArgs e)
        {
            if (cmb_remarks.Text != "" || cmb_remarks.Text != "Choose One")
            {
                DataTable dt = blcd.GetHairCounsulation(customer_id, cmb_remarks.Text);
                if (dt.Rows.Count > 0)
                {
                    string filepath = dt.Rows[0]["file_location"].ToString();
                    if (File.Exists(filepath))
                    {
                        System.Diagnostics.Process.Start(filepath);
                        panel_remarks.Hide();
                    }
                   
                }
                else
                {
                    MessageBox.Show("This is not avialble");

                }
                
            }
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CustomerSampleForms" + "\\"+ cmb_doucments.Text;
            if (File.Exists(folderPath))
            {
                RandomGenerator generator = new RandomGenerator();
                int rand = generator.RandomNumber(1000, 100000);
                string rsg = generator.RandomString(4, false);
                generatedcode = rsg + rand.ToString();
                panel_code.Visible = true;
              //  string sourceFile = generatedcode;
                FileInfo fi = new FileInfo(generatedcode);
                string customerdocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "POS" + "\\" + "Customer Documents" + "\\" + generatedcode + ".docx";
                 if (!File.Exists(customerdocument))
                {
                    File.Copy(folderPath, customerdocument);
                 
                }
                System.Diagnostics.Process.Start(customerdocument);
              
            }
            panel_document.Hide();
        }
        string generatedcode;
        private void lbl_get_file_Click(object sender, EventArgs e)
        {
            panel_document.Hide();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = ofd.FileName;
                string sourceFolder = sourceFile;
                string filenameWithoutPath = Path.GetFileName(sourceFile);
        

                if (!Directory.Exists(CreateFormFolder))
                {
                    Directory.CreateDirectory(CreateFormFolder);
                }
                destinationfile = CreateFormFolder + "\\" + filenameWithoutPath;
                FileInfo fi = new FileInfo(sourceFile);
                RandomGenerator generator = new RandomGenerator();
                int rand = generator.RandomNumber(1000, 100000);
                string rsg = generator.RandomString(4, false);

               generatedcode = rsg + rand.ToString();
                panel_code.Visible = true;
              
                if (!File.Exists(destinationfile))
                {
                    fi.CopyTo(destinationfile);

                }

                string customerdocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "POS" + "\\" + "Customer Documents" + "\\" +generatedcode + ".docx";
                if (!File.Exists(customerdocument))
                {
                    string curFile = createfolder + "\\" + generatedcode + ".docx";
                    fi.CopyTo(customerdocument);
                
                }
               // File.Copy(destinationfile,customerdocument +Path.GetFileName(destinationfile));
                System.Diagnostics.Process.Start(customerdocument);

            }
        }
    private void panel_document_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_get_file_MouseHover(object sender, EventArgs e)
        {
            lbl_get_file.Font = new Font(lbl_get_file.Font.Name, lbl_get_file.Font.SizeInPoints, FontStyle.Underline);
        }

        private void lbl_form_MouseHover(object sender, EventArgs e)
        {
            lbl_form.Font = new Font(lbl_form.Font.Name, lbl_form.Font.SizeInPoints, FontStyle.Underline);
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            panel_code.Hide();
        }

        private void lbl_form_Click(object sender, EventArgs e)
        {
            panel_document.Show();
            panel_remarks.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btn_documents_Click(object sender, EventArgs e)
        {
            panel_document.Hide();
        }

        private void btn_code_Click(object sender, EventArgs e)
        {
            panel_code.Hide();
        }

        private void btn_remark_Click(object sender, EventArgs e)
        {
            panel_remarks.Hide();
        }
    }
}
