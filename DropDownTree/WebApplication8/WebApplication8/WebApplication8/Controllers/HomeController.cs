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
        public string[] SelectedCatogory { get; set; }
        // GET: api/Default 
        [HttpGet]
        public IEnumerable<OrdersDetails> Get()
        {
            // Fetch the Datasource of DropDownTree component
            var data = OrdersDetails.GetAllRecords().ToList();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$filter"))
            {

                string filter = string.Join("", queryString["$filter"].ToString().Split(' ').Skip(2)); // get filter from querystring
                data = data.Where(d => d.ParentId.ToString() == filter).ToList();
                return data;
            }
            else
            {
                data = data.Where(d => d.ParentId == null).ToList();
                return data;
            }
        }

        [HttpPost]
        public IActionResult SaveData()
        {
            var value = HttpContext.Request.Form["SelectedCatogory"];
            return View();
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

