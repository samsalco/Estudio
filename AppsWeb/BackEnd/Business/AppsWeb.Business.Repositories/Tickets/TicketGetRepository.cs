using AppsWeb.Business.DatabaseManager;
using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;
using AppsWeb.Common.Read.Tickets;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppsWeb.Business.Repositories.Tickets
{
    public class TicketGetRepository : RepositoryBase<Task<RequestResult<List<Ticket>>>,object>
    {
        /// <summary>
        /// Constructor del repositorio de Tickets
        /// </summary>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public TicketGetRepository(RepositoryDatabaseProviders provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Consulta de tickets
        /// </summary>
        /// <param name="request">Parametro de consulta</param>
        /// <returns>Lista de tickets</returns>
        public override async Task<RequestResult<List<Ticket>>> Get(object request)
        {
            //Si no llega parametros es porque se quiere obtener todos los tickets, de lo contrario se esta buscando 
            //un ticket especifico
            return Task.Run(()=> TicketHandler.GetTicket(Provider,ConnectionString, request)).Result;
        }        
    }
}
