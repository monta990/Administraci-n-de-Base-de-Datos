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
using System.Data.SqlClient;
using Npgsql;
using MongoDB.Driver.Core;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Raven.Client.Connection;
using Raven.Abstractions.Data;
using Raven.Client.Document;
using Raven.Json;
using Raven.Imports.Newtonsoft.Json;
namespace abd
{
    public partial class FrmSessionManager : Form
    {
        public string cadena;
        private TreeView treedatabes = new TreeView();
        public static SqlConnection SqlConnection; //iniciar msssql
        public static MySqlConnection mySqlConnection; //iniciar mysql
        public static SQLiteConnection SQLiteconect; //inicar sqlite
        public static NpgsqlConnection npgsqlConnection; //iniciar postgresql
        public static MongoClient MongoDBClient; //iniciar mongo
        public static IMongoDatabase MongoDatabase;
        private string nouserandpassword="Input a username and password";
        public FrmSessionManager()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cBdbm.Text = cBdbm.Items[0].ToString(); //combobox to Index 0 (MySQL)
            btSelectBD.Visible = false;
            btSelectBD.Enabled = false;
        }
        /// <summary>
        /// Test conecctions
        /// </summary>
        /// <param name="manager">Manager</param>
        private void Test(string manager)
        {
            switch (manager)
            {
                case "0": //MySQL
                    #region MySQL
                    try
                    {
                        if (tBuser.Text.Trim() == "" || tBpass.Text.Trim() == "")
                        {
                            MessageBox.Show(nouserandpassword,"Check user and password", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Conecction Pass", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            while (lector.Read())
                            {
                                cBdatabases.Items.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            mySqlConnection.Close();
                        }
                    }
                    catch (MySqlException Error)
                    {
                        MessageBox.Show("Server Down","Check server status",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;
                #endregion
                case "1": //PostgreSQL
                    #region PostgreSQL
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
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                cBdatabases.Items.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            npgsqlConnection.Close();
                            MessageBox.Show("Test Passed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database " + NpgsqlError, "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                    #endregion PostgreSQL
                case "2": //MSSQLServer
                    #region MSSQLServer
                    if (tBuser.Text.Trim() == "" || tBpass.Text.Trim() == "")
                    {
                        MessageBox.Show(nouserandpassword, "Check user and password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cadena = "Data Source=" + tBhost.Text + ";User Id=" + tBuser.Text + ";Password=" + tBpass.Text; //sin base de datos
                        SqlConnection = new SqlConnection(cadena);
                        try
                        {
                            string bd = "EXEC sp_databases";
                            SqlCommand SqlCommand = new SqlCommand(); //comando
                            SqlCommand.CommandText = bd; //comando a ejecutar
                            SqlConnection.Open();
                            SqlCommand.Connection = SqlConnection;
                            SqlCommand.ExecuteNonQuery();
                            SqlDataReader lector = SqlCommand.ExecuteReader();
                            MessageBox.Show("Conecction Pass", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            while (lector.Read())
                            {
                                cBdatabases.Items.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            SqlConnection.Close();
                        }
                        catch (SqlException error)
                        {
                            MessageBox.Show("Server Down " + error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SqlConnection.Close();
                        }
                    }
                    break;
                    #endregion MSSQLServer
                case "3": //SQLite
                    #region SQLite
                    if (tBhost.Text.Trim() == "")
                    {
                        MessageBox.Show("Please browse for a db file before DO a test", "No Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            SQLiteConnection SQLiteconect = new SQLiteConnection("Data Source = " + tBhost.Text);
                            SQLiteconect.Open();
                            MessageBox.Show("Connected to BD file", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SQLiteconect.Close();
                        }
                        catch (SQLiteException sqliterror)
                        {
                            MessageBox.Show("Error: " + sqliterror);
                        }
                    }
                    #endregion
                    break;
                case "4": //MongoDB
                    #region MongoDB
                    try
                    {
                        if (cBdatabases.Text.Trim() == "")
                        {
                            MessageBox.Show("Ingress a database name", "No DB name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
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
        /// <summary>
        /// Make a connection to selected DB
        /// </summary>
        private void Connection()
        {
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    #region MySql
                    if (tBpass.Text.Trim() == "" || tBuser.Text.Trim() == "") //check password and user
                    {
                        MessageBox.Show(nouserandpassword, "Check User and Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (cBdatabases.Text.Trim() == "") //conecction if not use DB
                        {
                            cadena = "server=" + tBhost.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text; //sin base de datos
                            mySqlConnection = new MySqlConnection(cadena);
                            try
                            {
                                string bd = "SHOW DATABASES";
                                MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                                mySqlCommand.CommandText = bd; //comando a ejecutar
                                mySqlConnection.Open();
                                mySqlCommand.Connection = mySqlConnection;
                                mySqlCommand.ExecuteNonQuery();
                                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                                while (lector.Read())
                                {
                                    treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                                }
                                lector.Close();
                                mySqlConnection.Close();
                                FrmStart.ShowFrmDatabaseMySQL(treedatabes);
                                this.Close();
                            }
                            catch (MySqlException error)
                            {
                                MessageBox.Show("Server Down", "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mySqlConnection.Close();
                            }
                        }
                        else //si se especifica base de datos
                        {
                            cadena = "server=" + tBhost.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text + ";Database=" + cBdatabases.Text; //con base de datos
                            mySqlConnection = new MySqlConnection(cadena);
                            try
                            {
                                string bd = "SHOW DATABASES LIKE '" + cBdatabases.Text + "'";
                                MySqlCommand mySqlCommand = new MySqlCommand(); //comando
                                mySqlCommand.CommandText = bd;
                                mySqlConnection.Open();                      
                                mySqlCommand.Connection = mySqlConnection;
                                mySqlCommand.ExecuteNonQuery();
                                MySqlDataReader lector = mySqlCommand.ExecuteReader();
                                while (lector.Read()) //carga de los nombres de las base de datos
                                {
                                    treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                                }
                                lector.Close();
                                FrmStart.ShowFrmDatabaseMySQL(treedatabes);
                                mySqlConnection.Close();
                                this.Close();
                            }
                            catch (MySqlException error)
                            {
                                MessageBox.Show("Connection error, check your username, password and database and server staus", "Check data and server status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mySqlConnection.Close();
                            }
                        }
                    }
                    #endregion
                    break;
                case "1": //PostgreSQL
                    #region PostgreSQL
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
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            FrmStart.ShowFrmDatabasePostgreSQL(treedatabes);
                            npgsqlConnection.Close();
                            this.Close();
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database" + NpgsqlError);
                        }
                    }
                    else
                    {
                        cadena = "Server=" + tBhost.Text + "; Port=" + dUDport.Text + "; User Id=" + tBuser.Text + "; Password=" + tBpass.Text + "; Database=" + cBdatabases.Text + ";";
                        npgsqlConnection = new NpgsqlConnection(cadena);
                        try
                        {
                            string query = "SELECT tablename FROM pg_catalog.pg_tables WHERE schemaname != 'pg_catalog' AND schemaname != 'information_schema'"; //muestra las tablas de la bd seleccionada
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.CommandText = query;
                            npgsqlConnection.Open();
                            command.Connection = npgsqlConnection;
                            command.ExecuteNonQuery();
                            NpgsqlDataReader lector = command.ExecuteReader();
                            while (lector.Read()) //carga de los nombres de las base de datos
                            {
                                treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                            }
                            lector.Close();
                            MessageBox.Show(treedatabes.ToString());
                            FrmStart.ShowFrmDatabasePostgreSQL(treedatabes);
                            npgsqlConnection.Close();
                            this.Close();
                        }
                        catch (Exception NpgsqlError)
                        {
                            MessageBox.Show("Connection error, check your username, password and database" + NpgsqlError);
                        }
                    }
                    #endregion
                    break;
                case "2": //MSSQL Server
                    #region MSSQL Server
                    if (tBpass.Text.Trim() == "" || tBuser.Text.Trim() == "") //check password and user
                    {
                        MessageBox.Show(nouserandpassword, "Check User and Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (cBdatabases.Text.Trim() == "") //conecction if not use DB
                        {
                            cadena = "Data Source=" + tBhost.Text + ";User Id=" + tBuser.Text + ";Password=" + tBpass.Text; //sin base de datos
                            SqlConnection = new SqlConnection(cadena);
                            try
                            {
                                string bd = "EXEC sp_databases";
                                SqlCommand SqlCommand = new SqlCommand(); //comando
                                SqlCommand.CommandText = bd; //comando a ejecutar
                                SqlConnection.Open();
                                SqlCommand.Connection = SqlConnection;
                                SqlCommand.ExecuteNonQuery();
                                SqlDataReader lector = SqlCommand.ExecuteReader();
                                while (lector.Read())
                                {
                                    treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                                }
                                lector.Close();
                                SqlConnection.Close();
                                FrmStart.ShowFrmDatabaseMSSQL(treedatabes);
                                this.Close();
                            }
                            catch (SqlException error)
                            {
                                MessageBox.Show("Server Down " + error, "Check Server Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SqlConnection.Close();
                            }
                        }
                        else //si se especifica base de datos
                        {
                            cadena = "Data Source=" + tBhost.Text + "," + dUDport.Text + ";User Id=" + tBuser.Text + ";Password=" + tBpass.Text + ";Initial Catalog=" + cBdatabases.Text; //con base de datos
                            SqlConnection = new SqlConnection(cadena);
                            try
                            {
                                string bd = "SELECT * FROM information_schema.tables WHERE TABLE_TYPE='" + cBdatabases.Text + "' AND TABLE_SCHEMA = 'dbo'";
                                SqlCommand SqlCommand = new SqlCommand(); //comando
                                SqlCommand.CommandText = bd; //comando a ejecutar
                                SqlConnection.Open();
                                SqlCommand.Connection = SqlConnection;
                                SqlCommand.ExecuteNonQuery();
                                SqlDataReader lector = SqlCommand.ExecuteReader();
                                while (lector.Read()) //carga de los nombres de las base de datos
                                {
                                    treedatabes.Nodes.Add(lector.GetValue(0).ToString());
                                }
                                lector.Close();
                                SqlConnection.Close();
                                FrmStart.ShowFrmDatabaseMSSQL(treedatabes);
                                this.Close();
                            }
                            catch (SqlException error)
                            {
                                MessageBox.Show("Connection error, check your username, password and database and server staus"+ error.ToString(), "Check data and server status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SqlConnection.Close();
                                //MessageBox.Show(error.ToString());  //mensaje de debug error
                            }
                        }
                    }
                    #endregion
                    break;
                case "3": //SQLite
                    #region SQLite
                    if (tBhost.Text.Trim() == "")
                    {
                        MessageBox.Show("Browse for a databese or write a new database name", "No Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            SQLiteconect = new SQLiteConnection("Data Source = " + tBhost.Text);
                            SQLiteconect.Open();
                            //MessageBox.Show("Conectado a la BD");
                            treedatabes.Nodes.Add(tBhost.Text);
                            FrmStart.ShowFrmDatabaseSQLite(treedatabes);
                            SQLiteconect.Close();
                            this.Close();
                        }
                        catch (SQLiteException sqliterror)
                        {
                            MessageBox.Show("Error de conexión: " + sqliterror);
                        }
                    }
                    #endregion
                    break;
                case "4": //MongoDB
                    #region MongoDB
                    if (cBdatabases.Text.Trim() == "")
                    {
                        MessageBox.Show(nouserandpassword, "No DB name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            tBhost.Update();
                            string cadena = "mongodb://" + tBhost.Text + ":" + dUDport.Text;
                            MongoDBClient = new MongoClient(cadena);
                            try
                            {
                                MessageBox.Show(MongoDBClient.GetDatabase(cBdatabases.Text).ToString());
                            }
                            catch (MongoException error)
                            {
                                MessageBox.Show("Server Up: "+ error, "Server Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                    }
                    #endregion
                    break;
                case "5": //ReavenDB
                    #region ReavenDB
                    using (var store = new DocumentStore { Url = tBhost.Text+":"+dUDport.Text }.Initialize())
                    {
                        using (var session = store.OpenSession(cBdatabases.Text))
                        {
                            
                            string json = JsonConvert.SerializeObject(store.DatabaseCommands.GetDocuments(1, 1));
                            MessageBox.Show(json);
                            cBdatabases.Items.Add(json.ToString());
                        }
                    }
                    //System.Diagnostics.Process.Start("http://localhost:8080");
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// Data for connection on DB´s mannagers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBdbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    Enable();
                    tBhost.Text = "127.0.0.1";
                    tBuser.Text = "root";
                    tBpass.Text = "alvarez";
                    dUDport.Text = "3306";
                    break;
                case "1": //PostgrSQL
                    Enable();
                    tBhost.Text = "localhost";
                    tBuser.Text = "postgres";
                    tBpass.Text = "postgres";
                    dUDport.Text = "5432";
                    cBdatabases.Text = "prestamos";
                    break;
                case "2": //MSSqlServer
                    Enable();
                    tBhost.Text = @"LAPDELL\SQLEXPRESS";
                    tBuser.Text = "sa";
                    tBpass.Text = "alvarez";
                    dUDport.Text = "1433";
                    break;
                case "3": //SQLite
                    Disable();
                    break;
                case "4": //Mongo
                    Enable();
                    tBhost.Text = "127.0.0.1";
                    dUDport.Text = "27017";
                    tBuser.Text = "";
                    tBpass.Text = "";
                    cBdatabases.Text = "primera";
                    break;
                case "5": //Reaven
                    Enable();
                    tBhost.Text = "http://localhost";
                    dUDport.Text = "8080";
                    tBuser.Text = "";
                    tBpass.Text = "";
                    cBdatabases.Text = "primera";
                    break;
            }
        }
        /// <summary>
        /// Connect to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            Connection();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Pick database for SQLite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelectBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog Db = new OpenFileDialog();
            Db.Filter = "Database (*.db)|*.db";
            if (Db.ShowDialog() == DialogResult.OK)
            {
                tBhost.Text = Db.SafeFileName;
            }
        }
        /// <summary>
        /// Test BD connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTest_Click(object sender, EventArgs e)
        {
            Test(cBdbm.SelectedIndex.ToString()); //prepare test connection
        }
    }
}