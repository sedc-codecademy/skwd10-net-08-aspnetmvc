namespace Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
