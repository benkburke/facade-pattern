using System;

namespace FacadePattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            string keypress;

            do
            {
                // 0)
                // Display starting menu
                Console.Clear();

                Console.WriteLine("Facade Pattern -- Retail Store Context");
                Console.WriteLine();

                // 1)
                Console.WriteLine("Select option:");

                Console.WriteLine();
                Console.WriteLine("1) Create Customer");
                Console.WriteLine("2) Create Inventory Item");

                Console.WriteLine();
                Console.WriteLine("3) Add Item to Cart");
                Console.WriteLine("4) Make Payment");

                Console.WriteLine();
                Console.WriteLine("5) View Customers");
                Console.WriteLine("6) View Inventory");
                Console.WriteLine("7) View Payments");

                var selection = Console.ReadKey().KeyChar.ToString();
                int.TryParse(selection, out int menuChoice);

                // Should be abstracted to individual methods 
                // and use another pattern such as strategy
                switch (menuChoice)
                {
                    case 1:
                        {
                            Console.Clear();

                            Console.Write("Customer Name: ");
                            var customerName = Console.ReadLine().ToString();

                            StoreFacade.AddCustomer(customerName);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            Console.Write("Item Name: ");
                            var itemName = Console.ReadLine().ToString();
                            Console.WriteLine();

                            Console.Write("Item Cost: ");
                            var itemCost = Console.ReadLine().ToString();
                            decimal.TryParse(itemCost, out decimal itemPrice);

                            StoreFacade.AddItemStock(itemName, itemPrice);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            Console.Write("Customer Name: ");
                            var customerName = Console.ReadLine().ToString();
                            Console.WriteLine();

                            Console.Write("Item Name: ");
                            var itemName = Console.ReadLine().ToString();
                            Console.WriteLine();

                            Console.Write("Item Quantity: ");
                            var itemQuantity = Console.ReadLine().ToString();
                            int.TryParse(itemQuantity, out int quantity);

                            StoreFacade.PurchaseItem(customerName, itemName, quantity);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();

                            Console.Write("Customer Name: ");
                            var customerName = Console.ReadLine().ToString();
                            Console.WriteLine();

                            Console.Write("Amount: ");
                            var paymentAmount = Console.ReadLine().ToString();
                            decimal.TryParse(paymentAmount, out decimal amount);

                            StoreFacade.MakePayment(amount, customerName);
                            break;
                        }
                    case 5:
                        Console.Clear();
                        Console.WriteLine(StoreFacade.ViewCustomers());
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine(StoreFacade.ViewInventory());
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine(StoreFacade.ViewPayments());
                        break;
                    default:
                        break;
                }

                // 3) 
                Console.WriteLine();
                Console.WriteLine("Menu ( M )");
                Console.WriteLine("Exit ( X )");

                keypress = Console.ReadKey().KeyChar.ToString();
            } while (keypress.ToLower() != "x");
        }
    }
}
