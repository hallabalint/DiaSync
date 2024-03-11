namespace DiaSync
{
    partial class StatusBar
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
            pb1 = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // pb1
            // 
            pb1.Location = new Point(12, 36);
            pb1.Name = "pb1";
            pb1.Size = new Size(230, 23);
            pb1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 70);
            Controls.Add(label1);
            Controls.Add(pb1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(270, 109);
            MinimumSize = new Size(270, 109);
            Name = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pb1;
        private Label label1;
    }
}