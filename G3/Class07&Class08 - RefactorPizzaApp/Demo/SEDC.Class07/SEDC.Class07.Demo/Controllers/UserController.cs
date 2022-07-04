using Microsoft.AspNetCore.Mvc;
using SEDC.Class07.Demo.Services;

namespace SEDC.Class07.Demo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            //_userService = new UserService();
            //_userService = new UserNewService();
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Details(int? id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }
    }
}
