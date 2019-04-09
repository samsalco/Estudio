using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel protocolo
        /// </summary>
        readonly OrderViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public OrderController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new OrderViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion

        /// <summary>
        /// Obtener protocolos del paciente
        /// </summary>
        /// <param name="value"></param>
        [HttpGet("{history}/{tipo}")]
        public IActionResult Get(int history, string tipo)
        {
            if (tipo == "all") tipo = string.Empty;

            return Ok(viewmodel.GetOrders(history, tipo));
        }
    }
}
