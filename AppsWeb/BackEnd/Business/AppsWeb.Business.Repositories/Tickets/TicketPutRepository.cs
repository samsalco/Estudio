using AppsWeb.Business.DatabaseManager;
using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;

namespace AppsWeb.Business.Repositories.Tickets
{
    /// <summary>
    /// Repositorio para actualizar ticket
    /// </summary>
    public class TicketPutRepository : RepositoryBase<RequestResult<bool>,object>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public TicketPutRepository(RepositoryDatabaseProviders provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Actualización de un ticket
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registro actualizado</returns>
        public override RequestResult<bool> Put(object request)
        {
            return Common.Writes.Tickets.TicketsHandler.UpdateTicket((Ticket)request, Provider, ConnectionString);
        }
    }
}
