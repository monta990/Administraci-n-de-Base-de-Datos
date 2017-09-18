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
    public partial class SessionManager : Form
    {
        public string cadena;
        public static MySqlConnection mySqlConnection;
        public SessionManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBdbm.Text = cBdbm.Items[0].ToString(); //combobox a indice 0 (MySQL)
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBdbm.SelectedIndex.ToString();
            switch (cBdbm.SelectedIndex.ToString())
            {
                case "0": //MySQL
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "3306";
                    break;
                case "1": //PostgrSQL
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "5432";
                    break;
                case "2":
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "";
                    break;
                case "3":
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "";
                    break;
                case "4":
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "";
                    break;
                case "5":
                    txtHOST.Text = "127.0.0.1";
                    dUDport.Text = "";
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
                        MySqlConnection mySqlConnection = new MySqlConnection(cadena);
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
                            MessageBox.Show("Usuario o contraseña y/o tabla erroneos");
                            mySqlConnection.Close();
                            //MessageBox.Show(error.ToString());  //mensaje de debug error
                        }
                    }
                    break;
                case "1": //PostgreSQL
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    
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
    }
}
