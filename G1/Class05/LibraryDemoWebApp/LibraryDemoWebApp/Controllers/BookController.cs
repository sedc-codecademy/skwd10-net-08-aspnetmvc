using LibraryDemoWebApp.Models;
using LibraryDemoWebApp.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryDemoWebApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(Guid id)
        {
            var book = LibraryDb.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            return View(book);
        }

        public IActionResult Create()
        {
            List<SelectListItem> authors =
                LibraryDb.Authors.Select(x =>
                new SelectListItem($"{x.FirstName} {x.LastName}", x.Id.ToString())).ToList();

            ViewBag.Authors = authors;

            ViewBag.BookTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string> ((int) BookType.EBook, "EBook"),
                new KeyValuePair<int, string> ((int) BookType.HardCopy, "Hard Copy"),
            };

            return View(new BookCreateViewModel());
        }

        [HttpPost]
        public IActionResult Save(BookCreateViewModel model)
        {
            //Save
            //Validations
            if (LibraryDb.Books.Any(x => x.ISBN == model.ISBN))
            {
                throw new Exception("Book with that ISBN already exists");
            }

            var authors = LibraryDb.Authors.Where(x => model.Authors.Contains(x.Id)).ToList();

            var newBook = new Book(model.Name, model.ISBN, model.Pages, authors)
            {
                BookType = model.BookType
            };

            LibraryDb.Books.Add(newBook);

            return RedirectToAction("Index", "Home");
        }
    }
}
