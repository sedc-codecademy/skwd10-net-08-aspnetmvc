namespace PizzAppOnion.Contracts.ViewModels.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }
    }
}
