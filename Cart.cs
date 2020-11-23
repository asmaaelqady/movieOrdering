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
    class Cart
    {
        static List<string> movies = new List<string>();
        public void addToCart(string name)
        {
            movies.Add(name);

        }
        public void deleteFromCart(string name)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (name == movies[i])
                    movies.RemoveAt(i);
            }
        }

        public List<string> getCart()
        {
            return movies;
        }
        public void clearCart()
        {
            movies.Clear();
        }
    }
}
