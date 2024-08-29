﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult AddComment(int id)
        { 
            ViewBag.Id = id;    
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {  
            p.CommentDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
        
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}
