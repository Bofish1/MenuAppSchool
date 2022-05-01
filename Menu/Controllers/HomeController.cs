using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        private MenuContext context { get; set; }

        public HomeController(MenuContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeCAt = "all")
        {
            return View();
        }
        public IActionResult List(string activeCat = "all")
        {
            var session = new MenuSession(HttpContext.Session);
           
            var model = new FoodListViewModel
            {
                ActiveCat = activeCat,
                Categories = context.Categories.ToList()
            };
            IQueryable<Food> query = context.Foods;
            if (activeCat != "all")
                query = query.Where(t => t.CategoryId.ToLower() == activeCat.ToLower());
            model.Foods = query.ToList();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            var session = new MenuSession(HttpContext.Session);
            var model = new FoodViewModel
            {
                Food = context.Foods
                .FirstOrDefault(t => t.FoodId == id)
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(FoodListViewModel model)
        {
            model.Food = context.Foods
               .Where(t => t.FoodId == model.Food.FoodId)
               .FirstOrDefault();

            var session = new MenuSession(HttpContext.Session);
            var foods = session.GetMyFood();
            foods.Add(model.Food);
            session.SetMyFoods(foods);

            return RedirectToAction("Index","Order"); //Returns you to the menu "cart"
        }

       /* public RedirectToActionResult Remove(FoodListViewModel model)
        {
           model.Food = context.Foods
               .Where(t => t.FoodId == model.Food.FoodId)
               .FirstOrDefault();

            var session = new MenuSession(HttpContext.Session);
            var foods = session.GetMyFood();
            foods.Remove(model.Food);
            session.SetMyFoods(foods);

            return RedirectToAction("Index", "Order"); //Returns you to the menu "cart"
        }*/

        public RedirectToActionResult Remove(int count)
        {
          

            var session = new MenuSession(HttpContext.Session);
            var foods = session.GetMyFood();
            foods.Reverse();//So that list will delete in the correct order
            foods.RemoveAt(count);
            session.SetMyFoods(foods);

            return RedirectToAction("Index", "Order"); //Returns you to the menu "cart"
        }
    }
}
