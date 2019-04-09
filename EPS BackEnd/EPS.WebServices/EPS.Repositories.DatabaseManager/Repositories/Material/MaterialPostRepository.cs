using EPS.Common.Models;
using EPS.Common.Writes;
using System;

namespace EPS.Repositories.DatabaseManager
{
    public class MaterialPostRepository : RepositoryBase<RequestResponse<int>, MaterialRequest>
    {
        public MaterialPostRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar un protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override RequestResponse<int> Post(MaterialRequest request)
        {
            var response = MaterialWrites.AddMaterial(request.Material, Provider.ToString(), ConnectionString);
            return (response.Successful) ?
                OrderWrites.SaveOrderByPatient(response.Result, request.History, "MATE", DateTime.Now, "A", request.UserCode, Provider.ToString(), ConnectionString) : response;
        }
    }
}
