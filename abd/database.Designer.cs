namespace abd
{
    partial class database
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
            this.dGVdatabase = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVdatabase)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVdatabase
            // 
            this.dGVdatabase.AllowUserToAddRows = false;
            this.dGVdatabase.AllowUserToDeleteRows = false;
            this.dGVdatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVdatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dGVdatabase.Location = new System.Drawing.Point(1, 1);
            this.dGVdatabase.Name = "dGVdatabase";
            this.dGVdatabase.ReadOnly = true;
            this.dGVdatabase.Size = new System.Drawing.Size(282, 439);
            this.dGVdatabase.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Databases";
            this.Column1.Name = "Column1";
            // 
            // database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dGVdatabase);
            this.Name = "database";
            this.Text = "database";
            this.Load += new System.EventHandler(this.database_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVdatabase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVdatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}