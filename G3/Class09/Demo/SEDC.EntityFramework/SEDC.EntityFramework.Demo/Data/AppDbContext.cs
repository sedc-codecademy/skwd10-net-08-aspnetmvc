using Microsoft.EntityFrameworkCore;

namespace SEDC.EntityFramework.Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);



            builder.Entity<Employee>(emp =>
            {
                //emp.Property<int>("Id");
                emp.Property("FirstName")
                .IsRequired(true)
                .HasMaxLength(50);
                emp.Property("LastName")
                .IsRequired(true)
                .HasMaxLength(50);
            });


            builder.Entity<Employee>()
                .HasData(
                  new Employee { Id = 1, FirstName = "Martin", LastName = "Panovski", YearsOfExperiance = 5, CompanyId = 1 },
                  new Employee { Id = 2, FirstName = "Jovana", LastName = "Miskimovska", YearsOfExperiance = 3, CompanyId = 1 },
                  new Employee { Id = 3, FirstName = "Stefan", LastName = "Ivanovski", YearsOfExperiance = 8, CompanyId = 2 },
                  new Employee { Id = 4, FirstName = "Dejan", LastName = "Jovanov", YearsOfExperiance = 4, CompanyId = 2 }
                );


            builder.Entity<Company>()
                .HasData(
                   new Company { Id = 1, Name = "Seavus", City = "Skopje", Address = "Test address 1"},                 
                   new Company { Id = 2, Name = "Seavus", City = "Bitola", Address = "Test address 2"}                 
                );
        }
    }
}
