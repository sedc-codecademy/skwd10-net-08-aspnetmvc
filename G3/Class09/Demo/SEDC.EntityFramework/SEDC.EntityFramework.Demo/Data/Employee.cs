using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.EntityFramework.Demo.Data
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperiance { get; set; }
        //[ForeignKey("FK_Employees_CompanyId")]
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
