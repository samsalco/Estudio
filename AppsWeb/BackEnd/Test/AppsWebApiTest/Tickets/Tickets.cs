using AppsWebAPI.Controllers;

using AppsWebApiTest.Common;

using Xunit;

namespace AppsWebApiTest
{
    /// <summary>
    /// Prueba con tickets
    /// </summary>
    public class Tickets
    {
        TicketsController controller;
        /// <summary>
        /// Constructor
        /// </summary>
        public Tickets()
        {
            controller = new TicketsController(new DBParametersContext());
        }
        /// <summary>
        /// Prueba para grabar ticket
        /// </summary>
        [Fact]
        public void PostTicket()
        {            
            var result = controller.Post(new AppsWeb.Common.Models.Tickets.Ticket()
            {
                Id = 38835,
                CodeClient= "CALPRO",
                Control= 415551,
                Requeriment= 21820,
                Description = "Al firmar la nota de Ingreso a obstetricia esta saliendo un mensaje de error (chpingobs)",
                Solution = "Se corrige el query que guarda la información del movimiento de atención inicial de urgencias en el servicio.",
                Impact = "Se corrige el query que guarda la información del movimiento de atención inicial de urgencias en el servicio.",
                State = "E"
            });
        }
        /// <summary>
        /// Actualización 
        /// </summary>
        [Fact]
        public void PutTicket()
        {
            var result = controller.Put(new AppsWeb.Common.Models.Tickets.Ticket()
            {
                Id = 38835,
                CodeClient = "CALPRO",
                Control = 415551,
                Requeriment = 21820,
                Description = "Al firmar la nota de Ingreso a obstetricia esta saliendo un mensaje de error (chpingobs)",
                Solution = "Se corrige el query que guarda la información del movimiento de atención inicial de urgencias en el servicio.",
                Impact = "Se corrige el query que guarda la información del movimiento de atención inicial de urgencias en el servicio.",
                State = "E"
            });
        }
    }
}
