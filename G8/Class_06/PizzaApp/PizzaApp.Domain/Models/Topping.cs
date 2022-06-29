namespace PizzaApp.Domain.Models
{
    public class Topping
        : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}