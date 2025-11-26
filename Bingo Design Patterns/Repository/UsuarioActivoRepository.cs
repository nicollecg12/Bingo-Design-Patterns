using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Repository
{
    public class UsuarioActivoRepository : IUsuarioActivoRepository
    {
        private readonly string _connectionString;

        public UsuarioActivoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Jugador> GetAll()
        {
            List<Jugador> lista = new List<Jugador>();
            string query = "SELECT * FROM vwUsuariosActivos";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jugador u = new Jugador(    
                        Convert.ToInt32(reader["id_jugador"]),
                        reader["nombre_Completo"].ToString(),
                        Convert.ToInt32(reader["edad"]),
                        reader["telefono"].ToString(),
                        reader["loginName"].ToString(),
                        Convert.ToDateTime(reader["fecha_registro"])
                        );

                        lista.Add(u);
                    }
                }
            }

            return lista;
        }
    }
}
