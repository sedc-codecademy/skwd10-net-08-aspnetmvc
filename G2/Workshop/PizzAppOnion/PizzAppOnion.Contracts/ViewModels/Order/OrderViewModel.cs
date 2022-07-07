using System.ComponentModel.DataAnnotations;

namespace PizzAppOnion.Contracts.ViewModels.Order
{
    public class OrderViewModel
    {
        [Display(Name = "Id of order")]
        public int Id { get; set; }

        [Display(Name = "Order created at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Pizza")]
        [MinLength(1)]
        public int[] Pizzas { get; set; }
    }
}
