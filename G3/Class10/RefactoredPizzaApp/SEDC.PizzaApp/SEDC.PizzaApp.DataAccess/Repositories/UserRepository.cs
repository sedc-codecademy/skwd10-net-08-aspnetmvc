using SEDC.PizzaApp.DataAccess.Data;
using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly PizzaAppDbContext _context;
        public UserRepository(PizzaAppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            User userDb = _context.Users.SingleOrDefault(x => x.Id == id);
            _context.Users.Remove(userDb);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
