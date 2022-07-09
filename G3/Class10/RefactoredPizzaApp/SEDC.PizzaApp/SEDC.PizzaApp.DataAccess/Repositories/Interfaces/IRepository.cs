using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        // CRUD operations
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
