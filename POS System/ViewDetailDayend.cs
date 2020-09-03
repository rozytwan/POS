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
    public partial class ViewDetailDayend : UserControl
    {
        public ViewDetailDayend()
        {
            InitializeComponent();
        }
        Bll_dayend bllde = new Bll_dayend();
        private void ViewDetailDayend_Load(object sender, EventArgs e)
        {
            searchPanel.Show();
            panel_dayend.Hide();
        }
        private void Show_Click(object sender, EventArgs e)
        {
            DatagridView();
        }



        public void DatagridView()
        {
            DateTime date1 = Convert.ToDateTime(datefrom.Text);
            DateTime date2 = Convert.ToDateTime(dateto.Text);
            DataTable dt = bllde.SearchByDateDetail(date1, date2);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    // dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["col_subtotal"].Value = dt.Rows[i]["subtotal"].ToString();
                    dataGridView1.Rows[i].Cells["col_discount"].Value = dt.Rows[i]["discount"].ToString();
                    dataGridView1.Rows[i].Cells["col_tax"].Value = dt.Rows[i]["tax"].ToString();
                    dataGridView1.Rows[i].Cells["col_servicecharge"].Value = dt.Rows[i]["service_charge"].ToString();
                    dataGridView1.Rows[i].Cells["col_grandtotal"].Value = dt.Rows[i]["grand_total"].ToString();
                    dataGridView1.Rows[i].Cells["col_cash"].Value = dt.Rows[i]["totalCashsales"].ToString();
                    dataGridView1.Rows[i].Cells["col_card"].Value = dt.Rows[i]["totalcardsales"].ToString();
                    dataGridView1.Rows[i].Cells["col_credit"].Value = dt.Rows[i]["credit"].ToString();
                    dataGridView1.Rows[i].Cells["col_creditpaid"].Value = dt.Rows[i]["credit_paid"].ToString();
                    dataGridView1.Rows[i].Cells["col_cashdrop"].Value = dt.Rows[i]["totalCareof"].ToString();
                    dataGridView1.Rows[i].Cells["col_cashincounter"].Value = dt.Rows[i]["totalCashinCounter"].ToString();
                    dataGridView1.Rows[i].Cells["col_countingcash"].Value = dt.Rows[i]["counting_cash"].ToString();
                    dataGridView1.Rows[i].Cells["col_settlement"].Value = dt.Rows[i]["cash_sattlement"].ToString();
                    dataGridView1.Rows[i].Cells["col_closing"].Value = dt.Rows[i]["closing_blc"].ToString();
                    dataGridView1.Rows[i].Cells["col_opening"].Value = dt.Rows[i]["openingbalc"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();

                }
                decimal subtotal = dt.Select().Where(p => p["subtotal"] != DBNull.Value && Convert.ToDecimal(p["subtotal"]) > 0).Select(c => Convert.ToDecimal(c["subtotal"])).Sum();
                decimal cash = dt.Select().Where(p => p["totalCashsales"] != DBNull.Value && Convert.ToDecimal(p["totalCashsales"]) > 0).Select(c => Convert.ToDecimal(c["totalCashsales"])).Sum();
                decimal card = dt.Select().Where(p => p["totalcardsales"] != DBNull.Value && Convert.ToDecimal(p["totalcardsales"]) > 0).Select(c => Convert.ToDecimal(c["totalcardsales"])).Sum();
                decimal grandtotal = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToDecimal(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                decimal cashdrop = dt.Select().Where(p => p["totalCareof"] != DBNull.Value && Convert.ToDecimal(p["totalCareof"]) > 0).Select(c => Convert.ToDecimal(c["totalCareof"])).Sum();
                decimal tax = dt.Select().Where(p => p["tax"] != DBNull.Value && Convert.ToDecimal(p["tax"]) > 0).Select(c => Convert.ToDecimal(c["tax"])).Sum();
                decimal servicecharge = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                decimal discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToDecimal(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();
                decimal credit = dt.Select().Where(p => p["credit"] != DBNull.Value && Convert.ToDecimal(p["credit"]) > 0).Select(c => Convert.ToDecimal(c["credit"])).Sum();
                decimal creditpaid= dt.Select().Where(p => p["credit_paid"] != DBNull.Value && Convert.ToDecimal(p["credit_paid"]) > 0).Select(c => Convert.ToDecimal(c["credit_paid"])).Sum();
                decimal countercash = dt.Select().Where(p => p["totalCashinCounter"] != DBNull.Value && Convert.ToDecimal(p["totalCashinCounter"]) > 0).Select(c => Convert.ToDecimal(c["totalCashinCounter"])).Sum();
                decimal countingcash = dt.Select().Where(p => p["counting_cash"] != DBNull.Value && Convert.ToDecimal(p["counting_cash"]) > 0).Select(c => Convert.ToDecimal(c["counting_cash"])).Sum();
                decimal settlement = dt.Select().Where(p => p["cash_sattlement"] != DBNull.Value && Convert.ToDecimal(p["cash_sattlement"]) > 0).Select(c => Convert.ToDecimal(c["cash_sattlement"])).Sum();
                decimal closing = dt.Select().Where(p => p["closing_blc"] != DBNull.Value && Convert.ToDecimal(p["closing_blc"]) > 0).Select(c => Convert.ToDecimal(c["closing_blc"])).Sum();
                decimal opening = dt.Select().Where(p => p["openingbalc"] != DBNull.Value && Convert.ToDecimal(p["openingbalc"]) > 0).Select(c => Convert.ToDecimal(c["openingbalc"])).Sum();
                // decimal opening = dt.Select().Select(c => Convert.ToDecimal(c["openingbalc"])).Sum();

                lbl_subtotal.Text = Convert.ToString(subtotal);
                lbl_cash.Text = Convert.ToString(cash);
                lbl_card.Text = Convert.ToString(card);
                lbl_grandtotal.Text = Convert.ToString(grandtotal);
                lbl_cashdrop.Text = Convert.ToString(cashdrop);
                lbl_tax.Text = Convert.ToString(tax);
                lbl_servicecharge.Text = Convert.ToString(servicecharge);
                lbl_discount.Text = Convert.ToString(discount);
                lbl_credit.Text = Convert.ToString(credit);
                lbl_countercash.Text = Convert.ToString(countercash);
                lbl_counting.Text = Convert.ToString(countingcash);
                lbl_settlement.Text = Convert.ToString(settlement);
                lbl_closingblc.Text = Convert.ToString(closing);
                lbl_openingblc.Text = Convert.ToString(opening);
                searchPanel.Hide();
                panel_dayend.Show();
            }
            else
            {
                MessageBox.Show("No data exist Between dates", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            panel_dayend.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            panel_dayend.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 16)
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
                    if (cells.ColumnIndex <= 16)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\DayEnd Detail Report \\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "DayEnd Report " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("DayEnd Detail Report ");
                Paragraph pheadingDate = new Paragraph("From:     " + datefrom.Text + "                                        " + "To:      " + dateto.Text);
                pheading.Alignment = Element.TITLE;

                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph(""+ lbl_subtotal.Text +"                              " + lbl_grandtotal.Text);
                p.Alignment = Element.ALIGN_BOTTOM;
                pdfDoc.Add(pheading);

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
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 16)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in rows.Cells)
                {
                    if (cell.ColumnIndex <= 16)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();

                    }

                }
            }
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\DayEnd Record Excel\\Dayend Detail\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
            {
                wb.Worksheets.Add(dt, "DayEnd Detail Report");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-MM-dd hh") + "Dayend.xlsx");

                MessageBox.Show("Data Has Been Export To Document");
            }
        }

        private void lbl_subtotal_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
    }
}
    
    
