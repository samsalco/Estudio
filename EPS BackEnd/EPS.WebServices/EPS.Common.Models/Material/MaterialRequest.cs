using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Common.Models
{
    public class MaterialRequest
    {
        public string UserCode { get; set; }
        /// <summary>
        /// Historia
        /// </summary>
        public int History { get; set; }
        /// <summary>
        /// Medicamento
        /// </summary>
        public Material Material { get; set; }
    }
}
