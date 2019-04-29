using AppsWeb.Business.DatabaseManager;
using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;

namespace AppsWeb.Business.Repositories.Tickets
{
    /// <summary>
    /// Repositorio para grabar tickets
    /// </summary>
    public class TicketPostRepository : RepositoryBase<RequestResult<int>,object>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public TicketPostRepository(RepositoryDatabaseProviders provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Grabación del ticket
        /// </summary>
        /// <param name="parameter">Ticket</param>
        /// <returns>Registros guardados</returns>
        public override RequestResult<int> Post(object request)
        {
            //Llamamos al manejador de la grabación del ticket 
            return Common.Writes.Tickets.TicketsHandler.SaveTicket((Ticket)request,Provider,ConnectionString);
        }        
    }
}
