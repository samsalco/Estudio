using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AppsWeb.Common.Read.Tickets
{
    /// <summary>
    /// Manejador de tickets
    /// </summary>
    public class TicketHandler
    {
        static RequestResult<List<Ticket>> result;
        static List<Ticket> listT;
        static string query;
        
        /// <summary>
        /// Consulta un ticket especifico
        /// </summary>
        /// <param name="request">Identificador</param>
        /// <param name="provider">Proveedor</param>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <returns></returns>
        public static RequestResult<List<Ticket>> GetTicket(RepositoryDatabaseProviders provider, string connectionString, object request)
        {
            result = new RequestResult<List<Ticket>>();
            listT = new List<Ticket>();
            int? id = request != null ? Convert.ToInt32(request.ToString()) : new Nullable<int>();
            try
            {
                query = "select ticid,ticcod,ticcon,ticreq,ticdes,ticsol,ticimp,ticobs,ticsta from tsticket";
                if (id.HasValue)
                {
                    query = $"{query} where ticid = @ticid";                    
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    if (id.HasValue)
                    {                        
                        command.Parameters.Add(new SqlParameter("@ticid", request));
                    }

                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        listT.Add(new Ticket()
                        {
                            Id = rd.GetInt32(0),
                            CodeClient = rd.GetString(1),
                            Control = !rd.IsDBNull(4) ? rd.GetInt32(2) : 0,
                            Requeriment = !rd.IsDBNull(3) ? rd.GetInt32(3) : 0,
                            Description = !rd.IsDBNull(4) ? rd.GetString(4) : string.Empty,
                            Solution = !rd.IsDBNull(5) ? rd.GetString(5) : string.Empty,
                            Impact = !rd.IsDBNull(6) ? rd.GetString(6) : string.Empty,
                            Observations = !rd.IsDBNull(7) ? rd.GetString(7) : string.Empty,
                            State = rd.GetString(8)
                        });
                    }
                    rd.Close();
                }
                if (listT.Count > 0)
                {
                    result.Successful = true;
                    result.Result = listT;
                }
                else
                {
                    result.Successful = false;
                    result.Message = "No existe la información solicitada";
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
