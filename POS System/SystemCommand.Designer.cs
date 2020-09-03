namespace POS_System
{
    partial class SystemCommand
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
            this.btn_run = new DevComponents.DotNetBar.ButtonX();
            this.commandLine = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_run.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(404, 367);
            this.btn_run.Name = "btn_run";
            this.btn_run.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_run.Size = new System.Drawing.Size(91, 37);
            this.btn_run.TabIndex = 274;
            this.btn_run.Text = "Run";
            this.btn_run.Click += new System.EventHandler(this.btn_takeaway_Click);
            // 
            // commandLine
            // 
            this.commandLine.AcceptsTab = true;
            this.commandLine.BackColor = System.Drawing.SystemColors.MenuText;
            this.commandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandLine.ForeColor = System.Drawing.Color.Lime;
            this.commandLine.Location = new System.Drawing.Point(1, 0);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(500, 364);
            this.commandLine.TabIndex = 275;
            this.commandLine.Text = "";
            // 
            // SystemCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(500, 407);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.btn_run);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemCommand";
            this.Text = "SystemCommand";
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX btn_run;
        private System.Windows.Forms.RichTextBox commandLine;
    }
}