using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess
{
    //will have all methods from IRepository<Pizza>, plus the method GetPizzaOnPromotion
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Pizza GetPizzaOnPromotion();
    }
}
