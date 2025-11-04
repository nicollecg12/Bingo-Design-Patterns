using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Numero { get; set; }
        public string User { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string nombre, int edad,string numero, string user, string contraseña)
        {

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(user)|| string.IsNullOrWhiteSpace(contraseña)|| string.IsNullOrWhiteSpace(numero))
            {
                throw new ArgumentException("No puede dejar campos vacíos");
            }
            if (contraseña.Length < 8)
            {
                throw new ArgumentException("La contraseña debe contener al menos 8 caracteres");
            }
            if (user.Length < 3)
            {
                throw new ArgumentException("El nombre de usuario debe contener al menos 3 caracteres");
            }
            if (edad < 12)
            {
                throw new ArgumentException("Debe tener al menos 12 años");
            }
           

            Nombre = nombre;
            Numero = numero;
            User = user;
            Contraseña = contraseña;
            Edad = edad;
        }

        public abstract string VerificarCreacion();
        
    }
}
