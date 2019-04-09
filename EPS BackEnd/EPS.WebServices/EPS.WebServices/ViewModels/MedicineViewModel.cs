using EPS.Common.Models;
using EPS.Managers;
using EPS.Repositories.DatabaseManager;

namespace EPS.WebServices
{
    public class MedicineViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de medicamento
        /// </summary>
        readonly MedicineManager manager;
        #endregion
        #region Constructor de clase
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public MedicineViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new MedicineManager(provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<int> PostMedicine(MedicineRequest request)
        {
            return manager.PostMedicine(request);
        }
        #endregion
    }
}
