using SEDC.Class03.Demo.Models.Domain;

namespace SEDC.Class03.Demo
{
    public class StaticDb
    {
        public static List<User> Users = new List<User>
        {
            new User()
            {
                Id = 1,
                FirstName = "Martin",
                LastName = "Panovski",
                Address = "Test address",
                City = "Skopje",
                Phone = "070/233-333"
            },
            new User()
            {
                Id = 2,
                FirstName = "Jovana",
                LastName = "Miskimovska",
                Address = "Test address 1",
                City = "Skopje",
                Phone = "070/233-333"
            },
            new User()
            {
                Id = 3,
                FirstName = "Stefan",
                LastName = "Stefanovski",
                Address = "Test address",
                City = "Skopje",
                Phone = "070/233-333",
            },
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                DateCreated = DateTime.Now,
                User = Users.SingleOrDefault(x => x.Id == 1),
                IsDelievered = true,
                Price = 320
            }
        };
    }
}
