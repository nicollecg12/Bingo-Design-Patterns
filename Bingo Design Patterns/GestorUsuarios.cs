using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public class GestorUsuarios
    {
        private static GestorUsuarios _instancia;

        private List<Usuario> usuarios;
        private string connectionString = "Server=DESKTOP-HRMH4OH;Database=Bingo;Integrated Security=True;";

        private GestorUsuarios()
        {
            usuarios = new List<Usuario>();
        }

        public static GestorUsuarios Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GestorUsuarios();

                return _instancia;
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            int Id;
            string NombreCompleto, LoginName, Correo;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               
                string query = "SELECT * FROM vw_UsuariosActivos";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   // int id_jugador = Convert.ToInt32(dr["id_jugador"]);
                   // DateTime fecha_registro = Convert.ToDateTime(dr["id_jugador"]);
                    string nombre = dr["nombre_Completo"].ToString();
                    string user = dr["loginName"].ToString();
                    string contraseña = dr["contrasena_hash"].ToString();
                    int edad = Convert.ToInt32(dr["edad"]);
                    string numero = dr["telefono"].ToString();           
                    string tipo = dr["rol"].ToString();

                    Usuario u;

                    if (tipo == "Administrador")
                    {
                        u = new Administrador(nombre, edad, numero, user, contraseña, tipo);
                    }
                    else
                    {
                        u = new Jugador(nombre, edad, numero, user, contraseña, tipo);
                    }

                    lista.Add(u);
                }
            }

            usuarios = lista;
            return lista;
        }

        public Usuario BuscarUsuario(string login)
        {
            foreach (var user in usuarios)
            {
                if (user.User == login)
                    return user;
            }
            return null;
        }
    }
}
