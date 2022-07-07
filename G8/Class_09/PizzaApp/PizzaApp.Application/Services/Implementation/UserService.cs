using PizzaApp.Application.Mapper;
using PizzaApp.Application.Repository;
using PizzaApp.Application.ViewModel.Users;
using DomainEntity = PizzaApp.Domain.Models;
namespace PizzaApp.Application.Services.Implementation
{
    public class UserService
        : IUserService
    {
        private readonly IRepository<DomainEntity.User> userRepository;

        public UserService(IRepository<DomainEntity.User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public Model GetUser(int id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
                throw new Exception("User doesn't exists");

            return user.ToModel();
        }

        public Model CreateUser(Create create)
        {
            var user = create.ToUser();

            var createdUser = userRepository.Create(user);
            userRepository.Commit();

            return createdUser.ToModel();
        }

        public Model EditUser(int id, Edit edit)
        {
            var user = userRepository.GetById(id);

            if(user == null)
            {
                throw new Exception("User doesn't exists");
            }
            var editedUser = user.Edit(edit);

            userRepository.Update(editedUser);
            userRepository.Commit();
            return editedUser.ToModel();
        }

        public IList<ViewModel.Users.Index> GetUsers()
        {
            return userRepository
                .GetAll()
                .Select(x => x.ToIndexModel())
                .ToList();
        }

        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
            userRepository.Commit();
        }
    }
}
