using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public class Administrador: Usuario
    {
        public Administrador(string nombre, int edad,string numero, string user, string contraseña) : base(nombre, edad,numero, user, contraseña)
        {
        }
        public override string VerificarCreacion()
        {
            return "¡Administrador registrado exitosamente!";
        }
    }
}
