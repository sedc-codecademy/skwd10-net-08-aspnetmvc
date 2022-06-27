using SEDC.Class05.Demo.Models;

namespace SEDC.Class05.Demo
{
    public class StaticDb
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Martin",
                LastName = "Panovski",
                Age = 28,
                City = "Skopje",
                //IsEmployeed = true
            },
            new User
            {
                Id = 2,
                FirstName = "Jovana",
                LastName = "Miskimovska",
                Age = 25,
                City = "Skopje",
                //IsEmployeed = true
            },
            new User
            {
                Id = 3,
                FirstName = "Dejan",
                LastName = "Jovanov",
                Age = 29,
                City = "Skopje",
                //IsEmployeed = true
            },
        };
    }
}
