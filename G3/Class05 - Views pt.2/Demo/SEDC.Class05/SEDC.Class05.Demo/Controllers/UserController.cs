using Microsoft.AspNetCore.Mvc;
using SEDC.Class05.Demo.Models;

namespace SEDC.Class05.Demo.Controllers
{
    public class UserController : Controller
    {
        [Route("user")]
        public IActionResult Index(int userId)
        {
            var user = StaticDb.Users.SingleOrDefault(x => x.Id == 1);
            User u = new User();
            return View(user);
        }

        [HttpGet("all")]
        public IActionResult Users()
        {
            var users = StaticDb.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = StaticDb.Users.Count() + 1;
                StaticDb.Users.Add(user);
                return RedirectToAction("Users");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = StaticDb.Users.SingleOrDefault(x => x.Id == id);
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = StaticDb.Users.SingleOrDefault(x => x.Id == user.Id);
                    userFromDb.FirstName = user.FirstName;
                    userFromDb.LastName = user.LastName;
                    userFromDb.City = user.City;
                    userFromDb.Age = user.Age;
                    return RedirectToAction("Users");
            }
            return View();
        }
    }
}
