using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Application.ViewModel.Users
{
    public class Index
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
    }

    public class Create
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int DestinationFromLocation { get; set; }
    }

    public class Model
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int LocationFromStore { get; set; }
    }

    public class Edit
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int LocationFromStore { get; set; }
    }
}
