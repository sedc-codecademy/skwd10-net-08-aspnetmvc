using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDDViewModel> GetAllUsersForDropdown()
        {
            //1. get all users from db
            List<User> usersDb = _userRepository.GetAll();

            //2. map from domain model to view model
            List<UserDDViewModel> userDDViewModels = usersDb.Select(x => UserMapper.ToUserDDViewModel(x)).ToList();
            return userDDViewModels;
        }
    }
}
