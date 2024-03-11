namespace DiaSync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkedListBox1 = new CheckedListBox();
            btFetch = new Button();
            btUpdate = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(384, 346);
            checkedListBox1.TabIndex = 0;
            // 
            // btFetch
            // 
            btFetch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btFetch.Location = new Point(12, 365);
            btFetch.Name = "btFetch";
            btFetch.Size = new Size(149, 45);
            btFetch.TabIndex = 1;
            btFetch.Text = "Frissítési lista elkészítése";
            btFetch.UseVisualStyleBackColor = true;
            btFetch.Click += btFetch_ClickAsync;
            // 
            // btUpdate
            // 
            btUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btUpdate.Location = new Point(247, 365);
            btUpdate.Name = "btUpdate";
            btUpdate.Size = new Size(149, 45);
            btUpdate.TabIndex = 1;
            btUpdate.Text = "Kijelöltek frissítése";
            btUpdate.UseVisualStyleBackColor = true;
            btUpdate.Click += btUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 422);
            Controls.Add(btUpdate);
            Controls.Add(btFetch);
            Controls.Add(checkedListBox1);
            Name = "Form1";
            Text = "DiaSync";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button btFetch;
        private Button btUpdate;
    }
}