namespace POS_System
{
    partial class NoteItem
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
            this.txt_rich_note = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_rich_note
            // 
            this.txt_rich_note.Location = new System.Drawing.Point(0, 1);
            this.txt_rich_note.Name = "txt_rich_note";
            this.txt_rich_note.Size = new System.Drawing.Size(283, 77);
            this.txt_rich_note.TabIndex = 0;
            this.txt_rich_note.Text = "";
            this.txt_rich_note.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // NoteItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 83);
            this.Controls.Add(this.txt_rich_note);
            this.Name = "NoteItem";
            this.Text = "NoteItem";
            this.Load += new System.EventHandler(this.NoteItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_rich_note;
    }
}