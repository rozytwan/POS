namespace POS_System
{
    partial class CreateBusiness
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBusiness));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btncreate = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.RichTextBox();
            this.txtnote2 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtn_english = new System.Windows.Forms.RadioButton();
            this.rbtn_arabic = new System.Windows.Forms.RadioButton();
            this.sbtn_tax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.sbtn_service_charge = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_tax = new System.Windows.Forms.Label();
            this.txt_tax = new System.Windows.Forms.TextBox();
            this.lbl_service_charge = new System.Windows.Forms.Label();
            this.txt_service_charge = new System.Windows.Forms.TextBox();
            this.txt_pan_no = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_upload = new DevComponents.DotNetBar.ButtonX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // txtaddress
            // 
            resources.ApplyResources(this.txtaddress, "txtaddress");
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtaddress_KeyDown);
            // 
            // txtphone
            // 
            resources.ApplyResources(this.txtphone, "txtphone");
            this.txtphone.Name = "txtphone";
            this.txtphone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphone_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // btncreate
            // 
            this.btncreate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncreate.BackColor = System.Drawing.Color.White;
            this.btncreate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(this.btncreate, "btncreate");
            this.btncreate.Name = "btncreate";
            this.btncreate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btncreate.Symbol = "";
            this.btncreate.TextColor = System.Drawing.Color.White;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.business__2_;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtnote
            // 
            resources.ApplyResources(this.txtnote, "txtnote");
            this.txtnote.Name = "txtnote";
            // 
            // txtnote2
            // 
            resources.ApplyResources(this.txtnote2, "txtnote2");
            this.txtnote2.Name = "txtnote2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // rbtn_english
            // 
            resources.ApplyResources(this.rbtn_english, "rbtn_english");
            this.rbtn_english.Checked = true;
            this.rbtn_english.Name = "rbtn_english";
            this.rbtn_english.TabStop = true;
            this.rbtn_english.UseVisualStyleBackColor = true;
            // 
            // rbtn_arabic
            // 
            resources.ApplyResources(this.rbtn_arabic, "rbtn_arabic");
            this.rbtn_arabic.Name = "rbtn_arabic";
            this.rbtn_arabic.UseVisualStyleBackColor = true;
            // 
            // sbtn_tax
            // 
            // 
            // 
            // 
            this.sbtn_tax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.sbtn_tax, "sbtn_tax");
            this.sbtn_tax.Name = "sbtn_tax";
            this.sbtn_tax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sbtn_tax.ValueChanged += new System.EventHandler(this.sbtn_tax_ValueChanged);
            // 
            // sbtn_service_charge
            // 
            // 
            // 
            // 
            this.sbtn_service_charge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.sbtn_service_charge, "sbtn_service_charge");
            this.sbtn_service_charge.Name = "sbtn_service_charge";
            this.sbtn_service_charge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sbtn_service_charge.ValueChanged += new System.EventHandler(this.sbtn_service_charge_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // lbl_tax
            // 
            resources.ApplyResources(this.lbl_tax, "lbl_tax");
            this.lbl_tax.Name = "lbl_tax";
            // 
            // txt_tax
            // 
            resources.ApplyResources(this.txt_tax, "txt_tax");
            this.txt_tax.Name = "txt_tax";
            this.txt_tax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tax_KeyPress);
            // 
            // lbl_service_charge
            // 
            resources.ApplyResources(this.lbl_service_charge, "lbl_service_charge");
            this.lbl_service_charge.Name = "lbl_service_charge";
            // 
            // txt_service_charge
            // 
            resources.ApplyResources(this.txt_service_charge, "txt_service_charge");
            this.txt_service_charge.Name = "txt_service_charge";
            this.txt_service_charge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_service_charge_KeyPress);
            // 
            // txt_pan_no
            // 
            resources.ApplyResources(this.txt_pan_no, "txt_pan_no");
            this.txt_pan_no.Name = "txt_pan_no";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btn_upload
            // 
            this.btn_upload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_upload.BackColor = System.Drawing.Color.White;
            this.btn_upload.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(this.btn_upload, "btn_upload");
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_upload.Symbol = "";
            this.btn_upload.TextColor = System.Drawing.Color.White;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // CreateBusiness
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_pan_no);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_service_charge);
            this.Controls.Add(this.lbl_service_charge);
            this.Controls.Add(this.txt_tax);
            this.Controls.Add(this.lbl_tax);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sbtn_service_charge);
            this.Controls.Add(this.sbtn_tax);
            this.Controls.Add(this.rbtn_arabic);
            this.Controls.Add(this.rbtn_english);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtnote2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateBusiness";
            this.Load += new System.EventHandler(this.CreateBusiness_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btncreate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtnote;
        private System.Windows.Forms.RichTextBox txtnote2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtn_english;
        private System.Windows.Forms.RadioButton rbtn_arabic;
        private DevComponents.DotNetBar.Controls.SwitchButton sbtn_tax;
        private DevComponents.DotNetBar.Controls.SwitchButton sbtn_service_charge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_tax;
        private System.Windows.Forms.TextBox txt_tax;
        private System.Windows.Forms.Label lbl_service_charge;
        private System.Windows.Forms.TextBox txt_service_charge;
        private System.Windows.Forms.TextBox txt_pan_no;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.ButtonX btn_upload;
    }
}