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

        
        //This is a "DuckTape" version of manipulating the session, it works for now might fix later
        //Consider making a "proper" shopping cart
        public RedirectToActionResult Remove(string f)
        {


            var session = new MenuSession(HttpContext.Session);
            var foods = session.GetMyFood();
            int count = 0;
            foreach (Food food in foods.ToList<Food>())
            {
                if(food.Name == f)
                {
                    foods.RemoveAt(count);
                    break;//Needed to stop the list from trying to delete all items of the same name resulting in index out of bounds
                }
                count++;
            }
            session.SetMyFoods(foods);

            return RedirectToAction("Index", "Order"); 
        }
    }
}
