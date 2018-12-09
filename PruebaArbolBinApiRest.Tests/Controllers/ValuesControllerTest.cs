using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaArbolBinApiRest;
using PruebaArbolBinApiRest.Controllers;

namespace PruebaArbolBinApiRest.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Post()
        {
            ArbolBinarioController controller = new ArbolBinarioController();

            // Disponer
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:56474/API/ArbolBinario/Crear")
            };

            // Actuar
            string[] arr1 = new string[] { "70", "76", "80" };
            IHttpActionResult actionResult = controller.Crear(arr1);

            // Declarar
            Assert.IsNotNull(actionResult);
        }

    }
}
