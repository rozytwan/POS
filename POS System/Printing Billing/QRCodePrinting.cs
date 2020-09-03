using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Printing_Billing
{
    public class QRCodePrinting
    {
        public string printer_name;
        public void printQR()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 60000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = printer_name;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 60000;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);


            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();

            }
            else
            {
                MessageBox.Show("Invalid Printer", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();

                }
            }
        }
       public PictureBox pb1 = new PictureBox();
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            pb1.Size = new System.Drawing.Size(100, 100);
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                 Bitmap myBitmap1 = new Bitmap(100,100);
                pb1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, 100, 100));
                e.Graphics.DrawImage(myBitmap1, 75, 0);
               
            
        }
        }
     }
        


