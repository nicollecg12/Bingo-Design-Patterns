using Bingo_Design_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Repository
{
    public class PalabraRepository2 : IPalabraRepository2
    {
        private readonly string _connectionString;

        public PalabraRepository2(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Palabra> GetAll()
        {
            List<Palabra> lista = new List<Palabra>();
            string query = "SELECT * FROM Palabra";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Palabra
                        {
                            IdPalabra = Convert.ToInt32(reader["id_palabra"]),
                            Palabra1 = reader["palabra"].ToString(),
                            Frase = reader["frase"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
