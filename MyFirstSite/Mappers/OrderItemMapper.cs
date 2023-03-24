using MyFirstSite.DomainModels;
using MyFirstSite.Models;

namespace MyFirstSite.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemModel ToViewModel(this OrderItem orderItem)
        {
            return new OrderItemModel 
            {
                Id = orderItem.Id,
                MenuItem = orderItem.MenuItem.ToViewModel(),
                Quantity = orderItem.Quantity
            };
        }
    }
}
