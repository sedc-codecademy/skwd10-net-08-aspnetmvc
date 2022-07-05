namespace PizzAppOnion.Domain.Entities
{
    public class Order : BaseEntity
    {
        public List<Pizza> Pizzas { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Pizzas.Sum(x => x.Price);
        }

        public Order()
        {
            Pizzas = new List<Pizza>();
        }
    }
}
