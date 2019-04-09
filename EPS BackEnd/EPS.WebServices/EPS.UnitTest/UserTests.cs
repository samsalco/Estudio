using EPS.Common.Models;
using EPS.WebServices;
using EPS.WebServices.Controllers;
using Microsoft.Extensions.Options;
using Xunit;

namespace EPS.UnitTest
{
    /// <summary>
    /// Pruebas Unitarias
    /// </summary>
    public class UserTests
    {
        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        [Fact]
        public void GetAllUserTest()
        {
            UserController userController = new UserController(new UserDBParameter());
            var result = userController.Get();
        }

        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        [Fact]
        public void PostUser()
        {
            UserController userController = new UserController(new UserDBParameter());
            var result = userController.Post(new User() {  Code = "vfranco", Name="Victor Franco", Password = "54321"});
        }
    }

    public class UserDBParameter : IOptions<ConnectionContext>
    {
        public ConnectionContext Value => new ConnectionContext()
        {
            ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EPS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
            Provider = "SqlServer"
        };
    }

}
