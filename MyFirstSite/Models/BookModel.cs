using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstSite.Helpers.Enums;

namespace MyFirstSite.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public CategoryModel? Category { get; set; }
        //public BookCategoryEnum Category { get; set; }
    }
}
