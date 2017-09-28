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
using System.Data.SQLite;
using Npgsql;


namespace abd
{
    public partial class SessionManager : Form
    {
        public string cadena;
        public static MySqlConnection mySqlConnection;
        public static NpgsqlConnection npgsqlConnection;
        public SessionManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBdbm.Text = cBdbm.Items[0].ToString(); //combobox a indice 0 (MySQL)
            btSelectBD.Visible = false;
            btSelectBD.Enabled = false;
        }
        public void Disable()
        {
            btSelectBD.Visible = true;
            btSelectBD.Enabled = true;
            lbIP.Text = "Database Source:";
            txtHOST.Clear();
            txtHOST.Focus();
            label3.Visible = false;
            tBuser.Visible = false;
            label4.Visible = false;
            tBpass.Visible = false;
            label5.Visible = false;
            dUDport.Visible = false;
            label6.Visible = false;
            tBdatabase.Visible = false;
        }
        public void Enable()
        {
            btSelectBD.Visible = false;
            btSelectBD.Enabled = false;
            lbIP.Text = "Host Name/IP:";
            txtHOST.Clear();
            label3.Visible = true;
            tBuser.Visible = true;
            label4.Visible = true;
            tBpass.Visible = true;
            label5.Visible = true;
            dUDport.Visible = true;
            label6.Visible = true;
            tBdatabase.Visible = true;
        }
        private void cBdbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBdbm.SelectedIndex.ToString();
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    Enable();
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "3306";
                    break;
                case "1": //PostgrSQL
                    Enable();
                    txtHOST.Text = "localhost";
                    dUDport.Text = "5432";
                    break;
                case "2": //MSSqlServer
                    Enable();
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "";
                    break;
                case "3": //SQLite
                    Disable();
                    break;
                case "4": //Mongo

                    break;
                case "5": //Reaven

                    break;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    if (tBdatabase.Text.Trim()=="") //conexión si no especificar BD
                    {
                        cadena = "server=" + txtHOST.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text; //sin base de datos
                        MySqlConnection mySqlConnection = new MySqlConnection(cadena);
                        try
                        {
                            string bd = "SHOW DATABASES";
                            MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                            mySqlCommand.CommandText = bd; //comando a ejecutar
                            mySqlConnection.Open();
                            mySqlCommand.Connection = mySqlConnection;
                            mySqlCommand.ExecuteNonQuery();
                            MySqlDataReader lector = mySqlCommand.ExecuteReader();
                            DataGridView databases = new DataGridView();
                            databases.Columns.Add("Column1","Column1");
                            while (lector.Read())
                            {
                                databases.Rows.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            Start.ShowFormDB(databases);
                            this.Close();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Usuario y/o contraseña");
                            mySqlConnection.Close();
                            //MessageBox.Show(error.ToString()); //mensaje de debug error
                        }
                    }
                    else //si se especifica base de datos
                    {
                        cadena = "server=" + txtHOST.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text + ";Database=" + tBdatabase.Text; //con base de datos
                        mySqlConnection = new MySqlConnection(cadena);
                        try
                        {
                            string bd = "SHOW DATABASES LIKE '"+tBdatabase.Text+"'";
                            MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                            mySqlCommand.CommandText = bd; //comando a ejecutar
                            mySqlConnection.Open();
                            mySqlCommand.Connection = mySqlConnection;
                            mySqlCommand.ExecuteNonQuery();
                            MySqlDataReader lector = mySqlCommand.ExecuteReader();
                            DataGridView databases = new DataGridView();
                            databases.Columns.Add("Column1", "Comlumn1");
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                databases.Rows.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            Start.ShowFormDB(databases);
                            this.Close();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Connection error, check your username, password and database");
                            mySqlConnection.Close();
                            //MessageBox.Show(error.ToString());  //mensaje de debug error
                        }
                    }
                    break;
                case "1": //PostgreSQL
                    if (tBdatabase.Text.Trim() == "")
                    {
                        cadena = "Server=" + txtHOST.Text + "; Port=" + dUDport.Text + "; User Id=" + tBuser.Text + "; Password=" + tBpass.Text;
                        npgsqlConnection = new NpgsqlConnection(cadena);
                        try
                        {
                            string query = "SELECT datname FROM pg_database WHERE datistemplate = false;";
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.CommandText = query;
                            npgsqlConnection.Open();
                            command.Connection = npgsqlConnection;
                            command.ExecuteNonQuery();
                            NpgsqlDataReader lector = command.ExecuteReader();
                            DataGridView databases = new DataGridView();
                            databases.Columns.Add("Column1", "Comlumn1");
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                databases.Rows.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            Start.ShowFormDB(databases);
                            npgsqlConnection.Close();
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database" + NpgsqlError);
                        }
                    }
                    else
                    {
                        cadena = "Server=" + txtHOST.Text + "; Port=" + dUDport.Text + "; User Id=" + tBuser.Text + "; Password=" + tBpass.Text+"; Database="+tBdatabase.Text+";" ;
                        npgsqlConnection = new NpgsqlConnection(cadena);
                        try
                        {
                            string query = "SELECT datname FROM pg_database WHERE ;";
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.CommandText = query;
                            npgsqlConnection.Open();
                            command.Connection = npgsqlConnection;
                            command.ExecuteNonQuery();
                            NpgsqlDataReader lector = command.ExecuteReader();
                            DataGridView databases = new DataGridView();
                            databases.Columns.Add("Column1", "Comlumn1");
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                databases.Rows.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            Start.ShowFormDB(databases);
                            npgsqlConnection.Close();
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database" + NpgsqlError);
                        }
                    }
                    this.Close();
                    break;
                case "2": //MSSQL Server
                    if (txtHOST.Text.Trim() == "")
                    {
                        MessageBox.Show("The host name is empty", "No Hostname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                    }

                    break;
                case "3": //SQLite
                    if (txtHOST.Text.Trim() == "")
                    {
                        MessageBox.Show("Browse for a databese or ingress a database name","No Database", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            SQLiteConnection SQLiteconect = new SQLiteConnection("Data Source = " + txtHOST.Text);
                            SQLiteconect.Open();
                            MessageBox.Show("Conectado a la BD");
                            SQLiteconect.Close();
                        }
                        catch (SQLiteException sqliterror)
                        {
                            MessageBox.Show("Error de conexión: " + sqliterror);
                        }
                    }
                    break;
                case "4":
                    
                    break;
                case "5":

                    break;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSelectBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog Db = new OpenFileDialog();
            Db.Filter = "Database (*.db)|*.db";
            if (Db.ShowDialog() == DialogResult.OK)
            {
                txtHOST.Text = Db.FileName;
            }
        }
    }
}
