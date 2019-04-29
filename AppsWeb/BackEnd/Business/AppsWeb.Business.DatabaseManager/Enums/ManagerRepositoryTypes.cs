namespace AppsWeb.Business.DatabaseManager.Enums
{
    /// <summary>
    /// Tipos de respositorios
    /// </summary>
    public enum ManagerRepositoryTypes
    {        
        GetTickets,      //Consulta un ticket especifico o todos, depende de los parámetros
        PostTicket,     //Guarda ticket
        PutTicket       //Actualiza el ticket
    }
}
