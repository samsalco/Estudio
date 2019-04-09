using EPS.Common.Models;
using EPS.Common.Writes;

namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Repositorio de adicionar usuario
    /// </summary>
    public class UserPostRepository: RepositoryBase<RequestResponse<int>, User>
    {
        public UserPostRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar usuario
        /// </summary>
        /// <param name="parameters">usuario</param>
        /// <returns></returns>
        public override RequestResponse<int> Post(User user)
        {
            return UserWrites.AddUser(user, Provider.ToString(), ConnectionString);
        }
    }
}
