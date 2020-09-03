namespace POS_System
{
    partial class Item_modifier_list
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
            this.flw_mdPanel = new DevComponents.DotNetBar.PanelEx();
            this.flow_modifier = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_normal = new DevComponents.DotNetBar.ButtonX();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_cross = new DevComponents.DotNetBar.ButtonX();
            this.flw_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.flw_mdPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flw_mdPanel
            // 
            this.flw_mdPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.flw_mdPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.flw_mdPanel.Controls.Add(this.flow_modifier);
            this.flw_mdPanel.Controls.Add(this.flowLayoutPanel1);
            this.flw_mdPanel.Controls.Add(this.flw_pnl);
            this.flw_mdPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.flw_mdPanel.Location = new System.Drawing.Point(-1, 2);
            this.flw_mdPanel.Name = "flw_mdPanel";
            this.flw_mdPanel.Size = new System.Drawing.Size(291, 368);
            this.flw_mdPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.flw_mdPanel.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.flw_mdPanel.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.flw_mdPanel.Style.BorderColor.Color = System.Drawing.Color.Transparent;
            this.flw_mdPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.flw_mdPanel.Style.ForeColor.Color = System.Drawing.Color.Transparent;
            this.flw_mdPanel.Style.GradientAngle = 90;
            this.flw_mdPanel.TabIndex = 398;
            this.flw_mdPanel.Text = "panelEx3";
            // 
            // flow_modifier
            // 
            this.flow_modifier.AutoScroll = true;
            this.flow_modifier.Location = new System.Drawing.Point(0, 0);
            this.flow_modifier.Name = "flow_modifier";
            this.flow_modifier.Size = new System.Drawing.Size(291, 314);
            this.flow_modifier.TabIndex = 406;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_normal);
            this.flowLayoutPanel1.Controls.Add(this.btn_ok);
            this.flowLayoutPanel1.Controls.Add(this.btn_cross);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 317);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(291, 51);
            this.flowLayoutPanel1.TabIndex = 405;
            // 
            // btn_normal
            // 
            this.btn_normal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_normal.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_normal.Location = new System.Drawing.Point(3, 3);
            this.btn_normal.Name = "btn_normal";
            this.btn_normal.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_normal.Size = new System.Drawing.Size(96, 39);
            this.btn_normal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_normal.TabIndex = 0;
            this.btn_normal.Text = "Normal";
            this.btn_normal.Click += new System.EventHandler(this.btn_normal_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(105, 3);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_ok.Size = new System.Drawing.Size(100, 39);
            this.btn_ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ok.Symbol = "";
            this.btn_ok.TabIndex = 406;
            this.btn_ok.Text = "Ok";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cross
            // 
            this.btn_cross.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cross.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btn_cross.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cross.Location = new System.Drawing.Point(211, 3);
            this.btn_cross.Name = "btn_cross";
            this.btn_cross.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.btn_cross.Size = new System.Drawing.Size(69, 39);
            this.btn_cross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cross.Symbol = "";
            this.btn_cross.TabIndex = 407;
            this.btn_cross.Click += new System.EventHandler(this.btn_cross_Click);
            // 
            // flw_pnl
            // 
            this.flw_pnl.AutoSize = true;
            this.flw_pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flw_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.flw_pnl.Location = new System.Drawing.Point(0, 0);
            this.flw_pnl.Name = "flw_pnl";
            this.flw_pnl.Size = new System.Drawing.Size(291, 0);
            this.flw_pnl.TabIndex = 404;
            // 
            // Item_modifier_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 374);
            this.Controls.Add(this.flw_mdPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Item_modifier_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_modifier_list";
            this.Load += new System.EventHandler(this.Item_modifier_list_Load);
            this.flw_mdPanel.ResumeLayout(false);
            this.flw_mdPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx flw_mdPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flw_pnl;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.ButtonX btn_normal;
        private System.Windows.Forms.FlowLayoutPanel flow_modifier;
        private DevComponents.DotNetBar.ButtonX btn_cross;
    }
}