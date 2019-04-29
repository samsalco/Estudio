namespace AppsWeb.Business.DatabaseManager.Interfaces
{
    /// <summary>
    /// Interfaz con verbos de acceso a recursos
    /// </summary>
    /// <typeparam name="T">Resultado a retornar</typeparam>
    /// <typeparam name="K">Parametros de entrada</typeparam>
    public interface IRepository<T,K>
    {
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        T Delete(K parameter);
        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        T Get(K parameter);
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        T Post(K parameter);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="parameter">Entrada</param>
        /// <returns>Resultado</returns>
        T Put(K parameter);
    }
}
