using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionDB
    {
        private string cadenaConexion;
        private string server = "localhost";
        private string database = "";
        private string port = "3306";
        private string password = "";
        private string user = "root";
        public ConexionDB()
        {
            this.cadenaConexion = $"server={server};port={port};user={user};password={password};database={database}";
        }

        public MySqlConnection conectarse()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
