using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public class GestorUsuarios
    {
        public static GestorUsuarios _instancia;
        private List<Usuario> usuarios;

        private GestorUsuarios() 
        { 
        usuarios = new List<Usuario>();
        }

        public static GestorUsuarios Instancia 
        {
            get 
            {
                if (_instancia == null) 
                { 
                _instancia = new GestorUsuarios();
                }
                return _instancia;
            }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }
    }
}
