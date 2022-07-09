using SEDC.PizzaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class AddPizzaViewModel
    {
        public int OrderId { get; set; }
        [Display(Name="Pizza")]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza Size")]
        public PizzaSize PizzaSize { get; set; }
        [Display(Name = "Number of pizzas")]
        public int NumberOfPizzas { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
