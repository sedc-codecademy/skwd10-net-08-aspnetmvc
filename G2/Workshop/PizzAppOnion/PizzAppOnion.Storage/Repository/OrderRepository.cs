using Microsoft.EntityFrameworkCore;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;
using PizzAppOnion.Storage.Database.Context;

namespace PizzAppOnion.Storage.Repository.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository 
    {
        public OrderRepository(IPizzaDbContext pizzaDbContext) : base(pizzaDbContext)
        {
        }

        public async Task<IReadOnlyList<Order>> GetAllOrdersAsync()
        {
            IQueryable<Order> orderQuery = GetAll();

            return await orderQuery.ToArrayAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await GetById(id).SingleOrDefaultAsync();
        }

        public void Insert(Order createdOrder)
        {
            InsertEntity(createdOrder);
        }

        public void Update(Order existingOrder)
        {
            //noop
        }

        public void Delete(int id)
        {
            //Order order = GetOrder(id);

            //if (order is null)
            //{
            //    throw new Exception($"Order with id {id} not found");
            //}

            //PizzaDatabase.ORDERS.Remove(order);
        }
    }
}
