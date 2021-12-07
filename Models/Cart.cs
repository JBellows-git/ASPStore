using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem (Inventory inventory, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Inventory.InventoryID == inventory.InventoryID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Inventory = inventory, Quantity = quantity });
            } else
            {
                line.Quantity += quantity;
            }
        }
        
        public virtual void RemoveLine (Inventory inventory) => 
            lineCollection.RemoveAll(l => l.Inventory.InventoryID == inventory.InventoryID);
        

        public virtual decimal ComputeTotalValue() =>
            (decimal)lineCollection.Sum(e => e.Inventory.InventoryPrice * e.Quantity);
        

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Inventory Inventory { get; set; }
        public int Quantity { get; set; }
    }
}
