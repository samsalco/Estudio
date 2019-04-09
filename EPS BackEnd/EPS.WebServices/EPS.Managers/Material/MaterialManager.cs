using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;

namespace EPS.Managers
{
    public class MaterialManager
    {
        #region Members
        /// <summary>
        /// Factoria de laboratorio
        /// </summary>
        readonly RepositoryFactory<RequestResponse<int>, MaterialRequest> repositoryImplementatorPostMaterial;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public MaterialManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            ///Todos los usuarios
            repositoryImplementatorPostMaterial = new RepositoryFactory<RequestResponse<int>, MaterialRequest>(RepositoryType.DatabaseManager);
            repositoryImplementatorPostMaterial.GetRepository("MaterialPost", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adicionar Material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<int> PostMaterial(MaterialRequest request)
        {
            return repositoryImplementatorPostMaterial.Post(request);
        }
        #endregion
    }
}
