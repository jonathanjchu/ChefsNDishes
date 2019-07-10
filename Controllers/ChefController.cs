using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class ChefController : Controller
    {
        private MyContext dbContext;

        public ChefController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet]
        [Route("chefs")]
        public IActionResult ShowChefs()
        {
            var chefs = dbContext.Chefs.ToList();

            return View(chefs);
        }

        [HttpGet]
        [Route("chefs/new")]
        public IActionResult NewChef()
        {
            return View("NewChefForm");
        }

        [HttpPost]
        [Route("chefs/new")]
        public IActionResult CreateNewChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();

                return RedirectToAction("ShowChefs");
            }
            else
            {
                return View("NewChefForm");
            }
        }
    }
}