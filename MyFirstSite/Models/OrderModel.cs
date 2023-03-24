namespace MyFirstSite.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }
    }
}
