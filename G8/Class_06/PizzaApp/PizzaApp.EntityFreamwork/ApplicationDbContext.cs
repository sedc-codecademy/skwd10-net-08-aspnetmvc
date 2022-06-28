using Microsoft.EntityFrameworkCore;
using PizzaApp1.Models.Domain;

namespace PizzaApp1.Models.Db
{
    public class ApplicationDbContext
        :DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
