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
    class Customer : User
    {
        string address;
        string phoneNumber;

        public static List<Customer> readCustomers()
        {
            List<Customer> customers = new List<Customer>();
            StreamReader sr = new StreamReader("Customers.txt");

            while (sr.Peek() >= 0)
            {
                string str;
                string[] strArray;
                str = sr.ReadLine();

                strArray = str.Split(',');
                Customer currentCustomer = new Customer();
                currentCustomer.userName = strArray[0];
                currentCustomer.Password = strArray[1];
                currentCustomer.address = strArray[2];
                currentCustomer.phoneNumber = strArray[3];
                customers.Add(currentCustomer);
            }
            sr.Close();
            return customers;
        }
        public void displayCustomers()
        {
            List<Customer> newList = readCustomers();
            foreach (Customer i in newList)
            {
                Console.WriteLine("ID: {0}, address: {1}, Phone: {2}", i.getUser(), i.address, i.phoneNumber);
            }
        }

        public static void signUp()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            foreach (Customer i in readCustomers())
            {
                while (i.userName == name)
                {
                    Console.Write("This username is taken, please type a different name: ");
                    name = Console.ReadLine();

                }
            }
            Console.Write("Please enter your Password: ");
            string pass = Console.ReadLine();

            Console.Write("Please enter your address: ");
            string address = Console.ReadLine();

            Console.Write("Please enter your phone number: ");
            string phone = Console.ReadLine();


            using (var writer = File.AppendText("Customers.txt"))
            {
                writer.WriteLine(name + ',' + pass + ',' + address + ',' + phone);
                writer.Close();
            }

            Thread.Sleep(50);
            Console.Clear();

            Console.WriteLine("Successfully Added, please log in :)");
            User.LogIn('c');
        }


        public void Checkout(List<string> movieName)
        {
            List<Movie> newList = Movie.readMovies();
            int deliveryCost = 10;
            decimal Totalcost = 0;
            decimal result = 0;



            for (int i = 0; i < newList.Count; i++)
            {
                for (int j = 0; j < movieName.Count; j++)
                {
                    if (movieName[j] == newList[i].name)
                    {
                        result += newList[i].price;
                    }
                }

            }
            Totalcost = result + deliveryCost;

            Console.WriteLine("The Total Cost {0}:", Totalcost + "$");

        }
    }
}
