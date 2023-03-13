using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.Helpers.Enums;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;
using MyFirstSite.Models;

namespace MyFirstSite.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookDb.Books.Select(x => x.ToViewModel()).OrderBy(x => x.Category.Name).ThenBy(x => x.Title).ToList();
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

        [HttpGet]
        public IActionResult CategorySort(string category)
        {
            /*for (int i = 1; i <= 7; i++)
            {
                if(categoryId == i)
                {
                    var book = BookDb.Books.Select(x => x.ToViewModel()).ToList();
                    return View(book);
                }
            }*/
            /*List<SelectListItem> categoryList = new List<SelectListItem>();
            categoryList.Add(new SelectListItem() { Text = "Crime", Value = "crime" });
            categoryList.Add(new SelectListItem() { Text = "Fantasy", Value = "fantasy" });
            categoryList.Add(new SelectListItem() { Text = "Classics", Value = "classics" });
            categoryList.Add(new SelectListItem() { Text = "Horror", Value = "horror" });
            categoryList.Add(new SelectListItem() { Text = "Adventure", Value = "adventure" });
            categoryList.Add(new SelectListItem() { Text = "Bestseller", Value = "bestseller" });
            categoryList.Add(new SelectListItem() { Text = "Other", Value = "other" });*/

            var categorySort = BookDb.Books.Where(x => x.Category.Name == category);


            ViewBag.category = BookDb.Books.Select(x => x.Category).ToList();
            return View(categorySort.ToList());
        }
    }
}
