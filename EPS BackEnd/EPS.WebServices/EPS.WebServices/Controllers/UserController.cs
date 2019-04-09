using EPS.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EPS.WebServices.Controllers
{
    /// <summary>
    /// Controladora para manejo de Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        #region Members
        /// <summary>
        /// ViewModel usuario
        /// </summary>
        readonly UserViewModel viewmodel;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de API
        /// </summary>
        /// <param name="connectionContext">Contexto de conexion</param>
        public UserController(IOptions<ConnectionContext> connectionContext) : base(connectionContext)
        {
            viewmodel = new UserViewModel(ConnectionContext.GetProvider(), ConnectionContext.GetConnectionString());
        }
        #endregion
        #region Methods APIS
        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <returns>List<Usser></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(viewmodel.GetUsers());
        }
        /// <summary>
        /// Obtener un usuario mediante usuario y clave
        /// </summary>
        /// <param name="id">usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        [HttpGet("{id}/{password}")]
        public IActionResult Get(string id, string password)
        {
            return Ok(viewmodel.GetUser(id, password));
        }
        /// <summary>
        /// Adicionar un usuario
        /// </summary>
        /// <param name="value">Entidad tipo usuario(User)</param>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(viewmodel.PostUser(user));
        }
        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="value">Entidad tipo usuario(User)</param>
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            return Ok(viewmodel.PutUser(user));
        }
        #endregion
    }
}
