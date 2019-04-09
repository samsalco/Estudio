namespace EPS.Common.Models
{
    /// <summary>
    /// Interface de orden
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Código
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// Comentarios/observaciones
        /// </summary>
        string Comments { get; set; }
    }
}
