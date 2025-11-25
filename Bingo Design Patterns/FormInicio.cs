using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public partial class FormInicio : Form
    {
        SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string user = txtNombre.Text;
            string contraseña = txtContraseña.Text;
            try
            {
               bool encontrado = GestorUsuarios.Instancia.ObtenerUsuarios().Any(u => u.User == user && u.Contraseña == contraseña); ;

                if (encontrado)
                {
                    cn.Open();
                    string rol;
                    string query = "select rol from usuario where loginName = @loginName;";
                    
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        string resultado;
                        cmd.Parameters.AddWithValue("@loginName", user);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            resultado = Convert.ToString(result);
                            
                        }
                            resultado = Convert.ToString(result);
                        rol = resultado;
                    }
                    
                    if (rol == "Administrador")
                    {
                       FormAdministrador formAdministrador = new FormAdministrador();
                        formAdministrador.Show();
                        this.Hide();
                    }
                    else 
                    {
                        FormBingo formBingo = new FormBingo(user);
                        formBingo.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña inválidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void llbRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
            this.Hide();
        }
    }
}
