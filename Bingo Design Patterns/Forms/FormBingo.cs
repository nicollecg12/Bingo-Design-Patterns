using Bingo_Design_Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public partial class FormBingo : Form
    {
        SqlConnection cn = ConexionBD.CrearInstancia().CrearConexion();
        private readonly IPalabraRepository _palabraRepository;


        private string fraseActual;
        private string patronCorrecto;
        private Random random = new Random();
        private int segundosJugados = 0;
        private Button[,] botonesJugador;       
        private Button[,] botonesMaquina;   
        private const int TAM = 5;
        string login;
        int idJugador;
        int idPartida;
        Partida nueva = new Partida();


        public FormBingo(string loginName)
        {
            InitializeComponent();
            login = loginName;
            cn.Open();

            _palabraRepository = new PalabraRepository(ConexionBD.con.CadenaConexion);

            

            
           

        }

        private void FormBingo_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> patrones = _palabraRepository.ObtenerPatrones();
            var textos = patrones.Keys.OrderBy(x => random.Next()).ToList();
            int indice = 0;

            foreach (Control control in panelBingo.Controls)
            {
                if (control is Button && indice < textos.Count)
                {
                    control.Text = textos[indice];
                    control.Tag = textos[indice]; 
                    control.BackColor = SystemColors.Control;
                    indice++;
                }
            }

            indice = 0;
            textos = patrones.Keys.OrderBy(x => random.Next()).ToList();
            foreach (Control control in panelBingo2.Controls)
            {
                if (control is Button && indice < textos.Count)
                {
                    control.Text = textos[indice];
                    control.Tag = textos[indice];
                    control.BackColor = SystemColors.Control;
                    indice++;
                }
            }

            foreach (Control control in panelBingo.Controls)
            {
                if (control is Button btn)
                {
                    btn.Click -= BotonBingo_Click;
                    btn.Click += BotonBingo_Click;
                }
            }

            foreach (Control control in panelBingo2.Controls)
            {
                if (control is Button btn)
                {
                    btn.Click -= BotonBingo_Click;
                    btn.Click += BotonBingo_Click;
                }
            }

            dgvPatrones.Columns.Add("Patron", "Patrón Correcto");
            EstilizarDataGridView();

            InicializarMatricesDeBotones();
            NuevaFraseAleatoria();
            timerJuego.Start();
        }

        private void EstilizarDataGridView()
        {
            var dgv = dgvPatrones;

            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(5, 50, 80);         

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 200);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 32;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 160, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgv.RowTemplate.Height = 28;
            dgv.RowHeadersVisible = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            // Bordes suaves con padding visual
            dgv.DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);

            dgv.ScrollBars = ScrollBars.Vertical;

            // Quitar bordes feos
            dgv.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        }
        private void InicializarMatricesDeBotones()
        {
            
            botonesJugador = new Button[TAM, TAM];
            botonesMaquina = new Button[TAM, TAM];

           
            var botonesPanelJugador = panelBingo.Controls.OfType<Button>().OrderBy(b => b.Top).ThenBy(b => b.Left).ToList();
            var botonesPanelMaquina = panelBingo2.Controls.OfType<Button>().OrderBy(b => b.Top).ThenBy(b => b.Left).ToList();


            for (int i = 0; i < Math.Min(botonesPanelJugador.Count, TAM * TAM); i++)
            {
                int fila = i / TAM;
                int col = i % TAM;
                botonesJugador[fila, col] = botonesPanelJugador[i];
            }

            
            for (int i = 0; i < Math.Min(botonesPanelMaquina.Count, TAM * TAM); i++)
            {
                int fila = i / TAM;
                int col = i % TAM;
                botonesMaquina[fila, col] = botonesPanelMaquina[i];
            }
        }

        private bool VerificarBingoPorFila(Button[,] matriz)
        {
            for (int fila = 0; fila < TAM; fila++)
            {
                if (FilaCompleta(matriz, fila))
                    return true;
            }
            return false;
        }

        private bool FilaCompleta(Button[,] matriz, int fila)
        {
            for (int col = 0; col < TAM; col++)
            {
                var btn = matriz[fila, col];
                if (btn == null) return false;      
                                                    
                if (btn.Enabled) return false;
            }
            return true;
        }

        
        private void ManejarVictoria(string mensaje)
        {
            timerJuego.Stop();
            DeshabilitarTableros();

            DialogResult resultado = MessageBox.Show(
                mensaje + "\n\n¿Quieres volver a jugar?",
                "BINGO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (resultado == DialogResult.Yes)
            {
                ReiniciarJuego();
            }
            else
            {
                
                FormInicio f = new FormInicio();
                f.Show();
                this.Close();   
            }
        }
        private void ReiniciarJuego()
        {
            segundosJugados = 0;
            lblTiempo.Text = "Tiempo: 00:00";

            
            foreach (var b in botonesJugador)
            {
                if (b != null)
                {
                    b.Enabled = true;
                    b.BackColor = SystemColors.Control;
                }
            }

            foreach (var b in botonesMaquina)
            {
                if (b != null)
                {
                    b.Enabled = true;
                    b.BackColor = SystemColors.Control;
                }
            }

           
            FormBingo_Load(null, null);

            NuevaFraseAleatoria();
            timerJuego.Start();
        }

        private void DeshabilitarTableros()
        {
            foreach (var b in botonesJugador)
                if (b != null) b.Enabled = false;
            foreach (var b in botonesMaquina)
                if (b != null) b.Enabled = false;
        }

        private void MarcarEnMaquina(string patron)
        {
            cn.Close();
            foreach (Control ctr in panelBingo2.Controls)
            {
                if (ctr is Button btn)
                {
                    string tag = btn.Tag as string;
                    if (tag == patron && btn.Enabled)
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.Enabled = false;
                        break;
                    }
                }
            }

            cn.Open();
            string query = "SELECT id_jugador FROM Usuario WHERE loginName = @loginName";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@loginName", login);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    idJugador = Convert.ToInt32(result);
            }

            // Verificamos si la máquina hizo BINGO por fila
            if (VerificarBingoPorFila(botonesMaquina))
            {

                ManejarVictoria("La máquina hizo BINGO (fila completada).");           
                string estado = "Completada";

                SqlCommand cmd2 = new SqlCommand("sp_RegistroPartida", cn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@estado", estado);

                try
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nueva.IdPartida = Convert.ToInt32(reader["IdPartida"]);
                            nueva.Estado = reader["Estado"].ToString();
                            nueva.Fecha = Convert.ToDateTime(reader["Fecha"]);
                            MessageBox.Show("Partida registrada con éxito");
                        }                     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }

                SqlCommand cmd3 = new SqlCommand("sp_InsertarResultado", cn);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.AddWithValue("@id_partida", nueva.IdPartida);
                cmd3.Parameters.AddWithValue("@id_jugador", idJugador);
                cmd3.Parameters.AddWithValue("@es_ganador", 0);
                try
                {
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("resultado exitoso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                return;
            }
            cn.Close();
        }

        private void NuevaFraseAleatoria()
        {
            Dictionary<string, string> patrones = _palabraRepository.ObtenerPatrones();
            var listaPatrones = patrones.Keys.ToList();
            patronCorrecto = listaPatrones[random.Next(listaPatrones.Count)];
            fraseActual = patrones[patronCorrecto];

           
            MarcarEnMaquina(patronCorrecto);
            this.Invalidate();
        }

        private void FormBingo_Paint(object sender, PaintEventArgs e)
        {
            int diameter = 240;
            int x = (this.ClientSize.Width - diameter) / 2;
            int y = 20;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.White, x, y, diameter, diameter);

            using (Font fuente = new Font("Arial", 10, FontStyle.Bold))
            using (StringFormat formato = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                RectangleF rectTexto = new RectangleF(x, y, diameter, diameter);
                e.Graphics.DrawString(fraseActual, fuente, Brushes.Black, rectTexto, formato);
            }
        }

        private void btnNuevaFrase_Click(object sender, EventArgs e)
        {
            NuevaFraseAleatoria();
            try
            { dgvPatrones.Rows.Add(patronCorrecto); }
            catch 
            {
                MessageBox.Show(":)");
            }
            
        }

        private void timerJuego_Tick(object sender, EventArgs e)
        {
            segundosJugados++;
            int minutos = segundosJugados / 60;
            int segundos = segundosJugados % 60;
            lblTiempo.Text = $"Tiempo: {minutos:D2}:{segundos:D2}";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Hide();
        }

        private void BotonBingo_Click(object sender, EventArgs e)
        {
           
            if (!(sender is Button boton)) return;
            if (!boton.Enabled) return;

            string patronDelBoton = boton.Tag as string;

            if (string.Equals(patronDelBoton, patronCorrecto))
            {
                boton.BackColor = Color.LightGreen;
                boton.Enabled = false;

                
                MarcarEnMaquina(patronCorrecto);

               
                if (VerificarBingoPorFila(botonesJugador))
                {
                    cn.Open();
                    string estado = "Completada";

                    SqlCommand cmd2 = new SqlCommand("sp_RegistroPartida", cn);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@estado", estado);

                    try
                    {
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nueva.IdPartida = Convert.ToInt32(reader["IdPartida"]);
                                nueva.Estado = reader["Estado"].ToString();
                                nueva.Fecha = Convert.ToDateTime(reader["Fecha"]);
                                MessageBox.Show("Partida registrada con éxito");
                            }
                            idPartida = nueva.IdPartida;
                        }                  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }

                    SqlCommand cmd3 = new SqlCommand("sp_InsertarResultado", cn);
                    cmd3.CommandType = CommandType.StoredProcedure;

                    cmd3.Parameters.AddWithValue("@id_partida", nueva.IdPartida);
                    cmd3.Parameters.AddWithValue("@id_jugador", idJugador);
                    cmd3.Parameters.AddWithValue("@es_ganador", 1);
                    try
                    {
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("resultado exitoso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                    return;

                    ManejarVictoria("¡Correcto! Hiciste BINGO (fila completada).");          
                    return;
                }

                MessageBox.Show("¡Correcto!", "Felicitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NuevaFraseAleatoria();
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Esa no es la casilla correcta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPatrones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cn.Close();
            if (e.RowIndex < 0) return;

            string palabra = dgvPatrones.Rows[e.RowIndex].Cells[0].Value.ToString();

            MarcarEnTableroJugador(palabra); 
            MarcarEnMaquina(palabra);

            if (VerificarBingoPorFila(botonesJugador))
            {
                ManejarVictoria("¡Correcto! Hiciste BINGO (fila completada).");
               cn.Open();
                string estado = "Completada";

                SqlCommand cmd2 = new SqlCommand("sp_RegistroPartida", cn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@estado", estado);

                try
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nueva.IdPartida = Convert.ToInt32(reader["IdPartida"]);
                            nueva.Estado = reader["Estado"].ToString();
                            nueva.Fecha = Convert.ToDateTime(reader["Fecha"]);
                            MessageBox.Show("Partida registrada con éxito");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }

                SqlCommand cmd3 = new SqlCommand("sp_InsertarResultado", cn);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.AddWithValue("@id_partida", nueva.IdPartida);
                cmd3.Parameters.AddWithValue("@id_jugador", idJugador);
                cmd3.Parameters.AddWithValue("@es_ganador", 1);
                try
                {
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("resultado exitoso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                return;

            }

            if (VerificarBingoPorFila(botonesMaquina))
            {
                ManejarVictoria("La máquina hizo BINGO (fila completada).");
                return;
            }
        }

        private void MarcarEnTableroJugador(string palabra)
        {
            foreach (Control control in panelBingo.Controls)
            {
                if (control is Button btn && btn.Tag?.ToString() == palabra && btn.Enabled)
                {
                    btn.BackColor = Color.LightGreen;
                    btn.Enabled = false; 
                    return;
                }
            }
        }
    }
}
