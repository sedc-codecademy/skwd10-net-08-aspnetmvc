using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Repositories.Interfaces
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        List<Pizza> GetOnPromotion();
    }
}
