using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public class Partida
    {
        private int idPartida;
        private string estado;
        private DateTime fecha;

        public int IdPartida { get => idPartida; set => idPartida = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
