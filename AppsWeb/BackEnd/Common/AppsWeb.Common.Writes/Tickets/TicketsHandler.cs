using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;

using System;
using System.Data.SqlClient;

namespace AppsWeb.Common.Writes.Tickets
{
    /// <summary>
    /// Manejador de grabaciones de ticket 
    /// </summary>
    public class TicketsHandler
    {
        /// <summary>
        /// Consulta a ejecutar
        /// </summary>
        static string query;


        /// <summary>
        /// Grabación de un ticket nuevo
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <returns>Registros guardados</returns>
        public static RequestResult<int> SaveTicket(Ticket ticket, RepositoryDatabaseProviders provider, string connectionString)
        {
            RequestResult<int> result = new RequestResult<int>();

            try
            {
                if (ticket != null)
                {
                    ValidateTicket(ref ticket);
                    query = "insert into tsticket (ticid,ticcod,ticcon,ticreq,ticdes,ticsol,ticimp,ticobs,ticsta) values(@ticid,@ticcod,@ticcon,@ticreq,@ticdes,@ticsol,@ticimp,@ticobs,@ticsta)";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add(new SqlParameter("@ticid", ticket.Id));
                        command.Parameters.Add(new SqlParameter("@ticcod", ticket.CodeClient));
                        command.Parameters.Add(new SqlParameter("@ticcon", ticket.Control));
                        command.Parameters.Add(new SqlParameter("@ticreq", ticket.Requeriment));
                        command.Parameters.Add(new SqlParameter("@ticdes", ticket.Description));
                        command.Parameters.Add(new SqlParameter("@ticsol", ticket.Solution));
                        command.Parameters.Add(new SqlParameter("@ticimp", ticket.Impact));
                        command.Parameters.Add(new SqlParameter("@ticobs", ticket.Observations));
                        command.Parameters.Add(new SqlParameter("@ticsta", ticket.State));

                        connection.Open();

                        result.Result = command.ExecuteNonQuery();
                        if (result.Result > 0)
                        {
                            result.Successful = true;
                        }
                        else
                        {
                            result.Message = "No se guardo el ticket";
                            result.Successful = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Actualización del ticket
        /// </summary>
        /// <param name="ticket">Ticket a actualizar</param>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <returns>Registro actualizado</returns>
        public static RequestResult<bool> UpdateTicket(Ticket ticket, RepositoryDatabaseProviders provider, string connectionString)
        {
            RequestResult<bool> result = new RequestResult<bool>();

            try
            {
                query = "update tsticket set ticcod = @ticcod, ticcon = @ticcon, ticreq = @ticreq, ticdes = @ticdes, ticsol = @ticsol, ticimp = @ticimp, ticobs = @ticobs, ticsta = @ticsta where ticid = @ticid";
                ValidateTicket(ref ticket);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@ticcod", ticket.CodeClient));
                    command.Parameters.Add(new SqlParameter("@ticcon", ticket.Control));
                    command.Parameters.Add(new SqlParameter("@ticreq", ticket.Requeriment));
                    command.Parameters.Add(new SqlParameter("@ticdes", ticket.Description));
                    command.Parameters.Add(new SqlParameter("@ticsol", ticket.Solution));
                    command.Parameters.Add(new SqlParameter("@ticimp", ticket.Impact));
                    command.Parameters.Add(new SqlParameter("@ticobs", ticket.Observations));
                    command.Parameters.Add(new SqlParameter("@ticsta", ticket.State));
                    command.Parameters.Add(new SqlParameter("@ticid", ticket.Id));

                    connection.Open();

                    result.Result = command.ExecuteNonQuery() > 0;
                    result.Message = result.Successful ? "Registro actualizado exitosamente" : "No se actualizo el registro";
                    result.Successful = true;
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Valida la información del ticket
        /// </summary>
        /// <param name="ticket">Ticket</param>
        private static void ValidateTicket(ref Ticket ticket)
        {
            ticket.Description = !string.IsNullOrWhiteSpace(ticket.Description) ? ticket.Description : string.Empty;
            ticket.Impact = !string.IsNullOrWhiteSpace(ticket.Impact) ? ticket.Impact : string.Empty;
            ticket.Observations = !string.IsNullOrWhiteSpace(ticket.Observations) ? ticket.Observations : string.Empty;
            ticket.Solution = !string.IsNullOrWhiteSpace(ticket.Solution) ? ticket.Solution : string.Empty;
        }
    }
}
