using Microsoft.EntityFrameworkCore;
using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;

namespace PizzaApp.EntityFreamwork.Repository
{
    public class UserEFRepository
        : IRepository<User>
    {
        private readonly ApplicationDbContext dbContext;

        public UserEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public User? GetById(int id)
        {
            return dbContext.Users.Find(id);
        }
        public User Create(User entity)
        {
            dbContext.Users.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user is not null)
            {
                dbContext.Users.Remove(user);
            }
        }

        public IQueryable<User> GetAll()
        {
            return dbContext.Users.AsNoTracking();
        }

        public void Update(User entity)
        {
            dbContext.Update(entity);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
