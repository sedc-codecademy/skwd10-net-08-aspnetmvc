using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            //return domain models (all records from the table in DB)
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            //returns one record from a table in DB (by id)
            return StaticDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            StaticDb.UserId++;
            entity.Id = StaticDb.UserId;
            //send the record to the DB
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception($"The user with id {entity.Id} was not found!");
            }
            //update the record in DB
            int index = StaticDb.Users.IndexOf(user);
            StaticDb.Users[index] = entity;
        }

        public void DeleteById(int id)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"The user with id {id} was not found!");
            }
            //delete record from DB
            StaticDb.Users.Remove(user);
        }
    }
}
