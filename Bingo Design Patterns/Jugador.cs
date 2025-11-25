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
       public  Jugador (string nombre, int edad,string numero, string user, string contraseña,string tipo ) : base (nombre, edad,numero, user, contraseña,tipo) 
        { 
        }

        public Jugador(int idJugador,string nombre, int edad, string numero, string user , DateTime Fecha_registro) :base(idJugador,nombre,edad,numero,user,Fecha_registro)
        {
        }
        public interface IClienteActivoRepository
        {
            List<Jugador> ObtenerTodos();
        }
        public override string VerificarCreacion()
        {
            return "¡Jugador registrado exitosamente!";
        }

      
    }
}
