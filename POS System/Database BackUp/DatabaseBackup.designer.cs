namespace BackUP
{
    partial class DatabaseBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseBackup));
            this.btn_connect = new System.Windows.Forms.GroupBox();
            this.cbo_server_name = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser_id = new System.Windows.Forms.TextBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_database_name = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_backup_browse = new System.Windows.Forms.Button();
            this.txt_backup_loaction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_restore_browse = new System.Windows.Forms.Button();
            this.txtrestore_location = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_connect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Controls.Add(this.cbo_server_name);
            this.btn_connect.Controls.Add(this.txtpassword);
            this.btn_connect.Controls.Add(this.txtuser_id);
            this.btn_connect.Controls.Add(this.btn_disconnect);
            this.btn_connect.Controls.Add(this.button1);
            this.btn_connect.Controls.Add(this.label3);
            this.btn_connect.Controls.Add(this.label2);
            this.btn_connect.Controls.Add(this.label1);
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(8, 79);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(594, 168);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.TabStop = false;
            this.btn_connect.Text = "SQL Server Authentication";
            // 
            // cbo_server_name
            // 
            this.cbo_server_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_server_name.FormattingEnabled = true;
            this.cbo_server_name.Location = new System.Drawing.Point(120, 43);
            this.cbo_server_name.Name = "cbo_server_name";
            this.cbo_server_name.Size = new System.Drawing.Size(358, 28);
            this.cbo_server_name.TabIndex = 2;
            this.cbo_server_name.Text = "LocalHost";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(333, 112);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(145, 27);
            this.txtpassword.TabIndex = 7;
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // txtuser_id
            // 
            this.txtuser_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser_id.Location = new System.Drawing.Point(121, 112);
            this.txtuser_id.Name = "txtuser_id";
            this.txtuser_id.Size = new System.Drawing.Size(128, 27);
            this.txtuser_id.TabIndex = 6;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_disconnect.FlatAppearance.BorderSize = 0;
            this.btn_disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_disconnect.ForeColor = System.Drawing.Color.White;
            this.btn_disconnect.Image = global::POS_System.Properties.Resources.database__1_;
            this.btn_disconnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_disconnect.Location = new System.Drawing.Point(500, 95);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(88, 61);
            this.btn_disconnect.TabIndex = 4;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_disconnect.UseVisualStyleBackColor = false;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::POS_System.Properties.Resources.database;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(500, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(254, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_database_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 75);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Selection";
            // 
            // cbo_database_name
            // 
            this.cbo_database_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_database_name.FormattingEnabled = true;
            this.cbo_database_name.Location = new System.Drawing.Point(121, 32);
            this.cbo_database_name.Name = "cbo_database_name";
            this.cbo_database_name.Size = new System.Drawing.Size(358, 28);
            this.cbo_database_name.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Database";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_backup);
            this.groupBox2.Controls.Add(this.btn_backup_browse);
            this.groupBox2.Controls.Add(this.txt_backup_loaction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 140);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Backup";
            // 
            // btn_backup
            // 
            this.btn_backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_backup.FlatAppearance.BorderSize = 0;
            this.btn_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_backup.ForeColor = System.Drawing.Color.White;
            this.btn_backup.Image = global::POS_System.Properties.Resources.cloud_backup_up_arrow;
            this.btn_backup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_backup.Location = new System.Drawing.Point(504, 83);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(84, 47);
            this.btn_backup.TabIndex = 9;
            this.btn_backup.Text = "Back Up";
            this.btn_backup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_backup.UseVisualStyleBackColor = false;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_backup_browse
            // 
            this.btn_backup_browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_backup_browse.FlatAppearance.BorderSize = 0;
            this.btn_backup_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_backup_browse.ForeColor = System.Drawing.Color.White;
            this.btn_backup_browse.Image = global::POS_System.Properties.Resources.open_folder;
            this.btn_backup_browse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_backup_browse.Location = new System.Drawing.Point(501, 12);
            this.btn_backup_browse.Name = "btn_backup_browse";
            this.btn_backup_browse.Size = new System.Drawing.Size(84, 47);
            this.btn_backup_browse.TabIndex = 8;
            this.btn_backup_browse.Text = "Browse";
            this.btn_backup_browse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_backup_browse.UseVisualStyleBackColor = false;
            this.btn_backup_browse.Click += new System.EventHandler(this.btn_backup_browse_Click);
            // 
            // txt_backup_loaction
            // 
            this.txt_backup_loaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_backup_loaction.Location = new System.Drawing.Point(121, 55);
            this.txt_backup_loaction.Name = "txt_backup_loaction";
            this.txt_backup_loaction.Size = new System.Drawing.Size(357, 27);
            this.txt_backup_loaction.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_restore);
            this.groupBox3.Controls.Add(this.btn_restore_browse);
            this.groupBox3.Controls.Add(this.txtrestore_location);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 475);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(594, 125);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Restore";
            // 
            // btn_restore
            // 
            this.btn_restore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_restore.FlatAppearance.BorderSize = 0;
            this.btn_restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restore.ForeColor = System.Drawing.Color.White;
            this.btn_restore.Image = global::POS_System.Properties.Resources.backup;
            this.btn_restore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_restore.Location = new System.Drawing.Point(501, 72);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(84, 47);
            this.btn_restore.TabIndex = 9;
            this.btn_restore.Text = "Restore";
            this.btn_restore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_restore.UseVisualStyleBackColor = false;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_restore_browse
            // 
            this.btn_restore_browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btn_restore_browse.FlatAppearance.BorderSize = 0;
            this.btn_restore_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restore_browse.ForeColor = System.Drawing.Color.White;
            this.btn_restore_browse.Image = global::POS_System.Properties.Resources.open_folder;
            this.btn_restore_browse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_restore_browse.Location = new System.Drawing.Point(501, 16);
            this.btn_restore_browse.Name = "btn_restore_browse";
            this.btn_restore_browse.Size = new System.Drawing.Size(84, 47);
            this.btn_restore_browse.TabIndex = 8;
            this.btn_restore_browse.Text = "Browse";
            this.btn_restore_browse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_restore_browse.UseVisualStyleBackColor = false;
            this.btn_restore_browse.Click += new System.EventHandler(this.btn_restore_browse_Click);
            // 
            // txtrestore_location
            // 
            this.txtrestore_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrestore_location.Location = new System.Drawing.Point(123, 58);
            this.txtrestore_location.Name = "txtrestore_location";
            this.txtrestore_location.Size = new System.Drawing.Size(357, 27);
            this.txtrestore_location.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Location";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(81)))), ((int)(((byte)(126)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(611, 73);
            this.panel4.TabIndex = 109;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS_System.Properties.Resources.database_sign;
            this.pictureBox1.Location = new System.Drawing.Point(147, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(221, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(227, 39);
            this.label23.TabIndex = 18;
            this.label23.Text = "Back Up Data";
            // 
            // DatabaseBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(611, 603);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Up";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.btn_connect.ResumeLayout(false);
            this.btn_connect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox btn_connect;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser_id;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_database_name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_backup_loaction;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_backup_browse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_restore_browse;
        private System.Windows.Forms.TextBox txtrestore_location;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_server_name;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

