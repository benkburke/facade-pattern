using System.Linq;
using System.Text.Json;
using FacadePattern.Domain;
using FacadePattern.Infrastructure;

namespace FacadePattern.Systems
{
    public static class InventorySystem
    {
        public static InventoryItem GetItem(string itemName)
        {
            return Db.Items.FirstOrDefault(c => c.Name == itemName);
        }

        public static void UpdateStock(InventoryItem itemUpdate)
        {
            var item = Db.Items.FirstOrDefault(i => i.Name == itemUpdate.Name);

            // Update if exists
            if (item != null)
            {
                item.Name = itemUpdate.Name;
                item.Cost = itemUpdate.Cost;

                return;
            }

            // Create if needed
            item = new InventoryItem
            {
                Name = itemUpdate.Name,
                Cost = itemUpdate.Cost
            };

            Db.Items.Add(item);
        }

        public static string ViewStock()
        {
            return JsonSerializer.Serialize(Db.Items);
        }
    }
}
