using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp2.Shared;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            // Get the DataSource from Database
            var data = WeatherForecast.GetAllRecords().ToList();
            return data;

        }
       
    }
}
