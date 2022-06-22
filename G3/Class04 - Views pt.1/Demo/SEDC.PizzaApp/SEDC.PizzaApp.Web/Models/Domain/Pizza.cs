namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
