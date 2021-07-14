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
            OkObjectResult someChanges123456 = (OkObjectResult)iaresult.Result;
            OkObjectResult aSecondChangs = (OkObjectResult)iaresult.Result;

            
            



            Assert.AreEqual(expected.Value, result.Value);
            //private const ObjectResult expected = new ObjectResult(Controller.StatusCode(503, "The Application is already terminated"));
        }

        [TestMethod]
        public void HelloStatusCode()
        {
            OkObjectResult expected = new OkObjectResult(200);


            Task<IActionResult> iaresult = appController.helloapp("Max");
            OkObjectResult result = (OkObjectResult)iaresult.Result;



            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void HelloValue()
        {
            OkObjectResult expected = new OkObjectResult(200);
            expected.Value = "Hello Max";

            Task<IActionResult> iaresult = appController.helloapp("Max");
            OkObjectResult result = (OkObjectResult)iaresult.Result;



            Assert.AreEqual(expected.Value, result.Value);
        }

        [TestMethod]
        public void breakValue()
        {
            OkObjectResult expected = new OkObjectResult(200);
            expected.Value = "The Application was paused for 2 seconds";

            Task<IActionResult> iaresult = appController.breakapp(2);
            OkObjectResult result = (OkObjectResult)iaresult.Result;



            Assert.AreEqual(expected.Value, result.Value);
        }

        [TestMethod]
        public void breakStatusCode()
        {
            OkObjectResult expected = new OkObjectResult(200);
            expected.Value = "The Application was paused for 2 seconds";

            Task<IActionResult> iaresult = appController.breakapp(2);
            OkObjectResult result = (OkObjectResult)iaresult.Result;



            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }
    }
}
