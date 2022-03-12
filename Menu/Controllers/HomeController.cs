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

        public IActionResult Index()
        {
            var foods = context.Foods.Include(m => m.category).OrderBy(m => m.Name).ToList();
            return View(foods);
        }
    }
}
