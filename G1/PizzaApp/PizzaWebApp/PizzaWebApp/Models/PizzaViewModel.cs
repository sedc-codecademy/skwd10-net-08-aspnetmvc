using System.ComponentModel;

namespace PizzaWebApp.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
    }
}
