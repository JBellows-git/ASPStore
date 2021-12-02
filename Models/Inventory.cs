using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GroupProject.Models
{

	public class Inventory
	{
		public int InventoryID { get; set; }

		public int InventoryNumber { get; set; }

		public string InventoryName { get; set; }

		public string InventoryDescription { get; set; }

		public int InventoryStock { get; set; }

		public decimal IventoryPrice { get; set; }

	}
}
