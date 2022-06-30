namespace PizzaApp.Domain.Models
{
    public class User
        : IEntity
    {
        public User(string name, string lastName, int locationFromStore, string phone, string email)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (lastName is null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            Name = name;
            LastName = lastName;
            LocationFromStore = locationFromStore;
            Phone = phone;
            Email = email;
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value is null)
                {
                    throw new Exception("Name can not be empty");
                }
                Name = value;
            }
        }

        public string LastName { get; private set; } = string.Empty;

        public void SetLastName(string lastName)
        {
            if (lastName is null)
            {
                throw new Exception("Lastname can not be empty");
            }
            Name = lastName;
        }

        public int LocationFromStore { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public int GetLocation()
        {
            return LocationFromStore;
        }
    }
}