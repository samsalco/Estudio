using EPS.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocolController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel protocolo
        /// </summary>
        readonly ProtocolViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public ProtocolController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new ProtocolViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion
        /// <summary>
        /// Adicionar protocolo
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] ProtocolRequest request)
        {
            return Ok(viewmodel.PostProtocol(request));
        }
    }
}
