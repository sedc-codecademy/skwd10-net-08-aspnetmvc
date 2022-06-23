using MovieWebApp.Entites;
using MovieWebApp.Models;

namespace MovieWebApp.Storage
{
    public class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie(1, "Tetoviranje", Genre.Drama, 120, 2000, 8),
            new Movie(2, "Vikend na mrtovci", Genre.Action, 150, 1989, 10),
            new Movie(3, "Balkankan", Genre.Drama, 90, 2005, 10)
        };
    }
}
