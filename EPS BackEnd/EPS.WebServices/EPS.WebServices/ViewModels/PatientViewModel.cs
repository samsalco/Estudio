using EPS.Common.Models;
using EPS.Managers;
using EPS.Repositories.DatabaseManager;

namespace EPS.WebServices
{
    public class PatientViewModel
    {
        #region Members
        /// <summary>
        /// Manejador 
        /// </summary>
        readonly PatientManager manager;
        #endregion

        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public PatientViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new PatientManager(provider, connectionString);
        }
        /// <summary>
        /// Obtener paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public RequestResponse<Patient> GetPatient(string history)
        {
            return manager.GetPatient(history);
        }
    }
}
