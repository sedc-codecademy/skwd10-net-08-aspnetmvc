using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Domain.Models;

namespace PizzaApp.EntityFreamwork.Configuration
{
    public class PizzaEntityTypeConfiguration
        : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            //builder.Property(x => x.Price).HasPrecision(18, 2);
        }
    }
}
