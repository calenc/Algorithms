namespace homework1
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
            this.OpenTextFileBtn = new System.Windows.Forms.Button();
            this.OpenBinaryFileBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenTextFileBtn
            // 
            this.OpenTextFileBtn.Location = new System.Drawing.Point(21, 12);
            this.OpenTextFileBtn.Name = "OpenTextFileBtn";
            this.OpenTextFileBtn.Size = new System.Drawing.Size(134, 23);
            this.OpenTextFileBtn.TabIndex = 0;
            this.OpenTextFileBtn.Text = "OpenTextFile";
            this.OpenTextFileBtn.UseVisualStyleBackColor = true;
            this.OpenTextFileBtn.Click += new System.EventHandler(this.OpenTextFileBtn_Click);
            // 
            // OpenBinaryFileBtn
            // 
            this.OpenBinaryFileBtn.Location = new System.Drawing.Point(21, 67);
            this.OpenBinaryFileBtn.Name = "OpenBinaryFileBtn";
            this.OpenBinaryFileBtn.Size = new System.Drawing.Size(134, 23);
            this.OpenBinaryFileBtn.TabIndex = 1;
            this.OpenBinaryFileBtn.Text = "Open Binary File";
            this.OpenBinaryFileBtn.UseVisualStyleBackColor = true;
            this.OpenBinaryFileBtn.Click += new System.EventHandler(this.OpenBinaryFileBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(572, 216);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 337);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OpenBinaryFileBtn);
            this.Controls.Add(this.OpenTextFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenTextFileBtn;
        private System.Windows.Forms.Button OpenBinaryFileBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}

