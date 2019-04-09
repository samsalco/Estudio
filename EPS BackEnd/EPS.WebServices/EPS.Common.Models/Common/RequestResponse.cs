namespace EPS.Common.Models
{
    /// <summary>
    /// Respuesta de API
    /// </summary>
    public class RequestResponse<T>
    {
        /// <summary>
        /// Message related to response
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Response status
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// delivered result
        /// </summary>
        public T Result { get; set; }
    }
}
