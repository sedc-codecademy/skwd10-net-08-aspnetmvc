using System.ComponentModel;

namespace LibraryDemoWebApp.Models
{
    public class BookCreateViewModel
    {
        [DisplayName("Име")]
        public string Name { get; set; }
        public Guid ISBN { get; set; }
        public int Pages { get; set; }
        public List<Guid> Authors { get; set; }
        public BookType BookType { get; set; }

        public BookCreateViewModel()
        {

        }
    }
}
