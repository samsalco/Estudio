namespace EPS.Common.Models
{
    public class Material : IOrder
    {
        /// <summary>
        /// Secuencia
        /// </summary>
        public int? Sequence { get; set; }
        /// <summary>
        ///¨Presentacion
        /// </summary>
        public string Presentation { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public int Quantity { get; set; }
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
