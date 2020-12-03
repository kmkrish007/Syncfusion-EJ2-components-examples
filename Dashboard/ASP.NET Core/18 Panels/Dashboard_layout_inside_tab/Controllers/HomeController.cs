using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard_layout_inside_tab.Models;
using Syncfusion.EJ2.Navigations;

namespace Dashboard_layout_inside_tab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.headerText1 = new TabHeader { Text = "New" };
            ViewBag.headerText2 = new TabHeader { Text = "In-Progress" };
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
