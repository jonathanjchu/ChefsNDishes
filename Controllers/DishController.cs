using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class DishController : Controller
    {
        private MyContext dbContext;

        public DishController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("dishes")]
        public IActionResult ShowDishes()
        {
            var dishes = dbContext.Dishes.Include(x => x.Creator).ToList();
            return View(dishes);
        }

        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            var chefs = dbContext.Chefs.OrderBy(c => c.FirstName).ToList();
            ViewBag.Chefs = chefs;

            return View("NewDishForm");
        }

        [HttpPost]
        [Route("dishes/new")]
        public IActionResult CreateNewDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();

                return RedirectToAction("ShowDishes");
            }
            else
            {
                return View("NewDishForm");
            }
        }

    }
}