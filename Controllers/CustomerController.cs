﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupProject.Data;
using GroupProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GroupProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CustomerController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
