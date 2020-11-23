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
    public class Movie
    {
        public string name;
        public string category;
        public int year;
        public float rating;
        public decimal price;
        public float userRating;
        int count = 0;
        Cart cart = new Cart();

        public static List<Movie> readMovies()
        {
            List<Movie> movies = new List<Movie>();
            StreamReader sr = new StreamReader("Movies.txt");
            while (sr.Peek() >= 0)
            {
                string str;
                string[] strArray;
                str = sr.ReadLine();
                strArray = str.Split(',');
                Movie currentMovie = new Movie();
                currentMovie.name = strArray[0];
                currentMovie.category = strArray[1];
                currentMovie.year = int.Parse(strArray[2]);
                currentMovie.rating = float.Parse(strArray[3]);
                currentMovie.price = decimal.Parse(strArray[4]);
                currentMovie.userRating = float.Parse(strArray[5]);
                movies.Add(currentMovie);
            }
            sr.Close();
            return movies;
        }
        public static void displayMovies()
        {
            List<Movie> newList = readMovies();

            foreach (Movie i in newList)
            {
                Console.WriteLine("Name: {0}, Category: {1}, Year: {2}, Rating: {3}, Price: {4}", i.name, i.category, i.year, i.rating, i.price);

            }
        }
        public void myRateSet(float r)
        {
            List<float> CustomerRate = new List<float>();

            CustomerRate.Add(r);
            userRating = CustomerRate.Average();

        }
        public void search()
        {
            string[] strArray = { "0" };
        label:
            Console.Write("Enter name of movie or Category:    ");
            String name = Console.ReadLine().ToLower();
            Console.Clear();

            bool res = false;
            string[] words = File.ReadAllLines("Movies.txt");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(name))
                {

                    strArray = words[i].Split(',');
                    Console.WriteLine("Name : {0}  category : {1}  year : {2} Rate : {3} Price : {4}", strArray[0], strArray[1], strArray[2], strArray[3], strArray[4]);
                    res = true;
                    count++;
                }
            }
            if (res == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not found try again...");
                Console.ResetColor();
                goto label;
            }

            if (count > 1)
            {
                Console.Write("select movie: ");
                string name1 = Console.ReadLine().ToLower();
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(name1))
                    {

                        strArray = words[i].Split(',');


                    }
                }

                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Rate");
                Console.WriteLine("2. Add To Cart");
                Console.WriteLine("--------------------------------");

                int h = int.Parse(Console.ReadLine());
                if (h == 1)
                {
                    if (strArray[0] == name1)
                    {
                        Console.WriteLine("Enter rate: ");
                        float r = float.Parse(Console.ReadLine());
                        myRateSet(r);
                        strArray[5] = getUserRate().ToString();
                        Console.WriteLine("Name : {0}  category : {1}  year : {2} Rate : {3} Price : {4} User Rate : {5}", strArray[0], strArray[1], strArray[2], strArray[3], strArray[4], strArray[5]);

                    }
                }
                else if (h == 2)
                {
                    Customer cust = new Customer();
                    cart.addToCart(strArray[0]);
                    Console.WriteLine("Successfully Added.");
                    cust.Checkout(cart.getCart());
                }
            }
            else if (count == 1)
            {

                Console.WriteLine("1. Rate");
                Console.WriteLine("2. Add To Cart");
                int h = int.Parse(Console.ReadLine());
                if (h == 1)
                {
                    Console.WriteLine("Enter rate: ");
                    float r = float.Parse(Console.ReadLine());
                    myRateSet(r);
                    strArray[5] = getUserRate().ToString();
                    Console.WriteLine("Name : {0}  category : {1}  year : {2} Rate : {3} Price : {4} User Rate : {5}", strArray[0], strArray[1], strArray[2], strArray[3], strArray[4], strArray[5]);
                    Console.Write("\nThank you for rating, would you like to return to main menu? (y/n) ");
                    char cc = char.Parse(Console.ReadLine());
                    if (cc == 'y')
                    {
                        Console.Clear();
                        goto label;
                    }

                }
                else if (h == 2)
                {
                    Customer cust = new Customer();
                    cart.addToCart(strArray[0]);
                    Console.WriteLine("Successfully Added.");
                    cust.Checkout(cart.getCart());
                }

            }

        }
        public float getUserRate()
        {
            return userRating;
        }
        public void outPut(string[] strArray)
        {

            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Rate");
            Console.WriteLine("2. Add To Cart");
            Console.WriteLine("--------------------------------");

            int h = int.Parse(Console.ReadLine());
            if (h == 1)
            {
                Console.WriteLine("Enter rate: ");
                float r = float.Parse(Console.ReadLine());
                myRateSet(r);
                strArray[5] = getUserRate().ToString();
                Console.WriteLine("Name : {0}  category : {1}  year : {2} Rate : {3} Price : {4} User Rate : {5}", strArray[0], strArray[1], strArray[2], strArray[3], strArray[4], strArray[5]);
            }
            else if (h == 2)
            {
                Customer cust = new Customer();
            addAnother:
                Console.WriteLine("\nwhich movie would you like to add to cart? ");
                string name = Console.ReadLine();
                cart.addToCart(name);
                Console.Write("\nSuccessfully added, would you like to add another movie? (y/n) ");
                char choice = char.Parse(Console.ReadLine());
                if (choice == 'y')
                {
                    goto addAnother;
                }
                Thread.Sleep(20);
                Console.Clear();
                Console.WriteLine("\nYour Cart has: ");
                foreach (string d in cart.getCart())
                    Console.WriteLine(d);

                Console.WriteLine("\nPlease Choose: \n1- Proceed.\n2- Delete From Cart.");
                int n = int.Parse(Console.ReadLine());
                if (n == 2)
                {
                deleteMovie:
                    Console.Write("Please enter the movie's name: ");
                    string delete = Console.ReadLine();
                    cart.deleteFromCart(delete);
                    Console.Write("\nSuccessfully added, would you like to add another movie? (y/n) ");
                    char cc = char.Parse(Console.ReadLine());
                    if (choice == 'y')
                    {
                        goto deleteMovie;
                    }
                }
                Console.WriteLine("\nYour Movies: ");
                foreach (string d in cart.getCart())
                {
                    Console.WriteLine(d);
                }
                cust.Checkout(cart.getCart());

            }
        }
    }
}
