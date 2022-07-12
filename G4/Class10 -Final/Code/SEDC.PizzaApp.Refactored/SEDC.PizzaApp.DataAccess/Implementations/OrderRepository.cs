using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public OrderRepository()
        {

        }
        public void DeleteById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }

            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            //first do the increment, then assign the value
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if(orderDb == null)
            {
                throw new Exception($"Order with id {entity.Id} was not found!");
            }
            int index = StaticDb.Orders.FindIndex(x => x.Id == entity.Id);
            if(index == -1)
            {
                throw new Exception($"Order with id {entity.Id} was not found!");
            }

            StaticDb.Orders[index] = entity;
        }
    }
}
