namespace POS_System
{
    partial class KitchenOrderInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenOrderInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_adult = new System.Windows.Forms.TextBox();
            this.txt_children = new System.Windows.Forms.TextBox();
            this.lbl_total = new System.Windows.Forms.Label();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl_table_no = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnbackspace = new System.Windows.Forms.Button();
            this.btnzero = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btnseven = new System.Windows.Forms.Button();
            this.btnsix = new System.Windows.Forms.Button();
            this.btnfive = new System.Windows.Forms.Button();
            this.btnfour = new System.Windows.Forms.Button();
            this.btnthree = new System.Windows.Forms.Button();
            this.btntwo = new System.Windows.Forms.Button();
            this.btnone = new System.Windows.Forms.Button();
            this.btn_close = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adult";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Children ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total";
            // 
            // txt_adult
            // 
            this.txt_adult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adult.Location = new System.Drawing.Point(105, 118);
            this.txt_adult.Name = "txt_adult";
            this.txt_adult.Size = new System.Drawing.Size(130, 29);
            this.txt_adult.TabIndex = 3;
            this.txt_adult.Text = "0";
            this.txt_adult.TextChanged += new System.EventHandler(this.txt_adult_TextChanged);
            this.txt_adult.Enter += new System.EventHandler(this.txt_adult_Enter);
            this.txt_adult.Leave += new System.EventHandler(this.txt_adult_Leave);
            // 
            // txt_children
            // 
            this.txt_children.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_children.Location = new System.Drawing.Point(105, 167);
            this.txt_children.Name = "txt_children";
            this.txt_children.Size = new System.Drawing.Size(130, 29);
            this.txt_children.TabIndex = 4;
            this.txt_children.Text = "0";
            this.txt_children.TextChanged += new System.EventHandler(this.txt_children_TextChanged);
            this.txt_children.Enter += new System.EventHandler(this.txt_children_Enter);
            this.txt_children.Leave += new System.EventHandler(this.txt_children_Leave);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(109, 217);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(16, 17);
            this.lbl_total.TabIndex = 5;
            this.lbl_total.Text = "0";
            this.lbl_total.Click += new System.EventHandler(this.lbl_total_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(138, 265);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_ok.Size = new System.Drawing.Size(89, 40);
            this.btn_ok.TabIndex = 278;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 52);
            this.panel2.TabIndex = 388;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(167, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(129, 31);
            this.label24.TabIndex = 6;
            this.label24.Text = "Cover Up";
            // 
            // lbl_table_no
            // 
            this.lbl_table_no.AutoSize = true;
            this.lbl_table_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_table_no.Location = new System.Drawing.Point(107, 68);
            this.lbl_table_no.Name = "lbl_table_no";
            this.lbl_table_no.Size = new System.Drawing.Size(16, 17);
            this.lbl_table_no.TabIndex = 390;
            this.lbl_table_no.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 389;
            this.label5.Text = "Table No";
            // 
            // btnbackspace
            // 
            this.btnbackspace.BackColor = System.Drawing.Color.DimGray;
            this.btnbackspace.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnbackspace.FlatAppearance.BorderSize = 7;
            this.btnbackspace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnbackspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbackspace.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbackspace.Image = ((System.Drawing.Image)(resources.GetObject("btnbackspace.Image")));
            this.btnbackspace.Location = new System.Drawing.Point(247, 254);
            this.btnbackspace.Name = "btnbackspace";
            this.btnbackspace.Size = new System.Drawing.Size(78, 61);
            this.btnbackspace.TabIndex = 402;
            this.btnbackspace.UseVisualStyleBackColor = false;
            this.btnbackspace.Click += new System.EventHandler(this.btnbackspace_Click);
            // 
            // btnzero
            // 
            this.btnzero.BackColor = System.Drawing.Color.DimGray;
            this.btnzero.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnzero.FlatAppearance.BorderSize = 7;
            this.btnzero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnzero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzero.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzero.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnzero.Location = new System.Drawing.Point(324, 253);
            this.btnzero.Name = "btnzero";
            this.btnzero.Size = new System.Drawing.Size(78, 61);
            this.btnzero.TabIndex = 400;
            this.btnzero.Text = "0";
            this.btnzero.UseVisualStyleBackColor = false;
            this.btnzero.Click += new System.EventHandler(this.btnzero_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.DimGray;
            this.btn9.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn9.FlatAppearance.BorderSize = 7;
            this.btn9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn9.Location = new System.Drawing.Point(407, 187);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(78, 61);
            this.btn9.TabIndex = 399;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.DimGray;
            this.btn8.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn8.FlatAppearance.BorderSize = 7;
            this.btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn8.Location = new System.Drawing.Point(326, 188);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(78, 61);
            this.btn8.TabIndex = 398;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btnseven
            // 
            this.btnseven.BackColor = System.Drawing.Color.DimGray;
            this.btnseven.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnseven.FlatAppearance.BorderSize = 7;
            this.btnseven.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnseven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseven.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseven.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnseven.Location = new System.Drawing.Point(242, 187);
            this.btnseven.Name = "btnseven";
            this.btnseven.Size = new System.Drawing.Size(78, 61);
            this.btnseven.TabIndex = 397;
            this.btnseven.Text = "7";
            this.btnseven.UseVisualStyleBackColor = false;
            this.btnseven.Click += new System.EventHandler(this.btnseven_Click);
            // 
            // btnsix
            // 
            this.btnsix.BackColor = System.Drawing.Color.DimGray;
            this.btnsix.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnsix.FlatAppearance.BorderSize = 7;
            this.btnsix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnsix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsix.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsix.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsix.Location = new System.Drawing.Point(407, 122);
            this.btnsix.Name = "btnsix";
            this.btnsix.Size = new System.Drawing.Size(78, 61);
            this.btnsix.TabIndex = 396;
            this.btnsix.Text = "6";
            this.btnsix.UseVisualStyleBackColor = false;
            this.btnsix.Click += new System.EventHandler(this.btnsix_Click);
            // 
            // btnfive
            // 
            this.btnfive.BackColor = System.Drawing.Color.DimGray;
            this.btnfive.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnfive.FlatAppearance.BorderSize = 7;
            this.btnfive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnfive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfive.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnfive.Location = new System.Drawing.Point(324, 122);
            this.btnfive.Name = "btnfive";
            this.btnfive.Size = new System.Drawing.Size(78, 61);
            this.btnfive.TabIndex = 395;
            this.btnfive.Text = "5";
            this.btnfive.UseVisualStyleBackColor = false;
            this.btnfive.Click += new System.EventHandler(this.btnfive_Click);
            // 
            // btnfour
            // 
            this.btnfour.BackColor = System.Drawing.Color.DimGray;
            this.btnfour.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnfour.FlatAppearance.BorderSize = 7;
            this.btnfour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnfour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfour.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfour.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnfour.Location = new System.Drawing.Point(242, 122);
            this.btnfour.Name = "btnfour";
            this.btnfour.Size = new System.Drawing.Size(78, 61);
            this.btnfour.TabIndex = 394;
            this.btnfour.Text = "4";
            this.btnfour.UseVisualStyleBackColor = false;
            this.btnfour.Click += new System.EventHandler(this.btnfour_Click);
            // 
            // btnthree
            // 
            this.btnthree.BackColor = System.Drawing.Color.DimGray;
            this.btnthree.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnthree.FlatAppearance.BorderSize = 7;
            this.btnthree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnthree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthree.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthree.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnthree.Location = new System.Drawing.Point(407, 58);
            this.btnthree.Name = "btnthree";
            this.btnthree.Size = new System.Drawing.Size(78, 61);
            this.btnthree.TabIndex = 393;
            this.btnthree.Text = "3";
            this.btnthree.UseVisualStyleBackColor = false;
            this.btnthree.Click += new System.EventHandler(this.btnthree_Click);
            // 
            // btntwo
            // 
            this.btntwo.BackColor = System.Drawing.Color.DimGray;
            this.btntwo.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btntwo.FlatAppearance.BorderSize = 7;
            this.btntwo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btntwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntwo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntwo.Location = new System.Drawing.Point(324, 58);
            this.btntwo.Name = "btntwo";
            this.btntwo.Size = new System.Drawing.Size(78, 61);
            this.btntwo.TabIndex = 392;
            this.btntwo.Text = "2";
            this.btntwo.UseVisualStyleBackColor = false;
            this.btntwo.Click += new System.EventHandler(this.btntwo_Click);
            // 
            // btnone
            // 
            this.btnone.BackColor = System.Drawing.Color.DimGray;
            this.btnone.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnone.FlatAppearance.BorderSize = 7;
            this.btnone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnone.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnone.Location = new System.Drawing.Point(242, 58);
            this.btnone.Name = "btnone";
            this.btnone.Size = new System.Drawing.Size(78, 61);
            this.btnone.TabIndex = 391;
            this.btnone.Text = "1";
            this.btnone.UseVisualStyleBackColor = false;
            this.btnone.Click += new System.EventHandler(this.btnone_Click);
            // 
            // btn_close
            // 
            this.btn_close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(28, 266);
            this.btn_close.Name = "btn_close";
            this.btn_close.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_close.Size = new System.Drawing.Size(85, 40);
            this.btn_close.TabIndex = 403;
            this.btn_close.Text = "Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.age;
            this.pictureBox1.Location = new System.Drawing.Point(64, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 404;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::POS_System.Properties.Resources.boy;
            this.pictureBox2.Location = new System.Drawing.Point(66, 170);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 405;
            this.pictureBox2.TabStop = false;
            // 
            // KitchenOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 321);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btnbackspace);
            this.Controls.Add(this.btnzero);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btnseven);
            this.Controls.Add(this.btnsix);
            this.Controls.Add(this.btnfive);
            this.Controls.Add(this.btnfour);
            this.Controls.Add(this.btnthree);
            this.Controls.Add(this.btntwo);
            this.Controls.Add(this.btnone);
            this.Controls.Add(this.lbl_table_no);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.txt_children);
            this.Controls.Add(this.txt_adult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KitchenOrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cover Up";
            this.Load += new System.EventHandler(this.KitchenOrderInfo_Load);
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
        private System.Windows.Forms.Label lbl_total;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl_table_no;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnbackspace;
        private System.Windows.Forms.Button btnzero;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btnseven;
        private System.Windows.Forms.Button btnsix;
        private System.Windows.Forms.Button btnfive;
        private System.Windows.Forms.Button btnfour;
        private System.Windows.Forms.Button btnthree;
        private System.Windows.Forms.Button btntwo;
        private System.Windows.Forms.Button btnone;
        private DevComponents.DotNetBar.ButtonX btn_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TextBox txt_children;
        public System.Windows.Forms.TextBox txt_adult;
    }
}