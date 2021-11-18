using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GroupProject.Controllers
{
    //diabling roles use until we get it to where we can add and edit roles
    //[Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
