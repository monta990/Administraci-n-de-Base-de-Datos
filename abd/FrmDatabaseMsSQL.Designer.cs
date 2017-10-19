namespace abd
{
    partial class FrmDatabaseMsSQL
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
            this.dGVtables = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVdatabase = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVtables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVdatabase)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVtables
            // 
            this.dGVtables.AllowUserToAddRows = false;
            this.dGVtables.AllowUserToDeleteRows = false;
            this.dGVtables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVtables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVtables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dGVtables.Location = new System.Drawing.Point(2, 180);
            this.dGVtables.Name = "dGVtables";
            this.dGVtables.ReadOnly = true;
            this.dGVtables.Size = new System.Drawing.Size(363, 175);
            this.dGVtables.TabIndex = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tables of ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dGVdatabase
            // 
            this.dGVdatabase.AllowUserToAddRows = false;
            this.dGVdatabase.AllowUserToDeleteRows = false;
            this.dGVdatabase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVdatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVdatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dGVdatabase.Location = new System.Drawing.Point(2, 0);
            this.dGVdatabase.Name = "dGVdatabase";
            this.dGVdatabase.ReadOnly = true;
            this.dGVdatabase.Size = new System.Drawing.Size(363, 175);
            this.dGVdatabase.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Databases";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // FrmDatabaseMsSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 357);
            this.Controls.Add(this.dGVtables);
            this.Controls.Add(this.dGVdatabase);
            this.Name = "FrmDatabaseMsSQL";
            this.Text = "FrmDatabaseMsSQL";
            ((System.ComponentModel.ISupportInitialize)(this.dGVtables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVdatabase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVtables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dGVdatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}