using Bingo_Design_Patterns.Repository;
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
    public partial class FormAdministrador : Form
    {
      
        private readonly IUsuarioActivoRepository _repoUsuarios;
        SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();
        public FormAdministrador()
        {
            InitializeComponent();
            _repoUsuarios = new UsuarioActivoRepository(ConexionBD.con.CadenaConexion);

           
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuarios.SelectedRows.Count > 0)
            {
                cn.Open();
                int idUsuario = Convert.ToInt32(dgvListaUsuarios.SelectedRows[0].Cells["id_jugador"].Value);

                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                        SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        try
                        {
                            
                            cmd.ExecuteNonQuery();
                             MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                        MessageBox.Show("Error al registrar usuario: " + ex.Message );
                        }
                        finally
                        {
                            cn.Close();
                        }


             
                    CargarDatos(); 
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarDatos()
        {

            var lista = _repoUsuarios.GetAll();
            dgvListaUsuarios.DataSource = lista;
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dgvListaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaUsuarios.MultiSelect = false;
        }

        private void btnAgregarAdministrador_Click(object sender, EventArgs e)
        {
            FormRegistroAdministrador formRegistro = new FormRegistroAdministrador();
            formRegistro.Show();
            this.Hide();
        }

        private void btnAdministrarPalabras_Click(object sender, EventArgs e)
        {
            FormAdministrarPalabras formRegistro = new FormAdministrarPalabras();
            formRegistro.Show();
            this.Hide();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Hide();
        }
    }
}
