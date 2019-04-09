using System.Collections.Generic;

namespace EPS.Common.Models
{
    /// <summary>
    /// Protocolo
    /// </summary>
    public class Protocol: IProtocol
    {
        /// <summary>
        /// Secuencia
        /// </summary>
        public int Sequence { get; set; }
        /// <summary>
        /// Listado de ordenes
        /// </summary>
        public List<IOrder> Orders { get; set; }
        /// <summary>
        /// Cambiar estado
        /// </summary>
        /// <param name="newState"></param>
        /// <returns></returns>
        public object ChangeState(string newState)
        {
            return null;
        }
    }
}
