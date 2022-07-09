using DataAccess.Abstraction;
using DataAccess.Storage;
using DomainModels;

namespace DataAccess.Repositories
{
    public class MenuItemRepository : IRepository<MenuItem>
    {
        public List<MenuItem> GetAll()
        {
            return PizzaDb.MenuItems;
        }

        public MenuItem GetById(int id)
        {
            return PizzaDb.MenuItems.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(MenuItem entity)
        {
            PizzaDb.MenuItems.Add(entity);
        }

        public void Update(MenuItem entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                int index = PizzaDb.MenuItems.IndexOf(item);
                PizzaDb.MenuItems[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                PizzaDb.MenuItems.Remove(item);
            }
        }
    }
}
