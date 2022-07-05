using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain.Models;


namespace PizzaApp.EntityFreamwork
{
    public  class ApplicationDbContext
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
