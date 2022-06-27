using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Helpers
{
    public static class UserMapper
    {
        public static UserSelectViewModel MapToUserSelectViewModel(this User user)
        {
            return new UserSelectViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
