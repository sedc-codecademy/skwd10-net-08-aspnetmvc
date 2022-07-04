using ViewModels = PizzaApp.Application.ViewModel.Users;
namespace PizzaApp.Application.Services
{
    public interface IUserService
    {
        public ViewModels.Model GetUser(int id);

        public ViewModels.Model CreateUser(ViewModels.Create create);

        public ViewModels.Model EditUser(int id, ViewModels.Edit edit);

        public IList<ViewModels.Index> GetUsers();

        public void DeleteUser(int userId);
    }
}
