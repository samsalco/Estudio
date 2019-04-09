using EPS.Common.Models;
using EPS.Common.Writes;
using System;
using System.Threading.Tasks;

namespace EPS.Repositories.DatabaseManager
{
    public class LaboratoryPostRepository : RepositoryBase<RequestResponse<int>, LaboratoryRequest>
    {
        public LaboratoryPostRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar un protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override RequestResponse<int> Post(LaboratoryRequest request)
        {
            var response = LaboratoryWrites.AddLaboratory(request.Laboratory, Provider.ToString(), ConnectionString);
            return (response.Successful) ?
                OrderWrites.SaveOrderByPatient(response.Result, request.History, "LABO", DateTime.Now, "A", request.UserCode, Provider.ToString(), ConnectionString) : response;
        }
        /// <summary>
        /// Adicionar un protocolo asincronico
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override Task<RequestResponse<int>> PostAsync(LaboratoryRequest request)
        {
            var response = LaboratoryWrites.AddLaboratory(request.Laboratory, Provider.ToString(), ConnectionString);

            return Task.FromResult((response.Successful) ? OrderWrites.SaveOrderByPatient(response.Result, request.History, "LABO", DateTime.Now, "A", request.UserCode, Provider.ToString(), ConnectionString) : response);
        }
    }
}
