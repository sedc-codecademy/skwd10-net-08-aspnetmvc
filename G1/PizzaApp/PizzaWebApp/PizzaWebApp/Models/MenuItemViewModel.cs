namespace PizzaWebApp.Models
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public PizzaViewModel Pizza { get; set; }
        public SizeViewModel Size { get; set; }
        public decimal Price { get; set; }
    }
}
