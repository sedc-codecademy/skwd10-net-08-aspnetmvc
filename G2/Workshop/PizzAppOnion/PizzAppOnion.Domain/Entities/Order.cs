using System.ComponentModel.DataAnnotations.Schema;

namespace PizzAppOnion.Domain.Entities
{
    public class Order : BaseEntity
    {
        public List<Pizza> Pizzas { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserFk))]
        public User User { get; set; }

        public int UserFk { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Pizzas.Sum(x => x.Price);
        }

        public Order()
        {
            Pizzas = new List<Pizza>();
        }
    }
}
