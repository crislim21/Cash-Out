using Test.Models;
using Test.Repository;
using Test.Services;

namespace Test
{
    internal class Program
    {
        private MenuService menu = new MenuService();
        private ProductService ps = new ProductService();
        private CartService cs = new CartService();
        private List<Product> listProduct = null;
        private List<Cart> listCart = null;
        private List<History> listHistory = null;
        public Program()
        {

            string menuInput = string.Empty;
            listProduct = ProductRepository.getListProduct();
            listCart = CartRepository.getListCart();
            listHistory = HistoryRepository.getListHistory();
            /// <summary>
            /// Dummy Data
            /// </summary>
            ps.dummyData(listProduct);

            while (menuInput != "4")
            {
                Console.Clear();
                menu.displayMainMenu();
                menuInput = Console.ReadLine();
                bool isNumber = int.TryParse(menuInput, out int a);
                if (!isNumber) Console.WriteLine("Input must be an numberic");
                else
                {
                    Console.WriteLine("Hello");
                    switch (a)
                    {
                        case 1:
                            addProduct(listProduct);
                            break;
                        case 2:
                            addPurchaseOut(listCart,listProduct);
                            break;
                        case 3:
                            menu.displayHistory(listHistory);
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        void addProduct(List<Product>listProduct)
        {
            Console.Clear();
            menu.displayProduct(listProduct);
            menu.displayProductMenu();
            string? productMenuInput = string.Empty;
            productMenuInput = Console.ReadLine();
            bool isNumber = int.TryParse(productMenuInput, out int b);
            if (!isNumber) Console.WriteLine("Input must be an numberic");
            else
            {
                switch (b)
                {
                    case 1:
                        ps.createProduct(listProduct);
                        break;
                    case 2:
                        ps.updateProduct(listProduct);
                        break;
                    case 3:
                        ps.deleteProduct(listProduct);
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        }

        public void addPurchaseOut(List<Cart> listCart, List<Product>listProduct)
        {
            Console.Clear();
            Console.WriteLine("Purchase Out");
            Console.WriteLine("Product List: ");
            menu.displayProduct(listProduct);
            menu.displayCart(listCart);
            menu.displayCartMenu();
            string? cartMenuInput = string.Empty;
            cartMenuInput = Console.ReadLine();

            bool isNumber = int.TryParse(cartMenuInput, out int b);
            if (!isNumber) Console.WriteLine("Input must be an numberic");
            else
            {
                switch (b)
                {
                    case 1:
                        cs.addProductToCart(listCart, listProduct);
                        break;
                    case 2:
                        cs.deleteProductFromCart(listCart);
                        break;
                    case 3:
                        cs.updateProductFromCart(listCart, listProduct);
                        break;
                    case 4:
                        cs.checkOut(listCart,listHistory, listProduct);
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}