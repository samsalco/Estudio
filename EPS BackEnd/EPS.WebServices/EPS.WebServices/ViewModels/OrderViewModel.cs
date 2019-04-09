using EPS.Common.Models;
using EPS.Managers.Order;
using EPS.Repositories.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPS.WebServices
{
    public class OrderViewModel
    {
        #region Members
        /// <summary>
        /// Manejador de protocolo
        /// </summary>
        readonly OrderManager manager;
        #endregion
        #region Constructor de clase
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="connectionString">CAdena de conexion</param>
        /// <param name="provider">Proveedor de BD</param>
        public OrderViewModel(RepositoryDatabaseProvider provider, string connectionString)
        {
            manager = new OrderManager(provider, connectionString);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener ordenes del  paciente
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        public RequestResponse<List<IActivity>> GetOrders(int history, string tipo)
        {
            return manager.GetOrders(history, tipo);
        }
        #endregion
    }
}
