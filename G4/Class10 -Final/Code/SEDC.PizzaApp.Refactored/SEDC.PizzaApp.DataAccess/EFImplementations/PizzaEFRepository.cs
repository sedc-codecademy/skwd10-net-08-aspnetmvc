using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public PizzaEFRepository(PizzaAppDbContext pizzaAppDbContext) //DI
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            Pizza pizzaDb = _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizzaDb == null)
            {
                throw new Exception($"The pizza with id {id} was not found!");
            }

            _pizzaAppDbContext.Pizzas.Remove(pizzaDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<Pizza> GetAll()
        {
            return _pizzaAppDbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Add(entity);
            _pizzaAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }

        public Pizza GetPizzaOnPromotion()
        {
            //          SELECT*
            //FROM[PizzaAppDb].[dbo].[Pizzas]
            //where IsOnPromotion = 1
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.IsOnPromotion == true);
        }

    }
}
