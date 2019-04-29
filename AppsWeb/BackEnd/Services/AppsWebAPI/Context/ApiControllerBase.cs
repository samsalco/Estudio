using AppsWeb.Business.DatabaseManager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppsWebAPI.Context
{
    /// <summary>
    /// Controlador Base de la Api
    /// </summary>
    public abstract class ApiControllerBase : ControllerBase
    {
        internal readonly ConnectionContext ConnectionContext;

        /// <summary>
        /// Establece la conexión
        /// </summary>
        /// <param name="connectionContext">Contexto de conexión BD</param>
        public ApiControllerBase(IOptions<ConnectionContext> connectionContext)
        {
            ConnectionContext = connectionContext?.Value;
        }
    }
}
