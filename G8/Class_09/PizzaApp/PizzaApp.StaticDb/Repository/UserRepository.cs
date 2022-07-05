using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb.Repository
{
    public class UserRepository
        : IRepository<User>
    {
        public User? GetById(int id)
        {
            return PizzaAppDb.Users.FirstOrDefault(x => x.Id == id);
        }
        public User Create(User entity)
        {
            var lastId = PizzaAppDb.Users.LastOrDefault()?.Id ?? 0;
            entity.Id = ++lastId;
            PizzaAppDb.Users.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if(user != null)
            {
                PizzaAppDb.Users.Remove(user);
            }
        }

        public void DeleteAll()
        {
            PizzaAppDb.Users.Clear();
        }

        public IQueryable<User> GetAll()
        {
            return PizzaAppDb.Users.AsQueryable();
        }

        public void Update(User entity)
        {
            var user = GetById(entity.Id);
            if(user != null)
            {
                user = entity;
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
