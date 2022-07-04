using Business.Abstraction;
using DataAccess.Helpers;
using DataAccess.Storage;
using DomainModels;
using Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Implementation
{
    public class SizeService : ISizeService
    {
        public List<SizeViewModel> GetAll()
        {
            var sizes = PizzaDb.Sizes.Select(x => x.ToViewModel()).OrderBy(x => x.Description).ToList();
            return sizes;
        }

        public List<SelectListItem> GetSizesSelectList()
        {
            return PizzaDb.Sizes.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public SizeViewModel GetById(int id)
        {
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if (size == null)
            {
                throw new Exception($"Size with Id {id} not found");
            }

            return size.ToViewModel();
        }

        public void Save(SizeViewModel model)
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

                return;
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
        }

        public void Delete(int id)
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
        }
    }
}
