using DataAccess.Abstraction;
using DataAccess.Storage;
using DomainModels;

namespace DataAccess.Repositories
{
    public class SizeRepository : IRepository<Size>
    {
        public List<Size> GetAll()
        {
            return PizzaDb.Sizes;
        }

        public Size GetById(int id)
        {
            return PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Size entity)
        {
            PizzaDb.Sizes.Add(entity);
        }

        public void Update(Size entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                int index = PizzaDb.Sizes.IndexOf(item);
                PizzaDb.Sizes[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                PizzaDb.Sizes.Remove(item);
            }
        }
    }
}
