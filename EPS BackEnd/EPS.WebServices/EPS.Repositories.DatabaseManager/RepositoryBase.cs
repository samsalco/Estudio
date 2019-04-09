using System.Threading.Tasks;

namespace EPS.Repositories.DatabaseManager
{
    public class RepositoryBase<T, K> : IRepository<T, K>
    {
        public RepositoryDatabaseProvider Provider { get; protected set; }
        public string ConnectionString { get; protected set; }

        /// <summary>
        /// Eliminar registros
        /// </summary>
        /// <param name="data">Datos de entrada</param>
        /// <returns>Entero con los registros afectados</returns>
        public virtual int Delete(K data)
        {
            return 0;
        }
        /// <summary>
        /// Actualiza datos
        /// </summary>
        /// <param name="data">Datos de entrada</param>
        /// <returns>Cantidad de registros</returns>
        public virtual int Put(K data)
        {
            return 0;
        }
        /// <summary>
        /// Obtiene los datos
        /// </summary>
        /// <param name="parameters">Parámetros </param>
        /// <returns>Devuelve el tipo de dato</returns>
        public virtual T Get(K parameters)
        {
            return default(T);
        }
        /// <summary>
        /// Inserta datos en el repositorio
        /// </summary>
        /// <param name="parameters">Parámetros de ingreso</param>
        /// <returns>Datos a guardar</returns>
        public virtual T Post(K parameters)
        {
            return default(T);
        }
        /// <summary>
        /// Inserta datos en el repositorio Asyncrono
        /// </summary>
        /// <param name="parameters">Parámetros de ingreso</param>
        /// <returns>Datos a guardar</returns>
        public virtual Task< T> PostAsync(K parameters)
        {
            return Task.FromResult( default(T));
        }
    }
}
