using BLLS;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

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
    public partial class View_Stock_Purchase : UserControl
    {
        public View_Stock_Purchase()
        {
            InitializeComponent();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        BLLPurchase blp = new BLLPurchase();
        BLLUser blu = new BLLUser();
        public void loadCategory()
        {
            DataTable dt = blsc.GetCategories();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "category_name";
                cmb_search.ValueMember = "category_id";
            }
        }
        public void LoadProduct()
        {

            DataTable dt = blsc.GetproductList();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["product_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "product_name";
                cmb_search.ValueMember = "product_id";
            }
        }
        private void View_Stock_Purchase_Load(object sender, EventArgs e)
        {
         
            cbo_searchTYpe.Text = "Choose Type";
            searchPanel.Show();
            backPanel.Hide();
            string today = DateTime.Now.ToShortDateString();
            dtp_from.Text = today;
            dtp_to.Text = today;
       

        }
        decimal sumqty=0;
        decimal sumtotal=0;
      
        public void TotalCategory()
        {
            decimal sumtotal = 0;
            decimal sumqty = 0;
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DataTable dt = blp.GetCategorybyid(cmb_search.Text,datefrom, dateto);
            if (lbl_qty_total.Text != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sumqty += Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                }
                lbl_qty_total.Text = sumqty.ToString();
            }
            else
            {
                lbl_qty_total.Text = "0.00";
            }
            DataTable dt1 = blp.GetGrandTotalbyCategory(cmb_search.Text, datefrom, dateto);
            if (lblgt.Text != "")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    sumtotal += Convert.ToDecimal(dt1.Rows[i]["grand_total"].ToString());
                }
                lblgt.Text = sumtotal.ToString();
            }
            else
            {
                lblgt.Text = "0.00";
            }
        }
        public void TotalProduct()
        {
            decimal sumtotal = 0;
            decimal sumqty = 0;
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DataTable dt = blp.GetProductbyid(cmb_search.Text, datefrom, dateto);
            if (lbl_qty_total.Text != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sumqty += Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                }
                lbl_qty_total.Text = sumqty.ToString();
            }
            else
            {
                lbl_qty_total.Text = "0.00";
            }
            DataTable dt1 = blp.GetGrandTotalbyProduct(cmb_search.Text, datefrom, dateto);
            if (lblgt.Text != "")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                   
                    sumtotal += Convert.ToDecimal(dt1.Rows[i]["grand_total"].ToString());
                }
                lblgt.Text = sumtotal.ToString();
            }
            else
            {
                lblgt.Text = "0.00";
            }
        }
        public void TotalAll()
        {
            decimal sumtotal = 0;
            decimal sumqty = 0;
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DataTable dt = blp.GetAll(datefrom, dateto);
            if (lbl_qty_total.Text != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sumqty += Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                }
                lbl_qty_total.Text = sumqty.ToString();
            }
            else
            {
                lbl_qty_total.Text = "0.00";
            }
            DataTable dt1 = blp.GetGrandTotalbyAll(datefrom, dateto);
            if (lblgt.Text != "")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    sumtotal += Convert.ToDecimal(dt1.Rows[i]["grand_total"].ToString());
                }
                lblgt.Text = sumtotal.ToString();
            }
            else
            {
                lblgt.Text = "0.00";
            }
        }
        string invoice_no;
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || cmb_search.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
            else
            {
                DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
                DateTime dateto = Convert.ToDateTime(dtp_to.Text);
                DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                if (cbo_searchTYpe.Text == "Category Name")
                {
                    DataTable dt = blp.GetCategorybyid(cmb_search.Text, datefrom, dateto);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                             dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                            dataGridView1.Rows[i].Cells["calBillNo"].Value = dt.Rows[i]["bill_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["price"].ToString();
                            if (invoice_no != dt.Rows[i]["invoice_no"].ToString())
                            {
                                dataGridView1.Rows[i].Cells["col_discount"].Value = dt.Rows[i]["discount"].ToString();
                                dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                                dataGridView1.Rows[i].Cells["col_tax"].Value = dt.Rows[i]["tax"].ToString();
                            }
                            invoice_no = dt.Rows[i]["invoice_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_supplier"].Value = dt.Rows[i]["supplier_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_purchase_date"].Value = dt.Rows[i]["purchase_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_expire_date"].Value = dt.Rows[i]["expiry_date"].ToString();

                        }
                        searchPanel.Hide();
                        backPanel.Show();
                        TotalCategory();
                    }
                }
                else if (cbo_searchTYpe.Text == "Product Name")
                {
                    DataTable dt3 = blp.GetProductbyid(cmb_search.Text, datefrom, dateto);
                    if (dt3.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_category_name"].Value = dt3.Rows[i]["category_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt3.Rows[i]["product_name"].ToString();
                            dataGridView1.Rows[i].Cells["calBillNo"].Value = dt3.Rows[i]["bill_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt3.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_price"].Value = dt3.Rows[i]["price"].ToString();
                            
                            if (invoice_no != dt3.Rows[i]["invoice_no"].ToString())
                            {
                                dataGridView1.Rows[i].Cells["col_discount"].Value = dt3.Rows[i]["discount"].ToString();
                                dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt3.Rows[i]["grand_total"].ToString();
                                dataGridView1.Rows[i].Cells["col_tax"].Value = dt3.Rows[i]["tax"].ToString();
                            }
                            invoice_no = dt3.Rows[i]["invoice_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_supplier"].Value = dt3.Rows[i]["supplier_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_purchase_date"].Value = dt3.Rows[i]["purchase_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_expire_date"].Value = dt3.Rows[i]["expiry_date"].ToString();

                        }
                        searchPanel.Hide();
                        backPanel.Show();
                        TotalProduct();
                    }
                }
                if (cbo_searchTYpe.Text=="ALL")
                {
                    DataTable dt = blp.GetAll(datefrom, dateto);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                            dataGridView1.Rows[i].Cells["calBillNo"].Value = dt.Rows[i]["bill_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["price"].ToString();
                            if (invoice_no != dt.Rows[i]["invoice_no"].ToString())
                            {
                                dataGridView1.Rows[i].Cells["col_discount"].Value = dt.Rows[i]["discount"].ToString();
                                dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                                dataGridView1.Rows[i].Cells["col_tax"].Value = dt.Rows[i]["tax"].ToString();
                            }
                            invoice_no = dt.Rows[i]["invoice_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_supplier"].Value = dt.Rows[i]["supplier_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_purchase_date"].Value = dt.Rows[i]["purchase_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_expire_date"].Value = dt.Rows[i]["expiry_date"].ToString();

                        }
                        searchPanel.Hide();
                        backPanel.Show();
                        TotalAll();
                    }
                }
       

            }
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
  if (cbo_searchTYpe.Text == "Product Name")
            {
                LoadProduct();
            }
            else if (cbo_searchTYpe.Text == "Category Name")
            { 
                loadCategory();
            }
            if (cbo_searchTYpe.Text=="ALL")
            {
                cmb_search.Text = "ALL";
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {

            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 14)
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
                    if (cells.ColumnIndex <= 14)
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockPurchase\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "StockPurchase " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Complementry Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                                                            " + lbl_qty_total.Text + "                                                        " + lblgt.Text);
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
        string Business_Name;
        string exportBillNo;
        string pan_no;
        DataTable dt = new DataTable();
        DataTable dt_report = new DataTable();
     
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 9)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex <= 9)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\StockPurchase Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Stock Purchase");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockPurchase.xlsx");
            }
        }
        DataTable dt_xml = new DataTable();
        private void btn_export_XML_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index < 14)
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
                    if (cell.ColumnIndex < 14)
                    {
                        dt_xml.Rows[dt_xml.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }
            dt_xml.TableName = "MyTable";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\PurchaseDetails\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Purchaseview.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();
        }

        private void backPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
