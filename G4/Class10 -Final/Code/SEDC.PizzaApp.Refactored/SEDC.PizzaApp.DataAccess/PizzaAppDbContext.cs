using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.DataAccess
{
    //Context class has to inherit from DbContext
    public class PizzaAppDbContext : DbContext
    {
        //through the  options param, we get different info for the configuration of the db connection
        //for example, connection string
        public PizzaAppDbContext(DbContextOptions options) : base(options)
        {

        }

        //define main tables
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        //define relations, eventually the initial data in the db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //define relations

            modelBuilder.Entity<Order>() //main table
                .HasMany(x => x.PizzaOrders) // 1-m relation (many side)
                .WithOne(x => x.Order) //1-m relation (one side)
                .HasForeignKey(x => x.OrderId); //foreign key in the relation

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders) //one pizza is related with many records in the PizaaOrder table
                .WithOne(x => x.Pizza) //one PizzaOrder is related to one record in the Pizza table
                .HasForeignKey(x => x.PizzaId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(x => x.User) //one Order is related to one record in the User table
            //    .WithMany(x => x.Orders) //and one User can be related to many records in the Orders table
            //    .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>() //main table
               .HasMany(x => x.Orders) // 1-m relation (many side)
               .WithOne(x => x.User) //1-m relation (one side)
               .HasForeignKey(x => x.UserId); //foreign key in the relation


            //SEEDING
            //send initial data to the db
            modelBuilder.Entity<Pizza>()
               .HasData(new Pizza
               {
                   Id = 1,
                   Name = "Kaprichioza",
                   IsOnPromotion = true
               },
               new Pizza
               {
                   Id = 2,
                   Name = "Pepperoni",
                   IsOnPromotion = false
               },
               new Pizza
               {
                   Id = 3,
                   Name = "Margarita",
                   IsOnPromotion = false
               });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Tanja",
                    LastName = "Stojanovska",
                    Address = "Address1",
                    PhoneNumber ="Tel1"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Stefan",
                    LastName = "Trajkov",
                    Address = "Address2",
                    PhoneNumber = "Tel2"

                });

            modelBuilder.Entity<Order>()// we are sending data just for the columns, the relations are defined above
                .HasData(new Order
                {
                    Id = 1,
                    PaymentMethod = PaymentMethod.Card,
                    Delivered = true,
                    PizzaStore = "Store1",
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    PaymentMethod = PaymentMethod.Cash,
                    Delivered = false,
                    PizzaStore = "Store2",
                    UserId = 2
                });

            modelBuilder.Entity<PizzaOrder>()
                .HasData(new PizzaOrder
                {
                    Id = 1,
                    OrderId = 1,
                    PizzaId = 1,
                    Price = 300,
                    PizzaSize = PizzaSize.Normal,
                    NumberOfPizzas = 2
                },
                    new PizzaOrder
                    {
                        Id = 2,
                        OrderId = 1,
                        PizzaId = 2,
                        Price = 350,
                        PizzaSize = PizzaSize.Normal,
                        NumberOfPizzas = 3
                    },
                    new PizzaOrder
                    {
                        Id = 3,
                        OrderId = 2,
                        PizzaId = 3,
                        Price = 400,
                        PizzaSize = PizzaSize.Family,
                        NumberOfPizzas = 2
                    });

        }
    }
}
