namespace PizzaApp1.Models.ViewModel
{
    public class OrderCreateViewModel
    {
        public string TestName { get; set; }

        public IEnumerable<int> Pizzas { get; set; } = new List<int>();
    }
}
