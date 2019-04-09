using EPS.Common.Models;
using EPS.Common.Writes;
using System;

namespace EPS.Repositories.DatabaseManager
{
    public class MedicinePostRepository : RepositoryBase<RequestResponse<int>, MedicineRequest>
    {
        public MedicinePostRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar un protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override RequestResponse<int> Post(MedicineRequest request)
        {
            var response = MedicineWrites.AddMedicine(request.Medicine, Provider.ToString(), ConnectionString);
            return (response.Successful) ?
                OrderWrites.SaveOrderByPatient(response.Result, request.History, "MEDI", DateTime.Now, "A", request.UserCode, Provider.ToString(), ConnectionString) : response;
        }
    }
}
