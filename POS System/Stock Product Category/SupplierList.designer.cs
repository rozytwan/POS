namespace POS_System
{
    partial class SupplierList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Add_Supplier = new DevComponents.DotNetBar.ButtonX();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.btn_edit = new DevComponents.DotNetBar.ButtonX();
            this.caltitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sup_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caladress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caliban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calaccount_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calbank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calecc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calpan_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcst_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.txt_searchbox = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 73);
            this.panel2.TabIndex = 115;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(92, 65);
            this.btn_back.TabIndex = 20;
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(356, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(222, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Suppliers List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.caltitle,
            this.col_sup_id,
            this.calname,
            this.caladress,
            this.calphone,
            this.calmobile,
            this.calemail,
            this.calcity,
            this.caliban,
            this.calaccount_no,
            this.calbank,
            this.calRemarks,
            this.calecc_no,
            this.calpan_no,
            this.calcst_no});
            this.dataGridView1.Location = new System.Drawing.Point(3, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(945, 414);
            this.dataGridView1.TabIndex = 116;
            // 
            // Add_Supplier
            // 
            this.Add_Supplier.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add_Supplier.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Add_Supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Supplier.Location = new System.Drawing.Point(12, 79);
            this.Add_Supplier.Name = "Add_Supplier";
            this.Add_Supplier.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.Add_Supplier.Size = new System.Drawing.Size(111, 42);
            this.Add_Supplier.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Add_Supplier.TabIndex = 117;
            this.Add_Supplier.Text = "+Supplier";
            this.Add_Supplier.Click += new System.EventHandler(this.Add_Supplier_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_delete.Location = new System.Drawing.Point(113, 547);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_delete.Size = new System.Drawing.Size(51, 51);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.Symbol = "";
            this.btn_delete.TabIndex = 119;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_edit.Location = new System.Drawing.Point(33, 547);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_edit.Size = new System.Drawing.Size(51, 51);
            this.btn_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_edit.Symbol = "";
            this.btn_edit.TabIndex = 118;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // caltitle
            // 
            this.caltitle.HeaderText = "Title";
            this.caltitle.Name = "caltitle";
            this.caltitle.ReadOnly = true;
            // 
            // col_sup_id
            // 
            this.col_sup_id.HeaderText = "Sup Id";
            this.col_sup_id.Name = "col_sup_id";
            this.col_sup_id.ReadOnly = true;
            this.col_sup_id.Visible = false;
            // 
            // calname
            // 
            this.calname.HeaderText = "Name";
            this.calname.Name = "calname";
            this.calname.ReadOnly = true;
            // 
            // caladress
            // 
            this.caladress.HeaderText = "Adress";
            this.caladress.Name = "caladress";
            this.caladress.ReadOnly = true;
            // 
            // calphone
            // 
            this.calphone.HeaderText = "Phone";
            this.calphone.Name = "calphone";
            this.calphone.ReadOnly = true;
            // 
            // calmobile
            // 
            this.calmobile.HeaderText = "Mobile";
            this.calmobile.Name = "calmobile";
            this.calmobile.ReadOnly = true;
            // 
            // calemail
            // 
            this.calemail.HeaderText = "Email";
            this.calemail.Name = "calemail";
            this.calemail.ReadOnly = true;
            // 
            // calcity
            // 
            this.calcity.HeaderText = "City";
            this.calcity.Name = "calcity";
            this.calcity.ReadOnly = true;
            // 
            // caliban
            // 
            this.caliban.HeaderText = "IBAN.";
            this.caliban.Name = "caliban";
            this.caliban.ReadOnly = true;
            // 
            // calaccount_no
            // 
            this.calaccount_no.HeaderText = "Account No.";
            this.calaccount_no.Name = "calaccount_no";
            this.calaccount_no.ReadOnly = true;
            // 
            // calbank
            // 
            this.calbank.HeaderText = "Bank";
            this.calbank.Name = "calbank";
            this.calbank.ReadOnly = true;
            // 
            // calRemarks
            // 
            this.calRemarks.HeaderText = "Remarks";
            this.calRemarks.Name = "calRemarks";
            this.calRemarks.ReadOnly = true;
            // 
            // calecc_no
            // 
            this.calecc_no.HeaderText = "ECC No";
            this.calecc_no.Name = "calecc_no";
            this.calecc_no.ReadOnly = true;
            // 
            // calpan_no
            // 
            this.calpan_no.HeaderText = "PAN No";
            this.calpan_no.Name = "calpan_no";
            this.calpan_no.ReadOnly = true;
            // 
            // calcst_no
            // 
            this.calcst_no.HeaderText = "CST No";
            this.calcst_no.Name = "calcst_no";
            this.calcst_no.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 123;
            this.label2.Text = "Suppliers";
            // 
            // cmb_search
            // 
            this.cmb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Items.AddRange(new object[] {
            "Name"});
            this.cmb_search.Location = new System.Drawing.Point(503, 89);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(197, 32);
            this.cmb_search.TabIndex = 122;
            // 
            // txt_searchbox
            // 
            this.txt_searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchbox.Location = new System.Drawing.Point(772, 89);
            this.txt_searchbox.Name = "txt_searchbox";
            this.txt_searchbox.Size = new System.Drawing.Size(176, 29);
            this.txt_searchbox.TabIndex = 120;
            this.txt_searchbox.TextChanged += new System.EventHandler(this.txt_searchbox_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_search.Location = new System.Drawing.Point(706, 95);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(60, 20);
            this.lbl_search.TabIndex = 121;
            this.lbl_search.Text = "Search";
            // 
            // SupplierList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_search);
            this.Controls.Add(this.txt_searchbox);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.Add_Supplier);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "SupplierList";
            this.Size = new System.Drawing.Size(960, 602);
            this.Load += new System.EventHandler(this.SupplierList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX Add_Supplier;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private DevComponents.DotNetBar.ButtonX btn_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sup_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn calname;
        private System.Windows.Forms.DataGridViewTextBoxColumn caladress;
        private System.Windows.Forms.DataGridViewTextBoxColumn calphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn calmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn calemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcity;
        private System.Windows.Forms.DataGridViewTextBoxColumn caliban;
        private System.Windows.Forms.DataGridViewTextBoxColumn calaccount_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbank;
        private System.Windows.Forms.DataGridViewTextBoxColumn calRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn calecc_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn calpan_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcst_no;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.TextBox txt_searchbox;
        private System.Windows.Forms.Label lbl_search;
    }
}