using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.EntityFramework.Demo.Data
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? Address { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
