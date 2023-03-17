using System.Globalization;

namespace MyFirstSite.DomainModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public decimal Price { get; set; }

        public MenuItem(){}

        public MenuItem(int id, Book book, decimal price)
        {
            Id = id;
            Book = book;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Book.Title} - {Book.Author} [{Price.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR"))}]";
        }
    }
}
