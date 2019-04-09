using EPS.Common.Models;
using EPS.Common.Reads;

namespace EPS.Repositories.DatabaseManager
{
    public class PatientRepository : RepositoryBase<RequestResponse<Patient>, string>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="provider">Provvedor de BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public PatientRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener paciente
        /// </summary>
        /// <param name="request">Parametros de petición</param>
        /// <returns>Response</returns>
        public override RequestResponse<Patient> Get(string history)
        {
            return EPSHandler.GetPatient(history, Provider.ToString(), ConnectionString);
        }
        #endregion
    }
}
