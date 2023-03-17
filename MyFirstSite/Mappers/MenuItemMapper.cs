using MyFirstSite.DomainModels;
using MyFirstSite.Models;

namespace MyFirstSite.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemModel ToViewModel(this MenuItem menuItem) 
        { 
            return new MenuItemModel
            {
                Id = menuItem.Id,
                Book = menuItem.Book.ToViewModel(),
                Price = menuItem.Price
            }; 
        }
    }
}
