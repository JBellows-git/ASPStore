using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace GroupProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CustomerController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        //still need to figure out how to add admin to users
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var cust = (from c in _context.Customers
                       where c.Email == User.Identity.Name
                       select c).FirstOrDefault();            
            
            return View(cust);
        }

        public IActionResult Update()
        {
            var cust = (from c in _context.Customers
                        where c.Email == User.Identity.Name
                        select c).FirstOrDefault();
            if (cust != null)
            {
                var viewCust = new CustomerViewModel
                {
                    FirstName = cust.FirstName,
                    LastName = cust.LastName,
                    Address = cust.Address,
                    City = cust.City,
                    State = cust.State,
                    Zipcode = cust.Zipcode
                };
                return View(viewCust);
            } else
            {
                return View();
            }
            
           
        }

        public async Task<IActionResult> InformationUpdate(CustomerViewModel model)
        {
            var cust = (from c in _context.Customers
                        where c.Email == User.Identity.Name
                        select c).FirstOrDefault();
            if (ModelState.IsValid)
            {
                
                if (cust != null)
                {
                    cust.FirstName = model.FirstName;
                    cust.LastName = model.LastName;
                    cust.Address = model.Address;
                    cust.City = model.City;
                    cust.State = model.State;
                    cust.Zipcode = model.Zipcode;

                    _context.SaveChanges();

                } else
                {
                    Customer newCust = new Customer
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        City = model.City,
                        State = model.State,
                        Zipcode = model.Zipcode,
                        Email = User.Identity.Name
                    };

                    _context.Add(newCust);
                    await _context.SaveChangesAsync();
                }

                
                return RedirectToAction("Index");
            }

            return RedirectToAction("Update");
        }
    }
}
