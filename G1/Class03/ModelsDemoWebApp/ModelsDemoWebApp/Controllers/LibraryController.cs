using Microsoft.AspNetCore.Mvc;
using ModelsDemoWebApp.Storage;

namespace ModelsDemoWebApp.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Details()
        {
            return View(LibraryDb.Library);
        }
    }
}
