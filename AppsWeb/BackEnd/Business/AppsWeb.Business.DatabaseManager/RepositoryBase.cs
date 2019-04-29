using AppsWeb.Business.DatabaseManager.Enums;
using AppsWeb.Business.DatabaseManager.Interfaces;

namespace AppsWeb.Business.DatabaseManager
{
    /// <summary>
    /// Respositorio Base para ejecutar los verbos de acceso a recursos
    /// </summary>
    /// <typeparam name="T">Resultado</typeparam>
    /// <typeparam name="K">Entrada</typeparam>
    public class RepositoryBase<T, K> : IRepository<T, K>
    {
        /// <summary>
        /// Proveedor BD
        /// </summary>
        public RepositoryDatabaseProviders Provider { get; protected set; }
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        public string ConnectionString { get; protected set; }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        public virtual T Delete(K parameter)
        {
            return default(T);
        }

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        public virtual T Get(K parameter)
        {
            return default(T);
        }
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        public virtual T Post(K parameter)
        {
            return default(T);
        }
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        public virtual T Put(K parameter)
        {
            return default(T);
        }
    }
}
