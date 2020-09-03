using BLLS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Counter_Cash_Withdrawl : UserControl
    {
        public Counter_Cash_Withdrawl()
        {
            InitializeComponent();
        }
        BLLcashwithdrawl blcw = new BLLcashwithdrawl();
        BLLUser blu = new BLLUser();
        private void Counter_Cash_Withdrawl_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            btn_export_to_pdf.Hide();
            panel2.Hide();
            panel4.Hide();
            Sum_Cash();
        }
        decimal sum;
        public void Sum_Cash()
        {
            DateTime date1 = Convert.ToDateTime(datefrom.Text);
            DateTime date2 = Convert.ToDateTime(dateto.Text);
            DataTable dt = blcw.Sum_Cash(date1,date2);
            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     sum += Convert.ToDecimal(dt.Rows[i][0].ToString());
                   
                }
                lbl_cash.Text = sum.ToString();
  }

        }
    
        private void Show_Click(object sender, EventArgs e)
        {
            DateTime date1 = Convert.ToDateTime(datefrom.Text);
            DateTime date2 = Convert.ToDateTime(dateto.Text);
            DataTable dt = blcw.Search_data_ByDate(date1,date2);
            if(dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_cash"].Value = dt.Rows[i]["cash"].ToString();
                    dataGridView1.Rows[i].Cells["col_withdrawl_type"].Value = dt.Rows[i]["withdrawl_type"].ToString();
                    dataGridView1.Rows[i].Cells["cal_description"].Value = dt.Rows[i]["remarks"].ToString();


                    decimal avg_cash = dt.Select().Where(p => p["cash"] != DBNull.Value && Convert.ToInt32(p["cash"]) > 0).Select(c => Convert.ToDecimal(c["cash"])).Sum();
                    lbl_cash.Text = Convert.ToString(avg_cash);
                    dataGridView1.Show();
                    panel2.Show();
                    panel1.Hide();
                    panel4.Show();
                    btn_export_to_pdf.Show();

                }
            }
            else
            {
                MessageBox.Show("No data exist Between dates", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
          
        }


        //string name;
        //string withdrawl_type;
    
        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {

            PdfPTable pdfTable = new PdfPTable(5);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(celli.Value.ToString());
                       
                    }
                    catch { }
                }
            }
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Counter Cash Withdrawl\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "CounterCashWithdrawl " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Counter Cash Withdrawl");
                //Paragraph pname = new Paragraph(name);
                Paragraph pdate = new Paragraph("From:"    + datefrom.Text + "                       " + " To:"     + dateto.Text);
               // Paragraph withdrawal = new Paragraph(withdrawl_type);
                pheading.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph(" ");
             
                pdfDoc.Add(pheading);
               // pdfDoc.Add(pname);
                pdfDoc.Add(pdate);
              //  pdfDoc.Add(withdrawal);

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }

       
    }
}
