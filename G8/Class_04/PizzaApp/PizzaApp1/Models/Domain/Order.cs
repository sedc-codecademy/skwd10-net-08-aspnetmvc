namespace PizzaApp1.Models.Domain
{
    public class Order
    {
        private const int MaxmimuDistanceFromStore = 100;

        public Order()
        {

        }

        public Order(int id, User user)
        {
            Id = id;
            User = user;
            IsDelivered = false;
            IsPaid = false;
            CanBeDelivered = user.GetLocation() < MaxmimuDistanceFromStore;
        }

        public int Id { get; set; }

        public User User { get; set; }

        public bool? IsDelivered { get; private set; }

        public int Price { get; set; }

        public bool CanBeDelivered { get; private set; }

        public bool IsPaid { get; private set; }

        public IEnumerable<Pizza> Pizzas { get; set; } = new List<Pizza>();


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
