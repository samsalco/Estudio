namespace AppsWeb.Common.Models.Tickets
{
    /// <summary>
    /// Ticket 
    /// </summary>
    public class Ticket
    {       
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Código del cliente -- Ejemplo (FCARDB)
        /// </summary>
        public string CodeClient { get; set; }
        /// <summary>
        /// Número del control relacionado
        /// </summary>
        public int Control { get; set; }
        /// <summary>
        /// Número del requerimiento en el Team System
        /// </summary>
        public int Requeriment { get; set; }
        /// <summary>
        /// Descripción del error o problema
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Solución aplicada por el desarrollador
        /// </summary>
        public string Solution { get; set; }
        /// <summary>
        /// Analisis de impacto
        /// </summary>
        public string Impact { get; set; }
        /// <summary>
        /// Observaciones
        /// </summary>
        public string Observations { get; set; }
        /// <summary>
        /// Estado (E:Entregado, P:Pendiente, S:Solucionado)
        /// </summary>
        public string State { get; set; }        
    }
}
