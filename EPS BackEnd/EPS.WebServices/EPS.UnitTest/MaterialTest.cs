using EPS.Common.Models;
using EPS.WebServices.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace EPS.UnitTest
{
    public class MaterialTest
    {
        [Fact]
        public void PostMaterial()
        {
            MaterialController materialController = new MaterialController(new UserDBParameter());
            Material material = new Material() { Code = "03", Comments = "observaciones material N2", Name = "Frasco", Presentation = "BO", Quantity = 2, Type = "MATE" };

            //jSONS
            string materialJson = JsonConvert.SerializeObject(material);

            MaterialRequest request = new MaterialRequest()
            {
                History = 1,
                UserCode = "vfranco",
                Material = material
            };

            var result = materialController.Post(request);
        }
    }
}
