namespace Models.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Pizzas.Sum(x => x.Price);
        }
    }
}
