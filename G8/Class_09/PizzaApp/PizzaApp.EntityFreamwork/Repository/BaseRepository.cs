using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;


namespace PizzaApp.EntityFreamwork.Repository
{
    public class BaseRepository<T>
        : IRepository<T> where T : class, IEntity

    {
        private readonly ApplicationDbContext db;

        public BaseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Commit()
        {
            db.SaveChanges();
        }

        public T Create(T entity)
        {
            db.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if(entity is not null)
            {
                db.Remove(entity);
            }
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T? GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }
    }
}
