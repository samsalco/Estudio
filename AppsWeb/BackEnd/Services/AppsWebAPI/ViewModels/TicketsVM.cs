using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Business.Manager.Ticket;
using AppsWeb.Common.Models.Common;
using AppsWeb.Common.Models.Tickets;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppsWebAPI.ViewModels
{
    public class TicketsVM
    {
        readonly TicketManager manager;

        /// <summary>
        /// Constructor de la viewModel
        /// </summary>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public TicketsVM(RepositoryDatabaseProviders provider,string connectionString)
        {
            manager = new TicketManager(provider, connectionString);
        }

        /// <summary>
        /// Consultamos todos los tickets
        /// </summary>
        /// <param name="request">Parametros</param>
        /// <returns>Lista de tickets</returns>        
        public async Task<RequestResult<List<Ticket>>> Get(object request)
        {
            return await manager.Get(request);
        }
        /// <summary>
        /// Guardamos un ticket
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registros guardados</returns>
        public RequestResult<int> Post(object request)
        {
            return manager.Post(request);
        }
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registro actualizado</returns>
        public RequestResult<bool> Put(object request)
        {
            return manager.Put(request);
        }
    }
}
