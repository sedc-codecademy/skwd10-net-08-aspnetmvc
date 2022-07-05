using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class NewOrderService : IOrderService
    {
        public void AddPizzaToOrder(AddPizzaViewModel addPizzaViewModel)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(OrderViewModel order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            return null;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
