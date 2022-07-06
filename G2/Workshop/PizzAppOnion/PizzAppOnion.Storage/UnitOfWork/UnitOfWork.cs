using PizzAppOnion.Domain.UnitOfWork;
using PizzAppOnion.Storage.Database.Context;

namespace PizzAppOnion.Storage.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPizzaDbContext _dbContext;

        public UnitOfWork(IPizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
