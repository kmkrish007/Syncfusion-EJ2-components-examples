using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Syncfusion.EJ2.Base;
using WebApplication8.Models;


namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult SaveData()
        {
            var value = HttpContext.Request.Form["checkTree"];
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string[] data)
        {
            var checkedNodes = data;
            return Json("success");
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "Australia",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "New South Wales",

            });
            treedata.Add(new
            {
                id = 3,
                pid = 1,
                name = "Victoria"
            });

            treedata.Add(new
            {
                id = 4,
                pid = 1,
                name = "South Australia"
            });
            treedata.Add(new
            {
                id = 6,
                pid = 1,
                name = "Western Australia",

            });
            treedata.Add(new
            {
                id = 7,
                name = "Brazil",
                hasChild = true
            });
            treedata.Add(new
            {
                id = 8,
                pid = 7,
                name = "Paraná"
            });
            treedata.Add(new
            {
                id = 9,
                pid = 7,
                name = "Ceará"
            });
            treedata.Add(new
            {
                id = 10,
                pid = 7,
                name = "Acre"
            });
            treedata.Add(new
            {
                id = 11,
                name = "China",
                hasChild = true
            });
            treedata.Add(new
            {
                id = 12,
                pid = 11,
                name = "Guangzhou"
            });
            treedata.Add(new
            {
                id = 13,
                pid = 11,
                name = "Shanghai"
            });
            treedata.Add(new
            {
                id = 14,
                pid = 11,
                name = "Beijing"
            });
            treedata.Add(new
            {
                id = 15,
                pid = 11,
                name = "Shantou"

            });
            treedata.Add(new
            {
                id = 16,
                name = "France",
                hasChild = true

            });
            treedata.Add(new
            {
                id = 17,
                pid = 16,
                name = "Pays de la Loire"

            });
            treedata.Add(new
            {
                id = 18,
                pid = 16,
                name = "Aquitaine"

            });
            treedata.Add(new
            {
                id = 19,
                pid = 16,
                name = "Brittany"

            });
            treedata.Add(new
            {
                id = 20,
                pid = 16,
                name = "Lorraine"
            });
            treedata.Add(new
            {
                id = 21,
                name = "India",
                hasChild = true

            });
            treedata.Add(new
            {
                id = 22,
                pid = 21,
                name = "Assam"

            });
            treedata.Add(new
            {
                id = 23,
                pid = 21,
                name = "Bihar"
            });
            treedata.Add(new
            {
                id = 24,
                pid = 21,
                name = "Tamil Nadu"

            });
            ViewBag.dataSource = treedata;
            ViewBag.checkedNodes = new string[] { "1" };
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

  
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails()
        {

        }
        public OrdersDetails(int? Id, int? ParentId, int Jobs, bool HasChild, string Towns)
        {
            this.Id = Id;
            this.ParentId = ParentId;
            this.Jobs = Jobs;
            this.HasChild = HasChild;
            this.Towns = Towns;
        }
        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                order.Add(new OrdersDetails(1, null, 40, true, "South-east"));
                order.Add(new OrdersDetails(2, 1, 60, true, "south-west"));
                order.Add(new OrdersDetails(3, 2, 80, false, "north-east"));
                order.Add(new OrdersDetails(4, 2, 100, false, "north-west"));
            }
            return order;
        }

        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public int Jobs { get; set; }
        public bool HasChild { get; set; }
        public string Towns { get; set; }
    }
   
    public class Data
    {

        public bool requiresCounts { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
    }

    public class SampleModel
    {
        public string[] SelectedCatogory { get; set; }
    }
}

