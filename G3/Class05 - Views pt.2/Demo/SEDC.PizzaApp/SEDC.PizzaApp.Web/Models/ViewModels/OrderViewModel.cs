using SEDC.PizzaApp.Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Pizza name")]
        [Required(ErrorMessage = "Please enter pizza name. Ex: Capri, Vege...")]
        public string PizzaName { get; set; }


        [Required(ErrorMessage = "Please select a payment method")]
        public PaymentMethod PaymentMethod { get; set; }


        public int UserId { get; set; }
    }
}
