using MyFirstSite.DomainModels;
using MyFirstSite.Helpers.Enums;

namespace MyFirstSite.Helpers.LocalDB
{
    public static class BookDb
    {

        public static List<Category> Categories = new List<Category>
        {
            new Category(1, /*BookCategoryEnum.Crime*/"Crime"),
            new Category(2, /*BookCategoryEnum.Fantasy*/"Fantasy"),
            new Category(3, /*BookCategoryEnum.Classics*/"Classics"),
            new Category(4, /*BookCategoryEnum.Horror*/"Horror"),
            new Category(5, /*BookCategoryEnum.Adventure*/"Adventure"),
            new Category(6, /*BookCategoryEnum.Bestseller*/"Bestseller"),
            new Category(7, /*BookCategoryEnum.Other*/"Other"),
        };

        public static List<Book> Books = new List<Book>
        {
            new Book(IdHelper.GetRandomId(), "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "Some description 1", Categories[1]),
            new Book(IdHelper.GetRandomId(), "The Alchemyst", "Paulo Coelho", "Some description 2", Categories[5]),
            new Book(IdHelper.GetRandomId(), "The Count of Monte Cristo", "Alexandre Dumas", "Some description 3", Categories[4]),
            new Book(IdHelper.GetRandomId(), "The Exorcist", "William Peter Blatty", "Some description 4", Categories[3]),
            new Book(IdHelper.GetRandomId(), "Little Women", "Louisa May Alcott", "Some description 5", Categories[2]),
            new Book(IdHelper.GetRandomId(), "Death On The Nile", "Agatha Christie", "Some description 6", Categories[0]),
            new Book(IdHelper.GetRandomId(), "Pride and Prejudice", "Seth Grahame-Smith", "Some description 7", Categories[2]),
            new Book(IdHelper.GetRandomId(), "The Devil Wears Prada", "Lauren Weisberger", "Some description 8", Categories[6]),
            new Book(IdHelper.GetRandomId(), "The Chronicles of Narnia", "C. S. Lewis", "Some description 9", Categories[1]),
            new Book(IdHelper.GetRandomId(), "Diary of a Wimpy Kid", "Jeff Kinney", "Some description 10", Categories[6]),
            new Book(IdHelper.GetRandomId(), "Percy Jackson and the Olympians", "Rick Riordan", "Some description 11", Categories[1])
        };
    }
}
