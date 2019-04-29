namespace AppsWeb.Common.Models.Common
{
    /// <summary>
    /// Resultado de la solicitud
    /// </summary>
    /// <typeparam name="T">Resultado</typeparam>
    public class RequestResult<T>
    {
        /// <summary>
        /// Estado de la consulta
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Mensaje de la api
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Resultado de la consulta
        /// </summary>
        public T Result { get; set; }
    }
}
