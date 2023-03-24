using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;
using MyFirstSite.Models;
using System.Diagnostics;
using System.Net.WebSockets;

namespace MyFirstSite.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            var menu = BookDb.MenuItems.Select(x => x.ToViewModel()).OrderBy(x => x.Book.Title).ThenBy(x => x.Book.Author).ToList();
            return View(menu);
        }

        public IActionResult CreateEditMenuItem(int? id)
        {
            var menuItem = new MenuItemCreateEditModel();

            if(id.HasValue)
            {
                var item = BookDb.MenuItems.FirstOrDefault(x => x.Id == id);

                if (item == null)
                {
                    throw new Exception($"Menu item with Id {item} does not exist");
                }

                menuItem = new MenuItemCreateEditModel
                {
                    Id = item.Id,
                    SelectedBookId = item.Book.Id,
                    Price = item.Price
                };
            }

            ViewBag.Books = BookDb.Books.Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();

            return View(menuItem);
        }

        [HttpPost]
        public IActionResult Save(MenuItemCreateEditModel model)
        {
            if(model.SelectedBookId == 0
                || model.Price == 0)
            {
                throw new Exception("All properties required");
            }

            var selectedBook = BookDb.Books.FirstOrDefault(x => x.Id == model.SelectedBookId);
            if(selectedBook == null)
            {
                throw new Exception("Selected book does not exist");
            }

            if(model.Price <= 0 )
            {
                throw new Exception("Book price should be larger than 0");
            }

            if(BookDb.MenuItems.Any(x => x.Id != model.Id 
                                    && x.Book.Id == model.SelectedBookId))
            {
                throw new Exception($"This menu item already exists");
            }

            if(model.Id == 0)
            {
                var menuItem = new MenuItem(IdHelper.GetRandomId(), selectedBook, model.Price);
                BookDb.MenuItems.Add(menuItem);
                return RedirectToAction("Index");
            }

            var existingMenuItem = BookDb.MenuItems.FirstOrDefault(x => x.Id == model.Id);
            if(existingMenuItem == null)
            {
                throw new Exception("Menu item does not exist");
            }
            BookDb.MenuItems.Remove(existingMenuItem);
            existingMenuItem.Book = selectedBook;
            existingMenuItem.Price = model.Price;
            BookDb.MenuItems.Add(existingMenuItem);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existingMenuItem = BookDb.MenuItems.FirstOrDefault(x => x.Id == id);

            if(existingMenuItem == null)
            {
                throw new Exception($"Menu item with Id {id} does not exist");
            }

            BookDb.MenuItems.Remove(existingMenuItem);

            return RedirectToAction("Index");
        }
    }
}
