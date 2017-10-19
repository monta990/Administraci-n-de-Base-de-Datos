using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace abd
{
    public partial class FrmDatabaseMySQL : Form
    {
        public FrmDatabaseMySQL(TreeView treedatabases)
        {
            InitializeComponent();
            this.treedatabases = treedatabases;
        }
        private TreeView treedatabases;
        private void database_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < treedatabases.Nodes.Count; i++)
            {
                tVdata.Nodes.Add(treedatabases.Nodes[i].ToString().Remove(0,9));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MySqlConnection mySqlConnection = SessionManager.mySqlConnection;
            try
            {
                string bd = "USE " + tVdata.SelectedNode.Text + "; SHOW TABLES";
                MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                mySqlCommand.CommandText = bd; //comando a ejecutar
                mySqlConnection.Open();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.ExecuteNonQuery();
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
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
                mySqlConnection.Close();
            }
            catch (MySqlException error)
            {
                //MessageBox.Show("Server Down "+error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mySqlConnection.Close();
            }
        }
    }
}