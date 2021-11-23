using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductsController(ApplicationDbContext context,
                                  IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Store()
        {
            return View(await _context.Inventories.ToListAsync());
        }

        public IActionResult NewItem()
        {
            return View();
        }

        public async Task<IActionResult> Create(InventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Inventory newInventory = new Inventory
                {
                    InventoryNumber = model.InventoryNumber,
                    InventoryName = model.InventoryName,
                    InventoryDescription = model.InventoryDescription,
                    InventoryStock = model.InventoryStock,
                    IventoryPrice = model.IventoryPrice
                };
                
                _context.Add(newInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Store");
            }

            return View();
        }
    }
}
