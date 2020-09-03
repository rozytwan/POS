namespace POS_System.Hotel
{
    partial class HotelRoomStatus
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_messy = new DevComponents.DotNetBar.ButtonX();
            this.btn_check_in = new DevComponents.DotNetBar.ButtonX();
            this.btn_cleaning = new DevComponents.DotNetBar.ButtonX();
            this.btn_out_of_service = new DevComponents.DotNetBar.ButtonX();
            this.btn_room_block = new DevComponents.DotNetBar.ButtonX();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel3.Controls.Add(this.label23);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 62);
            this.panel3.TabIndex = 285;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(178, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(302, 39);
            this.label23.TabIndex = 19;
            this.label23.Text = "Hotel Room Status";
            // 
            // btn_messy
            // 
            this.btn_messy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_messy.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_messy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_messy.Location = new System.Drawing.Point(13, 72);
            this.btn_messy.Name = "btn_messy";
            this.btn_messy.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_messy.Size = new System.Drawing.Size(164, 149);
            this.btn_messy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_messy.Symbol = "";
            this.btn_messy.TabIndex = 307;
            this.btn_messy.Text = "Messy";
            this.btn_messy.Click += new System.EventHandler(this.btn_messy_Click);
            // 
            // btn_check_in
            // 
            this.btn_check_in.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_check_in.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_check_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check_in.Location = new System.Drawing.Point(382, 72);
            this.btn_check_in.Name = "btn_check_in";
            this.btn_check_in.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_check_in.Size = new System.Drawing.Size(164, 149);
            this.btn_check_in.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_check_in.Symbol = "";
            this.btn_check_in.TabIndex = 310;
            this.btn_check_in.Text = "Check In";
            this.btn_check_in.Click += new System.EventHandler(this.btn_check_in_Click);
            // 
            // btn_cleaning
            // 
            this.btn_cleaning.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cleaning.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_cleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cleaning.Location = new System.Drawing.Point(195, 72);
            this.btn_cleaning.Name = "btn_cleaning";
            this.btn_cleaning.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_cleaning.Size = new System.Drawing.Size(164, 149);
            this.btn_cleaning.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cleaning.Symbol = "";
            this.btn_cleaning.TabIndex = 311;
            this.btn_cleaning.Text = "Cleaning ";
            this.btn_cleaning.Click += new System.EventHandler(this.btn_cleaning_Click);
            // 
            // btn_out_of_service
            // 
            this.btn_out_of_service.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_out_of_service.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_out_of_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_out_of_service.Location = new System.Drawing.Point(195, 248);
            this.btn_out_of_service.Name = "btn_out_of_service";
            this.btn_out_of_service.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_out_of_service.Size = new System.Drawing.Size(164, 149);
            this.btn_out_of_service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_out_of_service.Symbol = "";
            this.btn_out_of_service.TabIndex = 314;
            this.btn_out_of_service.Text = "Out Of Service";
            this.btn_out_of_service.Click += new System.EventHandler(this.btn_out_of_service_Click);
            // 
            // btn_room_block
            // 
            this.btn_room_block.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_room_block.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_room_block.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_room_block.Location = new System.Drawing.Point(13, 248);
            this.btn_room_block.Name = "btn_room_block";
            this.btn_room_block.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_room_block.Size = new System.Drawing.Size(164, 149);
            this.btn_room_block.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_room_block.Symbol = "";
            this.btn_room_block.TabIndex = 312;
            this.btn_room_block.Text = "Room Block";
            this.btn_room_block.Click += new System.EventHandler(this.btn_room_block_Click);
            // 
            // HotelRoomStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 447);
            this.Controls.Add(this.btn_out_of_service);
            this.Controls.Add(this.btn_room_block);
            this.Controls.Add(this.btn_cleaning);
            this.Controls.Add(this.btn_check_in);
            this.Controls.Add(this.btn_messy);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotelRoomStatus";
            this.Text = "HotelRoomStatus";
            this.Load += new System.EventHandler(this.HotelRoomStatus_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label23;
        private DevComponents.DotNetBar.ButtonX btn_messy;
        private DevComponents.DotNetBar.ButtonX btn_check_in;
        private DevComponents.DotNetBar.ButtonX btn_cleaning;
        private DevComponents.DotNetBar.ButtonX btn_out_of_service;
        private DevComponents.DotNetBar.ButtonX btn_room_block;
    }
}