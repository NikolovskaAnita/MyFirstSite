using System.ComponentModel;

namespace MyFirstSite.Models
{
    public class BookCategorySortModel
    {
        public int Id { get; set; }

        [DisplayName("Selected Category")]
        public int SelectedCategoryId { get; set; }
    }
}
