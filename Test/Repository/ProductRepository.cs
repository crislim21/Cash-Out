using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repository
{
    internal class ProductRepository
    {
        private static List<Product> listProduct = null;
        public static List<Product> getListProduct()
        {
            if (listProduct == null)
            {
                listProduct = new List<Product>();
            }
            return listProduct;

        }
    }
}
