using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Helpers.Enums;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;

namespace MyFirstSite.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookDb.Books.Select(x => x.ToViewModel()).ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = BookDb.Books.FirstOrDefault(x => x.Id == id);

            if(book == null)
            {
                throw new Exception($"Book with ID: {id} not found!");
            }

            return View(book.ToViewModel());
        }
    }
}
