using MyFirstSite.Helpers.Enums;
using MyFirstSite.Models;

namespace MyFirstSite.DomainModels
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
         //public BookCategoryEnum Category { get; set; }

        public Book(){}

        public Book(int id, string title, string author, string description)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
        }

        public Book(int id, string title, string author, string description, Category? category)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Category = category;
        }
    }
}
