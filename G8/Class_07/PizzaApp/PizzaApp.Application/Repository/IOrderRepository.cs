using PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Application.Repository
{
    public interface IOrderRepository
        : IRepository<Order>
    {
        public IQueryable<Order> GetAllDileveredPizza();
    }
}
