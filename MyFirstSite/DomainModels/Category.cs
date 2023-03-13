using MyFirstSite.Helpers.Enums;

namespace MyFirstSite.DomainModels
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public BookCategoryEnum Name { get; set; }

        public Category() { }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
