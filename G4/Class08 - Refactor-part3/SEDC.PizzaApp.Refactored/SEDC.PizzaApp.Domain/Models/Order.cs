using SEDC.PizzaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool Delivered { get; set; }
        public string PizzaStore { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        //foreign key
        public int UserId { get; set; }
        public User User { get; set; }

        //PizzaOrder is on the M side in the relation
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
