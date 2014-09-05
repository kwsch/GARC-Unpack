namespace Pack
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
            this.B_Open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.B_Go = new System.Windows.Forms.Button();
            this.CHK_ForceBIN = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CHK_AutoExtract = new System.Windows.Forms.CheckBox();
            this.CHK_delAfterD = new System.Windows.Forms.CheckBox();
            this.CHK_NoPrint = new System.Windows.Forms.CheckBox();
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.CHK_SkipDecompress = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(12, 9);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(51, 23);
            this.B_Open.TabIndex = 0;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(69, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(290, 20);
            this.textBox1.TabIndex = 1;
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(12, 72);
            this.RTB.Name = "RTB";
            this.RTB.ReadOnly = true;
            this.RTB.Size = new System.Drawing.Size(382, 171);
            this.RTB.TabIndex = 2;
            this.RTB.Text = "";
            this.RTB.WordWrap = false;
            // 
            // B_Go
            // 
            this.B_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Go.Location = new System.Drawing.Point(365, 9);
            this.B_Go.Name = "B_Go";
            this.B_Go.Size = new System.Drawing.Size(29, 23);
            this.B_Go.TabIndex = 3;
            this.B_Go.Text = "Go";
            this.B_Go.UseVisualStyleBackColor = true;
            this.B_Go.Click += new System.EventHandler(this.B_Go_Click);
            // 
            // CHK_ForceBIN
            // 
            this.CHK_ForceBIN.AutoSize = true;
            this.CHK_ForceBIN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_ForceBIN.Location = new System.Drawing.Point(319, 35);
            this.CHK_ForceBIN.Name = "CHK_ForceBIN";
            this.CHK_ForceBIN.Size = new System.Drawing.Size(73, 17);
            this.CHK_ForceBIN.TabIndex = 5;
            this.CHK_ForceBIN.Text = "Force .bin";
            this.CHK_ForceBIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_ForceBIN.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearTextbox);
            // 
            // CHK_AutoExtract
            // 
            this.CHK_AutoExtract.AutoSize = true;
            this.CHK_AutoExtract.Checked = true;
            this.CHK_AutoExtract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_AutoExtract.Location = new System.Drawing.Point(12, 35);
            this.CHK_AutoExtract.Name = "CHK_AutoExtract";
            this.CHK_AutoExtract.Size = new System.Drawing.Size(148, 17);
            this.CHK_AutoExtract.TabIndex = 7;
            this.CHK_AutoExtract.Text = "Auto Extract on DragDrop";
            this.CHK_AutoExtract.UseVisualStyleBackColor = true;
            // 
            // CHK_delAfterD
            // 
            this.CHK_delAfterD.AutoSize = true;
            this.CHK_delAfterD.Checked = true;
            this.CHK_delAfterD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_delAfterD.Location = new System.Drawing.Point(12, 52);
            this.CHK_delAfterD.Name = "CHK_delAfterD";
            this.CHK_delAfterD.Size = new System.Drawing.Size(164, 17);
            this.CHK_delAfterD.TabIndex = 8;
            this.CHK_delAfterD.Text = "Only Un/Decompressed Files";
            this.CHK_delAfterD.UseVisualStyleBackColor = true;
            // 
            // CHK_NoPrint
            // 
            this.CHK_NoPrint.AutoSize = true;
            this.CHK_NoPrint.Location = new System.Drawing.Point(193, 52);
            this.CHK_NoPrint.Name = "CHK_NoPrint";
            this.CHK_NoPrint.Size = new System.Drawing.Size(89, 17);
            this.CHK_NoPrint.TabIndex = 9;
            this.CHK_NoPrint.Text = "Don\'t printout";
            this.CHK_NoPrint.UseVisualStyleBackColor = true;
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(11, 249);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(382, 10);
            this.pBar1.TabIndex = 10;
            // 
            // CHK_SkipDecompress
            // 
            this.CHK_SkipDecompress.AutoSize = true;
            this.CHK_SkipDecompress.Location = new System.Drawing.Point(193, 35);
            this.CHK_SkipDecompress.Name = "CHK_SkipDecompress";
            this.CHK_SkipDecompress.Size = new System.Drawing.Size(113, 17);
            this.CHK_SkipDecompress.TabIndex = 11;
            this.CHK_SkipDecompress.Text = "Don\'t Decompress";
            this.CHK_SkipDecompress.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 262);
            this.Controls.Add(this.CHK_SkipDecompress);
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.CHK_NoPrint);
            this.Controls.Add(this.CHK_delAfterD);
            this.Controls.Add(this.CHK_AutoExtract);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CHK_ForceBIN);
            this.Controls.Add(this.B_Go);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.B_Open);
            this.MinimumSize = new System.Drawing.Size(420, 300);
            this.Name = "Form1";
            this.Text = "GARC Unpacker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Button B_Go;
        private System.Windows.Forms.CheckBox CHK_ForceBIN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CHK_AutoExtract;
        private System.Windows.Forms.CheckBox CHK_delAfterD;
        private System.Windows.Forms.CheckBox CHK_NoPrint;
        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.CheckBox CHK_SkipDecompress;
    }
}

