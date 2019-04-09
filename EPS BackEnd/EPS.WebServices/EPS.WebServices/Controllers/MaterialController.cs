using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPS.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel material
        /// </summary>
        readonly MaterialViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public MaterialController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new MaterialViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion
        /// <summary>
        /// Adicionar Laboratorio
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] MaterialRequest request)
        {
            return Ok(viewmodel.PostMaterial(request));
        }
    }
}
