using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace MovieDatabaseLab
{
    internal class Program
    {
        static List<Movie> moviesList = new List<Movie>();
        static void Main(string[] args)
        {
            bool isActiveLoop = true;
            LoadListData();

            Console.WriteLine("Welcome to the Movie List Application!");
            Console.WriteLine($"There are {moviesList.Count} movies in this list.");
            do
            {
                int userInput = GetNumber();
                SelectCategory(userInput);

                if (userInput > 0 && userInput <= 5)
                {
                    isActiveLoop = GetUserChoice();
                    Console.Clear();
                }
            }while (isActiveLoop);
        }

        static void PrintMovies(string category)
        {
            foreach (Movie movie in moviesList)
            {
                if (movie.Category == category)
                {
                    Console.WriteLine(movie.Title + ", " + movie.ReleaseYear + ".");
                }
            }
        }
        static void SelectCategory(int userInput)
        {
            switch (userInput)
            {
                case 1://Action
                    {
                        Console.Clear();
                        Console.WriteLine("----- Action Movies-----");
                        PrintMovies("Action");
                        break;
                    }
                case 2://Comedy
                    {
                        Console.Clear();
                        Console.WriteLine("-----Comedy Movies-----");
                        PrintMovies("Comedy");
                        break;
                    }
                case 3://Drama
                    {
                        Console.Clear();
                        Console.WriteLine("-----Drama Movies-----");
                        PrintMovies("Drama");
                        break;
                    }
                case 4://Fantasy
                    {
                        Console.Clear();
                        Console.WriteLine("-----Fantasy Movies-----");
                        PrintMovies("Fantasy");
                        break;
                    }
                case 5://Science Fiction
                    {
                        Console.Clear();
                        Console.WriteLine("-----Science Fiction Movies-----");
                        PrintMovies("Science Fiction");
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry but that is not a valid category... Please enter (1-5) to select a category from below.");
                        break;
                    }
            }
        }
        static void PrintSortedList()
        {
            Console.WriteLine("\n-----Categories-----");
            List<string> movieCategories = new List<string>();
            foreach (Movie movie in moviesList)
            {
                if (!movieCategories.Contains(movie.Category))
                {
                    movieCategories.Add(movie.Category);
                }
            }

            movieCategories.Sort((cat1, cat2) => cat1.CompareTo(cat2));

            int counter = 1;
            foreach (string category in movieCategories)
            {
                Console.WriteLine($"{counter}. {category}");
                counter++;
            }
        }
        static int GetNumber()
        {
            bool isParsable = false;
            int result = -1;
            do
            {
                PrintSortedList();
                Console.Write("\nWhich category are you interested in? ");
                isParsable = int.TryParse(Console.ReadLine(), out result);
            } while (!isParsable);

            return result;
        }
        static void LoadListData()
        {
            moviesList.Add(new Movie("A River Runs Through It", "Drama", 1992));
            moviesList.Add(new Movie("Star Wars: Rogue One","Science Fiction", 2016));
            moviesList.Add(new Movie("Old Henry","Action", 2021));
            moviesList.Add(new Movie("Tombstone", "Action", 1993));
            moviesList.Add(new Movie("Shrek","Fantasy", 2001));
            moviesList.Add(new Movie("Lord of the Rings", "Fantasy", 2001));
            moviesList.Add(new Movie("GodZilla", "Science Fiction", 2019));
            moviesList.Add(new Movie("Avatar", "Fantasy", 2009));
            moviesList.Add(new Movie("Dirty Grandpa", "Comedy", 2016));
            moviesList.Add(new Movie("Miracle", "Drama",2004));
        }
        static bool GetUserChoice()
        {
            string userInput = "";
            bool isActiveLoop = false;

            do
            {
                Console.WriteLine("\nContinue? (Y/N)");
                userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    isActiveLoop = true;
                }
                if (userInput == "N")
                {
                    isActiveLoop = false;
                }

            } while (userInput != "Y" && userInput != "N");

            return isActiveLoop;
        }

    }
}
