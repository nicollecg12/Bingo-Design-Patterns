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

            NuevaFraseAleatoria();
            timerJuego.Start();
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

            if (patronDelBoton == patronCorrecto)
            {
                boton.BackColor = Color.LightGreen;
                boton.Enabled = false;

                MarcarEnMaquina(patronCorrecto);

                MessageBox.Show("¡Correcto!", "Felicitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevaFraseAleatoria();
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Esa no es la casilla correcta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        }
    }
}
