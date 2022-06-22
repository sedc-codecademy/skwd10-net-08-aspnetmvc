using SEDC.PizzaApp02.App.Models.Domain;
using SEDC.PizzaApp03.App.Models.Enums;

namespace SEDC.PizzaApp03.App.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
