using FacadePattern.Domain;
using FacadePattern.Systems;

namespace FacadePattern
{
    public static class StoreFacade
    {
        public static void AddCustomer(string name)
        {
            CustomerSystem.UpdateCustomer(new Customer { Name = name });
        }

        public static void AddItemStock(string name, decimal price)
        {
            var item = new InventoryItem
            {
                Name = name,
                Cost = price
            };

            InventorySystem.UpdateStock(item);
        }

        public static void MakePayment(decimal amount, string customerName)
        {
            // Some validation or logic on the customer record
            var customer = CustomerSystem.GetCustomer(customerName);

            // Submit payment for processing
            PaymentSystem.MakePayment(amount, customer);
        }

        public static void PurchaseItem(string customerName, string itemName, int quantity)
        {
            var item = InventorySystem.GetItem(itemName);

            var customer = CustomerSystem.GetCustomer(customerName);
            customer.ShoppingCart.Add(item, quantity);

            CustomerSystem.UpdateCustomer(customer);
        }

        public static string ViewCustomers()
        {
            return CustomerSystem.ViewCustomers();
        }

        public static string ViewInventory()
        {
            return InventorySystem.ViewStock();
        }

        public static string ViewPayments()
        {
            return PaymentSystem.ViewPayments();
        }
    }
}
