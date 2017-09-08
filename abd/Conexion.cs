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
    public partial class Conexion : Form
    {
        public string cadena;

        public Conexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex.ToString();
            switch (comboBox1.SelectedIndex.ToString())
            {
                case "0":
                    txtHOST.Text = "127.0.0.1";
                    break;
                case "1":
                    txtHOST.Text = "127.0.0.1";
                    break;
                case "2":
                    txtHOST.Text = "127.0.0.1";
                    break;
                case "3":
                    txtHOST.Text = "127.0.0.1";
                    break;
                case "4":
                    txtHOST.Text = "127.0.0.1";
                    break;
                case "5":
                    txtHOST.Text = "127.0.0.1";
                    break;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex.ToString())
            {
                case "0":
                    if (tBdatabase.Text.Trim()=="")
                    {
                        cadena = "server=" + txtHOST.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text; //sin base de datos
                    }
                    else
                    {
                        cadena = "server=" + txtHOST.Text + ";port=" + dUDport.Text + ";user=" + tBuser.Text + ";password=" + tBpass.Text + "Database=" + tBdatabase.Text; //con base de datos
                    }
                    MySqlConnection mySqlConnection = new MySqlConnection(cadena);
                    try
                    {
                        mySqlConnection.Open();
                        MessageBox.Show("Conexión correcta!");
                    }
                    catch (MySqlException error)
                    {
                        MessageBox.Show("Usuario o contraseña y/o tabla erroneos");
                        mySqlConnection.Close();
                        MessageBox.Show(error.ToString());
                    }
                    break;
                case "1":
                    
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
    }
}
