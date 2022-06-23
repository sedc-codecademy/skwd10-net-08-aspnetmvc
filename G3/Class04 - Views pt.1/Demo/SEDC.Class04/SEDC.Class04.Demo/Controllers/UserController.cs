using Microsoft.AspNetCore.Mvc;
using SEDC.Class04.Demo.Models;

namespace SEDC.Class04.Demo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            //User user = new User
            //{
            //    Id = 1,
            //    FirstName = "Martin",
            //    LastName = "Panovski",
            //    Age = 28,
            //    City = "Skopje",
            //    IsEmployeed = true
            //};

            var users = StaticDb.Users;

            UserViewModel model = new UserViewModel
            {
                OrderCount = 10,
                Users = users
            };

            return View(model);
        }
    }
}
