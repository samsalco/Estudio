using EPS.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel medicamento
        /// </summary>
        readonly MedicineViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public MedicineController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new MedicineViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion
        /// <summary>
        /// Adicionar medicamento
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] MedicineRequest request)
        {
            return Ok(viewmodel.PostMedicine(request));
        }
    }
}
