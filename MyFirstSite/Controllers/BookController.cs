
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;
using MyFirstSite.Models;
using System.Net;
using System.Xml.Linq;

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

        /*[HttpPost]
        public IActionResult SortCategory(string selectOption)
        {
            var book = BookDb.Books.Select(x => x.ToViewModel());
            //var book = BookDb.Books.Select(x => x.Category.Name.ToLower() == selectOption.ToLower());
            //var book = BookDb.Books.FirstOrDefault(x => x.Category.Name == selectOption);

            if (selectOption == null) 
            {
                throw new Exception("No category selected");
            }

            while (selectOption != null)
            { 
                book = book.Where(a => a.Category.Name.ToLower().Equals(selectOption.ToLower()));
                break;
            }

            return View(book.ToList());
        }*/

        public IActionResult Sort(int? id)
        {
            var categoryItem = new BookCategorySortModel();

            if (id.HasValue)
            {
                var item = BookDb.Categories.FirstOrDefault(x => x.Id == id);

                if (id == null)
                {
                    throw new Exception($"Menu item with Id {id} does not exist");
                }

                categoryItem = new BookCategorySortModel
                {
                    Id = item.Id,
                    
                };
            }

            ViewBag.Categories = BookDb.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            return View(categoryItem);
        }

        [HttpPost]
        public IActionResult SortCategory(BookCategorySortModel model)
        {
            var matchingCategory = BookDb.Categories.FirstOrDefault(x => x.Id == model.Id);
            if(matchingCategory == null)
            {
                throw new Exception("Category not selected");
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateEditBook(int? id)
        {
            var model = new BookModel();

            if (id.HasValue)
            {
                var domainModel = BookDb.Books.FirstOrDefault(x => x.Id == id.Value);

                if(domainModel == null) 
                {
                    throw new Exception("Book with that ID does not exist.");
                }
                model = domainModel.ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(BookModel book)
        {
            if(string.IsNullOrEmpty(book.Title) 
                || string.IsNullOrEmpty(book.Author)
                || string.IsNullOrEmpty(book.Description))
            {
                throw new Exception("Please fill out all the properties");
            }

            if(BookDb.Books.Any(x => x.Title.ToLower() == book.Title.ToLower() && x.Id != book.Id))
            {
                throw new Exception($"Book with the name {book.Title} already exists");
            }

            if(book.Id == 0)
            {
                var model = new Book(IdHelper.GetRandomId(), book.Title, book.Author, book.Description);
                BookDb.Books.Add(model);
                return RedirectToAction("Index");
            }

            var existingBook = BookDb.Books.FirstOrDefault(x => x.Id == book.Id);
            if(existingBook == null) 
            {
                throw new Exception($"Book with {book.Id} does not exist");
            }

            BookDb.Books.Remove(existingBook);
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            BookDb.Books.Add(existingBook);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existingBook = BookDb.Books.FirstOrDefault(x => x.Id == id);
            if(existingBook == null)
            {
                throw new Exception($"Book with Id {id} does not exist");
            }

            BookDb.Books.Remove(existingBook);

            return RedirectToAction("Index");
        }
    }
}

