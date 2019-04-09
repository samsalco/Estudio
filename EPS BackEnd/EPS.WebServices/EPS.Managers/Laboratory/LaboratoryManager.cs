using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;
using System.Threading.Tasks;

namespace EPS.Managers
{
    public class LaboratoryManager
    {
        #region Members
        /// <summary>
        /// Factoria de laboratorio
        /// </summary>
        readonly RepositoryFactory<Common.Models.RequestResponse<int>, LaboratoryRequest> repositoryImplementatorPostLaboratory;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public LaboratoryManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            ///Todos los usuarios
            repositoryImplementatorPostLaboratory = new RepositoryFactory<RequestResponse<int>, LaboratoryRequest>(RepositoryType.DatabaseManager);
            repositoryImplementatorPostLaboratory.GetRepository("LaboratoryPostAsync", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar laboratorio
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestResponse<int>> PostLaboratory(LaboratoryRequest request) => await repositoryImplementatorPostLaboratory.PostAsync(request);
        #endregion
    }
}
