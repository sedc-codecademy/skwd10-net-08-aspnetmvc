using PizzaApp1.Models.Enums;

namespace PizzaApp1.Models.ViewModel
{
    public class PizzaPostViewModel
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public PizzaSize Size { get; set; }
    }
}
