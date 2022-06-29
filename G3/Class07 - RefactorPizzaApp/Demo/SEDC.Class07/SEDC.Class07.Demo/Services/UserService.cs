using SEDC.Class07.Demo.Models;

namespace SEDC.Class07.Demo.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public User GetUserById()
        {
            return new User();
        }
    }

    public class UserNewService : IUserService
    {
        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public User GetUserById()
        {
            return new User();
        }
    }
}
