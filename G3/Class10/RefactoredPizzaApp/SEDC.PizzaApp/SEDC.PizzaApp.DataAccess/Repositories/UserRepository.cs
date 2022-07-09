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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
