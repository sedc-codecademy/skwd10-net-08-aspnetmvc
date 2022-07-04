namespace PizzaApp.Domain.Models
{
    public class Order
        : IEntity
    {
        private const int MaxmimuDistanceFromStore = 100;

        public Order()
        {

        }

        public Order(User user, IList<Pizza> pizzas)
        {
            User = user;
            IsDelivered = false;
            IsPaid = false;
            CanBeDelivered = user.GetLocation() < MaxmimuDistanceFromStore;
            Pizzas = pizzas;
        }

        public int Id { get; set; }

        public User User { get; set; }

        public bool? IsDelivered { get; private set; }

        public decimal Price => Pizzas.Sum(x => x.Price);

        public bool CanBeDelivered { get; private set; }

        public bool IsPaid { get; private set; }

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public void ClearPizzas()
        {
            Pizzas.Clear();
        }

        public void AddPizza(Pizza? pizza, int numberOfPizzas)
        {
            if (pizza == null)
                throw new Exception("Pizza doesn't exist");

            Enumerable.Range(0, numberOfPizzas).ToList().ForEach(_ =>
            {
                Pizzas.Add(pizza);
            });
        }

        public void Pay()
        {
            if (!CanBeDelivered)
            {
                throw new Exception("Can not be delivered");
            }
            if (IsPaid)
            {
                throw new Exception("You already paid");
            }

            IsPaid = true;
        }

        public void Deliver()
        {
            if (!CanBeDelivered)
            {
                throw new Exception("Can not be delivered");
            }

            if (!IsPaid)
            {
                throw new Exception("You need to pay");
            }

            IsDelivered = true;
        }
    }
}
