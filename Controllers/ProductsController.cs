using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RolesExampleTest.Infrastructure;
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

        [Authorize]
        [HttpGet]
        public IActionResult NewItem()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddToCart(int? id, string returnUrl)
        {
            Inventory inventory = _context.Inventories.FirstOrDefault(i => i.InventoryID == id);

            if(inventory != null)
            {
                Cart cart = GetCart();
                cart.AddItem(inventory, 1);
                SaveCart(cart);
            }

            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }
        
        public IActionResult RemoveFromCart(int? id, string returnUrl)
        {
            Inventory inventory = _context.Inventories.FirstOrDefault(i => i.InventoryID == id);

            if (inventory != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(inventory);
                SaveCart(cart);

            }


            return View("AddToCart", new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .SingleOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Inventories.SingleOrDefaultAsync(m => m.InventoryID == id);
            _context.Inventories.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Store));
        }

        private bool ProductExists(int id)
        {
            return _context.Inventories.Any(e => e.InventoryID == id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Inventory newInventory = new Inventory
                {
                    
                    InventoryName = model.InventoryName,
                    InventoryDescription = model.InventoryDescription,
                    InventoryStock = model.InventoryStock,
                    InventoryPrice = model.InventoryPrice
                };
                
                _context.Add(newInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Store");
            }

            return View();
        }
    }
}
