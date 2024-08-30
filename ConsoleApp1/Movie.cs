using System;

namespace MovieDatabaseLab
{
    public class Movie
    {
        public string Title;
        public string Category;
        public int ReleaseYear;

        public Movie(string title, string category, int releaseYear)
        {
            Title = title;
            Category = category;
            ReleaseYear = releaseYear;
        }
    }
}
