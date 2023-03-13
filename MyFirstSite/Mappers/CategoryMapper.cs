using MyFirstSite.DomainModels;
using MyFirstSite.Models;

namespace MyFirstSite.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryModel ToViewModel(this Category category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
