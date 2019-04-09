using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;
using System;
using System.Collections.Generic;

namespace EPS.Managers
{
    /// <summary>
    /// Manejador de USuario
    /// </summary>
    public class UserManager
    {
        #region Members
        /// <summary>
        /// Factoria de usuarios
        /// </summary>
        readonly RepositoryFactory<RequestResponse<List<User>>, object> repositoryImplementatorAllUsers;

        /// <summary>
        /// Factoria de usuario
        /// </summary>
        readonly RepositoryFactory<RequestResponse<User>, Tuple<string, string>> repositoryImplementatorUser;

        /// <summary>
        /// Factoria adicionar usuario
        /// </summary>

        readonly RepositoryFactory<RequestResponse<int>, User> repositoryImplementatorPostUser;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public UserManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            ///Todos los usuarios
            repositoryImplementatorAllUsers = new RepositoryFactory<RequestResponse<List<User>>, object>(RepositoryType.DatabaseManager);
            repositoryImplementatorAllUsers.GetRepository("AllUsers", provider, connectionString);

            ///Un usuario
            repositoryImplementatorUser = new RepositoryFactory<RequestResponse<User>, Tuple<string, string>>(RepositoryType.DatabaseManager);
            repositoryImplementatorUser.GetRepository("User", provider, connectionString);

            ///Un usuario
            repositoryImplementatorPostUser = new RepositoryFactory<RequestResponse<int>, User>(RepositoryType.DatabaseManager);
            repositoryImplementatorPostUser.GetRepository("PostUser", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Recupera lista de todos los usuarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Listado de usuarios</returns>
        public RequestResponse<List<User>> GetAllUsers(object request)
        {
           return repositoryImplementatorAllUsers.Get(request);
        }
        /// <summary>
        /// Obtener usuario
        /// </summary>
        /// <param name="id">codigo</param>
        /// <param name="password">contraseña</param>
        /// <returns>usuario</returns>
        public RequestResponse<User> GetUser(string id, string password)
        {
            return repositoryImplementatorUser.Get(new Tuple<string, string>(id, password));
        }
        /// <summary>
        /// Adicionar usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public RequestResponse<int> PostUser(User user)
        {
          return repositoryImplementatorPostUser.Post(user);
        }
        #endregion
    }
}
