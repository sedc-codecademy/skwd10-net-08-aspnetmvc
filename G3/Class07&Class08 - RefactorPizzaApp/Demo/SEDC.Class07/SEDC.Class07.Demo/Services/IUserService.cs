using SEDC.Class07.Demo.Models;

namespace SEDC.Class07.Demo.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById();
    }
}
