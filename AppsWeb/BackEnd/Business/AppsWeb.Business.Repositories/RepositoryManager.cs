
using AppsWeb.Business.DatabaseManager;
using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Business.Repositories.Tickets;

namespace AppsWeb.Business.Repositories
{
    public class RepositoryManager<T,K> : RepositoryBase<T,K>
    {
        //Repositorio que va a asignar
        readonly object repository;
        //Tipo de repositorio
        readonly ManagerRepositoryTypes repositoryType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameRepository">Nombre del repositorio a solicitar</param>
        /// <param name="provider">Proveedor BD</param>
        /// <param name="connectionString">Conexión a la base de datos</param>
        public RepositoryManager(string nameRepository, RepositoryDatabaseProviders provider, string connectionString)
        {
            switch (nameRepository)
            {
                case "GetTickets":
                    repository = new TicketGetRepository(provider, connectionString);
                    repositoryType = ManagerRepositoryTypes.GetTickets;
                    break;
                case "PostTicket":
                    repository = new TicketPostRepository(provider, connectionString);
                    repositoryType = ManagerRepositoryTypes.PostTicket;
                    break;
                case "PutTicket":
                    repository = new TicketPutRepository(provider, connectionString);
                    repositoryType = ManagerRepositoryTypes.PutTicket;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Consulta
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override T Get(K parameter)
        {
            switch (repositoryType)
            {
                case ManagerRepositoryTypes.GetTickets:
                    return (T)(object)((TicketGetRepository)repository).Get(parameter);                                
                default:
                    break;
            }
            return base.Get(parameter);
        }
        /// <summary>
        /// Grabación
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override T Post(K parameter)
        {
            switch (repositoryType)
            {                
                case ManagerRepositoryTypes.PostTicket:
                    return (T)(object)((TicketPostRepository)repository).Post(parameter);             
                default:
                    break;
            }            
            return base.Post(parameter);
        }
        /// <summary>
        /// Actualización
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override T Put(K parameter)
        {
            switch (repositoryType)
            {
                case ManagerRepositoryTypes.PutTicket:
                    return (T)(object)((TicketPutRepository)repository).Put(parameter);
                default:
                    break;
            }
            
            return base.Put(parameter);
        }
        /// <summary>
        /// Borrado
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override T Delete(K parameter)
        {
            switch (repositoryType)
            {                
                default:
                    break;
            }
            
            return base.Delete(parameter);
        }
    }
}
