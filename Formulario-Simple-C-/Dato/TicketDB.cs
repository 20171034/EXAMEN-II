using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TicketDB
    {
        private ConexionDB dbConn;

        public TicketDB()
        {
            this.dbConn = new ConexionDB();
        }

        public bool generarTicket(Ticket ticket)
        {
            string query =
            "INSERT INTO Tickets " +
            "(fecha, usuario, cliente, tipo_soporte, descripcion_solicitud, " +
            "descripcion_respuesta, precio, impuesto, descuento, total) " +
            "VALUES (@Fecha, @Usuario, @Cliente, @TipoSoporte, " +
            "@DescripcionSolicitud, @DescripcionRespuesta, " +
            "@Precio, @Impuesto, @Descuento, @Total)";
            using (var connection = dbConn.conectarse())
            using (var command = new MySqlCommand(query, connection))
            {
                try {
                    connection.Open();
                    command.Parameters.AddWithValue("@Fecha", ticket.Fecha);
                    command.Parameters.AddWithValue("@Usuario", ticket.Usuario);
                    command.Parameters.AddWithValue("@Cliente", ticket.Cliente);
                    command.Parameters.AddWithValue("@TipoSoporte", ticket.TipoSoporte);
                    command.Parameters.AddWithValue("@DescripcionSolicitud", ticket.DescripcionSolicitud);
                    command.Parameters.AddWithValue("@DescripcionRespuesta", ticket.DescripcionRespuesta);
                    command.Parameters.AddWithValue("@Precio", ticket.Precio);
                    command.Parameters.AddWithValue("@Impuesto", ticket.Impuesto);
                    command.Parameters.AddWithValue("@Descuento", ticket.Descuento);
                    command.Parameters.AddWithValue("@Total", ticket.Total);
                    command.ExecuteNonQuery();
                    return true;
                } catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
