
namespace BMSys
{
    partial class admincs
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtpw = new System.Windows.Forms.TextBox();
            this.btnAlogin = new System.Windows.Forms.Button();
            this.lblcancel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 32);
            this.label1.TabIndex = 62;
            this.label1.Text = "Password :";
            // 
            // txtpw
            // 
            this.txtpw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpw.Location = new System.Drawing.Point(256, 289);
            this.txtpw.Name = "txtpw";
            this.txtpw.Size = new System.Drawing.Size(306, 28);
            this.txtpw.TabIndex = 63;
            // 
            // btnAlogin
            // 
            this.btnAlogin.BackColor = System.Drawing.Color.Olive;
            this.btnAlogin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlogin.ForeColor = System.Drawing.Color.White;
            this.btnAlogin.Location = new System.Drawing.Point(320, 390);
            this.btnAlogin.Name = "btnAlogin";
            this.btnAlogin.Size = new System.Drawing.Size(188, 42);
            this.btnAlogin.TabIndex = 64;
            this.btnAlogin.Text = "Login";
            this.btnAlogin.UseVisualStyleBackColor = false;
            this.btnAlogin.Click += new System.EventHandler(this.btnAlogin_Click);
            // 
            // lblcancel
            // 
            this.lblcancel.AutoSize = true;
            this.lblcancel.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcancel.ForeColor = System.Drawing.Color.White;
            this.lblcancel.Location = new System.Drawing.Point(351, 447);
            this.lblcancel.Name = "lblcancel";
            this.lblcancel.Size = new System.Drawing.Size(83, 26);
            this.lblcancel.TabIndex = 65;
            this.lblcancel.Text = "Cancel";
            this.lblcancel.Click += new System.EventHandler(this.lblcancel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BMSys.Properties.Resources.booklogo;
            this.pictureBox2.Location = new System.Drawing.Point(320, 125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(188, 133);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 66;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(265, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 55);
            this.label2.TabIndex = 67;
            this.label2.Text = "Admin Login";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.chb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblcancel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnAlogin);
            this.panel1.Controls.Add(this.txtpw);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 504);
            this.panel1.TabIndex = 68;
            // 
            // chb
            // 
            this.chb.AutoSize = true;
            this.chb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb.ForeColor = System.Drawing.Color.White;
            this.chb.Location = new System.Drawing.Point(256, 332);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(178, 26);
            this.chb.TabIndex = 68;
            this.chb.Text = "Show Password";
            this.chb.UseVisualStyleBackColor = true;
            this.chb.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // admincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(788, 528);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admincs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admincs";
            this.Load += new System.EventHandler(this.admincs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpw;
        private System.Windows.Forms.Button btnAlogin;
        private System.Windows.Forms.Label lblcancel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chb;
    }
}