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

        private readonly PizzaAppDbContext _context;

        public PizzaRepository(PizzaAppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Pizza pizza = _context.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new Exception($"Pizza with id {id} was not found");
            }
            _context.Pizzas.Remove(pizza);
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _context.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public List<Pizza> GetOnPromotion()
        {
            return _context.Pizzas.Where(x => x.IsOnPromotion).ToList();
        }

        public void Insert(Pizza entity)
        {
            //entity.Id = ++_context.PizzaId;
            _context.Pizzas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            _context.Pizzas.Update(entity);
            _context.SaveChanges();
        }

    }
}
