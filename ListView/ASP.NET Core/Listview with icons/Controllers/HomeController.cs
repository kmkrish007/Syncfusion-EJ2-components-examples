using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreApplication.Models;

namespace CoreApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<object> listData = new List<object>();
            listData.Add(new
            {
                text = "Jenifer",
                contact = "(206) 555-985774",
                id = "1",
                avatar = "J",
                pic = "pic01"
            });
            listData.Add(new
            {
                text = "Amenda",
                contact = "(206) 555-3412",
                id = "2",
                avatar = "A",
                pic = ""
            });
            listData.Add(new
            {
                text = "Isabella",
                contact = "(206) 555-8122",
                id = "4",
                avatar = "",
                pic = "pic02"
            });
            listData.Add(new
            {
                text = "William ",
                contact = "(206) 555-9482",
                id = "5",
                avatar = "W",
                pic = ""
            });
            listData.Add(new
            {
                text = "Jacob",
                contact = "(71) 555-4848",
                id = "6",
                avatar = "",
                pic = "pic04"
            });
            listData.Add(new
            {
                text = "Matthew",
                contact = "(71) 555-7773",
                id = "7",
                avatar = "M",
                pic = ""
            });
            listData.Add(new
            {
                text = "Oliver",
                contact = "(71) 555-5598",
                id = "8",
                avatar = "",
                pic = "pic03"
            });
            listData.Add(new
            {
                text = "Charlotte",
                contact = "(206) 555-1189",
                id = "9",
                avatar = "C",
                pic = ""
            });
            ViewBag.listData = listData;
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
