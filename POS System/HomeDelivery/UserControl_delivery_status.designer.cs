namespace POS_System
{
    partial class UserControl_delivery_status
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dgv_deliver = new System.Windows.Forms.DataGridView();
            this.calkotid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calbill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caldeliveryman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcusadress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcusphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caltotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cal_recived = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cal_payment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deliver)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 73);
            this.panel2.TabIndex = 121;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.transport__2_;
            this.pictureBox1.Location = new System.Drawing.Point(262, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 5);
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
            this.label23.Location = new System.Drawing.Point(332, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(426, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Check Home Delivery Lists";
            // 
            // dgv_deliver
            // 
            this.dgv_deliver.AllowUserToAddRows = false;
            this.dgv_deliver.AllowUserToDeleteRows = false;
            this.dgv_deliver.BackgroundColor = System.Drawing.Color.White;
            this.dgv_deliver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_deliver.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.calkotid,
            this.calbill_no,
            this.caldeliveryman,
            this.calcusname,
            this.calcusadress,
            this.calcusphone,
            this.caltotal,
            this.calstatus,
            this.calid,
            this.cal_recived,
            this.cal_cancel,
            this.cal_payment_type});
            this.dgv_deliver.Location = new System.Drawing.Point(2, 74);
            this.dgv_deliver.Name = "dgv_deliver";
            this.dgv_deliver.ReadOnly = true;
            this.dgv_deliver.RowHeadersVisible = false;
            this.dgv_deliver.Size = new System.Drawing.Size(1021, 563);
            this.dgv_deliver.TabIndex = 120;
            this.dgv_deliver.RowHeadersBorderStyleChanged += new System.EventHandler(this.dgv_deliver_RowHeadersBorderStyleChanged);
            this.dgv_deliver.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_deliver_CellClick);
            this.dgv_deliver.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_deliver_RowHeaderMouseDoubleClick);
            // 
            // calkotid
            // 
            this.calkotid.HeaderText = "HD ID";
            this.calkotid.Name = "calkotid";
            this.calkotid.ReadOnly = true;
            this.calkotid.Width = 80;
            // 
            // calbill_no
            // 
            this.calbill_no.HeaderText = "Bill No";
            this.calbill_no.Name = "calbill_no";
            this.calbill_no.ReadOnly = true;
            // 
            // caldeliveryman
            // 
            this.caldeliveryman.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.caldeliveryman.HeaderText = "Delivery Man";
            this.caldeliveryman.Name = "caldeliveryman";
            this.caldeliveryman.ReadOnly = true;
            // 
            // calcusname
            // 
            this.calcusname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.calcusname.HeaderText = "Customer Name";
            this.calcusname.Name = "calcusname";
            this.calcusname.ReadOnly = true;
            // 
            // calcusadress
            // 
            this.calcusadress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.calcusadress.HeaderText = "Customer Address";
            this.calcusadress.Name = "calcusadress";
            this.calcusadress.ReadOnly = true;
            // 
            // calcusphone
            // 
            this.calcusphone.HeaderText = "Customer Phone";
            this.calcusphone.Name = "calcusphone";
            this.calcusphone.ReadOnly = true;
            this.calcusphone.Width = 80;
            // 
            // caltotal
            // 
            this.caltotal.HeaderText = "Amount";
            this.caltotal.Name = "caltotal";
            this.caltotal.ReadOnly = true;
            // 
            // calstatus
            // 
            this.calstatus.HeaderText = "Payment Status";
            this.calstatus.Name = "calstatus";
            this.calstatus.ReadOnly = true;
            // 
            // calid
            // 
            this.calid.HeaderText = "id";
            this.calid.Name = "calid";
            this.calid.ReadOnly = true;
            this.calid.Visible = false;
            // 
            // cal_recived
            // 
            this.cal_recived.HeaderText = "Payment Received";
            this.cal_recived.Name = "cal_recived";
            this.cal_recived.ReadOnly = true;
            this.cal_recived.Text = "Recived";
            this.cal_recived.UseColumnTextForButtonValue = true;
            // 
            // cal_cancel
            // 
            this.cal_cancel.HeaderText = "Cancel";
            this.cal_cancel.Name = "cal_cancel";
            this.cal_cancel.ReadOnly = true;
            this.cal_cancel.Text = "Cancel";
            this.cal_cancel.ToolTipText = "Cancel";
            this.cal_cancel.UseColumnTextForButtonValue = true;
            // 
            // cal_payment_type
            // 
            this.cal_payment_type.HeaderText = "Payment Type";
            this.cal_payment_type.Name = "cal_payment_type";
            this.cal_payment_type.ReadOnly = true;
            this.cal_payment_type.Visible = false;
            // 
            // UserControl_delivery_status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_deliver);
            this.Name = "UserControl_delivery_status";
            this.Size = new System.Drawing.Size(1024, 655);
            this.Load += new System.EventHandler(this.UserControl_delivery_status_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deliver)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dgv_deliver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn calkotid;
        private System.Windows.Forms.DataGridViewTextBoxColumn calbill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn caldeliveryman;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcusadress;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcusphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn caltotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn calstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn calid;
        private System.Windows.Forms.DataGridViewButtonColumn cal_recived;
        private System.Windows.Forms.DataGridViewButtonColumn cal_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cal_payment_type;
    }
}
