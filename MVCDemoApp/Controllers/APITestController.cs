using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APITestController : ControllerBase
    {
        private readonly ILogger<APITestController> _logger;

        public APITestController(ILogger<APITestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<APITest> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new APITest
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}