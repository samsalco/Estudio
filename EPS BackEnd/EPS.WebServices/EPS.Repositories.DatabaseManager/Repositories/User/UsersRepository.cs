using EPS.Common.Models;
using EPS.Common.Reads;
using System.Collections.Generic;

namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Repositorio de todos los usuario
    /// </summary>
    public class UsersRepository: RepositoryBase<RequestResponse<List<User>>, object>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="provider">Provvedor de BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public UsersRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <param name="request">Parametros de petición</param>
        /// <returns>Response</returns>
        public override RequestResponse<List<User>> Get(object request)
        {
            return UserHandler.GetAllUsers(Provider.ToString(), ConnectionString);
        }
        #endregion
    }
}
