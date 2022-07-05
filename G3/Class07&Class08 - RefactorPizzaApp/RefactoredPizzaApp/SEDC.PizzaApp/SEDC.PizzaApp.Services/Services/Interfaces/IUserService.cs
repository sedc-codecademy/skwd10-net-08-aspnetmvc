using SEDC.PizzaApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserViewModel> GetUsersForDropdown();
    }
}
