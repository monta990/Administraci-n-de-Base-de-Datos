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
    public partial class database : Form
    {
        public database(DataGridView dblist)
        {
            InitializeComponent();
            this.dblist = dblist;
            //dGVdatabase.DataSource = dblist.DataSource;
        }
        private DataGridView dblist;
        private void database_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(lector.GetValue(0).ToString());
            for (int i = 0; i < dblist.Rows.Count-1; i++) //-1 para fix de edición de datagridview
            {
                dGVdatabase.Rows.Add(dblist[0,i].Value.ToString()); // cargar datos
                //MessageBox.Show(dblist[0, i].Value.ToString());
            }
        }
    }
}