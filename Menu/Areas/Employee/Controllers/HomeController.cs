using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Menu.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController : Controller
    {
        private MenuContext context { get; set; }

        public HomeController(MenuContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var foods = context.Foods.Include(m => m.category).OrderBy(m => m.Name).ToList();
            return View(foods);
        }
    }
}
