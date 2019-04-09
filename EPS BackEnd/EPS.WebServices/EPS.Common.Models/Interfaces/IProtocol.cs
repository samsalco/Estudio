using System.Collections.Generic;

namespace EPS.Common.Models
{
    /// <summary>
    /// Interface Protocolo
    /// </summary>
    public interface IProtocol
    {
        /// <summary>
        /// Secuencia
        /// </summary>
        int Sequence { get; set; }
        /// <summary>
        /// Listado de ordenes
        /// </summary>
        List<IOrder> Orders { get; set; }
        /// <summary>
        /// Cambiar estado
        /// </summary>
        /// <param name="newState">Nuevo Estado</param>
        /// <returns></returns>
        object ChangeState(string newState);
    }
}
