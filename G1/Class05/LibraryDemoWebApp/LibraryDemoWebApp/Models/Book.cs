using System.ComponentModel;

namespace LibraryDemoWebApp.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [DisplayName("Име")]
        public string Name { get; set; }
        public Guid ISBN { get; set; }
        public int Pages { get; set; }
        public List<Author> Authors { get; set; }
        public BookType BookType { get; set; }

        public Book()
        {

        }
        public Book(string name, Guid iSBN, int pages, List<Author> authors)
        {
            Id = Guid.NewGuid();
            Name = name;
            ISBN = iSBN;
            Pages = pages;
            Authors = authors;
        }
    }
}
