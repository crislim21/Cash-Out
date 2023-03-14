using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    internal class MenuService
    {
        public void displayMainMenu()
        {
            Console.WriteLine("Welcome to Cash Out.");
            Console.WriteLine("Menus: ");
            Console.WriteLine("1. Product List");
            Console.WriteLine("2. Purchase Out");
            Console.WriteLine("3. View Purchase History");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Your input : ");
        }

        public void displayProductMenu()
        {
            Console.WriteLine("Product List menus: ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Back");
            Console.WriteLine("Please input your choice: ");
        }

        public void displayCartMenu()
        {
            Console.WriteLine("Menus:");
            Console.WriteLine("1. Add product to cart");
            Console.WriteLine("2. Remove product from cart");
            Console.WriteLine("3. Update product quantity in cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Back");
            Console.WriteLine("Plse input your choice: ");
        }

        public void displayProduct(List<Product> listProduct)
        {
            Console.WriteLine("| Product Code | Name | Price | Stock |");
            foreach(var p in listProduct)
            {
                Console.WriteLine($"| {p.Code} | {p.Name} | {p.Price} | {p.Stock} |");
            } 
        }

        public void displayCart(List<Cart> listCart)
        {
            Console.WriteLine("\nUser Cart: ");
            Console.WriteLine("| Product Code | Name | Price | Quantity |");
            foreach (var c in listCart)
            {
                Console.WriteLine($"| {c.Code} | {c.Name} | {c.Price} | {c.Quantity} |");
            }
        }

        public void displayHistory(List<History> listHistory)
        {
            Console.Clear();
            Console.WriteLine("View Purchase History");
            Console.WriteLine("| Product Code | Name | Price | Quantity | Sub Total |");
            double total = 0;
            foreach(var h in listHistory)
            {
                Console.WriteLine($"| {h.Code} | {h.Name} | {h.Price} | {h.Quantity} | {h.Price*h.Quantity} |");
                total += h.Price * h.Quantity;
            }
            Console.WriteLine("Total : " + total);
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Back");
            Console.WriteLine("Please input your choice :");
            string? input = string.Empty;
            int inp;
            do
            {
                input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out inp);
                if (!isNumber && inp != 1) Console.WriteLine("Please input a valid stock number");
                break;
            } while (true);


        }


    }
}
