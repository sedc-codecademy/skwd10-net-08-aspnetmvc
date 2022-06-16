namespace PizzaApp1.Models.Domain
{
    public class Pizza
    {
        private const int MaxmimuDistanceFromStore = 100;

        public Pizza(int id, string name, decimal price, IEnumerable<Topping> toppings, PizzaSize size, User user)
        {
            if(name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Id = id;
            Name = name;
            Price = price;
            Toppings = toppings;
            Size = size;
            User = user;
            IsDelivered = false;
            CanBeDelivered = user.GetLocation() < MaxmimuDistanceFromStore;
        }

        public Pizza(int id, string name, decimal price,  PizzaSize size, User user)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            User = user;
            IsDelivered = false;
            CanBeDelivered = user.GetLocation() < MaxmimuDistanceFromStore;
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool? IsDelivered { get; private set; }

        public bool CanBeDelivered { get; set; }

        public IEnumerable<Topping> Toppings { get; set; } = new List<Topping>();

        public PizzaSize Size { get; set; }

        public User User { get; set; }

        public void Deliver()
        {
            if (!CanBeDelivered)
            {
                throw new Exception();
            }

            IsDelivered = true;
        }
    }
}
