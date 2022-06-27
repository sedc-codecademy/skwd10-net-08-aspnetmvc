using LibraryDemoWebApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDemoWebApp.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Details()
        {
            return View(LibraryDb.Library);
        }
    }
}
