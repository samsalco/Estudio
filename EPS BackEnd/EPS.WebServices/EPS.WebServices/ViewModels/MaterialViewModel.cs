using EPS.Common.Models;
using EPS.Managers;
using EPS.Repositories.DatabaseManager;

namespace EPS.WebServices
{
    public class MaterialViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de material
        /// </summary>
        readonly MaterialManager manager;
        #endregion
        #region Constructor de clase
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public MaterialViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new MaterialManager(provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<int> PostMaterial(MaterialRequest request)
        {
            return manager.PostMaterial(request);
        }
        #endregion
    }
}
