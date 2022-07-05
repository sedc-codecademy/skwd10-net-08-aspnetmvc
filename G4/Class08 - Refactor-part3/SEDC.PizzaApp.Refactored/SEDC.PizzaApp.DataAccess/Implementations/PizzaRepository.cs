using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public List<Pizza> GetAll()
        {
            //return domain models (all records from the table in DB)
            return StaticDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            //returns one record from a table in DB (by id)
            return StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            StaticDb.PizzaId++;
            entity.Id = StaticDb.PizzaId;
            //send the record to the DB
            StaticDb.Pizzas.Add(entity);
            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
            if (pizza == null)
            {
                throw new Exception($"The user with id {entity.Id} was not found!");
            }
            //update the record in DB
            int index = StaticDb.Pizzas.IndexOf(pizza);
            StaticDb.Pizzas[index] = entity;
        }

        public void DeleteById(int id)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new Exception($"The pizza with id {id} was not found!");
            }
            //delete record from DB
            StaticDb.Pizzas.Remove(pizza);
        }
    }
}
