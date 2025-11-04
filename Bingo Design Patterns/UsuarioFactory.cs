using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public class UsuarioFactory
    {
        public static Usuario CrearUsuario(string nombre, int edad, string numero, string user, string contraseña, string tipo) 
        {
            if (tipo == "Jugador")
            {
                return new Jugador(nombre, edad, numero, user, contraseña);
            }
            if (tipo == "Administrador")
            {
                return new Administrador(nombre, edad, numero, user, contraseña);
            }
            else
            {
                throw new ArgumentException("Tipo de usuario no válido");
            }
        }
    }
}
