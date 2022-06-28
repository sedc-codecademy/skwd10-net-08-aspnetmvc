namespace PizzaApp.Domain.Models
{
    public class User
        : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int LocationFromStore { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public int GetLocation()
        {
            return LocationFromStore;
        }
    }
}