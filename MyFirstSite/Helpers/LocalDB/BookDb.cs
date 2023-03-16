using MyFirstSite.DomainModels;
using MyFirstSite.Helpers.Enums;

namespace MyFirstSite.Helpers.LocalDB
{
    public static class BookDb
    {

        public static List<Category> Categories = new List<Category>
        {
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Crime*/"Crime"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Fantasy*/"Fantasy"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Classics*/"Classics"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Horror*/"Horror"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Adventure*/"Adventure"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Bestseller*/"Bestseller"),
            new Category(IdHelper.GetRandomId(), /*BookCategoryEnum.Other*/"Other"),
        };

        public static List<Book> Books = new List<Book>
        {
            new Book(IdHelper.GetRandomId(), "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling", "Some description 1", /*BookCategoryEnum.Fantasy*/Categories[1]),
            new Book(IdHelper.GetRandomId(), "The Alchemyst", "Paulo Coelho", "Some description 2", /*BookCategoryEnum.Bestseller*/Categories[5]),
            new Book(IdHelper.GetRandomId(), "The Count of Monte Cristo", "Alexandre Dumas", "Some description 3", /*BookCategoryEnum.Adventure*/Categories[4]),
            new Book(IdHelper.GetRandomId(), "The Exorcist", "William Peter Blatty", "Some description 4", /*BookCategoryEnum.Horror*/Categories[3]),
            new Book(IdHelper.GetRandomId(), "Little Women", "Louisa May Alcott", "Some description 5", /*BookCategoryEnum.Classics*/Categories[2]),
            new Book(IdHelper.GetRandomId(), "Death On The Nile", "Agatha Christie", "Some description 6", /*BookCategoryEnum.Crime*/Categories[0]),
            new Book(IdHelper.GetRandomId(), "Pride and Prejudice", "Seth Grahame-Smith", "Some description 7", /*BookCategoryEnum.Classics*/Categories[2]),
            new Book(IdHelper.GetRandomId(), "The Devil Wears Prada", "Lauren Weisberger", "Some description 8", /*BookCategoryEnum.Other*/Categories[6]),
            new Book(IdHelper.GetRandomId(), "The Chronicles of Narnia", "C. S. Lewis", "Some description 9", /*BookCategoryEnum.Fantasy*/Categories[1]),
            new Book(IdHelper.GetRandomId(), "Diary of a Wimpy Kid", "Jeff Kinney", "Some description 10", /*BookCategoryEnum.Other*/Categories[6]),
            new Book(IdHelper.GetRandomId(), "Percy Jackson and the Olympians", "Rick Riordan", "Some description 11", /*BookCategoryEnum.Fantasy*/Categories[1])
        };
    }
}
