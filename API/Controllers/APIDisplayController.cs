using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisplaySomethingController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<displaySomethingController> _logger;

        //public displaySomethingController(ILogger<displaySomethingController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<APIPage> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new APIPage
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
              //  Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
