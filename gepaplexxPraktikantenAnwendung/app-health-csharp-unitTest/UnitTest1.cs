using gepaplexxPraktikantenAnwendung.AppControllerFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace app_health_csharp_unitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        AppController appController = new AppController();
        [TestMethod]
        public void HealthStatusCode()
        {
            OkObjectResult expected = new OkObjectResult(200);

            Task<IActionResult> iaresult = appController.healthapp();
            OkObjectResult result = (OkObjectResult)iaresult.Result;

            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }

        
        [TestMethod]
        public void HealthValue()
        {
            OkObjectResult expected = new OkObjectResult(200);
            expected.Value = "Healthy";

            Task<IActionResult> iaresult = appController.healthapp();
            OkObjectResult result = (OkObjectResult)iaresult.Result;



            Assert.AreEqual(expected.Value, result.Value);
            //private const ObjectResult expected = new ObjectResult(Controller.StatusCode(503, "The Application is already terminated"));
        }

        public void HelloStatusCode()
        {

        }
    }
}
