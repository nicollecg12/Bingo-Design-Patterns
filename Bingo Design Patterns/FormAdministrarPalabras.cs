using System;
using System.Collections;
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
    public partial class FormAdministrarPalabras : Form
    {
        SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();
        public FormAdministrarPalabras()
        {
            InitializeComponent();
           
        }

        private void btnEliminarPatron_Click(object sender, EventArgs e)
        {
            if (dgvPatrones.SelectedRows.Count > 0)
            {
                cn.Open();
                int idPalabra = Convert.ToInt32(dgvPatrones.SelectedRows[0].Cells["id_palabra"].Value);

                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar esta palabra?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarPalabra", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPalabra", idPalabra);

                    try
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Palabra eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar palabra: " + ex.Message);
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
            Limpiar();
        }

        public void CargarDatos()
        {
            string query = "SELECT * FROM Palabra";

            using (SqlConnection conn = new SqlConnection(ConexionBD.con.CadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPatrones.DataSource = dt;
            }
        }

        private void btnModificarPatron_Click(object sender, EventArgs e)
        {
            if (dgvPatrones.SelectedRows.Count > 0)
            {
                cn.Open();
                int idPalabra = Convert.ToInt32(dgvPatrones.SelectedRows[0].Cells["id_palabra"].Value);

                DialogResult result = MessageBox.Show(
                    "¿Está seguro de modificar esta palabra?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarPalabra", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPalabra", idPalabra);
                    cmd.Parameters.AddWithValue("@Palabra", txtPatron.Text);
                    cmd.Parameters.AddWithValue("@Frase", txtDescripcion.Text);

                    try
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Palabra se actualizo correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al modificar el patron: " + ex.Message);
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
                MessageBox.Show("Debe seleccionar una fila para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        private void dgvPatrones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPatrones.Rows[e.RowIndex];

                txtPatron.Text = fila.Cells["palabra"].Value.ToString();
                txtDescripcion.Text = fila.Cells["frase"].Value.ToString();
            }
        }

        private void btnAñadirPatron_Click(object sender, EventArgs e)
        {
            cn.Open();

            DialogResult result = MessageBox.Show(
                "¿Está seguro de agregar esta palabra?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarPalabra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Palabra", txtPatron.Text);
                cmd.Parameters.AddWithValue("@Frase", txtDescripcion.Text);

                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Palabra se agrego correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el patron: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
                Limpiar();
            }
        }

        private void FormAdministrarPalabras_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dgvPatrones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatrones.MultiSelect = false;
        }

        public void Limpiar()
        {
            txtDescripcion.Clear();
            txtPatron.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormAdministrador formRegistro = new FormAdministrador();
            formRegistro.Show();
            this.Hide();
        }
    }
}
