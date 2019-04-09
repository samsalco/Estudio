namespace EPS.Common.Models
{
    public class Medicine: IOrder
    {
        public int? Sequence { get; set; }
        /// <summary>
        /// Dosis
        /// </summary>
        public decimal Dose { get; set; }
        /// <summary>
        /// Unidad
        /// </summary>
        public string Unity { get; set; }
        /// <summary>
        /// Frecuencia
        /// </summary>
        public string Frecuency { get; set; }
        /// <summary>
        /// Duracion
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// Posologia
        /// </summary>
        public string Posology { get; set; }
        /// <summary>
        /// Codigo
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Comentarios/observaciones
        /// </summary>
        public string Comments { get; set; }
    }
}
