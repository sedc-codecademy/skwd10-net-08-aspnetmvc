using System.Globalization;

namespace PizzaWebApp.DomainModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int id, Pizza pizza, Size size, decimal price)
        {
            Id = id;
            Pizza = pizza;
            Size = size;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Pizza.Name} ({Size.Name}) [{Price.ToString("C", CultureInfo.CreateSpecificCulture("mk-MK"))}]";
        }
    }
}
