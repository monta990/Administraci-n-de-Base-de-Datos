using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abd
{
    public partial class FrmDatabaseMsSQL : Form
    {
        public FrmDatabaseMsSQL(TreeView treedatabases)
        {
            InitializeComponent();
            this.treedatabases = treedatabases;
        }
        private TreeView treedatabases;

        private void tVdata_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SqlConnection SqlConnection = SessionManager.SqlConnection;
            try
            {
                string bd = "USE " + tVdata.SelectedNode.Text + "; SHOW TABLES";
                SqlCommand SqlCommand = new SqlCommand(); //comando
                SqlCommand.CommandText = bd; //comando a ejecutar
                SqlConnection.Open();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.ExecuteNonQuery();
                SqlDataReader lector = SqlCommand.ExecuteReader();
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
                SqlConnection.Close();
            }
            catch (SqlException error)
            {
                //MessageBox.Show("Server Down "+error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection.Close();
            }
        }

        private void FrmDatabaseMsSQL_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < treedatabases.Nodes.Count; i++)
            {
                tVdata.Nodes.Add(treedatabases.Nodes[i].ToString().Remove(0, 9));
            }
        }
    }
}
