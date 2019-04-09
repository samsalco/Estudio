namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Interface con metodos, entradas retornos requeridos
    /// </summary>
    /// <typeparam name="T">objeto a retornar</typeparam>
    /// <typeparam name="K">Parametro entrada</typeparam>
    public interface IRepository<T, K>
    {
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Numero de valores afectados</returns>
        int Delete(K data);
        /// <summary>
        /// Obtener
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Objeto</returns>
        T Get(K parameters);
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Objeto</returns>
        T Post(K parameters);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Numero de items afectados</returns>
        int Put(K data);
    }
}
