using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Threading;

namespace movieOrdering
{
    class Admin : User
    {
        public Admin()
        {
            userName = "admin";
            Password = "admin";
        }
        public static void AddMovie()
        {
            Console.Write("Add Movie name :");
            string name = Console.ReadLine().ToLower();
            foreach (Movie i in Movie.readMovies())
            {
                while (i.name == name)
                {
                    Console.Write("This Film is already here, please type a another one: ");
                    name = Console.ReadLine().ToLower();
                }
            }
            Console.Write("Add Movie Catagory :");
            string catagory = Console.ReadLine().ToLower();
            Console.Write("Add Movie Year :");
            string year = Console.ReadLine();
            Console.Write("Add Movie Rating :");
            string rating = Console.ReadLine();
            Console.Write("Add Movie Price :");
            string price = Console.ReadLine();
            string userRating = "0";

            using (var writer = File.AppendText("Movies.txt"))
            {
                writer.WriteLine(name + ',' + catagory + ',' + year + ',' + rating + ',' + price + ',' + userRating);
                writer.Close();
            }

            Thread.Sleep(560);

            Console.Clear();
            Console.WriteLine("Successfully Added");
            Console.WriteLine("Do you want to add another movie?(yes/no)");
            string value = Console.ReadLine();
            if (value == "yes")
            {
                Console.Clear();
                Movie m = new Movie();
                AddMovie();
            }
            else
            {
                Console.ReadKey();
            }
        }
        public static void deleteMovie(string movie)
        {
            //string movie = "Enola Holmes";
            List<Movie> allMovies = Movie.readMovies();
            for (int i = 0; i < allMovies.Count; i++)
            {
                if (movie == allMovies[i].name)
                {
                    allMovies.RemoveAt(i);
                }
            }
            Console.WriteLine("Successfully deleted.");
            File.WriteAllText("Movies.txt", String.Empty);
            StreamWriter sw = new StreamWriter("Movies.txt");

            for (int i = 0; i < allMovies.Count; i++)
            {
                sw.WriteLine(allMovies[i].name + ',' + allMovies[i].category + ',' + allMovies[i].year + ',' + allMovies[i].rating + ',' + allMovies[i].price + ',' + allMovies[i].userRating);
            }
            sw.Close();

        }
    }
}
