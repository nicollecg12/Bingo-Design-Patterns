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
    public partial class FormRegistroAdministrador : Form
    {
        SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();
        public FormRegistroAdministrador()
        {
            InitializeComponent();
        }

        private void btnAgregarAdmin_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtNombre.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            string telefono = txtNumeroTelefonico.Text;
            string loginName = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
            string rol = "Administrador";

            Usuario nuevo = UsuarioFactory.CrearUsuario(nombreCompleto, edad, telefono, loginName, contraseña, rol);

            DialogResult result = MessageBox.Show(
                "¿Está seguro que quiere agregar este administrador?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
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
                    MessageBox.Show("Error al registrar usuario: " + MessageBoxButtons.OK + MessageBoxIcon.Information);
                }
                finally
                {
                    cn.Close();
                }

                limpiar();
               
            }
        }

        public void limpiar()
        {
            txtContraseña.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
            txtNombreUsuario.Clear();
            txtNumeroTelefonico.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormAdministrador formRegistro = new FormAdministrador();
            formRegistro.Show();
            this.Hide();
        }
    }
}

