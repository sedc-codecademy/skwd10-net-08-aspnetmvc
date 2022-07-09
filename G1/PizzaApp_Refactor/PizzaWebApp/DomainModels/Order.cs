namespace DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {

        }

        public Order(string address, string phoneNumber, string note, List<OrderItem> orderItems)
        {
            Address = address;
            PhoneNumber = phoneNumber;
            Note = note;
            OrderItems = orderItems;
        }
    }
}
