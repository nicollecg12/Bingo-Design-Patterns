using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Design_Patterns
{
    public class ConexionBD
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;


        public static ConexionBD con = null;

        private ConexionBD()
        {
            this.Base = "Bingo";
            this.Servidor = "DESKTOP-HRMH4OH";
            this.Usuario = string.Empty;
            this.Clave = string.Empty;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = "Data Source=" + "." +//this.Servidor +
                                          "; Initial Catalog=" + this.Base +
                                          "; Integrated Security=True; trustservercertificate=true";
            }
            catch (Exception ex)
            {
                cadena = null;
                MessageBox.Show("no se conecto a la base de datos");
                throw ex;
            }
            return cadena;
        }

        public static ConexionBD CrearInstancia()
        {
            if (con == null)
            {
                con = new ConexionBD();
            }
            return con;

        }
    }
}
