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
using System.ComponentModel.DataAnnotations;

namespace GroupProject.Controllers
{
    //disabling roles use until we get it to where we can add and edit roles
    //[Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {

        private RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public RoleAdminController(RoleManager<IdentityRole> roleMgr, ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            roleManager = roleMgr;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerList()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public IActionResult RoleList() => View(roleManager.Roles);

        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
