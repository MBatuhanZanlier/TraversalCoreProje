﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {  
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.usurname = values.Name + " " + values.Surname.ToUpper(); 
            ViewBag.profileımg=values.ImageUrl;
            return View();
        }
    }
}
