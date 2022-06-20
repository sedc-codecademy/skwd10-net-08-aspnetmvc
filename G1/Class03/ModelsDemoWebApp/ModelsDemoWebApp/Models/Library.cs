namespace ModelsDemoWebApp.Models
{
    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }

        public Library(string name, List<Book> books, List<Author> authors)
        {
            Name = name;
            Books = books;
            Authors = authors;
        }
    }
}
