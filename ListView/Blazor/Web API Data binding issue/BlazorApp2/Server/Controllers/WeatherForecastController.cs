using BlazorApp2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor;

namespace BlazorApp2.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public object Get()
        {
            IEnumerable DataSource = TreeDetails.GetAllRecords();
            var data = DataSource.AsQueryable();
            return data;
        }
        public class TreeDetails
        {
            public class ListData
            {
                public string Id { get; set; }
                public string Name { get; set; }
                public string DiagramJson { get; set; }
            }
            public static List<ListData> GetAllRecords()
            {
                List<ListData> m_templateData2 = new List<ListData>();
                m_templateData2.Add(new ListData { Id = "1", Name = "Local Disk(C:)"});
                m_templateData2.Add(new ListData { Id = "4", Name = "Local Disk(D:)"});
                m_templateData2.Add(new ListData { Id = "5", Name = "Local Disk(E:)"});
                return m_templateData2;
             }

        }
    }
}
