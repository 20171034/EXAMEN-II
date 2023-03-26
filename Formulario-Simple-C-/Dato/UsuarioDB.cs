using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDB
    {
        private ConexionDB dbConn;

        public UsuarioDB()
        {
            this.dbConn = new ConexionDB();
        }

        public bool Login(string codigoUsuario, string contrasena)
        {
            using (var connection = this.dbConn.conectarse())
            {
                using (var command = new MySqlCommand("SELECT COUNT(*) FROM Usuarios WHERE id = @CodigoUsuario AND contrasena = @Contrasena", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);
                    int result = (int)command.ExecuteScalar();
                    return result == 1;
                }
            }
        }
    }
}
