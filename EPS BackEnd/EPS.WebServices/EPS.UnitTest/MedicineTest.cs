using EPS.Common.Models;
using EPS.WebServices.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace EPS.UnitTest
{
    public class MedicineTest
    {
        [Fact]
        public void PostMedicine()
        {
            MedicineController medicineController = new MedicineController(new UserDBParameter());
            Medicine medicine = new Medicine() { Code = "01", Comments = "Observaciones medicamento N2", Dose = 8, Duration = "5D", Frecuency = "CD", Name = "Noxpirin", Posology = "posologia del medicamento N2", Type = "MEDI", Unity = "GG" };

            //jSONS
            string medicineJson = JsonConvert.SerializeObject(medicine);

            MedicineRequest request = new MedicineRequest()
            {
                History = 3,
                UserCode = "vfranco",
                Medicine = medicine
            };

            var result = medicineController.Post(request);
        }
    }
}
