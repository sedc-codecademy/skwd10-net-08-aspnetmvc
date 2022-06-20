using Microsoft.AspNetCore.Mvc;
using ModelsDemoWebApp.Storage;

namespace ModelsDemoWebApp.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            //Example sending just one author to the view
            //var author = LibraryDb.Authors.First();
            //return View(author);

            return View(LibraryDb.Authors);
        }
    }
}
