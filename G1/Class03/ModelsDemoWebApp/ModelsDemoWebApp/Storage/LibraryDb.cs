using ModelsDemoWebApp.Models;

namespace ModelsDemoWebApp.Storage
{
    public static class LibraryDb
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author("Julie", "James", DateTime.Now.AddYears(-60)),
            new Author("Alexandre", "Dumas", DateTime.Now.AddYears(-50)),
            new Author("Jo", "Nesbo", DateTime.Now.AddYears(-50)),
            new Author("J.K", "Rowling", DateTime.Now.AddYears(-40))
        };

        public static List<Book> Books = new List<Book>
        {
            new Book("Count of Monte Christo", Guid.NewGuid(), 550, new List<Author> { Authors[1] }),
            new Book("Nemesis", Guid.NewGuid(), 420, new List<Author> { Authors[2] }),
            new Book("Suddenly one summer", Guid.NewGuid(), 380, new List<Author> { Authors[0], Authors[2] })
        };

        public static Library Library = new Library("Brakja Miladinovci", Books, Authors);
    }
}
