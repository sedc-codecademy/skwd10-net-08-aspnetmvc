using Microsoft.EntityFrameworkCore;
using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Storage.Database.Context
{
    public class PizzaDbContext : DbContext, IPizzaDbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().Property(x => x.Price).HasColumnType("money");
        }
    }
}
