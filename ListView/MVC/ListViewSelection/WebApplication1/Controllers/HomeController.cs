using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Web;
using System;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<object> listdata = new List<object>();
            listdata.Add(new
            {
                text = "Asia",
                id = "01",

            });
            listdata.Add(new
            {
                text = "North America",
                id = "02",
                enabled = false
            });
            listdata.Add(new
            {
                text = "Europe",
                id = "03",
                enabled = false
            });
            listdata.Add(new
            {
                text = "Australia",
                id = "04",
            });
            listdata.Add(new
            {
                text = "Africa",
                id = "05"
            });
            ViewBag.dataSource = listdata;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}