using EPS.Repositories.DatabaseManager;
using System.Threading.Tasks;

namespace EPS.Repositories
{
    /// <summary>
    /// Factoria de repositorios
    /// </summary>
    public class RepositoryFactory<T, K> : IRepository<T, K>
    {
        #region Members
        readonly RepositoryType repository;
        public RepositoryBase<T, K> Repository { get; private set; }
        #endregion
        #region Constructor de clase
        public RepositoryFactory(RepositoryType repositoryType)
        {
            repository = repositoryType;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(K data)
        {
            return Repository.Delete(data);
        }
        /// <summary>
        /// Obtener
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T Get(K parameters)
        {
            return Repository.Get(parameters);
        }
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T Post(K parameters)
        {
            return Repository.Post(parameters);
        }
        public async Task<T> PostAsync(K parameters)
        {
            return await Repository.PostAsync(parameters);
        }
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Put(K data)
        {
            return Repository.Put(data);
        }
        /// <summary>
        /// Obtener repositorio
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <param name="provider"></param>
        /// <param name="ConnectionString"></param>
        public void GetRepository(string repositoryName, RepositoryDatabaseProvider provider, string ConnectionString)
        {
            switch (repository)
            {
                case RepositoryType.DatabaseManager:
                default:
                    Repository = new ManagerRepository<T, K>(repositoryName, provider, ConnectionString);
                    break;
            }
        }
        #endregion
    }
}
