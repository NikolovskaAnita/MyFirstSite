using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Models;

namespace MyFirstSite.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult CreateOrderItem(int id)
        {
            ViewBag.MenuItems = BookDb.MenuItems.Select(x => new SelectListItem(x.ToString(), x.Id.ToString()));

            var orderItem = new OrderItemModel()
            {
                OrderId = id
            };

            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Save(OrderItemModel model)
        {
            var order = BookDb.Orders.FirstOrDefault(x => x.Id == model.OrderId);
            if (order == null)
            {
                throw new Exception("Order does not exist");
            }

            var menuItem = BookDb.MenuItems.FirstOrDefault(x => x.Id == model.MenuItem.Id);
            if (menuItem == null)
            {
                throw new Exception("Menu item does not exist");
            }

            if (model.Quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0");
            }

            var orderItem = new OrderItem(IdHelper.GetRandomId(), menuItem, model.Quantity);
            order.OrderItems.Add(orderItem);

            return RedirectToAction("Details", "Order",new {id = model.OrderId});
        }

        public IActionResult Delete(int id)
        {
            var existingOrder = BookDb.Orders.FirstOrDefault(x => x.OrderItems.Any(y => y.Id == id));
            if (existingOrder == null) 
            {
                throw new Exception($"Order that contains order item with Id {id} does not exist");
            }

            var existingOrderItem = existingOrder.OrderItems.First(x => x.Id == id);

            existingOrder.OrderItems.Remove(existingOrderItem);

            return RedirectToAction("Details", "Order", new { id = existingOrder.Id });
        }
    }
}
