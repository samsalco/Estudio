using EPS.Common.Models;
using EPS.Managers;
using EPS.Repositories.DatabaseManager;
using System.Threading.Tasks;

namespace EPS.WebServices
{
    public class LaboratoryViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de protocolo
        /// </summary>
        readonly LaboratoryManager manager;
        #endregion
        #region Constructor de clase
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public LaboratoryViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new LaboratoryManager(provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestResponse<int>> PostLaboratory(LaboratoryRequest request) => await manager.PostLaboratory(request);

        #endregion
    }
}
