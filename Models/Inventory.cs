using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AspGroupProject.Models
{

	public class Inventory
	{
		public int InventoryNumber { get; set; }
		public string InventoryName { get; set; }
		public string InventoryDescription { get; set; }
		public int InventoryStock { get; set; }
		public double IventoryPrice { get; set; }

	}
}
