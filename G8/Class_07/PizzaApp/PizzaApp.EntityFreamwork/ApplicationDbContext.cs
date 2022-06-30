using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain.Models;

namespace PizzaApp1.Models.Db
{
    public class ApplicationDbContext
        : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
