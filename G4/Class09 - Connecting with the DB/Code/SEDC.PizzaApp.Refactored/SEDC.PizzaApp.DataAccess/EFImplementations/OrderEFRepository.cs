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
            throw new NotImplementedException();
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

            var ordersDb = _pizzaAppDbContext.Orders
                .Include(x => x.PizzaOrders) //inner join Orders with PizzaOrder
                .Include(x => x.User) //inner join Orders with Users
                .ToList(); 

            return ordersDb;

            //TODO - add join with Pizza table
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
