using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PizzAppOnion.Storage.Database.Context
{
    public interface IPizzaDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        ChangeTracker ChangeTracker { get; }
    }
}
