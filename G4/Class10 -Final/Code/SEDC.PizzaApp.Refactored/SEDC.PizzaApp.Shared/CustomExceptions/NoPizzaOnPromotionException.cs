using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Shared.CustomExceptions
{
    public class NoPizzaOnPromotionException : Exception
    {
        public NoPizzaOnPromotionException(string message) : base(message)
        {

        }
    }
}
