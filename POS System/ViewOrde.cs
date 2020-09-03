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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Reflection;

namespace POS_System
{
    public partial class ViewOrder: UserControl
    {
        public ViewOrder()
        {
            InitializeComponent();
        }
        bll_orderCancel boc = new bll_orderCancel();

        private void OrderCancelForm_Load(object sender, EventArgs e)
        {

            //loadcategorys();
            //loadproducts();
            //loadtableno();
            panel1.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
          

        }

        public void loadcategorys()
        {
            DataTable getcat = boc.getallcategory();
            if (getcat.Rows.Count > 0)
            {
                DataRow dr = getcat.NewRow();
                dr["category"] = "Choose One";
                getcat.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getcat;
                txt_searchText.DisplayMember = "category";

            }

        }

        public void loadproducts()
        {
            DataTable getpro = boc.getalitems();
            if (getpro.Rows.Count > 0)
            {
                DataRow dr = getpro.NewRow();
                dr["item"] = "Choose One";
                getpro.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getpro;
                txt_searchText.DisplayMember = "item";

            }

        }
        public void loadtableno()
        {
            DataTable getno = boc.getalltableno();
            if (getno.Rows.Count > 0)
            {
                DataRow dr = getno.NewRow();
                dr["table_no"] = 0.00;
                getno.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getno;
                txt_searchText.DisplayMember = "table_no";

            }

        }
        public void loaggrids()
        {
            DataTable getdt = boc.getallCancelOrders();
            if (getdt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < getdt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(getdt.Rows[i]["id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());


                }

            }
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {

            panel1.Hide();
        }
        string Business_Name;
        string pan_no;
        BLLUser blu = new BLLUser();
        private void button1_Click_1(object sender, EventArgs e)
        {

            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount - 15);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 8)
                {
                    cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }
            }



            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cells in row.Cells)
                {
                    if (cells.ColumnIndex <= 8)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Restaurant Order Cancel Report\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "Restaurant Cancel Report " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Restaurant Cancel Order Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
              
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
             
                pdfDoc.Add(pheading);
                pdfDoc.Add(pheading_business_name);
                pdfDoc.Add(pheading_pan_no);
              
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
               
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }

        
        

        //public void searchbyTablename() {
        //    dataGridView1.Rows.Clear();
        //    DataTable dtst = boc.getbyTablesearch(cbo_tablesno.Text);
        //    if (dtst.Rows.Count > 0)
        //    {
        //        dataGridView1.Rows.Clear();
        //        for (int i = 0; i < dtst.Rows.Count; i++)
        //        {
        //            dataGridView1.Rows.Add(dtst.Rows[i]["id"].ToString(), dtst.Rows[i]["table_no"].ToString(), dtst.Rows[i]["category"].ToString(), dtst.Rows[i]["item"].ToString(), dtst.Rows[i]["quantity"].ToString(), dtst.Rows[i]["cost"].ToString(), dtst.Rows[i]["total"].ToString(), dtst.Rows[i]["user_name"].ToString(), dtst.Rows[i]["phone"].ToString(), dtst.Rows[i]["kot_print"].ToString(), dtst.Rows[i]["active"].ToString());


        //        }

        //    }

        //  }









        private void btnbackpage_Click(object sender, EventArgs e)
        {

            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Item")
            {
                loadproducts();
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                loadcategorys();
            }
            else if (cbo_searchTYpe.Text == "Table No")
            {
                loadtableno();
            }

            else if (cbo_searchTYpe.Text == "ALL")
            {

                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                List<string> li = new List<string>();
                li.Add("TS");
                li.Add("TA");
                li.Add("HD");
                txt_searchText.DataSource = li;
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
               
                if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable getdt = boc.getbycategoryorder(txt_searchText.Text);
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["order_id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());


                        }

                        panel1.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }


                }
                else if (cbo_searchTYpe.Text == "Item")
                {
                    DataTable getdt = boc.getbyitemsorder(txt_searchText.Text);
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["order_id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());


                        }

                        panel1.Show();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }


                }
                else if (cbo_searchTYpe.Text == "Table No")
                {

                    DataTable getdt = boc.getbytable_no(Convert.ToDecimal(txt_searchText.Text));
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["order_id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());


                        }

                        panel1.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }


                }
                else if (cbo_searchTYpe.Text == "ALL")
                {

                    DataTable getdt = boc.getallOrdersbydates();
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["order_id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());
                        }

                        panel1.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }

                }
                else if (cbo_searchTYpe.Text == "Sales Type")
                {

                    DataTable getdt = boc.getby_sales_typeOrder(txt_searchText.Text);
                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getdt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[i]["order_id"].ToString(), getdt.Rows[i]["table_no"].ToString(), getdt.Rows[i]["category_name"].ToString(), getdt.Rows[i]["item"].ToString(), getdt.Rows[i]["quantity"].ToString(), getdt.Rows[i]["cost"].ToString(), getdt.Rows[i]["total"].ToString(), getdt.Rows[i]["user_name"].ToString(), getdt.Rows[i]["phone"].ToString(), getdt.Rows[i]["kot_print"].ToString(), getdt.Rows[i]["active"].ToString());
                        }

                        panel1.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available");
                    }

                }

            }
        }

        private void btn_export_excel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
            ////ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            //DataTable dt = new DataTable();

            ////Adding the Columns
            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    if (column.Index <= 14)
            //    {
            //        dt.Columns.Add(column.HeaderText);
            //    }
            //}

            ////Adding the Rows
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    dt.Rows.Add();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ColumnIndex <= 14)
            //        {
            //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            //        }
            //    }
            //}

            ////Exporting to Excel
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\OrderCancelListReport Excel\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt, "Order Cancel List");
            //    wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "OrderCancelListReport.xlsx");
            //}
        }
        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
           
            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex+1, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex+1, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[1, 6]].Merge();
                worksheet.Cells[1, 2] = "Demo Restaurant PanNo:123456789";
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Order Cancel Excel\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                workbook.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "OrderCancel.xlsx");
                    MessageBox.Show("Export Successful");
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        DataTable dt_xml = new DataTable();
        private void btn_export_XML_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index < 8)
                {
                    dt_xml.Columns.Add(column.HeaderText);
                }
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt_xml.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex < 8)
                    {
                        dt_xml.Rows[dt_xml.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }
            dt_xml.TableName = "MyTable";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Order Cancel Log XML\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Order Cancel Log.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();
        }

        private void btn_text_export_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Order Cancel Log Text\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            TextWriter sw = new StreamWriter(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "0rder Cancel Log.txt");
            int rowcount = dataGridView1.Rows.Count;
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            sw.WriteLine("                         " + Business_Name + "            ");
            sw.WriteLine("                       Pan No:  " + pan_no + "            ");
           
            sw.WriteLine("          ");
            for (int i = 0; i < rowcount - 1; i++)
            {
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "\t"
                             + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\t"
                              + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\t"
                               + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\t"
                                 + dataGridView1.Rows[i].Cells[4].Value.ToString() + "\t"
                                   + dataGridView1.Rows[i].Cells[5].Value.ToString() + "\t"
                                     + dataGridView1.Rows[i].Cells[6].Value.ToString() + "\t"
                                     + dataGridView1.Rows[i].Cells[7].Value.ToString() + "\t"
                              

                               );
            }
            sw.Close();
            MessageBox.Show("Data Has Been Export In Text File");
        }
    }
}