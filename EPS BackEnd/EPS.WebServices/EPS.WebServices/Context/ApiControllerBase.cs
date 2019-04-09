using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices
{
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// Conexión
        /// </summary>
        internal readonly ConnectionContext ConnectionContext;
        /// <summary>
        /// Establece la conexión
        /// </summary>
        /// <param name="connectionContext">Conexto</param>
        public ApiControllerBase(IOptions<ConnectionContext> connectionContext)
        {
            ConnectionContext = connectionContext?.Value;
        }


    }
}
