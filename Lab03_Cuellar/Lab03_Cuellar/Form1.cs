using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace Lab03_Cuellar
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("Conexion cerrada satiosfactoriamente");
                }
                else
                    MessageBox.Show("La conexion ya esta cerrada" );
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cerrar la conexion:( :" +
                    ex.ToString());
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor =txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server= " + servidor + ";Database= " + bd + ";";

            if (chkAutentication.Checked)
            { str += "Integrated Security = true"; }
            else
                str += "Usuarioid= " + user  + ";Password= " + pwd + ";";

            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado satisfactoriamente :)");
                btnDesconectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar el servidor : " + ex.ToString());
            }

        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Estado del servidor :" + conn.State +
                        "Version del servidor: " + conn.ServerVersion +
                        "Base de Datos: " + conn.Database);
                }
                else
                    MessageBox.Show("Estado del servidor:" + conn.State);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Imposible to determinated the state" +
                    " of the server :( :" +
                    ex.ToString());
            }
        }

        private void chkAutentication_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutentication.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled=true;
                txtPassword.Enabled=true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }
    }
}
