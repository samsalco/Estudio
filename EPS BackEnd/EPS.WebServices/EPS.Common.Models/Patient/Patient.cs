using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Common.Models
{
    /// <summary>
    /// PAciente
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Historia
        /// </summary>
        public int History { get; set; }
        /// <summary>
        /// Identificacion
        /// </summary>
        public string Identification { get; set; }
        /// <summary>
        /// Tipo de identificacion
        /// </summary>
        public string IdentificationType { get; set; }
        /// <summary>
        /// Primer Nombre
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Segundo Nombre
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Primer Apellido
        /// </summary>
        public string FirstLastName { get; set; }
        /// <summary>
        /// Segundo Apellido
        /// </summary>
        public string SecondLastName { get; set; }
        /// <summary>
        /// Genero
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
