using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    internal class ProductService
    {
        // Start createProduct
        public void createProduct(List<Product> listProduct)
        {
            string? code = string.Empty;
            do
            {
                Console.Write("Please enter your Product Code: ");
                code = Console.ReadLine();
                if (code.Length < 2)
                {
                    Console.WriteLine("The Product Code length must be 2 or greater");
                }
                else if (code.Equals("exit"))
                {
                    return;
                }
            } while (!(code.Length >= 2));

            foreach(var lp in listProduct)
            {
                if(lp.Code == code)
                {
                    Console.WriteLine("This Product Code already exist, please input others");
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    return;
                }
            }

            string? name = string.Empty;
            do
            {
                Console.Write("Please enter your Product Name: ");
                name = Console.ReadLine();
                if (name.Length < 2)
                {
                    Console.WriteLine("The Product Name length must be 2 or greater");
                }
            } while (!(name.Length >= 2));

            string? stock = string.Empty;
            int stockValue;
            do
            {
                Console.Write("Please enter your Product Stock: ");
                stock = Console.ReadLine();
                bool isNumber = int.TryParse(stock, out stockValue);
                if (!isNumber) Console.WriteLine("Please input a valid stock number");
                else if (stockValue < 0) Console.WriteLine("The Product Stock cannot be less than 0");
            } while (!(stockValue >= 0));

            string? price = null;
            double priceValue;
            do
            {
                Console.Write("Please enter your Product Price: ");
                price = Console.ReadLine();
                if (price == null)
                {
                    Console.WriteLine("Price fill Product Price");
                    return;
                }
                bool isNumber = double.TryParse(price, out priceValue);
                if (!isNumber) Console.WriteLine("Please input a valid price number");
                else if (priceValue < 100) Console.WriteLine("The Product Price cannot be less than 100");
            } while (!(priceValue >= 100));

            listProduct.Add(new Product
            {
                Code = code,
                Name = name,
                Stock = stockValue,
                Price = priceValue

            });

            Console.WriteLine("Product Inserted, Enter to Continue....");
            Console.ReadLine();

        }
        // End Create Product
        
        // Start addDummy 
        public List<Product> dummyData(List<Product>listProduct)
        {
            listProduct.Add(new Product
            {
                Code = "PS5",
                Name = "PlayStation 5",
                Stock = 15,
                Price = 15000
            });
            listProduct.Add(new Product
            {
                Code = "NS",
                Name = "Nitendo Switch Lite",
                Stock = 20,
                Price = 1000
            });
            return listProduct;
        }
        // End addDummy

        // Start getProduct
        public List<Product> getProduct(List<Product> listProduct)
        {
            var allProducts = from lp in listProduct
                              select lp;
            return allProducts.ToList();
        }
        // End getProduct

        // Start updateProduct
        public void updateProduct(List<Product> listProduct)
        {
            string? updateInput;
            bool isTrue = true;
            do
            {
                Console.WriteLine("Please enter your Product Code (type exit to return): ");
                updateInput = Console.ReadLine();
                if (updateInput.Equals("exit"))
                {
                    return;
                } 
                else
                {
                    foreach (var lp in listProduct)
                    {
                        if (lp.Code.Equals(updateInput))
                        {
                            string? name = string.Empty;
                            do
                            {
                                Console.Write("Please enter your Product Name: ");
                                name = Console.ReadLine();
                                if (name.Length < 2)
                                {
                                    Console.WriteLine("The Product Name length must be 2 or greater");
                                }
                            } while (!(name.Length >= 2));

                            string? stock = string.Empty;
                            int stockValue = -1 ;
                            do
                            {
                                Console.Write("Please enter your Product Stock: ");
                                stock = Console.ReadLine();
                                bool isNumber = int.TryParse(stock, out stockValue);
                                if (!isNumber) Console.WriteLine("Please input a valid stock number");
                                else if (stockValue < 0) Console.WriteLine("The Product Stock cannot be less than 0");
                            } while (!(stockValue >= 0));

                            string? price = null;
                            double priceValue;
                            do
                            {
                                Console.Write("Please enter your Product Price: ");
                                price = Console.ReadLine();
                                if (price == null)
                                {
                                    Console.WriteLine("Price fill Product Price");
                                    return;
                                }
                                bool isNumber = double.TryParse(price, out priceValue);
                                if (!isNumber) Console.WriteLine("Please input a valid price number");
                                else if (priceValue < 100) Console.WriteLine("The Product Price cannot be less than 100");
                            } while (!(priceValue >= 100));

                            lp.Name = name;
                            lp.Stock = stockValue;
                            lp.Price = priceValue;
                            isTrue = false;
                            break;
                        }
                        else
                        {
                            isTrue = true;
                        }
                    }
                    if(isTrue == true)
                    {
                        Console.WriteLine("The Product Code was not found. Please re-enter your Product Code.");
                    }

                }
            } while(isTrue);
        }
        // End updateProduct

        // Start deleteProduct
        public void deleteProduct(List<Product> listProduct)
        {
            string? deleteInput;
            bool isTrue = true;
            do
            {
                int index = 0;
                Console.WriteLine("Please enter your Product Code (type exit to return)");
                deleteInput = Console.ReadLine();
                if (deleteInput.Equals("exit"))
                {
                    return;
                }
                else
                {
                    foreach (var lp in listProduct)
                    {
                        if (lp.Code.Equals(deleteInput))
                        {
                            
                            listProduct.RemoveAt(index);
                            isTrue = false;
                            return;
                        }
                        else
                        {
                            index++;
                            isTrue = true;
                        }
                    }
                    if (isTrue == true)
                    {
                        Console.WriteLine("The Product Code was not found. Please re-enter your Product Code.");
                    }
                }
            } while (true);
            // End deleteProduct
        }


    }
}
