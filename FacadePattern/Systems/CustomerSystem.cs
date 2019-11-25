using System.Linq;
using System.Text.Json;
using FacadePattern.Domain;
using FacadePattern.Infrastructure;

namespace FacadePattern.Systems
{
    public static class CustomerSystem
    {
        public static Customer GetCustomer(string customerName)
        {
            return Db.Customers.FirstOrDefault(c => c.Name == customerName);
        }

        public static void UpdateCustomer(Customer customerUpdate)
        {
            var customer = Db.Customers.FirstOrDefault(c => c.Name == customerUpdate.Name);

            // Update if exists
            if (customer != null)
            {
                customer.Name = customerUpdate.Name;
                customer.ShoppingCart = customerUpdate.ShoppingCart;

                return;
            }

            // Create if needed
            customer = new Customer
            {
                Name = customerUpdate.Name
            };
            Db.Customers.Add(customer);
        }

        public static string ViewCustomers()
        {
            return JsonSerializer.Serialize(Db.Customers);
        }
    }
}
