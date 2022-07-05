namespace PizzAppOnion.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }

        public List<Order> Orders { get; set; }

        public Pizza()
        {
            Orders = new List<Order>();
        }
    }
}
