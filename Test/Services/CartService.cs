using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    internal class CartService
    {
        private MenuService menu = new MenuService();
        // Start adding product to cart
        public void addProductToCart(List<Cart>listCart, List<Product>listProduct)
        {
            string? cartInput;
            bool isTrue = true;
            do
            {
                Console.WriteLine("Please enter your Product Code (type exit to return): ");
                cartInput = Console.ReadLine();
                if(cartInput.Equals("exit"))
                {
                    return;
                }
                else
                {
                    foreach(var lp in listProduct)
                    {
                        if (lp.Code.Equals(cartInput))
                        {
                            string? quantity = String.Empty;
                            int quantityValue = -1;
                            do
                            {
                                Console.WriteLine("Please enter your item quantity");
                                quantity = Console.ReadLine();
                                bool isNumber = int.TryParse(quantity, out quantityValue);
                                if (!isNumber) Console.WriteLine("Please input a valid price number");
                                if (quantityValue <= 0)
                                {
                                    Console.WriteLine("The item quantity must be greater than 0");
                                    continue;
                                }
                                else if (quantityValue > lp.Stock) 
                                {
                                    Console.WriteLine("The item quantity must be less or equal than the existing product stock.");
                                }
                                Console.WriteLine("Halo");
                            } while (!(quantityValue<=lp.Stock) || !(quantityValue<0));
                            foreach(var lc in listCart)
                            {
                                if (lc.Code.Equals(lp.Code))
                                {
                                    lc.Quantity += quantityValue;
                                    return;
                                }
                            }
                            listCart.Add(new Cart
                            {
                                Code = lp.Code,
                                Name = lp.Name,
                                Quantity = quantityValue,
                                Price = lp.Price
                            });
                            isTrue = false;
                            return;
                            
                        }
                        else
                        {
                            isTrue = true;
                        }
                    }
                    if (isTrue == true)
                    {
                        Console.WriteLine("The Product Code was not found. Please re-enter your Product Code.");
                    }
                }
            }while(true);
        }
        // End

        // Start deleting product from cart
        public void deleteProductFromCart(List<Cart> listCart)
        {
            string? deleteInput;
            bool isTrue = true;
            do
            {
                int index = 0;
                Console.WriteLine("Please enter your Product Code from your Cart (type exit to return)");
                deleteInput = Console.ReadLine();
                if (deleteInput.Equals("exit"))
                {
                    return;
                }
                else
                {
                    foreach(var lc in listCart)
                    {
                        if (lc.Code.Equals(deleteInput))
                        {
                            listCart.RemoveAt(index);
                            isTrue = false;
                            return;
                        }
                        else
                        {
                            index++;
                            isTrue = true;
                        }
                    }
                    if(isTrue)
                    {
                        Console.WriteLine("The Product Code was not found. Please re-enter your Product Code.");
                    }
                }

            } while (true);
        }
        // End

        // Start updating product from cart
        public void updateProductFromCart(List<Cart>listCart, List<Product>listProduct)
        {
            string? updateInput;
            bool isTrue = true;
            int stockProduct = 0;
            do
            {
                Console.WriteLine("Please enter your Product Code from Cart (type exit to return): ");
                updateInput = Console.ReadLine();
                if (updateInput.Equals("exit"))
                {
                    return;
                }
                else
                {
                    foreach(var lp in listProduct)
                    {
                        if (lp.Code.Equals(updateInput))
                        {
                            stockProduct = lp.Stock;
                            break;
                        }
                    }
                    foreach(var lc in listCart)
                    {
                        if (lc.Code.Equals(updateInput))
                        {
                            string? quantity = string.Empty;
                            int quantityValue = 0;
                            do
                            {
                                Console.WriteLine("Please enter item quantity");
                                quantity = Console.ReadLine();
                                bool isNumber = int.TryParse(quantity, out quantityValue);
                                if(!isNumber)
                                {
                                    Console.WriteLine("Please input a valid quantity");
                                }
                                else if(quantityValue > stockProduct)
                                {
                                    Console.WriteLine("The combined item quantity in your cart with your new input must be less or equal than the existing product stock.");
                                }
                            } while(!(quantityValue <= stockProduct));
                            lc.Quantity = quantityValue;
                            return;
                        }
                    }
                }
            } while (true);
        }
        // End

        public void checkOut(List<Cart>listCart, List<History>listHistory, List<Product> listProduct)
        {
            menu.displayCart(listCart);
            double total = 0;
            foreach(var cart in listCart)
            {
                total += cart.Price * cart.Quantity;
            }
            Console.WriteLine("Total Price: " + total);
            string? input = string.Empty;
            bool isTrue = true;
            do
            {
                Console.WriteLine("Proceed? (Type OK to proceed, otherwise type anything beside it to back)");
                input = Console.ReadLine();
                if (input.Equals("OK"))
                {
                    foreach(var cart in listCart)
                    {
                        listHistory.Add(new History
                        {
                            Code = cart.Code,
                            Name = cart.Name,
                            Quantity = cart.Quantity,
                            Price = cart.Price,
                        });
                    }
                    foreach(var lp in listProduct)
                    {
                        foreach(var lc in listCart)
                        {
                            if (lp.Code.Equals(lc.Code))
                            {
                                lp.Stock -= lc.Quantity;
                                break;
                            }
                        }
                    }
                    listCart.Clear();
                    return;           
                }
                else
                {
                    return;
                }
            } while (true);

        }
    }
}
