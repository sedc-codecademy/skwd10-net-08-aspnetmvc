using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Id of order")]
        public int Id { get; set; }

        [Display(Name = "Order created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }
    }
}
