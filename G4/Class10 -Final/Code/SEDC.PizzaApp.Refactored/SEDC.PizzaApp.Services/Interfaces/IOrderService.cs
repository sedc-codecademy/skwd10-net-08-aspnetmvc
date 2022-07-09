using SEDC.PizzaApp.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderById(int id);
        void CreateOrder(OrderViewModel order);
        void AddPizzaToOrder(AddPizzaViewModel addPizzaViewModel);
        void DeleteOrder(int orderId);
        OrderViewModel GetOrderForEditing(int id);
        void EditOrder(OrderViewModel orderViewModel);
    }
}
