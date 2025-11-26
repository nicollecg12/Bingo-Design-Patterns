using Bingo_Design_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Repository
{
    public class PalabraRepository : IPalabraRepository
    {
        private readonly string _connectionString;

        public PalabraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Dictionary<string, string> ObtenerPatrones()
        {
            var patrones = new Dictionary<string, string>();

            string query = "SELECT palabra, frase FROM Palabra";

            using (SqlConnection cn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string clave = reader.GetString(0);
                        string valor = reader.GetString(1);

                        patrones[clave] = valor;
                    }
                }
            }

            return patrones;
        }
    }
}
