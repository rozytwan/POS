using BLLS.BLLHotel;
using BLLS.Hotel;
using Bunifu.Framework.UI;
using DevComponents.DotNetBar;
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
using System.Windows.Media.Imaging;

namespace POS_System.Hotel
{
    public partial class Hotel : UserControl
    {
        public Hotel()
        {
            InitializeComponent();
        }
        BLLHotelRoom blhr = new BLLHotelRoom();
        BLL_HotelCategory hotel = new BLL_HotelCategory();
        ButtonX btn_area = new ButtonX();
        private void Hotel_Load(object sender, EventArgs e)
        {
            
            flowLayoutPanel2.AllowDrop = true;
          DataTable dt = blhr.getAllRoomCategory();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; dt.Rows.Count > x; x++)
                {
                    btn_area = new ButtonX();
                    btn_area.Text = dt.Rows[x]["category_name"].ToString();
                    btn_area.Location = System.Drawing.Point.Add(new Point(4 + x * 70, 4), new Size(50, 50));
                    btn_area.Name = dt.Rows[x]["room_category_id"].ToString();

                    btn_area.ForeColor = Color.White;
                    this.btn_area.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(29, 0, 0, 26);
                    this.btn_area.Size = new System.Drawing.Size(100, 50);
                    this.btn_area.TabIndex = 311;

                    btn_area.Click += new System.EventHandler(this.btn_area_click);
                
                    flowLayoutPanel1.Controls.Add(btn_area);
                    btn_area.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                }
            }
        }

        private void btn_area_click(object sender, EventArgs e)
        {
            room_category_id = Convert.ToInt32(((ButtonX)sender).Name);
            if (room_category_id > 0)
            {
                roomManagement();
            }
        }

        int room_category_id;
       
        Panel mainPanel = new Panel();
        Panel roomPanel = new Panel();
   
        BunifuFlatButton btn_room_no = new BunifuFlatButton();
        BunifuFlatButton btn_details = new BunifuFlatButton();
      
        Label lbl_customer_name = new Label();
        Label lbl_image_id = new Label();
        Label lbl_phone_no = new Label();
        Label lbl_country = new Label();
        Label lbl_package = new Label();
        Label room_status = new Label();
        BunifuFlatButton btn_check_in_out = new BunifuFlatButton();
        
        public void roomManagement()
        {
            
            DataTable dt = blhr.getAllRoomDetaisbyId(room_category_id);
            if (dt.Rows.Count > 0)
            {
                flowLayoutPanel2.Controls.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mainPanel = new Panel();
                    btn_room_no = new BunifuFlatButton();
                    btn_details = new BunifuFlatButton();
                    lbl_customer_name = new Label();
                    lbl_phone_no = new Label();
                    lbl_country = new Label();
                    lbl_package = new Label();
                    mainPanel.Size = new System.Drawing.Size(190, 225);
                    string image_name = dt.Rows[i]["image"].ToString();
                    if (image_name.Length > 0)
                    {
                        Byte[] imge_byte = (byte[])dt.Rows[i]["image"];
                        var stream = new MemoryStream(imge_byte);
                        var image = (Bitmap)Image.FromStream(stream);
                        var new_image = new Bitmap(image, new Size(225, 180));

                        mainPanel.BackgroundImage = new_image;
                        mainPanel.BackgroundImageLayout = ImageLayout.None;

                    }

                    // mainPanel.BackColor = Color.White;
                    btn_room_no.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
                    btn_room_no.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
                   
                    //this.btn_details.Size = new System.Drawing.Size(190, 225);
                    //btn_details.BackColor = Color.White;
                    //this.btn_details.BorderRadius = 7;
                    this.btn_room_no.BorderRadius = 7;

                    this.btn_room_no.Cursor = System.Windows.Forms.Cursors.Hand;
                    this.btn_room_no.DisabledColor = System.Drawing.Color.White;
                    this.btn_room_no.Iconcolor = System.Drawing.Color.White;
                    this.btn_room_no.Iconimage = null;
                    this.btn_room_no.Iconimage_right = null;
                    this.btn_room_no.Iconimage_right_Selected = null;
                    this.btn_room_no.Iconimage_Selected = null;
                    this.btn_room_no.IconMarginLeft = 0;
                    this.btn_room_no.IconMarginRight = 0;
                    this.btn_room_no.IconRightVisible = false;
                    this.btn_room_no.IconRightZoom = 0D;
                    this.btn_room_no.IconVisible = true;
                    this.btn_room_no.IconZoom = 90D;
                    this.btn_room_no.IsTab = false;
                    this.btn_room_no.Location = new Point(3, 3);
                    room_id = dt.Rows[i]["room_id"].ToString();
                    this.btn_room_no.Name = room_id;
                    this.mainPanel.Name = room_id;
                  this.btn_room_no.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
                    this.btn_room_no.OnHovercolor = System.Drawing.Color.Red;
                    this.btn_room_no.OnHoverTextColor = System.Drawing.Color.White;
                    this.btn_room_no.selected = false;
                    this.btn_room_no.Size = new System.Drawing.Size(187, 50);
                    this.btn_room_no.TabIndex = 0;
                    this.btn_room_no.Text = dt.Rows[i]["room_no"].ToString();
                   // package_id =Convert.ToInt32(dt.Rows[i]["package_id"].ToString());
                    this.btn_room_no.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    this.btn_room_no.Textcolor = System.Drawing.Color.White;
                    this.btn_room_no.TextFont = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    btn_check_in_out = new BunifuFlatButton();
                    mainPanel.Size = new System.Drawing.Size(190, 225);
                  //  mainPanel.BackColor = Color.White;
                    btn_check_in_out.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
                    btn_check_in_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
                    this.btn_check_in_out.BorderRadius = 7;
                    this.btn_check_in_out.Cursor = System.Windows.Forms.Cursors.Hand;
                    this.btn_check_in_out.DisabledColor = System.Drawing.Color.White;
                    this.btn_check_in_out.Iconcolor = System.Drawing.Color.White;
                    this.btn_check_in_out.Iconimage = null;
                    this.btn_check_in_out.Iconimage_right = null;
                    this.btn_check_in_out.Iconimage_right_Selected = null;
                    this.btn_check_in_out.Iconimage_Selected = null;
                    this.btn_check_in_out.IconMarginLeft = 0;
                    this.btn_check_in_out.IconMarginRight = 0;
                    this.btn_check_in_out.IconRightVisible = false;
                    this.btn_check_in_out.IconRightZoom = 0D;
                    this.btn_check_in_out.IconVisible = true;
                    this.btn_check_in_out.IconZoom = 90D;
                    this.btn_check_in_out.IsTab = false;
                    this.btn_check_in_out.Location = new Point(2, 180);
                    
                    this.btn_check_in_out.Name = room_id;
                    this.btn_check_in_out.AccessibleName= dt.Rows[i]["room_no"].ToString();
                    this.btn_check_in_out.Normalcolor = System.Drawing.Color.Orange;
                    this.btn_check_in_out.OnHovercolor = System.Drawing.Color.Blue;
                    this.btn_check_in_out.OnHoverTextColor = System.Drawing.Color.White;
                    this.btn_check_in_out.selected = false;
                    this.btn_check_in_out.Size = new System.Drawing.Size(187, 50);
                    this.btn_check_in_out.TabIndex = 0;
                   this.btn_check_in_out.Text = dt.Rows[i]["status"].ToString(); ;

                    this.btn_check_in_out.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    this.btn_check_in_out.Textcolor = System.Drawing.Color.White;
                    this.btn_check_in_out.TextFont = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    this.lbl_customer_name.AutoSize = true;
                    this.lbl_customer_name.Location = new System.Drawing.Point(0, 55);
                    this.lbl_customer_name.Size = new System.Drawing.Size(35, 13);
                    this.lbl_customer_name.TabIndex = 0;
                    this.lbl_customer_name.ForeColor = Color.Black;
                    this.lbl_customer_name.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    this.lbl_country.AutoSize = true;
                    this.lbl_country.Location = new System.Drawing.Point(0, 75);
                    this.lbl_country.Size = new System.Drawing.Size(35, 13);
                    this.lbl_country.TabIndex = 0;
                    this.lbl_country.ForeColor = Color.Black;
                    this.lbl_country.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    this.lbl_phone_no.AutoSize = true;
                    this.lbl_phone_no.Location = new System.Drawing.Point(0, 95);
                    this.lbl_phone_no.Size = new System.Drawing.Size(35, 13);
                    this.lbl_phone_no.TabIndex = 0;
                    this.lbl_phone_no.ForeColor = Color.Black;
                    this.lbl_phone_no.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    this.lbl_package.AutoSize = true;
                    this.lbl_package.Location = new System.Drawing.Point(0, 150);
                    this.lbl_package.Size = new System.Drawing.Size(35, 13);
                    this.lbl_package.TabIndex = 0;
                    this.lbl_package.ForeColor = Color.Red;
                    this.lbl_package.Font = new System.Drawing.Font("Georgia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    DataTable dtm = blhr.getAllRoombookingbyId(Convert.ToInt32(room_id));
                    if (dtm.Rows.Count>0)
                    {
                        if (Convert.ToInt32(dtm.Rows[0]["package_id"].ToString()) != 0)
                        {
                            DataTable dtp = hotel.GetRoompackageById(Convert.ToInt32(dtm.Rows[0]["package_id"].ToString()));
                            if (dtp.Rows.Count > 0)
                            {
                                this.lbl_package.Name = "label1";
                                this.lbl_package.Text = "With" + ' ' + dtp.Rows[0]["package_name"].ToString();
                            }
                        }
                    }
                  

                    if (dtm.Rows.Count > 0)
                    {
                        this.lbl_customer_name.Name = "label1";
                        this.lbl_customer_name.Text = dtm.Rows[0]["name"].ToString();
                        this.lbl_phone_no.Name = "label1";
                        this.lbl_phone_no.Text = dtm.Rows[0]["contact"].ToString();
                        this.lbl_country.Name = "label1";
                        this.lbl_country.Text = dtm.Rows[0]["country"].ToString();
                        this.btn_check_in_out.Text = "Check Out";
                      
                        this.btn_check_in_out.Normalcolor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        //this.lbl_customer_name.Name = "label1";
                        //this.lbl_customer_name.Text = "Customer Name";
                        //this.lbl_phone_no.Name = "label1";
                        //this.lbl_phone_no.Text = "Customer Country";
                        //this.lbl_country.Name = "label1";
                        //this.lbl_country.Text = "Customer Contact";
                        //this.lbl_phone_no.Text = "label1";
                       // this.btn_check_in_out.Text = "Check In";
                    }

                    flowLayoutPanel2.Controls.Add(mainPanel);
                    mainPanel.Controls.Add(btn_room_no);
                    mainPanel.Controls.Add(lbl_customer_name);
                    mainPanel.Controls.Add(lbl_phone_no);
                    mainPanel.Controls.Add(lbl_country);
                    mainPanel.Controls.Add(lbl_package);
                    mainPanel.Controls.Add(btn_check_in_out);
                  
                    btn_room_no.Click += new System.EventHandler(this.btn_room_no_click);
           
                    mainPanel.Click += new System.EventHandler(this.mainPanel_click);
                    btn_check_in_out.Click += new System.EventHandler(this.btn_check_in_out_click);
                    
                }
            }
        }
        private static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight); return newImage;
        }
        //string image_name;
    
        public static string room_id;
        public static int package_id;
        public string room_no;
        public string image_id;
        private void btn_room_no_click(object sender, EventArgs e)
        {
            room_id = ((BunifuFlatButton)sender).Name;
            room_no = ((BunifuFlatButton)sender).Text;
           DataTable dtm = blhr.getAllRoombookingbyId(Convert.ToInt32(room_id));
            if (dtm.Rows.Count==0)
            {
                MessageBox.Show("Room Is Empty Cannot Order!!", "No Customer Alert !!");
            }
            else
            {
                if (room_id != "")
                {
                    hotel_KOTOrder hko = new hotel_KOTOrder(room_no, room_id);
                    Control crl = this.Parent;
                    crl.Controls.Clear();
                    crl.Controls.Add(hko);
                }
            }
        }
  
        private void mainPanel_click(object sender, EventArgs e)
        {
            room_id = ((Panel)sender).Name;
       
            room_no = ((Panel)sender).Text;
           DataTable dt = blhr.GetAllRoom(room_id);
            if (dt.Rows.Count>0)
            {
                if (room_id != "")
                {
                    //  DataTable dt = blhr.GetRoomDetail(image_id);
                    RoomImages rd = new RoomImages();
                    Control crl = this.Parent;
                    rd.room_id = room_id;

                    crl.Controls.Clear();
                    crl.Controls.Add(rd);
                    //  RoomView();
                }
            }
            //else
            //{
            //    MessageBox.Show("Images Not Available !!", "No Photos Alert !!");
            //}
   

        }
 
        string buttonText;
        private void btn_check_in_out_click(object sender, EventArgs e)
        {
            room_id = ((BunifuFlatButton)sender).Name;
            room_no= ((BunifuFlatButton)sender).AccessibleName;
            buttonText = ((BunifuFlatButton)sender).Text;

            if (room_no != "")
            {
                if (buttonText == "Check In")
                {
                    GetDetails hko = new GetDetails();
                    Control crl = this.Parent;
                    hko.room_id = room_id;
                    hko.lbl_room_no.Text = room_no;
                    crl.Controls.Clear();
                    crl.Controls.Add(hko);
                }
                else if (buttonText=="Check Out")
              {
                    HotelBilling hko = new HotelBilling(room_no,room_id);
                    Control crl = this.Parent;                 
                    crl.Controls.Clear();
                    crl.Controls.Add(hko);
                }
                else
                {
                    MessageBox.Show("May be in renovation");
                }
            }
            
           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        string imgpath;
  
        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
 e.Effect = DragDropEffects.Copy;
        }

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
