namespace PizzaWebApp.Helpers
{
    public static class CommonHelper
    {
        public static int GetRandomId()
        {
            var rnd = new Random();
            return rnd.Next(1, int.MaxValue);
        }
    }
}
