namespace PizzaWebApp.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {

        }

        public Order(int id, string address, string phoneNumber, string note, decimal totalPrice, List<OrderItem> orderItems)
        {
            Id = id;
            Address = address;
            PhoneNumber = phoneNumber;
            Note = note;
            TotalPrice = totalPrice;
            OrderItems = orderItems;
        }
    }
}
