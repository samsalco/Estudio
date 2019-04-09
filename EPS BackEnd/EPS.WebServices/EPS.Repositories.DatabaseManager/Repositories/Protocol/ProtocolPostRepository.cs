using EPS.Common.Models;
using EPS.Common.Writes;

namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Repositorio post de protocolo
    /// </summary>
    public class ProtocolPostRepository: RepositoryBase<RequestResponse<int>, ProtocolRequest>
    {
        public ProtocolPostRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar un protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override RequestResponse<int> Post(ProtocolRequest request)
        {
            return ProtocolWrites.AddProtocol(request, Provider.ToString(), ConnectionString);
        }
    }
}
