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
        public FrmDatabaseMySQL(DataGridView dblist)
        {
            InitializeComponent();
            this.dblist = dblist;
        }
        private DataGridView dblist;
        private void database_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dblist.Rows.Count-1; i++) //-1 para fix de edición de datagridview, ya que al crearlo en SessionManager le deja un row null
            {
                dGVdatabase.Rows.Add(dblist[0,i].Value.ToString()); // cargar datos
            }
        }

        private void dGVdatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection mySqlConnection = SessionManager.mySqlConnection;
            try
            {
                string bd = "USE "+ dGVdatabase.CurrentCell.Value.ToString() +"; SHOW TABLES";
                MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                mySqlCommand.CommandText = bd; //comando a ejecutar
                mySqlConnection.Open();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.ExecuteNonQuery();
                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                dGVtables.Rows.Clear();
                dGVtables.Columns.Clear();
                dGVtables.Columns.Add("Tables", "Tables of "+ dGVdatabase.CurrentCell.Value.ToString());
                while (lector.Read())
                {
                    dGVtables.Rows.Add(lector.GetValue(0).ToString());
                }
                lector.Close();
                mySqlConnection.Close();
            }
            catch (MySqlException error)
            {
                MessageBox.Show("Server Down", "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mySqlConnection.Close();
            }
        }

        private void dGVdatabase_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dGVdatabase_CellDoubleClick(sender, e);
        }
    }
}