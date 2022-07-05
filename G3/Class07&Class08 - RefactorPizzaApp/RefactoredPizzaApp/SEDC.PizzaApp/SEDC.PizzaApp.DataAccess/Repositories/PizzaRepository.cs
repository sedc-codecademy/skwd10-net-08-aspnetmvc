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
    public class PizzaRepository : IPizzaRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetOnPromotion()
        {
            return StaticDb.Pizzas.Where(x => x.IsOnPromotion).ToList();
        }

        public void Insert(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
