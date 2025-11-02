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
    public partial class FormBingo : Form
    {
        public FormBingo()
        {
            InitializeComponent();
        }

        private void FormBingo_Load(object sender, EventArgs e)
        {
            List<string> textos = new List<string>
            {         
              "Singleton", "Factory Method", "Strategy", "Observer", "Command",
              "Decorator", "Adapter", "State", "Template Method", "MVC",
              "Prototype", "Builder", "Mediator", "Facade", "Composite",
              "God Object", "Spaghetti Code", "Duplicate Code", "Hard Coding", "Lava Flow",
              "Golden Hammer", "Copy-Paste Programming", "Shotgun Surgery", "Feature Envy", "Premature Optimization",
              "Magic Numbers", "God Method", "Circular Dependency", "Boat Anchor", "Poltergeist"
            };

            Random random = new Random();
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
            Random random2 = new Random();
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

        }
    }
}
