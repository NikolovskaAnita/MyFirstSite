namespace MyFirstSite.Models
{
    public class OrderItemModel
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public MenuItemModel MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
