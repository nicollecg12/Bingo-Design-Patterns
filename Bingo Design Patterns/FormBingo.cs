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
        List<string> textos;
        List<string> frases;
        string fraseActual;
        Random random = new Random();
        int segundosJugados = 0;

        public FormBingo()
        {
            InitializeComponent();

            textos = new List<string>
            {
                "Singleton", "Factory Method", "Strategy", "Observer", "Command",
                "Decorator", "Adapter", "State", "Template Method", "MVC",
                "Prototype", "Builder", "Mediator", "Facade", "Composite",
                "God Object", "Spaghetti Code", "Duplicate Code", "Hard Coding", "Lava Flow",
                "Golden Hammer", "Copy-Paste Programming", "Shotgun Surgery", "Feature Envy", "Premature Optimization",
                "Magic Numbers", "God Method", "Circular Dependency", "Boat Anchor", "Poltergeist"
            };

            frases = new List<string>
            {
                "Permite una única instancia global del objeto.", // Singleton
                "Crea objetos de distintos tipos sin especificar la clase exacta.", // Factory Method
                "Permite cambiar el comportamiento de un algoritmo en tiempo de ejecución.", // Strategy
                "Permite que los objetos se suscriban a eventos de otros objetos.", // Observer
                "Encapsula una acción o solicitud como un objeto independiente.", // Command
                "Agrega funcionalidades sin modificar el código original.", // Decorator
                "Convierte la interfaz de una clase en otra que el cliente espera.", // Adapter
                "Permite que un objeto cambie su comportamiento cuando cambia su estado interno.", // State
                "Define el esqueleto de un algoritmo y deja que las subclases implementen los detalles.", // Template Method
                "Patrón arquitectónico que separa modelo, vista y controlador.", // MVC
                "Crea nuevos objetos copiando un prototipo existente.", // Prototype
                "Permite construir objetos complejos paso a paso.", // Builder
                "Facilita la comunicación entre múltiples objetos sin acoplarlos directamente.", // Mediator
                "Proporciona una interfaz unificada para un conjunto de interfaces en un sistema.", // Facade
                "Combina objetos en estructuras jerárquicas para tratarlos de forma uniforme.", // Composite
                "Objeto que concentra demasiadas responsabilidades.", // God Object
                "Código con estructura desordenada y difícil de mantener.", // Spaghetti Code
                "Repetición innecesaria de código idéntico o similar.", // Duplicate Code
                "Valores escritos directamente en el código en lugar de usar constantes.", // Hard Coding
                "Código antiguo que sigue presente por miedo a eliminarlo.", // Lava Flow
                "Uso excesivo de una herramienta o patrón en todos los casos posibles.", // Golden Hammer
                "Copiar y pegar código en lugar de reutilizarlo correctamente.", // Copy-Paste Programming
                "Modificar un módulo obliga a cambiar muchos otros.", // Shotgun Surgery
                "Una clase muestra demasiado interés en los datos de otra clase.", // Feature Envy
                "Optimización prematura que complica el código innecesariamente.", // Premature Optimization
                "Uso de números sin explicación ni contexto.", // Magic Numbers
                "Método extremadamente largo y con demasiadas responsabilidades.", // God Method
                "Dos o más clases se dependen mutuamente de forma circular.", // Circular Dependency
                "Recurso que ya no se usa pero sigue presente en el sistema.", // Boat Anchor
                "Objeto que solo existe para pasar datos entre otros sin lógica útil." // Poltergeist
            };

            fraseActual = frases[random.Next(frases.Count)];
        }

        private void FormBingo_Load(object sender, EventArgs e)
        {
            textos = textos.OrderBy(x => random.Next()).ToList();

            int indice = 0;
            foreach (Control control in panelBingo.Controls)
            {
                if (control is Button && indice < textos.Count)
                {
                    control.Text = textos[indice];
                    indice++;
                }
            }

            textos = textos.OrderBy(x => random.Next()).ToList();
            indice = 0;
            foreach (Control control in panelBingo2.Controls)
            {
                if (control is Button && indice < textos.Count)
                {
                    control.Text = textos[indice];
                    indice++;
                }
            }

            timerJuego.Start();
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
            fraseActual = frases[random.Next(frases.Count)];

            this.Invalidate();
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
    }
}
