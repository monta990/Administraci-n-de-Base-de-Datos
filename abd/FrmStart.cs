﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abd
{
    public partial class FrmStart : Form
    {
        //private int childFormNumber = 0;

        public FrmStart()
        {
            InitializeComponent();
        }

        static public void ShowFrmDatabaseMySQL(TreeView treedatabases) //lanzar selector de base de datos MySQL
        {
            FrmDatabaseMySQL childForm = new FrmDatabaseMySQL(treedatabases);
            childForm.MdiParent = Application.OpenForms[0];
            childForm.Text = "Databases MySQL";
            childForm.Height = Application.OpenForms[0].Height -
                                Application.OpenForms[0].Controls[0].Height -
                                Application.OpenForms[0].Controls[1].Height - 
                                Application.OpenForms[0].Controls[2].Height - 45;
            childForm.Width = 380;
            childForm.Show();
        }
        static public void ShowFrmDatabaseMSSQL(TreeView treedatabases) //lanzar selector de base de datos MySQL
        {
            FrmDatabaseMsSQL childForm = new FrmDatabaseMsSQL(treedatabases);
            childForm.MdiParent = Application.OpenForms[0];
            childForm.Text = "Databases MSSQL";
            childForm.Height = Application.OpenForms[0].Height -
                                Application.OpenForms[0].Controls[0].Height -
                                Application.OpenForms[0].Controls[1].Height -
                                Application.OpenForms[0].Controls[2].Height - 45;
            childForm.Width = 380;
            childForm.Show();
        }
        static public void ShowFrmDatabaseSQLite(TreeView treedatabases) //lanzar selector de base de datos MySQL
        {
            FrmDatabaseSQLite childForm = new FrmDatabaseSQLite(treedatabases);
            childForm.MdiParent = Application.OpenForms[0];
            childForm.Text = "Database SQLite";
            childForm.Height = Application.OpenForms[0].Height -
                                Application.OpenForms[0].Controls[0].Height -
                                Application.OpenForms[0].Controls[1].Height -
                                Application.OpenForms[0].Controls[2].Height - 45;
            childForm.Width = 380;
            childForm.Show();
        }
        static public void ShowFrmDatabasePostgreSQL(TreeView treedatabases) //lanzar selector de base de datos MySQL
        {
            FrmDatabasePostgreSQL childForm = new FrmDatabasePostgreSQL(treedatabases);
            childForm.MdiParent = Application.OpenForms[0];
            childForm.Text = "Databases PostgreSQL";
            childForm.Height = Application.OpenForms[0].Height -
                                Application.OpenForms[0].Controls[0].Height -
                                Application.OpenForms[0].Controls[1].Height -
                                Application.OpenForms[0].Controls[2].Height - 45;
            childForm.Width = 380;
            childForm.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            new FrmSessionManager().ShowDialog();
            #region code to create new childform
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
            #endregion
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            
        }
    }
}
