using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abd
{
    public partial class FrmDatabaseSQLite : Form
    {
        public FrmDatabaseSQLite(TreeView treedatabases)
        {
            InitializeComponent();
            this.treedatabases = treedatabases;
        }
        private TreeView treedatabases;

        private void tVdata_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SQLiteConnection SQLiteconect = FrmSessionManager.SQLiteconect;
            try
            {
                //SQLiteconect.Database.ToString();
                string bd = "SELECT name FROM sqlite_master WHERE type = 'table'";
                SQLiteCommand SQLiteCommand = new SQLiteCommand(); //comando
                SQLiteCommand.CommandText = bd; //comando a ejecutar
                SQLiteconect.Open();
                SQLiteCommand.Connection = SQLiteconect;
                SQLiteCommand.ExecuteNonQuery();
                SQLiteDataReader lector = SQLiteCommand.ExecuteReader();
                if (tVdata.Nodes[tVdata.SelectedNode.Index].Nodes.Count >= 1)
                {
                    tVdata.Nodes[tVdata.SelectedNode.Index].Nodes.Clear();
                }
                else
                {
                    while (lector.Read())
                    {
                        tVdata.Nodes[tVdata.SelectedNode.Index].Nodes.Add(lector.GetString(0));
                    }
                }
                lector.Close();
                SQLiteconect.Close();
            }
            catch (SQLiteException error)
            {
                //MessageBox.Show("Server Down "+error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SQLiteconect.Close();
            }
        }

        private void FrmDatabaseSQLite_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < treedatabases.Nodes.Count; i++)
            {
                tVdata.Nodes.Add(treedatabases.Nodes[i].ToString().Remove(0, 9));
            }
        }
    }
}
