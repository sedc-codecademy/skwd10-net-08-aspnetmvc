using LibraryDemoWebApp.Storage;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDemoWebApp.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View(LibraryDb.Authors);
        }

        public IActionResult Details(Guid id)
        {
            var author = LibraryDb.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Author does not exist");
            }

            return View(author);
        }
    }
}
