using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using BlazorApp2.Shared;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeViewController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            var val = TreeView.GetAllRecords();
            var Data = val.ToList();
            int count = Data.Count();
            return Data;

        }
    }
}
