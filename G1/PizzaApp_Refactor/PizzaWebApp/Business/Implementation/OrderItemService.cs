using Business.Abstraction;
using DataAccess.Helpers;
using DataAccess.Storage;
using DomainModels;
using ViewModels;

namespace Business.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        public void Save(OrderItemViewModel model)
        {
            var order = PizzaDb.Orders.FirstOrDefault(x => x.Id == model.OrderId);

            if (order == null)
            {
                throw new Exception($"Order does not exist");
            }

            var menuItem = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == model.MenuItem.Id);

            if (menuItem == null)
            {
                throw new Exception($"Menu item does not exist");
            }

            if (model.Quantity <= 0)
            {
                throw new Exception($"Quantity must be grater than 0");
            }

            var orderItem = new OrderItem(CommonHelper.GetRandomId(), menuItem, model.Quantity);

            order.OrderItems.Add(orderItem);
        }
        public int Delete(int id)
        {
            var existingOrder = PizzaDb.Orders.FirstOrDefault(x => x.OrderItems.Any(y => y.Id == id));

            if (existingOrder == null)
            {
                throw new Exception($"Order that contains order item with {id} does not exist");
            }

            var existingOrderItem = existingOrder.OrderItems.First(x => x.Id == id);

            existingOrder.OrderItems.Remove(existingOrderItem);

            return existingOrder.Id;
        }
    }
}
