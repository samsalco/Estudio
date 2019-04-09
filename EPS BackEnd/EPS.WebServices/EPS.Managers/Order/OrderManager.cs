using EPS.Common.Models;
using EPS.Repositories;
using EPS.Repositories.DatabaseManager;
using System;
using System.Collections.Generic;

namespace EPS.Managers.Order
{
    public class OrderManager
    {
        /// <summary>
        /// Factoria de get protocolo/ ordenes del paciente
        /// </summary>
        readonly RepositoryFactory<RequestResponse<List<IActivity>>, Tuple<int, string>> repositoryImplementatorGetOrder;

        public OrderManager(RepositoryDatabaseProvider provider, string connectionString)
        {
            repositoryImplementatorGetOrder = new RepositoryFactory<RequestResponse<List<IActivity>>, Tuple<int, string>>(RepositoryType.DatabaseManager);
            repositoryImplementatorGetOrder.GetRepository("OrderGet", provider, connectionString);
        }
        #region Methods
        /// <summary>
        /// Obtener protocolo
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        public RequestResponse<List<IActivity>> GetOrders(int history, string tipo)
        {
            return repositoryImplementatorGetOrder.Get(new Tuple<int, string>(history, tipo));
        }
        #endregion
    }
}
