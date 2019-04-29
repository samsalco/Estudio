using AppsWeb.Business.DatabaseManager;
using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Business.DatabaseManager.Interfaces;
using AppsWeb.Business.Repositories.Enum;

namespace AppsWeb.Business.Repositories
{
    /// <summary>
    /// Fabrica de repositorios
    /// </summary>
    /// <typeparam name="T">Entrada</typeparam>
    /// <typeparam name="K">Resultado</typeparam>
    public class RepositoryFactory<T,K> : IRepository<T, K>
    {
        readonly RepositoryType repository;

        public RepositoryBase<T,K> Repository { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repositoryType"></param>
        public RepositoryFactory(RepositoryType repositoryType)
        {
            repository = repositoryType;
        }

        /// <summary>
        /// Borrar
        /// </summary>
        /// <param name="parameter">Parámetros de entrada</param>
        /// <returns>Resultado</returns>
        public T Delete(K parameter)
        {
            return Repository.Delete(parameter);
        }
        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="parameter">Parámetros de entrada</param>
        /// <returns>Resultado</returns>
        public T Get(K parameter)
        {
            return Repository.Get(parameter);
        }
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="parameter">Parámetros de entrada</param>
        /// <returns>Resultado</returns>
        public T Post(K parameter)
        {
            return Repository.Post(parameter);
        }

        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="parameter">Parámetros de entrada</param>
        /// <returns>Resultado</returns>
        public T Put(K parameter)
        {
            return Repository.Put(parameter);
        }

        public void GetRepository(string repositoryName, RepositoryDatabaseProviders provider, string connectionString)
        {
            switch (repository)
            {
                default:
                case RepositoryType.DatabaseManager:
                    Repository = new RepositoryManager<T, K>(repositoryName, provider, connectionString);
                    break;
                case RepositoryType.ORM:
                    break;
                case RepositoryType.NoSql:
                    break;
                case RepositoryType.Integration:
                    break;                
            }
        }
    }
}
