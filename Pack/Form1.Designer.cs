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
            this.chk_binonly = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chk_auto = new System.Windows.Forms.CheckBox();
            this.delAfterD = new System.Windows.Forms.CheckBox();
            this.cNoprint = new System.Windows.Forms.CheckBox();
            this.pBar1 = new System.Windows.Forms.ProgressBar();
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
            // chk_binonly
            // 
            this.chk_binonly.AutoSize = true;
            this.chk_binonly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_binonly.Location = new System.Drawing.Point(248, 35);
            this.chk_binonly.Name = "chk_binonly";
            this.chk_binonly.Size = new System.Drawing.Size(146, 17);
            this.chk_binonly.TabIndex = 5;
            this.chk_binonly.Text = "Force .bin Extension Only";
            this.chk_binonly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_binonly.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear Textbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearTextbox);
            // 
            // chk_auto
            // 
            this.chk_auto.AutoSize = true;
            this.chk_auto.Checked = true;
            this.chk_auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_auto.Location = new System.Drawing.Point(12, 35);
            this.chk_auto.Name = "chk_auto";
            this.chk_auto.Size = new System.Drawing.Size(148, 17);
            this.chk_auto.TabIndex = 7;
            this.chk_auto.Text = "Auto Extract on DragDrop";
            this.chk_auto.UseVisualStyleBackColor = true;
            // 
            // delAfterD
            // 
            this.delAfterD.AutoSize = true;
            this.delAfterD.Checked = true;
            this.delAfterD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.delAfterD.Location = new System.Drawing.Point(12, 52);
            this.delAfterD.Name = "delAfterD";
            this.delAfterD.Size = new System.Drawing.Size(164, 17);
            this.delAfterD.TabIndex = 8;
            this.delAfterD.Text = "Only Un/Decompressed Files";
            this.delAfterD.UseVisualStyleBackColor = true;
            // 
            // cNoprint
            // 
            this.cNoprint.AutoSize = true;
            this.cNoprint.Location = new System.Drawing.Point(214, 53);
            this.cNoprint.Name = "cNoprint";
            this.cNoprint.Size = new System.Drawing.Size(89, 17);
            this.cNoprint.TabIndex = 9;
            this.cNoprint.Text = "Don\'t printout";
            this.cNoprint.UseVisualStyleBackColor = true;
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(11, 249);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(382, 10);
            this.pBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 262);
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.cNoprint);
            this.Controls.Add(this.delAfterD);
            this.Controls.Add(this.chk_auto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chk_binonly);
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
        private System.Windows.Forms.CheckBox chk_binonly;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chk_auto;
        private System.Windows.Forms.CheckBox delAfterD;
        private System.Windows.Forms.CheckBox cNoprint;
        private System.Windows.Forms.ProgressBar pBar1;
    }
}

