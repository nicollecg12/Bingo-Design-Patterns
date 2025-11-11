using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public partial class FormBingo : Form
    {
        private Dictionary<string, string> patrones;
        private string fraseActual;
        private string patronCorrecto;
        private Random random = new Random();
        private int segundosJugados = 0;
        private Button[,] botonesJugador;       
        private Button[,] botonesMaquina;   
        private const int TAM = 5;

        public FormBingo()
        {
            InitializeComponent();

            patrones = new Dictionary<string, string>
            {
                { "Singleton", "Permite una única instancia global del objeto." },
                { "Factory Method", "Crea objetos de distintos tipos sin especificar la clase exacta." },
                { "Strategy", "Permite cambiar el comportamiento de un algoritmo en tiempo de ejecución." },
                { "Observer", "Permite que los objetos se suscriban a eventos de otros objetos." },
                { "Command", "Encapsula una acción o solicitud como un objeto independiente." },
                { "Decorator", "Agrega funcionalidades sin modificar el código original." },
                { "Adapter", "Convierte la interfaz de una clase en otra que el cliente espera." },
                { "State", "Permite que un objeto cambie su comportamiento cuando cambia su estado interno." },
                { "Template Method", "Define el esqueleto de un algoritmo y deja que las subclases implementen los detalles." },
                { "MVC", "Patrón arquitectónico que separa modelo, vista y controlador." },
                { "Prototype", "Crea nuevos objetos copiando un prototipo existente." },
                { "Builder", "Permite construir objetos complejos paso a paso." },
                { "Mediator", "Facilita la comunicación entre múltiples objetos sin acoplarlos directamente." },
                { "Facade", "Proporciona una interfaz unificada para un conjunto de interfaces en un sistema." },
                { "Composite", "Combina objetos en estructuras jerárquicas para tratarlos de forma uniforme." },
                { "God Object", "Objeto que concentra demasiadas responsabilidades." },
                { "Spaghetti Code", "Código con estructura desordenada y difícil de mantener." },
                { "Duplicate Code", "Repetición innecesaria de código idéntico o similar." },
                { "Hard Coding", "Valores escritos directamente en el código en lugar de usar constantes." },
                { "Lava Flow", "Código antiguo que sigue presente por miedo a eliminarlo." },
                { "Golden Hammer", "Uso excesivo de una herramienta o patrón en todos los casos posibles." },
                { "Copy-Paste Programming", "Copiar y pegar código en lugar de reutilizarlo correctamente." },
                { "Shotgun Surgery", "Modificar un módulo obliga a cambiar muchos otros." },
                { "Feature Envy", "Una clase muestra demasiado interés en los datos de otra clase." },
                { "Premature Optimization", "Optimización prematura que complica el código innecesariamente." },
                { "Magic Numbers", "Uso de números sin explicación ni contexto." },
                { "God Method", "Método extremadamente largo y con demasiadas responsabilidades." },
                { "Circular Dependency", "Dos o más clases se dependen mutuamente de forma circular." },
                { "Boat Anchor", "Recurso que ya no se usa pero sigue presente en el sistema." },
                { "Poltergeist", "Objeto que solo existe para pasar datos entre otros sin lógica útil." }
            };
        }

        private void FormBingo_Load(object sender, EventArgs e)
        {
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




            InicializarMatricesDeBotones();
            NuevaFraseAleatoria();
            timerJuego.Start();
        }

        private void InicializarMatricesDeBotones()
        {
            // Crea matrices
            botonesJugador = new Button[TAM, TAM];
            botonesMaquina = new Button[TAM, TAM];

            // Rellenar la matriz leyendo controles en el orden en que están añadidos al Panel.
            // Se asume orden: fila0col0, fila0col1, ..., fila0col4, fila1col0, ...
            // Si tu Layout de panel no respeta ese orden, podrías ordenarlos por posición (Top, Left).
            var botonesPanelJugador = panelBingo.Controls.OfType<Button>().OrderBy(b => b.Top).ThenBy(b => b.Left).ToList();
            var botonesPanelMaquina = panelBingo2.Controls.OfType<Button>().OrderBy(b => b.Top).ThenBy(b => b.Left).ToList();

            // Rellenar matriz jugador
            for (int i = 0; i < Math.Min(botonesPanelJugador.Count, TAM * TAM); i++)
            {
                int fila = i / TAM;
                int col = i % TAM;
                botonesJugador[fila, col] = botonesPanelJugador[i];
            }

            // Rellenar matriz máquina
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
                if (btn == null) return false;      // defensivo
                                                    // consideramos marcado si está deshabilitado (como en tu lógica)
                if (btn.Enabled) return false;
            }
            return true;
        }

        // Cuando haya bingo, detener juego y notificar
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
                // ✅ Puedes volver al inicio o cerrar la ventana:
                FormInicio f = new FormInicio();
                f.Show();
                this.Close();   // o this.Hide();
            }
        }
        private void ReiniciarJuego()
        {
            segundosJugados = 0;
            lblTiempo.Text = "Tiempo: 00:00";

            // Habilitar botones y poner color normal
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

            // Rebarajar paneles
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

            // Verificamos si la máquina hizo BINGO por fila
            if (VerificarBingoPorFila(botonesMaquina))
            {
                ManejarVictoria("La máquina hizo BINGO (fila completada).");
            }
        }

        private void NuevaFraseAleatoria()
        {
            var listaPatrones = patrones.Keys.ToList();
            patronCorrecto = listaPatrones[random.Next(listaPatrones.Count)];
            fraseActual = patrones[patronCorrecto];
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

                // Marcar también en la máquina (tu método ya lo hace)
                MarcarEnMaquina(patronCorrecto);

                // Verificar si el jugador hizo BINGO por fila
                if (VerificarBingoPorFila(botonesJugador))
                {
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

       
    }
}
