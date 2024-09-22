using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
{
    public class TestController : Controller
    {
        public string actionn()
        {
            return "hello";
        }

        public JsonResult action2()
        {
            JsonResult res = new JsonResult(new {id=1,name="mariam"});
            return res;
        }

        public ViewResult action3()
        {
            ViewResult res = new ViewResult();
            res.ViewName = "Test";
            return res;
        }
    }
}
