using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Common.Models
{
    public class MedicineRequest
    {
        public string UserCode { get; set; }
        /// <summary>
        /// Historia
        /// </summary>
        public int History { get; set; }
        /// <summary>
        /// Medicamento
        /// </summary>
        public Medicine Medicine { get; set; }
    }
}
