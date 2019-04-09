using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;
using System.Collections.Generic;

namespace EPS.Managers.Protocol
{
    public class ProtocolManager
    {
        #region Members
        /// <summary>
        /// Factoria de protocolo
        /// </summary>
        readonly RepositoryFactory<RequestResponse<int>, ProtocolRequest> repositoryImplementatorPostProtocol;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public ProtocolManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            ///Todos los usuarios
            repositoryImplementatorPostProtocol = new RepositoryFactory<RequestResponse<int>, ProtocolRequest>(RepositoryType.DatabaseManager);
            repositoryImplementatorPostProtocol.GetRepository("ProtocolPost", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<int> PostProtocol(ProtocolRequest request)
        {
            return repositoryImplementatorPostProtocol.Post(request);
        }
        #endregion
    }
}
