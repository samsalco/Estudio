using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel usuario
        /// </summary>
        readonly PatientViewModel viewmodel;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public PatientController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new PatientViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion

        /// <summary>
        /// Obtener un paciente por historia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(viewmodel.GetPatient(id));
        }
    }
}
