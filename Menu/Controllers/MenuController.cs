using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Menu.Models;
using System.Linq;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private MenuContext context { get; set; }
        public MenuController(MenuContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Food());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var food = context.Foods.Find(id);
            return View(food);
        }

        [HttpPost]
        public IActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                if (food.FoodId == 0)
                    context.Foods.Add(food);
                else
                    context.Foods.Update(food);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (food.FoodId == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(food);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var food = context.Foods.Find(id);
            return View(food);
        }

        [HttpPost]
        public IActionResult Delete(Food food)
        {
            context.Foods.Remove(food);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
