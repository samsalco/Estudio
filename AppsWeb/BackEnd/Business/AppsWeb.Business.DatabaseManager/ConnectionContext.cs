using AppsWeb.Business.DatabaseManager.Enums;

namespace AppsWeb.Business.DatabaseManager
{
    /// <summary>
    /// Contexto de conexión a BD
    /// </summary>
    public class ConnectionContext
    {
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Proveedor
        /// </summary>
        public RepositoryDatabaseProviders Provider { get; set; }
    }
}
