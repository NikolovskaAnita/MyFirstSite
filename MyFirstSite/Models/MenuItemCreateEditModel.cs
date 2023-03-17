using System.ComponentModel;

namespace MyFirstSite.Models
{
    public class MenuItemCreateEditModel
    {
        public int Id { get; set; }

        [DisplayName("Selected Book")]
        public int SelectedBookId { get; set; }
        public decimal Price { get; set; }
    }
}
