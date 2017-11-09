namespace abd
{
    partial class FrmSessionManager
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
            this.cBdbm = new System.Windows.Forms.ComboBox();
            this.lbIP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dUDport = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tBhost = new System.Windows.Forms.TextBox();
            this.tBuser = new System.Windows.Forms.TextBox();
            this.tBpass = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBdatabases = new System.Windows.Forms.ComboBox();
            this.btTest = new System.Windows.Forms.Button();
            this.btSelectBD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manager:";
            // 
            // cBdbm
            // 
            this.cBdbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBdbm.FormattingEnabled = true;
            this.cBdbm.Items.AddRange(new object[] {
            "MySQL",
            "PostgreSQL",
            "MSSQL",
            "SQLite",
            "MongoDB",
            "RavenDB"});
            this.cBdbm.Location = new System.Drawing.Point(112, 29);
            this.cBdbm.Name = "cBdbm";
            this.cBdbm.Size = new System.Drawing.Size(188, 21);
            this.cBdbm.TabIndex = 1;
            this.cBdbm.SelectedIndexChanged += new System.EventHandler(this.cBdbm_SelectedIndexChanged);
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(6, 68);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(78, 13);
            this.lbIP.TabIndex = 2;
            this.lbIP.Text = "Host Name/IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // dUDport
            // 
            this.dUDport.Location = new System.Drawing.Point(112, 163);
            this.dUDport.Name = "dUDport";
            this.dUDport.Size = new System.Drawing.Size(60, 20);
            this.dUDport.TabIndex = 5;
            this.dUDport.Text = "3306";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Port:";
            // 
            // tBhost
            // 
            this.tBhost.Location = new System.Drawing.Point(112, 65);
            this.tBhost.Name = "tBhost";
            this.tBhost.Size = new System.Drawing.Size(145, 20);
            this.tBhost.TabIndex = 7;
            this.tBhost.Text = "127.0.0.1";
            // 
            // tBuser
            // 
            this.tBuser.Location = new System.Drawing.Point(112, 103);
            this.tBuser.Name = "tBuser";
            this.tBuser.Size = new System.Drawing.Size(188, 20);
            this.tBuser.TabIndex = 8;
            // 
            // tBpass
            // 
            this.tBpass.Location = new System.Drawing.Point(112, 136);
            this.tBpass.Name = "tBpass";
            this.tBpass.PasswordChar = '*';
            this.tBpass.Size = new System.Drawing.Size(188, 20);
            this.tBpass.TabIndex = 9;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(225, 225);
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
            this.label6.Location = new System.Drawing.Point(5, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Database";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(6, 225);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBdatabases);
            this.groupBox1.Controls.Add(this.btTest);
            this.groupBox1.Controls.Add(this.btSelectBD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.cBdbm);
            this.groupBox1.Controls.Add(this.lbIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tBpass);
            this.groupBox1.Controls.Add(this.dUDport);
            this.groupBox1.Controls.Add(this.tBuser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tBhost);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 258);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Session";
            // 
            // cBdatabases
            // 
            this.cBdatabases.FormattingEnabled = true;
            this.cBdatabases.Location = new System.Drawing.Point(112, 193);
            this.cBdatabases.Name = "cBdatabases";
            this.cBdatabases.Size = new System.Drawing.Size(188, 21);
            this.cBdatabases.TabIndex = 16;
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(112, 225);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 15;
            this.btTest.Text = "Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // btSelectBD
            // 
            this.btSelectBD.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSelectBD.Image = global::abd.Properties.Resources.Folder;
            this.btSelectBD.Location = new System.Drawing.Point(263, 63);
            this.btSelectBD.Name = "btSelectBD";
            this.btSelectBD.Size = new System.Drawing.Size(37, 23);
            this.btSelectBD.TabIndex = 14;
            this.btSelectBD.UseVisualStyleBackColor = false;
            this.btSelectBD.Click += new System.EventHandler(this.btSelectBD_Click);
            // 
            // SessionManager
            // 
            this.AcceptButton = this.btnConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(326, 276);
            this.Controls.Add(this.groupBox1);
            this.Name = "SessionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Session Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBdbm;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DomainUpDown dUDport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBhost;
        private System.Windows.Forms.TextBox tBuser;
        private System.Windows.Forms.TextBox tBpass;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSelectBD;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.ComboBox cBdatabases;
    }
}

