namespace abd
{
    partial class Conexion
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dUDport = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHOST = new System.Windows.Forms.TextBox();
            this.tBuser = new System.Windows.Forms.TextBox();
            this.tBpass = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tBdatabase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manager:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "MySQL"});
            this.comboBox1.Location = new System.Drawing.Point(119, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host Name/IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // dUDport
            // 
            this.dUDport.Location = new System.Drawing.Point(119, 157);
            this.dUDport.Name = "dUDport";
            this.dUDport.Size = new System.Drawing.Size(121, 20);
            this.dUDport.TabIndex = 5;
            this.dUDport.Text = "3306";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Port:";
            // 
            // txtHOST
            // 
            this.txtHOST.Location = new System.Drawing.Point(119, 59);
            this.txtHOST.Name = "txtHOST";
            this.txtHOST.Size = new System.Drawing.Size(121, 20);
            this.txtHOST.TabIndex = 7;
            this.txtHOST.Text = "127.0.0.1";
            // 
            // tBuser
            // 
            this.tBuser.Location = new System.Drawing.Point(119, 97);
            this.tBuser.Name = "tBuser";
            this.tBuser.Size = new System.Drawing.Size(121, 20);
            this.tBuser.TabIndex = 8;
            // 
            // tBpass
            // 
            this.tBpass.Location = new System.Drawing.Point(119, 130);
            this.tBpass.Name = "tBpass";
            this.tBpass.PasswordChar = '*';
            this.tBpass.Size = new System.Drawing.Size(121, 20);
            this.tBpass.TabIndex = 9;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(359, 205);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 10;
            this.btnConectar.Text = "Connect";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Database";
            // 
            // tBdatabase
            // 
            this.tBdatabase.Location = new System.Drawing.Point(119, 187);
            this.tBdatabase.Name = "tBdatabase";
            this.tBdatabase.Size = new System.Drawing.Size(121, 20);
            this.tBdatabase.TabIndex = 12;
            // 
            // Coneccion
            // 
            this.AcceptButton = this.btnConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 242);
            this.Controls.Add(this.tBdatabase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.tBpass);
            this.Controls.Add(this.tBuser);
            this.Controls.Add(this.txtHOST);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dUDport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Coneccion";
            this.Text = "Session Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DomainUpDown dUDport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHOST;
        private System.Windows.Forms.TextBox tBuser;
        private System.Windows.Forms.TextBox tBpass;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBdatabase;
    }
}

