using MyFirstSite.DomainModels;
using MyFirstSite.Models;

namespace MyFirstSite.Mappers
{
    public static class BookMapper
    {
        public static BookModel ToViewModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category.ToViewModel()
            };
        }
    }
}
