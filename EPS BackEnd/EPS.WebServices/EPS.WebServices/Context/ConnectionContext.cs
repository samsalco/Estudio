using EPS.Repositories.DatabaseManager;

namespace EPS.WebServices
{
    /// <summary>
    /// Contextos de conexion
    /// </summary>
    public class ConnectionContext
    {
        /// <summary>
        /// Proveedor
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Obtener cadena de conexion
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return ConnectionString;
        }
        /// <summary>
        /// Obtener Provvedor BD
        /// </summary>
        /// <returns></returns>
        public RepositoryDatabaseProvider GetProvider()
        {
            if (Provider.ToLower().Contains("informix"))
                return RepositoryDatabaseProvider.Informix;
            else if (Provider.ToLower().Contains("oracle"))
                return RepositoryDatabaseProvider.Oracle;
            else if (Provider.ToLower().Contains("sqlserver"))
                return RepositoryDatabaseProvider.SqlServer;
            else return RepositoryDatabaseProvider.NoSql;
        }
    }
}
