using EPS.Common.Models;
using EPS.Common.Reads;
using System;
using System.Collections.Generic;

namespace EPS.Repositories.DatabaseManager
{
    /// <summary>
    /// Repositorio obtener ordenes por paciente
    /// </summary>
    public class OrderGetRepository : RepositoryBase<RequestResponse<List<IActivity>>, Tuple<int, string>>
    {
        public OrderGetRepository(RepositoryDatabaseProvider provider, string connectionString)
        {
            Provider = provider;
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Adicionar un protocolo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override RequestResponse<List<IActivity>> Get(Tuple<int, string> request)
        {
            return OrderHandler.GetOrdersPatient(request.Item1, request.Item2, Provider.ToString(), ConnectionString);            
        }
    }
}
