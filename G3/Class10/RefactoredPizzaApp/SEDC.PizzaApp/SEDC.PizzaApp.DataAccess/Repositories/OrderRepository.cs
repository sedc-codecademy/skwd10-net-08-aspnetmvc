using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IRepository<Order>
    {
        private readonly PizzaAppDbContext _context;
        public OrderRepository(PizzaAppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza).ToList();
        }
        public Order GetById(int id)
        {
            return _context.Orders
                   .Include(x => x.PizzaOrders)
                   .ThenInclude(x => x.Pizza)
                   .Include(x => x.User)
                   .FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Order entity)
        {
            //entity.Id = ++_context.OrderId;
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Order orderDb = _context.Orders.SingleOrDefault(x => x.Id == id);
            _context.Orders.Remove(orderDb);
            _context.SaveChanges();
        }
    }
}
