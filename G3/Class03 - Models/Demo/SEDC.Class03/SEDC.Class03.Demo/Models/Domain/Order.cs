namespace SEDC.Class03.Demo.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDelievered { get; set; }
        public double Price { get; set; }
    }
}
