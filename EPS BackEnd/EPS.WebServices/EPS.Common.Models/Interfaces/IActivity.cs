namespace EPS.Common.Models
{
    /// <summary>
    /// Interface de la actividad
    /// </summary>
    public interface IActivity
    {
        /// <summary>
        /// Tipo
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// Cambiar estado de la orden
        /// </summary>
        /// <param name="newState">Nuevo estado</param>
        /// <returns></returns>
        object ChangeStateOrder(string newState);
        /// <summary>
        /// Guardar la actividad
        /// </summary>
        /// <returns></returns>
        object SaveActivity();
    }
}
