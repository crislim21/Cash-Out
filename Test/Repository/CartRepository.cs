using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repository
{
    internal class CartRepository
    {
        private static List<Cart> listCart = null;
        public static List<Cart> getListCart()
        {
            if (listCart == null)
            {
                listCart = new List<Cart>();
            }
            return listCart;

        }
    }
}
