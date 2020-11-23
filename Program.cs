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
    class Program
    {
        static void Main(string[] args)
        {
        start:
            Movie m = new Movie();
            Console.Write("Type s for SignUp or l for LOGIN: ");
            //Console.WriteLine("-----------------------------------------------------------------");
            char i = char.Parse(Console.ReadLine());
            if (i == 's' || i == 'S')
            {
                Thread.Sleep(50);
                Console.Clear();
                Customer.signUp();
            }
            else if (i == 'l' || i == 'L')
            {
                Thread.Sleep(50);
                Console.Clear();
                Console.Write("Type a for Admin and c for Customer: ");
                //Console.WriteLine("-----------------------------------------------------------------"); 
                char input = char.Parse(Console.ReadLine());
                Thread.Sleep(50);
                Console.Clear();
                User.LogIn(input);
            }
            else
            {
                Console.WriteLine("\nInvalid Input, Please Try Again.\n");
                goto start;
            }


        }
    }
}
