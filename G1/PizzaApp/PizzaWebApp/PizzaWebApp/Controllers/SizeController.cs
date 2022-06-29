using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.DomainModels;
using PizzaWebApp.Helpers;
using PizzaWebApp.Mappers;
using PizzaWebApp.Models;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class SizeController : Controller
    {
        public IActionResult Index()
        {
            var sizes = PizzaDb.Sizes.Select(x => x.ToViewModel()).OrderBy(x => x.Description).ToList();
            return View(sizes);
        }

        public IActionResult Details(int id)
        {
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if (size == null)
            {
                throw new Exception($"Size with Id {id} not found");
            }

            return View(size.ToViewModel());
        }

        public IActionResult CreateEditSize(int? id)
        {
            var model = new SizeViewModel();

            if (id.HasValue)
            {
                var domainModel = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id.Value);

                if (domainModel == null)
                {
                    throw new Exception($"Size with id {id} does not exist");
                }

                model = domainModel.ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(SizeViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name)
                || string.IsNullOrEmpty(model.Description))
            {
                throw new Exception($"All properties are required.");
            }

            if (PizzaDb.Sizes.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception($"Size with the name {model.Name} already exists");
            }


            if (model.Id == 0)
            {
                var size = new Size(CommonHelper.GetRandomId(), model.Name, model.Description);

                PizzaDb.Sizes.Add(size);

                return RedirectToAction("Index");
            }

            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == model.Id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {model.Id} does not exist");
            }

            PizzaDb.Sizes.Remove(existingSize);

            existingSize.Name = model.Name;
            existingSize.Description = model.Description;

            PizzaDb.Sizes.Add(existingSize);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {id} does not exist");
            }

            var menuItems = PizzaDb.MenuItems.Where(x => x.Size.Id == id).ToList();

            foreach (var menuItem in menuItems)
            {
                PizzaDb.MenuItems.Remove(menuItem);
            }

            PizzaDb.Sizes.Remove(existingSize);

            return RedirectToAction("Index");
        }
    }
}
