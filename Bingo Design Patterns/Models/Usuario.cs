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
        private int idUsuario;
        private string nombre;
        private int edad;
        private string numero;
        private string user;
        private string contraseña;
        private string tipo;
        private DateTime fecha_registro;


        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Numero { get => numero; set => numero = value; }
        public string User { get => user; set => user = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public DateTime Fecha_registro { get => fecha_registro; set => fecha_registro = value; }

        public Usuario() { }

        public Usuario(int idJugador, string nombre, int edad, string numero, string user, DateTime Fecha_registro)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(user)  || string.IsNullOrWhiteSpace(numero))
            {
                throw new ArgumentException("No puede dejar campos vacíos");
              
            } 
            if (user.Length < 3)
            {
                throw new ArgumentException("El nombre de usuario debe contener al menos 3 caracteres");
                
            }
            if (edad < 12)
            {
                throw new ArgumentException("Debe tener al menos 12 años");
               
            }

            idUsuario = idJugador;
            Nombre = nombre;
            User = user;
            Edad = edad;
            Numero = numero;
            User = user;
            fecha_registro = Fecha_registro;


        }
        public Usuario(string nombre, int edad,string numero, string user, string contraseña,string Tipo)
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
            tipo = Tipo;
            
        }



        public abstract string VerificarCreacion();
        
    }
}
