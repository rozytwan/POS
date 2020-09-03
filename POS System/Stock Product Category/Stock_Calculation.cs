using BLLS;
using ClosedXML.Excel;
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
    public partial class Stock_Calculation : UserControl
    {
        public Stock_Calculation()
        {
            InitializeComponent();
        }
        BLLStock blstock = new BLLStock();
        BLLUser blu = new BLLUser();
        BLLStockCategory bllsc = new BLLStockCategory();
        private void Stock_Calculation_Load(object sender, EventArgs e)
        {
            LoadCalcution();
            cmb_choose.SelectedIndex = 0;
           
        }
        double total_amount = 0;
        double sum = 0;
        public void TotalCalculation()
        {
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total_amount += Convert.ToDouble(dataGridView1.Rows[i].Cells["col_total"].Value);
 }
            }
            lbl_total.Text = total_amount.ToString("#.##");
          

        }
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public int product_id;
        IngridentCostCalculation icc = new IngridentCostCalculation();
        public void LoadCalcution()
        {
            dt = blstock.GetstockCalculation();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_productid"].Value = dt.Rows[i]["product_id"].ToString();
                    product_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_productid"].Value);
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_department"].Value = dt.Rows[i]["department"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    MinimumQuantity();
                    dataGridView1.Rows[i].Cells["col_unit"].Value = unit;

                    dt1 = blstock.GetLatestPrice(product_id);
                    if (dt1.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_cost"].Value = dt1.Rows[0]["price"].ToString() +" "+"/"+" "+ dt1.Rows[0]["unit"].ToString();
                       
                        decimal totalPrice = icc.IngredintCostCalculation(unit, Convert.ToDecimal(dt1.Rows[0]["price"].ToString()), product_id, dt1.Rows[0]["unit"].ToString());
                     dataGridView1.Rows[i].Cells["col_total"].Value = Convert.ToString(Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) * totalPrice);
                    }
              
                }
                TotalCalculation();
            }
        }
        string unit;
        private void MinimumQuantity()
        {
            DataTable dt = bllsc.Getunitbyproductid(product_id);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["inhouse_unit_3"].ToString() != "")
                {
                   unit= dt.Rows[0]["inhouse_unit_3"].ToString();
                }
                else if (dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                {
                   unit = dt.Rows[0]["inhouse_unit_2"].ToString();
                }
                else
                {
                    unit = dt.Rows[0]["inhouse_unit_1"].ToString();
                }


            }
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_choose.SelectedIndex == 0)
            {
                cmb_choose.Text = "Search By";
            }
            if (cmb_choose.SelectedIndex == 1)
            {

                dt = blstock.StockProductCalculation(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_productid"].Value = dt.Rows[i]["product_id"].ToString();
                        product_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_productid"].Value);
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                        MinimumQuantity();
                        dataGridView1.Rows[i].Cells["col_unit"].Value = unit;

                        dt1 = blstock.GetLatestPrice(product_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_cost"].Value = dt1.Rows[0]["price"].ToString() + " " + "/" + " " + dt1.Rows[0]["unit"].ToString();

                            decimal totalPrice = icc.IngredintCostCalculation(unit, Convert.ToDecimal(dt1.Rows[0]["price"].ToString()), product_id, dt1.Rows[0]["unit"].ToString());
                            dataGridView1.Rows[i].Cells["col_total"].Value = Convert.ToString(Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) * totalPrice);
                        }
                    }
                    total_amount = 0;
                    TotalCalculation();
                }
            }
          else if (cmb_choose.SelectedIndex == 2)
            {

                dt = blstock.DepartmentStockCalculation(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_productid"].Value = dt.Rows[i]["product_id"].ToString();
                        product_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_productid"].Value);
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                        MinimumQuantity();
                        dataGridView1.Rows[i].Cells["col_unit"].Value = unit;

                        dt1 = blstock.GetLatestPrice(product_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_cost"].Value = dt1.Rows[0]["price"].ToString() + " " + "/" + " " + dt1.Rows[0]["unit"].ToString();

                            decimal totalPrice = icc.IngredintCostCalculation(unit, Convert.ToDecimal(dt1.Rows[0]["price"].ToString()), product_id, dt1.Rows[0]["unit"].ToString());
                            dataGridView1.Rows[i].Cells["col_total"].Value = Convert.ToString(Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) * totalPrice);
                        }
                    }
                    total_amount = 0;
                    TotalCalculation();
                }
            }
        }
        
        string Business_Name;
        string pan_no;
        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-2);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <=4 )
                {
                    cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }
            }


            string data;
            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cells in row.Cells)
                {
                    if (cells.ColumnIndex <=4)
                    {
                        if (cells.Value == null)
                        {
                            data = "0.00";
                        }
                        else
                        {
                            data = cells.Value.ToString();
                        }
                        pdfTable.AddCell(data);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockAmountCalculation\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "StockAmountCalculation " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Stock Amount Calculation Reports");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph(" ");
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph(" ");
                p.Alignment = Element.ALIGN_BOTTOM;
                pdfDoc.Add(pheading);
                pdfDoc.Add(pheading_business_name);
                pdfDoc.Add(pheading_pan_no);
                pdfDoc.Add(pheadingDate);
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(p);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt_m = blu.checkbusiness();
            if (dt_m.Rows.Count > 0)
            {
                Business_Name = dt_m.Rows[0]["business_name"].ToString();
                pan_no = dt_m.Rows[0]["pan_no"].ToString();
            }
            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <=4)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }
            string data;
            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex <=4)
                    {
                        if (cell.Value == null)
                        {
                            data = "0.00";
                        }
                        else
                        {
                            data = cell.Value.ToString();
                        }
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = data;
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\StockAmountCalculatin Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, Business_Name);
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Stock Calculation.xlsx");
                MessageBox.Show("Stock Amount Calculation report has been export to document", "Stock Calculation Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
