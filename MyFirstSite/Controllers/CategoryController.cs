using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers;
using MyFirstSite.Helpers.Enums;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;
using MyFirstSite.Models;

namespace MyFirstSite.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var category = BookDb.Categories.Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return View(category);
        }

        public IActionResult Details(int id)
        {
            var category = BookDb.Categories.FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                throw new Exception($"Category with Id {id} not found");
            }
            return View(category.ToViewModel());
        }

        public IActionResult CreateEditCategory(int? id) 
        {
            var model = new CategoryModel();

            if (id.HasValue)
            {
                var domainModel = BookDb.Categories.FirstOrDefault(x => x.Id == id.Value);

                if (domainModel == null)
                {
                    throw new Exception($"Category with Id {id} does not exist");
                }

                model = domainModel.ToViewModel(); 
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(CategoryModel model) 
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                throw new Exception("All propeties are required");
            }

            if(BookDb.Categories.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception($"Category with the name {model.Name} already exists");
            }

            if(model.Id == 0)
            {
                var category = new Category(IdHelper.GetRandomId(), model.Name);
                BookDb.Categories.Add(category);
                return RedirectToAction("Index");
            }

            var existingCategory = BookDb.Categories.FirstOrDefault(x => x.Id == model.Id);
            if (existingCategory == null)
            {
                throw new Exception($"Category with Id {model.Id} does not exist");
            }
            BookDb.Categories.Remove(existingCategory);
            existingCategory.Name = model.Name;
            BookDb.Categories.Add(existingCategory);

            return RedirectToAction("Index"); 
        }

        public IActionResult Delete(int id)
        {
            var existingCategory = BookDb.Categories.FirstOrDefault( x => x.Id == id);
            if (existingCategory == null) 
            {
                throw new Exception($"Category with Id {id} does not exist");
            }

            var bookCategory = BookDb.Books.Where(x => x.Category.Id == id).ToList();
            foreach(var bookCat in bookCategory)
            {
                BookDb.Books.Remove(bookCat);
            }

            BookDb.Categories.Remove(existingCategory);

            return RedirectToAction("Index");
        }
    }
}
