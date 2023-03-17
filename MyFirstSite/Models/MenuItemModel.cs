using System.Globalization;

namespace MyFirstSite.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        public BookModel Book { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Book.Title} - {Book.Author} [{Price.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR"))}]";
        }
    }
}
