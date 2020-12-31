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
using ClosedXML.Excel;

namespace POS_System
{
    public partial class StockList : UserControl
    {
        public StockList()
        {
            InitializeComponent();
        }
        BLLStock blls = new BLLStock();
        BLLStockCategory blsc = new BLLStockCategory();
        private void StockList_Load(object sender, EventArgs e)
        {
            LoadStock();
            StockGrouping();
            cmb_choose.Text = "Search By";
        }
       

        int product_id;
        public void LoadStock()
        {
            DataTable dt = blls.getallstock();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    if (dt1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                    }
                    product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                    DataTable dt2 = blsc.GetQtybyProductid(product_id);
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt2.Rows[0]["product_name"].ToString();
                    }
                    int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                    DataTable dt3 = blsc.GetDepartment(department_id);
                    if (dt3.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1; ;
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt3.Rows[0]["department"].ToString();
                    }

                    dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                    dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                    DataTable dtcal = blls.GetProductCalculationQty(product_id);
                    if (dtcal.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                   
                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                    decimal qty = Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                    if (qty < 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_qty1"].Value = (Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]))) + " " + dt2.Rows[0]["inhouse_unit_1"];
                        dataGridView1.Rows[i].Cells["col_qty2"].Value = (Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"])) + " " + dt2.Rows[0]["inhouse_unit_2"];
                        dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"] + " " + dt2.Rows[0]["inhouse_unit_3"];
                    }
                    else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"])) + " " + dt2.Rows[0]["inhouse_unit_1"];
                        dataGridView1.Rows[i].Cells["col_qty2"].Value = dt.Rows[i]["qty"] + " "+ dt2.Rows[0]["inhouse_unit_2"];
                    }
                    else
                    {
                        
                        dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"] + " " + dt2.Rows[0]["inhouse_unit_1"];
                    }
                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();

                }
            }
        }
  
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            DataTable dt2 = blsc.GetQtybyProductid(product_id);
            if (cmb_choose.SelectedIndex==-1)
            {
                cmb_choose.Text = "Search By";
            }
            if (cmb_choose.SelectedIndex == 0)
            {
              
                DataTable dt = blls.SearchbyProductname(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                        if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]);
                            dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"].ToString();
                        }
                        else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]);
                        }
                        else
                        {

                            dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"].ToString();
                        }
                    }
                }
            }
            else if (cmb_choose.SelectedIndex == 1)
            {
             
                DataTable dt = blls.SearchbyCategoryname(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();

                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                        if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]);
                            dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"].ToString();
                        }
                        else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]);
                        }
                        else
                        {

                            dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"].ToString();
                        }
                    }
                }
                }
           else if (cmb_choose.SelectedIndex==2)
            {

                DataTable dt = blls.SearchbyDepartment(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                     
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                        if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]);
                            dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"].ToString();
                        }
                        else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]);
                        }
                        else
                        {

                            dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"].ToString();
                        }
                    }
                }
            }
           
                }
            
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_transfer"].Index && e.RowIndex >= 0)
            {
                Stock_Transfer st = new Stock_Transfer();
                st.stock_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_stock_id"].Value.ToString());
                st.ShowDialog();
                LoadStock();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DataTable dt2 = blsc.GetQtybyProductid(product_id);
            DataTable dt = blls.Searchbylocation(cmb_location.Text);
            if (cmb_location.Text == "Choose location")
            {
                LoadStock();
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();

                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();

                        if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]);
                            dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"].ToString();
                        }
                        else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]));
                            dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]);
                        }
                        else
                        {

                            dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"].ToString();
                        }
                    }
                }
            }
        

        private void cmb_location_Enter(object sender, EventArgs e)
        {
        
        }

        private void cmb_location_Leave(object sender, EventArgs e)
        {
           
        }
        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
        int i = 0;
        public void StockGrouping()
        {
            DataTable dt = blcg.GetStockGrouping();
            flwpln_categoryGrouping.Controls.Clear();
            for (int low = 0; low < dt.Rows.Count; low++)
            {
                Button[] GroupCategory = new Button[99];
                GroupCategory[low] = new Button();
                GroupCategory[low].Name = dt.Rows[low]["id"].ToString();
                GroupCategory[low].Text = dt.Rows[low]["group_name"].ToString();
                GroupCategory[low].Location = System.Drawing.Point.Add(new Point(0, 4 + i * 55), new Size(25, 20));
                GroupCategory[low].Height = 50;
                GroupCategory[low].Width = 80;
                GroupCategory[low].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                GroupCategory[low].FlatStyle = FlatStyle.Flat;
                GroupCategory[low].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                //GroupCategory[low].BackColor = ColorTranslator.FromHtml("#33A6FF");

                GroupCategory[low].ForeColor = Color.White;

                string image_color = dt.Rows[low]["group_color"].ToString();
                GroupCategory[low].BackColor = Color.FromName(image_color);
                GroupCategory[low].TextAlign = ContentAlignment.TopCenter;

                flwpln_categoryGrouping.Controls.Add(GroupCategory[low]);
                GroupCategory[low].Click += new EventHandler(GroupCategorys_Click);
                // lblcateogry_item.Hide();
                //lblitem_id.Hide();
            }

        }
        private void GroupCategorys_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Name);
            if (id > 0)
            {
                DataTable dt = blcg.GetProductCategoryGrouping(id);
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                        DataTable dt1 = blls.SearchbyCategoryId(category_id);
                        if (dt1.Rows.Count>0)
                        {
                            for (int j = 0; j< dt.Rows.Count; j++)
                            {
                                //dataGridView1.Rows.Add();
                                //dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                                //dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                                //dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                                //dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();

                                //dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                                //dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                                //dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                                //if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]) > 0)
                                //{
                                //    dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]));
                                //    dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_3"]);
                                //    dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["qty"].ToString();
                                //}
                                //else if (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]) > 0)
                                //{
                                //    dataGridView1.Rows[i].Cells["col_qty1"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]) / (Convert.ToDecimal(dt2.Rows[0]["inhouse_qty_2"]));
                                //    dataGridView1.Rows[i].Cells["col_qty2"].Value = Convert.ToDecimal(dt.Rows[i]["qty"]);
                                //}
                                //else
                                //{

                                //    dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["qty"].ToString();
                                //}
                            }
                        }
                    }
                }
            }
        }
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index < 9)
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
                    if (cell.ColumnIndex < 9)
                    {
                        if (cell.Value != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = 0.00;
                        }
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\StockReport Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Stock Record");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockReport.xlsx");
            }
        }

        private void lbl_search_Click(object sender, EventArgs e)
        {

        }
    }
    }

