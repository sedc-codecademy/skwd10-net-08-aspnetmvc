using MovieWebApp.Models;

namespace MovieWebApp.Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int Length { get; set; }
        public int Year { get; set; }
        public int ImdbRating { get; set; }

        public Movie(int id, string name, Genre genre, int length, int year, int imdbRating)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Length = length;
            Year = year;
            ImdbRating = imdbRating;
        }
    }
}
