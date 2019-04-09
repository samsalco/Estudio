namespace EPS.Common.Models
{
    /// <summary>
    /// Laboratorio
    /// </summary>
    public class Laboratory : IOrder
    {
        public int? Sequence { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Frecuencia
        /// </summary>
        public string Frecuency { get; set; }
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
