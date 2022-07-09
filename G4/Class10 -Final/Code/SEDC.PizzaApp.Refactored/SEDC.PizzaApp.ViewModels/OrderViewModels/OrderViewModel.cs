using SEDC.PizzaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Is order delivered")]
        public bool Delivered { get; set; }
        [Display(Name = "Pizza Store")]
        public string PizzaStore { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
    }
}
