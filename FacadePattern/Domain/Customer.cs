using System.Collections.Generic;

namespace FacadePattern.Domain
{
    public class Customer
    {
        public string Name {get; set;}
        public Dictionary<InventoryItem, int> ShoppingCart = new Dictionary<InventoryItem, int>();
    }
}
