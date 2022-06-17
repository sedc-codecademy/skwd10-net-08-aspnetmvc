using Microsoft.AspNetCore.Mvc;

namespace SEDC.Class02.Demo.Controllers
{
    [Route("корисници")]
    public class UserController : Controller
    {
        [Route("сите")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("CallMe")]
        public IActionResult Contact()
        {
            return new EmptyResult();
        }
    }
}
