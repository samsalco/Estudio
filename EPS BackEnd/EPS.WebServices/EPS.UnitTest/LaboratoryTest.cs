using EPS.Common.Models;
using EPS.WebServices.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace EPS.UnitTest
{
    public class LaboratoryTest
    {
        [Fact]
        public void PostLaboratory()
        {
            LaboratoryController laboratoryController = new LaboratoryController(new UserDBParameter());
            Laboratory laboratory = new Laboratory() { Code = "02", Comments = "observaciones laboratorio N2", Name = "Muestra de hemoglobina", Type = "LABO", Frecuency = "10M", Quantity = 15 };

            //jSONS
            string laboratoryJson = JsonConvert.SerializeObject(laboratory);

            LaboratoryRequest request = new LaboratoryRequest()
            {
                History = 1,
                UserCode = "vfranco",
                Laboratory = laboratory
            };

            var result = laboratoryController.Post(request);
        }
    }
}
