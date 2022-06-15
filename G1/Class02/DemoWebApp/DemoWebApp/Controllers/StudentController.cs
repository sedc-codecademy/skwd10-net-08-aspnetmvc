using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    [Route("stud")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Darko",
                    LastName = "Angelovski"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Vedra",
                    LastName = "Stojanovska"
                }
            };

        [Route("pocetna")]
        [Route("prva")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("detali")]
        public IActionResult Details()
        {
            return View();
        }

        [Route("pravila")]
        public IActionResult Rules()
        {
            //return new RedirectResult("https://www.sedc.mk/");
            return RedirectToAction("Privacy", "Home");
        }

        [Route("povekje-pravila")]
        public IActionResult ViewRules()
        {
            return View("Details");
        }

        [Route("site")]
        public IActionResult GetAll()
        {
            return new JsonResult(students);
        }

        [Route("poId/{id?}")]
        public IActionResult GetById(int id)
        {
            return new JsonResult(students.FirstOrDefault(x => x.Id == id));
        }

        // If more than one param needs to be send, the default route pattern needs to be extended: "{controller=Home}/{action=Index}/{id?}/{name?}"
        //public IActionResult GetByIdAndName(int id, string name)
        //{
        //    return new JsonResult(students.FirstOrDefault(x => x.Id == id && x.FirstName == name));
        //}
    }
}
