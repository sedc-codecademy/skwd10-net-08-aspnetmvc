using System.ComponentModel.DataAnnotations;

namespace PizzAppOnion.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(255)]
        public string UserName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
