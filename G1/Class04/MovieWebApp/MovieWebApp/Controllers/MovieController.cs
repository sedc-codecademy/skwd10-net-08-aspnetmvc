using Microsoft.AspNetCore.Mvc;
using MovieWebApp.Storage;

namespace MovieWebApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View(StaticDb.Movies);
        }
    }
}
