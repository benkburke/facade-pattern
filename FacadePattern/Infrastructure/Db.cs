using System.Collections.Generic;
using FacadePattern.Domain;

namespace FacadePattern.Infrastructure
{
    public static class Db
    {
        public readonly static IList<Customer> Customers = new List<Customer>();
        public readonly static IList<InventoryItem> Items = new List<InventoryItem>();
        public readonly static IList<Payment> Payments = new List<Payment>();

    }
}
