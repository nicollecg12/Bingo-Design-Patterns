using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public class ClienteActivoRepository : IClienteActivoRepository
    {
        private readonly string _connectionString;

        public ClienteActivoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Jugador> ObtenerTodos()
        {
            List<Jugador> lista = new List<Jugador>();

            string query = "SELECT * FROM vw_ClientesActivos";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Jugador(
                    Convert.ToInt32(dr["id_jugador"]),
                    dr["nombre_Completo"].ToString(),
                    Convert.ToInt32(dr["edad"]),
                    Convert.ToString(dr["telefono"]),
                    dr["loginName"].ToString(),
                    Convert.ToDateTime(dr["fecha_registro"])
                    ));
                }
            }

            return lista;
        }
    }
}
