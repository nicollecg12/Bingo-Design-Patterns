using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            cboTipoUsuario.Items.Add("Jugador");
            cboTipoUsuario.Items.Add("Administrador");
            cboTipoUsuario.SelectedIndex = -1;

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string tipo = cboTipoUsuario.Text;
            string nombre = txtNombre.Text;
            string numero = txtNumeroTelefonico.Text;
            string user = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

        

            try
            {
                if (!long.TryParse(numero, out _))
                {
                    MessageBox.Show("El número telefonico solo puede contener caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.TryParse(nombre, out _))
                {
                    MessageBox.Show("El nombre no debe contener números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                foreach (var users in GestorUsuarios.Instancia.ObtenerUsuarios())
                {
                    if (users.User == user)
                    {
                        MessageBox.Show("Ya existe ese nombre de usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Usuario nuevo = UsuarioFactory.CrearUsuario(nombre, numero, user, contraseña, tipo);
                GestorUsuarios.Instancia.AgregarUsuario(nuevo);
                MessageBox.Show(nuevo.VerificarCreacion(), "Atención",MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
