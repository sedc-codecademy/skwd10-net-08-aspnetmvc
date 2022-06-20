using Microsoft.AspNetCore.Mvc;

namespace ModelsDemoWebApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Book = Storage.LibraryDb.Books.First();
            return View();
        }

        public IActionResult ViewDataAction()
        {
            ViewData.Add("Book", Storage.LibraryDb.Books[2]);
            return View();
        }

        public IActionResult GetBookByName(string id = "")
        {
            var book = Storage.LibraryDb.Books.FirstOrDefault(x => x.Name.ToLower().StartsWith(id.ToLower()));

            if(book == null)
            {
                return RedirectToAction("Details", "Library");
            }

            return View(book);
        }
    }
}
