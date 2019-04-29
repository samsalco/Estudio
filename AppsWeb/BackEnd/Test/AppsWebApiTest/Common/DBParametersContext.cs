using AppsWeb.Business.DatabaseManager;

using Microsoft.Extensions.Options;

namespace AppsWebApiTest.Common
{
    /// <summary>
    /// Contexto de conexión a la base de datos
    /// </summary>
    public class DBParametersContext : IOptions<ConnectionContext>
    {
        public ConnectionContext Value => new ConnectionContext()
        {
            Provider = AppsWeb.Business.DatabaseManager.Enums.RepositoryDatabaseProviders.SqlServer,
            ConnectionString = "Data Source=SERCO-CAROSOMO\\SQLEXPRESS;Initial Catalog=senseiohs;Persist Security Info=True;User ID=senseiohs;Password=micael777"
        };
    }
}
