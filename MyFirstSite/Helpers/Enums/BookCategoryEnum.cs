using System.ComponentModel;

namespace MyFirstSite.Helpers.Enums
{
    public enum BookCategoryEnum
    {
        Crime = 1,
        Fantasy,
        Classics,
        Horror,
        Adventure,
        Bestseller,
        Other
    }

    /*public static string CategoryToList()
    {
        List<BookCategoryEnum> bookCategoryEnum = Enum.GetValues(typeof(BookCategoryEnum))
                            .Cast<BookCategoryEnum>()
                            .ToList();

        return String.Join(Environment.NewLine, bookCategoryEnum);
    }*/
}
