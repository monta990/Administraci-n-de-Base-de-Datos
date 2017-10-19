namespace abd
{
    partial class FrmDatabaseMySQL
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
            this.tVdata = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tVdata
            // 
            this.tVdata.Location = new System.Drawing.Point(2, 3);
            this.tVdata.Name = "tVdata";
            this.tVdata.Size = new System.Drawing.Size(367, 356);
            this.tVdata.TabIndex = 2;
            this.tVdata.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // FrmDatabaseMySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 364);
            this.Controls.Add(this.tVdata);
            this.Name = "FrmDatabaseMySQL";
            this.Text = "database";
            this.Load += new System.EventHandler(this.database_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView tVdata;
    }
}