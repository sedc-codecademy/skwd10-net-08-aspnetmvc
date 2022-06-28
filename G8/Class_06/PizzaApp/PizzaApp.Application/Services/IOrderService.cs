using PizzaApp.Application.ViewModel;
using PizzaApp.Application.ViewModel.Order;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Services
{
    public interface IOrderService
    {
        OrderViewModel GetOrder(int id);

        OrderViewModel CreateOrder(OrderCreateViewModel model, User user);

        void EditOrder(int id, OrderEditViewModel model);
    }
}
