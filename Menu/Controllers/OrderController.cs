using Microsoft.AspNetCore.Mvc;
using Menu.Models;

namespace Menu.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Total = 0;
            var session = new MenuSession(HttpContext.Session);
            var model = new FoodListViewModel
            {
                Foods = session.GetMyFood(),
            };
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Delete(FoodListViewModel model)
        {
            var session = new MenuSession(HttpContext.Session);
            session.RemoveMyFoods();

            return RedirectToAction("Index", "Home");
        }

   


    }
}
