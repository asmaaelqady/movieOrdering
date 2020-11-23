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
    class User
    {

        protected string userName;
        protected string Password;

        public string getUser()
        {
            return userName;
        }
        public string getPassword()
        {
            return Password;
        }
        public void setUser(string s)
        {
            userName = s;
        }
        public void setPassword(string s)
        {
            Password = s;
        }


        public static void LogIn(char c)
        {
            Customer cust = new Customer();
            Cart cart = new Cart();
            Movie m = new Movie();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (c == 'c' || c == 'C')
            {

                List<Customer> findIn = Customer.readCustomers();
                int counter = 0;

                foreach (Customer i in findIn)
                {
                    if (i.getUser() == id && i.getPassword() == password)
                    {
                        Console.Clear();
                        Console.WriteLine("welcome  " + id);

                        Console.WriteLine("\n");
                    K:
                        Console.WriteLine("1. Display");
                        Console.WriteLine("2. Search For A Specific Movie");
                        Console.WriteLine("--------------------------------");

                        int h = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (h == 1)
                        {
                            Movie.displayMovies();
                            Console.WriteLine("\n");
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
                            Console.WriteLine("Your Cart has: ");
                            foreach (string d in cart.getCart())
                                Console.WriteLine(d);

                            Console.WriteLine("\nPlease Choose: \n1- Proceed.\n2- Delete From Cart.\n3- Clear Cart.");
                            int n = int.Parse(Console.ReadLine());
                            if (n == 2)
                            {
                            deleteMovie:
                                Console.Write("Please enter the movie's name: ");
                                string delete = Console.ReadLine();
                                cart.deleteFromCart(delete);
                                Console.Write("\nSuccessfully deleted, would you like to delete another movie? (y/n) ");
                                char cc = char.Parse(Console.ReadLine());
                                if (cc == 'y')
                                {
                                    goto deleteMovie;
                                }
                            }
                            else if (n == 3)
                            {
                                cart.clearCart();
                                Console.Write("\nSuccessfully cleared, would you like to return to menu? (y/n) ");
                                char cc = char.Parse(Console.ReadLine());
                                if (cc == 'y')
                                {
                                    Console.Clear();
                                    Movie.displayMovies();
                                    goto addAnother;
                                }
                            }

                            Console.WriteLine("\nYour Movies: ");
                            foreach (string d in cart.getCart())
                            {
                                Console.WriteLine(d);
                            }
                            cust.Checkout(cart.getCart());

                        }
                        if (h == 2)
                        {
                            m.search();

                            Console.WriteLine("would you like to go to main menu? (y/n)");
                            char l = char.Parse(Console.ReadLine());
                            if (l == 'y' || l == 'Y')
                            {
                                Console.Clear();
                                goto K;
                            }
                        }


                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (counter == findIn.Count)
                {
                    Console.WriteLine("Invalid");
                    Console.Write("\nwould you like to try again? (y/n)");
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'y' || answer == 'Y')
                    {
                        Thread.Sleep(20);
                        Console.Clear();
                        LogIn(c);
                    }
                }
            }
            else if (c == 'a' || c == 'A')
            {
            begin:
                Admin a = new Admin();
                if (a.getUser() == id && a.getPassword() == password)
                {
                    Thread.Sleep(50);
                    Console.Clear();
                    Console.WriteLine("welcome admin\n");

                    Console.WriteLine("1- Add movie. \n2- Delete Movie");
                    Console.Write("\nPlease Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Thread.Sleep(50);
                        Console.Clear();
                        Admin.AddMovie();
                        Console.Write("\nWould you like to get back to menu? (y/n)");
                        char input = char.Parse(Console.ReadLine());
                        if (input == 'y' || input == 'Y')
                            goto begin;
                        else
                            Console.WriteLine("Thank you :)");
                    }
                    else if (choice == 2)
                    {
                        Thread.Sleep(50);
                        Console.Clear();
                        Console.WriteLine("The full list of movies: \n");
                        Movie.displayMovies();
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.Write("Please Enter the movie's name: ");
                        string movie = Console.ReadLine();
                        Admin.deleteMovie(movie);
                        Console.Write("\nWould you like to get back to menu? (y/n)");
                        char input = char.Parse(Console.ReadLine());
                        if (input == 'y' || input == 'Y')
                            goto begin;
                        else
                            Console.WriteLine("Thank you :)");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input, Please try again.\n");
                        goto begin;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid");
                    Console.Write("would you like to try again? (y/n)");
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'y' || answer == 'Y')
                    {
                        Thread.Sleep(20);
                        Console.Clear();
                        LogIn(c);
                    }
                }
            }
        }
    }
}
