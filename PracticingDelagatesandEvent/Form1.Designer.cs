namespace PracticingDelagatesandEvent
{
    partial class Form1
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
            this.studentCard1 = new PracticingDelagatesandEvent.StudentCard();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // studentCard1
            // 
            this.studentCard1.Location = new System.Drawing.Point(327, 14);
            this.studentCard1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.studentCard1.Name = "studentCard1";
            this.studentCard1.Size = new System.Drawing.Size(235, 318);
            this.studentCard1.TabIndex = 0;
            this.studentCard1.StudentSaved += new System.Action<PracticingDelagatesandEvent.StudentCard.Student>(this.studentCard1_StudentSaved);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(370, 237);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 68);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 346);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.studentCard1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private StudentCard studentCard1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

