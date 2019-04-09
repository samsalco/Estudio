using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;

namespace EPS.Managers
{
    public class MedicineManager
    {
        #region Members
        /// <summary>
        /// Factoria de Medicamentos
        /// </summary>
        readonly RepositoryFactory<RequestResponse<int>, MedicineRequest> repositoryImplementatorPostMedicine;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public MedicineManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            ///Todos los usuarios
            repositoryImplementatorPostMedicine = new RepositoryFactory<RequestResponse<int>, MedicineRequest>(RepositoryType.DatabaseManager);
            repositoryImplementatorPostMedicine.GetRepository("MedicinePost", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar medicamento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<int> PostMedicine(MedicineRequest request)
        {
            return repositoryImplementatorPostMedicine.Post(request);
        }
        #endregion
    }
}
