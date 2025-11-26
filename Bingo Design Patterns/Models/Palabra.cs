using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Models
{
    public  class Palabra
    {
        private int idPalabra;
        private string palabra;
        private string frase;

        public int IdPalabra { get => idPalabra; set => idPalabra = value; }
        public string Palabra1 { get => palabra; set => palabra = value; }
        public string Frase { get => frase; set => frase = value; }
    }
}
