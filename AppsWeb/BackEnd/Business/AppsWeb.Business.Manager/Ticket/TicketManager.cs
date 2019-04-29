using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Business.Repositories;
using AppsWeb.Common.Models.Common;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppsWeb.Business.Manager.Ticket
{
    /// <summary>
    /// Manejador de tickets
    /// </summary>
    public class TicketManager
    {        
        /// <summary>
        /// Repositorio para consultar un ticket especifico
        /// </summary>
        readonly RepositoryFactory<Task<RequestResult<List<Common.Models.Tickets.Ticket>>>, object> repositoryImplementatorGetTicket;
        /// <summary>
        /// Repositorio para grabar 
        /// </summary>
        readonly RepositoryFactory<RequestResult<int>, object> repositoryImplementatorPostTicket;
        /// <summary>
        /// Repositorio para actualizar
        /// </summary>
        readonly RepositoryFactory<RequestResult<bool>, object> repositoryImplementatorPutTicket;
        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public TicketManager(RepositoryDatabaseProviders provider, string connectionString)
        {
            //Consulta 
            repositoryImplementatorGetTicket = new RepositoryFactory<Task<RequestResult<List<Common.Models.Tickets.Ticket>>>, object>(Repositories.Enum.RepositoryType.DatabaseManager);
            repositoryImplementatorGetTicket.GetRepository("GetTickets", provider, connectionString);
            //Grabación
            repositoryImplementatorPostTicket = new RepositoryFactory<RequestResult<int>, object>(Repositories.Enum.RepositoryType.DatabaseManager);
            repositoryImplementatorPostTicket.GetRepository("PostTicket", provider, connectionString);
            //Actualización 
            repositoryImplementatorPutTicket = new RepositoryFactory<RequestResult<bool>, object>(Repositories.Enum.RepositoryType.DatabaseManager);
            repositoryImplementatorPutTicket.GetRepository("PutTicket", provider, connectionString);
        }

        /// <summary>
        /// Consulta de todos los tickets
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestResult<List<Common.Models.Tickets.Ticket>>> Get(object request)
        {
            return await repositoryImplementatorGetTicket.Get(request);
        }
        /// <summary>
        /// Guarda un ticket
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registros guardados</returns>
        public RequestResult<int> Post(object request)
        {
            return repositoryImplementatorPostTicket.Post(request);
        }
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registro actualizado</returns>
        public RequestResult<bool> Put(object request)
        {
            return repositoryImplementatorPutTicket.Put(request);
        }
    }
}
