using PizzaApp.Application.ViewModel;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Services
{
    public interface IOrderService
    {
        Order GetOrder(int id);

        Order CreateOrder(OrderCreateViewModel model, User user);
    }
}
