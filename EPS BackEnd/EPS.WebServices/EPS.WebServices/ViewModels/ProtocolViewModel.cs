using EPS.Common.Models;
using EPS.Managers.Protocol;
using EPS.Repositories.DatabaseManager;
using System.Collections.Generic;

namespace EPS.WebServices
{
    /// <summary>
    /// ViewModel protocolo
    /// </summary>
    public class ProtocolViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de protocolo
        /// </summary>
        readonly ProtocolManager manager;
        #endregion
        #region Constructor de clase
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public ProtocolViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new ProtocolManager(provider, connectionString);
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
            return manager.PostProtocol(request);
        }
        #endregion
    }
}
