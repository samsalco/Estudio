using AppsWeb.Business.DatabaseManager;
using AppsWeb.Common.Models.Tickets;

using AppsWebAPI.Context;
using AppsWebAPI.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System.Threading.Tasks;

namespace AppsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ApiControllerBase
    {
        /// <summary>
        /// Vista modelo
        /// </summary>
        readonly TicketsVM ticketsVM;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionContext">Contexto de conexión</param>
        public TicketsController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            ticketsVM = new TicketsVM(ConnectionContext.Provider, ConnectionContext.ConnectionString);
        }

        /// <summary>
        /// Consulta de todos los tickets
        /// </summary>
        /// <returns>Lista de todos los tickets</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await ticketsVM.Get(null));
        }
        /// <summary>
        /// Consulta un ticket por identificador
        /// </summary>
        /// <param name="Id">Identificador</param>
        /// <returns>Ticket</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            return Ok(ticketsVM.Get(Id));
        }
        /// <summary>
        /// Grabación de un ticket
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registros guardados</returns>
        [HttpPost]
        public IActionResult Post([FromBody]Ticket request)
        {
            return Ok(ticketsVM.Post(request));
        }

        /// <summary>
        /// Actualizamos el ticket
        /// </summary>
        /// <param name="request">Ticket</param>
        /// <returns>Registro actualizado</returns>
        [HttpPut]
        public IActionResult Put([FromBody]Ticket request)
        {
            return Ok(ticketsVM.Put(request));
        }
    }
}