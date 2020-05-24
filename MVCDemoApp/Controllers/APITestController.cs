using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemoApp.Models;

namespace API.Controllers
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
        public IEnumerable<Employee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Employee
            {
                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
