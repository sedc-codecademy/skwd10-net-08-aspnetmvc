using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext) //Dependency Injection
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            //SELECT * FROM ORDERS WHERE Id = id
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            ////SELECT * FROM ORDERS
            //var ordersDb =  _pizzaAppDbContext.Orders.ToList();
            //return ordersDb;

            //            select*
            //from Orders as o
            //inner join Users u
            //on u.Id = o.UserId
            //inner join PizzaOrder po
            //on o.Id = po.OrderId
            //            inner join Pizzas p
            //on p.Id = po.PizzaId

            var ordersDb = _pizzaAppDbContext.Orders
                .Include(x => x.PizzaOrders) //inner join Orders with PizzaOrder
                .ThenInclude(x => x.Pizza) //inner join PizzaOrders with Pizza
                .Include(x => x.User) //inner join Orders with Users
                .ToList();

            return ordersDb;

        }

        public Order GetById(int id)
        {
            //            select*
            //from Orders as o
            //inner join Users u
            //on u.Id = o.UserId
            //inner join PizzaOrder po
            //on o.Id = po.OrderId
            //inner join Pizzas p
            //on p.Id = po.PizzaId
            //where o.Id = 2

            var orderDb = _pizzaAppDbContext.Orders
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
            return orderDb;
        }

        public int Insert(Order entity)
        {
           _pizzaAppDbContext.Orders.Add(entity); //no db call
           _pizzaAppDbContext.SaveChanges(); //call to db

            return entity.Id;
        }

        public void Update(Order entity)
        {
            _pizzaAppDbContext.Orders.Update(entity); //no db call
            _pizzaAppDbContext.SaveChanges(); //call to db
        }
    }
}
