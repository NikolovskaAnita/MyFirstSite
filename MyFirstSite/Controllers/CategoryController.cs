using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.DomainModels;
using MyFirstSite.Helpers.Enums;
using MyFirstSite.Helpers.LocalDB;
using MyFirstSite.Mappers;

namespace MyFirstSite.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var category = BookDb.Categories.Select(x => x.ToViewModel()).ToList();
            return View(category);
        }

        
    }
}
