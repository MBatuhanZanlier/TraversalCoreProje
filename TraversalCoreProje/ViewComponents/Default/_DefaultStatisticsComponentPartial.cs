﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count(); 
            ViewBag.v2=c.Guides.Count();
            ViewBag.v3 = "285";
            return View();  
        }
    }
}
