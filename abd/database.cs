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
    public partial class Database : Form
    {
        public Database(DataGridView dblist)
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
    }
}