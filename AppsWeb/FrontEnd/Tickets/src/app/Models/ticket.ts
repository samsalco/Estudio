/// <summary>
/// Ticket
/// </summary>
export class Ticket {
    /// <summary>
    /// Identificador
    /// </summary>
    public Id: number;
    /// <summary>
    /// Código del cliente -- Ejemplo (FCARDB)
    /// </summary>
    public CodeClient: string;
    /// <summary>
    /// Número del control relacionado
    /// </summary>
    public Control: number;
    /// <summary>
    /// Número del requerimiento en el Team System
    /// </summary>
    public Requeriment: number;
    /// <summary>
    /// Descripción del error o problema
    /// </summary>
    public Description: string;
    /// <summary>
    /// Solución aplicada por el desarrollador
    /// </summary>
    public Solution: string;
    /// <summary>
    /// Analisis de impacto
    /// </summary>
    public Impact: string;
    /// <summary>
    /// Observaciones
    /// </summary>
    public Observations: string;
    /// <summary>
    /// Estado (E:Entregado, P:Pendiente, S:Solucionado)
    /// </summary>
    public State: string;
}
