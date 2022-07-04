namespace PizzaApp.Application.Services.ExternalServices
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string body); 
    }
}
