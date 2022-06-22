using PizzaApp1.Models.Enums;

namespace PizzaApp1.Models.Domain
{
    public class Pizza
    {
        public Pizza()
        {

        }
        public Pizza(int id, string name, decimal price, IEnumerable<Topping> toppings, PizzaSize size)
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
        }

        public Pizza(int id, string name, decimal price, PizzaSize size)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Id = id;
            Name = name;
            Price = price;
            Size = size;
        }


        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public IEnumerable<Topping> Toppings { get; set; } = new List<Topping>();

        public PizzaSize Size { get; set; }
    }
}
