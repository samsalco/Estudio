using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;

namespace EPS.Managers
{
    public class PatientManager
    {
        #region Members
        /// <summary>
        /// Factoria de usuario
        /// </summary>
        readonly RepositoryFactory<RequestResponse<Patient>, string> repositoryImplementator;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor que inicializa la factoría
        /// </summary>
        public PatientManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            repositoryImplementator = new RepositoryFactory<RequestResponse<Patient>, string>(RepositoryType.DatabaseManager);
            repositoryImplementator.GetRepository("Patient", provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener paciente
        /// </summary>
        /// <returns>usuario</returns>
        public RequestResponse<Patient> GetPatient(string  history)
        {
            return repositoryImplementator.Get(history);
        }

        #endregion
    }
}
