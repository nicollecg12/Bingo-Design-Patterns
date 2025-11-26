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
    public partial class FormRegistro : Form
    {
       
        public FormRegistro()
        {
            InitializeComponent();   

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string tipo = "Jugador";
            string nombre = txtNombre.Text;
            string numero = txtNumeroTelefonico.Text;
            string user = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
        

            try
            {
                if (!long.TryParse(txtNumeroTelefonico.Text, out _ ))
                {
                    MessageBox.Show("El número telefonico solo puede contener caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.TryParse(nombre, out _))
                {
                    MessageBox.Show("El nombre no debe contener números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                if (!int.TryParse(txtEdad.Text, out int edad))
                {
                    MessageBox.Show("La edad solo puede contener caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }

                foreach (var users in GestorUsuarios.Instancia.ObtenerUsuarios())
                {
                    if (users.User == user)
                    {
                        MessageBox.Show("Ya existe ese nombre de usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Usuario nuevo = UsuarioFactory.CrearUsuario(nombre, edad,numero, user, contraseña, tipo);
                SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();

                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreCompleto", nuevo.Nombre);                
                cmd.Parameters.AddWithValue("@LoginName", nuevo.User);
                cmd.Parameters.AddWithValue("@ContrasenaHash", nuevo.Contraseña);
                cmd.Parameters.AddWithValue("@Rol", nuevo.Tipo);
                cmd.Parameters.AddWithValue("@Edad", nuevo.Edad);
                cmd.Parameters.AddWithValue("@telefono", nuevo.Numero);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    GestorUsuarios.Instancia.ObtenerUsuarios();
                    MessageBox.Show(nuevo.VerificarCreacion(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar usuario: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                

                FormInicio formInicio = new FormInicio();
                formInicio.Show();
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormInicio frm = new FormInicio();
            frm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
