using EPS.Common.Models;
using EPS.Common.Reads;
using System;

namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Repositrio de usuario
    /// </summary>
    public class UserRepository : RepositoryBase<RequestResponse<User>, Tuple<string, string>>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="provider">Provvedor de BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public UserRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener usuario
        /// </summary>
        /// <param name="request">Parametros de petición</param>
        /// <returns>Response</returns>
        public override RequestResponse<User> Get(Tuple<string, string> request)
        {
            return UserHandler.GetUser(request.Item1, request.Item2, Provider.ToString(), ConnectionString);
        }
        #endregion
    }
}
