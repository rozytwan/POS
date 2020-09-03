namespace POS_System.CustomerAttendance
{
    partial class EventAttendance
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
            this.btn_start = new DevComponents.DotNetBar.ButtonX();
            this.btn_stop = new DevComponents.DotNetBar.ButtonX();
            this.txt_card_no = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_addcategory = new System.Windows.Forms.Label();
            this.cbo_event_type = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_start.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(29, 220);
            this.btn_start.Name = "btn_start";
            this.btn_start.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_start.Size = new System.Drawing.Size(421, 411);
            this.btn_start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_start.TabIndex = 65;
            this.btn_start.Text = "Start";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_stop.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(538, 220);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_stop.Size = new System.Drawing.Size(432, 418);
            this.btn_stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_stop.TabIndex = 66;
            this.btn_stop.Text = "Stop";
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_card_no
            // 
            this.txt_card_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_card_no.ForeColor = System.Drawing.Color.Gray;
            this.txt_card_no.Location = new System.Drawing.Point(33, 139);
            this.txt_card_no.Name = "txt_card_no";
            this.txt_card_no.Size = new System.Drawing.Size(929, 45);
            this.txt_card_no.TabIndex = 67;
            this.txt_card_no.Text = "Card No";
            this.txt_card_no.TextChanged += new System.EventHandler(this.txt_card_no_TextChanged);
            this.txt_card_no.Enter += new System.EventHandler(this.txt_card_no_Enter);
            this.txt_card_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_card_no_KeyDown);
            this.txt_card_no.Leave += new System.EventHandler(this.txt_card_no_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.btn_back);
            this.panel2.Controls.Add(this.lbl_addcategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 68);
            this.panel2.TabIndex = 68;
            // 
            // btn_back
            // 
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Image = global::POS_System.Properties.Resources.back36;
            this.btn_back.Location = new System.Drawing.Point(3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(70, 64);
            this.btn_back.TabIndex = 22;
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // lbl_addcategory
            // 
            this.lbl_addcategory.AutoSize = true;
            this.lbl_addcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addcategory.ForeColor = System.Drawing.Color.White;
            this.lbl_addcategory.Location = new System.Drawing.Point(399, 19);
            this.lbl_addcategory.Name = "lbl_addcategory";
            this.lbl_addcategory.Size = new System.Drawing.Size(215, 29);
            this.lbl_addcategory.TabIndex = 0;
            this.lbl_addcategory.Text = "Event Attendance";
            // 
            // cbo_event_type
            // 
            this.cbo_event_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_event_type.FormattingEnabled = true;
            this.cbo_event_type.Location = new System.Drawing.Point(33, 84);
            this.cbo_event_type.Name = "cbo_event_type";
            this.cbo_event_type.Size = new System.Drawing.Size(219, 33);
            this.cbo_event_type.TabIndex = 69;
            // 
            // EventAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbo_event_type);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_card_no);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Name = "EventAttendance";
            this.Size = new System.Drawing.Size(993, 665);
            this.Load += new System.EventHandler(this.EventAttendance_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btn_start;
        private DevComponents.DotNetBar.ButtonX btn_stop;
        private System.Windows.Forms.TextBox txt_card_no;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_addcategory;
        private System.Windows.Forms.ComboBox cbo_event_type;
    }
}