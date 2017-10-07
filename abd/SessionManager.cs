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
using MongoDB.Driver.Core;
using MongoDB.Driver;
using MongoDB.Bson;


namespace abd
{
    public partial class SessionManager : Form
    {
        public string cadena;
        public static MySqlConnection mySqlConnection; //iniciar mysql
        public static NpgsqlConnection npgsqlConnection; //iniciar postgresql
        public static MongoClient MongoDBClient; //iniciar mongo
        public static IMongoDatabase MongoDatabase;
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
        /// <summary>
        /// Test conecction
        /// </summary>
        /// <param name="manager">Manager</param>
        private void Test(string manager)
        {
            switch (manager)
            {
                case "0": //MySQL
                    #region MySQL
                    if (tBuser.Text.Trim() == "")
                    {
                        MessageBox.Show("Please put a user");
                    }
                    else
                    {
                        cadena = "server=" + tBhost.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text; //sin base de datos
                        MySqlConnection mySqlConnection = new MySqlConnection(cadena);
                        string bd = "SHOW DATABASES";
                        MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                        mySqlCommand.CommandText = bd; //comando a ejecutar
                        mySqlConnection.Open();
                        mySqlCommand.Connection = mySqlConnection;
                        mySqlCommand.ExecuteNonQuery();
                        MySqlDataReader lector = mySqlCommand.ExecuteReader();
                        MessageBox.Show("Conexión Exitosa", "Hay conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        while (lector.Read())
                        {
                            cBdatabases.Items.Add(lector.GetValue(0).ToString());
                        }
                        lector.Close();
                    }
                    #endregion
                    break;
                case "1": //PostgrSQL
                    break;
                case "2": //MSSQLServer
                    break;
                case "3": //SQLite
                    #region SQLite
                    MessageBox.Show("Not necesary DO a test","Not necesary",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    #endregion
                    break;
                case "4": //MongoDB
                    #region MongoDB
                    try
                    {
                        tBhost.Update();
                        string cadena = "mongodb://" + tBhost.Text + ":" + dUDport.Text;
                        MongoDBClient = new MongoClient(cadena);
                        MongoDBClient.GetDatabase(cBdatabases.Text);
                        if (MongoDBClient.Cluster.Description.State.ToString() == "Disconnected")
                        {
                            MessageBox.Show("Server Down", "Server Down", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Server Up", "Server Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (MongoConnectionException error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                    #endregion
                    break;
                case "5": //RevenDB
                    break;
            }
        }
        public void Disable()
        {
            btSelectBD.Visible = true;
            btSelectBD.Enabled = true;
            lbIP.Text = "Database Source:";
            tBhost.Clear();
            tBhost.Focus();
            label3.Visible = false;
            tBuser.Visible = false;
            label4.Visible = false;
            tBpass.Visible = false;
            label5.Visible = false;
            dUDport.Visible = false;
            label6.Visible = false;
            cBdatabases.Visible = false;
        }
        public void Enable()
        {
            btSelectBD.Visible = false;
            btSelectBD.Enabled = false;
            lbIP.Text = "Host Name/IP:";
            tBhost.Clear();
            label3.Visible = true;
            tBuser.Visible = true;
            label4.Visible = true;
            tBpass.Visible = true;
            label5.Visible = true;
            dUDport.Visible = true;
            label6.Visible = true;
            cBdatabases.Visible = true;
        }
        private void cBdbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    Enable();
                    tBhost.Text = "127.0.0.1";
                    dUDport.Text = "3306";
                    break;
                case "1": //PostgrSQL
                    Enable();
                    tBhost.Text = "localhost";
                    dUDport.Text = "5432";
                    break;
                case "2": //MSSqlServer
                    Enable();
                    tBhost.Text = "127.0.0.1";
                    dUDport.Text = "";
                    break;
                case "3": //SQLite
                    Disable();
                    break;
                case "4": //Mongo
                    Enable();
                    tBhost.Text = "127.0.0.1";
                    dUDport.Text = "27017";
                    break;
                case "5": //Reaven
                    Enable();
                    break;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    if (cBdatabases.Text.Trim()=="") //conexión si no especificar BD
                    {
                        cadena = "server=" + tBhost.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text; //sin base de datos
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
                        cadena = "server=" + tBhost.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text + ";Database=" + cBdatabases.Text; //con base de datos
                        mySqlConnection = new MySqlConnection(cadena);
                        try
                        {
                            string bd = "SHOW DATABASES LIKE '"+ cBdatabases.Text+"'";
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
                    if (cBdatabases.Text.Trim() == "")
                    {
                        cadena = "Server=" + tBhost.Text + "; Port=" + dUDport.Text + "; User Id=" + tBuser.Text + "; Password=" + tBpass.Text;
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
                        cadena = "Server=" + tBhost.Text + "; Port=" + dUDport.Text + "; User Id=" + tBuser.Text + "; Password=" + tBpass.Text+"; Database="+ cBdatabases.Text+";" ;
                        npgsqlConnection = new NpgsqlConnection(cadena);
                        try
                        {
                            string query = "SELECT table_name FROM information_schema.tables WHERE table_schema='"+ cBdatabases.Text +"';"; //muestra las tablas de la bd seleccionada
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
                            //npgsqlConnection.Close();
                            this.Close();
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database" + NpgsqlError);
                        }
                    }
                    break;
                case "2": //MSSQL Server
                    if (tBhost.Text.Trim() == "")
                    {
                        MessageBox.Show("The host name is empty", "No Hostname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                    }

                    break;
                case "3": //SQLite
                    if (tBhost.Text.Trim() == "")
                    {
                        MessageBox.Show("Browse for a databese or ingress a database name","No Database", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            SQLiteConnection SQLiteconect = new SQLiteConnection("Data Source = " + tBhost.Text);
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
                case "4": //MongoDB
                    try
                    {
                        tBhost.Update();
                        string cadena = "mongodb://" + tBhost.Text + ":" + dUDport.Text;
                        MongoDBClient = new MongoClient(cadena);
                        MongoDBClient.GetDatabase(cBdatabases.Text);
                        if (MongoDBClient.Cluster.Description.State.ToString() == "Disconnected")
                        {
                            MessageBox.Show("Server Down","Server Down",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Server Up", "Server Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (MongoConnectionException error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                    
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
                tBhost.Text = Db.FileName;
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            Test(cBdbm.SelectedIndex.ToString());
        }
    }
}
