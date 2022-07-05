using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
    
        public List<UserViewModel> GetUsersForDropdown()
        {
            List<User> usersDb = _userRepository.GetAll();

            return usersDb.Select(x => x.MapToUserViewModel()).ToList();
        }
    }
}
