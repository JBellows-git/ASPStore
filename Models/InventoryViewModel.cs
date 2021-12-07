using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GroupProject.Models
{

	public class InventoryViewModel
	{
	
		public int InventoryNumber { get; set; }

		[Required(ErrorMessage = "You must enter a name for the Inventory Item")]
		public string InventoryName { get; set; }

		[Required(ErrorMessage = "You must enter a Description for the Item")]
		public string InventoryDescription { get; set; }

		[Range(10, 2000, ErrorMessage = "You must specify between 10 and 2000 units")]		
		public int InventoryStock { get; set; }

		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal InventoryPrice { get; set; }

	}
}
