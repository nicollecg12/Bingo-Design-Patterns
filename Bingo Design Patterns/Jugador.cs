using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public class Jugador:Usuario
    {
       public  Jugador (string nombre, string numero, string user, string contraseña) : base (nombre, numero, user, contraseña) 
        { 
        }
        public override string VerificarCreacion()
        {
            return "¡Jugador registrado exitosamente!";
        }
    }
}
