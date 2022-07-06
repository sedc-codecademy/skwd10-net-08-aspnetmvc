using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Application.Services;
using PizzaApp.Application.ViewModel.Users;

namespace PizzaApp1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = userService.GetUser(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View(new Create());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Create create)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userService.CreateUser(create);
                    return RedirectToAction(nameof(Index));
                }

                return View(create);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userService.GetUser(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Edit edit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userService.EditUser(id, edit);
                    return RedirectToAction(nameof(Index));
                }

                return View(edit);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userService.GetUser(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                userService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
