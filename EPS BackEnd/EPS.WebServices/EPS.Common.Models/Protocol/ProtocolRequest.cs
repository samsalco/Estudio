using System.Collections.Generic;

namespace EPS.Common.Models
{
    /// <summary>
    /// Parametro de insercion protocolo
    /// </summary>
    public class ProtocolRequest
    {
        public string UserCode { get; set; }
        /// <summary>
        /// Historia
        /// </summary>
        public int History { get; set; }
        /// <summary>
        /// Listado de protocolos
        /// </summary>
        public List<ProtocolItem> Protocols { get; set; }
    }
}
