using EPS.WebServices.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPS.UnitTest
{
    public class OrderTest
    {
        [Fact]
        public void GetOrder()
        {
            OrderController orderController = new OrderController(new UserDBParameter());

            var resultAll = orderController.Get(1001, string.Empty);
            var resultProtocolos = orderController.Get(1001, "PROT");
            var resultMateriales = orderController.Get(1001, "MATE");
            var resultMedicamentos = orderController.Get(1001, "MEDI");
            var resultLaboratorios = orderController.Get(1001, "LABO");
        }
    }
}
