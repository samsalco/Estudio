using EPS.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel protocolo
        /// </summary>
        readonly LaboratoryViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public LaboratoryController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new LaboratoryViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion
        /// <summary>
        /// Adicionar Laboratorio
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LaboratoryRequest request)
        {
            try
            {
                return Ok(await viewmodel.PostLaboratory(request));
            }
            catch (Exception ex)
            {
                return Ok(new RequestResponse<int>() { Message = $"{ex.Message} {ex.TargetSite} {ex.InnerException}" });
            }
        }
    }
}
