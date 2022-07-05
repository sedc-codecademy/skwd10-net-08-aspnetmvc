using Business.Abstraction;
using DataAccess.Helpers;
using DataAccess.Storage;
using DomainModels;
using Mappers;
using ViewModels;

namespace Business.Implementation
{
    public class OrderService : IOrderService
    {
        public List<OrderViewModel> GetAll()
        {
            return PizzaDb.Orders.Select(x => x.ToViewModel()).ToList();
        }

        public OrderViewModel Details(int id)
        {
            var order = PizzaDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return order.ToViewModel();
        }

        public int Save(OrderViewModel model)
        {
            var order = new Order(CommonHelper.GetRandomId(), model.Address, model.PhoneNumber, model.Note, new List<OrderItem>());

            PizzaDb.Orders.Add(order);

            return order.Id;
        }
        public void Delete(int id)
        {
            var existingOrder = PizzaDb.Orders.FirstOrDefault(x => x.Id == id);

            if (existingOrder == null)
            {
                throw new Exception($"Order with id {id} does not exist");
            }

            PizzaDb.Orders.Remove(existingOrder);
        }
    }
}
