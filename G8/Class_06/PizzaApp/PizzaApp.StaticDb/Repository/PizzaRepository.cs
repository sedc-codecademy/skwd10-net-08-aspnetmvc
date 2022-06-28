using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.StaticDb.Repository
{
    public class PizzaRepository
        : IRepository<Pizza>
    {
        public Pizza Create(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Pizza> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
