namespace PizzaWebApp.DomainModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        //public Order Order { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int id, MenuItem menuItem, /*Order order,*/ int quantity)
        {
            Id = id;
            MenuItem = menuItem;
            //Order = order;
            Quantity = quantity;
        }
    }
}
