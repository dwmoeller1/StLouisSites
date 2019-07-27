using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;

namespace StLouisSites.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public LocationController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            return View();
        }
         
        [HttpGet]
        public IActionResult Create()
        {
            userManager.GetUserId(User);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            context.Add(location);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}