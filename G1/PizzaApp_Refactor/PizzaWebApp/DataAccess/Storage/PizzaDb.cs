using DataAccess.Helpers;
using DomainModels;

namespace DataAccess.Storage
{
    internal static class PizzaDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(CommonHelper.GetRandomId(), "Kapricioza", "Kecap, kaskaval, pecurki, shunka", "https://media-cdn.tripadvisor.com/media/photo-s/0e/25/5c/f9/pizza-capricciosa-pica.jpg"),
            new Pizza(CommonHelper.GetRandomId(), "Peperoni", "Kecap, kaskaval, pecurki, kulen", "https://www.simplehomecookedrecipes.com/wp-content/uploads/2021/02/Pepperoni-Pizza-480x270.png")
        };

        public static List<Size> Sizes = new List<Size>
        {
            new Size(CommonHelper.GetRandomId(), "Mala", "20 cm"),
            new Size(CommonHelper.GetRandomId(), "Sredna", "30 cm"),
            new Size(CommonHelper.GetRandomId(), "Golema", "40 cm"),
            new Size(CommonHelper.GetRandomId(), "Familijarna", "50 cm"),
        };

        public static List<MenuItem> MenuItems = new List<MenuItem>
        {
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[0], 150),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[1], 230),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[2], 300),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[3], 400),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[0], 180),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[1], 250),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[2], 320),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[3], 420)
        };

        public static List<Order> Orders = new List<Order>();
    }
}
