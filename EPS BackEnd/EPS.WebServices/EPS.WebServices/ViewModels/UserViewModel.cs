using EPS.Common.Models;
using EPS.Common.Reads;
using EPS.Managers;
using EPS.Repositories.DatabaseManager;
using System.Collections.Generic;

namespace EPS.WebServices
{
    /// <summary>
    /// ViewModel de usuario
    /// </summary>
    public class UserViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de usuario
        /// </summary>
        readonly UserManager manager;
        #endregion

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public UserViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new UserManager(provider, connectionString);
        }
        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        public RequestResponse<List<User>> GetUsers()
        {
            return manager.GetAllUsers(null);
        }
        /// <summary>
        /// Obtener un usuario
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        public RequestResponse<User> GetUser(string id, string password)
        {
            return manager.GetUser(id, password);
        }
        /// <summary>
        /// Insertar un usuario
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <returns></returns>
        public RequestResponse<int> PostUser(User user)
        {            
            return manager.PostUser(user);
        }
        /// <summary>
        /// Actualizar usuario
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <returns></returns>
        public RequestResponse<int> PutUser(User user)
        {
            return null;
        }
    }
}
