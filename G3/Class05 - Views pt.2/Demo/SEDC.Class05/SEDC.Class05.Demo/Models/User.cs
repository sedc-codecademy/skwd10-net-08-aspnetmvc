using System.ComponentModel.DataAnnotations;

namespace SEDC.Class05.Demo.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please enter first name!")]
        [MinLength(8, ErrorMessage = "Please enter more than 8 characters")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "City of residence")]
        public string City { get; set; }


        //public bool IsEmployeed { get; set; }

    }
}
