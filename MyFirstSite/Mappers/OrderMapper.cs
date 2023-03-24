using MyFirstSite.DomainModels;
using MyFirstSite.Models;

namespace MyFirstSite.Mappers
{
    public static class OrderMapper
    {
        public static OrderModel ToViewModel(this Order order)
        {
            return new OrderModel
            {
                Id = order.Id,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Note = order.Note,
                OrderItems = order.OrderItems.Select(x => x.ToViewModel()).ToList(),
                TotalPrice = order.TotalPrice
            };
        }
    }
}
