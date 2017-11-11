using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace abd
{
    public partial class FrmDatabasePostgreSQL : Form
    {
        private TreeView treedatabases;
        public FrmDatabasePostgreSQL(TreeView treedatabases)
        {
            InitializeComponent();
            this.treedatabases = treedatabases;
        }

        private void database_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < treedatabases.Nodes.Count; i++)
            {
                tVdata.Nodes.Add(treedatabases.Nodes[i].ToString());
            }
        }

        private void tVdata_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NpgsqlConnection npgsqlConnection = FrmSessionManager.npgsqlConnection;
            try
            {
                string bd = "SELECT table_name FROM " + tVdata.SelectedNode.Text + "";
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(); //comando
                npgsqlCommand.CommandText = bd; //comando a ejecutar
                npgsqlConnection.Open();
                npgsqlCommand.Connection = npgsqlConnection;
                npgsqlCommand.ExecuteNonQuery();
                NpgsqlDataReader lector = npgsqlCommand.ExecuteReader();
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
                npgsqlConnection.Close();
            }
            catch (NpgsqlException error)
            {
                //MessageBox.Show("Server Down "+error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                npgsqlConnection.Close();
            }
        }
    }
}