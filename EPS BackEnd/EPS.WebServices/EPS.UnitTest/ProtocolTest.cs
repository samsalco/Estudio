using EPS.Common.Models;
using EPS.WebServices.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace EPS.UnitTest
{
    public class ProtocolTest
    {
        [Fact]
        public void PostProtocol()
        {
            ProtocolController protocolController = new ProtocolController(new UserDBParameter());

            Medicine medicine = new Medicine() { Code = "01", Comments="Observaciones medicamento", Dose = 10, Duration = "1D", Frecuency= "CH", Name = "Acetaminofen", Posology = "posologia del medicamento", Type = "MEDI", Unity = "TB" };
            Laboratory laboratory = new Laboratory() { Code = "02", Comments = "observaciones laboratorio", Name = "Muestra de sangre", Type = "LABO", Frecuency = "8H", Quantity = 2};
            Material material = new Material() { Code = "03", Comments = "observaciones material", Name = "Agujas", Presentation= "UN", Quantity = 10, Type = "MATE" };

            //jSONS
            string medicineJson = JsonConvert.SerializeObject(medicine);
            string laboratoryJson = JsonConvert.SerializeObject(laboratory);
            string materialJson = JsonConvert.SerializeObject(material);

            ProtocolRequest request = new ProtocolRequest()
            {
                Protocols = new List<ProtocolItem>()
                {
                    { new ProtocolItem(){  ActivityType = "MEDI", ActivityJson = medicineJson} },
                    { new ProtocolItem(){  ActivityType = "LABO", ActivityJson = laboratoryJson} },
                    { new ProtocolItem(){  ActivityType = "MATE", ActivityJson = materialJson} }
                }, History = 1001, UserCode = "admon"
            };

            var result = protocolController.Post(request);
        }
    }
}
