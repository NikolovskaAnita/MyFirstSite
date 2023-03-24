using Microsoft.AspNetCore.Mvc;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;
using MyFirstSite.Models;

namespace MyFirstSite.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var orders = BookDb.Orders.Select(x => x.ToViewModel()).ToList();
            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            return View(new OrderModel());
        }

        public IActionResult Details(int id)
        {
            var order = BookDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new Exception($"Order with Id {id} not found");
            }

            return View(order.ToViewModel());
        }

        [HttpPost]
        public IActionResult Save(OrderModel model)
        {
            var order = new Order(IdHelper.GetRandomId(), model.Address, model.PhoneNumber, model.Note, new List<OrderItem>());
            BookDb.Orders.Add(order);

            return RedirectToAction("Details", new { id = order.Id});
        }

        public IActionResult Delete(int id) 
        {
            var existingOrder = BookDb.Orders.FirstOrDefault(x => x.Id == id);
            if(existingOrder != null)
            {
                throw new Exception($"Order with Id {id} does not exist");
            }
            BookDb.Orders.Remove(existingOrder);

            return RedirectToAction("Index");
        }
    }
}
